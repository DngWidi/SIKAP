Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class uf_seleksi

    '==========================================================
    ' VARIABLE PENCARIAN
    '==========================================================
    Private _keywordCari As String = ""
    Private _statusCari As String = ""

    '==========================================================
    ' ID REKRUTMEN YANG DIPILIH
    '==========================================================
    Private _idRekrutmenTerpilih As Long = 0

    '==========================================================
    ' ID KANDIDAT YANG DIPILIH
    '==========================================================
    Private _idKandidatTerpilih As Long = 0

    '==========================================================
    ' STATUS RECRUITMENT YANG DIPILIH
    '==========================================================
    Private _statusTerpilih As String = ""

    '==========================================================
    ' TAHAP AWAL
    '==========================================================
    Private _tahapAwal As String = ""

#Region "Function"

    '==========================================================
    ' GET TOTAL RECORD
    '==========================================================
    Private Function GetTotalRecord() As Integer

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT COUNT(*) FROM sakandidatrekrutmen r INNER JOIN sakandidat k ON k.ffcidkandidat = r.ffcidkandidat " &
                    "INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE 1 = 1 "

                '==================================================
                ' FILTER KEYWORD
                '==================================================

                If _keywordCari <> "" Then

                    sql &= "AND (k.ffcnokandidat LIKE @Keyword OR k.ffcnama LIKE @Keyword OR p.ffcnopermintaan LIKE @Keyword " &
                           "OR p.ffckddepart LIKE @Keyword OR p.ffckdbagian LIKE @Keyword OR p.ffckdjabatan LIKE @Keyword) "

                End If

                '==================================================
                ' FILTER STATUS
                '==================================================

                If _statusCari <> "" Then

                    sql &= "AND r.ffcstatus = @Status "

                End If

                Using cmd As New MySqlCommand(sql, conn)

                    '==================================================
                    ' PARAMETER KEYWORD
                    '==================================================

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@Keyword", "%" & _keywordCari & "%")
                    End If

                    '==================================================
                    ' PARAMETER STATUS
                    '==================================================

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@Status", _statusCari)
                    End If
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using

            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal menghitung data seleksi." & vbCrLf & ex.Message)
            Return 0
        End Try

    End Function


    '==========================================================
    ' GET STATUS CODE
    '==========================================================
    Private Function GetStatusCode() As String

        Select Case cstatus.SelectedIndex

            Case 0
                Return ""

            Case 1
                Return "SCREENING"

            Case 2
                Return "TEST"

            Case 3
                Return "INTERVIEW"

            Case 4
                Return "OFFER"

            Case 5
                Return "REJECTED"

            Case 6
                Return "ACCEPTED"

            Case 7
                Return "HIRED"

            Case Else
                Return ""

        End Select

    End Function


    '==========================================================
    ' STATUS DISPLAY
    '==========================================================
    Private Function GetStatusDisplay(status As String) As String

        Select Case status.ToUpper().Trim()

            Case "SCREENING"
                Return "Screening"

            Case "TEST"
                Return "Test"

            Case "INTERVIEW"
                Return "Interview"

            Case "OFFER"
                Return "Penawaran"

            Case "REJECTED"
                Return "Rejected"

            Case "ACCEPTED"
                Return "Diterima"

            Case "HIRED"
                Return "Hired"

            Case Else
                Return status

        End Select

    End Function


    '==========================================================
    ' GET TAHAP TERAKHIR
    '
    ' Fungsi ini membaca proses terakhir dari saprosesseleksi.
    '
    ' INI ADALAH BAGIAN PENTING DALAM WORKFLOW BARU.
    ' uf_seleksi tidak lagi hanya mengandalkan ffcstatus.
    '==========================================================
    Private Function GetTahapTerakhir(idRekrutmen As Long, idKandidat As Long, ByRef tahap As String, ByRef statusProses As String, ByRef hasil As String) As Boolean

        tahap = ""
        statusProses = ""
        hasil = ""

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffctahap, ffcstatus, ffchasil FROM saprosesseleksi WHERE ffcidrekrutmen = @IdRekrutmen " &
                    "AND ffcidkandidat = @IdKandidat ORDER BY ffcidproses DESC LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@IdRekrutmen", idRekrutmen)
                    cmd.Parameters.AddWithValue("@IdKandidat", idKandidat)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then

                            If Not IsDBNull(rd("ffctahap")) Then
                                tahap = rd("ffctahap").ToString().Trim().ToUpper()
                            End If

                            If Not IsDBNull(rd("ffcstatus")) Then
                                statusProses = rd("ffcstatus").ToString().Trim().ToUpper()
                            End If

                            If Not IsDBNull(rd("ffchasil")) Then
                                hasil = rd("ffchasil").ToString().Trim().ToUpper()
                            End If
                            Return True
                        End If
                    End Using
                End Using
            End Using
            Return False
        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil tahap seleksi terakhir." & vbCrLf & ex.Message)
            Return False
        End Try

    End Function


    '==========================================================
    ' MENENTUKAN TAHAP AWAL FORM PROSES SELEKSI
    '
    ' Fungsi ini menentukan tahap yang akan ditampilkan
    ' ketika frmProsesSeleksi dibuka dari uf_seleksi.
    '
    '==========================================================
    Private Function GetTahapAwalProses() As String

        '==========================================================
        ' VALIDASI ID
        '==========================================================

        If _idRekrutmenTerpilih <= 0 OrElse _idKandidatTerpilih <= 0 Then
            Return ""

        End If


        '==========================================================
        ' AMBIL PROSES TERAKHIR
        '==========================================================

        Dim tahapTerakhir As String = ""
        Dim statusProses As String = ""
        Dim hasilTerakhir As String = ""
        Dim adaProses As Boolean = GetTahapTerakhir(_idRekrutmenTerpilih, _idKandidatTerpilih, tahapTerakhir, statusProses, hasilTerakhir)

        '==========================================================
        ' BELUM ADA PROSES
        '
        ' Maka mulai dari SCREENING.
        '==========================================================

        If Not adaProses Then
            Return "SCREENING"
        End If


        '==========================================================
        ' NORMALISASI
        '==========================================================

        tahapTerakhir =
        If(tahapTerakhir, "").
        Trim().
        ToUpper()

        statusProses = If(statusProses, "").Trim().ToUpper()

        hasilTerakhir = If(hasilTerakhir, "").Trim().ToUpper()


        '==========================================================
        ' FAILED / TIDAK LULUS
        '==========================================================

        If statusProses = "FAILED" Then
            Return ""
        End If


        If hasilTerakhir = "TIDAK_LULUS" OrElse hasilTerakhir = "TIDAK_DIREKOMENDASIKAN" Then
            Return ""
        End If


        '==========================================================
        ' SCREENING
        '
        ' Baik SCHEDULED, PROCESS maupun PASSED,
        ' form dibuka pada tahap SCREENING.
        '==========================================================

        If tahapTerakhir = "SCREENING" Then
            Return "SCREENING"
        End If


        '==========================================================
        ' TEST
        '
        ' Ini yang memperbaiki kasus pada gambar Anda.
        '
        ' Contoh:
        '
        ' ffctahap  = TEST
        ' ffcstatus = SCHEDULED
        ' ffchasil  = NULL
        '
        ' Maka:
        '
        ' TahapAwal = TEST
        '
        ' sehingga frmProsesSeleksi membuka TEST,
        ' bukan kosong.
        '==========================================================

        If tahapTerakhir = "TEST" Then
            Return "TEST"
        End If


        '==========================================================
        ' INTERVIEW HR
        '
        ' Jika interview sudah selesai dinilai,
        ' user nantinya memilih tahap berikutnya.
        '
        ' Untuk sementara dikosongkan.
        ' Aturan pilihan berikutnya akan kita kunci
        ' di frmProsesSeleksi pada tahap berikutnya.
        '==========================================================

        If tahapTerakhir = "INTERVIEW_HR" Then
            Return ""
        End If


        '==========================================================
        ' INTERVIEW USER
        '==========================================================

        If tahapTerakhir = "INTERVIEW_USER" Then
            Return ""
        End If


        '==========================================================
        ' MEDICAL CHECK
        '
        ' Jika sudah ada proses MEDICAL_CHECK,
        ' tetap buka tahap tersebut.
        '==========================================================

        If tahapTerakhir = "MEDICAL_CHECK" Then
            Return "MEDICAL_CHECK"
        End If


        '==========================================================
        ' OFFERING
        '==========================================================

        If tahapTerakhir = "OFFERING" Then
            Return "OFFERING"
        End If


        '==========================================================
        ' DEFAULT
        '==========================================================

        Return ""

    End Function

    '==========================================================
    ' CEK APAKAH KANDIDAT BOLEH DIPROSES
    '
    ' ATURAN WORKFLOW:
    '
    ' 1. BELUM ADA PROSES
    '    -> ENABLE
    '
    ' 2. FAILED
    '    -> DISABLE
    '
    ' 3. HASIL TIDAK LULUS
    '    -> DISABLE
    '
    ' 4. INTERVIEW_HR / INTERVIEW_USER
    '    DAN NILAI MASIH KOSONG
    '    -> DISABLE
    '
    '    Karena proses interview dilakukan melalui
    '    frmPenilaianInterviewAdd.
    '
    ' 5. TEST SCHEDULED / PROCESS
    '    -> ENABLE
    '
    ' 6. SCREENING SCHEDULED / PROCESS
    '    -> ENABLE
    '
    ' 7. MEDICAL_CHECK SCHEDULED / PROCESS
    '    -> ENABLE
    '
    ' 8. PROSES LAINNYA
    '    -> ENABLE selama belum FAILED.
    '==========================================================
    Private Function BolehProsesSeleksi() As Boolean

        '==========================================================
        ' VALIDASI ID
        '==========================================================

        If _idRekrutmenTerpilih <= 0 OrElse _idKandidatTerpilih <= 0 Then
            Return False

        End If


        '==========================================================
        ' STATUS RECRUITMENT FINAL
        '==========================================================

        Select Case _statusTerpilih

            Case "REJECTED"

                Return False

            Case "ACCEPTED"

                Return False

            Case "HIRED"

                Return False

        End Select


        '==========================================================
        ' AMBIL PROSES TERAKHIR
        '==========================================================

        Dim tahapTerakhir As String = ""
        Dim statusProses As String = ""
        Dim hasilTerakhir As String = ""

        Dim adaProses As Boolean = GetTahapTerakhir(_idRekrutmenTerpilih, _idKandidatTerpilih, tahapTerakhir, statusProses, hasilTerakhir)


        '==========================================================
        ' BELUM ADA PROSES
        '
        ' Kandidat baru pertama kali masuk seleksi.
        ' Maka button Proses Seleksi harus ENABLE.
        '==========================================================

        If Not adaProses Then
            Return True
        End If


        '==========================================================
        ' NORMALISASI DATA
        '==========================================================

        tahapTerakhir = If(tahapTerakhir, "").Trim().ToUpper()

        statusProses = If(statusProses, "").Trim().ToUpper()

        hasilTerakhir = If(hasilTerakhir, "").Trim().ToUpper()


        '==========================================================
        ' 1. JIKA PROSES FAILED
        '
        ' Tidak boleh dilanjutkan.
        '==========================================================

        If statusProses = "FAILED" Then
            Return False
        End If


        '==========================================================
        ' 2. JIKA HASIL TIDAK LULUS
        '
        ' Termasuk hasil interview:
        ' TIDAK_DIREKOMENDASIKAN
        '==========================================================

        If hasilTerakhir = "TIDAK_LULUS" OrElse hasilTerakhir = "TIDAK_DIREKOMENDASIKAN" Then
            Return False

        End If


        '==========================================================
        ' 3. INTERVIEW HR / USER
        '
        ' Interview tidak diproses melalui frmProsesSeleksi.
        '
        ' Jika nilai masih kosong:
        '    -> DISABLE
        '
        ' Karena user harus masuk ke:
        '
        ' uf_penilaianinterview
        '       ↓
        ' frmPenilaianInterviewAdd
        '
        ' Jika nilai sudah ada:
        '    -> ENABLE
        '
        ' karena interview sudah dinilai dan kandidat dapat
        ' dilanjutkan ke tahap berikutnya.
        '==========================================================

        If tahapTerakhir = "INTERVIEW_HR" OrElse tahapTerakhir = "INTERVIEW_USER" Then

            '------------------------------------------------------
            ' NILAI BELUM ADA
            '------------------------------------------------------

            If String.IsNullOrWhiteSpace(GetNilaiProsesTerakhir(_idRekrutmenTerpilih, _idKandidatTerpilih)) Then
                Return False
            End If
            '------------------------------------------------------
            ' NILAI SUDAH ADA
            '------------------------------------------------------
            Return True

        End If


        '==========================================================
        ' 4. SCREENING
        '
        ' Screening dikerjakan melalui frmProsesSeleksi.
        '
        ' Walaupun status:
        ' SCHEDULED
        ' PROCESS
        ' PASSED
        '
        ' tetap boleh membuka proses.
        '==========================================================

        If tahapTerakhir = "SCREENING" Then
            Return True

        End If


        '==========================================================
        ' 5. TEST
        '
        ' TEST juga dikerjakan melalui frmProsesSeleksi.
        '
        ' Contoh kondisi:
        '
        ' ffctahap  = TEST
        ' ffcstatus = SCHEDULED
        ' ffchasil  = NULL
        '
        ' BUTTON HARUS ENABLE.
        '==========================================================

        If tahapTerakhir = "TEST" Then
            Return True
        End If


        '==========================================================
        ' 6. MEDICAL CHECK
        '
        ' Medical check juga dikontrol melalui uf_seleksi /
        ' frmProsesSeleksi.
        '==========================================================

        If tahapTerakhir = "MEDICAL_CHECK" Then
            Return True
        End If


        '==========================================================
        ' 7. OFFERING
        '
        ' Selama belum FAILED / REJECTED,
        ' proses masih dapat dibuka.
        '==========================================================

        If tahapTerakhir = "OFFERING" Then
            Return True
        End If


        '==========================================================
        ' 8. DEFAULT
        '
        ' Untuk tahap lain yang belum dinyatakan gagal,
        ' tetap izinkan proses.
        '==========================================================

        Return True

    End Function
    '==========================================================
    ' GET NILAI PROSES TERAKHIR
    '
    ' Digunakan khusus untuk menentukan apakah:
    '
    ' INTERVIEW_HR
    ' atau
    ' INTERVIEW_USER
    '
    ' sudah mendapatkan penilaian.
    '
    ' Jika nilai NULL / kosong:
    '    button Proses Seleksi DISABLE
    '
    ' Jika nilai sudah ada:
    '    button Proses Seleksi ENABLE
    '==========================================================
    Private Function GetNilaiProsesTerakhir(idRekrutmen As Long, idKandidat As Long) As String

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffcnilai FROM saprosesseleksi WHERE ffcidrekrutmen = @IdRekrutmen AND ffcidkandidat = @IdKandidat AND ffctahap IN ('INTERVIEW_HR', 'INTERVIEW_USER') ORDER BY ffcidproses DESC LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@IdRekrutmen", idRekrutmen)
                    cmd.Parameters.AddWithValue("@IdKandidat", idKandidat)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result Is Nothing OrElse IsDBNull(result) Then
                        Return ""
                    End If
                    Return result.ToString().Trim()
                End Using

            End Using

        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil nilai interview." & vbCrLf & ex.Message)
            Return ""

        End Try

    End Function

