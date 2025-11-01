Imports Org.BouncyCastle.Asn1
Imports Org.BouncyCastle.Crypto.Engines.SM2Engine

Public Class FormJenisPembayaran

    Private Sub FormJenisPembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menambah opsi combobox tahun ajar berdasarkan database kelas
        ComboBoxTahunAjar.DropDownStyle = ComboBoxStyle.DropDownList
        Try
            Dim sql As String = "SELECT DISTINCT tahunajar FROM kelas ORDER BY tahunajar DESC"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        ComboBoxTahunAjar.Items.Clear()
                        While rdr.Read()
                            ComboBoxTahunAjar.Items.Add(rdr("tahunajar").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Consider logging the exception; keep UI responsive
        End Try
        LoadJenisPembayaran()
    End Sub

    Private Sub LoadJenisPembayaran()
        Try
            Dim sql As String = "SELECT kode_jenis_pembayaran, nama_pembayaran, nominal FROM jenis_pembayaran ORDER BY nama_pembayaran"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        dt.Columns("kode_jenis_pembayaran").ColumnName = "Kode Jenis Pembayaran"
                        dt.Columns("nama_pembayaran").ColumnName = "Nama Pembayaran"
                        dt.Columns("nominal").ColumnName = "Nominal"

                        dgvJenisPembayaran.DataSource = Nothing
                        dgvJenisPembayaran.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateKodeFromName(ByVal name As String) As String
        If String.IsNullOrWhiteSpace(name) Then
            Return String.Empty
        End If

        ' Split on spaces, take first letter of each word, keep letters only, uppercase
        Dim parts = name.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        Dim sb As New System.Text.StringBuilder()
        For Each p In parts
            Dim ch = p.Trim().FirstOrDefault()
            If Char.IsLetter(ch) Then
                sb.Append(Char.ToUpperInvariant(ch))
            ElseIf ch <> Nothing Then
                ' If first char is not a letter, try to find the first letter in the word
                Dim firstLetter = p.FirstOrDefault(Function(c) Char.IsLetter(c))
                If firstLetter <> Nothing Then
                    sb.Append(Char.ToUpperInvariant(firstLetter))
                End If
            End If
        Next

        Dim baseCode = sb.ToString()
        If String.IsNullOrEmpty(baseCode) Then
            ' Fallback: use first three characters of the name (sanitized)
            Dim clean = New String(name.Where(Function(c) Char.IsLetterOrDigit(c)).ToArray()).ToUpperInvariant()
            Return If(clean.Length <= 3, clean, clean.Substring(0, 3))
        End If

        ' Ensure uniqueness by appending tahun ajar
        Dim uniqueCode = baseCode & ComboBoxTahunAjar.Text
        If KodeExists(uniqueCode) Then
            MessageBox.Show("Kode jenis pembayaran yang dihasilkan sudah ada. Silakan ubah nama pembayaran untuk menghasilkan kode unik.", "Kode Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End If

        Return uniqueCode
    End Function

    Private Function KodeExists(ByVal kode As String) As Boolean
        Try
            Dim sql As String = "SELECT COUNT(1) FROM jenis_pembayaran WHERE kode_jenis_pembayaran = @kode"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@kode", kode)
                    conn.Open()
                    Dim cnt = Convert.ToInt32(cmd.ExecuteScalar())
                    Return cnt > 0
                End Using
            End Using
        Catch ex As Exception
            ' On error assume code does not exist (prevents blocking save). You may want to log the exception.
            Return False
        End Try
    End Function

    Private Sub buatTagihanBiasa(kode As String, nisn As String)
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmdInsertTagihan = New MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tagihan (kode_tagihan, nisn, periode, status, kode_jenis_pembayaran) VALUES (@kodetagihan, @nisn, @periode, 'belum bayar', @kode_jenis_pembayaran)", conn)
                    conn.Open()
                    cmdInsertTagihan.Parameters.AddWithValue("@kodetagihan", nisn & "_" & ComboBoxTahunAjar.Text & "_" & kode)
                    cmdInsertTagihan.Parameters.AddWithValue("@nisn", nisn)
                    cmdInsertTagihan.Parameters.AddWithValue("@periode", ComboBoxTahunAjar.Text)
                    cmdInsertTagihan.Parameters.AddWithValue("@kode_jenis_pembayaran", kode)
                    cmdInsertTagihan.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal membuat tagihan untuk NISN " & nisn & ": " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi input
        If String.IsNullOrWhiteSpace(txtNamaPembayaran.Text) Then
            MessageBox.Show("Nama Pembayaran tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Generate kode otomatis berdasarkan huruf pertama tiap kata pada nama pembayaran
        Dim kode = GenerateKodeFromName(txtNamaPembayaran.Text)
        If kode Is Nothing Then
            ' Kode duplikat atau error saat generate
            MessageBox.Show("Jenis Pembayaran sudah ada di periode yang sama. Mohon untuk tidak menduplikasi jenis pembayaran pada periode yang sama", "Error Kode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Simpan data ke database
        Try
            ' Insert ke database jenis_pembayaran
            Dim sql As String = "INSERT INTO jenis_pembayaran (kode_jenis_pembayaran, nama_pembayaran, nominal, tahunajar) VALUES (@kode_jenis_pembayaran, @nama_pembayaran, @nominal, @tahunajar)"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@kode_jenis_pembayaran", kode)
                    cmd.Parameters.AddWithValue("@nama_pembayaran", txtNamaPembayaran.Text)
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToDecimal(numNominal.Value))
                    cmd.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data Jenis Pembayaran berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using

            ' Ambil semua nisn siswa untuk tahun ajar tersebut, collect first then close reader
            Dim nisnList As New List(Of String)
            Dim sqlSiswa As String = "SELECT s.nisn FROM siswa s JOIN kelas_per_tahun kp ON s.nisn = kp.nisn JOIN kelas k ON kp.idKelas = k.idKelas WHERE k.tahunajar = @tahunajar"
            Using conn = DatabaseConnector.GetConnection()
                Using cmdSiswa = New MySql.Data.MySqlClient.MySqlCommand(sqlSiswa, conn)
                    cmdSiswa.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text.ToString())
                    conn.Open()
                    Using rdr = cmdSiswa.ExecuteReader()
                        While rdr.Read()
                            nisnList.Add(rdr("nisn").ToString())
                        End While
                    End Using
                End Using
            End Using

            ' Now iterate the collected list and create tagihan (reader is closed now)
            For Each nisn As String In nisnList
                If String.Equals(txtNamaPembayaran.Text.Trim(), "SPP", StringComparison.OrdinalIgnoreCase) Then
                    ' Jika jenis pembayaran adalah SPP, buat tagihan untuk setiap bulan
                    Dim sqlTambahTagihanSPP As String = "INSERT INTO tagihan (kode_tagihan, nisn, periode, status, kode_jenis_pembayaran) VALUES (@kodetagihan, @nisn, @periode, 'belum bayar', @kode_jenis_pembayaran)"
                    Using conn2 = DatabaseConnector.GetConnection()
                        conn2.Open()
                        For month As Integer = 1 To 12
                            Using cmdInsertTagihanSPP = New MySql.Data.MySqlClient.MySqlCommand(sqlTambahTagihanSPP, conn2)
                                Dim periodeSPP As String = ComboBoxTahunAjar.Text & "-" & month.ToString("D2")
                                cmdInsertTagihanSPP.Parameters.AddWithValue("@kodetagihan", nisn & "_" & periodeSPP & "_" & kode)
                                cmdInsertTagihanSPP.Parameters.AddWithValue("@nisn", nisn)
                                cmdInsertTagihanSPP.Parameters.AddWithValue("@periode", periodeSPP)
                                cmdInsertTagihanSPP.Parameters.AddWithValue("@kode_jenis_pembayaran", kode)
                                cmdInsertTagihanSPP.ExecuteNonQuery()
                            End Using
                        Next
                    End Using
                Else
                    ' Untuk jenis pembayaran lainnya, buat satu tagihan
                    buatTagihanBiasa(kode, nisn)
                End If
            Next

            txtNamaPembayaran.Clear()
            numNominal.Value = 0
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Refresh grid
        LoadJenisPembayaran()
    End Sub

    Private Sub dgvJenisPembayaran_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvJenisPembayaran.CellMouseDoubleClick
        ' Masukkan data ke TextBox untuk diedit
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvJenisPembayaran.Rows.Count Then
            Return
        End If
        Dim selectedRow As DataGridViewRow = dgvJenisPembayaran.Rows(e.RowIndex)
        txtNamaPembayaran.Text = selectedRow.Cells("Nama Pembayaran").Value.ToString()
        numNominal.Value = Convert.ToDecimal(selectedRow.Cells("Nominal").Value)

        ' Aktifkan tombol Edit, Hapus, dan Batal. nonaktifkan Simpan
        btnSimpan.Enabled = False
        btnEdit.Enabled = True
        btnHapus.Enabled = True
        btnBatal.Enabled = True
        txtNamaPembayaran.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Validasi input
        If String.IsNullOrWhiteSpace(txtNamaPembayaran.Text) Then
            MessageBox.Show("Nama Pembayaran tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update data di database
        Try
            Dim sql As String = "UPDATE jenis_pembayaran SET nama_pembayaran = @nama_pembayaran, nominal = @nominal WHERE kode_jenis_pembayaran = @kode_jenis_pembayaran"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    ' Gunakan nilai kode dari DataGridView untuk WHERE clause
                    Dim selectedRow As DataGridViewRow = dgvJenisPembayaran.SelectedRows(0)
                    Dim kode As String = selectedRow.Cells("Kode Jenis Pembayaran").Value.ToString()
                    cmd.Parameters.AddWithValue("@nama_pembayaran", txtNamaPembayaran.Text)
                    cmd.Parameters.AddWithValue("@nominal", Convert.ToDecimal(numNominal.Value))
                    cmd.Parameters.AddWithValue("@kode_jenis_pembayaran", kode)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Data Jenis Pembayaran berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNamaPembayaran.Clear()
            numNominal.Value = 0
        Catch ex As Exception
            MessageBox.Show("Gagal mengupdate data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Refresh grid
        LoadJenisPembayaran()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

        ' Konfirmasi penghapusan
        Dim result = MessageBox.Show("Apakah Anda yakin ingin menghapus data Jenis Pembayaran ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        ' Hapus data dari database
        Try
            Dim sql As String = "DELETE FROM jenis_pembayaran WHERE kode_jenis_pembayaran = @kode_jenis_pembayaran"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    ' Gunakan nilai kode dari DataGridView untuk WHERE clause
                    Dim selectedRow As DataGridViewRow = dgvJenisPembayaran.SelectedRows(0)
                    Dim kode As String = selectedRow.Cells("Kode Jenis Pembayaran").Value.ToString()
                    cmd.Parameters.AddWithValue("@kode_jenis_pembayaran", kode)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Data Jenis Pembayaran berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNamaPembayaran.Clear()
            numNominal.Value = 0
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Refresh grid
        LoadJenisPembayaran()

    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Reset tombol dan TextBox
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        txtNamaPembayaran.Clear()
        numNominal.Value = 0
    End Sub
End Class