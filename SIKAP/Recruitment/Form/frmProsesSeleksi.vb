Imports System.Windows.Forms.LinkLabel
Imports MySql.Data.MySqlClient

Public Class frmProsesSeleksi
    Private _idKandidat As Long = 0
    Private _idRekrutmen As Long = 0
    Private _idProses As Long = 0

    Private _mode As String = "Tambah"
    Public Property TahapAwal As String
    Public Property IdProses As Long
        Get
            Return _idProses
        End Get
        Set(value As Long)
            _idProses = value
        End Set
    End Property
    Public Property ModeForm As String
        Get
            Return _mode
        End Get
        Set(value As String)
            _mode = value
        End Set
    End Property
#Region "Function"
    Private Function GetRecruitmentStatusByStage(tahap As String, statusProses As String, hasil As String) As String

        tahap = If(tahap, "").Trim().ToUpper()
        statusProses = If(statusProses, "").Trim().ToUpper()
        hasil = If(hasil, "").Trim().ToUpper()


        '==========================================================
        ' JIKA PROSES GAGAL
        '==========================================================
        If statusProses = "FAILED" Then
            Return "REJECTED"
        End If


        '==========================================================
        ' JIKA HASIL TIDAK LULUS
        '==========================================================
        If hasil = "TIDAK_LULUS" OrElse hasil = "TIDAK_DIREKOMENDASIKAN" Then

            Return "REJECTED"

        End If


        '==========================================================
        ' PROSES BELUM SELESAI
        '==========================================================
        If statusProses <> "PASSED" Then
            Select Case tahap
                Case "SCREENING"
                    Return "SCREENING"
                Case "TEST"
                    Return "TEST"
                Case "INTERVIEW_HR", "INTERVIEW_USER"
                    Return "INTERVIEW"
                Case "MEDICAL_CHECK"
                    Return "INTERVIEW"
                Case "OFFERING"
                    Return "OFFER"
                Case Else
                    Return ""
            End Select

        End If


        '==========================================================
        ' PROSES PASSED
        '==========================================================
        Select Case tahap

            Case "SCREENING"
                Return "SCREENING"

            Case "TEST"
                Return "TEST"

            Case "INTERVIEW_HR",
             "INTERVIEW_USER"

                Return "INTERVIEW"

            Case "MEDICAL_CHECK"
                Return "INTERVIEW"

            Case "OFFERING"
                Return "ACCEPTED"

            Case Else
                Return ""

        End Select

    End Function
    Private Function GetLatestRecruitmentStatus() As String

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffctahap, ffcstatus, ffchasil FROM saprosesseleksi WHERE ffcidrekrutmen = @idrekrutmen AND ffcidkandidat = @idkandidat ORDER BY ffcidproses DESC LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then
                            Dim tahap As String = If(IsDBNull(rd("ffctahap")), "", rd("ffctahap").ToString())
                            Dim status As String = If(IsDBNull(rd("ffcstatus")), "", rd("ffcstatus").ToString())
                            Dim hasil As String = If(IsDBNull(rd("ffchasil")), "", rd("ffchasil").ToString())
                            Return GetRecruitmentStatusByStage(tahap, status, hasil)
                        End If
                    End Using

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception("Gagal menentukan status recruitment terbaru." & vbCrLf & ex.Message)
        End Try

        Return ""

    End Function
    Private Function ValidasiInput() As Boolean

        '==========================================================
        ' TAHAP
        '==========================================================

        If cTahap.SelectedIndex < 0 OrElse String.IsNullOrWhiteSpace(cTahap.Text) Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih tahap seleksi.")
            cTahap.Focus()
            Return False
        End If


        '==========================================================
        ' STATUS
        '==========================================================

        If cStatus.SelectedIndex < 0 OrElse String.IsNullOrWhiteSpace(cStatus.Text) Then

            PesanPopupPeringatan("Peringatan", "Silakan pilih status proses seleksi.")
            cStatus.Focus()
            Return False

        End If


        '==========================================================
        ' HASIL
        '==========================================================

        If cHasil.SelectedIndex < 0 OrElse
       String.IsNullOrWhiteSpace(cHasil.Text) Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih hasil seleksi.")
            cHasil.Focus()
            Return False

        End If


        '==========================================================
        ' INTERVIEWER
        '==========================================================

        If String.IsNullOrWhiteSpace(tInterviewer.Text) Then
            PesanPopupPeringatan("Peringatan", "Interviewer / penilai harus diisi.")
            tInterviewer.Focus()
            Return False

        End If


        '==========================================================
        ' NILAI
        '==========================================================

        If Not String.IsNullOrWhiteSpace(tNilai.Text) Then

            Dim nilai As Decimal
            If Not Decimal.TryParse(tNilai.Text.Trim(), nilai) Then
                PesanPopupPeringatan("Peringatan", "Nilai harus berupa angka.")
                tNilai.Focus()
                Return False

            End If

            If nilai < 0D OrElse nilai > 100D Then
                PesanPopupPeringatan("Peringatan", "Nilai harus berada di antara 0 sampai 100.")
                tNilai.Focus()
                Return False

            End If

        End If

        Return True

    End Function
