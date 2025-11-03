Public Class FormManageUserForAdmin
    Private Sub LoadData()
        Try
            ' Use existing columns from table "kelas"
            Dim sql As String = "SELECT * FROM user ORDER BY id LIMIT 20"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        ' Bind to DataGridView using mapped columns (prevent auto-generated duplicate columns)
                        dgvUsersData.DataSource = Nothing
                        dgvUsersData.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FormManageUserForAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PhComboBoxJabatan.PlaceHolderText = "bendahara"
        PhComboBoxJabatan.DropDownStyle = ComboBoxStyle.DropDownList

        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
        LoadData()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi Input
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Username dan password tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sql As String = "INSERT INTO user(username,password,jabatan) VALUES (@username, @password, @jabatan)"
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text)
                    cmd.Parameters.AddWithValue("@jabatan", PhComboBoxJabatan.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data user baru berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Reset Field dan button
        btnBatal.PerformClick()

        ' Reload DataGridView
        LoadData()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        txtUsername.Clear()
        txtPassword.Clear()
        PhComboBoxJabatan.SelectedIndex = -1

        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
    End Sub

    Private Sub dgvUsersData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsersData.CellContentClick
        ' Validasi row selected
        If e.RowIndex < 0 Then
            Return
        End If

        ' Validasi Aksi yang ditekan
        Dim selectedRow As DataGridViewRow = dgvUsersData.Rows(e.RowIndex)
        If dgvUsersData.Columns(e.ColumnIndex).Name = "edit" Then
            txtUsername.Text = selectedRow.Cells("username").Value.ToString()
            txtPassword.Text = selectedRow.Cells("password").Value.ToString()
            PhComboBoxJabatan.Text = selectedRow.Cells("jabatan").Value.ToString()

            ' Fokus ke numJumlah untuk memudahkan edit
            txtUsername.Focus()

            ' nyalakan tombol Edit, Hapus, dan Batal matikan Simpan
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
            btnBatal.Enabled = True
        ElseIf dgvUsersData.Columns(e.ColumnIndex).Name = "hapus" Then
            ' Hapus data user
            If e.RowIndex >= 0 Then
                btnHapus.Enabled = True
                btnHapus.PerformClick()
                btnHapus.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Konfirmasi penghapusan
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus user ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Return
        End If

        ' Hapus data dari database
        Try
            Dim sql As String = "DROP FROM user WHERE id = @id"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", dgvUsersData.CurrentRow.Cells("id"))
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        btnBatal.PerformClick()
        LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Validasi input
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Jumlah Nominal tidak boleh Nol atau minus dan keterangan tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sql As String = "UPDATE transaksi SET username = @username, password = @password, jabatan = @jabatan WHERE id = @id"
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text)
                    cmd.Parameters.AddWithValue("@jabatan", PhComboBoxJabatan.Text)

                    conn.Open()
                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Data user berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Tidak ada data yang diperbarui. Periksa kembali kode transaksi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Reset form dan reload data
        btnBatal.PerformClick()
        LoadData()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Try
            Dim sql = "SELECT * FROM user WHERE username LIKE @search OR jabatan LIKE @search"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & txtCari.Text & "%")
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        dgvUsersData.DataSource = Nothing
                        dgvUsersData.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class