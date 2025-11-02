<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSiswa
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
        Me.ComboBoxKelas = New System.Windows.Forms.ComboBox()
        Me.lblKelas = New System.Windows.Forms.Label()
        Me.ComboBoxTahunAjar = New System.Windows.Forms.ComboBox()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.txtCariSiswa = New System.Windows.Forms.Label()
        Me.TextBoxNama = New System.Windows.Forms.TextBox()
        Me.TextBoxNISN = New System.Windows.Forms.TextBox()
        Me.txtTahunAjar = New System.Windows.Forms.Label()
        Me.txtNamaLgkp = New System.Windows.Forms.Label()
        Me.txtNISN = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.dgvSiswa = New System.Windows.Forms.DataGridView()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgvBtnEdit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.dgvBtnHapus = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.ComboBoxKelas)
        Me.GroupBox1.Controls.Add(Me.lblKelas)
        Me.GroupBox1.Controls.Add(Me.ComboBoxTahunAjar)
        Me.GroupBox1.Controls.Add(Me.TextBoxSearch)
        Me.GroupBox1.Controls.Add(Me.txtCariSiswa)
        Me.GroupBox1.Controls.Add(Me.TextBoxNama)
        Me.GroupBox1.Controls.Add(Me.TextBoxNISN)
        Me.GroupBox1.Controls.Add(Me.txtTahunAjar)
        Me.GroupBox1.Controls.Add(Me.txtNamaLgkp)
        Me.GroupBox1.Controls.Add(Me.txtNISN)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1067, 243)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Data Siswa"
        '
        'ComboBoxKelas
        '
        Me.ComboBoxKelas.Enabled = False
        Me.ComboBoxKelas.FormattingEnabled = True
        Me.ComboBoxKelas.Location = New System.Drawing.Point(208, 196)
        Me.ComboBoxKelas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxKelas.Name = "ComboBoxKelas"
        Me.ComboBoxKelas.Size = New System.Drawing.Size(251, 24)
        Me.ComboBoxKelas.TabIndex = 16
        '
        'lblKelas
        '
        Me.lblKelas.AutoSize = True
        Me.lblKelas.Location = New System.Drawing.Point(41, 201)
        Me.lblKelas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKelas.Name = "lblKelas"
        Me.lblKelas.Size = New System.Drawing.Size(44, 16)
        Me.lblKelas.TabIndex = 15
        Me.lblKelas.Text = "Kelas:"
        '
        'ComboBoxTahunAjar
        '
        Me.ComboBoxTahunAjar.FormattingEnabled = True
        Me.ComboBoxTahunAjar.Location = New System.Drawing.Point(208, 149)
        Me.ComboBoxTahunAjar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxTahunAjar.Name = "ComboBoxTahunAjar"
        Me.ComboBoxTahunAjar.Size = New System.Drawing.Size(251, 24)
        Me.ComboBoxTahunAjar.TabIndex = 13
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(714, 187)
        Me.TextBoxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(251, 22)
        Me.TextBoxSearch.TabIndex = 12
        '
        'txtCariSiswa
        '
        Me.txtCariSiswa.AutoSize = True
        Me.txtCariSiswa.Location = New System.Drawing.Point(622, 191)
        Me.txtCariSiswa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtCariSiswa.Name = "txtCariSiswa"
        Me.txtCariSiswa.Size = New System.Drawing.Size(70, 16)
        Me.txtCariSiswa.TabIndex = 2
        Me.txtCariSiswa.Text = "Cari Siswa"
        '
        'TextBoxNama
        '
        Me.TextBoxNama.Location = New System.Drawing.Point(208, 101)
        Me.TextBoxNama.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(251, 22)
        Me.TextBoxNama.TabIndex = 9
        '
        'TextBoxNISN
        '
        Me.TextBoxNISN.Location = New System.Drawing.Point(208, 52)
        Me.TextBoxNISN.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNISN.Name = "TextBoxNISN"
        Me.TextBoxNISN.Size = New System.Drawing.Size(251, 22)
        Me.TextBoxNISN.TabIndex = 8
        '
        'txtTahunAjar
        '
        Me.txtTahunAjar.AutoSize = True
        Me.txtTahunAjar.Location = New System.Drawing.Point(41, 154)
        Me.txtTahunAjar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtTahunAjar.Name = "txtTahunAjar"
        Me.txtTahunAjar.Size = New System.Drawing.Size(75, 16)
        Me.txtTahunAjar.TabIndex = 2
        Me.txtTahunAjar.Text = "Tahun Ajar:"
        '
        'txtNamaLgkp
        '
        Me.txtNamaLgkp.AutoSize = True
        Me.txtNamaLgkp.Location = New System.Drawing.Point(41, 105)
        Me.txtNamaLgkp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNamaLgkp.Name = "txtNamaLgkp"
        Me.txtNamaLgkp.Size = New System.Drawing.Size(103, 16)
        Me.txtNamaLgkp.TabIndex = 1
        Me.txtNamaLgkp.Text = "Nama Lengkap:"
        '
        'txtNISN
        '
        Me.txtNISN.AutoSize = True
        Me.txtNISN.Location = New System.Drawing.Point(41, 55)
        Me.txtNISN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNISN.Name = "txtNISN"
        Me.txtNISN.Size = New System.Drawing.Size(42, 16)
        Me.txtNISN.TabIndex = 0
        Me.txtNISN.Text = "NISN:"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.Controls.Add(Me.btnBatal)
        Me.Panel1.Controls.Add(Me.btnHapus)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnSimpan)
        Me.Panel1.Location = New System.Drawing.Point(567, 105)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 38)
        Me.Panel1.TabIndex = 14
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBatal.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBatal.Enabled = False
        Me.btnBatal.Location = New System.Drawing.Point(300, 0)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(100, 38)
        Me.btnBatal.TabIndex = 7
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'btnHapus
        '
        Me.btnHapus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnHapus.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnHapus.Enabled = False
        Me.btnHapus.Location = New System.Drawing.Point(200, 0)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(100, 38)
        Me.btnHapus.TabIndex = 6
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(100, 0)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 38)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSimpan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSimpan.Location = New System.Drawing.Point(0, 0)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 38)
        Me.btnSimpan.TabIndex = 4
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'dgvSiswa
        '
        Me.dgvSiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSiswa.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dgvSiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSiswa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgvBtnEdit, Me.dgvBtnHapus})
        Me.dgvSiswa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSiswa.Location = New System.Drawing.Point(0, 243)
        Me.dgvSiswa.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSiswa.Name = "dgvSiswa"
        Me.dgvSiswa.ReadOnly = True
        Me.dgvSiswa.RowHeadersWidth = 51
        Me.dgvSiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSiswa.Size = New System.Drawing.Size(1067, 311)
        Me.dgvSiswa.TabIndex = 1
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewImageColumn1.HeaderText = "Edit"
        Me.DataGridViewImageColumn1.Image = Global.KeuanganSekolah.My.Resources.Resources.edit_square_50dp_F19E39_FILL0_wght400_GRAD0_opsz48
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.MinimumWidth = 6
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.Width = 125
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewImageColumn2.HeaderText = "Hapus"
        Me.DataGridViewImageColumn2.Image = Global.KeuanganSekolah.My.Resources.Resources.delete_forever_50dp_EA3323_FILL1_wght400_GRAD0_opsz48
        Me.DataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn2.MinimumWidth = 6
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 125
        '
        'dgvBtnEdit
        '
        Me.dgvBtnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dgvBtnEdit.HeaderText = "Edit"
        Me.dgvBtnEdit.Image = Global.KeuanganSekolah.My.Resources.Resources.edit_square_50dp_F19E39_FILL0_wght400_GRAD0_opsz48
        Me.dgvBtnEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.dgvBtnEdit.MinimumWidth = 6
        Me.dgvBtnEdit.Name = "dgvBtnEdit"
        Me.dgvBtnEdit.ReadOnly = True
        Me.dgvBtnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBtnEdit.Width = 36
        '
        'dgvBtnHapus
        '
        Me.dgvBtnHapus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dgvBtnHapus.HeaderText = "Hapus"
        Me.dgvBtnHapus.Image = Global.KeuanganSekolah.My.Resources.Resources.delete_forever_50dp_EA3323_FILL1_wght400_GRAD0_opsz48
        Me.dgvBtnHapus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.dgvBtnHapus.MinimumWidth = 6
        Me.dgvBtnHapus.Name = "dgvBtnHapus"
        Me.dgvBtnHapus.ReadOnly = True
        Me.dgvBtnHapus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBtnHapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dgvBtnHapus.Width = 76
        '
        'FormSiswa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.dgvSiswa)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormSiswa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "FormSiswa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvSiswa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTahunAjar As Label
    Friend WithEvents txtNamaLgkp As Label
    Friend WithEvents txtNISN As Label
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents TextBoxNISN As TextBox
    Friend WithEvents TextBoxNama As TextBox
    Friend WithEvents dgvSiswa As DataGridView
    Friend WithEvents txtCariSiswa As Label
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboBoxTahunAjar As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBoxKelas As ComboBox
    Friend WithEvents lblKelas As Label
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents dgvBtnEdit As DataGridViewImageColumn
    Friend WithEvents dgvBtnHapus As DataGridViewImageColumn
End Class
