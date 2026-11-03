Imports System.Collections.Generic
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Drawing
Public Class frmKaryawanAdd
    Public Property ModeForm As ModeFormPegawai =
    ModeFormPegawai.Tambah

    Public Property NikPegawai As String = ""
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()

    Private FotoSumberBaru As String = ""
    Private FotoPathDatabase As String = ""
    Private FotoPathLama As String = ""

    Private SedangMemuatKepegawaian As Boolean = False

    Public Class ComboItem

        Public Property Value As String
        Public Property Text As String

        Public Sub New(value As String, text As String)
            Me.Value = value
            Me.Text = text
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function

    End Class
#Region "Function"
    Public Enum ModeFormPegawai
        Tambah
        Edit
        Detail
    End Enum

    Private Function GetPrefix() As String
        Select Case cJenisKelamin.Text.Trim()
            Case "Laki-laki"
                Return "Mr"
            Case "Perempuan"
                Return "Ms"
            Case Else
                Return ""
        End Select
    End Function
    Private Function NilaiString(reader As MySqlDataReader,
                             namaField As String) As String

        If reader.IsDBNull(reader.GetOrdinal(namaField)) Then
            Return ""
        End If

        Return Convert.ToString(reader(namaField)).Trim()

    End Function

    Private Function SiapkanFotoKaryawan() As String

        ' Tidak ada foto baru yang dipilih.
        If String.IsNullOrWhiteSpace(FotoSumberBaru) Then
            Return FotoPathDatabase
        End If

        If String.IsNullOrWhiteSpace(tNik.Text) Then
            Throw New Exception("NIK karyawan belum tersedia.")
        End If

        ' Salin foto ke folder karyawan.
        Dim relativePath As String = SalinFileKeKaryawan(FotoSumberBaru, tNik.Text.Trim(), "Foto")

        Return relativePath

    End Function

    Private Function GetComboValue(combo As Guna.UI2.WinForms.Guna2ComboBox) As String

        If combo.SelectedItem Is Nothing Then
            Return ""
        End If

        Dim item As ComboItem =
        TryCast(combo.SelectedItem, ComboItem)

        If item Is Nothing Then
            Return ""
        End If

        Return item.Value

    End Function
    Private Function FormatNominalPayroll(nilai As String) As String

        If String.IsNullOrWhiteSpace(nilai) Then
            Return "0"
        End If

        Dim angka As Decimal

        Dim budayaIndonesia As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        Dim budayaInvariant As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

        If Decimal.TryParse(nilai.Trim(), Globalization.NumberStyles.Any, budayaInvariant, angka) Then
            Return angka.ToString("N0", budayaIndonesia)
        ElseIf Decimal.TryParse(nilai.Trim(), Globalization.NumberStyles.Any, budayaIndonesia, angka) Then
            Return angka.ToString("N0", budayaIndonesia)
        End If
        Return "0"

    End Function

