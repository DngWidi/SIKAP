# Desain Menu Aplikasi HRIS
**Platform:** Visual Basic .NET (VB Community 2022) + Guna UI2 + MySQL Server

---

## 1. Struktur Utama (Main Menu / Ribbon atau Sidebar)

Karena siklus HRIS mengikuti perjalanan karyawan (employee lifecycle), susun menu berdasarkan urutan proses bisnis, bukan sekadar per tabel database. Berikut struktur level atas yang disarankan:

```
├── Dashboard
├── Rekrutmen
├── Data Karyawan
├── Absensi & Kehadiran
├── Lembur
├── Cuti & Izin
├── Penilaian Kinerja (Performance Appraisal)
├── Penggajian (Payroll)
├── Resign / Offboarding
├── Master Data
├── Laporan (Reports)
├── Pengaturan & Keamanan (Settings & User Management)
└── Bantuan / Tentang Aplikasi
```

---

## 2. Rincian Tiap Modul

### 2.1 Dashboard
- Ringkasan jumlah karyawan aktif, cuti hari ini, karyawan terlambat, ulang tahun bulan ini
- Grafik headcount per departemen
- Notifikasi: pengajuan cuti pending, kontrak akan habis, penilaian jatuh tempo
- Shortcut ke modul yang sering dipakai

### 2.2 Rekrutmen (Recruitment)
- **Lowongan Pekerjaan** – input posisi, departemen, kualifikasi, status buka/tutup
- **Data Pelamar (Candidate Pool)** – biodata, CV upload, sumber lamaran
- **Seleksi & Tahapan Interview** – tracking status (screening, interview 1/2, tes, offering)
- **Penilaian Interview** – skor per interviewer, catatan
- **Penawaran Kerja (Job Offer)** – template surat penawaran, status accept/reject
- **Konversi Pelamar → Karyawan** – tombol otomatis pindahkan data pelamar diterima ke modul Data Karyawan (hindari input ulang)

### 2.3 Data Karyawan (Employee Master Data)
- **Biodata Karyawan** – data pribadi, kontak, pendidikan, keluarga, dokumen (KTP, NPWP, ijazah)
- **Data Kepegawaian** – NIK karyawan, departemen, jabatan, status (tetap/kontrak/magang), tanggal join
- **Riwayat Jabatan/Mutasi** – histori promosi, rotasi, mutasi departemen
- **Kontrak Kerja** – tanggal mulai/berakhir kontrak, reminder perpanjangan
- **Dokumen Karyawan** – upload/scan dokumen pendukung
- **Struktur Organisasi** – bagan departemen dan hierarki atasan-bawahan

### 2.4 Absensi & Kehadiran
- **Input/Import Absensi** – manual, atau import dari mesin fingerprint/face recognition (file txt/csv)
- **Jadwal Kerja (Shift)** – pengaturan shift kerja per karyawan/departemen
- **Rekap Kehadiran** – harian, mingguan, bulanan
- **Approval Keterlambatan/Izin Absen**
- **Pengaturan Hari Libur/Kalender Kerja**

### 2.5 Lembur (Overtime)
- **Pengajuan Lembur** – karyawan/atasan input rencana lembur
- **Approval Lembur** – berjenjang (atasan langsung → HR)
- **Perhitungan Jam Lembur** – otomatis berdasarkan aturan (per jam, hari libur, dsb.)
- **Riwayat Lembur per Karyawan**

### 2.6 Cuti & Izin (Leave Management)
- **Master Jenis Cuti** – cuti tahunan, sakit, melahirkan, izin khusus
- **Saldo Cuti** – otomatis bertambah tiap periode, otomatis berkurang saat approved
- **Pengajuan Cuti/Izin**
- **Approval Cuti** – alur persetujuan berjenjang
- **Riwayat & Kalender Cuti** – lihat siapa saja yang cuti dalam rentang tanggal tertentu

### 2.7 Penilaian Kinerja (Performance Appraisal)
- **Master KPI/Kriteria Penilaian** – per jabatan/departemen
- **Periode Penilaian** – bulanan/triwulan/tahunan
- **Input Penilaian** – oleh atasan, bisa ditambah self-assessment
- **Hasil & Skor Akhir** – otomatis kalkulasi bobot
- **Riwayat Penilaian per Karyawan** – untuk bahan promosi/kenaikan gaji
- **Rekomendasi Tindak Lanjut** – training, promosi, warning

