Public Class FormMenuUtama
    Public Property JabatanPengguna As String
    Private Sub FormMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Username1ToolStripMenuItem.Text = LoginSession.Username
        JabatanPengguna = LoginSession.UserRole.ToLower()
        Label1.Parent = PictureBox3
        If JabatanPengguna = "bendahara" Then
            btnDataKelas.Enabled = False
            btnDataSiswa.Enabled = False
            btnPemasukanLainnya.Enabled = True

            btnManageUser.Enabled = False
            btnJnsPembayaran.Enabled = True
            btnTransaksiPembayaran.Enabled = True
            btnPengeluaran.Enabled = True
        ElseIf JabatanPengguna = "kepsek" Then
            btnTransaksiPembayaran.Enabled = False
            btnPengeluaran.Enabled = False
            btnPemasukanLainnya.Enabled = False
            btnDataKelas.Enabled = False
            btnDataSiswa.Enabled = False
            btnJnsPembayaran.Enabled = False

            btnManageUser.Enabled = True
        ElseIf JabatanPengguna = "admin" Then
            btnDataKelas.Enabled = True
            btnDataSiswa.Enabled = True
            btnJnsPembayaran.Enabled = True
            btnTransaksiPembayaran.Enabled = True
            btnPengeluaran.Enabled = True
            btnPemasukanLainnya.Enabled = True
        End If

    End Sub

    Private Sub btnDataSiswa_Click(sender As Object, e As EventArgs) Handles btnDataSiswa.Click
        Dim fDataSiswa As New FormSiswa()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fDataSiswa.TopLevel = False
        fDataSiswa.FormBorderStyle = FormBorderStyle.None
        fDataSiswa.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fDataSiswa)
        fDataSiswa.Show()
    End Sub

    Private Sub btnDataKelas_Click(sender As Object, e As EventArgs) Handles btnDataKelas.Click
        Dim fDataKelas As New FormKelas()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fDataKelas.TopLevel = False
        fDataKelas.FormBorderStyle = FormBorderStyle.None
        fDataKelas.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fDataKelas)
        fDataKelas.Show()
    End Sub

    Private Sub btnJnsPembayaran_Click(sender As Object, e As EventArgs) Handles btnJnsPembayaran.Click
        Dim fJenisPembayaran As New FormJenisPembayaran()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fJenisPembayaran.TopLevel = False
        fJenisPembayaran.FormBorderStyle = FormBorderStyle.None
        fJenisPembayaran.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fJenisPembayaran)
        fJenisPembayaran.Show()
    End Sub

    Private Sub btnTransaksiPembayaran_Click(sender As Object, e As EventArgs) Handles btnTransaksiPembayaran.Click
        Dim fTransaksi As New FormTransaksi()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fTransaksi.TopLevel = False
        fTransaksi.FormBorderStyle = FormBorderStyle.None
        fTransaksi.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fTransaksi)
        fTransaksi.Show()
    End Sub

    Private Sub btnPengeluaran_Click(sender As Object, e As EventArgs) Handles btnPengeluaran.Click
        Dim fPengeluaran As New FormPengeluaran()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fPengeluaran.TopLevel = False
        fPengeluaran.FormBorderStyle = FormBorderStyle.None
        fPengeluaran.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fPengeluaran)
        fPengeluaran.Show()
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        Dim fLaporan As New FormLaporan()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fLaporan.TopLevel = False
        fLaporan.FormBorderStyle = FormBorderStyle.None
        fLaporan.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fLaporan)
        fLaporan.Show()
    End Sub

    Private Sub btnManageUser_Click(sender As Object, e As EventArgs) Handles btnManageUser.Click
        Dim fManageUsers As New FormManageUserForAdmin()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fManageUsers.TopLevel = False
        fManageUsers.FormBorderStyle = FormBorderStyle.None
        fManageUsers.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fManageUsers)
        fManageUsers.Show()
    End Sub

    Private Sub btnPemasukanLainnya_Click(sender As Object, e As EventArgs) Handles btnPemasukanLainnya.Click
        Dim fPemasukanLainnya As New FormPemasukanLainnya()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fPemasukanLainnya.TopLevel = False
        fPemasukanLainnya.FormBorderStyle = FormBorderStyle.None
        fPemasukanLainnya.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fPemasukanLainnya)
        fPemasukanLainnya.Show()
    End Sub

    Private Sub UbahPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbahPasswordToolStripMenuItem.Click
        Dim fProfile As New FormProfile()

        ' Tampilkan form di dalam PanelMain (PanelMain mengisi client area sehingga MDI child tidak terlihat)
        fProfile.TopLevel = False
        fProfile.FormBorderStyle = FormBorderStyle.None
        fProfile.Dock = DockStyle.Fill

        PanelMain.Controls.Clear() ' optional: hapus konten lama (mis. Label1)
        PanelMain.Controls.Add(fProfile)
        fProfile.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Hide()
        LoginSession.Username = ""
        LoginSession.UserID = ""
        LoginSession.UserRole = ""
        FormLogin.Show()
    End Sub
End Class