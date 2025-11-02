Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1
Imports Org.BouncyCastle.Crypto.Engines.SM2Engine

Public Class FormSiswa
    Private Sub fillComboBoxTahunAjar()
        ' Mengisi ComboBoxTahunAjar dengan data dari tabel kelas
        Try
            Dim sql As String = "SELECT DISTINCT tahunajar FROM kelas"
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
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub insertNewKelasPerTahun(conn As MySqlConnection, tx As MySqlTransaction)
        Dim sqlInsertKelasPerTahun As String = "INSERT INTO kelas_per_tahun (nisn, idKelas) VALUES (@nisn, (SELECT idKelas FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar))"
        Using cmdInsert = New MySql.Data.MySqlClient.MySqlCommand(sqlInsertKelasPerTahun, conn, tx)
            cmdInsert.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
            cmdInsert.Parameters.AddWithValue("@namakelas", ComboBoxKelas.Text)
            cmdInsert.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
            cmdInsert.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub insertNewSiswa()
        If String.IsNullOrWhiteSpace(TextBoxNISN.Text) Or String.IsNullOrWhiteSpace(TextBoxNama.Text) Or String.IsNullOrWhiteSpace(ComboBoxTahunAjar.Text) Then
            MessageBox.Show("NISN, Nama, dan Kelas harus diisi.", "Input Diperlukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn = DatabaseConnector.GetConnection()
            conn.Open()
            Using tx = conn.BeginTransaction()
                Try
                    ' Insert siswa
                    Dim sql As String = "INSERT INTO siswa (nisn, nama) VALUES (@nisn, @nama)"
                    Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn, tx)
                        cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                        cmd.Parameters.AddWithValue("@nama", TextBoxNama.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Insert kelas_per_tahun
                    insertNewKelasPerTahun(conn, tx)

                    ' Increment jumlahsiswa by diKelas (ComboBox holds idKelas)
                    Dim updateKelasSql As String = "UPDATE kelas SET jumlahsiswa = jumlahsiswa + 1 WHERE idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar)"
                    Using cmd = New MySql.Data.MySqlClient.MySqlCommand(updateKelasSql, conn, tx)
                        cmd.Parameters.AddWithValue("@namakelas", ComboBoxKelas.Text)
                        cmd.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
                        cmd.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                    MessageBox.Show("Data siswa berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    tx.Rollback()
                    Throw
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If (TextBoxNama.Text.Equals("") Or TextBoxNISN.Text.Equals("") Or ComboBoxTahunAjar.Text.Equals("")) Then
            MessageBox.Show("Setiap data siswa tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim checkSql As String = "SELECT COUNT(*) FROM siswa WHERE nisn = @nisn"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(checkSql, conn)
                    cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count > 0 Then
                        ' Existing student: add kelas_per_tahun and increment kelas in single transaction
                        Using tx = conn.BeginTransaction()
                            Try
                                insertNewKelasPerTahun(conn, tx)
                                Dim updateKelasSql As String = "UPDATE kelas SET jumlahsiswa = jumlahsiswa + 1 WHERE idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar)"
                                Using cmd2 = New MySql.Data.MySqlClient.MySqlCommand(updateKelasSql, conn, tx)
                                    cmd2.Parameters.AddWithValue("@namakelas", ComboBoxKelas.Text)
                                    cmd2.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
                                    cmd2.ExecuteNonQuery()
                                End Using
                                tx.Commit()
                                MessageBox.Show("Kelas per tahun tambahan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Catch ex As Exception
                                tx.Rollback()
                                Throw
                            End Try
                        End Using
                    Else
                        ' New student: perform full insert (handled in insertNewSiswa)
                        insertNewSiswa()
                    End If
                End Using
            End Using

            ' Membuat tagihan baru untuk siswa
            Dim relatedJenisPembayaran As New List(Of Tuple(Of String, String))()

            Dim sqlSelectRelatedTagihan As String = "SELECT kode_jenis_pembayaran, nama_pembayaran FROM jenis_pembayaran WHERE tahunajar = @tahunajar"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlSelectRelatedTagihan, conn)
                    cmd.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim kode As String = If(IsDBNull(rdr("kode_jenis_pembayaran")), String.Empty, rdr("kode_jenis_pembayaran").ToString().Trim())
                            Dim nama As String = If(IsDBNull(rdr("nama_pembayaran")), String.Empty, rdr("nama_pembayaran").ToString().Trim())
                            If kode <> String.Empty Then
                                relatedJenisPembayaran.Add(Tuple.Create(kode, nama))
                            End If
                        End While
                    End Using
                End Using
            End Using

            For Each jenisPembayaran In relatedJenisPembayaran
                Dim jenisPembayaranId As String = jenisPembayaran.Item1
                Dim jenisPembayaranNama As String = jenisPembayaran.Item2
                ' Jika jenis pembayaran adalah SPP, buat tagihan untuk setiap bulan dalam tahun ajaran
                If jenisPembayaranNama.Equals("SPP") Then
                    For month As Integer = 1 To 12
                        Dim periode As String = ComboBoxTahunAjar.Text & "-" & month.ToString("D2")
                        Dim sqlInsertSppTagihan As String = "INSERT INTO tagihan (kode_tagihan, nisn, periode, status, kode_jenis_pembayaran) VALUES (@kode_tagihan, @nisn, @periode, 'Belum Lunas', @kode_jenis_pembayaran)"
                        Using conn = DatabaseConnector.GetConnection()
                            Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlInsertSppTagihan, conn)
                                cmd.Parameters.AddWithValue("@kode_tagihan", TextBoxNISN.Text & "_" & periode & "_" & jenisPembayaranId)
                                cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                                cmd.Parameters.AddWithValue("@periode", periode)
                                cmd.Parameters.AddWithValue("@kode_jenis_pembayaran", jenisPembayaranId)
                                conn.Open()
                                cmd.ExecuteNonQuery()
                            End Using
                        End Using
                    Next
                    Continue For
                End If

                Dim sqlInsertSiswaTagihan As String = "INSERT INTO tagihan (kode_tagihan, nisn, periode, status, kode_jenis_pembayaran) VALUES (@kode_tagihan, @nisn, @periode, 'Belum Lunas', @kode_jenis_pembayaran)"
                Using conn = DatabaseConnector.GetConnection()
                    Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlInsertSiswaTagihan, conn)
                        cmd.Parameters.AddWithValue("@kode_tagihan", TextBoxNISN.Text & "_" & ComboBoxTahunAjar.Text & "_" & jenisPembayaranId)
                        cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                        cmd.Parameters.AddWithValue("@periode", ComboBoxTahunAjar.Text)
                        cmd.Parameters.AddWithValue("@kode_jenis_pembayaran", jenisPembayaranId)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Next
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Clear inputs
        TextBoxNISN.Text = ""
        TextBoxNama.Text = ""
        ComboBoxTahunAjar.Items.Clear()
        ComboBoxKelas.Items.Clear()
        fillComboBoxTahunAjar()

        ' Refresh grid
        LoadSiswa()
    End Sub

    Private Sub FormSiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxKelas.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxTahunAjar.DropDownStyle = ComboBoxStyle.DropDownList

        ' Mengisi ComboBoxKelas dengan data dari tabel kelas
        Try
            Dim sql As String = "SELECT DISTINCT tahunajar FROM kelas"
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
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Load all siswa initially
        LoadSiswa()
    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        ' Call the shared load method with search text
        LoadSiswa(TextBoxSearch.Text)
    End Sub

    Private Sub LoadSiswa(Optional ByVal search As String = "")
        Try
            Dim sql As String
            If String.IsNullOrWhiteSpace(search) Then
                sql = "SELECT s.nisn, s.nama, k.namakelas, k.tahunajar FROM siswa s JOIN kelas_per_tahun kp ON s.nisn = kp.nisn JOIN kelas k ON kp.idKelas = k.idKelas ORDER BY s.nama"
            Else
                sql = "SELECT s.nisn, s.nama, k.namakelas, k.tahunajar FROM siswa s JOIN kelas_per_tahun kp ON s.nisn = kp.nisn JOIN kelas k ON kp.idKelas = k.idKelas WHERE s.nisn LIKE @search OR s.nama LIKE @search OR k.namakelas LIKE @search OR k.tahunajar LIKE @search ORDER BY s.nama"
            End If

            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    If Not String.IsNullOrWhiteSpace(search) Then
                        cmd.Parameters.AddWithValue("@search", "%" & search & "%")
                    End If
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        dgvSiswa.DataSource = Nothing
                        dgvSiswa.DataSource = dt
                        dgvSiswa.Columns("nisn").HeaderText = "NISN"
                        dgvSiswa.Columns("nama").HeaderText = "Nama Lengkap"
                        dgvSiswa.Columns("namakelas").HeaderText = "Kelas"
                        dgvSiswa.Columns("tahunajar").HeaderText = "Tahun Ajar"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data siswa: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub clearInputFields()
        ' Clear inputs
        TextBoxNISN.Text = ""
        TextBoxNISN.ReadOnly = False
        TextBoxNama.Text = ""
        ComboBoxTahunAjar.Text = ""
        ComboBoxTahunAjar.Enabled = True
        ComboBoxKelas.Items.Clear()
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Validasi input
        If (TextBoxNama.Text.Equals("")) Then
            MessageBox.Show("Setiap data siswa tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update database siswa
        Try
            Dim sql As String = "UPDATE siswa SET nama = @nama WHERE nisn = @nisn"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                    cmd.Parameters.AddWithValue("@nama", TextBoxNama.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data siswa berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui data: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Decrement jumlah siswa di tabel kelas lama dan increment di kelas baru jika ada perubahan
        Try
            Dim sqlDecrement As String = "UPDATE kelas SET jumlahsiswa = jumlahsiswa - 1 WHERE idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @old_namakelas AND tahunajar = @old_tahunajar)"
            Dim sqlIncrement As String = "UPDATE kelas SET jumlahsiswa = jumlahsiswa + 1 WHERE idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @new_namakelas AND tahunajar = @new_tahunajar)"
            ' Dapatkan data kelas lama
            Dim old_namakelas As String = ""
            Dim old_tahunajar As String = ""
            Dim sqlGetOldKelas As String = "SELECT k.namakelas, k.tahunajar FROM kelas_per_tahun kp JOIN kelas k ON kp.idKelas = k.idKelas WHERE kp.nisn = @nisn"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlGetOldKelas, conn)
                    cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            old_namakelas = rdr("namakelas").ToString()
                            old_tahunajar = rdr("tahunajar").ToString()
                        End If
                    End Using
                End Using
            End Using
            ' Jika ada perubahan kelas atau tahun ajar, lakukan update jumlahsiswa
            If old_namakelas <> ComboBoxKelas.Text Or old_tahunajar <> ComboBoxTahunAjar.Text Then
                Using conn = DatabaseConnector.GetConnection()
                    Using cmdDecrement = New MySql.Data.MySqlClient.MySqlCommand(sqlDecrement, conn)
                        cmdDecrement.Parameters.AddWithValue("@old_namakelas", old_namakelas)
                        cmdDecrement.Parameters.AddWithValue("@old_tahunajar", old_tahunajar)
                        conn.Open()
                        cmdDecrement.ExecuteNonQuery()
                    End Using
                    Using cmdIncrement = New MySql.Data.MySqlClient.MySqlCommand(sqlIncrement, conn)
                        cmdIncrement.Parameters.AddWithValue("@new_namakelas", ComboBoxKelas.Text)
                        cmdIncrement.Parameters.AddWithValue("@new_tahunajar", ComboBoxTahunAjar.Text)
                        cmdIncrement.ExecuteNonQuery()
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui jumlah siswa di kelas: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Update kelas_per_tahun jika kelas atau tahun ajar diubah
        Try
            Dim sqlUpdateKelasPerTahun As String = "UPDATE kelas_per_tahun SET idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar) WHERE nisn = @nisn"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlUpdateKelasPerTahun, conn)
                    cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                    cmd.Parameters.AddWithValue("@namakelas", ComboBoxKelas.Text)
                    cmd.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui kelas per tahun: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Reset ComboBoxTahunAjar
        ComboBoxTahunAjar.Items.Clear()
        fillComboBoxTahunAjar()

        ' Clear inputs
        clearInputFields()

        ' Load ulang data siswa
        LoadSiswa()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Konfirmasi penghapusan
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data siswa ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Try
            ' Decrement jumlah siswa di tabel kelas
            Dim updateKelasSql As String = "UPDATE kelas k SET jumlahsiswa = jumlahsiswa - 1 WHERE idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar)"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(updateKelasSql, conn)
                    cmd.Parameters.AddWithValue("@namakelas", dgvSiswa.CurrentRow.Cells("namakelas").Value.ToString)
                    cmd.Parameters.AddWithValue("@tahunajar", dgvSiswa.CurrentRow.Cells("tahunajar").Value.ToString)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui jumlah siswa di kelas: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Hapus data kelas_per_tahun terlebih dahulu karena ada foreign key constraint
        Try
            Dim sql As String = "DELETE FROM kelas_per_tahun WHERE nisn = @nisn AND idKelas = (SELECT idKelas FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar)"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                    cmd.Parameters.AddWithValue("@namakelas", dgvSiswa.CurrentRow.Cells("namakelas").Value.ToString)
                    cmd.Parameters.AddWithValue("@tahunajar", dgvSiswa.CurrentRow.Cells("tahunajar").Value.ToString)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Data siswa berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Jika kelas_per_tahun dengan nisn tersebut sudah tidak ada lagi, hapus juga data siswa
        Try
            Dim sqlCheck As String = "SELECT COUNT(*) FROM kelas_per_tahun WHERE nisn = @nisn"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlCheck, conn)
                    cmd.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count = 0 Then
                        ' Hapus data siswa
                        Dim sqlDeleteSiswa As String = "DELETE FROM siswa WHERE nisn = @nisn"
                        Using cmdDelete = New MySql.Data.MySqlClient.MySqlCommand(sqlDeleteSiswa, conn)
                            cmdDelete.Parameters.AddWithValue("@nisn", TextBoxNISN.Text)
                            cmdDelete.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data siswa: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Clear inputs
        clearInputFields()

        ' Load ulang data siswa
        LoadSiswa()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        fillComboBoxTahunAjar()

        ' Clear inputs
        clearInputFields()
    End Sub

    Private Sub ComboBoxTahunAjar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTahunAjar.SelectedIndexChanged
        ' Jika text kosong maka disable ComboBoxKelas dan kosongkan isinya
        If String.IsNullOrWhiteSpace(ComboBoxTahunAjar.Text) Then
            ComboBoxKelas.Items.Clear()
            ComboBoxKelas.Enabled = False
            Return
        End If

        ComboBoxKelas.Enabled = True
        ' Mengisi ComboBoxKelas dengan data dari tabel kelas
        Try
            Dim sql As String = "SELECT namakelas FROM kelas WHERE tahunajar = @tahunajar"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    cmd.Parameters.AddWithValue("@tahunajar", ComboBoxTahunAjar.Text)
                    Using rdr = cmd.ExecuteReader()
                        ComboBoxKelas.Items.Clear()
                        While rdr.Read()
                            ComboBoxKelas.Items.Add(rdr("namakelas").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data kelas: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvSiswa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSiswa.CellContentClick

        Dim selectedRow As DataGridViewRow = dgvSiswa.Rows(e.RowIndex)
        If dgvSiswa.Columns(e.ColumnIndex).Name = "dgvBtnEdit" Then
            ' Isikan data siswa ke form input untuk diedit (kecuali nisn)
            If e.RowIndex >= 0 Then
                TextBoxNISN.AcceptsReturn = False ' NISN tidak boleh diedit
                TextBoxNISN.ReadOnly = True
                ComboBoxTahunAjar.Enabled = False ' Tahun Ajar tidak boleh diedit
                TextBoxNISN.Text = selectedRow.Cells("nisn").Value.ToString()
                TextBoxNama.Text = selectedRow.Cells("nama").Value.ToString()
                ComboBoxTahunAjar.Text = selectedRow.Cells("tahunajar").Value.ToString()
                ComboBoxKelas.Text = selectedRow.Cells("namakelas").Value.ToString()
            End If
            ' Fokus ke TextBoxNISN untuk memudahkan edit
            TextBoxNama.Focus()

            ' nyalakan tombol Edit, Hapus, dan Batal matikan Simpan
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
            btnBatal.Enabled = True
        ElseIf dgvSiswa.Columns(e.ColumnIndex).Name = "dgvBtnHapus" Then
            ' Hapus data siswa
            If e.RowIndex >= 0 Then
                TextBoxNISN.Text = selectedRow.Cells("nisn").Value.ToString()
                btnHapus.Enabled = True
                btnHapus.PerformClick()
                btnHapus.Enabled = False
            End If
        End If

    End Sub
End Class