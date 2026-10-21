Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing
Public Class frmPenawaranKerjaAdd
    '==========================================================
    ' FORM MODE
    '==========================================================
    Public Enum FormMode
        Detail
        Proses
    End Enum

    '==========================================================
    ' PROPERTY
    '==========================================================
    Public Property IdOffering As Long
    Public Property IdKandidat As Long
    Public Property IdRekrutmen As Long
    Public Property ModeForm As FormMode

    '==========================================================
    ' STATUS OFFERING
    '==========================================================
    Private _statusOffering As String = ""
    Private Function GetDecimalValue(text As String) As Decimal

        If String.IsNullOrWhiteSpace(text) Then
            Return 0D
        End If

        Dim value As Decimal

        If Decimal.TryParse(text, Globalization.NumberStyles.Number, Globalization.CultureInfo.CurrentCulture, value) Then
            Return value
        End If

        Throw New Exception("Nilai angka tidak valid: " & text)

    End Function
#Region "PRIVATE"
    Private Sub Setlabel(control As Control, value As Object)

        If value Is Nothing OrElse IsDBNull(value) Then
            control.Text = ""
        Else
            control.Text = value.ToString()
        End If


    End Sub
    Private Sub SetText(control As Guna2TextBox, value As Object)

        If value Is Nothing OrElse IsDBNull(value) Then

            control.Text = String.Empty

        Else

            control.Text = Convert.ToString(value)

        End If

    End Sub
    Private Sub SetDate(control As Guna2DateTimePicker, value As Object)
        If value Is Nothing OrElse IsDBNull(value) Then
            Return
        End If
        control.Value = Convert.ToDateTime(value)
    End Sub
    Private Sub SetDateTime(control As Control, value As Object)
        If value Is Nothing OrElse IsDBNull(value) Then
            control.Text = ""
        Else
            control.Text = Convert.ToDateTime(value).ToString("dd/MM/yyyy HH:mm")
        End If
    End Sub
    Private Sub SetDecimal(control As Guna2TextBox, value As Object)
        If value Is Nothing OrElse IsDBNull(value) Then
            control.Text = String.Empty
        Else
            control.Text = Convert.ToDecimal(value).ToString("N0")
        End If
    End Sub
    Private Sub SetComboValue(combo As Guna2ComboBox, value As Object)

        If value Is Nothing OrElse IsDBNull(value) Then
            combo.SelectedIndex = -1
            Return
        End If

        Dim nilai As String = value.ToString().Trim()

        If String.IsNullOrEmpty(nilai) Then
            combo.SelectedIndex = -1
            Return

        End If

        Dim index As Integer =
        combo.FindStringExact(nilai)

        If index >= 0 Then
            combo.SelectedIndex = index
        Else
            combo.SelectedIndex = -1
        End If

    End Sub
    Private Sub LoadStatusOffering()

        tStatus.Items.Clear()

        tStatus.Items.Add("WAITING")
        tStatus.Items.Add("ACCEPTED")
        tStatus.Items.Add("REJECTED")
        tStatus.Items.Add("CANCELLED")

        tStatus.SelectedIndex = -1

    End Sub
    Private Sub LoadDataOffering()
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "SELECT o.ffcidoffering, o.ffcidkandidat, o.ffcidrekrutmen, o.ffcnopenawaran, o.ffdpenawaran, o.ffdmulai,o.ffcjabatan, o.ffcdepartemen, " &
                 "o.ffcbagian, o.ffcjeniskaryawan, o.ffctempatkerja,o.ffngajipokok, o.ffntunjangantetap, o.ffntunjanganlain,o.ffntransport ,o.ffnmakan, o.ffcmassapercobaan,o.ffcstatus, " &
                 "o.ffdrespon,o.ffcalasanreject,o.ffcalasancancel,o.ffcketerangan, k.ffcnokandidat, k.ffcnama,k.ffcnik, k.ffcnotelp,k.ffcemail, " &
                 "r.ffcidpermintaan,p.ffcnopermintaan,p.ffcjnskebutuhan, p.ffcprioritas,a.ffcnama AS NamaJabatan ,b.ffcnama AS NamaDepartment,c.ffcnama AS NamaBagian FROM sapenawarankerja o INNER JOIN sakandidat k ON o.ffcidkandidat = k.ffcidkandidat " &
                 "INNER JOIN sakandidatrekrutmen r ON o.ffcidrekrutmen = r.ffcidrekrutmen INNER JOIN sapermintaankaryawan p ON r.ffcidpermintaan = p.ffcidpermintaan  LEFT JOIN  sajabatan a ON o.ffcjabatan = a.ffckls LEFT JOIN sadepartment b ON o.ffcdepartemen = b.ffckode LEFT JOIN sabagian c ON o.ffcbagian = c.ffcbag  " &
                 "WHERE o.ffcidoffering = @idOffering AND o.ffcidkandidat = @idKandidat AND o.ffcidrekrutmen = @idRekrutmen "

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idOffering", IdOffering)
                    cmd.Parameters.AddWithValue("@idKandidat", IdKandidat)

                    cmd.Parameters.AddWithValue("@idRekrutmen", IdRekrutmen)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        If Not reader.Read() Then
                            PesanPopupPeringatan("Peringatan", "Data offering tidak ditemukan.")
                            Me.Close()
                            Return

                        End If


                        '==================================================
                        ' INFORMASI KANDIDAT
                        '==================================================
                        Setlabel(lNoKandidat, reader("ffcnokandidat"))

                        Setlabel(lNamaKandidat, reader("ffcnama"))

                        Setlabel(lNikKandidat, reader("ffcnik"))

                        Setlabel(lNoHp, reader("ffcnotelp"))

                        Setlabel(lEmail, reader("ffcemail"))


                        '==================================================
                        ' INFORMASI REKRUTMEN
                        '==================================================
                        Setlabel(lNoPermintaan, reader("ffcnopermintaan"))

                        Setlabel(lJabatan, reader("NamaJabatan"))

                        Setlabel(lDepartment, reader("NamaDepartment"))

                        Setlabel(lBagian, reader("NamaBagian"))

                        Setlabel(lJenis, reader("ffcjnskebutuhan"))

                        Setlabel(lPrioritas, reader("ffcprioritas"))


                        '==================================================
                        ' DETAIL OFFERING
                        '==================================================
                        SetText(tnoPenawaran, reader("ffcnopenawaran"))
                        SetDate(dtpPenawaran, reader("ffdpenawaran"))

                        SetDate(dtpMulai, reader("ffdmulai"))

                        SetComboValue(cJenisKaryawan, reader("ffcjeniskaryawan"))

                        SetText(tTempatKerja, reader("ffctempatkerja"))

                        SetDecimal(tGajiPokok, reader("ffngajipokok"))

                        SetDecimal(tTunjanganTetap, reader("ffntunjangantetap"))

                        SetDecimal(tTunjanganLain, reader("ffntunjanganlain"))
                        SetDecimal(tTransport, reader("ffntransport"))
                        SetDecimal(tMakan, reader("ffnmakan"))

                        SetComboValue(cMasaPercobaan, reader("ffcmassapercobaan"))


                        '==================================================
                        ' STATUS
                        '==================================================
                        _statusOffering = If(IsDBNull(reader("ffcstatus")), "", reader("ffcstatus").ToString())

                        SetComboValue(tStatus, _statusOffering)

                        SetDateTime(dtpRespon, reader("ffdrespon"))

                        SetText(tAlasanReject, reader("ffcalasanreject"))

                        SetText(tAlasanCancel, reader("ffcalasancancel"))


                        '==================================================
                        ' KETERANGAN
                        '==================================================
                        SetText(tKeterangan, reader("ffcketerangan"))

                    End Using

                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memuat data offering." & Environment.NewLine & ex.Message)
        End Try


    End Sub
    Private Sub AturModeForm()

        Select Case ModeForm

            Case FormMode.Detail

                AturModeDetail()

            Case FormMode.Proses

                AturModeProses()

        End Select

    End Sub
    Private Sub AturModeDetail()

        'Semua field hanya untuk melihat data

        tnoPenawaran.ReadOnly = True
        dtpPenawaran.Enabled = False
        dtpMulai.Enabled = False

        cJenisKaryawan.Enabled = False
        tTempatKerja.ReadOnly = True

        tGajiPokok.ReadOnly = True
        tTunjanganTetap.ReadOnly = True
        tTunjanganLain.ReadOnly = True
        tTransport.ReadOnly = True
        tMakan.ReadOnly = True
        cMasaPercobaan.Enabled = False

        tKeterangan.ReadOnly = True



        'Status
        tStatus.Enabled = False
        dtpRespon.Enabled = False
        tAlasanReject.ReadOnly = True
        tAlasanCancel.ReadOnly = True

        'Tombol
        bSimpan.Visible = False
        bTerima.Visible = False
        bTolak.Visible = False
        bBatalkan.Visible = False

        bCetak.Visible = True
        bTutup.Visible = True

    End Sub
    Private Sub AturModeProses()

        '==========================================================
        ' DEFAULT
        '==========================================================
        tnoPenawaran.ReadOnly = True

        tStatus.Enabled = False
        dtpRespon.Enabled = False

        bSimpan.Visible = False
        bCetak.Visible = True
        bTutup.Visible = True

        ' Default semua field readonly
        dtpPenawaran.Enabled = False
        dtpMulai.Enabled = False

        cJenisKaryawan.Enabled = False
        tTempatKerja.ReadOnly = True

        tGajiPokok.ReadOnly = True
        tTunjanganTetap.ReadOnly = True
        tTunjanganLain.ReadOnly = True
        tTransport.ReadOnly = True
        tMakan.ReadOnly = True

        cMasaPercobaan.Enabled = False

        tKeterangan.ReadOnly = True

        tAlasanReject.ReadOnly = True
        tAlasanCancel.ReadOnly = True


        '==========================================================
        ' CEK STATUS OFFERING
        '==========================================================
        Select Case _statusOffering.Trim().ToUpper()

            Case "WAITING"

                '==================================================
                ' DETAIL OFFERING BISA DIEDIT
                '==================================================
                dtpPenawaran.Enabled = True
                dtpMulai.Enabled = True

                cJenisKaryawan.Enabled = True
                tTempatKerja.ReadOnly = False

                tGajiPokok.ReadOnly = False
                tTunjanganTetap.ReadOnly = False
                tTunjanganLain.ReadOnly = False
                tTransport.ReadOnly = False
                tMakan.ReadOnly = False

                cMasaPercobaan.Enabled = True

                tKeterangan.ReadOnly = False


                '==================================================
                ' ALASAN
                '==================================================
                tAlasanReject.ReadOnly = False
                tAlasanCancel.ReadOnly = False


                '==================================================
                ' TOMBOL
                '==================================================
                bSimpan.Visible = True


            Case "ACCEPTED"

                '==================================================
                ' DETAIL SUDAH FINAL / READONLY
                '==================================================
                dtpPenawaran.Enabled = False
                dtpMulai.Enabled = False

                cJenisKaryawan.Enabled = False
                tTempatKerja.ReadOnly = True

                tGajiPokok.ReadOnly = True
                tTunjanganTetap.ReadOnly = True
                tTunjanganLain.ReadOnly = True
                tTransport.ReadOnly = True
                tMakan.ReadOnly = True

                cMasaPercobaan.Enabled = False

                tKeterangan.ReadOnly = True

                tAlasanReject.ReadOnly = True

                '==================================================
                ' ACCEPTED MASIH BOLEH DIBATALKAN
                '==================================================
                tAlasanCancel.ReadOnly = False

                bSimpan.Visible = False


            Case "REJECTED"

                '==================================================
                ' SUDAH DITOLAK
                '==================================================
                bSimpan.Visible = False

                tAlasanReject.ReadOnly = True
                tAlasanCancel.ReadOnly = True


            Case "CANCELLED"

                '==================================================
                ' SUDAH DIBATALKAN
                '==================================================
                bSimpan.Visible = False

                tAlasanReject.ReadOnly = True
                tAlasanCancel.ReadOnly = True


            Case Else

                '==================================================
                ' STATUS TIDAK DIKENAL
                '==================================================
                bSimpan.Visible = False

        End Select


        '==========================================================
        ' ATUR TOMBOL BERDASARKAN STATUS
        '==========================================================
        AturTombolStatus()

    End Sub
    Private Sub AturTombolStatus()

        '==========================================================
        ' DEFAULT
        '==========================================================
        bTerima.Visible = False
        bTolak.Visible = False
        bBatalkan.Visible = False


        Select Case _statusOffering.Trim().ToUpper()

            Case "WAITING"

                '----------------------------------------------
                ' Offering masih menunggu keputusan
                '----------------------------------------------
                bTerima.Visible = True
                bTolak.Visible = True
                bBatalkan.Visible = True


            Case "ACCEPTED"

                '----------------------------------------------
                ' Kandidat sudah menerima,
                ' tetapi masih bisa dibatalkan
                '----------------------------------------------
                bBatalkan.Visible = True


            Case "REJECTED"

                '----------------------------------------------
                ' Sudah ditolak
                ' Tidak ada proses lanjutan pada offering ini
                '----------------------------------------------
                bTerima.Visible = False
                bTolak.Visible = False
                bBatalkan.Visible = False


            Case "CANCELLED"

                '----------------------------------------------
                ' Sudah dibatalkan
                '----------------------------------------------
                bTerima.Visible = False
                bTolak.Visible = False
                bBatalkan.Visible = False

        End Select

    End Sub
    Private Sub LoadJenisKaryawan()

        cJenisKaryawan.Items.Clear()

        cJenisKaryawan.Items.Add("Tetap")
        cJenisKaryawan.Items.Add("Kontrak")
        cJenisKaryawan.Items.Add("Harian")
        cJenisKaryawan.Items.Add("Magang")

    End Sub
    Private Sub LoadMasaPercobaan()

        cMasaPercobaan.Items.Clear()

        cMasaPercobaan.Items.Add("Tidak Ada")
        cMasaPercobaan.Items.Add("1 Bulan")
        cMasaPercobaan.Items.Add("2 Bulan")
        cMasaPercobaan.Items.Add("3 Bulan")
        cMasaPercobaan.Items.Add("6 Bulan")

    End Sub

