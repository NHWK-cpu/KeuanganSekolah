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
        Me.dtpSampaiTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtmDariTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbJenisLaporan = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rvLaporan = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.panelFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelFilter
        '
        Me.panelFilter.BackColor = System.Drawing.Color.LightBlue
        Me.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelFilter.Controls.Add(Me.btnTampilkan)
        Me.panelFilter.Controls.Add(Me.dtpSampaiTanggal)
        Me.panelFilter.Controls.Add(Me.Label3)
        Me.panelFilter.Controls.Add(Me.dtmDariTanggal)
        Me.panelFilter.Controls.Add(Me.Label2)
        Me.panelFilter.Controls.Add(Me.cmbJenisLaporan)
        Me.panelFilter.Controls.Add(Me.Label1)
        Me.panelFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelFilter.Location = New System.Drawing.Point(0, 0)
        Me.panelFilter.Name = "panelFilter"
        Me.panelFilter.Size = New System.Drawing.Size(800, 122)
        Me.panelFilter.TabIndex = 0
        '
        'dtpSampaiTanggal
        '
        Me.dtpSampaiTanggal.Location = New System.Drawing.Point(419, 64)
        Me.dtpSampaiTanggal.Name = "dtpSampaiTanggal"
        Me.dtpSampaiTanggal.Size = New System.Drawing.Size(200, 20)
        Me.dtpSampaiTanggal.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(310, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sampai Tanggal:"
        '
        'dtmDariTanggal
        '
        Me.dtmDariTanggal.Location = New System.Drawing.Point(419, 24)
        Me.dtmDariTanggal.Name = "dtmDariTanggal"
        Me.dtmDariTanggal.Size = New System.Drawing.Size(200, 20)
        Me.dtmDariTanggal.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Dari Tanggal:"
        '
        'cmbJenisLaporan
        '
        Me.cmbJenisLaporan.FormattingEnabled = True
        Me.cmbJenisLaporan.Location = New System.Drawing.Point(102, 46)
        Me.cmbJenisLaporan.Name = "cmbJenisLaporan"
        Me.cmbJenisLaporan.Size = New System.Drawing.Size(177, 21)
        Me.cmbJenisLaporan.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jenis Laporan:"
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
        'btnTampilkan
        '
        Me.btnTampilkan.Location = New System.Drawing.Point(666, 64)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(98, 23)
        Me.btnTampilkan.TabIndex = 6
        Me.btnTampilkan.Text = "Tampilkan"
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'FormLaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.panelFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormLaporan"
        Me.Text = "Laporan Keuangan"
        Me.panelFilter.ResumeLayout(False)
        Me.panelFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelFilter As Panel
    Friend WithEvents cmbJenisLaporan As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtmDariTanggal As DateTimePicker
    Friend WithEvents dtpSampaiTanggal As DateTimePicker
    Friend WithEvents rvLaporan As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnTampilkan As Button
End Class
