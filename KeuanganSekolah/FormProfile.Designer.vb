<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProfile))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Username = New System.Windows.Forms.Label()
        Me.txtPeran = New System.Windows.Forms.TextBox()
        Me.Peran = New System.Windows.Forms.Label()
        Me.txtPwBaru = New System.Windows.Forms.TextBox()
        Me.PasswordBaru = New System.Windows.Forms.Label()
        Me.txtPwLama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.txtKonfirmasiPw = New System.Windows.Forms.TextBox()
        Me.KonfirmasiPassword = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(178, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(69, 58)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(200, 104)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(160, 20)
        Me.txtUsername.TabIndex = 24
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.Location = New System.Drawing.Point(52, 104)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(65, 15)
        Me.Username.TabIndex = 23
        Me.Username.Text = "Username"
        '
        'txtPeran
        '
        Me.txtPeran.Location = New System.Drawing.Point(200, 147)
        Me.txtPeran.Name = "txtPeran"
        Me.txtPeran.ReadOnly = True
        Me.txtPeran.Size = New System.Drawing.Size(160, 20)
        Me.txtPeran.TabIndex = 26
        '
        'Peran
        '
        Me.Peran.AutoSize = True
        Me.Peran.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Peran.Location = New System.Drawing.Point(52, 147)
        Me.Peran.Name = "Peran"
        Me.Peran.Size = New System.Drawing.Size(40, 15)
        Me.Peran.TabIndex = 25
        Me.Peran.Text = "Peran"
        '
        'txtPwBaru
        '
        Me.txtPwBaru.Location = New System.Drawing.Point(199, 84)
        Me.txtPwBaru.Name = "txtPwBaru"
        Me.txtPwBaru.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwBaru.Size = New System.Drawing.Size(160, 20)
        Me.txtPwBaru.TabIndex = 30
        '
        'PasswordBaru
        '
        Me.PasswordBaru.AutoSize = True
        Me.PasswordBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordBaru.Location = New System.Drawing.Point(50, 84)
        Me.PasswordBaru.Name = "PasswordBaru"
        Me.PasswordBaru.Size = New System.Drawing.Size(93, 15)
        Me.PasswordBaru.TabIndex = 29
        Me.PasswordBaru.Text = "Password Baru:"
        '
        'txtPwLama
        '
        Me.txtPwLama.Location = New System.Drawing.Point(199, 41)
        Me.txtPwLama.Name = "txtPwLama"
        Me.txtPwLama.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwLama.Size = New System.Drawing.Size(160, 20)
        Me.txtPwLama.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Password Lama:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPeran)
        Me.GroupBox1.Controls.Add(Me.Peran)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.Username)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(186, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(417, 198)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informasi Akun"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKonfirmasiPw)
        Me.GroupBox2.Controls.Add(Me.KonfirmasiPassword)
        Me.GroupBox2.Controls.Add(Me.btnBatal)
        Me.GroupBox2.Controls.Add(Me.btnSimpan)
        Me.GroupBox2.Controls.Add(Me.txtPwBaru)
        Me.GroupBox2.Controls.Add(Me.PasswordBaru)
        Me.GroupBox2.Controls.Add(Me.txtPwLama)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(188, 212)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(415, 222)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ganti Password"
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnSimpan.BackgroundImage = CType(resources.GetObject("btnSimpan.BackgroundImage"), System.Drawing.Image)
        Me.btnSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSimpan.Location = New System.Drawing.Point(222, 183)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 23)
        Me.btnSimpan.TabIndex = 31
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnBatal.BackgroundImage = CType(resources.GetObject("btnBatal.BackgroundImage"), System.Drawing.Image)
        Me.btnBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBatal.Location = New System.Drawing.Point(321, 183)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(75, 23)
        Me.btnBatal.TabIndex = 32
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'txtKonfirmasiPw
        '
        Me.txtKonfirmasiPw.Location = New System.Drawing.Point(199, 124)
        Me.txtKonfirmasiPw.Name = "txtKonfirmasiPw"
        Me.txtKonfirmasiPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtKonfirmasiPw.Size = New System.Drawing.Size(160, 20)
        Me.txtKonfirmasiPw.TabIndex = 34
        '
        'KonfirmasiPassword
        '
        Me.KonfirmasiPassword.AutoSize = True
        Me.KonfirmasiPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KonfirmasiPassword.Location = New System.Drawing.Point(50, 124)
        Me.KonfirmasiPassword.Name = "KonfirmasiPassword"
        Me.KonfirmasiPassword.Size = New System.Drawing.Size(126, 15)
        Me.KonfirmasiPassword.TabIndex = 33
        Me.KonfirmasiPassword.Text = "Konfirmasi Password:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(560, -9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(308, 486)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 27
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(-94, -9)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(308, 486)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 33
        Me.PictureBox3.TabStop = False
        '
        'FormProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormProfile"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Username As Label
    Friend WithEvents txtPeran As TextBox
    Friend WithEvents Peran As Label
    Friend WithEvents txtPwBaru As TextBox
    Friend WithEvents PasswordBaru As Label
    Friend WithEvents txtPwLama As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtKonfirmasiPw As TextBox
    Friend WithEvents KonfirmasiPassword As Label
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
