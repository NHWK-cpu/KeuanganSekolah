Public Class FormProfile
    Private Sub FormProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = LoginSession.Username
        txtPeran.Text = LoginSession.UserRole
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' validasi input
        If String.IsNullOrWhiteSpace(txtPwLama.Text) Or String.IsNullOrWhiteSpace(txtPwBaru.Text) Or String.IsNullOrWhiteSpace(txtKonfirmasiPw.Text) Then
            MessageBox.Show("Password lama, Password baru, dan Konfirmasi password tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        ElseIf txtPwBaru.Text <> txtKonfirmasiPw.Text Then
            MessageBox.Show("Password baru dan Konfirmasi password tidak boleh berbeda.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' verifikasi apakah passwrod lama benar
        Try
            Dim sqlVerify As String = "SELECT COUNT(*) FROM `user` WHERE username = @username AND jabatan = @jabatan AND password = @password"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlVerify, conn)
                    cmd.Parameters.AddWithValue("@username", LoginSession.Username)
                    cmd.Parameters.AddWithValue("@jabatan", LoginSession.UserRole)
                    cmd.Parameters.AddWithValue("@password", txtPwLama.Text)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    If count < 1 Then
                        MessageBox.Show("Password lama salah.", "Verifikasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim sql As String = "UPDATE user SET password = @password WHERE username = @username AND jabatan = @jabatan"
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@password", txtPwBaru)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@jabatan", txtPeran.Text)

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
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        txtPwLama.Text = ""
        txtPwBaru.Text = ""
        txtKonfirmasiPw.Text = ""
    End Sub
End Class