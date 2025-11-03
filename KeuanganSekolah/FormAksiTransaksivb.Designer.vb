<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAksiTransaksivb
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnBayar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblKekuranganPembayaran = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numNominalBayar = New System.Windows.Forms.NumericUpDown()
        Me.lblNamaTagihan = New System.Windows.Forms.Label()
        Me.lblPeriode = New System.Windows.Forms.Label()
        Me.lblNominal = New System.Windows.Forms.Label()
        Me.lblNamaSiswa = New System.Windows.Forms.Label()
        Me.lblOperator = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.numNominalBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama Tagihan"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(21, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Periode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nominal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(21, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(103, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nama Siswa"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.KeuanganSekolah.My.Resources.Resources.Rectangle_2
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(21, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(487, 261)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(145, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "DATA TAGIHAN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(21, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Operator"
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatal.ForeColor = System.Drawing.SystemColors.Control
        Me.btnBatal.Location = New System.Drawing.Point(78, 317)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(272, 52)
        Me.btnBatal.TabIndex = 7
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'btnBayar
        '
        Me.btnBayar.BackColor = System.Drawing.Color.Green
        Me.btnBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBayar.ForeColor = System.Drawing.SystemColors.Control
        Me.btnBayar.Location = New System.Drawing.Point(416, 317)
        Me.btnBayar.Name = "btnBayar"
        Me.btnBayar.Size = New System.Drawing.Size(272, 52)
        Me.btnBayar.TabIndex = 8
        Me.btnBayar.Text = "Bayar"
        Me.btnBayar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(527, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 24)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Status"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Location = New System.Drawing.Point(531, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(246, 41)
        Me.Panel1.TabIndex = 10
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(55, 9)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(128, 20)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "Belum Terbayar"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(527, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(223, 24)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Kekurangan Pembayaran"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.lblKekuranganPembayaran)
        Me.Panel2.Location = New System.Drawing.Point(531, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(246, 41)
        Me.Panel2.TabIndex = 12
        '
        'lblKekuranganPembayaran
        '
        Me.lblKekuranganPembayaran.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKekuranganPembayaran.AutoSize = True
        Me.lblKekuranganPembayaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKekuranganPembayaran.Location = New System.Drawing.Point(55, 9)
        Me.lblKekuranganPembayaran.Name = "lblKekuranganPembayaran"
        Me.lblKekuranganPembayaran.Size = New System.Drawing.Size(18, 20)
        Me.lblKekuranganPembayaran.TabIndex = 11
        Me.lblKekuranganPembayaran.Text = "0"
        Me.lblKekuranganPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(527, 213)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 24)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Nominal Bayar"
        '
        'numNominalBayar
        '
        Me.numNominalBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numNominalBayar.Location = New System.Drawing.Point(531, 242)
        Me.numNominalBayar.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numNominalBayar.Name = "numNominalBayar"
        Me.numNominalBayar.Size = New System.Drawing.Size(246, 26)
        Me.numNominalBayar.TabIndex = 14
        '
        'lblNamaTagihan
        '
        Me.lblNamaTagihan.AutoSize = True
        Me.lblNamaTagihan.BackColor = System.Drawing.Color.Transparent
        Me.lblNamaTagihan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaTagihan.ForeColor = System.Drawing.Color.White
        Me.lblNamaTagihan.Location = New System.Drawing.Point(156, 61)
        Me.lblNamaTagihan.Name = "lblNamaTagihan"
        Me.lblNamaTagihan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNamaTagihan.Size = New System.Drawing.Size(42, 20)
        Me.lblNamaTagihan.TabIndex = 15
        Me.lblNamaTagihan.Text = "SPP"
        '
        'lblPeriode
        '
        Me.lblPeriode.AutoSize = True
        Me.lblPeriode.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriode.ForeColor = System.Drawing.Color.White
        Me.lblPeriode.Location = New System.Drawing.Point(105, 95)
        Me.lblPeriode.Name = "lblPeriode"
        Me.lblPeriode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPeriode.Size = New System.Drawing.Size(66, 20)
        Me.lblPeriode.TabIndex = 16
        Me.lblPeriode.Text = "Periode"
        '
        'lblNominal
        '
        Me.lblNominal.AutoSize = True
        Me.lblNominal.BackColor = System.Drawing.Color.Transparent
        Me.lblNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNominal.ForeColor = System.Drawing.Color.White
        Me.lblNominal.Location = New System.Drawing.Point(109, 131)
        Me.lblNominal.Name = "lblNominal"
        Me.lblNominal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNominal.Size = New System.Drawing.Size(70, 20)
        Me.lblNominal.TabIndex = 17
        Me.lblNominal.Text = "Nominal"
        '
        'lblNamaSiswa
        '
        Me.lblNamaSiswa.AutoSize = True
        Me.lblNamaSiswa.BackColor = System.Drawing.Color.Transparent
        Me.lblNamaSiswa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaSiswa.ForeColor = System.Drawing.Color.White
        Me.lblNamaSiswa.Location = New System.Drawing.Point(145, 165)
        Me.lblNamaSiswa.Name = "lblNamaSiswa"
        Me.lblNamaSiswa.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNamaSiswa.Size = New System.Drawing.Size(103, 20)
        Me.lblNamaSiswa.TabIndex = 18
        Me.lblNamaSiswa.Text = "Nama Siswa"
        '
        'lblOperator
        '
        Me.lblOperator.AutoSize = True
        Me.lblOperator.BackColor = System.Drawing.Color.Transparent
        Me.lblOperator.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperator.ForeColor = System.Drawing.Color.White
        Me.lblOperator.Location = New System.Drawing.Point(114, 199)
        Me.lblOperator.Name = "lblOperator"
        Me.lblOperator.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblOperator.Size = New System.Drawing.Size(75, 20)
        Me.lblOperator.TabIndex = 19
        Me.lblOperator.Text = "Operator"
        '
        'FormAksiTransaksivb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(800, 390)
        Me.Controls.Add(Me.lblOperator)
        Me.Controls.Add(Me.lblNamaSiswa)
        Me.Controls.Add(Me.lblNominal)
        Me.Controls.Add(Me.lblPeriode)
        Me.Controls.Add(Me.lblNamaTagihan)
        Me.Controls.Add(Me.numNominalBayar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnBayar)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormAksiTransaksivb"
        Me.Text = "FormAksiTransaksivb"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.numNominalBayar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnBayar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblKekuranganPembayaran As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents numNominalBayar As NumericUpDown
    Friend WithEvents lblNamaTagihan As Label
    Friend WithEvents lblPeriode As Label
    Friend WithEvents lblNominal As Label
    Friend WithEvents lblNamaSiswa As Label
    Friend WithEvents lblOperator As Label
End Class
