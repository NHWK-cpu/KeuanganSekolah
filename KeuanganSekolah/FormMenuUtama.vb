Public Class FormMenuUtama
    Public Property JabatanPengguna As String
    Private Sub FormMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        JabatanPengguna = LoginSession.UserRole.ToLower()
        If JabatanPengguna = "bendahara" Then
            btnDataKelas.Visible = False
            btnDataSiswa.Visible = False
            btnManageUser.Visible = False

            btnJnsPembayaran.Visible = True
            btnTransaksiPembayaran.Visible = True
            btnPengeluaran.Visible = True
        ElseIf JabatanPengguna = "kepsek" Then
            btnTransaksiPembayaran.Visible = False
            btnPengeluaran.Visible = False
            btnManageUser.Visible = False
            btnDataKelas.Visible = False
            btnDataSiswa.Visible = False

            btnJnsPembayaran.Visible = True
        ElseIf JabatanPengguna = "admin" Then
            btnDataKelas.Visible = True
            btnDataSiswa.Visible = True
            btnJnsPembayaran.Visible = True
            btnTransaksiPembayaran.Visible = True
            btnPengeluaran.Visible = True
            btnManageUser.Visible = True
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
End Class