#End Region
    Public Property IdKandidat As Long
        Get
            Return _idKandidat
        End Get
        Set(value As Long)
            _idKandidat = value
        End Set
    End Property

    Public Property IdRekrutmen As Long
        Get
            Return _idRekrutmen
        End Get
        Set(value As Long)
            _idRekrutmen = value
        End Set
    End Property
#Region "Private "

    Private Sub SimpanProsesSeleksi()

        '==========================================================
        ' VALIDASI ID
        '==========================================================

        If _idKandidat <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data kandidat belum ditentukan.")
            Return
        End If


        If _idRekrutmen <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data recruitment belum ditentukan.")
            Return
        End If


        '==========================================================
        ' AMBIL TAHAP
        '==========================================================

        Dim tahap As String = ""

        If cTahap.SelectedItem IsNot Nothing Then
            tahap = cTahap.SelectedItem.ToString().Trim().ToUpper()
        End If


        '==========================================================
        ' AMBIL STATUS
        '==========================================================

        Dim statusProses As String = ""

        If cStatus.SelectedItem IsNot Nothing Then
            statusProses = cStatus.SelectedItem.ToString().Trim().ToUpper()
        End If


        '==========================================================
        ' AMBIL HASIL
        '==========================================================

        Dim hasil As String = ""

        If cHasil.SelectedItem IsNot Nothing Then
            hasil = cHasil.SelectedItem.ToString().Trim().ToUpper()
        End If


        '==========================================================
        ' VALIDASI TAHAP
        '==========================================================

        If String.IsNullOrWhiteSpace(tahap) Then
            PesanPopupPeringatan("Peringatan", "Tahap seleksi harus dipilih.")
            Return

        End If


        '==========================================================
        ' VALIDASI STATUS
        '==========================================================

        If String.IsNullOrWhiteSpace(statusProses) Then
            PesanPopupPeringatan("Peringatan", "Status proses harus dipilih.")
            Return

        End If


        '==========================================================
        ' HASIL HANYA UNTUK PASSED / FAILED
        '==========================================================

        If statusProses = "PASSED" OrElse
       statusProses = "FAILED" Then

            If String.IsNullOrWhiteSpace(hasil) Then
                PesanPopupPeringatan("Peringatan", "Hasil seleksi harus dipilih untuk status " & statusProses & ".")
                Return
            End If
        Else
            hasil = ""
        End If


        '==========================================================
        ' VALIDASI HASIL BERDASARKAN TAHAP
        '==========================================================

        Select Case tahap

            Case "SCREENING", "TEST", "MEDICAL_CHECK", "OFFERING"

                If hasil <> "" AndAlso hasil <> "LULUS" AndAlso hasil <> "TIDAK_LULUS" Then
                    PesanPopupPeringatan("Peringatan", "Hasil untuk tahap " & tahap & " hanya boleh LULUS atau TIDAK_LULUS.")
                    Return
                End If


            Case "INTERVIEW_HR", "INTERVIEW_USER"
                If hasil <> "" AndAlso hasil <> "DIREKOMENDASIKAN" AndAlso hasil <> "TIDAK_DIREKOMENDASIKAN" Then
                    PesanPopupPeringatan("Peringatan", "Hasil untuk tahap " & tahap & " hanya boleh DIREKOMENDASIKAN atau " & "TIDAK_DIREKOMENDASIKAN.")
                    Return
                End If


            Case Else
                PesanPopupPeringatan("Peringatan", "Tahap seleksi tidak dikenali.")
                Return

        End Select


        '==========================================================
        ' NILAI
        '==========================================================

        Dim nilai As Nullable(Of Decimal) = Nothing

        If Not String.IsNullOrWhiteSpace(tNilai.Text) Then
            Dim nilaiTemp As Decimal
            If Not Decimal.TryParse(tNilai.Text.Trim(), nilaiTemp) Then
                PesanPopupPeringatan("Peringatan", "Nilai seleksi harus berupa angka.")
                tNilai.Focus()

                Return

            End If


            If nilaiTemp < 0D OrElse nilaiTemp > 100D Then
                PesanPopupPeringatan("Peringatan", "Nilai seleksi harus berada antara 0 sampai 100.")
                tNilai.Focus()

                Return

            End If

            nilai = nilaiTemp

        End If


        '==========================================================
        ' TEST PASSED WAJIB ADA NILAI
        '==========================================================

        If tahap = "TEST" AndAlso statusProses = "PASSED" AndAlso Not nilai.HasValue Then
            PesanPopupPeringatan("Peringatan", "Nilai wajib diisi untuk proses Test.")
            tNilai.Focus()
            Return

        End If


        '==========================================================
        ' DATA LAIN
        '==========================================================

        Dim interviewer As String = tInterviewer.Text.Trim()

        Dim catatan As String = tCatatan.Text.Trim()

        Dim jadwal As DateTime = dtpJadwal.Value


        '==========================================================
        ' TANGGAL PROSES
        '==========================================================

        Dim tanggalProses As Nullable(Of DateTime) = Nothing

        Select Case statusProses

            Case "PROCESS", "PASSED", "FAILED", "CANCELLED"
                tanggalProses = DateTime.Now
            Case Else

                tanggalProses = Nothing

        End Select


        '==========================================================
        ' KONFIRMASI
        '==========================================================

        Dim teksKonfirmasi As String = ""

        If _mode.ToUpper() = "EDIT" Then
            teksKonfirmasi = "Apakah perubahan proses seleksi akan disimpan?"

        Else
            teksKonfirmasi = "Apakah data proses seleksi akan disimpan?"

        End If


        teksKonfirmasi &= vbCrLf & vbCrLf & "Tahap    : " & tahap & vbCrLf & "Status   : " & statusProses

        If hasil <> "" Then

            teksKonfirmasi &= vbCrLf & "Hasil    : " & hasil

        End If

        Dim hasilPopup As DialogResult = PesanPopupKonfirmasi("Konfirmasi", teksKonfirmasi)
        If hasilPopup <> DialogResult.OK AndAlso hasilPopup <> DialogResult.Yes Then
            Return

        End If


        '==========================================================
        ' DATABASE
        '==========================================================

        Using conn As New MySqlConnection(sambung)

            conn.Open()

            Using trans As MySqlTransaction =
            conn.BeginTransaction()

                Try

                    '==================================================
                    ' MODE TAMBAH
                    '==================================================

                    If _mode.ToUpper() = "TAMBAH" Then

                        Dim sqlInsert As String = "INSERT INTO saprosesseleksi (ffcidrekrutmen, ffcidkandidat, ffctahap, ffcstatus,ffdjadwal, ffdproses, ffcinterviewer,ffchasil,ffcnilai, ffccatatan) VALUES (@idrekrutmen, " &
                        "@idkandidat, @tahap, @status, @jadwal, @proses, @interviewer, @hasil, @nilai, @catatan)"


                        Using cmd As New MySqlCommand(sqlInsert, conn, trans)

                            cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                            cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat
                            cmd.Parameters.Add("@tahap", MySqlDbType.VarChar).Value = tahap
                            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = statusProses


                            If statusProses = "WAITING" OrElse statusProses = "SCHEDULED" OrElse statusProses = "PROCESS" Then
                                cmd.Parameters.Add("@jadwal", MySqlDbType.DateTime).Value = jadwal
                            Else
                                cmd.Parameters.Add("@jadwal", MySqlDbType.DateTime).Value = DBNull.Value
                            End If


                            If tanggalProses.HasValue Then
                                cmd.Parameters.Add("@proses", MySqlDbType.DateTime).Value = tanggalProses.Value
                            Else
                                cmd.Parameters.Add("@proses", MySqlDbType.DateTime).Value = DBNull.Value
                            End If


                            If String.IsNullOrWhiteSpace(interviewer) Then
                                cmd.Parameters.Add("@interviewer", MySqlDbType.VarChar).Value = DBNull.Value
                            Else
                                cmd.Parameters.Add("@interviewer", MySqlDbType.VarChar).Value = interviewer
                            End If


                            If String.IsNullOrWhiteSpace(hasil) Then
                                cmd.Parameters.Add("@hasil", MySqlDbType.VarChar).Value = DBNull.Value
                            Else
                                cmd.Parameters.Add("@hasil", MySqlDbType.VarChar).Value = hasil
                            End If


                            If nilai.HasValue Then
                                cmd.Parameters.Add("@nilai", MySqlDbType.Decimal).Value = nilai.Value
                            Else
                                cmd.Parameters.Add("@nilai", MySqlDbType.Decimal).Value = DBNull.Value
                            End If


                            If String.IsNullOrWhiteSpace(catatan) Then
                                cmd.Parameters.Add("@catatan", MySqlDbType.Text).Value = DBNull.Value
                            Else
                                cmd.Parameters.Add("@catatan", MySqlDbType.Text).Value = catatan
                            End If

                            Dim affected As Integer = cmd.ExecuteNonQuery()

                            If affected <= 0 Then
                                Throw New Exception("Data proses seleksi gagal disimpan.")
                            End If

                        End Using


                        '==================================================
                        ' MODE EDIT
                        '==================================================

                    ElseIf _mode.ToUpper() = "EDIT" Then

                        If _idProses <= 0 Then
                            Throw New Exception("ID proses seleksi tidak valid untuk proses Edit.")

                        End If


                        Dim sqlUpdate As String = "UPDATE saprosesseleksi SET ffctahap = @tahap,ffcstatus = @status, ffdjadwal = @jadwal,ffdproses = @proses, ffcinterviewer = @interviewer,ffchasil = @hasil, ffcnilai = @nilai, " &
                        "ffccatatan = @catatan, ffdupdate = NOW() WHERE ffcidproses = @idproses AND ffcidrekrutmen = @idrekrutmen AND ffcidkandidat = @idkandidat"

                        Using cmd As New MySqlCommand(sqlUpdate, conn, trans)

                            cmd.Parameters.Add("@idproses", MySqlDbType.Int64).Value = _idProses
                            cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                            cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat
                            cmd.Parameters.Add("@tahap", MySqlDbType.VarChar).Value = tahap
                            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = statusProses


                            If statusProses = "WAITING" OrElse statusProses = "SCHEDULED" OrElse statusProses = "PROCESS" Then
                                cmd.Parameters.Add("@jadwal", MySqlDbType.DateTime).Value = jadwal
                            Else
                                cmd.Parameters.Add("@jadwal", MySqlDbType.DateTime).Value = DBNull.Value
                            End If


                            If tanggalProses.HasValue Then
                                cmd.Parameters.Add("@proses", MySqlDbType.DateTime).Value = tanggalProses.Value
                            Else
                                cmd.Parameters.Add("@proses", MySqlDbType.DateTime).Value = DBNull.Value
                            End If


                            If String.IsNullOrWhiteSpace(interviewer) Then
                                cmd.Parameters.Add("@interviewer", MySqlDbType.VarChar).Value = DBNull.Value
                            Else
                                cmd.Parameters.Add("@interviewer", MySqlDbType.VarChar).Value = interviewer
                            End If


                            If String.IsNullOrWhiteSpace(hasil) Then
                                cmd.Parameters.Add("@hasil", MySqlDbType.VarChar).Value = DBNull.Value
                            Else
                                cmd.Parameters.Add("@hasil", MySqlDbType.VarChar).Value = hasil
                            End If


                            If nilai.HasValue Then
                                cmd.Parameters.Add("@nilai", MySqlDbType.Decimal).Value = nilai.Value
                            Else
                                cmd.Parameters.Add("@nilai", MySqlDbType.Decimal).Value = DBNull.Value
                            End If


                            If String.IsNullOrWhiteSpace(catatan) Then
                                cmd.Parameters.Add("@catatan", MySqlDbType.Text).Value = DBNull.Value
                            Else
                                cmd.Parameters.Add("@catatan", MySqlDbType.Text).Value = catatan

                            End If


                            Dim affected As Integer = cmd.ExecuteNonQuery()


                            If affected <= 0 Then
                                Throw New Exception("Data proses seleksi tidak ditemukan atau gagal diperbarui.")
                            End If

                        End Using


                    Else
                        Throw New Exception("Mode form tidak dikenali: " & _mode)

                    End If


                    '==================================================
                    ' TENTUKAN STATUS RECRUITMENT TERBARU
                    '==================================================

                    Dim latestStatus As String = GetLatestRecruitmentStatus()


                    If String.IsNullOrWhiteSpace(latestStatus) Then

                        Throw New Exception("Status recruitment terbaru tidak dapat ditentukan.")

                    End If


                    '==================================================
                    ' UPDATE STATUS RECRUITMENT
                    '==================================================

                    Dim sqlRecruitment As String = "UPDATE sakandidatrekrutmen SET ffcstatus = @status WHERE ffcidrekrutmen = @idrekrutmen AND ffcidkandidat = @idkandidat"


                    Using cmdRecruitment As New MySqlCommand(sqlRecruitment, conn, trans)
                        cmdRecruitment.Parameters.Add("@status", MySqlDbType.VarChar).Value = latestStatus
                        cmdRecruitment.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                        cmdRecruitment.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat

                        Dim affectedRecruitment As Integer = cmdRecruitment.ExecuteNonQuery()


                        If affectedRecruitment <= 0 Then
                            Throw New Exception("Data recruitment tidak ditemukan atau status recruitment gagal diperbarui.")
                        End If

                    End Using


                    '==================================================
                    ' COMMIT
                    '==================================================
                    trans.Commit()

                    '==================================================
                    ' LOAD ULANG RIWAYAT
                    '==================================================
                    LoadRiwayatSeleksi()

                    '==================================================
                    ' PESAN
                    '==================================================

                    If _mode.ToUpper() = "EDIT" Then
                        PesanPopupSukses("Berhasil", "Proses seleksi berhasil diperbarui.")
                    Else
                        PesanPopupSukses("Berhasil", "Proses seleksi berhasil disimpan.")
                    End If


                    '==================================================
                    ' SETELAH EDIT
                    '==================================================

                    If _mode.ToUpper() = "EDIT" Then
                        _mode = "Tambah"
                    End If


                Catch ex As Exception
                    Try
                        trans.Rollback()
                    Catch
                    End Try
                    PesanPopupError("Error", "Gagal menyimpan proses seleksi." & vbCrLf & ex.Message)

                End Try

            End Using

        End Using

    End Sub
