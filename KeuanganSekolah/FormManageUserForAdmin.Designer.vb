<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManageUserForAdmin
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
        Me.dgvUsersData = New System.Windows.Forms.DataGridView()
        Me.edit = New System.Windows.Forms.DataGridViewImageColumn()
        Me.hapus = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.PhComboBoxJabatan = New KeuanganSekolah.PHComboBox()
        CType(Me.dgvUsersData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUsersData
        '
        Me.dgvUsersData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsersData.BackgroundColor = System.Drawing.Color.LightCyan
        Me.dgvUsersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsersData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.edit, Me.hapus})
        Me.dgvUsersData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsersData.Location = New System.Drawing.Point(0, 222)
        Me.dgvUsersData.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvUsersData.Name = "dgvUsersData"
        Me.dgvUsersData.ReadOnly = True
        Me.dgvUsersData.RowHeadersWidth = 51
        Me.dgvUsersData.Size = New System.Drawing.Size(1067, 332)
        Me.dgvUsersData.TabIndex = 3
        '
        'edit
        '
        Me.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.edit.FillWeight = 146.5241!
        Me.edit.HeaderText = "Edit"
        Me.edit.Image = Global.KeuanganSekolah.My.Resources.Resources.edit_square_50dp_F19E39_FILL0_wght400_GRAD0_opsz48
        Me.edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.edit.MinimumWidth = 6
        Me.edit.Name = "edit"
        Me.edit.ReadOnly = True
        Me.edit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.edit.Width = 50
        '
        'hapus
        '
        Me.hapus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.hapus.FillWeight = 53.47594!
        Me.hapus.HeaderText = "Hapus"
        Me.hapus.Image = Global.KeuanganSekolah.My.Resources.Resources.delete_forever_50dp_EA3323_FILL1_wght400_GRAD0_opsz48
        Me.hapus.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.hapus.MinimumWidth = 6
        Me.hapus.Name = "hapus"
        Me.hapus.ReadOnly = True
        Me.hapus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.hapus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.hapus.Width = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightBlue
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCari)
        Me.GroupBox1.Controls.Add(Me.btnBatal)
        Me.GroupBox1.Controls.Add(Me.btnHapus)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSimpan)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.PhComboBoxJabatan)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1067, 222)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Pengeluaran"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 16)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Cari"
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(563, 164)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(426, 22)
        Me.txtCari.TabIndex = 20
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBatal.Enabled = False
        Me.btnBatal.Location = New System.Drawing.Point(889, 114)
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
        Me.btnHapus.Location = New System.Drawing.Point(763, 114)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(100, 28)
        Me.btnHapus.TabIndex = 18
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(639, 114)
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
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username:"
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSimpan.Location = New System.Drawing.Point(511, 114)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 28)
        Me.btnSimpan.TabIndex = 16
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(159, 100)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(265, 22)
        Me.txtPassword.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 103)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 164)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Jabatan"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(159, 46)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(267, 22)
        Me.txtUsername.TabIndex = 22
        '
        'PhComboBoxJabatan
        '
        Me.PhComboBoxJabatan.FormattingEnabled = True
        Me.PhComboBoxJabatan.Items.AddRange(New Object() {"Bendahara", "Kepsek", "Admin"})
        Me.PhComboBoxJabatan.Location = New System.Drawing.Point(159, 158)
        Me.PhComboBoxJabatan.Name = "PhComboBoxJabatan"
        Me.PhComboBoxJabatan.PlaceHolderText = Nothing
        Me.PhComboBoxJabatan.Size = New System.Drawing.Size(267, 24)
        Me.PhComboBoxJabatan.TabIndex = 23
        '
        'FormManageUserForAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.dgvUsersData)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormManageUserForAdmin"
        Me.Text = "Manage Users"
        CType(Me.dgvUsersData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvUsersData As DataGridView
    Friend WithEvents edit As DataGridViewImageColumn
    Friend WithEvents hapus As DataGridViewImageColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents PhComboBoxJabatan As PHComboBox
End Class
