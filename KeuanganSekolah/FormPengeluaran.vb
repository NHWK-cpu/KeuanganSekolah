Public Class FormPengeluaran
    Private Sub LoadData()
        Try
            Dim sql As String = "SELECT kode_transaksi, nominal, keterangan, operator, tanggal_transaksi FROM transaksi WHERE jenis_transaksi = 'keluar' ORDER BY tanggal_transaksi LIMIT 20"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        ' Bind to DataGridView using mapped columns (prevent auto-generated duplicate columns)
                        dgvPengeluaran.DataSource = Nothing
                        dgvPengeluaran.DataSource = dt
                        dgvPengeluaran.Columns("kode_transaksi").HeaderText = "Kode Transaksi"
                        dgvPengeluaran.Columns("nominal").HeaderText = "Nominal Transaksi"
                        dgvPengeluaran.Columns("keterangan").HeaderText = "Keterangan"
                        dgvPengeluaran.Columns("operator").HeaderText = "Operator"
                        dgvPengeluaran.Columns("tanggal_transaksi").HeaderText = "Tanggal Transaksi"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi Input
        If numJumlah.Value < 1 OrElse String.IsNullOrWhiteSpace(txtKeterangan.Text) Then
            MessageBox.Show("Jumlah Nominal tidak boleh Nol atau minus dan keterangan tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim tanggal As DateTime = dtpTanggal.Value
        Dim sql As String = "INSERT INTO transaksi(kode_transaksi, nominal, jenis_transaksi, keterangan, operator, tanggal_transaksi) VALUES (@kode_transaksi, @nominal, 'keluar', @keterangan, @operator, @tanggal_transaksi)"
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@kode_transaksi", RandomKode.GenerateRandomString())
                    cmd.Parameters.AddWithValue("@nominal", numJumlah.Value)
                    cmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text)
                    cmd.Parameters.AddWithValue("@operator", LoginSession.Username)
                    cmd.Parameters.AddWithValue("@tanggal_transaksi", tanggal)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data Pengeluaran berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Reset Field dan button
        btnBatal.Enabled = True
        btnBatal.PerformClick()
        btnBatal.Enabled = False

        ' Reload DataGridView
        LoadData()
    End Sub

    Private Sub dgvPengeluaran_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPengeluaran.CellContentClick
        ' Validasi row selected
        If e.RowIndex < 0 Then
            Return
        End If

        ' Validasi Aksi yang ditekan
        Dim selectedRow As DataGridViewRow = dgvPengeluaran.Rows(e.RowIndex)
        If dgvPengeluaran.Columns(e.ColumnIndex).Name = "edit" Then
            dtpTanggal.Text = selectedRow.Cells("tanggal_transaksi").Value.ToString()
            txtKeterangan.Text = selectedRow.Cells("keterangan").Value.ToString()
            numJumlah.Value = selectedRow.Cells("nominal").Value.ToString()

            ' Fokus ke numJumlah untuk memudahkan edit
            numJumlah.Focus()

            ' nyalakan tombol Edit, Hapus, dan Batal matikan Simpan
            btnSimpan.Enabled = False
            btnEdit.Enabled = True
            btnHapus.Enabled = True
            btnBatal.Enabled = True
        ElseIf dgvPengeluaran.Columns(e.ColumnIndex).Name = "hapus" Then
            ' Hapus data siswa
            If e.RowIndex >= 0 Then
                btnHapus.Enabled = True
                btnHapus.PerformClick()
                btnHapus.Enabled = False
            End If
        End If

    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        numJumlah.Value = 0
        txtKeterangan.Clear()
        dtpTanggal.Value = DateTime.Now()

        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnBatal.Enabled = False
    End Sub

    Private Sub FormPengeluaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' Validasi input
        If numJumlah.Value < 1 OrElse String.IsNullOrWhiteSpace(txtKeterangan.Text) Then
            MessageBox.Show("Jumlah Nominal tidak boleh Nol atau minus dan keterangan tidak boleh kosong.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim sql As String = "UPDATE transaksi SET nominal = @nominal, keterangan = @keterangan, operator = @operator, tanggal_transaksi = @tanggal_transaksi WHERE kode_transaksi = @kode_transaksi"
        Try
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nominal", numJumlah.Value)
                    cmd.Parameters.AddWithValue("@keterangan", txtKeterangan.Text)
                    cmd.Parameters.AddWithValue("@operator", LoginSession.Username)
                    cmd.Parameters.AddWithValue("@tanggal_transaksi", dtpTanggal.Value)
                    cmd.Parameters.AddWithValue("@kode_transaksi", dgvPengeluaran.CurrentRow.Cells("kode_transaksi").Value.ToString())

                    conn.Open()
                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Data Pengeluaran berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Tidak ada data yang diperbarui. Periksa kembali kode transaksi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Reset form dan reload data
        btnBatal.PerformClick()
        LoadData()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        ' Konfirmasi penghapusan
        'Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus transaksi ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        'If result = DialogResult.No Then
        '    Return
        'End If

        ' Hapus data dari database
        Try
            Dim sql As String = "DELETE FROM transaksi WHERE kode_transaksi = @kode_transaksi"
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@kode_transaksi", dgvPengeluaran.CurrentRow.Cells("kode_transaksi").Value.ToString())
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        LoadData()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Try
            Dim sql
            If String.IsNullOrWhiteSpace(txtCari.Text) Then
                sql = "SELECT kode_transaksi, nominal, keterangan, operator, tanggal_transaksi FROM transaksi WHERE jenis_transaksi = 'keluar'"
            Else
                sql = "SELECT kode_transaksi, nominal, keterangan, operator, tanggal_transaksi FROM transaksi WHERE jenis_transaksi = 'keluar' AND (keterangan LIKE @search OR operator LIKE @search)"
            End If
            Using conn = DatabaseConnector.GetConnection()
                Using cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@search", "%" & txtCari.Text & "%")
                    conn.Open()
                    Using rdr = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(rdr)

                        dgvPengeluaran.DataSource = Nothing
                        dgvPengeluaran.DataSource = dt
                        dgvPengeluaran.Columns("kode_transaksi").HeaderText = "Kode Transaksi"
                        dgvPengeluaran.Columns("nominal").HeaderText = "Nominal Transaksi"
                        dgvPengeluaran.Columns("keterangan").HeaderText = "Keterangan"
                        dgvPengeluaran.Columns("operator").HeaderText = "Operator"
                        dgvPengeluaran.Columns("tanggal_transaksi").HeaderText = "Tanggal Transaksi"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class