#End Region

    Private Sub frmPenawaranKerjaAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            '======================================================
            ' VALIDASI ID
            '======================================================
            If IdOffering <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID offering tidak valid.")
                Me.Close()
                Return

            End If

            If IdKandidat <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID kandidat tidak valid.")
                Me.Close()
                Return
            End If

            If IdRekrutmen <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID recruitment tidak valid.")
                Me.Close()
                Return

            End If
            LoadJenisKaryawan()
            LoadMasaPercobaan()
            LoadStatusOffering()
            '======================================================
            ' LOAD DATA
            '======================================================
            LoadDataOffering()


            '======================================================
            ' ATUR MODE FORM
            '======================================================
            AturModeForm()

        Catch ex As Exception

            PesanPopupError("Error", "Gagal membuka form penawaran kerja." & Environment.NewLine & ex.Message)

            Me.Close()

        End Try

    End Sub

    Private Sub bTutup_Click(sender As Object, e As EventArgs) Handles bTutup.Click
        Me.Close()

    End Sub

    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()
    End Sub

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click
        Try

            '==========================================================
            ' VALIDASI STATUS
            '==========================================================
            If _statusOffering.ToUpper() <> "WAITING" Then
                PesanPopupPeringatan("Peringatan", "Offering hanya dapat diubah ketika status masih WAITING.")
                Return

            End If


            '==========================================================
            ' KONFIRMASI
            '==========================================================
            Dim teksKonfirmasi As String = ""
            teksKonfirmasi = "Apakah Anda yakin ingin menyimpan perubahan offering?"


            Dim hasilPopup As DialogResult = PesanPopupKonfirmasi("Konfirmasi", teksKonfirmasi)
            If hasilPopup <> DialogResult.OK AndAlso hasilPopup <> DialogResult.Yes Then
                Return
            End If


            '==========================================================
            ' SIMPAN DATA
            '==========================================================
            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "UPDATE sapenawarankerja SET ffdpenawaran = @tglPenawaran, ffdmulai = @tglMulai,ffcjeniskaryawan = @jenisKaryawan,ffctempatkerja = @tempatKerja,ffngajipokok = @gajiPokok, ffntunjangantetap = @tunjanganTetap, " &
                    "ffntunjanganlain = @tunjanganLain,ffntransport = @transport,ffnmakan = @makan, ffcmassapercobaan = @masaPercobaan, ffcketerangan = @keterangan, ffcuserupdate = @userUpdate, ffdupdate = NOW() " &
                    "WHERE ffcidoffering = @idOffering AND ffcidkandidat = @idKandidat AND ffcidrekrutmen = @idRekrutmen AND ffcstatus = 'WAITING'"

                Using cmd As New MySqlCommand(sql, conn)

                    '==================================================
                    ' PARAMETER IDENTITAS
                    '==================================================
                    cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                    cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                    cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen


                    '==================================================
                    ' PARAMETER OFFERING
                    '==================================================
                    cmd.Parameters.Add("@tglPenawaran", MySqlDbType.Date).Value = dtpPenawaran.Value.Date
                    cmd.Parameters.Add("@tglMulai", MySqlDbType.Date).Value = dtpMulai.Value.Date


                    '==================================================
                    ' DATA PEKERJAAN
                    '==================================================
                    cmd.Parameters.Add("@jenisKaryawan", MySqlDbType.VarChar).Value = If(String.IsNullOrWhiteSpace(cJenisKaryawan.Text), DBNull.Value, CType(cJenisKaryawan.Text.Trim(), Object))
                    cmd.Parameters.Add("@tempatKerja", MySqlDbType.VarChar).Value = If(String.IsNullOrWhiteSpace(tTempatKerja.Text), DBNull.Value, CType(tTempatKerja.Text.Trim(), Object))


                    '==================================================
                    ' KOMPONEN GAJI
                    '==================================================
                    cmd.Parameters.Add("@gajiPokok", MySqlDbType.Decimal).Value = GetDecimalValue(tGajiPokok.Text)
                    cmd.Parameters.Add("@tunjanganTetap", MySqlDbType.Decimal).Value = GetDecimalValue(tTunjanganTetap.Text)
                    cmd.Parameters.Add("@tunjanganLain", MySqlDbType.Decimal).Value = GetDecimalValue(tTunjanganLain.Text)
                    cmd.Parameters.Add("@transport", MySqlDbType.Decimal).Value = GetDecimalValue(tTransport.Text)
                    cmd.Parameters.Add("@makan", MySqlDbType.Decimal).Value = GetDecimalValue(tMakan.Text)


                    '==================================================
                    ' MASA PERCOBAAN
                    '=================================================
                    cmd.Parameters.Add("@masaPercobaan", MySqlDbType.VarChar).Value = If(String.IsNullOrWhiteSpace(cMasaPercobaan.Text), DBNull.Value, CType(cMasaPercobaan.Text.Trim(), Object))


                    '==================================================
                    ' KETERANGAN
                    '==================================================
                    cmd.Parameters.Add("@keterangan", MySqlDbType.Text).Value = If(String.IsNullOrWhiteSpace(tKeterangan.Text), DBNull.Value, CType(tKeterangan.Text.Trim(), Object))

                    '==================================================
                    ' USER UPDATE
                    '==================================================
                    cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName


                    '==================================================
                    ' EKSEKUSI
                    '==================================================
                    Dim affectedRows As Integer = cmd.ExecuteNonQuery()

                    If affectedRows <= 0 Then
                        PesanPopupPeringatan("Peringatan", "Data offering tidak berubah atau sudah tidak berstatus WAITING.")
                        Return

                    End If

                End Using

            End Using


            '==========================================================
            ' BERHASIL
            '==========================================================
            PesanPopupSukses("Berhasil", "Data offering berhasil disimpan.")

            ' Refresh data setelah berhasil
            LoadDataOffering()

            ' Pastikan tombol mengikuti status terbaru
            AturModeForm()

        Catch ex As Exception
            PesanPopupError("Error", "Gagal menyimpan data offering." & Environment.NewLine & ex.Message)

        End Try
    End Sub

    Private Sub bTerima_Click(sender As Object, e As EventArgs) Handles bTerima.Click
        Try

            '==========================================================
            ' VALIDASI STATUS
            '==========================================================
            If _statusOffering.ToUpper() <> "WAITING" Then
                PesanPopupPeringatan("Peringatan", "Offering hanya dapat diterima ketika status masih WAITING.")
                Return

            End If


            '==========================================================
            ' KONFIRMASI
            '==========================================================

            Dim teksKonfirmasi As String = ""
            teksKonfirmasi = "Apakah Anda yakin kandidat menerima offering ini?"


            Dim hasilPopup As DialogResult = PesanPopupKonfirmasi("Konfirmasi", teksKonfirmasi)
            If hasilPopup <> DialogResult.OK AndAlso hasilPopup <> DialogResult.Yes Then
                Return
            End If



            '==========================================================
            ' DATABASE
            '==========================================================
            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Using trans As MySqlTransaction = conn.BeginTransaction()

                    Try

                        '==================================================
                        ' UPDATE OFFERING
                        '==================================================
                        Dim sqlOffering As String = "UPDATE sapenawarankerja SET ffcstatus = 'ACCEPTED', ffdrespon = NOW(), " &
                                "ffcuserupdate = @userUpdate, ffdupdate = NOW() WHERE ffcidoffering = @idOffering " &
                                "AND ffcidkandidat = @idKandidat AND ffcidrekrutmen = @idRekrutmen AND ffcstatus = 'WAITING'"

                        Dim affectedOffering As Integer

                        Using cmd As New MySqlCommand(sqlOffering, conn, trans)

                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName

                            affectedOffering = cmd.ExecuteNonQuery()

                        End Using


                        '==================================================
                        ' VALIDASI OFFERING
                        '==================================================
                        If affectedOffering <= 0 Then

                            Throw New Exception("Offering tidak dapat diterima. " & "Status offering mungkin sudah berubah.")

                        End If


                        '==================================================
                        ' UPDATE STATUS RECRUITMENT
                        '==================================================
                        Dim sqlRecruitment As String = "UPDATE sakandidatrekrutmen SET ffcstatus = 'ACCEPTED', ffcuserupdate = @userUpdate, ffdupdate = NOW() WHERE ffcidrekrutmen = @idRekrutmen AND ffcidkandidat = @idKandidat"

                        Using cmd As New MySqlCommand(sqlRecruitment, conn, trans)

                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen

                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat

                            cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName

                            Dim affectedRecruitment As Integer = cmd.ExecuteNonQuery()

                            If affectedRecruitment <= 0 Then

                                Throw New Exception("Data recruitment kandidat tidak ditemukan.")

                            End If

                        End Using

                        '==================================================
                        ' UPDATE PROSES SELEKSI
                        '==================================================
                        Dim sqlProses As String = "UPDATE saprosesseleksi SET ffcstatus = 'ACCEPTED', ffdupdate = NOW() WHERE ffcidoffering = @idOffering AND ffcidrekrutmen = @idRekrutmen AND ffcidkandidat = @idKandidat " &
                            "AND ffctahap = 'OFFERING' AND ffcstatus = 'WAITING'"

                        Using cmd As New MySqlCommand(sqlProses, conn, trans)
                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat

                            Dim affectedProses As Integer = cmd.ExecuteNonQuery()

                            If affectedProses <= 0 Then
                                Throw New Exception("Proses seleksi OFFERING tidak ditemukan.")
                            End If

                        End Using

                        '==================================================
                        ' BUAT DATA CALON PEGAWAI
                        '==================================================
                        Dim sqlCalon As String = "INSERT INTO sacalonpegawai (ffcidkandidat, ffcidrekrutmen, ffcidoffering, ffcktp, ffcnik, ffcstatus, ffdmulai, ffcjabatan, ffcdepartemen, ffcbagian, " &
                            "ffcjeniskaryawan, ffctempatkerja, ffcuserinput) Select o.ffcidkandidat, o.ffcidrekrutmen, o.ffcidoffering,k.ffcnik, NULL, 'CALON_PEGAWAI', o.ffdmulai, o.ffcjabatan, o.ffcdepartemen, o.ffcbagian, " &
                            "o.ffcjeniskaryawan, o.ffctempatkerja, @userInput FROM sapenawarankerja o INNER JOIN sakandidat k ON k.ffcidkandidat = o.ffcidkandidat INNER JOIN sakandidatrekrutmen r ON r.ffcidrekrutmen = o.ffcidrekrutmen " &
                            "AND r.ffcidkandidat = o.ffcidkandidat WHERE o.ffcidoffering = @idOffering AND o.ffcidkandidat = @idKandidat AND o.ffcidrekrutmen = @idRekrutmen AND o.ffcstatus = 'ACCEPTED' AND r.ffcstatus = 'ACCEPTED' " &
                            "AND NOT EXISTS (SELECT 1 FROM sacalonpegawai cp WHERE cp.ffcidoffering = o.ffcidoffering)"

                        Using cmd As New MySqlCommand(sqlCalon, conn, trans)

                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@userInput", MySqlDbType.VarChar).Value = Environment.UserName

                            Dim affectedCalon As Integer = cmd.ExecuteNonQuery()

                            If affectedCalon <> 1 Then
                                Throw New Exception("Data calon pegawai gagal dibuat. " & "Pastikan Offering, kandidat, dan rekrutmen valid " & "serta belum memiliki data calon pegawai.")
                            End If

                        End Using


                        '==================================================
                        ' COMMIT
                        '==================================================
                        trans.Commit()


                    Catch
                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using


            '==========================================================
            ' UPDATE STATUS FORM
            '==========================================================
            _statusOffering = "ACCEPTED"

            LoadDataOffering()

            AturModeForm()


            '==========================================================
            ' PESAN BERHASIL
            '==========================================================
            PesanPopupSukses("Berhasil", "Offering berhasil diterima.")

        Catch ex As Exception

            PesanPopupError("Error", "Gagal memproses penerimaan offering." & Environment.NewLine & ex.Message)

        End Try
    End Sub

    Private Sub bTolak_Click(sender As Object, e As EventArgs) Handles bTolak.Click
        Try

            '==========================================================
            ' VALIDASI STATUS
            '==========================================================
            If _statusOffering.ToUpper() <> "WAITING" Then
                PesanPopupPeringatan("Peringatan", "Offering hanya dapat ditolak ketika status masih WAITING.")
                Return
            End If

            '==========================================================
            ' VALIDASI ALASAN PENOLAKAN
            '==========================================================
            If String.IsNullOrWhiteSpace(tAlasanReject.Text) Then
                PesanPopupPeringatan("Peringatan", "Alasan penolakan wajib diisi.")
                tAlasanReject.Focus()
                Return
            End If

            '==========================================================
            ' KONFIRMASI
            '==========================================================
            Dim teksKonfirmasi As String = ""
            teksKonfirmasi = "Apakah Anda yakin ingin menolak offering ini?"

            Dim hasilPopup As DialogResult = PesanPopupKonfirmasi("Konfirmasi", teksKonfirmasi)
            If hasilPopup <> DialogResult.OK AndAlso hasilPopup <> DialogResult.Yes Then
                Return
            End If



            '==========================================================
            ' DATABASE
            '==========================================================
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try

                        '==================================================
                        ' UPDATE OFFERING
                        '==================================================
                        Dim sqlOffering As String = "UPDATE sapenawarankerja SET ffcstatus = 'REJECTED',ffdrespon = NOW(), ffcalasanreject = @alasanReject,ffcuserupdate = @userUpdate, ffdupdate = NOW() WHERE ffcidoffering = @idOffering " &
                            "AND ffcidkandidat = @idKandidat AND ffcidrekrutmen = @idRekrutmen AND ffcstatus = 'WAITING'"

                        Dim affectedOffering As Integer

                        Using cmd As New MySqlCommand(sqlOffering, conn, trans)
                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@alasanReject", MySqlDbType.Text).Value = tAlasanReject.Text.Trim()
                            cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName

                            affectedOffering = cmd.ExecuteNonQuery()

                        End Using


                        '==================================================
                        ' VALIDASI UPDATE OFFERING
                        '==================================================
                        If affectedOffering <= 0 Then
                            Throw New Exception("Offering tidak dapat ditolak. " & "Status offering mungkin sudah berubah.")
                        End If


                        '==================================================
                        ' UPDATE STATUS RECRUITMENT
                        '
                        ' Tetap OFFERING karena kandidat masih
                        ' memungkinkan mendapatkan offering baru.
                        '==================================================
                        Dim sqlRecruitment As String = "UPDATE sakandidatrekrutmen SET ffcstatus = 'OFFERING', ffcuserupdate = @userUpdate, " &
                            "ffdupdate = NOW() WHERE ffcidrekrutmen = @idRekrutmen AND ffcidkandidat = @idKandidat"

                        Using cmd As New MySqlCommand(sqlRecruitment, conn, trans)

                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName
                            Dim affectedRecruitment As Integer = cmd.ExecuteNonQuery()
                            If affectedRecruitment <= 0 Then
                                Throw New Exception("Data recruitment kandidat tidak ditemukan.")
                            End If

                        End Using

                        '==================================================
                        ' UPDATE PROSES SELEKSI
                        '==================================================
                        Dim sqlProses As String = "UPDATE saprosesseleksi SET ffcstatus = 'REJECTED', ffdupdate = NOW() WHERE ffcidoffering = @idOffering " &
                            "AND ffcidrekrutmen = @idRekrutmen AND ffcidkandidat = @idKandidat AND ffctahap = 'OFFERING' AND ffcstatus = 'WAITING'"

                        Using cmd As New MySqlCommand(sqlProses, conn, trans)
                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            Dim affectedProses As Integer = cmd.ExecuteNonQuery()
                            If affectedProses <= 0 Then
                                Throw New Exception("Proses seleksi OFFERING tidak ditemukan.")
                            End If

                        End Using

                        '==================================================
                        ' COMMIT
                        '==================================================
                        trans.Commit()

                    Catch
                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using


            '==========================================================
            ' UPDATE STATUS FORM
            '==========================================================
            _statusOffering = "REJECTED"

            LoadDataOffering()

            AturModeForm()


            '==========================================================
            ' PESAN BERHASIL
            '==========================================================
            PesanPopupSukses("Berhasil", "Offering berhasil ditolak.")
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memproses penolakan offering." & Environment.NewLine & ex.Message)
        End Try
    End Sub
    Private Sub bBatalkan_Click(sender As Object, e As EventArgs) Handles bBatalkan.Click

        Try
            '==========================================================
            ' VALIDASI STATUS
            '==========================================================
            If _statusOffering.ToUpper() <> "WAITING" AndAlso _statusOffering.ToUpper() <> "ACCEPTED" Then
                PesanPopupPeringatan("Peringatan", "Offering tidak dapat dibatalkan pada status saat ini.")
                Return
            End If

            '==========================================================
            ' VALIDASI ALASAN PEMBATALAN
            '==========================================================
            If String.IsNullOrWhiteSpace(tAlasanCancel.Text) Then
                PesanPopupPeringatan("Peringatan", "Alasan pembatalan wajib diisi.")
                tAlasanCancel.Focus()
                Return

            End If

            '==========================================================
            ' KONFIRMASI
            '==========================================================
            Dim teksKonfirmasi As String = ""
            teksKonfirmasi = "Apakah Anda yakin ingin membatalkan offering ini?"

            Dim hasilPopup As DialogResult = PesanPopupKonfirmasi("Konfirmasi", teksKonfirmasi)
            If hasilPopup <> DialogResult.OK AndAlso hasilPopup <> DialogResult.Yes Then
                Return
            End If

            '==========================================================
            ' DATABASE
            '==========================================================
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Using trans As MySqlTransaction = conn.BeginTransaction()

                    Try

                        '==================================================
                        ' UPDATE SAPENAWARANKERJA
                        '==================================================
                        Dim sqlOffering As String = "UPDATE sapenawarankerja SET ffcstatus = 'CANCELLED', ffdrespon = NOW(), ffcalasancancel = @alasanCancel, ffcuserupdate = @userUpdate, ffdupdate = NOW() " &
                        "WHERE ffcidoffering = @idOffering AND ffcidkandidat = @idKandidat AND ffcidrekrutmen = @idRekrutmen AND ffcstatus IN ('WAITING', 'ACCEPTED')"

                        Dim affectedOffering As Integer
                        Using cmd As New MySqlCommand(sqlOffering, conn, trans)

                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@alasanCancel", MySqlDbType.Text).Value = tAlasanCancel.Text.Trim()
                            cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName

                            affectedOffering = cmd.ExecuteNonQuery()

                        End Using

                        '==================================================
                        ' VALIDASI UPDATE OFFERING
                        '==================================================
                        If affectedOffering <= 0 Then
                            Throw New Exception("Offering tidak dapat dibatalkan. " & "Status offering mungkin sudah berubah.")
                        End If


                        '==================================================
                        ' UPDATE SAPROSSESELEKSI
                        '==================================================
                        Dim sqlProses As String = "UPDATE saprosesseleksi SET ffcstatus = 'CANCELLED', ffdupdate = NOW() WHERE ffcidoffering = @idOffering " &
                        "AND ffcidrekrutmen = @idRekrutmen AND ffcidkandidat = @idKandidat AND ffctahap = 'OFFERING' AND ffcstatus IN ('WAITING', 'ACCEPTED')"

                        Using cmd As New MySqlCommand(sqlProses, conn, trans)

                            cmd.Parameters.Add("@idOffering", MySqlDbType.Int64).Value = IdOffering
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat

                            Dim affectedProses As Integer = cmd.ExecuteNonQuery()

                            If affectedProses <= 0 Then
                                Throw New Exception("Proses seleksi OFFERING tidak ditemukan.")
                            End If

                        End Using


                        '==================================================
                        ' UPDATE STATUS RECRUITMENT
                        '==================================================
                        Dim sqlRecruitment As String = "UPDATE sakandidatrekrutmen SET ffcstatus = 'CANCELLED', ffcuserupdate = @userUpdate, ffdupdate = NOW() WHERE ffcidrekrutmen = @idRekrutmen AND ffcidkandidat = @idKandidat"

                        Using cmd As New MySqlCommand(sqlRecruitment, conn, trans)
                            cmd.Parameters.Add("@idRekrutmen", MySqlDbType.Int64).Value = IdRekrutmen
                            cmd.Parameters.Add("@idKandidat", MySqlDbType.Int64).Value = IdKandidat
                            cmd.Parameters.Add("@userUpdate", MySqlDbType.VarChar).Value = Environment.UserName

                            Dim affectedRecruitment As Integer = cmd.ExecuteNonQuery()

                            If affectedRecruitment <= 0 Then
                                Throw New Exception("Data recruitment kandidat tidak ditemukan.")
                            End If
                        End Using

                        '==================================================
                        ' COMMIT
                        '==================================================
                        trans.Commit()
                    Catch
                        trans.Rollback()
                        Throw

                    End Try

                End Using

            End Using

            '==========================================================
            ' UPDATE STATUS FORM
            '==========================================================
            _statusOffering = "CANCELLED"

            LoadDataOffering()

            AturModeForm()

            '==========================================================
            ' PESAN BERHASIL
            '==========================================================
            PesanPopupSukses("Berhasil", "Offering berhasil dibatalkan.")

        Catch ex As Exception
            PesanPopupError("Error", "Gagal membatalkan offering." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Private Sub tTempatKerja_TextChanged(sender As Object, e As EventArgs) Handles tTempatKerja.TextChanged
        Dim tb As Guna2TextBox = CType(sender, Guna2TextBox)

        If tb.Text.Length > 0 Then
            Dim cursorPos As Integer = tb.SelectionStart
            Dim text As String = tb.Text
            Dim formatted As String = Char.ToUpper(text(0)) & text.Substring(1).ToLower()
            If tb.Text <> formatted Then
                tb.Text = formatted
                tb.SelectionStart = Math.Min(cursorPos, tb.Text.Length)
            End If
        End If
    End Sub

    Private Sub tGajiPokok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        tGajiPokok.KeyPress, tTunjanganLain.KeyPress, tTunjanganTetap.KeyPress, tTransport.KeyPress, tMakan.KeyPress
        If (e.KeyChar = ChrW(Keys.Enter)) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        Select Case KeyAscii
            Case 48 To 57, 8, 13, 46
            Case Else
                KeyAscii = 0
        End Select
        If KeyAscii = 0 Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub tGajiPokok_Leave(sender As Object, e As EventArgs) Handles tGajiPokok.Leave
        If String.IsNullOrWhiteSpace(tGajiPokok.Text) Then
            Return
        End If

        Dim gaji As Decimal

        If Decimal.TryParse(tGajiPokok.Text.Replace(".", "").Replace(",", ""), gaji) Then
            tGajiPokok.Text = gaji.ToString("#,##0")

        End If
    End Sub

    Private Sub tTunjanganLain_Leave(sender As Object, e As EventArgs) Handles tTunjanganLain.Leave
        If String.IsNullOrWhiteSpace(tTunjanganLain.Text) Then
            Return
        End If

        Dim gaji As Decimal

        If Decimal.TryParse(tTunjanganLain.Text.Replace(".", "").Replace(",", ""), gaji) Then
            tTunjanganLain.Text = gaji.ToString("#,##0")

        End If
    End Sub

    Private Sub tTunjanganTetap_Leave(sender As Object, e As EventArgs) Handles tTunjanganTetap.Leave
        If String.IsNullOrWhiteSpace(tTunjanganTetap.Text) Then
            Return
        End If

        Dim gaji As Decimal

        If Decimal.TryParse(tTunjanganTetap.Text.Replace(".", "").Replace(",", ""), gaji) Then
            tTunjanganTetap.Text = gaji.ToString("#,##0")

        End If
    End Sub

    Private Sub tTransport_Leave(sender As Object, e As EventArgs) Handles tTransport.Leave
        If String.IsNullOrWhiteSpace(tTransport.Text) Then
            Return
        End If

        Dim gaji As Decimal

        If Decimal.TryParse(tTransport.Text.Replace(".", "").Replace(",", ""), gaji) Then
            tTransport.Text = gaji.ToString("#,##0")

        End If
    End Sub

    Private Sub tMakan_Leave(sender As Object, e As EventArgs) Handles tMakan.Leave
        If String.IsNullOrWhiteSpace(tMakan.Text) Then
            Return
        End If

        Dim gaji As Decimal

        If Decimal.TryParse(tMakan.Text.Replace(".", "").Replace(",", ""), gaji) Then
            tMakan.Text = gaji.ToString("#,##0")

        End If
    End Sub
End Class