#End Region
    Private Sub SetupComboBox()

        '==========================================================
        ' TAHAP SELEKSI
        '==========================================================
        cTahap.Items.Clear()

        cTahap.Items.Add("SCREENING")
        cTahap.Items.Add("TEST")
        cTahap.Items.Add("INTERVIEW_HR")
        cTahap.Items.Add("INTERVIEW_USER")
        cTahap.Items.Add("MEDICAL_CHECK")
        cTahap.Items.Add("OFFERING")


        '==========================================================
        ' STATUS PROSES
        '==========================================================
        cStatus.Items.Clear()

        cStatus.Items.Add("WAITING")
        cStatus.Items.Add("SCHEDULED")
        cStatus.Items.Add("PROCESS")
        cStatus.Items.Add("PASSED")
        cStatus.Items.Add("FAILED")
        cStatus.Items.Add("CANCELLED")


        '==========================================================
        ' HASIL
        '==========================================================
        cHasil.Items.Clear()

    End Sub
    Private Sub SetupHasilByTahap()

        '==========================================================
        ' SIMPAN TAHAP YANG DIPILIH
        '==========================================================
        Dim tahap As String = ""

        If cTahap.SelectedItem IsNot Nothing Then
            tahap = cTahap.SelectedItem.ToString().Trim().ToUpper()
        End If


        '==========================================================
        ' RESET HASIL
        '==========================================================
        cHasil.Items.Clear()
        cHasil.SelectedIndex = -1


        '==========================================================
        ' TENTUKAN HASIL BERDASARKAN TAHAP
        '==========================================================
        Select Case tahap

            Case "SCREENING", "TEST", "MEDICAL_CHECK", "OFFERING"
                cHasil.Items.Add("LULUS")
                cHasil.Items.Add("TIDAK_LULUS")
            Case "INTERVIEW_HR", "INTERVIEW_USER"
                cHasil.Items.Add("DIREKOMENDASIKAN")
                cHasil.Items.Add("TIDAK_DIREKOMENDASIKAN")
            Case Else
                'Tidak ada hasil

        End Select

    End Sub
    Private Sub SetHasilSeleksi(hasil As String)

        If String.IsNullOrWhiteSpace(hasil) Then

            cHasil.SelectedIndex = -1
            Return

        End If

        If cHasil.Items.Contains(hasil) Then

            cHasil.SelectedItem = hasil

        Else

            cHasil.SelectedIndex = -1

        End If

    End Sub
    Private Sub UpdateHasilByStatus()

        Dim status As String = ""

        If cStatus.SelectedItem IsNot Nothing Then
            status = cStatus.SelectedItem.ToString().Trim().ToUpper()
        End If


        Select Case status

            Case "WAITING", "SCHEDULED", "PROCESS", "CANCELLED"

                '==================================================
                ' BELUM ADA HASIL
                '==================================================
                cHasil.SelectedIndex = -1
                cHasil.Enabled = False


            Case "PASSED", "FAILED"

                '==================================================
                ' PROSES SELESAI
                ' HASIL WAJIB DIPILIH
                '==================================================
                cHasil.Enabled = True


            Case Else

                cHasil.SelectedIndex = -1
                cHasil.Enabled = False

        End Select

    End Sub
    Private Sub LoadKandidat()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT ffcnokandidat,ffcnama,ffcnik,ffcnotelp,ffcemail FROM sakandidat WHERE ffcidkandidat = @idkandidat LIMIT 1 "
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            lNoKandidat.Text = If(IsDBNull(rd("ffcnokandidat")), "", rd("ffcnokandidat").ToString())
                            lNamaKandidat.Text = If(IsDBNull(rd("ffcnama")), "", rd("ffcnama").ToString())
                            lNikKandidat.Text = If(IsDBNull(rd("ffcnik")), "", rd("ffcnik").ToString())
                            lNoHp.Text = If(IsDBNull(rd("ffcnotelp")), "", rd("ffcnotelp").ToString())
                            lEmail.Text = If(IsDBNull(rd("ffcemail")), "", rd("ffcemail").ToString())
                        Else
                            PesanPopupPeringatan("Peringatan", "Data kandidat tidak ditemukan.")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                PesanPopupError("Error", "Gagal mengambil data kandidat." & vbCrLf & ex.Message)
            End Try
        End Using

    End Sub
    Private Sub LoadRecruitment()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT r.ffcidrekrutmen,r.ffcidpermintaan,p.ffcnopermintaan,p.ffckddepart,p.ffckdbagian,p.ffckdjabatan FROM sakandidatrekrutmen r " &
                    "INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE r.ffcidrekrutmen = @idrekrutmen AND r.ffcidkandidat = @idkandidat LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            lNoPermintaan.Text = If(IsDBNull(rd("ffcnopermintaan")), "", rd("ffcnopermintaan").ToString())
                            lDepartment.Text = If(IsDBNull(rd("ffckddepart")), "", rd("ffckddepart").ToString())
                            lBagian.Text = If(IsDBNull(rd("ffckdbagian")), "", rd("ffckdbagian").ToString())
                            lJabatan.Text = If(IsDBNull(rd("ffckdjabatan")), "", rd("ffckdjabatan").ToString())
                        Else
                            PesanPopupPeringatan("Peringatan", "Data recruitment tidak ditemukan.")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                PesanPopupError("Error", "Gagal mengambil data recruitment." & vbCrLf & ex.Message)
            End Try
        End Using

    End Sub
    Private Sub SetupGridRiwayat()

        dgvRiwayatSeleksi.DataSource = Nothing
        dgvRiwayatSeleksi.Columns.Clear()

        dgvRiwayatSeleksi.AutoGenerateColumns = False
        dgvRiwayatSeleksi.AllowUserToAddRows = False
        dgvRiwayatSeleksi.AllowUserToDeleteRows = False
        dgvRiwayatSeleksi.ReadOnly = True

        ApplyGridTheme(dgvRiwayatSeleksi)
        '==========================================================
        ' ID PROSES
        '==========================================================
        Dim colID As New DataGridViewTextBoxColumn With {.Name = "ffcidproses", .HeaderText = "ID", .DataPropertyName = "ffcidproses", .Visible = False}
        dgvRiwayatSeleksi.Columns.Add(colID)


        '==========================================================
        ' TAHAP
        '==========================================================
        Dim colTahap As New DataGridViewTextBoxColumn With {.Name = "ffctahap", .HeaderText = "Tahap", .DataPropertyName = "ffctahap", .Width = 140}
        dgvRiwayatSeleksi.Columns.Add(colTahap)

        '==========================================================
        ' JADWAL
        '==========================================================
        Dim colJadwal As New DataGridViewTextBoxColumn With {.Name = "ffdjadwal", .HeaderText = "Jadwal", .DataPropertyName = "ffdjadwal", .Width = 140}
        colJadwal.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        dgvRiwayatSeleksi.Columns.Add(colJadwal)


        '==========================================================
        ' TANGGAL PROSES
        '==========================================================
        Dim colProses As New DataGridViewTextBoxColumn With {.Name = "ffdproses", .HeaderText = "Tanggal Proses", .DataPropertyName = "ffdproses", .Width = 140}
        colProses.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        dgvRiwayatSeleksi.Columns.Add(colProses)


        '==========================================================
        ' STATUS
        '==========================================================
        Dim colStatus As New DataGridViewTextBoxColumn With {.Name = "ffcstatus", .HeaderText = "Status", .DataPropertyName = "ffcstatus", .Width = 100}
        dgvRiwayatSeleksi.Columns.Add(colStatus)


        '==========================================================
        ' INTERVIEWER
        '==========================================================
        Dim colInterviewer As New DataGridViewTextBoxColumn With {.Name = "ffcinterviewer", .HeaderText = "Interviewer", .DataPropertyName = "ffcinterviewer", .Width = 150}
        dgvRiwayatSeleksi.Columns.Add(colInterviewer)


        '==========================================================
        ' NILAI
        '==========================================================
        Dim colNilai As New DataGridViewTextBoxColumn With {.Name = "ffcnilai", .HeaderText = "Nilai", .DataPropertyName = "ffcnilai", .Width = 70}
        dgvRiwayatSeleksi.Columns.Add(colNilai)


        '==========================================================
        ' HASIL
        '==========================================================
        Dim colHasil As New DataGridViewTextBoxColumn With {.Name = "ffchasil", .HeaderText = "Hasil", .DataPropertyName = "ffchasil", .Width = 130}
        dgvRiwayatSeleksi.Columns.Add(colHasil)


        '==========================================================
        ' CATATAN
        '==========================================================
        Dim colCatatan As New DataGridViewTextBoxColumn With {.Name = "ffccatatan", .HeaderText = "Catatan", .DataPropertyName = "ffccatatan", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill}
        dgvRiwayatSeleksi.Columns.Add(colCatatan)

    End Sub
    Private Sub LoadRiwayatSeleksi()

        Try

            Dim dt As New DataTable()

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String =
                "SELECT " &
                "ffcidproses, " &
                "ffctahap, " &
                "ffdjadwal, " &
                "ffdproses, " &
                "ffcstatus, " &
                "ffcinterviewer, " &
                "ffcnilai, " &
                "ffchasil, " &
                "ffccatatan " &
                "FROM saprosesseleksi " &
                "WHERE ffcidrekrutmen = @idrekrutmen " &
                "AND ffcidkandidat = @idkandidat " &
                "ORDER BY " &
                "CASE WHEN ffdjadwal IS NULL THEN 1 ELSE 0 END, " &
                "ffdjadwal ASC, " &
                "ffcidproses ASC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value =
                    _idRekrutmen

                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value =
                    _idKandidat

                    Using da As New MySqlDataAdapter(cmd)

                        da.Fill(dt)

                    End Using

                End Using

            End Using


            '==========================================================
            ' PASANG DATATABLE KE DATAGRIDVIEW
            '==========================================================
            dgvRiwayatSeleksi.DataSource = Nothing

            dgvRiwayatSeleksi.DataSource = dt


            '==========================================================
            ' PASTIKAN DATAGRIDVIEW TIDAK KOSONG
            '==========================================================
            dgvRiwayatSeleksi.Refresh()


        Catch ex As Exception

            PesanPopupError(
            "Error",
            "Gagal mengambil riwayat seleksi." &
            vbCrLf & ex.Message
        )

        End Try

    End Sub
    Private Sub LoadProsesSeleksi()

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffcidproses,ffcidrekrutmen, ffcidkandidat, ffctahap,ffcstatus,ffdjadwal,ffdproses,ffcinterviewer, ffchasil,ffcnilai, ffccatatan FROM saprosesseleksi WHERE ffcidproses = @idproses " &
                "AND ffcidrekrutmen = @idrekrutmen AND ffcidkandidat = @idkandidat LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.Add("@idproses", MySqlDbType.Int64).Value = _idProses
                    cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If Not rd.Read() Then
                            PesanPopupPeringatan("Peringatan", "Data proses seleksi tidak ditemukan.")
                            Return
                        End If


                        '==================================================
                        ' TAHAP
                        '==================================================

                        Dim tahap As String = ""
                        If Not IsDBNull(rd("ffctahap")) Then
                            tahap = rd("ffctahap").ToString().Trim().ToUpper()
                        End If

                        If cTahap.Items.Contains(tahap) Then
                            cTahap.SelectedItem = tahap
                        Else
                            cTahap.SelectedIndex = -1
                        End If


                        '==================================================
                        ' STATUS
                        '==================================================

                        Dim status As String = ""

                        If Not IsDBNull(rd("ffcstatus")) Then
                            status = rd("ffcstatus").ToString().Trim().ToUpper()
                        End If

                        If cStatus.Items.Contains(status) Then
                            cStatus.SelectedItem = status
                        Else
                            cStatus.SelectedIndex = -1
                        End If


                        '==================================================
                        ' JADWAL
                        '==================================================

                        If Not IsDBNull(rd("ffdjadwal")) Then
                            Dim jadwal As DateTime = Convert.ToDateTime(rd("ffdjadwal"))
                            dtpJadwal.Value = jadwal
                        Else
                            dtpJadwal.Value = DateTime.Now
                        End If


                        '==================================================
                        ' INTERVIEWER
                        '==================================================

                        If Not IsDBNull(rd("ffcinterviewer")) Then
                            tInterviewer.Text = rd("ffcinterviewer").ToString()
                        Else
                            tInterviewer.Clear()
                        End If


                        '==================================================
                        ' NILAI
                        '==================================================

                        If Not IsDBNull(rd("ffcnilai")) Then
                            tNilai.Text = Convert.ToDecimal(rd("ffcnilai")).ToString("0.00")
                        Else
                            tNilai.Clear()
                        End If


                        '==================================================
                        ' CATATAN
                        '==================================================

                        If Not IsDBNull(rd("ffccatatan")) Then
                            tCatatan.Text = rd("ffccatatan").ToString()
                        Else
                            tCatatan.Clear()
                        End If


                        '==================================================
                        ' HASIL
                        '==================================================

                        If Not IsDBNull(rd("ffchasil")) Then
                            Dim hasil As String = rd("ffchasil").ToString().Trim().ToUpper()
                            SetHasilSeleksi(hasil)
                        Else
                            cHasil.SelectedIndex = -1
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil data proses seleksi." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ResetInput()

        _idProses = 0
        _mode = "Tambah"


        '==========================================================
        ' RESET TAHAP
        '==========================================================
        cTahap.SelectedIndex = -1


        If Not String.IsNullOrWhiteSpace(TahapAwal) Then

            If cTahap.Items.Contains(TahapAwal) Then
                cTahap.SelectedItem = TahapAwal
            End If

        End If


        '==========================================================
        ' RESET STATUS
        '==========================================================
        cStatus.SelectedIndex = -1


        '==========================================================
        ' RESET INPUT
        '==========================================================
        tInterviewer.Clear()
        tNilai.Clear()

        cHasil.SelectedIndex = -1
        cHasil.Enabled = False

        tCatatan.Clear()

        dtpJadwal.Value = DateTime.Now

    End Sub
    Private Sub frmProsesSeleksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            SetupComboBox()
            SetupGridRiwayat()

            If _idKandidat <= 0 Then
                PesanPopupPeringatan("Peringatan", "Data kandidat belum ditentukan.")
                Return
            End If

            If _idRekrutmen <= 0 Then
                PesanPopupPeringatan("Peringatan", "Data recruitment belum ditentukan.")
                Return
            End If

            LoadKandidat()
            LoadRecruitment()
            LoadRiwayatSeleksi()

            If _mode.ToUpper() = "EDIT" Then
                If _idProses <= 0 Then
                    PesanPopupPeringatan("Peringatan", "ID proses seleksi tidak valid.")
                    Return
                End If
                LoadProsesSeleksi()
                If _mode.ToUpper() = "EDIT" Then
                    Me.Text = "Edit Proses Seleksi"
                Else
                    Me.Text = "Proses Seleksi"
                End If
            Else
                ResetInput()
            End If

        Catch ex As Exception
            PesanPopupError("Error", "Gagal membuka proses seleksi." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub cTahap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTahap.SelectedIndexChanged
        SetupHasilByTahap()
    End Sub
    Private Sub cStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cStatus.SelectedIndexChanged

        UpdateHasilByStatus()

    End Sub
    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click
        SimpanProsesSeleksi()
    End Sub


    Private Sub dgvRiwayatSeleksi_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRiwayatSeleksi.CellDoubleClick

        Try

            If e.RowIndex < 0 Then
                Return
            End If


            Dim row As DataGridViewRow = dgvRiwayatSeleksi.Rows(e.RowIndex)


            If row.Cells("ffcidproses").Value Is Nothing OrElse
               IsDBNull(row.Cells("ffcidproses").Value) Then
                PesanPopupPeringatan("Peringatan", "ID proses seleksi tidak ditemukan.")
                Return

            End If


            Dim idProses As Long = Convert.ToInt64(row.Cells("ffcidproses").Value)


            If idProses <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID proses seleksi tidak valid.")
                Return

            End If


            '======================================================
            ' SET MODE EDIT
            '======================================================

            _idProses = idProses
            _mode = "Edit"


            '======================================================
            ' LOAD DATA PROSES
            '======================================================

            LoadProsesSeleksi()
        Catch ex As Exception
            PesanPopupError("Error", "Gagal membuka proses seleksi untuk Edit." & vbCrLf & ex.Message)

        End Try

    End Sub
End Class