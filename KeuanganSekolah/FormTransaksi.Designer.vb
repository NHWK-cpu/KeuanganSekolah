<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTransaksi
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNamaSiswa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.txtCariNISN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelKanan = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvRiwayat = New System.Windows.Forms.DataGridView()
        Me.bayar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        Me.panelKanan.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvRiwayat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNamaSiswa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCari)
        Me.GroupBox1.Controls.Add(Me.txtCariNISN)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1067, 207)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Siswa"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(208, 140)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 22)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 140)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kelas:"
        '
        'txtNamaSiswa
        '
        Me.txtNamaSiswa.Location = New System.Drawing.Point(208, 87)
        Me.txtNamaSiswa.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNamaSiswa.Name = "txtNamaSiswa"
        Me.txtNamaSiswa.Size = New System.Drawing.Size(288, 22)
        Me.txtNamaSiswa.TabIndex = 4
        Me.txtNamaSiswa.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nama Siswa:"
        '
        'btnCari
        '
        Me.btnCari.Location = New System.Drawing.Point(563, 86)
        Me.btnCari.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(100, 28)
        Me.btnCari.TabIndex = 2
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'txtCariNISN
        '
        Me.txtCariNISN.Location = New System.Drawing.Point(208, 39)
        Me.txtCariNISN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCariNISN.Name = "txtCariNISN"
        Me.txtCariNISN.Size = New System.Drawing.Size(288, 22)
        Me.txtCariNISN.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cari Siswa (NISN):"
        '
        'panelKanan
        '
        Me.panelKanan.Controls.Add(Me.GroupBox2)
        Me.panelKanan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelKanan.Location = New System.Drawing.Point(0, 207)
        Me.panelKanan.Margin = New System.Windows.Forms.Padding(4)
        Me.panelKanan.Name = "panelKanan"
        Me.panelKanan.Size = New System.Drawing.Size(1067, 347)
        Me.panelKanan.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Azure
        Me.GroupBox2.Controls.Add(Me.dgvRiwayat)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1067, 347)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Riwayat dan Status Pembayaran"
        '
        'dgvRiwayat
        '
        Me.dgvRiwayat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRiwayat.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dgvRiwayat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRiwayat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bayar})
        Me.dgvRiwayat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRiwayat.Location = New System.Drawing.Point(4, 19)
        Me.dgvRiwayat.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvRiwayat.Name = "dgvRiwayat"
        Me.dgvRiwayat.ReadOnly = True
        Me.dgvRiwayat.RowHeadersWidth = 51
        Me.dgvRiwayat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRiwayat.Size = New System.Drawing.Size(1059, 324)
        Me.dgvRiwayat.TabIndex = 0
        '
        'bayar
        '
        Me.bayar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.bayar.HeaderText = "Bayar"
        Me.bayar.MinimumWidth = 6
        Me.bayar.Name = "bayar"
        Me.bayar.ReadOnly = True
        Me.bayar.Text = "bayar"
        Me.bayar.ToolTipText = "bayar"
        Me.bayar.Width = 55
        '
        'FormTransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.panelKanan)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormTransaksi"
        Me.Text = "Transaksi Pembayaran Siswa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.panelKanan.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvRiwayat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCariNISN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCari As Button
    Friend WithEvents txtNamaSiswa As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents panelKanan As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvRiwayat As DataGridView
    Friend WithEvents bayar As DataGridViewButtonColumn
End Class
