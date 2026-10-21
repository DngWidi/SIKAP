
Imports MySql.Data.MySqlClient
Imports System.Data
Public Class frmCalonPegawai
    'ID record calon pegawai dari uf_calonpegawai
    Public Property IdCalonPegawai As Long
    'Mode tampilan form
    Public Property ModeProses As Boolean = False

    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
    Private _status As String = ""
#Region "Private"
    Private Sub LoadDepartment()
        Using conn As New MySqlConnection(sambung)
            conn.Open()

            Dim sql As String = "SELECT ffckode, ffcnama FROM sadepartment ORDER BY ffcnama"

            Using cmd As New MySqlCommand(sql, conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    cDepartment.DataSource = Nothing
                    cDepartment.DisplayMember = "ffcnama"
                    cDepartment.ValueMember = "ffckode"
                    cDepartment.DataSource = dt
                    cDepartment.SelectedIndex = -1
                End Using
            End Using
        End Using

    End Sub
    Private Sub LoadBagian()
        Using conn As New MySqlConnection(sambung)
            conn.Open()

            Dim sql As String = "SELECT ffcbag, ffcnama FROM sabagian ORDER BY ffcnama"

            Using cmd As New MySqlCommand(sql, conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    cBagian.DataSource = Nothing
                    cBagian.DisplayMember = "ffcnama"
                    cBagian.ValueMember = "ffcbag"
                    cBagian.DataSource = dt
                    cBagian.SelectedIndex = -1
                End Using
            End Using
        End Using

    End Sub
    Private Sub LoadJabatan()
        Using conn As New MySqlConnection(sambung)
            conn.Open()

            Dim sql As String = "SELECT ffckls, ffcnama FROM sajabatan ORDER BY ffcnama"

            Using cmd As New MySqlCommand(sql, conn)
                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    cJabatan.DataSource = Nothing
                    cJabatan.DisplayMember = "ffcnama"
                    cJabatan.ValueMember = "ffckls"
                    cJabatan.DataSource = dt
                    cJabatan.SelectedIndex = -1
                End Using
            End Using
        End Using

    End Sub
#End Region
    Private Sub frmCalonPegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AturComboBox()
        AturPenghasilanReadOnly()
        If IdCalonPegawai <= 0 Then
            MessageBox.Show("ID calon pegawai tidak valid.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If
        LoadBagian()
        LoadJabatan()
        LoadDepartment()
        LoadDataCalonPegawai()
        AturModeForm()
        ShadowForm.SetShadowForm(Me)
    End Sub
    Private Sub AturModeForm()
        If ModeProses Then

            'MODE PROSES
            bSimpan.Visible = True
            bSimpan.Enabled = True
            bTandai.Visible = True
            bTandai.Enabled = True

            bBatal.Visible = True
            bBatal.Enabled = True

            'Field yang boleh diedit akan diatur di sini
        Else

            'MODE DETAIL: hanya untuk melihat data
            bSimpan.Visible = False
            bSimpan.Enabled = False

            bTandai.Visible = False
            bTandai.Enabled = False

            bBatal.Visible = True
            bBatal.Enabled = True

            'Field tidak boleh diedit
            KunciSemuaField()

        End If

        'Penghasilan dari Offering selalu terkunci
        AturPenghasilanReadOnly()

    End Sub
    Private Sub KunciSemuaField()

        'Data pribadi
        tNik.ReadOnly = True
        tNamaLengkap.ReadOnly = True
        tTempatLahir.ReadOnly = True
        tNpwp.ReadOnly = True
        tNomorTelp.ReadOnly = True
        tEmail.ReadOnly = True
        tKeterangan.ReadOnly = True

        'Pendidikan
        cPendidikan.Enabled = False
        tSekolah.ReadOnly = True
        tJurusan.ReadOnly = True
        nTahunLulus.Enabled = False

        'Alamat
        tAlamatKtp.ReadOnly = True
        tAlamatDomisili.ReadOnly = True

        'Penempatan
        tNomorIndukPegawai.ReadOnly = True
        cDepartment.Enabled = False
        cBagian.Enabled = False
        cJabatan.Enabled = False
        cJenis.Enabled = False
        tLokasi.ReadOnly = True
        dTglkerja.Enabled = False

        'ComboBox data pribadi
        cStatusNikah.Enabled = False
        cKelamin.Enabled = False


        'Status calon pegawai
        cCalon.Enabled = False

        'Tanggal lahir
        dTglLahir.Enabled = False

    End Sub
    Private Sub AturComboBox()

        cStatusNikah.Items.Clear()
        cStatusNikah.Items.AddRange(New Object() {"Belum Menikah", "Kawin", "Cerai"})

        cKelamin.Items.Clear()
        cKelamin.Items.AddRange(New Object() {"Laki-laki", "Perempuan"})


        cPendidikan.Items.Clear()
        cPendidikan.Items.AddRange(New Object() {"SD", "SMP", "SMA/SMK", "D1", "D2", "D3", "D4", "S1", "S2", "S3"})

        cCalon.Items.Clear()
        cCalon.Items.AddRange(New Object() {"CALON_PEGAWAI", "DATA_LENGKAP", "SIAP_MENJADI_PEGAWAI", "MENJADI_PEGAWAI", "BATAL"})

    End Sub
    Private Sub AturPenghasilanReadOnly()

        tGp.ReadOnly = True
        tTunjanganTetap.ReadOnly = True
        tTunjanganLain.ReadOnly = True
        tTunjanganTransport.ReadOnly = True
        tTunjanganMakan.ReadOnly = True
        tMasaCoba.ReadOnly = True

        tNomorIndukPegawai.ReadOnly = True
        tLokasi.ReadOnly = True

    End Sub
    Private Sub LoadDataCalonPegawai()

        Try
            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT cp.ffcidcalonpegawai, cp.ffcidkandidat, cp.ffcidrekrutmen,cp.ffcidoffering, cp.ffcktp, cp.ffcnik, cp.ffcstatus AS status_calon, cp.ffdmulai," &
                    "cp.ffdbergabung,cp.ffcjabatan AS kode_jabatan,b.ffcnama AS Nama_Jabatan, cp.ffcdepartemen AS kode_departemen,c.ffcnama AS Nama_Department, cp.ffcbagian AS kode_bagian,d.ffcnama AS Nama_Bagian, " &
                    "cp.ffcjeniskaryawan,cp.ffctempatkerja,k.ffcnokandidat, k.ffcnama, k.ffctempatlahir,k.ffcagama, k.ffdtgllahir, k.ffcjeniskelamin, k.ffcstatuspernikahan, " &
                    "k.ffcnik AS ktp_kandidat, k.ffcnpwp, k.ffcnotelp, k.ffcemail,k.ffcalamat,k.ffcdomisili, k.ffckelurahan, k.ffckecamatan, k.ffckota, k.ffcprovinsi, k.ffckodepos,k.ffcsumberkandidat, k.ffcketerangan, o.ffcnopenawaran, " &
                    "o.ffdpenawaran, o.ffngajipokok, o.ffntunjangantetap, o.ffntunjanganlain, o.ffntransport, o.ffnmakan,o.ffcmassapercobaan,e.ffctingkat  ,e.ffcnamainstitusi ,e.ffcjurusan ,e.ffctahunlulus FROM sacalonpegawai cp INNER JOIN sakandidat k ON k.ffcidkandidat = cp.ffcidkandidat " &
                    "INNER JOIN sapenawarankerja o ON o.ffcidoffering = cp.ffcidoffering LEFT JOIN sajabatan b ON cp.ffcjabatan = b.ffckls LEFT JOIN sadepartment c ON cp.ffcdepartemen = c.ffckode " &
                    "LEFT JOIN sabagian d ON cp.ffcbagian = d.ffcbag LEFT JOIN sakandidatpendidikan e ON cp.ffcidkandidat = e.ffcidkandidat  WHERE cp.ffcidcalonpegawai = @id LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@id", IdCalonPegawai)

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If Not rd.Read() Then
                            MessageBox.Show("Data calon pegawai tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return
                        End If

                        '------------------------------------
                        ' HEADER / RINGKASAN
                        '------------------------------------
                        lNoKandidat.Text = Teks(rd("ffcnokandidat"))
                        lNamaKandidat.Text = Teks(rd("ffcnama"))
                        lNoOffering.Text = Teks(rd("ffcnopenawaran"))

                        _status = Teks(rd("status_calon"))
                        lStatusKandidat.Text = _status
                        cCalon.Text = _status

                        lTglKerja.Text = FormatTanggal(rd("ffdmulai"))

                        '------------------------------------
                        ' DATA PRIBADI
                        '------------------------------------
                        tNik.Text = Teks(rd("ktp_kandidat"))
                        tNamaLengkap.Text = Teks(rd("ffcnama"))
                        tTempatLahir.Text = Teks(rd("ffctempatlahir"))
                        tNpwp.Text = Teks(rd("ffcnpwp"))
                        tNomorTelp.Text = Teks(rd("ffcnotelp"))
                        tEmail.Text = Teks(rd("ffcemail"))
                        tAgama.Text = Teks(rd("ffcagama"))
                        tKeterangan.Text = Teks(rd("ffcketerangan"))

                        PilihCombo(cKelamin, Teks(rd("ffcjeniskelamin")))

                        PilihCombo(cStatusNikah, Teks(rd("ffcstatuspernikahan")))
                        PilihCombo(cPendidikan, rd("ffctingkat"))
                        tSekolah.Text = Teks(rd("ffcnamainstitusi"))
                        tJurusan.Text = Teks(rd("ffcjurusan"))
                        nTahunLulus.Value = If(IsDBNull(rd("ffctahunlulus")), 0, Convert.ToInt32(rd("ffctahunlulus")))
                        If Not IsDBNull(rd("ffdtgllahir")) Then
                            dTglLahir.Value = Convert.ToDateTime(rd("ffdtgllahir"))
                        End If

                        '------------------------------------
                        ' ALAMAT
                        '------------------------------------
                        tAlamatKtp.Text = Teks(rd("ffcalamat"))
                        tAlamatDomisili.Text = Teks(rd("ffcdomisili"))
                        'Alamat domisili belum tersedia di
                        'schema sakandidat yang kita ketahui.

                        '------------------------------------
                        ' DATA KEPEGAWAIAN
                        '------------------------------------
                        tNomorIndukPegawai.Text = Teks(rd("ffcnik"))

                        tLokasi.Text = Teks(rd("ffctempatkerja"))

                        If Not IsDBNull(rd("ffdmulai")) Then
                            dTglkerja.Value =
                                Convert.ToDateTime(rd("ffdmulai"))
                        End If

                        'Kode organisasi ditampilkan sementara
                        'sampai master lookup disambungkan.

                        PilihCombo(cDepartment, Teks(rd("Nama_Department")))
                        ' cDepartment.Text = Teks(rd("Nama_Department"))
                        PilihCombo(cBagian, Teks(rd("Nama_Bagian")))
                        '  cBagian.Text = Teks(rd("Nama_Bagian"))
                        PilihCombo(cJabatan, Teks(rd("Nama_Jabatan")))
                        '  cJabatan.Text = Teks(rd("Nama_Jabatan"))
                        PilihCombo(cJenis, rd("ffcjeniskaryawan"))
                        '  cJenis.Text = Teks(rd("ffcjeniskaryawan"))

                        '------------------------------------
                        ' PENGHASILAN OFFERING
                        '------------------------------------
                        tGp.Text = FormatAngka(rd("ffngajipokok"))

                        tTunjanganTetap.Text = FormatAngka(rd("ffntunjangantetap"))

                        tTunjanganLain.Text = FormatAngka(rd("ffntunjanganlain"))

                        tTunjanganTransport.Text = FormatAngka(rd("ffntransport"))

                        tTunjanganMakan.Text = FormatAngka(rd("ffnmakan"))

                        tMasaCoba.Text = Teks(rd("ffcmassapercobaan"))

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data calon pegawai: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Teks(nilai As Object) As String

        If nilai Is Nothing OrElse IsDBNull(nilai) Then
            Return ""
        End If

        Return Convert.ToString(nilai).Trim()

    End Function
    Private Function FormatTanggal(nilai As Object) As String

        If nilai Is Nothing OrElse IsDBNull(nilai) Then
            Return "-"
        End If

        Return Convert.ToDateTime(nilai).ToString("dd/MM/yyyy")

    End Function
    Private Function FormatAngka(nilai As Object) As String

        If nilai Is Nothing OrElse IsDBNull(nilai) Then
            Return "0"
        End If

        Return Convert.ToDecimal(nilai).ToString("N0")

    End Function
    Private Sub PilihCombo(cmb As Guna.UI2.WinForms.Guna2ComboBox,
                       nilai As Object)

        Dim teksNilai As String = Teks(nilai)

        If teksNilai = "" Then
            cmb.SelectedIndex = -1
            Return
        End If

        Dim index As Integer = cmb.FindStringExact(teksNilai)

        If index >= 0 Then
            cmb.SelectedIndex = index
        Else
            cmb.SelectedIndex = -1

            MessageBox.Show("Nilai '" & teksNilai &
                        "' tidak ditemukan di ComboBox " & cmb.Name)
        End If

    End Sub
    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub
    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()

    End Sub

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click
        If Not ModeProses Then
            PesanPopupPeringatan("Peringatan", "Data hanya dapat disimpan melalui mode Proses.")
            Return
        End If

        If IdCalonPegawai <= 0 Then
            PesanPopupPeringatan("Peringatan", "ID calon pegawai tidak valid.")
            Return
        End If

        If String.IsNullOrWhiteSpace(tNamaLengkap.Text) Then
            PesanPopupPeringatan("Validasi", "Nama lengkap wajib diisi.")
            tNamaLengkap.Focus()
            Return
        End If

        If cDepartment.SelectedIndex < 0 OrElse cBagian.SelectedIndex < 0 OrElse cJabatan.SelectedIndex < 0 Then
            PesanPopupPeringatan("Validasi", "Departemen, bagian, dan jabatan wajib dipilih.")
            Return
        End If

        Dim idKandidat As Long = 0

        Using conn As New MySqlConnection(sambung)

            conn.Open()

            Using trans As MySqlTransaction = conn.BeginTransaction()

                Try
                    '1. Ambil ID kandidat dan pastikan record masih dapat diproses
                    Dim sqlKandidat As String = "SELECT ffcidkandidat FROM sacalonpegawai WHERE ffcidcalonpegawai = @id AND ffcstatus NOT IN ('BATAL','MENJADI_PEGAWAI') FOR UPDATE"

                    Using cmd As New MySqlCommand(sqlKandidat, conn, trans)

                        cmd.Parameters.AddWithValue("@id", IdCalonPegawai)

                        Dim hasil As Object = cmd.ExecuteScalar()

                        If hasil Is Nothing OrElse IsDBNull(hasil) Then
                            Throw New Exception("Data tidak ditemukan atau sudah tidak dapat diproses.")
                        End If

                        idKandidat = Convert.ToInt64(hasil)

                    End Using

                    '2. Simpan data pribadi kandidat
                    Dim sqlPribadi As String = "UPDATE sakandidat SET ffcnama = @nama, ffctempatlahir = @tempatlahir, ffdtgllahir = @tgllahir, ffcjeniskelamin = @kelamin, ffcstatuspernikahan = @statusnikah, " &
                        "ffcnik = @ktp, ffcnpwp = @npwp, ffcnotelp = @telp, ffcemail = @email, ffcalamat = @alamat,ffcdomisili=@domisili,ffcagama = @agama, ffcketerangan = @keterangan WHERE ffcidkandidat = @idkandidat"

                    Using cmd As New MySqlCommand(sqlPribadi, conn, trans)

                        cmd.Parameters.AddWithValue("@nama", tNamaLengkap.Text.Trim())
                        cmd.Parameters.AddWithValue("@tempatlahir", tTempatLahir.Text.Trim())
                        cmd.Parameters.AddWithValue("@tgllahir", dTglLahir.Value.Date)
                        cmd.Parameters.AddWithValue("@kelamin", cKelamin.Text.Trim())
                        cmd.Parameters.AddWithValue("@statusnikah", cStatusNikah.Text.Trim())
                        cmd.Parameters.AddWithValue("@agama", tAgama.Text.Trim())
                        cmd.Parameters.AddWithValue("@ktp", tNik.Text.Trim())
                        cmd.Parameters.AddWithValue("@npwp", tNpwp.Text.Trim())
                        cmd.Parameters.AddWithValue("@telp", tNomorTelp.Text.Trim())
                        cmd.Parameters.AddWithValue("@email", tEmail.Text.Trim())
                        cmd.Parameters.AddWithValue("@alamat", tAlamatKtp.Text.Trim())
                        cmd.Parameters.AddWithValue("@domisili", tAlamatDomisili.Text.Trim())
                        cmd.Parameters.AddWithValue("@keterangan", tKeterangan.Text.Trim())
                        cmd.Parameters.AddWithValue("@idkandidat", idKandidat)

                        cmd.ExecuteNonQuery()

                    End Using

                    '3. Simpan penempatan calon pegawai
                    Dim sqlPenempatan As String = "UPDATE sacalonpegawai SET ffcdepartemen = @departemen, ffcbagian = @bagian, ffcjabatan = @jabatan, ffcjeniskaryawan = @jenis, ffdmulai = @mulai, ffdupdate = NOW() WHERE ffcidcalonpegawai = @id"

                    Using cmd As New MySqlCommand(sqlPenempatan, conn, trans)

                        cmd.Parameters.AddWithValue("@departemen", cDepartment.SelectedValue)
                        cmd.Parameters.AddWithValue("@bagian", cBagian.SelectedValue)
                        cmd.Parameters.AddWithValue("@jabatan", cJabatan.SelectedValue)
                        cmd.Parameters.AddWithValue("@jenis", cJenis.Text.Trim())
                        cmd.Parameters.AddWithValue("@mulai", dTglkerja.Value.Date)
                        cmd.Parameters.AddWithValue("@id", IdCalonPegawai)

                        cmd.ExecuteNonQuery()

                    End Using

                    '4. Simpan pendidikan yang ditampilkan.
                    'Record pendidikan lain tidak dihapus.
                    Dim idPendidikan As Long = 0

                    Dim sqlCariPendidikan As String = "SELECT ffcidpendidikan FROM sakandidatpendidikan WHERE ffcidkandidat = @idkandidat ORDER BY ffctahunlulus DESC, ffcidpendidikan DESC LIMIT 1 FOR UPDATE"

                    Using cmd As New MySqlCommand(sqlCariPendidikan, conn, trans)

                        cmd.Parameters.AddWithValue("@idkandidat", idKandidat)

                        Dim hasil As Object = cmd.ExecuteScalar()

                        If hasil IsNot Nothing AndAlso Not IsDBNull(hasil) Then
                            idPendidikan = Convert.ToInt64(hasil)
                        End If

                    End Using

                    If cPendidikan.SelectedIndex >= 0 OrElse tSekolah.Text.Trim() <> "" OrElse tJurusan.Text.Trim() <> "" Then

                        Dim sqlPendidikan As String

                        If idPendidikan > 0 Then
                            sqlPendidikan = "UPDATE sakandidatpendidikan SET ffctingkat = @tingkat, ffcnamainstitusi = @institusi, ffcjurusan = @jurusan, ffctahunlulus = @tahun, ffcketerangan = @keterangan WHERE ffcidpendidikan = @idpendidikan " &
                                "AND ffcidkandidat = @idkandidat"
                        Else
                            sqlPendidikan = "INSERT INTO sakandidatpendidikan (ffcidkandidat, ffctingkat, ffcnamainstitusi,ffcjurusan, ffctahunlulus, ffcketerangan) VALUES (@idkandidat, @tingkat, @institusi,@jurusan, @tahun, @keterangan)"

                        End If

                        Using cmd As New MySqlCommand(sqlPendidikan, conn, trans)

                            cmd.Parameters.AddWithValue("@idkandidat", idKandidat)
                            cmd.Parameters.AddWithValue("@tingkat", cPendidikan.Text.Trim())
                            cmd.Parameters.AddWithValue("@institusi", tSekolah.Text.Trim())
                            cmd.Parameters.AddWithValue("@jurusan", tJurusan.Text.Trim())
                            cmd.Parameters.AddWithValue("@tahun", Convert.ToInt32(nTahunLulus.Value))
                            cmd.Parameters.AddWithValue("@keterangan", tKeterangan.Text.Trim())

                            If idPendidikan > 0 Then
                                cmd.Parameters.AddWithValue("@idpendidikan", idPendidikan)
                            End If

                            cmd.ExecuteNonQuery()

                        End Using

                    End If

                    trans.Commit()
                    PesanPopupSukses("Berhasil", "Data calon pegawai berhasil disimpan.")

                    Me.DialogResult = DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    Try
                        trans.Rollback()
                    Catch
                        'Transaksi mungkin sudah tidak aktif.
                    End Try
                    PesanPopupError("ERROR", "Gagal menyimpan data calon pegawai." & Environment.NewLine & ex.Message)
                End Try

            End Using

        End Using
    End Sub

    Private Sub bTandai_Click(sender As Object, e As EventArgs) Handles bTandai.Click

        If Not ModeProses Then
            PesanPopupPeringatan("Peringatan", "Tandai hanya dapat dilakukan melalui mode Proses.")
            Return
        End If

        If IdCalonPegawai <= 0 Then
            PesanPopupPeringatan("Peringatan", "ID calon pegawai tidak valid.")
            Return
        End If

        'Validasi data minimum
        If String.IsNullOrWhiteSpace(tNamaLengkap.Text) Then
            PesanPopupPeringatan("Validasi", "Nama lengkap wajib diisi.")
            tNamaLengkap.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(tNik.Text) Then
            PesanPopupPeringatan("Validasi", "Nomor KTP wajib diisi.")
            tNik.Focus()
            Return
        End If

        If cKelamin.SelectedIndex < 0 Then
            PesanPopupPeringatan("Validasi", "Jenis kelamin wajib dipilih.")
            cKelamin.Focus()
            Return
        End If

        If cDepartment.SelectedIndex < 0 OrElse cBagian.SelectedIndex < 0 OrElse cJabatan.SelectedIndex < 0 Then

            PesanPopupPeringatan("Validasi", "Departemen, bagian, dan jabatan wajib dipilih.")
            Return
        End If

        If String.IsNullOrWhiteSpace(cJenis.Text) Then
            PesanPopupPeringatan("Validasi", "Jenis karyawan wajib diisi.")
            cJenis.Focus()
            Return
        End If



        'Konfirmasi sebelum mengubah status
        If MessageBox.Show("Tandai calon pegawai ini sebagai SIAP MENJADI PEGAWAI?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Using trans As MySqlTransaction = conn.BeginTransaction()

                    Try
                        Dim sql As String = "UPDATE sacalonpegawai SET ffcstatus = 'SIAP_MENJADI_PEGAWAI',ffdupdate = NOW() WHERE ffcidcalonpegawai = @id AND ffcstatus = 'CALON_PEGAWAI'"

                        Using cmd As New MySqlCommand(sql, conn, trans)

                            cmd.Parameters.AddWithValue(
                            "@id", IdCalonPegawai)

                            Dim jumlah As Integer = cmd.ExecuteNonQuery()

                            If jumlah <> 1 Then
                                Throw New Exception("Status calon pegawai bukan CALON_PEGAWAI, atau data sudah berubah. Muat ulang data.")
                            End If

                        End Using

                        trans.Commit()

                    Catch
                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw
                    End Try

                End Using

            End Using

            PesanPopupSukses("Berhasil", "Calon pegawai berhasil ditandai SIAP MENJADI PEGAWAI.")

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal menandai calon pegawai." &
            Environment.NewLine & ex.Message)

        End Try

    End Sub


End Class