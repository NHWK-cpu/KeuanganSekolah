Public Class FormAksiTransaksivb
    Private kode_tagihan As String
    Private NamaTagihan As String
    Private periode As String
    Private nominal As Decimal
    Private namasiswa As String
    Private operator_name As String
    Private status As String
    Private nominal_terbayar As Decimal
    Private nominal_terbayar_setelah_update As Decimal

    Public Sub New(kode_tagihan As String, NamaTagihan As String, periode As String, nominal As Decimal, namasiswa As String, operator_name As String, status As String, nominal_terbayar As Decimal)
        InitializeComponent()

        Me.kode_tagihan = kode_tagihan
        Me.NamaTagihan = NamaTagihan
        Me.periode = periode
        Me.nominal = nominal
        Me.namasiswa = namasiswa
        Me.operator_name = operator_name
        Me.status = status
        Me.nominal_terbayar = nominal_terbayar
    End Sub
    Private Sub FormAksiTransaksivb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
        Label2.Parent = PictureBox1
        Label3.Parent = PictureBox1
        Label4.Parent = PictureBox1
        Label5.Parent = PictureBox1
        Label6.Parent = PictureBox1
        lblNamaTagihan.Parent = PictureBox1
        lblPeriode.Parent = PictureBox1
        lblNominal.Parent = PictureBox1
        lblNamaSiswa.Parent = PictureBox1
        lblOperator.Parent = PictureBox1

        lblNamaTagihan.Text = NamaTagihan
        lblPeriode.Text = periode
        lblNominal.Text = nominal.ToString("C2")
        lblNamaSiswa.Text = namasiswa
        lblOperator.Text = operator_name
        lblStatus.Text = status
        If status = "Lunas" Then
            Panel1.BackColor = Color.YellowGreen
        ElseIf status = "Belum Lunas" Then
            Panel1.BackColor = Color.Gold
        Else
            Panel1.BackColor = Color.Salmon
        End If

        ' Menghitung sisa pembayaran
        Dim sisaPembayaran As Decimal = nominal - nominal_terbayar
        lblKekuranganPembayaran.Text = sisaPembayaran.ToString("C2")
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        ' Validasi pembayaran
        If numNominalBayar.Value < 1 Then
            MessageBox.Show("Nominal Bayar harus lebih dari 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Buat data transaksi di database transaksi
        Dim pembayaran As Decimal = numNominalBayar.Value
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand("INSERT INTO transaksi (kode_transaksi, nominal, jenis_transaksi, keterangan, operator, tanggal_transaksi, kode_tagihan) VALUES (@kode_transaksi, @nominal, @jenis_transaksi, @keterangan, @operator, NOW(), @kode_tagihan)", conn)
                    cmd.Parameters.AddWithValue("@kode_transaksi", RandomKode.GenerateRandomString())
                    cmd.Parameters.AddWithValue("@nominal", pembayaran)
                    cmd.Parameters.AddWithValue("@jenis_transaksi", "masuk")
                    cmd.Parameters.AddWithValue("@keterangan", "Pembayaran " & NamaTagihan & " periode " & periode)
                    cmd.Parameters.AddWithValue("@operator", operator_name)
                    cmd.Parameters.AddWithValue("@kode_tagihan", kode_tagihan)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memproses pembayaran: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        'Update data tagihan
        Try
            Dim sqlUpdateTagihan As String = "UPDATE tagihan SET nominal_terbayar = nominal_terbayar + @pembayaran WHERE kode_tagihan = @kode_tagihan"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlUpdateTagihan, conn)
                    cmd.Parameters.AddWithValue("@pembayaran", pembayaran)
                    cmd.Parameters.AddWithValue("@kode_tagihan", kode_tagihan)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui tagihan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Jika tagihan lunas, update status

        Try
            ' Mengambil nominal_terbayar terbaru
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand("SELECT nominal_terbayar FROM tagihan WHERE kode_tagihan = @kode_tagihan", conn)
                    cmd.Parameters.AddWithValue("@kode_tagihan", kode_tagihan)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            nominal_terbayar_setelah_update = Convert.ToDecimal(rdr("nominal_terbayar"))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
        If nominal_terbayar_setelah_update >= nominal Then
            Try
                Dim sqlUpdateStatus As String = "UPDATE tagihan SET status = 'Lunas' WHERE kode_tagihan = @kode_tagihan"
                Using conn = DatabaseConnector.GetConnection()
                    Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlUpdateStatus, conn)
                        cmd.Parameters.AddWithValue("@kode_tagihan", kode_tagihan)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal memperbarui status tagihan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf nominal_terbayar_setelah_update < nominal Then
            Try
                Dim sqlUpdateStatus As String = "UPDATE tagihan SET status = 'Belum Lunas' WHERE kode_tagihan = @kode_tagihan"
                Using conn = DatabaseConnector.GetConnection()
                    Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sqlUpdateStatus, conn)
                        cmd.Parameters.AddWithValue("@kode_tagihan", kode_tagihan)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Gagal memperbarui status tagihan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class