### 2.8 Penggajian (Payroll)
- **Master Komponen Gaji** – gaji pokok, tunjangan, potongan, BPJS, PPh 21
- **Master Golongan/Grade Gaji**
- **Proses Penggajian Bulanan** – otomatis tarik data absensi, lembur, cuti tanpa gaji, potongan
- **Slip Gaji** – generate & cetak/export PDF per karyawan
- **Perhitungan Pajak (PPh 21)** – sesuai aturan pajak terbaru
- **Perhitungan BPJS (Kesehatan & Ketenagakerjaan)**
- **Riwayat Penggajian** – per periode, per karyawan
- **Export ke Bank (Payroll Transfer File)** – format sesuai bank yang dipakai perusahaan

### 2.9 Resign / Offboarding
- **Pengajuan Resign** – tanggal pengajuan, alasan, tanggal efektif
- **Approval Resign**
- **Exit Interview** – form dan catatan
- **Clearance/Checklist Offboarding** – aset kembali, akun nonaktif, dokumen final
- **Perhitungan Pesangon/Hak Terakhir** – sisa cuti, gaji terakhir, pesangon (jika ada)
- **Update Status Karyawan → Non-Aktif** – otomatis riwayat tetap tersimpan (bukan dihapus)

### 2.10 Master Data (Data Pendukung)
- Departemen, Jabatan, Level/Grade
- Lokasi/Cabang Kantor
- Jenis Cuti, Jenis Lembur, Komponen Gaji
- Kalender Nasional/Hari Libur
- Bank (untuk transfer gaji)
- Template Surat (offering, kontrak, SK, surat peringatan)

### 2.11 Laporan (Reports)
- Laporan Rekrutmen (funnel pelamar, time to hire)
- Laporan Kehadiran & Keterlambatan
- Laporan Lembur
- Laporan Cuti
- Laporan Penilaian Kinerja
- Laporan Payroll (slip gaji massal, rekap per departemen, PPh 21, BPJS)
- Laporan Turnover/Resign
- Laporan Headcount & Demografi Karyawan
- *(Sebaiknya semua laporan bisa difilter periode & export ke Excel/PDF)*

### 2.12 Pengaturan & Keamanan
- **Manajemen User & Role** – Admin HR, Staff HR, Manager, Karyawan (self-service)
- **Hak Akses per Modul (Role-Based Access Control)**
- **Log Aktivitas (Audit Trail)** – siapa mengubah data apa dan kapan
- **Backup & Restore Database**
- **Pengaturan Umum Perusahaan** – logo, alamat, konfigurasi periode payroll

### 2.13 Employee Self-Service (opsional tapi sangat disarankan)
Jika aplikasi juga dipakai karyawan (bukan cuma HR), pertimbangkan modul terpisah:
- Lihat slip gaji sendiri
- Ajukan cuti/izin/lembur sendiri
- Lihat hasil penilaian kinerja
- Update data pribadi (perlu approval HR)

---

## 3. Rekomendasi Alur Navigasi (UI dengan Guna UI2)

- Gunakan **GunaAdvancedPanel/GunaSidebarMenu** sebagai menu utama di sisi kiri, dikelompokkan sesuai modul di atas
- Gunakan **GunaTabControl** di dalam tiap modul untuk memisahkan sub-menu (misal: Data Karyawan → Tab Biodata, Tab Kontrak, Tab Dokumen)
- Gunakan **GunaDataGridView** untuk semua tampilan list data dengan fitur search/filter di atasnya
- Gunakan **GunaMessageDialog** untuk konfirmasi approval (cuti, lembur, resign) agar konsisten
- Terapkan **Role-Based Menu Visibility** – menu yang muncul menyesuaikan hak akses user yang login (misal karyawan biasa tidak melihat menu Payroll admin)

---

## 4. Catatan Desain Database (Singkat)

Agar menu di atas berjalan mulus, pastikan struktur tabel MySQL mendukung:
- Tabel `employees` sebagai pusat, dengan status (`active`, `resigned`, `on_leave`)
- Tabel transaksi terpisah per modul (`attendance`, `overtime`, `leave_requests`, `payroll_runs`, `appraisals`, `recruitment_candidates`) yang semuanya berelasi ke `employees` via `employee_id`
- Jangan hapus data karyawan resign, cukup ubah status — riwayat harus tetap bisa dilaporkan
- Gunakan tabel `audit_log` terpisah untuk mencatat perubahan data penting (gaji, approval)

---

Jika Anda mau, saya bisa lanjutkan ke tahap berikutnya, misalnya:
1. Rancangan **struktur tabel database (ERD)** MySQL secara detail
2. Wireframe/mockup tampilan untuk salah satu modul (misal Payroll atau Absensi)
3. Alur proses (flowchart) untuk approval berjenjang (cuti/lembur/resign)

Beri tahu saya mau mulai dari mana.