#End Region
#Region "Private"
    Private Sub LoadDataPegawai()

        If String.IsNullOrWhiteSpace(NikPegawai) Then
            PesanPopupPeringatan("Peringatan", "NIK karyawan belum ditentukan.")
            Return
        End If

        Dim ditemukan As Boolean = False

        'Variabel data pribadi
        Dim nik As String = ""
        Dim prefix As String = ""
        Dim namaDepan As String = ""
        Dim namaTengah As String = ""
        Dim namaBelakang As String = ""
        Dim namaLengkap As String = ""
        Dim namaPanggilan As String = ""
        Dim tempatLahir As String = ""
        Dim jenisKelamin As String = ""
        Dim agama As String = ""
        Dim statusPernikahan As String = ""
        Dim golonganDarah As String = ""
        Dim kewarganegaraan As String = ""
        Dim ktp As String = ""
        Dim kartuKeluarga As String = ""
        Dim npwp As String = ""
        Dim nomorTelp As String = ""
        Dim email As String = ""

        Dim tanggalLahir As Date? = Nothing

        'Variabel foto dan alamat
        Dim foto As String = ""
        Dim alamatKTP As String = ""
        Dim domisili As String = ""

        'Variabel kepegawaian
        Dim kodeDepartemen As String = ""
        Dim kodeBagian As String = ""
        Dim kodeJabatan As String = ""
        Dim jenisKaryawan As String = ""
        Dim hariKerja As String = ""
        Dim shiftKerja As String = ""

        Dim tanggalMasuk As Date? = Nothing
        Dim tanggalTetap As Date? = Nothing

        Try

            Dim sql As String = "SELECT ffcnik, ffcprefix, ffcfname, ffcmname, ffclname, ffcnama, ffcnick, ffclahir, ffdlahir, ffcsex, ffcagama, ffcstatuskawin, ffcdarah, " &
            "ffckewarganegaraan, ffcktp, ffckk, ffcnpwp, ffctelp, ffcemail, ffcfilefoto, ffcalamatktp, ffcdomisili, ffcdepart, ffcbagian, ffcjabatan, ffcstatuspeg, " &
            "ffdmasuk, ffdstatuspeg, ffcsisker, ffcshift FROM sajatidiri WHERE ffcnik = @nik LIMIT 1"

            Using conn As New MySqlConnection(sambung)
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nik", NikPegawai)
                    conn.Open()
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            ditemukan = True

                            '====================================
                            ' DATA PRIBADI
                            '====================================

                            nik = NilaiString(rd, "ffcnik")
                            prefix = NilaiString(rd, "ffcprefix")

                            namaDepan = NilaiString(rd, "ffcfname")
                            namaTengah = NilaiString(rd, "ffcmname")
                            namaBelakang = NilaiString(rd, "ffclname")
                            namaLengkap = NilaiString(rd, "ffcnama")
                            namaPanggilan = NilaiString(rd, "ffcnick")

                            tempatLahir = NilaiString(rd, "ffclahir")

                            If Not rd.IsDBNull(rd.GetOrdinal("ffdlahir")) Then
                                tanggalLahir = Convert.ToDateTime(rd("ffdlahir"))
                            End If

                            jenisKelamin = NilaiString(rd, "ffcsex")
                            agama = NilaiString(rd, "ffcagama")

                            statusPernikahan = NilaiString(rd, "ffcstatuskawin")
                            golonganDarah = NilaiString(rd, "ffcdarah")
                            kewarganegaraan = NilaiString(rd, "ffckewarganegaraan")

                            ktp = NilaiString(rd, "ffcktp")
                            kartuKeluarga = NilaiString(rd, "ffckk")
                            npwp = NilaiString(rd, "ffcnpwp")

                            nomorTelp = NilaiString(rd, "ffctelp")
                            email = NilaiString(rd, "ffcemail")

                            '====================================
                            ' FOTO DAN ALAMAT
                            '====================================

                            foto = NilaiString(rd, "ffcfilefoto")

                            alamatKTP = NilaiString(rd, "ffcalamatktp")
                            domisili = NilaiString(rd, "ffcdomisili")

                            '====================================
                            ' DATA KEPEGAWAIAN
                            '====================================

                            kodeDepartemen = NilaiString(rd, "ffcdepart")
                            kodeBagian = NilaiString(rd, "ffcbagian")
                            kodeJabatan = NilaiString(rd, "ffcjabatan")

                            jenisKaryawan = NilaiString(rd, "ffcstatuspeg")

                            hariKerja = NilaiString(rd, "ffcsisker")
                            shiftKerja = NilaiString(rd, "ffcshift")

                            If Not rd.IsDBNull(rd.GetOrdinal("ffdmasuk")) Then
                                tanggalMasuk = Convert.ToDateTime(rd("ffdmasuk"))
                            End If

                            If Not rd.IsDBNull(rd.GetOrdinal("ffdstatuspeg")) Then
                                tanggalTetap = Convert.ToDateTime(rd("ffdstatuspeg"))
                            End If

                        End If

                    End Using

                End Using

            End Using

            '============================================
            ' VALIDASI DATA
            '============================================

            If Not ditemukan Then
                PesanPopupPeringatan("Peringatan", "Data karyawan tidak ditemukan.")
                Return
            End If

            '============================================
            ' TAMPILKAN DATA PRIBADI
            '============================================

            tNik.Text = nik

            tNamaDepan.Text = namaDepan
            tNamaTengah.Text = namaTengah
            tNamaBelakang.Text = namaBelakang
            tNamaPanggilan.Text = namaPanggilan
            tNamaLengkap.Text = namaLengkap

            tTempatLahir.Text = tempatLahir

            If tanggalLahir.HasValue Then
                dtTglLahir.Value = tanggalLahir.Value
                dtTglLahir.Checked = True
            Else
                dtTglLahir.Checked = False
            End If

            Select Case jenisKelamin.Trim().ToUpper()
                Case "L", "M", "LAKI-LAKI"
                    PilihCombo(cJenisKelamin, "Laki-laki")

                Case "P", "F", "PEREMPUAN"
                    PilihCombo(cJenisKelamin, "Perempuan")

                Case Else
                    cJenisKelamin.SelectedIndex = -1
            End Select

            tAgama.Text = agama

            PilihCombo(cStatusPernikahan, statusPernikahan)
            PilihCombo(cGolonganDarah, golonganDarah)
            PilihCombo(cKewarganegaraan, kewarganegaraan)

            tKtp.Text = ktp
            tKartuKeluarga.Text = kartuKeluarga
            tNpwp.Text = npwp

            tNomorTelp.Text = nomorTelp
            tEmail.Text = email

            '============================================
            ' TAMPILKAN FOTO
            '============================================

            FotoPathLama = foto
            FotoPathDatabase = foto

            TampilkanFoto(FotoPathDatabase)

            '============================================
            ' TAMPILKAN ALAMAT
            '============================================

            tAlamatKTP.Text = alamatKTP
            tDomisili.Text = domisili

            'Checkbox tidak otomatis dicentang.
            'Karena alamat KTP dan domisili bisa berbeda.
            chkAlamat.Checked = False
            tDomisili.ReadOnly = False

            '============================================
            ' TAMPILKAN DATA KEPEGAWAIAN
            '============================================

            SedangMemuatKepegawaian = True

            Try

                'Pilih departemen
                PilihComboBerdasarkanValue(cDepartment, kodeDepartemen)

                'Muat bagian sesuai departemen
                LoadBagian(kodeDepartemen)

                'Pilih bagian
                PilihComboBerdasarkanValue(cBagian, kodeBagian)

                'Muat seluruh jabatan
                'Dilakukan setelah LoadBagian karena LoadBagian
                'mengosongkan ComboBox Jabatan.
                LoadJabatan()

                'Pilih jabatan
                PilihComboBerdasarkanValue(cJabatan, kodeJabatan)

                'Jenis karyawan
                PilihCombo(cJenisKaryawan, jenisKaryawan)

                'Tanggal masuk
                If tanggalMasuk.HasValue Then
                    dtTanggalMasuk.Value = tanggalMasuk.Value
                    dtTanggalMasuk.Checked = True
                Else
                    dtTanggalMasuk.Checked = False
                End If

                'Tanggal pengangkatan tetap
                If tanggalTetap.HasValue Then
                    dtTanggalTetap.Value = tanggalTetap.Value
                    dtTanggalTetap.Checked = True
                Else
                    dtTanggalTetap.Checked = False
                End If

                'Hari kerja
                PilihComboBerdasarkanValue(cKerja, hariKerja)

                'Shift
                PilihComboBerdasarkanValue(cShift, shiftKerja)

            Finally

                SedangMemuatKepegawaian = False

            End Try

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal mengambil data karyawan: " & ex.Message)

        End Try

    End Sub
    Private Sub LoadDataPayroll()

        If String.IsNullOrWhiteSpace(NikPegawai) Then
            PesanPopupPeringatan("Peringatan", "NIK karyawan belum ditentukan.")
            Return
        End If

        Try

            Dim sql As String = "SELECT ffcgp, ffctunjabat, ffctunlain, ffntrans, ffnmakan, ffnspsi, ffnjamsostek, ffnkesehatan " &
            "FROM sajatidiri_detil1 WHERE ffcnik = @nik LIMIT 1"

            Using conn As New MySqlConnection(sambung)
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nik", NikPegawai)
                    conn.Open()
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            tGajiPokok.Text = FormatNominalPayroll(NilaiString(rd, "ffcgp"))
                            tTunjanganTetap.Text = FormatNominalPayroll(NilaiString(rd, "ffctunjabat"))
                            tTunjanganLain.Text = FormatNominalPayroll(NilaiString(rd, "ffctunlain"))
                            tTransport.Text = FormatNominalPayroll(NilaiString(rd, "ffntrans"))
                            tUangMakan.Text = FormatNominalPayroll(NilaiString(rd, "ffnmakan"))
                            tSpsi.Text = FormatNominalPayroll(NilaiString(rd, "ffnspsi"))
                            tJamsostek.Text = FormatNominalPayroll(NilaiString(rd, "ffnjamsostek"))
                            tKesehatan.Text = FormatNominalPayroll(NilaiString(rd, "ffnkesehatan"))
                        Else
                            KosongkanDataPayroll()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal mengambil data Payroll: " & ex.Message)
        End Try

    End Sub
    Private Sub KosongkanDataPayroll()

        tGajiPokok.Text = "0"
        tTunjanganTetap.Text = "0"
        tTunjanganLain.Text = "0"
        tTransport.Text = "0"
        tUangMakan.Text = "0"
        tSpsi.Text = "0"
        tJamsostek.Text = "0"
        tKesehatan.Text = "0"

    End Sub

    Private Sub LoadDepartemen()

        Try
            cDepartment.Items.Clear()
            Using conn As New MySqlConnection(sambung)
                Dim sql As String = "SELECT ffckode, ffcnama FROM sadepartment ORDER BY ffcnama"
                Using cmd As New MySqlCommand(sql, conn)
                    conn.Open()
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            cDepartment.Items.Add(New ComboItem(rd("ffckode").ToString().Trim(), rd("ffcnama").ToString().Trim()))

                        End While
                    End Using
                End Using
            End Using
            cDepartment.SelectedIndex = -1
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat departemen: " & ex.Message)
        End Try

    End Sub
    Private Sub LoadBagian(kodeDepartemen As String)

        cBagian.Items.Clear()
        cBagian.SelectedIndex = -1

        cJabatan.Items.Clear()
        cJabatan.SelectedIndex = -1

        If String.IsNullOrWhiteSpace(kodeDepartemen) Then
            Return
        End If

        Try

            Using conn As New MySqlConnection(sambung)

                Dim sql As String = "SELECT ffcbag, ffcnama FROM sabagian WHERE LEFT(TRIM(ffcbag), 1) = @departemen ORDER BY ffcbag"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@departemen", kodeDepartemen)

                    conn.Open()

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        While rd.Read()

                            cBagian.Items.Add(New ComboItem(rd("ffcbag").ToString().Trim(), rd("ffcbag").ToString().Trim() &
                                " - " & rd("ffcnama").ToString().Trim()))

                        End While

                    End Using
                End Using
            End Using

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memuat bagian: " & ex.Message)

        End Try

    End Sub
    Private Sub LoadJabatan()

        Try

            cJabatan.Items.Clear()
            cJabatan.SelectedIndex = -1
            Using conn As New MySqlConnection(sambung)
                Dim sql As String = "SELECT ffckls, ffcnama FROM sajabatan ORDER BY ffckls"
                Using cmd As New MySqlCommand(sql, conn)
                    conn.Open()
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            cJabatan.Items.Add(New ComboItem(rd("ffckls").ToString().Trim(), rd("ffckls").ToString().Trim() &
                                " - " & rd("ffcnama").ToString().Trim()))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat jabatan: " & ex.Message)
        End Try

    End Sub
    Private Sub ResetDataPribadi()

        tNik.Clear()

        tNamaDepan.Clear()
        tNamaTengah.Clear()
        tNamaBelakang.Clear()
        tNamaPanggilan.Clear()
        tNamaLengkap.Clear()

        tTempatLahir.Clear()
        tAgama.Clear()

        cJenisKelamin.SelectedIndex = -1
        cStatusPernikahan.SelectedIndex = -1
        cGolonganDarah.SelectedIndex = -1
        cKewarganegaraan.SelectedIndex = -1
        cPtkp.SelectedIndex = -1

        tKtp.Clear()
        tKartuKeluarga.Clear()
        tNpwp.Clear()

        tNomorTelp.Clear()
        tEmail.Clear()

        ' Tanggal lahir belum dipilih
        dtTglLahir.ShowCheckBox = True
        dtTglLahir.Checked = False

        tNamaLengkap.ReadOnly = True
        FotoSumberBaru = ""
        FotoPathDatabase = ""
        FotoPathLama = ""

        If pbFoto.Image IsNot Nothing Then
            pbFoto.Image.Dispose()
            pbFoto.Image = Nothing
        End If
        UpdateNamaLengkap()

    End Sub
    Private Sub ResetAlamat()

        chkAlamat.Checked = False

        tAlamatKTP.Clear()
        tDomisili.Clear()

        tDomisili.ReadOnly = False

    End Sub

    Private Sub ResetKepegawaian()

        SedangMemuatKepegawaian = True

        cDepartment.SelectedIndex = -1
        cBagian.Items.Clear()
        cBagian.SelectedIndex = -1

        cJabatan.SelectedIndex = -1
        cJenisKaryawan.SelectedIndex = -1
        cKerja.SelectedIndex = -1
        cShift.SelectedIndex = -1

        dtTanggalMasuk.Checked = False
        dtTanggalTetap.Checked = False

        SedangMemuatKepegawaian = False

    End Sub
    Private Sub InisialisasiComboBox()

        ' Jenis Kelamin
        cJenisKelamin.Items.Clear()
        cJenisKelamin.Items.Add("Laki-laki")
        cJenisKelamin.Items.Add("Perempuan")

        ' Status Pernikahan
        cStatusPernikahan.Items.Clear()
        cStatusPernikahan.Items.Add("Belum Menikah")
        cStatusPernikahan.Items.Add("Menikah")
        cStatusPernikahan.Items.Add("Cerai Hidup")
        cStatusPernikahan.Items.Add("Cerai Mati")

        ' Golongan Darah
        cGolonganDarah.Items.Clear()
        cGolonganDarah.Items.Add("A")
        cGolonganDarah.Items.Add("B")
        cGolonganDarah.Items.Add("AB")
        cGolonganDarah.Items.Add("O")

        ' Kewarganegaraan
        cKewarganegaraan.Items.Clear()
        cKewarganegaraan.Items.Add("WNI")
        cKewarganegaraan.Items.Add("WNA")

        ' PTKP
        cPtkp.Items.Clear()
        cPtkp.Items.Add("TK/0")
        cPtkp.Items.Add("TK/1")
        cPtkp.Items.Add("TK/2")
        cPtkp.Items.Add("TK/3")
        cPtkp.Items.Add("K/0")
        cPtkp.Items.Add("K/1")
        cPtkp.Items.Add("K/2")
        cPtkp.Items.Add("K/3")
        cPtkp.Items.Add("K/I/0")
        cPtkp.Items.Add("K/I/1")
        cPtkp.Items.Add("K/I/2")
        cPtkp.Items.Add("K/I/3")

        ' Semua ComboBox menggunakan pilihan dari daftar
        cJenisKelamin.DropDownStyle = ComboBoxStyle.DropDownList
        cStatusPernikahan.DropDownStyle = ComboBoxStyle.DropDownList
        cGolonganDarah.DropDownStyle = ComboBoxStyle.DropDownList
        cKewarganegaraan.DropDownStyle = ComboBoxStyle.DropDownList
        cPtkp.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub
    Private Sub InisialisasiKepegawaian()

        ' Jenis Karyawan
        cJenisKaryawan.Items.Clear()
        cJenisKaryawan.Items.Add("Kontrak")
        cJenisKaryawan.Items.Add("Permanent")
        cJenisKaryawan.Items.Add("Internship")

        ' Hari Kerja
        cKerja.Items.Clear()
        cKerja.Items.Add("5 Hari Kerja")
        cKerja.Items.Add("6 Hari Kerja")

        ' Departemen, Bagian, Jabatan, dan Shift
        ' Akan diisi dari master database.

        cDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cBagian.DropDownStyle = ComboBoxStyle.DropDownList
        cJabatan.DropDownStyle = ComboBoxStyle.DropDownList

        cJenisKaryawan.DropDownStyle = ComboBoxStyle.DropDownList

        cKerja.DropDownStyle = ComboBoxStyle.DropDownList

        cShift.DropDownStyle = ComboBoxStyle.DropDownList
        SedangMemuatKepegawaian = True
        LoadDepartemen()
        LoadJabatan()
        InisialisasiShiftHariKerja()
        SedangMemuatKepegawaian = False

        cDepartment.SelectedIndex = -1
        cBagian.SelectedIndex = -1
        cJabatan.SelectedIndex = -1
        cJenisKaryawan.SelectedIndex = -1
        cKerja.SelectedIndex = -1
        cShift.SelectedIndex = -1

        dtTanggalMasuk.ShowCheckBox = True
        dtTanggalMasuk.Checked = False

        dtTanggalTetap.ShowCheckBox = True
        dtTanggalTetap.Checked = False

    End Sub
    Private Sub InisialisasiShiftHariKerja()

        ' Shift
        cShift.Items.Clear()

        cShift.Items.Add(New ComboItem("Non Shift", "Non Shift"))
        cShift.Items.Add(New ComboItem("Shift", "Shift"))

        ' Hari Kerja
        cKerja.Items.Clear()

        cKerja.Items.Add(New ComboItem("5", "5 Hari Kerja"))

        cKerja.Items.Add(New ComboItem("6", "6 Hari Kerja"))

        cShift.SelectedIndex = -1
        cKerja.SelectedIndex = -1

    End Sub
    Private Sub UpdateNamaLengkap()

        Dim bagianNama As New List(Of String)

        If Not String.IsNullOrWhiteSpace(tNamaDepan.Text) Then
            bagianNama.Add(tNamaDepan.Text.Trim())
        End If

        If Not String.IsNullOrWhiteSpace(tNamaTengah.Text) Then
            bagianNama.Add(tNamaTengah.Text.Trim())
        End If

        If Not String.IsNullOrWhiteSpace(tNamaBelakang.Text) Then
            bagianNama.Add(tNamaBelakang.Text.Trim())
        End If
        tNamaLengkap.Text = String.Join(" ", bagianNama)
    End Sub
    Private Sub AturModeForm()

        Select Case ModeForm

            Case ModeFormPegawai.Tambah

                Me.Text = "Tambah Data Karyawan"

                bSimpan.Visible = True
                bSimpan.Enabled = True

                bBatal.Visible = True
                bBatal.Enabled = True

                bTutup.Visible = False
                bPilihFoto.Enabled = True
            Case ModeFormPegawai.Edit

                Me.Text = "Edit Data Karyawan"

                bSimpan.Visible = True
                bSimpan.Enabled = True

                bBatal.Visible = True
                bBatal.Enabled = True

                bTutup.Visible = False
                bPilihFoto.Enabled = False
            Case ModeFormPegawai.Detail

                Me.Text = "Detail Data Karyawan"

                bSimpan.Visible = False
                bBatal.Visible = False

                bTutup.Visible = True
                bTutup.Enabled = True
                bPilihFoto.Enabled = False
        End Select

    End Sub
    Private Sub PilihComboBerdasarkanValue(combo As Guna.UI2.WinForms.Guna2ComboBox, nilai As String)

        combo.SelectedIndex = -1

        If String.IsNullOrWhiteSpace(nilai) Then Return

        For i As Integer = 0 To combo.Items.Count - 1

            Dim item As ComboItem =
            TryCast(combo.Items(i), ComboItem)

            If item IsNot Nothing AndAlso
           item.Value.Trim().Equals(nilai.Trim(), StringComparison.OrdinalIgnoreCase) Then
                combo.SelectedIndex = i
                Exit For

            End If

        Next

    End Sub
    Private Sub PilihCombo(combo As Guna.UI2.WinForms.Guna2ComboBox, nilai As String)

        If String.IsNullOrWhiteSpace(nilai) Then
            combo.SelectedIndex = -1
            Return
        End If

        Dim index As Integer = combo.FindStringExact(nilai.Trim())

        If index >= 0 Then
            combo.SelectedIndex = index
        Else
            combo.SelectedIndex = -1
        End If

    End Sub
    Private Sub TampilkanFoto(relativePath As String)

        If pbFoto.Image IsNot Nothing Then
            pbFoto.Image.Dispose()
            pbFoto.Image = Nothing
        End If

        If String.IsNullOrWhiteSpace(relativePath) Then
            Return
        End If

        Try
            Dim fullPath As String =
            GetFullFilePathKaryawan(relativePath)

            If Not File.Exists(fullPath) Then
                Return
            End If

            ' Membuat salinan gambar agar file tidak terkunci.
            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read)
                Using img As Image = Image.FromStream(fs)
                    pbFoto.Image = New Bitmap(img)
                End Using
            End Using

            FotoPathDatabase = relativePath

        Catch ex As Exception
            PesanPopupPeringatan("Peringatan", "Foto karyawan tidak dapat ditampilkan: " & ex.Message)
        End Try

    End Sub
    Private Sub PilihFotoKaryawan()

        Using dialog As New OpenFileDialog()

            dialog.Title = "Pilih Foto Karyawan"
            dialog.Filter =
            "File Gambar|*.jpg;*.jpeg;*.png;*.bmp"

            dialog.Multiselect = False

            If dialog.ShowDialog() <> DialogResult.OK Then
                Return
            End If

            Try
                ' Validasi bahwa file benar-benar dapat dibaca sebagai gambar.
                Using fs As New FileStream(
                dialog.FileName, FileMode.Open, FileAccess.Read)

                    Using img As Image = Image.FromStream(fs)

                        If pbFoto.Image IsNot Nothing Then
                            pbFoto.Image.Dispose()
                        End If

                        pbFoto.Image = New Bitmap(img)

                    End Using

                End Using

                ' Simpan lokasi sumber sementara.
                FotoSumberBaru = dialog.FileName

            Catch ex As Exception
                PesanPopupError("ERROR", "Gagal membaca foto: " & ex.Message)
            End Try

        End Using

    End Sub
