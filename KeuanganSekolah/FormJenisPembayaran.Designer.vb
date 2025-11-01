<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormJenisPembayaran
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
        Me.txtNamaPembayaran = New System.Windows.Forms.TextBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.numNominal = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvJenisPembayaran = New System.Windows.Forms.DataGridView()
        Me.ComboBoxTahunAjar = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numNominal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJenisPembayaran, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.ComboBoxTahunAjar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNamaPembayaran)
        Me.GroupBox1.Controls.Add(Me.btnBatal)
        Me.GroupBox1.Controls.Add(Me.btnHapus)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnSimpan)
        Me.GroupBox1.Controls.Add(Me.numNominal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 189)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Jenis Pembayaran"
        '
        'txtNamaPembayaran
        '
        Me.txtNamaPembayaran.Location = New System.Drawing.Point(154, 43)
        Me.txtNamaPembayaran.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtNamaPembayaran.Name = "txtNamaPembayaran"
        Me.txtNamaPembayaran.Size = New System.Drawing.Size(180, 20)
        Me.txtNamaPembayaran.TabIndex = 16
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBatal.Enabled = False
        Me.btnBatal.Location = New System.Drawing.Point(675, 126)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(75, 23)
        Me.btnBatal.TabIndex = 15
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'btnHapus
        '
        Me.btnHapus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnHapus.Enabled = False
        Me.btnHapus.Location = New System.Drawing.Point(581, 126)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 23)
        Me.btnHapus.TabIndex = 14
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(488, 126)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSimpan.Location = New System.Drawing.Point(392, 126)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.btnSimpan.TabIndex = 12
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'numNominal
        '
        Me.numNominal.Location = New System.Drawing.Point(154, 84)
        Me.numNominal.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.numNominal.Name = "numNominal"
        Me.numNominal.Size = New System.Drawing.Size(180, 20)
        Me.numNominal.TabIndex = 3
        Me.numNominal.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nominal (Rp):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama Pembayaran:"
        '
        'dgvJenisPembayaran
        '
        Me.dgvJenisPembayaran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvJenisPembayaran.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dgvJenisPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJenisPembayaran.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvJenisPembayaran.Location = New System.Drawing.Point(0, 189)
        Me.dgvJenisPembayaran.Name = "dgvJenisPembayaran"
        Me.dgvJenisPembayaran.ReadOnly = True
        Me.dgvJenisPembayaran.RowHeadersWidth = 51
        Me.dgvJenisPembayaran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJenisPembayaran.Size = New System.Drawing.Size(800, 261)
        Me.dgvJenisPembayaran.TabIndex = 1
        '
        'ComboBoxTahunAjar
        '
        Me.ComboBoxTahunAjar.FormattingEnabled = True
        Me.ComboBoxTahunAjar.Location = New System.Drawing.Point(154, 128)
        Me.ComboBoxTahunAjar.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBoxTahunAjar.Name = "ComboBoxTahunAjar"
        Me.ComboBoxTahunAjar.Size = New System.Drawing.Size(180, 21)
        Me.ComboBoxTahunAjar.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Tahun Ajar:"
        '
        'FormJenisPembayaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvJenisPembayaran)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormJenisPembayaran"
        Me.Text = "Manajemen Jenis Pembayaran"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numNominal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJenisPembayaran, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents numNominal As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents dgvJenisPembayaran As DataGridView
    Friend WithEvents txtNamaPembayaran As TextBox
    Friend WithEvents ComboBoxTahunAjar As ComboBox
    Friend WithEvents Label3 As Label
End Class
