Imports MySql.Data.MySqlClient
Imports System.Drawing
Public Class frmPenilaianInterviewAdd
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
    '==========================================================
    ' VARIABLE
    '==========================================================
    Private _idKandidat As Long = 0
    Private _idRekrutmen As Long = 0
    Private _idProses As Long = 0

    Private _mode As String = "Tambah"

    '==========================================================
    ' PROPERTY
    '==========================================================
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
    Private Function ValidasiPenilaian() As Boolean

        '==========================================================
        ' VALIDASI ID
        '==========================================================
        If _idKandidat <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data kandidat tidak valid.")
            Return False
        End If


        If _idRekrutmen <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data recruitment tidak valid.")
            Return False
        End If


        If _idProses <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data proses seleksi tidak valid.")
            Return False

        End If


        '==========================================================
        ' VALIDASI INTERVIEWER
        '==========================================================
        If String.IsNullOrWhiteSpace(lInterview.Text) Then
            PesanPopupPeringatan("Peringatan", "Interviewer wajib diisi.")
            lInterview.Focus()
            Return False
        End If


        '==========================================================
        ' VALIDASI NILAI
        '==========================================================
        If nNilai.Value < 0 OrElse nNilai.Value > 100 Then
            PesanPopupPeringatan("Peringatan", "Nilai interview harus berada antara 0 sampai 100.")
            nNilai.Focus()

            Return False

        End If


        '==========================================================
        ' VALIDASI HASIL
        '==========================================================
        If chasil.SelectedIndex < 0 OrElse
       String.IsNullOrWhiteSpace(chasil.Text) Then
            PesanPopupPeringatan("Peringatan", "Hasil interview wajib dipilih.")
            chasil.Focus()
            Return False

        End If


        '==========================================================
        ' VALIDASI NILAI HASIL
        '==========================================================
        Dim hasil As String =
        chasil.Text.Trim().ToUpper()

        If hasil <> "DIREKOMENDASIKAN" AndAlso hasil <> "TIDAK_DIREKOMENDASIKAN" Then
            PesanPopupPeringatan("Peringatan", "Hasil interview tidak valid.")
            chasil.Focus()
            Return False

        End If


        Return True

    End Function

