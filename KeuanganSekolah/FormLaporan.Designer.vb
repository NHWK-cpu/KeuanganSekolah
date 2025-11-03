<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLaporan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelFilter = New System.Windows.Forms.Panel()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.dtpSampaiTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtmDariTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbJenisTransaksi = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rvLaporan = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.panelFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelFilter
        '
        Me.panelFilter.AutoSize = True
        Me.panelFilter.BackColor = System.Drawing.Color.LightBlue
        Me.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelFilter.Controls.Add(Me.btnTampilkan)
        Me.panelFilter.Controls.Add(Me.dtpSampaiTanggal)
        Me.panelFilter.Controls.Add(Me.Label3)
        Me.panelFilter.Controls.Add(Me.dtmDariTanggal)
        Me.panelFilter.Controls.Add(Me.Label2)
        Me.panelFilter.Controls.Add(Me.cmbJenisTransaksi)
        Me.panelFilter.Controls.Add(Me.Label1)
        Me.panelFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelFilter.Location = New System.Drawing.Point(0, 0)
        Me.panelFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.panelFilter.Name = "panelFilter"
        Me.panelFilter.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.panelFilter.Size = New System.Drawing.Size(1067, 123)
        Me.panelFilter.TabIndex = 0
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Location = New System.Drawing.Point(888, 79)
        Me.btnTampilkan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(131, 28)
        Me.btnTampilkan.TabIndex = 6
        Me.btnTampilkan.Text = "Tampilkan"
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'dtpSampaiTanggal
        '
        Me.dtpSampaiTanggal.Location = New System.Drawing.Point(559, 79)
        Me.dtpSampaiTanggal.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpSampaiTanggal.Name = "dtpSampaiTanggal"
        Me.dtpSampaiTanggal.Size = New System.Drawing.Size(265, 22)
        Me.dtpSampaiTanggal.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(413, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sampai Tanggal:"
        '
        'dtmDariTanggal
        '
        Me.dtmDariTanggal.Location = New System.Drawing.Point(559, 30)
        Me.dtmDariTanggal.Margin = New System.Windows.Forms.Padding(4)
        Me.dtmDariTanggal.Name = "dtmDariTanggal"
        Me.dtmDariTanggal.Size = New System.Drawing.Size(265, 22)
        Me.dtmDariTanggal.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(413, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Dari Tanggal:"
        '
        'cmbJenisTransaksi
        '
        Me.cmbJenisTransaksi.FormattingEnabled = True
        Me.cmbJenisTransaksi.Location = New System.Drawing.Point(136, 57)
        Me.cmbJenisTransaksi.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbJenisTransaksi.Name = "cmbJenisTransaksi"
        Me.cmbJenisTransaksi.Size = New System.Drawing.Size(235, 24)
        Me.cmbJenisTransaksi.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jenis Transaksi:"
        '
        'rvLaporan
        '
        Me.rvLaporan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvLaporan.Location = New System.Drawing.Point(0, 0)
        Me.rvLaporan.Name = "rvLaporan"
        Me.rvLaporan.ServerReport.BearerToken = Nothing
        Me.rvLaporan.Size = New System.Drawing.Size(396, 246)
        Me.rvLaporan.TabIndex = 0
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 123)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1067, 431)
        Me.ReportViewer1.TabIndex = 7
        '
        'FormLaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.panelFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormLaporan"
        Me.Text = "Laporan Keuangan"
        Me.panelFilter.ResumeLayout(False)
        Me.panelFilter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panelFilter As Panel
    Friend WithEvents cmbJenisTransaksi As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtmDariTanggal As DateTimePicker
    Friend WithEvents dtpSampaiTanggal As DateTimePicker
    Friend WithEvents rvLaporan As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
