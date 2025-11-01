Public Class FormKelas
    Private Sub LoadDataKelas()
        Try
            ' Use existing columns from table "kelas"
            Dim sql As String = "SELECT namakelas, jumlahsiswa, tahunajar FROM kelas ORDER BY namakelas"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)
                        dt.Columns("namakelas").ColumnName = "Nama Kelas"
                        dt.Columns("jumlahsiswa").ColumnName = "Jumlah Siswa"
                        dt.Columns("tahunajar").ColumnName = "Tahun Ajar"

                        ' Bind to DataGridView using mapped columns (prevent auto-generated duplicate columns)
                        dgvKelas.DataSource = Nothing
                        dgvKelas.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub dgvKelas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvKelas.CellMouseDoubleClick
        ' Pastikan baris valid
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvKelas.Rows.Count Then
            Return
        End If
        ' Masukkan data ke TextBox untuk diedit
        Dim selectedRow As DataGridViewRow = dgvKelas.Rows(e.RowIndex)
        txtNamaKelas.Text = selectedRow.Cells("namakelas").Value.ToString()

        ' Aktifkan tombol Edit, Hapus, dan Batal. nonaktifkan Simpan
        btnSimpan.Enabled = False
        btnEdit.Enabled = True
        btnHapus.Enabled = True
        btnBatal.Enabled = True
        txtNamaKelas.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Validasi input
        If String.IsNullOrWhiteSpace(txtNamaKelas.Text) Then
            MessageBox.Show("Nama Kelas tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Update data di database
        Try
            Dim sql As String = "UPDATE kelas SET namakelas = @namakelas WHERE namakelas = @oldnamakelas"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    ' Gunakan nilai lama dari DataGridView untuk WHERE clause
                    Dim selectedRow As DataGridViewRow = dgvKelas.SelectedRows(0)
                    Dim oldNamaKelas As String = selectedRow.Cells("namakelas").Value.ToString()
                    cmd.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                    cmd.Parameters.AddWithValue("@oldnamakelas", oldNamaKelas)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Update tabel siswa untuk mencerminkan perubahan nama kelas
            Dim sqlUpdateSiswa As String = "UPDATE siswa SET namakelas = @namakelas WHERE namakelas = @oldnamakelas"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlUpdateSiswa, conn)
                    Dim selectedRow As DataGridViewRow = dgvKelas.SelectedRows(0)
                    Dim oldNamaKelas As String = selectedRow.Cells("namakelas").Value.ToString()
                    cmd.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                    cmd.Parameters.AddWithValue("@oldnamakelas", oldNamaKelas)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Data Kelas berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNamaKelas.Clear()

        Catch ex As Exception
            MessageBox.Show("Gagal mengupdate data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Reset tombol dan TextBox
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        txtNamaKelas.Clear()
        ' Refresh data di DataGridView
        LoadDataKelas()
    End Sub
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Konfirmasi penghapusan
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus kelas ini?\nSeluruh data siswa yang terkait dengan kelas ini akan terhapus juga!", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Return
        End If

        ' Hapus data dari database
        Try
            Dim sql As String = "DELETE FROM kelas WHERE namakelas = @namakelas"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Hapus data siswa yang terkait dengan kelas ini
        Try
            Dim sqlDeleteSiswa As String = "DELETE FROM siswa WHERE namakelas = @namakelas"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlDeleteSiswa, conn)
                    cmd.Parameters.AddWithValue("@namakelas", txtNamaKelas.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data siswa terkait: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Notify user of successful deletion
        MessageBox.Show("Data Kelas berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtNamaKelas.Clear()

        ' Reset tombol dan TextBox
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        txtNamaKelas.Clear()

        ' Refresh data di DataGridView
        LoadDataKelas()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs)
        ' Reset tombol dan TextBox
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        txtNamaKelas.Clear()
    End Sub

End Class