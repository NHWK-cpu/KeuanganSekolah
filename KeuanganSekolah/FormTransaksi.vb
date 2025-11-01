Public Class FormTransaksi

    Private Sub LoadDataTagihan()
        Try
            Dim sql As String = "SELECT periode, status, kode_jenis_pembayaran, kode_tagihan FROM tagihan WHERE nisn = @nisn ORDER BY nisn, periode"
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

    'Private Sub dgvRiwayat_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvRiwayat.CellMouseDoubleClick
    '    ' Masukkan data ke Combobox untuk diproses pembayaran
    '    If e.RowIndex < 0 OrElse e.RowIndex >= dgvRiwayat.Rows.Count Then
    '        Return
    '    End If
    '    Dim selectedRow As DataGridViewRow = dgvRiwayat.Rows(e.RowIndex)

    '    ' Ambil data dari jenis_pembayaran berdasarkan kode_jenis_pembayaran
    '    Dim sql As String = "SELECT nama_pembayaran, Nominal FROM jenis_pembayaran WHERE kode_jenis_pembayaran = @kode_jenis_pembayaran"
    '    Using conn = DatabaseConnector.GetConnection()
    '        Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
    '            ' Ambil kode_jenis_pembayaran dari baris yang dipilih di DataGridView
    '            cmd.Parameters.AddWithValue("@kode_jenis_pembayaran", selectedRow.Cells("kode_jenis_pembayaran").Value.ToString())
    '            conn.Open()
    '            Using rdr = cmd.ExecuteReader()
    '                If rdr.Read() Then
    '                    cmbJenisPembayaran.Text = rdr("nama_pembayaran").ToString()
    '                    numNominal.Value = Convert.ToDecimal(rdr("Nominal"))
    '                End If
    '            End Using
    '        End Using
    '    End Using

    'End Sub

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