#Region "Private"
    Private Function GetRecruitmentStatusAfterInterview(hasil As String) As String

        If hasil = "TIDAK_DIREKOMENDASIKAN" Then
            Return "REJECTED"
        End If


        If hasil = "DIREKOMENDASIKAN" Then
            Return "INTERVIEW"
        End If
        Return "INTERVIEW"

    End Function
    Private Sub LoadKandidat()

        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT ffcnokandidat,ffcnama,ffcnik,ffcnotelp,ffcemail FROM sakandidat WHERE ffcidkandidat = @idkandidat LIMIT 1"
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
                PesanPopupError("ERROR", "Gagal memuat data kandidat: " & ex.Message)
            End Try
        End Using


    End Sub
    Private Sub LoadInformasiInterview()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT k.ffcnokandidat, k.ffcnama,p.ffcnopermintaan,p.ffckddepart,p.ffckdbagian,p.ffckdjabatan,s.ffctahap,s.ffdjadwal, s.ffcinterviewer " &
                "FROM saprosesseleksi s INNER JOIN sakandidatrekrutmen r ON s.ffcidrekrutmen = r.ffcidrekrutmen INNER JOIN sakandidat k ON s.ffcidkandidat = k.ffcidkandidat " &
                "LEFT JOIN sapermintaankaryawan p ON r.ffcidpermintaan = p.ffcidpermintaan WHERE s.ffcidproses = @idproses And s.ffcidrekrutmen = @idrekrutmen And s.ffcidkandidat = @idkandidat LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idproses", _idProses)
                    cmd.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then

                            lNoKandidat.Text = If(IsDBNull(rd("ffcnokandidat")), "", rd("ffcnokandidat").ToString())
                            lNamaKandidat.Text = If(IsDBNull(rd("ffcnama")), "", rd("ffcnama").ToString())
                            '  lNoRecruitment.Text = If(IsDBNull(rd("ffcnorekrutmen")), "", rd("ffcnorekrutmen").ToString())
                            lNoPermintaan.Text = If(IsDBNull(rd("ffcnopermintaan")), "", rd("ffcnopermintaan").ToString())
                            lDepartment.Text = If(IsDBNull(rd("ffckddepart")), "", rd("ffckddepart").ToString())
                            lBagian.Text = If(IsDBNull(rd("ffckdbagian")), "", rd("ffckdbagian").ToString())
                            lJabatan.Text = If(IsDBNull(rd("ffckdjabatan")), "", rd("ffckdjabatan").ToString())
                            lTahap.Text = If(IsDBNull(rd("ffctahap")), "", rd("ffctahap").ToString())
                            If Not IsDBNull(rd("ffdjadwal")) Then
                                lTglJadwal.Text = Convert.ToDateTime(rd("ffdjadwal"))
                            End If
                            lInterview.Text = If(IsDBNull(rd("ffcinterviewer")), "", rd("ffcinterviewer").ToString())
                        Else
                            PesanPopupPeringatan("Peringatan", "Data proses interview tidak ditemukan.")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                PesanPopupError("ERROR", "Gagal memuat informasi interview: " & ex.Message)
            End Try
        End Using


    End Sub
    Private Sub LoadPenilaianInterview()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try

                Dim sql As String = "SELECT ffcstatus,ffcinterviewer,ffcnilai,ffchasil,ffccatatan,ffdproses " &
                "FROM saprosesseleksi WHERE ffcidproses = @idproses And ffcidrekrutmen = @idrekrutmen And ffcidkandidat = @idkandidat LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idproses", _idProses)
                    cmd.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then

                            '==================================================
                            ' INTERVIEWER
                            '==================================================
                            If IsDBNull(rd("ffcinterviewer")) Then
                                lInterview.Text = ""
                            Else
                                lInterview.Text = rd("ffcinterviewer").ToString()
                            End If


                            '==================================================
                            ' NILAI
                            '==================================================
                            If IsDBNull(rd("ffcnilai")) Then

                                nNilai.Text = 0

                            Else

                                Dim nilai As Decimal = Convert.ToDecimal(rd("ffcnilai"))

                                If nilai >= nNilai.Minimum AndAlso nilai <= nNilai.Maximum Then
                                    nNilai.Value = nilai

                                End If

                            End If


                            '==================================================
                            ' HASIL
                            '==================================================
                            If IsDBNull(rd("ffchasil")) Then
                                chasil.SelectedIndex = -1
                            Else
                                chasil.Text = rd("ffchasil").ToString()
                            End If


                            '==================================================
                            ' CATATAN
                            '==================================================
                            If IsDBNull(rd("ffccatatan")) Then
                                tcatatan.Text = ""
                            Else
                                tcatatan.Text = rd("ffccatatan").ToString()
                            End If
                        End If
                    End Using
                End Using

            Catch ex As Exception
                PesanPopupError("ERROR", "Gagal memuat penilaian interview: " & ex.Message)
            End Try
        End Using

    End Sub
    Private Sub SetupHasil()

        chasil.Items.Clear()

        chasil.Items.Add("DIREKOMENDASIKAN")
        chasil.Items.Add("TIDAK_DIREKOMENDASIKAN")

        chasil.SelectedIndex = -1

    End Sub
    Private Sub AturModeForm()

        Select Case _mode.ToUpper()

            Case "VIEW"


                nNilai.Enabled = False
                chasil.Enabled = False
                tcatatan.ReadOnly = True

                bselesai.Visible = False

            Case "EDIT"


                nNilai.Enabled = True
                chasil.Enabled = True
                tcatatan.ReadOnly = False


                bselesai.Visible = True

            Case Else

                '==================================================
                ' TAMBAH PENILAIAN
                '==================================================

                nNilai.Enabled = True
                chasil.Enabled = True
                tcatatan.ReadOnly = False

                bselesai.Visible = True

        End Select

    End Sub
    Private Sub SimpanPenilaian()

        '==========================================================
        ' VALIDASI
        '==========================================================
        If Not ValidasiPenilaian() Then
            Exit Sub
        End If


        '==========================================================
        ' KONFIRMASI
        '==========================================================
        ' If Not PesanPopupKonfirmasi("Konfirmasi", "Apakah Anda yakin ingin menyimpan hasil penilaian interview?") Then
        'Exit Sub
        'End If
        Dim hasilPopup As DialogResult = PesanPopupKonfirmasi("Konfirmasi", "Apakah Anda yakin ingin menyimpan hasil penilaian interview?")
        If hasilPopup <> DialogResult.OK AndAlso hasilPopup <> DialogResult.Yes Then
            Return

        End If


        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Dim transaction As MySqlTransaction = conn.BeginTransaction
            Try

                '======================================================
                ' AMBIL NILAI FORM
                '======================================================
                Dim interviewer As String = lInterview.Text.Trim()
                Dim nilai As Decimal = nNilai.Value
                Dim hasil As String = chasil.Text.Trim().ToUpper()
                Dim catatan As String = tcatatan.Text.Trim()


                '======================================================
                ' TENTUKAN STATUS PROSES
                '======================================================
                Dim statusProses As String = ""

                If hasil = "DIREKOMENDASIKAN" Then
                    statusProses = "PASSED"
                ElseIf hasil = "TIDAK_DIREKOMENDASIKAN" Then
                    statusProses = "FAILED"
                Else
                    PesanPopupPeringatan("Peringatan", "Hasil interview tidak dapat menentukan status proses.")
                    Exit Sub
                End If
                '======================================================
                ' UPDATE SAPROSSESSELEKSI
                '======================================================
                Dim sqlProses As String = "UPDATE saprosesseleksi SET ffcinterviewer = @interviewer,ffcnilai = @nilai,ffchasil = @hasil, ffccatatan = @catatan,ffcstatus = @status, ffdproses = NOW() " &
                    "WHERE ffcidproses = @idproses And ffcidrekrutmen = @idrekrutmen And ffcidkandidat = @idkandidat"
                Using cmdProses As New MySqlCommand(sqlProses, conn, transaction)

                    cmdProses.Parameters.AddWithValue("@interviewer", interviewer)
                    cmdProses.Parameters.AddWithValue("@nilai", nilai)
                    cmdProses.Parameters.AddWithValue("@hasil", hasil)
                    cmdProses.Parameters.AddWithValue("@catatan", If(String.IsNullOrWhiteSpace(catatan), DBNull.Value, catatan))
                    cmdProses.Parameters.AddWithValue("@status", statusProses)
                    cmdProses.Parameters.AddWithValue("@idproses", _idProses)
                    cmdProses.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                    cmdProses.Parameters.AddWithValue("@idkandidat", _idKandidat)

                    Dim affectedRows As Integer = cmdProses.ExecuteNonQuery()

                    '==================================================
                    ' PASTIKAN RECORD BENAR-BENAR ADA
                    '==================================================
                    If affectedRows <= 0 Then
                        Throw New Exception("Data proses seleksi tidak ditemukan atau tidak dapat diperbarui.")
                    End If
                    '======================================================
                    ' UPDATE STATUS RECRUITMENT
                    '======================================================
                    Dim statusRecruitment As String =
                    GetRecruitmentStatusAfterInterview(hasil)


                    Dim sqlRecruitment As String = "UPDATE sakandidatrekrutmen SET ffcstatus = @status, ffdupdate = NOW() WHERE ffcidrekrutmen = @idrekrutmen And ffcidkandidat = @idkandidat"


                    Using cmdRecruitment As New MySqlCommand(sqlRecruitment, conn, transaction)
                        cmdRecruitment.Parameters.AddWithValue("@status", statusRecruitment)
                        cmdRecruitment.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                        cmdRecruitment.Parameters.AddWithValue("@idkandidat", _idKandidat)
                        cmdRecruitment.ExecuteNonQuery()

                    End Using
                    transaction.Commit()

                    PesanPopupSukses("Sukses", "Penilaian interview berhasil disimpan.")
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using
            Catch ex As MySqlException
                Try
                    transaction.Rollback()
                Catch
                End Try
                PesanPopupError("Error MySQL: Kesalahan Database", ex.Message)


            Catch ex As Exception
                Try
                    transaction.Rollback()
                Catch
                End Try
                PesanPopupError("Error umum: Proses dibatalkan", ex.Message)

            End Try
        End Using
    End Sub
#End Region
    Private Sub frmPenilaianInterviewAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShadowForm.SetShadowForm(Me)
        Try
            '======================================================
            ' VALIDASI ID
            '======================================================
            If _idKandidat <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID kandidat tidak valid.")
                Me.Close()
                Exit Sub
            End If

            If _idRekrutmen <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID recruitment tidak valid.")
                Me.Close()
                Exit Sub
            End If

            If _idProses <= 0 Then
                PesanPopupPeringatan("Peringatan", "ID proses seleksi tidak valid.")
                Me.Close()
                Exit Sub
            End If
            SetupHasil()

            '======================================================
            ' LOAD DATA
            '======================================================
            LoadKandidat()
            LoadInformasiInterview()
            LoadPenilaianInterview()


            '======================================================
            ' SET MODE FORM
            '======================================================
            AturModeForm()

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal membuka form penilaian interview: " & ex.Message)

        End Try

    End Sub

    Private Sub bselesai_Click(sender As Object, e As EventArgs) Handles bselesai.Click
        SimpanPenilaian()
    End Sub

    Private Sub bbatal_Click(sender As Object, e As EventArgs) Handles bbatal.Click
        Me.Close()
    End Sub

    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()
    End Sub
End Class