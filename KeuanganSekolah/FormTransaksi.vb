Public Class FormTransaksi

    Private Sub LoadDataTagihan()
        Try
            Dim sql As String = "SELECT j.nama_pembayaran, t.periode, t.status, t.kode_jenis_pembayaran, t.kode_tagihan FROM tagihan t JOIN jenis_pembayaran j ON j.kode_jenis_pembayaran = t.kode_jenis_pembayaran WHERE t.nisn = @nisn ORDER BY t.nisn, t.periode"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nisn", txtCariNISN.Text.Trim())
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        dgvRiwayat.DataSource = Nothing
                        dgvRiwayat.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        ' Refresh data di DataGridView
        LoadDataTagihan()
    End Sub

    Private Sub dgvRiwayat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRiwayat.CellContentClick
        ' Validasi klik pada header atau di luar baris
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvRiwayat.Rows.Count Then
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvRiwayat.Rows(e.RowIndex)
        ' Lakukan sesuatu ketika user mengklik sel button bayar di DataGridView
        If dgvRiwayat.Columns(e.ColumnIndex).Name = "bayar" Then
            ' Ambil data dari jenis_pembayaran berdasarkan kode_jenis_pembayaran
            Dim kode_tagihan As String = selectedRow.Cells("kode_tagihan").Value.ToString()
            Dim NamaTagihan As String = selectedRow.Cells("nama_pembayaran").Value.ToString()
            Dim periode As String = selectedRow.Cells("periode").Value.ToString()
            Dim nominal As Decimal
            Dim namasiswa As String = ""
            Dim operator_name As String = LoginSession.Username
            Dim status As String = selectedRow.Cells("status").Value.ToString()
            Dim nominalTerbayar As Decimal = 0D

            ' mengisi data untuk ditampilkan di form aksi transaksi
            Dim sql As String = "SELECT jp.nominal, s.nama, t.nominal_terbayar FROM tagihan t JOIN jenis_pembayaran jp ON jp.kode_jenis_pembayaran = t.kode_jenis_pembayaran JOIN siswa s ON s.nisn = t.nisn WHERE t.kode_tagihan = @kode_tagihan"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    ' Ambil kode_jenis_pembayaran dari baris yang dipilih di DataGridView
                    cmd.Parameters.AddWithValue("@kode_tagihan", kode_tagihan)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            nominal = Convert.ToDecimal(rdr("nominal"))
                            namasiswa = rdr("nama").ToString()
                            nominalTerbayar = Convert.ToDecimal(rdr("nominal_terbayar"))
                        End If
                    End Using
                End Using
            End Using

            ' Menampilkan form aksi transaksi
            Dim fAksiTransaksi As New FormAksiTransaksivb(kode_tagihan, NamaTagihan, periode, nominal, namasiswa, operator_name, status, nominalTerbayar)
            Dim result As DialogResult = fAksiTransaksi.ShowDialog(FormMenuUtama)

            If result = DialogResult.OK Then
                ' Form ditutup dengan tombol Simpan
                MessageBox.Show("Transaksi berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Form dibatalkan atau ditutup tanpa simpan
                MessageBox.Show("Transaksi dibatalkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ' Lakukan refresh DataGridView
            LoadDataTagihan()
        End If
    End Sub

    'Private Sub btnSimpanPembayaran_Click(sender As Object, e As EventArgs)
    '    ' Validasi input
    '    If numJumlahBayar.Value < 10000 Then
    '        MessageBox.Show("Nominal pembayaran tidak boleh kurang dari 10.000.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Return
    '    End If

    '    ' Simpan data pembayaran ke database transaksi
    '    Try
    '        Dim sql As String = "INSERT INTO transaksi (kode_transaksi, nominal, jenis_transaksi, keterangan, operator, kode_tagihan) VALUES (@kode_transaksi, @nominal, 'masuk', @keterangan, @operator, @kode_tagihan)"
    '        Using conn = DatabaseConnector.GetConnection()
    '            Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
    '                ' Ambil data dari baris yang dipilih di DataGridView
    '                Dim selectedRow As DataGridViewRow = dgvRiwayat.SelectedRows(0)
    '                cmd.Parameters.AddWithValue("@kode_transaksi", RandomKode.GenerateRandomString())
    '                cmd.Parameters.AddWithValue("@nominal", numJumlahBayar.Value)
    '                cmd.Parameters.AddWithValue("@jenis_transaksi", cmbJenisPembayaran.Text)
    '                cmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text)
    '                cmd.Parameters.AddWithValue("@operator", LoginSession.Username)
    '                cmd.Parameters.AddWithValue("@kode_tagihan", dgvRiwayat.SelectedRows(0).Cells("kode_tagihan").Value.ToString())
    '                conn.Open()
    '                cmd.ExecuteNonQuery()
    '                MessageBox.Show("Pembayaran berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show("Gagal menyimpan pembayaran: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub


End Class