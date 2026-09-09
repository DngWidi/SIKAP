
Imports System.Runtime.InteropServices
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class frmPermintaanKaryawanAdd
    Private _mode As ModeForm = ModeForm.Tambah
    Private _idPermintaan As Long = 0
    Dim kodeSection As String = ""
    Public Enum ModeForm
        Tambah
        Edit
        View
    End Enum
    Public Enum StatusPermintaan
        Draft
        Submitted
        WaitingDepartmentApproval
        Revision
        WaitingHRApproval
        Approved
        Recruitment
        PartiallyFulfilled
        OnHold
        Fulfilled
        Rejected
        Closed
    End Enum
#Region "Property"

    Public Property Mode As ModeForm

        Get
            Return _mode
        End Get

        Set(value As ModeForm)
            _mode = value
        End Set

    End Property
    Public Property IdPermintaan As Long

        Get
            Return _idPermintaan
        End Get

        Set(value As Long)
            _idPermintaan = value
        End Set

    End Property

#End Region
#Region "Function"
    Private Function ValidasiDraft() As Boolean

        If csection.SelectedIndex = -1 Then

            PesanPopupPeringatan("Section belum dipilih.", "Silakan pilih section terlebih dahulu.")

            csection.Focus()

            Return False

        End If


        If cjabatan.SelectedIndex = -1 Then

            PesanPopupPeringatan("Jabatan belum dipilih.", "Silakan pilih jabatan yang dibutuhkan.")

            cjabatan.Focus()

            Return False

        End If


        Return True

    End Function
    Private Function ValidasiAjukan() As Boolean

        '========================================
        ' SECTION
        '========================================

        If csection.SelectedIndex = -1 Then

            PesanPopupPeringatan("Section belum dipilih.", "Silakan pilih section terlebih dahulu.")

            csection.Focus()

            Return False

        End If


        '========================================
        ' JABATAN
        '========================================

        If cjabatan.SelectedIndex = -1 Then

            PesanPopupPeringatan("Jabatan belum dipilih.", "Silakan pilih jabatan yang dibutuhkan.")

            cjabatan.Focus()

            Return False

        End If


        '========================================
        ' JUMLAH
        '========================================

        If njumlah.Value <= 0 Then

            PesanPopupPeringatan("Jumlah karyawan belum valid.", "Jumlah karyawan minimal 1 orang.")

            njumlah.Focus()

            Return False

        End If


        '========================================
        ' JENIS KEBUTUHAN
        '========================================

        If cjeniskebutuhan.SelectedIndex = -1 Then

            PesanPopupPeringatan("Jenis kebutuhan belum dipilih.", "Silakan pilih Replacement atau Additional.")

            cjeniskebutuhan.Focus()

            Return False

        End If


        '========================================
        ' REPLACEMENT
        '========================================

        If cjeniskebutuhan.SelectedItem.ToString() = "Replacement" Then

            If creplacement.SelectedIndex = -1 Then

                PesanPopupPeringatan("Karyawan pengganti belum dipilih.", "Silakan pilih karyawan yang akan digantikan.")

                creplacement.Focus()

                Return False

            End If


            If calasanreplacement.SelectedIndex = -1 Then

                PesanPopupPeringatan("Alasan replacement belum dipilih.", "Silakan pilih alasan replacement.")

                calasanreplacement.Focus()

                Return False

            End If

        End If


        '========================================
        ' STATUS KARYAWAN
        '========================================

        If cstatuskaryawan.SelectedIndex = -1 Then

            PesanPopupPeringatan("Status karyawan belum dipilih.", "Silakan pilih status kepegawaian.")

            cstatuskaryawan.Focus()

            Return False

        End If


        '========================================
        ' ALASAN KEBUTUHAN
        '========================================

        If calasan.SelectedIndex = -1 Then

            PesanPopupPeringatan("Alasan kebutuhan belum dipilih.", "Silakan pilih alasan kebutuhan karyawan.")

            calasan.Focus()

            Return False

        End If


        '========================================
        ' JUSTIFIKASI
        '========================================

        If String.IsNullOrWhiteSpace(tpenjelasan.Text) Then

            PesanPopupPeringatan("Justifikasi belum diisi.", "Silakan jelaskan alasan kebutuhan karyawan.")

            tpenjelasan.Focus()

            Return False

        End If


        '========================================
        ' PENDIDIKAN
        '========================================

        If cpendidikan.SelectedIndex = -1 Then

            PesanPopupPeringatan("Pendidikan belum dipilih.", "Silakan pilih pendidikan minimal.")

            cpendidikan.Focus()

            Return False

        End If


        Return True

    End Function
