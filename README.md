# SakuSekolah (Aplikasi Manajemen Keuangan Sekolah)

Aplikasi manajemen keuangan sekolah berbasis desktop yang dirancang untuk membantu sekolah dalam mengelola transaksi keuangan, termasuk pemasukan, pengeluaran, dan laporan keuangan.

## Deskripsi

Keuangan Sekolah adalah aplikasi Windows Forms yang dibangun menggunakan VB.NET dan MySQL sebagai basis data. Aplikasi ini menyediakan antarmuka yang intuitif untuk mengelola data siswa, kelas, jenis pembayaran, transaksi, serta menghasilkan laporan keuangan.

## Fitur Utama

- **Manajemen Pengguna**: Login dengan peran berbeda (admin, bendahara, kepala sekolah)
- **Manajemen Siswa**: Tambah, edit, hapus, dan cari data siswa
- **Manajemen Kelas**: Kelola data kelas dan kapasitasnya
- **Manajemen Jenis Pembayaran**: Tambah dan edit jenis pembayaran (SPP, uang kehidupan, dll.)
- **Transaksi Keuangan**: 
  - Pencatatansiswa (SPP, uang masuk lain)
  - Pengeluaran (belanja, gaji, dll.)
  - Pemasukan lain (donasi, hasil usaha sekolah)
- **Laporan Keuangan**: Generate laporan bulanan/tahunan dalam format yang mudah dibaca
- **Backup & Restore**: Fungsi cadangan dan pemulihan data (jika diimplementasikan)
- **Hak Akses Berbasis Peran**: 
  - Admin: Akses penuh ke semua modul
  - Bendahara: Akses ke transaksi, laporan, dan manajemen pembayaran
  - Kepala Sekolah: Akses ke laporan dan manajemen pengguna terbatas

## Teknologi yang Digunakan

- **Bahasa Pemrograman**: VB.NET
- **Framework**: .NET Framework 4.7.2
- **Basis Data**: MySQL
- **Connector**: MySQL Connector/NET
- **UI**: Windows Forms
- **Laporan**: Microsoft Report Viewer (untuk ReportTransaksi.rdlc)
- **Library Tambahan**:
  - BouncyCastle.Cryptography
  - Google.Protobuf
  - K4os.Compression.LZ4
  - System.IO.Pipelines
  - System.Memory
  - ZstdSharp

## Struktur Basis Data

- `user`: Untuk autentikasi (username, password, jabatan)
- `siswa`: Data siswa (nis, nama, kelas, alamat, dll.)
- `kelas`: Data kelas (nama_kelas, kapasitas)
- `jenis_pembayaran`: Jenis-jenis pembayaran (nama, nominal)
- `transaksi`: Catatan transaksi (tanggal, jenis, nominal, keterangan)
- `pemasukan_lainnya`: Pemasukan non-SPP
- `pengeluaran`: Catatan pengeluaran

## Instalasi dan Setup

1. **Prasyarat**:
   - Windows OS
   - .NET Framework 4.7.2 atau lebih tinggi
   - MySQL Server
   - MySQL Connector/NET (sudah disertakan dalam packages)

2. **Langkah-langkah**:
   - Clone atau salin repositori ini ke mesin lokal Anda
   - Pastikan MySQL Server berjalan dan buat database bernama `database_kas_sekolah`
   - Impor skema basis data (jika tersedia sebagai file SQL) atau biarkan aplikasi membuat tabel saat pertama kali dijalankan (jika diimplementasikan)
   - Buka solusi `KeuanganSekolah.sln` di Visual Studio
   - Bangun solusi (Build -> Build Solution)
   - Jalankan aplikasi (Debug -> Start Without Debugging)

3. **Konfigurasi Koneksi**:
   - File koneksi terletak di `App.config`
   - Pastikan string koneksi sesuai dengan pengaturan MySQL Anda:
     ```xml
     <add name="MySqlConn"
          connectionString="server=127.0.0.1;port=3306;database=database_kas_sekolah;uid=root;pwd=;AllowZeroDateTime=True;Convert Zero Datetime=True;"
          providerName="MySql.Data.MySqlClient" />
     ```

## Cara Menggunakan

1. Jalankan aplikasi, akan tampil form login
2. Masukkan username dan password (kredensial default mungkin perlu ditambahkan ke tabel `user`)
3. Setelah login, Anda akan diarahkan ke menu utama sesuai dengan peran Anda
4. Gunakan menu navigasi untuk mengakses berbagai modul:
   - Data Siswa
   - Data Kelas
   - Jenis Pembayaran
   - Transaksi Pembayaran
   - Pengeluaran
   - Pemasukan Lainnya
   - Laporan
   - Manage User (hanya untuk admin)
   - Profile (untuk mengubah password)

## Kontribusi

Kontribusi diterima dengan senang hati! Silakan ikuti langkah-langkah berikut:

1. Fork repositori ini
2. Buat branch fitur baru (`git checkout -b feature/AmazingFeature`)
3. Commit perubahan Anda (`git commit -m 'Add some AmazingFeature'`)
4. Push ke branch (`git push origin feature/AmazingFeature`)
5. Buka Pull Request

Pastikan kode Anda mengikuti gaya kode yang ada dan sertakan dokumentasi yang cukup.

## Kontak

Jika Anda memiliki pertanyaan atau masukan, silakan buat issue di repositori ini.

## Catatan Pengembang

- Aplikasi ini menggunakan parametri query untuk mencegah SQL injection (lihat `DatabaseConnector.vb`)
- Pastikan untuk selalu mencadangkan basis data sebelum melakukan perubahan besar
- Untuk pengembangan lebih lanjut, pertimbangkan penggunaan ORM seperti Entity Framework untuk pemeliharaan yang lebih mudah
- Pertimbangkan menambahkan fitur:
  - Export laporan ke PDF/Excel
  - Notifikasi pembayaran yang jatuh tempo
  - Multi bahasa
  - Tema gelap/terang
