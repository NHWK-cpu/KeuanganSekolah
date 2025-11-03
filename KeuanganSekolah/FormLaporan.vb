Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class FormLaporan

    Private Sub cmbJenisLaporan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisTransaksi.SelectedIndexChanged

    End Sub

    Private Sub dtmDariTanggal_ValueChanged(sender As Object, e As EventArgs) Handles dtmDariTanggal.ValueChanged

    End Sub

    Private Sub FormLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Dim dt As New DataTable()
        Using conn = DatabaseConnector.GetConnection()
            conn.Open()
            If String.IsNullOrWhiteSpace(cmbJenisTransaksi.Text) Then
                Using cmd As New MySqlCommand("SELECT * FROM transaksi WHERE tanggal_transaksi BETWEEN @dateawal AND @dateakhir", conn)
                    cmd.Parameters.AddWithValue("@dateawal", dtmDariTanggal.Value)
                    cmd.Parameters.AddWithValue("@dateakhir", dtpSampaiTanggal.Value)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            Else
                Using cmd As New MySqlCommand("SELECT * FROM transaksi WHERE (tanggal_transaksi BETWEEN @dateawal AND @dateakhir) AND jenis_transaksi = @jenis_transaksi", conn)
                    cmd.Parameters.AddWithValue("@dateawal", dtmDariTanggal.Value)
                    cmd.Parameters.AddWithValue("@dateakhir", dtpSampaiTanggal.Value)
                    cmd.Parameters.AddWithValue("@dateawal", dtmDariTanggal.Value)
                    cmd.Parameters.AddWithValue("@jenis_transaksi", cmbJenisTransaksi)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End If

        End Using

        For Each row As DataRow In dt.Rows
            MsgBox(row("tanggal_transaksi"))
        Next

        '' Tambah kolom baru untuk string tanggal
        'If Not dt.Columns.Contains("tanggal_transaksi_str") Then
        '    dt.Columns.Add("tanggal_transaksi_str", GetType(String))
        'End If

        '' Isi kolom string dari MySqlDateTime
        'For Each row As DataRow In dt.Rows
        '    Dim mysqlDate As MySql.Data.Types.MySqlDateTime = CType(row("tanggal_transaksi"), MySql.Data.Types.MySqlDateTime)
        '    If mysqlDate.IsNull Then
        '        row("tanggal_transaksi_str") = "N/A"
        '    Else
        '        row("tanggal_transaksi_str") = mysqlDate.GetDateTime().ToString("dd-MM-yyyy HH:mm:ss")
        '    End If
        'Next

        Dim rds As New ReportDataSource("DataSetTransaksi", dt)
        With Me.ReportViewer1.LocalReport
            .ReportPath = "../../ReportTransaksi.rdlc"
            .DataSources.Clear()
            .DataSources.Add(rds)
        End With

        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.RefreshReport()
    End Sub
End Class