#End Region


#Region "Private"

    '==========================================================
    ' SETUP STATUS
    '==========================================================
    Private Sub SetupStatus()

        cstatus.Items.Clear()

        cstatus.Items.Add("Semua Status")
        cstatus.Items.Add("Screening")
        cstatus.Items.Add("Test")
        cstatus.Items.Add("Interview")
        cstatus.Items.Add("Penawaran")
        cstatus.Items.Add("Rejected")
        cstatus.Items.Add("Diterima")
        cstatus.Items.Add("Hired")

        cstatus.SelectedIndex = 0

    End Sub

    '==========================================================
    ' LOAD DATA SELEKSI
    '==========================================================
    Private Sub DataSeleksi()

        Try

            '======================================================
            ' 1. HITUNG TOTAL RECORD
            '======================================================

            paginationSeleksi.TotalRecord = GetTotalRecord()


            '======================================================
            ' 2. PASTIKAN CURRENT PAGE VALID
            '======================================================

            If paginationSeleksi.TotalPage <= 0 Then
                paginationSeleksi.CurrentPage = 1

            ElseIf paginationSeleksi.CurrentPage > paginationSeleksi.TotalPage Then
                paginationSeleksi.CurrentPage = paginationSeleksi.TotalPage

            End If


            '======================================================
            ' 3. LOAD DATA
            '======================================================

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT r.ffcidrekrutmen AS `ID Rekrutmen`,r.ffcidkandidat AS `ID Kandidat`, r.ffcidpermintaan AS `ID Permintaan`, k.ffcnokandidat AS `No. Kandidat`,k.ffcnama AS `Nama Kandidat`, p.ffcnopermintaan AS `No. Permintaan`, " &
                    "p.ffckddepart AS `Kode Department`, p.ffckdbagian AS `Kode Bagian`, p.ffckdjabatan AS `Kode Jabatan`, r.ffdapply AS `Tanggal Apply`,r.ffcstatus AS `StatusCode`, " &
                    "CASE r.ffcstatus WHEN 'SCREENING' THEN 'Screening' WHEN 'TEST' THEN 'Test' WHEN 'INTERVIEW' THEN 'Interview' WHEN 'OFFER' THEN 'Penawaran' " &
                    "WHEN 'REJECTED' THEN 'Rejected' WHEN 'ACCEPTED' THEN 'Diterima' WHEN 'HIRED' THEN 'Hired' ELSE r.ffcstatus END AS `Status` FROM sakandidatrekrutmen r " &
                    "INNER JOIN sakandidat k ON k.ffcidkandidat = r.ffcidkandidat INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE 1 = 1 "

                '==================================================
                ' FILTER KEYWORD
                '==================================================

                If _keywordCari <> "" Then

                    sql &=
                        "AND (k.ffcnokandidat LIKE @Keyword OR k.ffcnama LIKE @Keyword OR p.ffcnopermintaan LIKE @Keyword OR p.ffckddepart LIKE @Keyword OR p.ffckdbagian LIKE @Keyword OR p.ffckdjabatan LIKE @Keyword) "

                End If

                '==================================================
                ' FILTER STATUS
                '==================================================

                If _statusCari <> "" Then
                    sql &= "AND r.ffcstatus = @Status "
                End If


                '==================================================
                ' SORTING
                '==================================================

                sql &=
                    "ORDER BY r.ffdapply DESC, r.ffcidrekrutmen DESC "


                '==================================================
                ' PAGINATION
                '==================================================

                sql &=
                    "LIMIT @Limit OFFSET @Offset "


                Using cmd As New MySqlCommand(sql, conn)

                    '==================================================
                    ' PARAMETER KEYWORD
                    '==================================================

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@Keyword", "%" & _keywordCari & "%")
                    End If

                    '==================================================
                    ' PARAMETER STATUS
                    '==================================================

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@Status", _statusCari)
                    End If

                    '==================================================
                    ' PARAMETER PAGINATION
                    '==================================================
                    cmd.Parameters.AddWithValue("@Limit", paginationSeleksi.PageSize)
                    cmd.Parameters.AddWithValue("@Offset", paginationSeleksi.Offset)

                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvSeleksi.DataSource = dt

                    End Using

                End Using

            End Using


            '======================================================
            ' 4. FORMAT GRID
            '======================================================

            FormatDataGridView()


            '======================================================
            ' 5. RESET SELECTION
            '======================================================

            _idRekrutmenTerpilih = 0
            _idKandidatTerpilih = 0
            _statusTerpilih = ""


            '======================================================
            ' 6. UPDATE PAGINATION INFO
            '======================================================

            UpdatePaginationInfo()


            '======================================================
            ' 7. UPDATE ACTION BUTTON
            '======================================================

            UpdateActionButtons()


        Catch ex As Exception

            PesanPopupError("Error", "Gagal memuat data seleksi." & vbCrLf & ex.Message)

        End Try

    End Sub


    '==========================================================
    ' UPDATE INFORMASI PAGINATION
    '==========================================================
    Private Sub UpdatePaginationInfo()
        lblInfo.Text = String.Format("Menampilkan {0} - {1} dari {2} Data", paginationSeleksi.StartRecord, paginationSeleksi.EndRecord, paginationSeleksi.TotalRecord)
    End Sub

    '==========================================================
    ' SETUP DATA GRID VIEW
    '==========================================================
    Private Sub SetupDataGridView()

        ApplyGridTheme(dgvSeleksi)

        With dgvSeleksi
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End With

    End Sub

    '==========================================================
    ' FORMAT DATA GRID VIEW
    '==========================================================
    Private Sub FormatDataGridView()

        If dgvSeleksi.Columns.Count = 0 Then
            Return
        End If


        '======================================================
        ' HIDDEN COLUMN
        '======================================================

        If dgvSeleksi.Columns.Contains("ID Rekrutmen") Then
            dgvSeleksi.Columns("ID Rekrutmen").Visible = False
        End If


        If dgvSeleksi.Columns.Contains("ID Kandidat") Then
            dgvSeleksi.Columns("ID Kandidat").Visible = False
        End If


        If dgvSeleksi.Columns.Contains("ID Permintaan") Then
            dgvSeleksi.Columns("ID Permintaan").Visible = False
        End If


        If dgvSeleksi.Columns.Contains("Kode Department") Then
            dgvSeleksi.Columns("Kode Department").Visible = False
        End If


        If dgvSeleksi.Columns.Contains("Kode Bagian") Then
            dgvSeleksi.Columns("Kode Bagian").Visible = False
        End If


        If dgvSeleksi.Columns.Contains("Kode Jabatan") Then
            dgvSeleksi.Columns("Kode Jabatan").Visible = False
        End If


        If dgvSeleksi.Columns.Contains("StatusCode") Then
            dgvSeleksi.Columns("StatusCode").Visible = False

        End If


        '======================================================
        ' LEBAR KOLOM
        '======================================================

        If dgvSeleksi.Columns.Contains("No. Kandidat") Then
            dgvSeleksi.Columns("No. Kandidat").Width = 110
        End If


        If dgvSeleksi.Columns.Contains("Nama Kandidat") Then
            dgvSeleksi.Columns("Nama Kandidat").Width = 180
        End If


        If dgvSeleksi.Columns.Contains("No. Permintaan") Then
            dgvSeleksi.Columns("No. Permintaan").Width = 140
        End If


        If dgvSeleksi.Columns.Contains("Tanggal Apply") Then
            dgvSeleksi.Columns("Tanggal Apply").Width = 110
        End If


        If dgvSeleksi.Columns.Contains("Status") Then
            dgvSeleksi.Columns("Status").Width = 120
        End If


        '======================================================
        ' FORMAT TANGGAL
        '======================================================

        If dgvSeleksi.Columns.Contains("Tanggal Apply") Then
            dgvSeleksi.Columns("Tanggal Apply").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
        End If


        '======================================================
        ' ALIGNMENT
        '======================================================

        If dgvSeleksi.Columns.Contains("No. Kandidat") Then
            dgvSeleksi.Columns("No. Kandidat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If


        If dgvSeleksi.Columns.Contains("No. Permintaan") Then
            dgvSeleksi.Columns("No. Permintaan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If


        If dgvSeleksi.Columns.Contains("Tanggal Apply") Then
            dgvSeleksi.Columns("Tanggal Apply").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If


        If dgvSeleksi.Columns.Contains("Status") Then
            dgvSeleksi.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If


        '======================================================
        ' THEME GRID
        '======================================================

        With dgvSeleksi

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 95, 209)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 95, 209)
            .ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White
            .ColumnHeadersHeight = 24
            .DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
            .GridColor = Color.FromArgb(229, 231, 235)
        End With

    End Sub

    '==========================================================
    ' SEARCH ENTER
    '==========================================================
    Private Sub tPencarian_KeyDown(sender As Object, e As KeyEventArgs) Handles tPencarian.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            bCari.PerformClick()

        End If

    End Sub


    '==========================================================
    ' RESET
    '==========================================================
    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click

        '======================================================
        ' CLEAR SEARCH
        '======================================================

        tPencarian.Clear()

        _keywordCari = ""

        _statusCari = ""

        '======================================================
        ' RESET STATUS
        '======================================================

        cstatus.SelectedIndex = 0

        '======================================================
        ' PAGE 1
        '======================================================

        paginationSeleksi.CurrentPage = 1

        '======================================================
        ' LOAD ULANG
        '======================================================

        DataSeleksi()

    End Sub

    '==========================================================
    ' PAGE CHANGED
    '==========================================================
    Private Sub paginationSeleksi_PageChanged(sender As Object, e As EventArgs) Handles paginationSeleksi.PageChanged
        DataSeleksi()
    End Sub

    '==========================================================
    ' UPDATE ACTION BUTTON
    '==========================================================
    Private Sub UpdateActionButtons()

        '======================================================
        ' DEFAULT
        '======================================================

        bDetail.Enabled = False
        bProsesSeleksi.Enabled = False

        '======================================================
        ' TIDAK ADA DATA
        '======================================================

        If _idRekrutmenTerpilih <= 0 Then
            Return
        End If


        '======================================================
        ' DETAIL SELALU BOLEH
        '======================================================

        bDetail.Enabled = True

        '======================================================
        ' CEK WORKFLOW
        '======================================================

        If BolehProsesSeleksi() Then
            bProsesSeleksi.Enabled = True
        Else
            bProsesSeleksi.Enabled = False
        End If

    End Sub

