<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPemasukanLainnya
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbPemasukanLainnya = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numJumlah = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvPemasukanLainnya = New System.Windows.Forms.DataGridView()
        Me.edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.hapus = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.gbPemasukanLainnya.SuspendLayout()
        CType(Me.numJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPemasukanLainnya, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPemasukanLainnya
        '
        Me.gbPemasukanLainnya.AutoSize = True
        Me.gbPemasukanLainnya.BackColor = System.Drawing.Color.LightBlue
        Me.gbPemasukanLainnya.Controls.Add(Me.Label4)
        Me.gbPemasukanLainnya.Controls.Add(Me.txtCari)
        Me.gbPemasukanLainnya.Controls.Add(Me.btnBatal)
        Me.gbPemasukanLainnya.Controls.Add(Me.btnHapus)
        Me.gbPemasukanLainnya.Controls.Add(Me.dtpTanggal)
        Me.gbPemasukanLainnya.Controls.Add(Me.btnEdit)
        Me.gbPemasukanLainnya.Controls.Add(Me.Label1)
        Me.gbPemasukanLainnya.Controls.Add(Me.btnSimpan)
        Me.gbPemasukanLainnya.Controls.Add(Me.txtKeterangan)
        Me.gbPemasukanLainnya.Controls.Add(Me.Label2)
        Me.gbPemasukanLainnya.Controls.Add(Me.numJumlah)
        Me.gbPemasukanLainnya.Controls.Add(Me.Label3)
        Me.gbPemasukanLainnya.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbPemasukanLainnya.Location = New System.Drawing.Point(0, 0)
        Me.gbPemasukanLainnya.Margin = New System.Windows.Forms.Padding(4)
        Me.gbPemasukanLainnya.Name = "gbPemasukanLainnya"
        Me.gbPemasukanLainnya.Padding = New System.Windows.Forms.Padding(4)
        Me.gbPemasukanLainnya.Size = New System.Drawing.Size(1067, 208)
        Me.gbPemasukanLainnya.TabIndex = 2
        Me.gbPemasukanLainnya.TabStop = False
        Me.gbPemasukanLainnya.Text = "Input Pemasukan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(507, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Cari"
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(556, 164)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(426, 22)
        Me.txtCari.TabIndex = 22
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBatal.Enabled = False
        Me.btnBatal.Location = New System.Drawing.Point(882, 113)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(100, 28)
        Me.btnBatal.TabIndex = 19
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'btnHapus
        '
        Me.btnHapus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnHapus.Enabled = False
        Me.btnHapus.Location = New System.Drawing.Point(756, 113)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(100, 28)
        Me.btnHapus.TabIndex = 18
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'dtpTanggal
        '
        Me.dtpTanggal.Location = New System.Drawing.Point(159, 44)
        Me.dtpTanggal.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(265, 22)
        Me.dtpTanggal.TabIndex = 1
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(632, 113)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 28)
        Me.btnEdit.TabIndex = 17
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tanggal:"
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSimpan.Location = New System.Drawing.Point(504, 113)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 28)
        Me.btnSimpan.TabIndex = 16
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(159, 100)
        Me.txtKeterangan.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(265, 22)
        Me.txtKeterangan.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 103)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Keterangan:"
        '
        'numJumlah
        '
        Me.numJumlah.Location = New System.Drawing.Point(159, 160)
        Me.numJumlah.Margin = New System.Windows.Forms.Padding(4)
        Me.numJumlah.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.numJumlah.Name = "numJumlah"
        Me.numJumlah.Size = New System.Drawing.Size(267, 22)
        Me.numJumlah.TabIndex = 4
        Me.numJumlah.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 164)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Jumlah (Rp):"
        '
        'dgvPemasukanLainnya
        '
        Me.dgvPemasukanLainnya.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPemasukanLainnya.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dgvPemasukanLainnya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPemasukanLainnya.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.edit, Me.hapus})
        Me.dgvPemasukanLainnya.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPemasukanLainnya.Location = New System.Drawing.Point(0, 208)
        Me.dgvPemasukanLainnya.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvPemasukanLainnya.Name = "dgvPemasukanLainnya"
        Me.dgvPemasukanLainnya.ReadOnly = True
        Me.dgvPemasukanLainnya.RowHeadersWidth = 51
        Me.dgvPemasukanLainnya.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPemasukanLainnya.Size = New System.Drawing.Size(1067, 346)
        Me.dgvPemasukanLainnya.TabIndex = 3
        '
        'edit
        '
        Me.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.edit.HeaderText = "Edit"
        Me.edit.Image = Global.KeuanganSekolah.My.Resources.Resources.edit_square_50dp_F19E39_FILL0_wght400_GRAD0_opsz48
        Me.edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.edit.MinimumWidth = 6
        Me.edit.Name = "edit"
        Me.edit.ReadOnly = True
        Me.edit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.edit.Width = 50
        '
        'hapus
        '
        Me.hapus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.hapus.HeaderText = "Hapus"
        Me.hapus.Image = Global.KeuanganSekolah.My.Resources.Resources.delete_forever_50dp_EA3323_FILL1_wght400_GRAD0_opsz48
        Me.hapus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.hapus.MinimumWidth = 6
        Me.hapus.Name = "hapus"
        Me.hapus.ReadOnly = True
        Me.hapus.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.hapus.Width = 50
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewImageColumn1.HeaderText = "Edit"
        Me.DataGridViewImageColumn1.Image = Global.KeuanganSekolah.My.Resources.Resources.edit_square_50dp_F19E39_FILL0_wght400_GRAD0_opsz48
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.MinimumWidth = 6
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewImageColumn1.Width = 50
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewImageColumn2.HeaderText = "Hapus"
        Me.DataGridViewImageColumn2.Image = Global.KeuanganSekolah.My.Resources.Resources.delete_forever_50dp_EA3323_FILL1_wght400_GRAD0_opsz48
        Me.DataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn2.MinimumWidth = 6
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewImageColumn2.Width = 50
        '
        'FormPemasukanLainnya
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.dgvPemasukanLainnya)
        Me.Controls.Add(Me.gbPemasukanLainnya)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormPemasukanLainnya"
        Me.Text = "Form Pemasukan Lainnya"
        Me.gbPemasukanLainnya.ResumeLayout(False)
        Me.gbPemasukanLainnya.PerformLayout()
        CType(Me.numJumlah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPemasukanLainnya, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbPemasukanLainnya As GroupBox
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents btnEdit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents numJumlah As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvPemasukanLainnya As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents edit As DataGridViewImageColumn
    Friend WithEvents hapus As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
End Class