#End Region
    Private Sub chkAlamat_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlamat.CheckedChanged

        If chkAlamat.Checked Then

            tDomisili.Text = tAlamatKTP.Text
            tDomisili.ReadOnly = True

        Else

            tDomisili.ReadOnly = False

        End If

    End Sub
    Private Sub tAlamatKtp_TextChanged(sender As Object, e As EventArgs) Handles tAlamatKTP.TextChanged
        If chkAlamat.Checked Then
            tDomisili.Text = tAlamatKTP.Text
        End If

    End Sub
    Private Sub NamaField_TextChanged(sender As Object, e As EventArgs) Handles _
        tNamaDepan.TextChanged, tNamaTengah.TextChanged, tNamaBelakang.TextChanged, cJenisKelamin.SelectedIndexChanged
        Select Case ModeForm
            Case ModeFormPegawai.Tambah
                UpdateNamaLengkap()
        End Select

    End Sub
    Private Sub frmKaryawanAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShadowForm.SetShadowForm(Me)

        InisialisasiComboBox()
        InisialisasiKepegawaian()

        Select Case ModeForm

            Case ModeFormPegawai.Tambah

                ResetDataPribadi()
                ResetAlamat()
                ResetKepegawaian()

            Case ModeFormPegawai.Edit,
                 ModeFormPegawai.Detail

                LoadDataPegawai()
                LoadDataPayroll()
        End Select

        AturModeForm()

    End Sub
    Private Sub bTutup_Click(sender As Object, e As EventArgs) Handles bTutup.Click
        Me.Close()
    End Sub
    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub
    Private Sub bPilihFoto_Click(sender As Object, e As EventArgs) Handles bPilihFoto.Click
        PilihFotoKaryawan()
    End Sub
    Private Sub cDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cDepartment.SelectedIndexChanged
        If SedangMemuatKepegawaian Then Return

        Dim kodeDepartemen As String =
        GetComboValue(cDepartment)

        LoadBagian(kodeDepartemen)
    End Sub
    Private Sub cBagian_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBagian.SelectedIndexChanged
        If SedangMemuatKepegawaian Then Return

        cJabatan.Items.Clear()
        cJabatan.SelectedIndex = -1

        If cBagian.SelectedIndex >= 0 Then
            LoadJabatan()
        End If
    End Sub
End Class