#End Region

    '==========================================================
    ' FORM LOAD
    '==========================================================
    Private Sub uf_seleksi_Load(sender As Object, e As EventArgs) Handles Me.Load

        '======================================================
        ' SETUP GRID
        '======================================================

        SetupDataGridView()

        '======================================================
        ' SETUP STATUS
        '======================================================

        SetupStatus()

        '======================================================
        ' LOAD DATA
        '======================================================

        DataSeleksi()

    End Sub


    '==========================================================
    ' GRID CELL CLICK
    '==========================================================
    Private Sub dgvSeleksi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSeleksi.CellClick

        If e.RowIndex < 0 Then
            _idRekrutmenTerpilih = 0
            _idKandidatTerpilih = 0
            _statusTerpilih = ""
            UpdateActionButtons()
            Return
        End If

        Dim row As DataGridViewRow = dgvSeleksi.Rows(e.RowIndex)

        '======================================================
        ' ID REKRUTMEN
        '======================================================

        If row.Cells("ID Rekrutmen").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ID Rekrutmen").Value) Then
            Long.TryParse(row.Cells("ID Rekrutmen").Value.ToString(), _idRekrutmenTerpilih)
        Else
            _idRekrutmenTerpilih = 0
        End If


        '======================================================
        ' ID KANDIDAT
        '======================================================

        If row.Cells("ID Kandidat").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ID Kandidat").Value) Then
            Long.TryParse(row.Cells("ID Kandidat").Value.ToString(), _idKandidatTerpilih)
        Else
            _idKandidatTerpilih = 0
        End If


        '======================================================
        ' STATUS
        '======================================================

        If row.Cells("StatusCode").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("StatusCode").Value) Then
            _statusTerpilih = row.Cells("StatusCode").Value.ToString().Trim().ToUpper()
        Else
            _statusTerpilih = ""
        End If


        '======================================================
        ' UPDATE BUTTON
        '======================================================

        UpdateActionButtons()

    End Sub


    '==========================================================
    ' DETAIL KANDIDAT
    '==========================================================
    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click
        Using frm As New frmDetailSeleksi()
            frm.IdKandidat =
                _idKandidatTerpilih
            frm.IdRekrutmen =
                _idRekrutmenTerpilih
            frm.ShowDialog()
        End Using

    End Sub


    '==========================================================
    ' PROSES SELEKSI
    '==========================================================
    Private Sub bProsesSeleksi_Click(sender As Object, e As EventArgs) Handles bProsesSeleksi.Click

        '======================================================
        ' VALIDASI REKRUTMEN
        '======================================================

        If _idRekrutmenTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat terlebih dahulu.")
            Return
        End If

        '======================================================
        ' VALIDASI KANDIDAT
        '======================================================

        If _idKandidatTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data kandidat tidak ditemukan.")
            Return
        End If


        '======================================================
        ' CEK STATUS FINAL
        '======================================================

        Select Case _statusTerpilih

            Case "ACCEPTED", "HIRED", "REJECTED"
                PesanPopupPeringatan("Informasi", "Kandidat dengan status " & GetStatusDisplay(_statusTerpilih) & " tidak dapat diproses kembali.")
                Return
        End Select


        '======================================================
        ' CEK BOLEH PROSES
        '======================================================

        If Not BolehProsesSeleksi() Then
            PesanPopupPeringatan("Informasi", "Kandidat belum dapat diproses ke tahap berikutnya.")

            Return

        End If


        '======================================================
        ' TENTUKAN TAHAP AWAL
        '======================================================

        Dim tahapAwal As String = GetTahapAwalProses()
        '======================================================
        ' BUKA FORM PROSES SELEKSI
        '======================================================

        Try
            Using frm As New frmProsesSeleksi()
                frm.IdKandidat = _idKandidatTerpilih
                frm.IdRekrutmen = _idRekrutmenTerpilih
                frm.TahapAwal = tahapAwal
                frm.ShowDialog()

            End Using


            '==================================================
            ' REFRESH DATA SETELAH FORM DITUTUP
            '==================================================

            DataSeleksi()

        Catch ex As Exception
            PesanPopupError("Error", "Gagal membuka form proses seleksi." & vbCrLf & ex.Message)
        End Try

    End Sub


    '==========================================================
    ' CARI
    '==========================================================
    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click

        '======================================================
        ' KEYWORD
        '======================================================
        _keywordCari = tPencarian.Text.Trim()
        '======================================================
        ' STATUS
        '======================================================

        _statusCari = GetStatusCode()

        '======================================================
        ' KEMBALI KE PAGE 1
        '======================================================

        paginationSeleksi.CurrentPage = 1

        '======================================================
        ' LOAD DATA
        '======================================================

        DataSeleksi()

    End Sub

End Class