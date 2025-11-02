Public Class FormKelas
    Private Sub LoadDataKelas()
        Try
            ' Use existing columns from table "kelas"
            Dim sql As String = "SELECT idKelas, namakelas, jumlahsiswa, tahunajar FROM kelas ORDER BY namakelas"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        ' Bind to DataGridView using mapped columns (prevent auto-generated duplicate columns)
                        dgvKelas.DataSource = Nothing
                        dgvKelas.DataSource = dt
                        dgvKelas.Columns("idKelas").HeaderText = "ID Kelas"
                        dgvKelas.Columns("namakelas").HeaderText = "Nama Kelas"
                        dgvKelas.Columns("jumlahsiswa").HeaderText = "Jumlah Siswa"
                        dgvKelas.Columns("tahunajar").HeaderText = "Tahun Ajar"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' cek database, apakah sudah ada kelas yang terbuat untuk tiap tahun ajar
        Try
            Dim sql As String = "SELECT DISTINCT tahunajar FROM kelas ORDER BY tahunajar DESC"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        cmbTahunAjar.Items.Clear()
                        While rdr.Read()
                            cmbTahunAjar.Items.Add(rdr("tahunajar").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data tahun ajar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub FormKelas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' dgvKelas.AutoGenerateColumns = False
        cmbTahunAjar = New PHComboBox With {
            .PlaceHolderText = "2024-2025"
        }
        Me.Controls.Add(cmbTahunAjar)
        cmbTahunAjar.Location = New Point(txtNamaKelas.Location.X, TahunAjar.Location.Y)
        cmbTahunAjar.Size = txtNamaKelas.Size
        cmbTahunAjar.BringToFront()


        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False

        LoadDataKelas()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi input
        If String.IsNullOrWhiteSpace(txtNamaKelas.Text) Or String.IsNullOrWhiteSpace(cmbTahunAjar.Text) Then
            MessageBox.Show("Nama Kelas tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Simpan data ke database
        Try
            Dim sql As String = "INSERT INTO kelas (idKelas, namakelas, jumlahsiswa, tahunajar) VALUES (@idKelas, @namakelas, @jumlahsiswa, @tahunajar)"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idKelas", txtNamaKelas.Text & "_" & cmbTahunAjar.Text)
                    cmd.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                    cmd.Parameters.AddWithValue("@jumlahsiswa", 0)
                    cmd.Parameters.AddWithValue("@tahunajar", cmbTahunAjar.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data Kelas berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtNamaKelas.Clear()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Refresh data in DataGridView
        LoadDataKelas()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Konfirmasi penghapusan
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus kelas ini?\nSeluruh data siswa yang terkait dengan kelas ini akan terhapus juga!", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Return
        End If

        ' Validate selected row
        If dgvKelas.CurrentRow Is Nothing OrElse dgvKelas.CurrentRow.Cells("namakelas").Value Is Nothing Then
            MessageBox.Show("Tidak ada kelas yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim namaKelasVal As String = dgvKelas.CurrentRow.Cells("namakelas").Value.ToString()
        Dim tahunAjar As String = Nothing
        Dim idKelasVal As String = Nothing

        ' Defensive logging helper
        Dim logPath As String = System.IO.Path.Combine(Application.StartupPath, "error_log.txt")
        Dim SubLog As Action(Of String) = Sub(msg)
                                              Try
                                                  System.IO.File.AppendAllText(logPath, DateTime.Now.ToString("s") & " - " & msg & Environment.NewLine)
                                              Catch
                                              End Try
                                          End Sub

        Try
            ' Step 1: get tahunajar and idKelas (use its own short-lived connection)
            Try
                Dim sqlGetInfo As String = "SELECT tahunajar, idKelas FROM kelas WHERE namakelas = @namakelas LIMIT 1"
                Using connRead = DatabaseConnector.GetConnection()
                    Using cmdGet = New MySql.Data.MySqlClient.MySqlCommand(sqlGetInfo, connRead)
                        cmdGet.Parameters.AddWithValue("@namakelas", namaKelasVal)
                        connRead.Open()
                        Using rdr = cmdGet.ExecuteReader()
                            If rdr.Read() Then
                                If Not IsDBNull(rdr("tahunajar")) Then tahunAjar = rdr("tahunajar").ToString()
                                If Not IsDBNull(rdr("idKelas")) Then idKelasVal = rdr("idKelas").ToString()
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                SubLog("Failed resolving idKelas: " & ex.ToString())
                Throw
            End Try

            If String.IsNullOrWhiteSpace(idKelasVal) Then
                MessageBox.Show("idKelas tidak ditemukan untuk kelas: " & namaKelasVal, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Step 2: collect all nisn for the kelas into a list while reader + connection are short-lived
            Dim nisnList As New List(Of String)()
            Try
                Dim sqlGetSiswa As String = "SELECT nisn FROM kelas_per_tahun WHERE idKelas = @idKelas"
                Using connRead = DatabaseConnector.GetConnection()
                    Using cmdGetSiswa = New MySql.Data.MySqlClient.MySqlCommand(sqlGetSiswa, connRead)
                        cmdGetSiswa.Parameters.AddWithValue("@idKelas", idKelasVal)
                        connRead.Open()
                        Using rdr = cmdGetSiswa.ExecuteReader()
                            While rdr.Read()
                                nisnList.Add(rdr("nisn").ToString())
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                SubLog("Failed collecting nisn list: " & ex.ToString())
                Throw
            End Try

            ' Step 3: perform deletes inside a transaction on a fresh connection
            Try
                Using connDel = DatabaseConnector.GetConnection()
                    connDel.Open()
                    Using tx = connDel.BeginTransaction()
                        Try
                            For Each nisn As String In nisnList
                                ' Delete kelas_per_tahun entry
                                Using cmdDeleteKelasPerTahun = New MySql.Data.MySqlClient.MySqlCommand("DELETE FROM kelas_per_tahun WHERE idKelas = @idKelas AND nisn = @nisn", connDel, tx)
                                    cmdDeleteKelasPerTahun.Parameters.AddWithValue("@idKelas", idKelasVal)
                                    cmdDeleteKelasPerTahun.Parameters.AddWithValue("@nisn", nisn)
                                    cmdDeleteKelasPerTahun.ExecuteNonQuery()
                                End Using

                                ' Check remaining kelas_per_tahun for nisn
                                Using cmdCheck = New MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) FROM kelas_per_tahun WHERE nisn = @nisn", connDel, tx)
                                    cmdCheck.Parameters.AddWithValue("@nisn", nisn)
                                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                                    If count = 0 Then
                                        ' Delete siswa row
                                        Using cmdDeleteSiswa = New MySql.Data.MySqlClient.MySqlCommand("DELETE FROM siswa WHERE nisn = @nisn", connDel, tx)
                                            cmdDeleteSiswa.Parameters.AddWithValue("@nisn", nisn)
                                            cmdDeleteSiswa.ExecuteNonQuery()
                                        End Using
                                    End If
                                End Using
                            Next

                            ' Delete kelas row itself by idKelas
                            Using cmdDeleteKelas = New MySql.Data.MySqlClient.MySqlCommand("DELETE FROM kelas WHERE idKelas = @idKelas", connDel, tx)
                                cmdDeleteKelas.Parameters.AddWithValue("@idKelas", idKelasVal)
                                cmdDeleteKelas.ExecuteNonQuery()
                            End Using

                            tx.Commit()
                        Catch ex As Exception
                            tx.Rollback()
                            SubLog("Transaction failed: " & ex.ToString())
                            Throw
                        End Try
                    End Using
                End Using
            Catch ex As Exception
                SubLog("Deletion phase failed: " & ex.ToString())
                Throw
            End Try

            MessageBox.Show("Data Kelas dan semua relasi berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNamaKelas.Clear()
            btnSimpan.Enabled = True
            btnEdit.Enabled = False
            btnHapus.Enabled = False
            btnBatal.Enabled = False

            ' Refresh data
            LoadDataKelas()
        Catch ex As Exception
            ' Write full stack trace to log and show path to user
            Dim fullText As String = DateTime.Now.ToString("s") & " - Exception in btnHapus_Click" & Environment.NewLine & ex.ToString() & Environment.NewLine & New String("-"c, 40) & Environment.NewLine
            Try
                System.IO.File.AppendAllText(logPath, fullText)
            Catch
            End Try
            System.Diagnostics.Debug.WriteLine(fullText)
            MessageBox.Show("Terjadi error. Full exception and stack trace ditulis ke: " & logPath & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Reset tombol dan TextBox
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        txtNamaKelas.Clear()
        cmbTahunAjar.Enabled = True
        cmbTahunAjar.SelectedIndex = -1
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Validasi input
        If String.IsNullOrWhiteSpace(txtNamaKelas.Text) Or String.IsNullOrWhiteSpace(cmbTahunAjar.Text) Then
            MessageBox.Show("Nama Kelas tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Update data di database
        Try
            ' Cek terlebih dahulu apakah nama kelas sudah ada di tahun ajar yang sama
            Dim sqlCheck As String = "SELECT COUNT(*) FROM kelas WHERE namakelas = @namakelas AND tahunajar = @tahunajar"
            Using conn = DatabaseConnector.GetConnection()
                Using cmdCheck = New MySql.Data.MySqlClient.MySqlCommand(sqlCheck, conn)
                    cmdCheck.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                    cmdCheck.Parameters.AddWithValue("@tahunajar", cmbTahunAjar.Text)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Nama Kelas sudah ada di Tahun Ajar yang sama.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    Else
                        ' Simpan perubahan
                        Dim sqlUpdate As String = "UPDATE kelas SET namakelas = @namakelas WHERE idKelas = @idKelas"
                        Using cmdUpdate = New MySql.Data.MySqlClient.MySqlCommand(sqlUpdate, conn)
                            cmdUpdate.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                            cmdUpdate.Parameters.AddWithValue("@idKelas", dgvKelas.CurrentRow.Cells("idKelas").Value.ToString())
                            cmdUpdate.ExecuteNonQuery()
                            MessageBox.Show("Data Kelas berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtNamaKelas.Clear()
                        End Using
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengupdate data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Reset tombol dan TextBox
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        txtNamaKelas.Clear()
        cmbTahunAjar.Enabled = True
        cmbTahunAjar.SelectedIndex = -1

        ' Refresh data di DataGridView
        LoadDataKelas()
    End Sub

    Private Sub dgvKelas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKelas.CellContentClick
        ' validasi klik pada header atau di luar baris data
        If e.RowIndex < 0 Then
            Return
        End If
        Dim selectedRow As DataGridViewRow = dgvKelas.Rows(e.RowIndex)
        If dgvKelas.Columns(e.ColumnIndex).Name = "edit" Then
            ' Isi TextBox dengan data dari baris yang dipilih
            txtNamaKelas.Text = selectedRow.Cells("namakelas").Value.ToString()
            cmbTahunAjar.Text = selectedRow.Cells("tahunajar").Value.ToString()
            cmbTahunAjar.Enabled = False ' Tahun ajar tidak boleh diubah
            ' Aktifkan tombol Edit, Hapus, dan Batal; Nonaktifkan tombol Simpan
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
            btnBatal.Enabled = True
        End If
    End Sub

End Class