#End Region
#Region "Private"
    Private Function GenerateNoPermintaan() As String
        Dim noBaru As String = ""
        Dim tahunSekarang As String = DateTime.Now.Year.ToString()
        Dim urutan As Integer = 1

        Try
            ' Asumsi variabel 'sambung' adalah connection string global Anda yang ada di modul
            Using conn As New MySqlConnection(sambung)
                conn.Open()

                ' Mengambil nomor permintaan terakhir (paling baru) di tahun berjalan
                Dim sql As String = "SELECT ffcnopermintaan FROM sapermintaankaryawan WHERE YEAR(ffdtglpermintaan) = @Tahun ORDER BY ffcidpermintaan DESC LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Tahun", DateTime.Now.Year)

                    ' Eksekusi query dan ambil nilainya
                    Dim lastNo As Object = cmd.ExecuteScalar()

                    ' Jika ada data di tahun ini
                    If lastNo IsNot Nothing AndAlso lastNo IsNot DBNull.Value Then
                        ' Contoh isi lastNo: "001/UPK/BBB/2026"
                        ' Kita ambil 3 karakter pertama saja dari kiri
                        Dim strUrutan As String = lastNo.ToString().Substring(0, 3)

                        ' Konversi ke Integer lalu tambah 1
                        If Integer.TryParse(strUrutan, urutan) Then
                            urutan += 1
                        Else
                            urutan = 1 ' Fallback jika format salah
                        End If
                    End If
                    ' Jika Else (tidak ada data), urutan tetap 1 sesuai nilai default di atas
                End Using
            End Using

            ' Format angka menjadi 3 digit (contoh: 1 menjadi "001") lalu gabung dengan template
            noBaru = urutan.ToString("000") & "/UPK/BBB/" & tahunSekarang

        Catch ex As Exception
            PesanPopupError("Error", "Gagal membuat nomor permintaan otomatis." & vbCrLf & ex.Message)
            ' Fallback jika terjadi error koneksi agar tidak kosong sama sekali
            noBaru = "001/UPK/BBB/" & tahunSekarang
        End Try
        Return noBaru
    End Function
    Private Sub section()
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                ' SESUAIKAN: Nama tabel dan kolom master section/departemen Anda
                Dim sql As String = "SELECT ffcbag ,ffcnama  FROM sabagian  ORDER BY ffcnama ASC"
                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        ' Tambahkan opsi default di baris pertama
                        Dim row As DataRow = dt.NewRow()
                        row("ffcbag") = ""
                        row("ffcnama") = "-- Pilih Section --"
                        dt.Rows.InsertAt(row, 0)

                        csection.DataSource = dt
                        csection.DisplayMember = "ffcnama" ' Yang tampil di layar
                        csection.ValueMember = "ffcbag"   ' Nilai/Kode yang disimpan
                        csection.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memuat data Section." & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Jabatan()
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                ' SESUAIKAN: Nama tabel dan kolom master jabatan Anda
                Dim sql As String = "SELECT ffckls, ffcnama FROM sajabatan a ORDER BY ffcnama ASC"
                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        Dim row As DataRow = dt.NewRow()
                        row("ffckls") = ""
                        row("ffcnama") = "-- Pilih Jabatan --"
                        dt.Rows.InsertAt(row, 0)

                        cjabatan.DataSource = dt
                        cjabatan.DisplayMember = "ffcnama"
                        cjabatan.ValueMember = "ffckls"
                        cjabatan.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memuat data Jabatan." & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub KaryawanReplacement(kodeSection As String)
        Try
            ' Jika kode section kosong (belum dipilih), bersihkan dropdown replacement
            If String.IsNullOrEmpty(kodeSection) Then
                creplacement.DataSource = Nothing
                creplacement.Items.Clear()
                Return
            End If

            Using conn As New MySqlConnection(sambung)
                conn.Open()
                ' SESUAIKAN: Asumsi field relasi ke section di tabel sakaryawan adalah 'ffckdsection'
                Dim sql As String = "SELECT ffcnik,ffcnama  FROM sajatidiri  WHERE ffcbagian = @KdSection ORDER BY ffcnama ASC"

                Using cmd As New MySqlCommand(sql, conn)
                    ' Masukkan parameter kode section yang dilempar dari event csection
                    cmd.Parameters.AddWithValue("@KdSection", kodeSection)

                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)

                        Dim row As DataRow = dt.NewRow()
                        row("ffcnik") = ""
                        row("ffcnama") = "-- Pilih Karyawan --"
                        dt.Rows.InsertAt(row, 0)

                        creplacement.DataSource = dt
                        creplacement.DisplayMember = "ffcnama"
                        creplacement.ValueMember = "ffcnik"
                        creplacement.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memuat data Karyawan Replacement." & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Prioritas()

        cprioritas.Items.Clear()

        cprioritas.Items.Add("Normal")
        cprioritas.Items.Add("Urgent")

        cprioritas.SelectedIndex = 0

    End Sub
    Private Sub StatusKaryawan()

        cstatuskaryawan.Items.Clear()

        cstatuskaryawan.Items.Add("Tetap")
        cstatuskaryawan.Items.Add("Kontrak")
        cstatuskaryawan.Items.Add("Outsourcing")
        cstatuskaryawan.Items.Add("Magang")

        cstatuskaryawan.SelectedIndex = -1

    End Sub
    Private Sub Alasan()

        calasan.Items.Clear()

        calasan.Items.Add("Replacement")
        calasan.Items.Add("Penambahan Beban Kerja")
        calasan.Items.Add("Pembukaan Section Baru")
        calasan.Items.Add("Perluasan Operasional")
        calasan.Items.Add("Proyek Baru")
        calasan.Items.Add("Perubahan Struktur Organisasi")
        calasan.Items.Add("Manpower Planning")
        calasan.Items.Add("Lainnya")

        calasan.SelectedIndex = -1

    End Sub
    Private Sub Pendidikan()

        cpendidikan.Items.Clear()

        cpendidikan.Items.Add("SMP")
        cpendidikan.Items.Add("SMA")
        cpendidikan.Items.Add("SMK")
        cpendidikan.Items.Add("D1")
        cpendidikan.Items.Add("D2")
        cpendidikan.Items.Add("D3")
        cpendidikan.Items.Add("D4")
        cpendidikan.Items.Add("S1")
        cpendidikan.Items.Add("S2")
        cpendidikan.Items.Add("S3")

    End Sub
    Private Sub Jurusan()
        cjurusan.Items.Clear()
        cjurusan.Items.Add("Semua Jurusan")
        cjurusan.Items.Add("Teknik Mesin")
        cjurusan.Items.Add("Teknik Industri")
        cjurusan.Items.Add("Teknik Elektro")
        cjurusan.Items.Add("Akuntansi")
        cjurusan.Items.Add("Manajemen")
        cjurusan.Items.Add("Ilmu Komputer / IT")
        cjurusan.Items.Add("Hukum")
        cjurusan.Items.Add("Psikologi")

        cjurusan.SelectedIndex = 0
    End Sub
    Private Sub SetupDefaultValue()

        dtglpermintaan.Value = DateTime.Now

        dtglkebutuhan.Value = DateTime.Now.AddDays(7)

        njumlah.Minimum = 1
        njumlah.Maximum = 999
        njumlah.Value = 1

        pnlReplacement.Visible = False

    End Sub
    Private Sub SetupMode()

        Select Case _mode

            Case ModeForm.Tambah

                lblTitle.Text = "Tambah Permintaan Karyawan"
                lblDescription.Text = "Tambahkan permintaan karyawan baru ke dalam sistem"

                tnopermintaan.Text = GenerateNoPermintaan()
                lnopermintaan.Text = tnopermintaan.Text
                tnopermintaan.ReadOnly = True

                bSimpan.Enabled = True
                bAjukan.Enabled = True


            Case ModeForm.Edit

                lblTitle.Text = "Edit Permintaan Karyawan"
                lblDescription.Text = "Edit permintaan karyawan baru ke dalam sistem"
                bSimpan.Enabled = True
                bAjukan.Enabled = True
                LoadDataPermintaan()
            Case ModeForm.View

                lblTitle.Text = "Detail Permintaan Karyawan"
                lblDescription.Text = "Detail permintaan karyawan baru ke dalam sistem"
                SetReadOnlyMode()
                LoadDataPermintaan()
        End Select

    End Sub
    Private Sub SetReadOnlyMode()

        '========================================
        ' INFORMASI PERMINTAAN
        '========================================

        cprioritas.Enabled = False

        '========================================
        ' DETAIL KEBUTUHAN
        '========================================

        csection.Enabled = False
        cjabatan.Enabled = False
        njumlah.Enabled = False
        cjeniskebutuhan.Enabled = False
        cstatuskaryawan.Enabled = False
        dtglkebutuhan.Enabled = False

        '========================================
        ' ALASAN
        '========================================

        calasan.Enabled = False

        '========================================
        ' KUALIFIKASI
        '========================================

        cpendidikan.Enabled = False

        '========================================
        ' BUTTON
        '========================================

        bSimpan.Visible = False
        bAjukan.Visible = False

    End Sub
    Private Sub LoadDataPermintaan()

        If _idPermintaan <= 0 Then
            PesanPopupPeringatan("Peringatan", "ID permintaan tidak valid.")
            Return
        End If

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT a.ffcidpermintaan ,a.ffcnopermintaan ,a.ffdtglpermintaan ,b.ffcnama AS `Requester`,c.ffcnama AS `Department` ,a.ffckdbagian ,a.ffckdjabatan ,a.ffnjumlah ,a.ffcjnskebutuhan ,a.ffcprioritas ," &
                "a.ffcstatuskaryawan,a.ffdtglbutuh, a.ffcalasan ,a.ffcjustifikasi ,a.ffcnikreplacement ,a.ffcalasanreplace ,a.ffcstatus ,a.ffcpendidikan ,a.ffcjurusan ,a.ffnpengalaman ," &
                "a.ffckompetensi ,a.ffcsertifikasi ,a.ffcdeskripsi ,a.ffctanggungjawab ,a.ffcpersyaratan,a.ffccatatan  " &
                "FROM sapermintaankaryawan a LEFT JOIN sajatidiri b ON a.ffcnikrequester = b.ffcnik LEFT JOIN sadepartment c ON a.ffckddepart = c.ffckode  WHERE ffcidpermintaan = @ID LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ID", _idPermintaan)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            PesanPopupPeringatan("Data Tidak Ditemukan", "Data permintaan karyawan tidak ditemukan.")
                            Return
                        End If

                        '========================================
                        'INFORMASI REQUESTER
                        '========================================

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcnopermintaan")) Then
                            tnopermintaan.Text = reader("ffcnopermintaan").ToString()
                            lnopermintaan.Text = reader("ffcnopermintaan").ToString()
                        End If

                        If Not reader.IsDBNull(reader.GetOrdinal("ffdtglpermintaan")) Then
                            dtglpermintaan.Value = Convert.ToDateTime(reader("ffdtglpermintaan"))
                        End If

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcprioritas")) Then
                            cprioritas.SelectedValue = reader("ffcprioritas").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("Requester")) Then
                            trequester.Text = reader("Requester").ToString()
                        End If

                        If Not reader.IsDBNull(reader.GetOrdinal("Department")) Then
                            tdepartmentrequester.Text = reader("Department").ToString()
                        End If


                        '========================================
                        ' INFORMASI KEBUTUHAN
                        '========================================

                        If Not reader.IsDBNull(reader.GetOrdinal("ffckdbagian")) Then
                            csection.SelectedValue = reader("ffckdbagian").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffckdjabatan")) Then
                            cjabatan.SelectedValue = reader("ffckdjabatan").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffnjumlah")) Then
                            njumlah.Value = Convert.ToDecimal(reader("ffnjumlah"))
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffcjnskebutuhan")) Then
                            cjeniskebutuhan.Text = reader("ffcjnskebutuhan").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffcstatuskaryawan")) Then
                            cstatuskaryawan.Text = reader("ffcstatuskaryawan").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffdtglbutuh")) Then
                            dtglkebutuhan.Value = Convert.ToDateTime(reader("ffdtglbutuh"))
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffcnikreplacement")) Then
                            creplacement.SelectedValue = reader("ffcnikreplacement").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffcalasanreplace")) Then
                            calasanreplacement.SelectedValue = reader("ffcalasanreplace").ToString()
                        End If

                        '========================================
                        ' ALASAN KEBUTUHAN
                        '========================================

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcalasan")) Then
                            calasan.Text = reader("ffcalasan").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffcjustifikasi")) Then
                            tpenjelasan.Text = reader("ffcjustifikasi").ToString()
                        End If

                        '========================================
                        ' KUALITAS YANG DI BUTUHKAN
                        '========================================

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcpendidikan")) Then
                            cpendidikan.Text = reader("ffcpendidikan").ToString()
                        End If

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcjurusan")) Then
                            cjurusan.Text = reader("ffcjurusan").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffnpengalaman")) Then
                            npengalaman.Value = Convert.ToDecimal(reader("ffnpengalaman"))
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffckompetensi")) Then
                            tkompetensi.Text = reader("ffckompetensi").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffcsertifikasi")) Then
                            tsertifikat.Text = reader("ffcsertifikasi").ToString()
                        End If

                        '========================================
                        ' deskripsi, tanggung jawab, persyaratan
                        '========================================

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcdeskripsi")) Then
                            tdeskripsi.Text = reader("ffcdeskripsi").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffctanggungjawab")) Then
                            ttanggungjawab.Text = reader("ffctanggungjawab").ToString()
                        End If

                        '========================================
                        ' deskripsi, tanggung jawab, persyaratan
                        '========================================

                        If Not reader.IsDBNull(reader.GetOrdinal("ffcpersyaratan")) Then
                            tsyaratkhusus.Text = reader("ffcpersyaratan").ToString()
                        End If
                        If Not reader.IsDBNull(reader.GetOrdinal("ffccatatan")) Then
                            tcatatan.Text = reader("ffccatatan").ToString()
                        End If



                    End Using

                End Using

            End Using

        Catch ex As MySqlException
            PesanPopupError("Database Error", "Gagal mengambil data permintaan." & vbCrLf & ex.Message)

        Catch ex As Exception

            PesanPopupError("Error", "Terjadi kesalahan saat mengambil data." & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub frmPermintaanKaryawanAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        Prioritas()
        StatusKaryawan()
        Alasan()
        Pendidikan()
        SetupDefaultValue()
        section()
        Jabatan()
        Jurusan()

        SetupMode()
    End Sub
#End Region

    Private Sub cjeniskebutuhan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cjeniskebutuhan.SelectedIndexChanged
        If cjeniskebutuhan.SelectedIndex = -1 Then
            pnlReplacement.Visible = False
            Return
        End If


        If cjeniskebutuhan.SelectedItem.ToString() = "Replacement" Then
            pnlReplacement.Visible = True
        Else
            pnlReplacement.Visible = False
            'Bersihkan data replacement
            creplacement.SelectedIndex = -1
            calasanreplacement.SelectedIndex = -1
        End If
    End Sub

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click
        ' 1. Cek Validasi Input
        If Not ValidasiDraft() Then
            Return
        End If

        ' 2. Konfirmasi User
        Dim result As DialogResult = PesanPopupKonfirmasi("Simpan Draft", "Apakah Anda yakin ingin menyimpan data permintaan ini sebagai Draft?")
        If result <> DialogResult.Yes Then
            Return
        End If

        ' 3. Proses Database
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            ' Menggunakan Transaction agar jika ada error di tengah jalan, data di-rollback
            Using trans As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim sql As String = ""
                    Using cmd As New MySqlCommand()
                        cmd.Connection = conn
                        cmd.Transaction = trans

                        ' ==========================================
                        ' A. PERSIAPKAN DATA DARI COMBOBOX
                        ' ==========================================
                        ' Ambil ValueMember (Kode) untuk combobox yang ambil dari database
                        Dim kdSection As String = If(csection.SelectedIndex > 0, csection.SelectedValue.ToString(), "")
                        Dim kdJabatan As String = If(cjabatan.SelectedIndex > 0, cjabatan.SelectedValue.ToString(), "")

                        ' Persiapkan data Replacement (bisa kosong jika bukan replacement)
                        Dim nikReplacement As String = ""
                        Dim alasanReplacement As String = ""
                        If cjeniskebutuhan.SelectedItem IsNot Nothing AndAlso cjeniskebutuhan.SelectedItem.ToString() = "Replacement" Then
                            nikReplacement = If(creplacement.SelectedIndex > 0, creplacement.SelectedValue.ToString(), "")
                            alasanReplacement = If(calasanreplacement.SelectedItem IsNot Nothing, calasanreplacement.SelectedItem.ToString(), "")
                        End If


                        ' ==========================================
                        ' B. SUSUN QUERY BERDASARKAN MODE
                        ' ==========================================
                        If _mode = ModeForm.Tambah Then
                            ' [OPSIONAL AMAN] Generate nomor baru lagi persis sebelum insert
                            ' Untuk mencegah nomor ganda jika 2 user buka form tambah bersamaan
                            tnopermintaan.Text = GenerateNoPermintaan()

                            ' SESUAIKAN: Nama field database Anda
                            sql = "insert into sapermintaankaryawan (ffcnopermintaan,ffdtglpermintaan,ffcnikrequester,ffckddepart,ffckdbagian,ffckdjabatan,ffnjumlah,ffcjnskebutuhan,ffcprioritas,ffcstatuskaryawan,ffdtglbutuh," &
                            "ffcalasan,ffcjustifikasi,ffcstatus,ffcpendidikan,ffcjurusan,ffnpengalaman,ffckompetensi,ffcsertifikasi,ffcdeskripsi,ffctanggungjawab,ffcpersyaratan,ffccatatan,ffcnikreplacement,ffcalasanreplace,ffdcreate) values (@nopermintaan," &
                            "@tglpermintaan,@nikreq,@kddepart,@kdbagian,@kdjabatan,@jumlah,@jnskebutuhan,@prioritas,@statuskaryawan,@tglbutuh,@alasan,@justifikasi,'DRAFT',@pendidikan,@jurusan,@pengalaman,@kompetensi,@sertifkasi,@deskripsi," &
                            "@tanggungjawab,@persyaratan,@catatan,@nikreplace,@alasanreplace,now())"

                        Else
                            ' Mode Edit
                            sql = "update sapermintaankaryawan set ffckdbagian=@kdbagian,ffckdjabatan=@kdjabatan,ffnjumlah=@jumlah,ffcjnskebutuhan=@jnskebutuhan,ffcprioritas=@prioritas,ffcstatuskaryawan=@statuskaryawan,ffdtglbutuh=@tglbutuh," &
                            "ffcalasan =@alasan,ffcjustifikasi=@justifikasi,ffcpendidikan=@pendidikan,ffcjurusan=@jurusan,ffnpengalaman=@pengalaman,ffckompetensi=@kompetensi,ffcsertifikasi=@sertifkasi,ffcdeskripsi=@deskripsi," &
                            "ffctanggungjawab=@tanggungjawab,ffcpersyaratan=@persyaratan,ffccatatan=@catatan,ffcnikreplacement=@nikreplace,ffcalasanreplace=@alasanreplace ,ffdupdate=Now() where ffcidpermintaan=@IdPermintaan And ffcstatus='DRAFT'"

                            cmd.Parameters.AddWithValue("@IdPermintaan", _idPermintaan)
                        End If


                        ' ==========================================
                        ' C. BINDING PARAMETER
                        ' ==========================================
                        cmd.CommandText = sql

                        cmd.Parameters.AddWithValue("@noPermintaan", tnopermintaan.Text)
                        cmd.Parameters.AddWithValue("@tglPermintaan", dtglpermintaan.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@nikreq", trequester.Text)
                        cmd.Parameters.AddWithValue("@kddepart", tdepartmentrequester.Text)
                        cmd.Parameters.AddWithValue("@kdBagian", kdSection)
                        cmd.Parameters.AddWithValue("@kdJabatan", kdJabatan)
                        cmd.Parameters.AddWithValue("@jumlah", njumlah.Value)
                        cmd.Parameters.AddWithValue("@jnskebutuhan", If(cjeniskebutuhan.SelectedItem IsNot Nothing, cjeniskebutuhan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@prioritas", If(cprioritas.SelectedItem IsNot Nothing, cprioritas.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@statusKaryawan", If(cstatuskaryawan.SelectedItem IsNot Nothing, cstatuskaryawan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@tglButuh", dtglkebutuhan.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@alasan", If(calasan.SelectedItem IsNot Nothing, calasan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@justifikasi", tpenjelasan.Text.Trim())
                        cmd.Parameters.AddWithValue("@pendidikan", If(cpendidikan.SelectedItem IsNot Nothing, cpendidikan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@jurusan", If(cjurusan.SelectedItem IsNot Nothing, cjurusan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@pengalaman", npengalaman.Value)
                        cmd.Parameters.AddWithValue("@kompetensi", tkompetensi.Text.Trim())
                        cmd.Parameters.AddWithValue("@sertifkasi", tsertifikat.Text.Trim())
                        cmd.Parameters.AddWithValue("@deskripsi", tdeskripsi.Text.Trim())
                        cmd.Parameters.AddWithValue("@tanggungjawab", ttanggungjawab.Text.Trim())
                        cmd.Parameters.AddWithValue("@persyaratan", tsyaratkhusus.Text.Trim())
                        cmd.Parameters.AddWithValue("@catatan", tcatatan.Text.Trim())
                        cmd.Parameters.AddWithValue("@nikReplace", nikReplacement)
                        cmd.Parameters.AddWithValue("@alasanReplace", alasanReplacement)

                        cmd.ExecuteNonQuery()
                    End Using

                    trans.Commit()
                    PesanPopupSukses("Berhasil", "Draft permintaan karyawan berhasil disimpan.")

                    ' Mengirim sinyal sukses ke uf_permintaankaryawan agar tabel otomatis refresh
                    Me.DialogResult = DialogResult.OK
                    Me.Close()

                Catch ex As MySqlException
                    trans.Rollback()
                    PesanPopupError("Error", "Gagal menghapus no permintaan !!" & vbCrLf & ex.Message)
                Catch ex As Exception
                    trans.Rollback()
                    PesanPopupError("Error", "Terjadi kesalahan !!" & vbCrLf & ex.Message)
                End Try
            End Using
        End Using


    End Sub

    Private Sub bAjukan_Click(sender As Object, e As EventArgs) Handles bAjukan.Click
        ' 1. Cek Validasi Ajukan (Lebih ketat dari Validasi Draft)
        If Not ValidasiAjukan() Then
            Return
        End If

        ' 2. Konfirmasi User
        Dim result As DialogResult = PesanPopupKonfirmasi("Ajukan Permintaan Karyawan", "Apakah Anda yakin ingin mengajukan permintaan karyawan ini untuk proses approval?")
        If result <> DialogResult.Yes Then
            Return
        End If

        ' 3. Proses Database

        Using conn As New MySqlConnection(sambung)
            conn.Open()
            ' Transaksi untuk keamanan data
            Using trans As MySqlTransaction = conn.BeginTransaction()
                Try
                    Dim sql As String = ""
                    Using cmd As New MySqlCommand()
                        cmd.Connection = conn
                        cmd.Transaction = trans

                        ' ==========================================
                        ' A. PERSIAPKAN DATA DARI COMBOBOX
                        ' ==========================================
                        Dim kdSection As String = If(csection.SelectedIndex > 0, csection.SelectedValue.ToString(), "")
                        Dim kdJabatan As String = If(cjabatan.SelectedIndex > 0, cjabatan.SelectedValue.ToString(), "")

                        Dim nikReplacement As String = ""
                        Dim alasanReplacement As String = ""
                        If cjeniskebutuhan.SelectedItem IsNot Nothing AndAlso cjeniskebutuhan.SelectedItem.ToString() = "Replacement" Then
                            nikReplacement = If(creplacement.SelectedIndex > 0, creplacement.SelectedValue.ToString(), "")
                            alasanReplacement = If(calasanreplacement.SelectedItem IsNot Nothing, calasanreplacement.SelectedItem.ToString(), "")
                        End If

                        ' ==========================================
                        ' B. SUSUN QUERY BERDASARKAN MODE
                        ' ==========================================

                        tnopermintaan.Text = GenerateNoPermintaan()

                        ' Mode Tambah: Status langsung ke WAITING_DEPARTMENT
                        sql = "insert into sapermintaankaryawan (ffcnopermintaan,ffdtglpermintaan,ffcnikrequester,ffckddepart,ffckdbagian,ffckdjabatan,ffnjumlah,ffcjnskebutuhan,ffcprioritas,ffcstatuskaryawan,ffdtglbutuh," &
                            "ffcalasan,ffcjustifikasi,ffcstatus,ffcpendidikan,ffcjurusan,ffnpengalaman,ffckompetensi,ffcsertifikasi,ffcdeskripsi,ffctanggungjawab,ffcpersyaratan,ffcnikreplacement,ffcalasanreplace,ffdcreate) values (@nopermintaan," &
                            "@tglpermintaan,@nikreq,@kddepart,@kdbagian,@kdjabatan,@jumlah,@jnskebutuhan,@prioritas,@statuskaryawan,@tglbutuh,@alasan,@justifikasi,'WAITING_DEPARTMENT',@pendidikan,@jurusan,@pengalaman,@kompetensi,@sertifkasi,@deskripsi," &
                            "@tanggungjawab,@persyaratan,@nikreplace,@alasanreplace,now())"


                        ' ==========================================
                        ' C. BINDING PARAMETER
                        ' ==========================================
                        cmd.CommandText = sql

                        cmd.Parameters.AddWithValue("@noPermintaan", tnopermintaan.Text)
                        cmd.Parameters.AddWithValue("@tglPermintaan", dtglpermintaan.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@nikreq", trequester.Text)
                        cmd.Parameters.AddWithValue("@kddepart", tdepartmentrequester.Text)
                        cmd.Parameters.AddWithValue("@kdBagian", kdSection)
                        cmd.Parameters.AddWithValue("@kdJabatan", kdJabatan)
                        cmd.Parameters.AddWithValue("@jumlah", njumlah.Value)
                        cmd.Parameters.AddWithValue("@jnskebutuhan", If(cjeniskebutuhan.SelectedItem IsNot Nothing, cjeniskebutuhan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@prioritas", If(cprioritas.SelectedItem IsNot Nothing, cprioritas.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@statusKaryawan", If(cstatuskaryawan.SelectedItem IsNot Nothing, cstatuskaryawan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@tglButuh", dtglkebutuhan.Value.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@alasan", If(calasan.SelectedItem IsNot Nothing, calasan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@justifikasi", tpenjelasan.Text.Trim())
                        cmd.Parameters.AddWithValue("@pendidikan", If(cpendidikan.SelectedItem IsNot Nothing, cpendidikan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@jurusan", If(cjurusan.SelectedItem IsNot Nothing, cjurusan.SelectedItem.ToString(), ""))
                        cmd.Parameters.AddWithValue("@pengalaman", npengalaman.Value)
                        cmd.Parameters.AddWithValue("@kompetensi", tkompetensi.Text.Trim())
                        cmd.Parameters.AddWithValue("@sertifkasi", tsertifikat.Text.Trim())
                        cmd.Parameters.AddWithValue("@deskripsi", tdeskripsi.Text.Trim())
                        cmd.Parameters.AddWithValue("@tanggungjawab", ttanggungjawab.Text.Trim())
                        cmd.Parameters.AddWithValue("@persyaratan", tsyaratkhusus.Text.Trim())
                        cmd.Parameters.AddWithValue("@nikReplace", nikReplacement)
                        cmd.Parameters.AddWithValue("@alasanReplace", alasanReplacement)
                        cmd.ExecuteNonQuery()
                    End Using

                    trans.Commit()
                    PesanPopupSukses("Berhasil", "Permintaan karyawan berhasil diajukan untuk proses approval.")

                    ' Mengirim sinyal ke uf_permintaankaryawan untuk me-refresh datagrid
                    Me.DialogResult = DialogResult.OK
                    Me.Close()

                Catch ex As MySqlException
                    trans.Rollback()
                    PesanPopupError("Error", "Gagal menghapus no permintaan !!" & vbCrLf & ex.Message)
                Catch ex As Exception
                    trans.Rollback()
                    PesanPopupError("Error", "Terjadi kesalahan !!" & vbCrLf & ex.Message)
                End Try
            End Using
        End Using

    End Sub

    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub

    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()
    End Sub
    Private Sub csection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles csection.SelectedIndexChanged
        ' 2. Pastikan ada item yang dipilih dan nilainya tidak kosong
        If csection.SelectedIndex > 0 AndAlso csection.SelectedValue IsNot Nothing Then

            ' 3. Isi variabel dengan ValueMember dari combobox
            kodeSection = csection.SelectedValue.ToString()

        End If

        ' 4. Panggil fungsi dengan variabel yang sudah disiapkan
        KaryawanReplacement(kodeSection)
    End Sub
End Class