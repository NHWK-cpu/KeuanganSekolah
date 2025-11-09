Imports MySql.Data.MySqlClient

Public Class FormLogin

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Try
            Dim sql As String = "SELECT * FROM user WHERE username = @username AND password = @password"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            LoginSession.UserID = rdr("id").ToString()
                            LoginSession.Username = rdr("username").ToString()
                            LoginSession.UserRole = rdr("jabatan").ToString()
                            Me.Hide()
                            FormMenuUtama.Show()
                        Else
                            MessageBox.Show("Password or username salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection failed: " & ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Batal_Click(sender As Object, e As EventArgs) Handles Batal.Click
        Application.Exit()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
