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
    ' STATUS YANG DIPILIH
    '==========================================================
    Private _statusTerpilih As String = ""
    Private _tahapAwal As String = ""
#Region "Function"
    '==========================================================
    ' GET TOTAL RECORD
    '==========================================================
    Private Function GetTotalRecord() As Integer

        Try

            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "SELECT COUNT(*) FROM sakandidatrekrutmen r INNER JOIN sakandidat k ON k.ffcidkandidat = r.ffcidkandidat INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE 1 = 1 "
                '==================================================
                ' FILTER KEYWORD
                '==================================================

                If _keywordCari <> "" Then

                    sql &= "AND (k.ffcnokandidat LIKE @Keyword OR k.ffcnama LIKE @Keyword OR p.ffcnopermintaan LIKE @Keyword OR p.ffckddepart LIKE @Keyword OR p.ffckdbagian LIKE @Keyword OR p.ffckdjabatan LIKE @Keyword) "

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
#End Region
#Region "Private"
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

            paginationSeleksi.TotalRecord =
                GetTotalRecord()


            '======================================================
            ' 2. PASTIKAN CURRENT PAGE VALID
            '======================================================

            If paginationSeleksi.TotalPage <= 0 Then

                paginationSeleksi.CurrentPage = 1

            ElseIf paginationSeleksi.CurrentPage >
                   paginationSeleksi.TotalPage Then

                paginationSeleksi.CurrentPage =
                    paginationSeleksi.TotalPage

            End If


            '======================================================
            ' 3. LOAD DATA
            '======================================================

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT r.ffcidrekrutmen AS `ID Rekrutmen`, r.ffcidkandidat AS `ID Kandidat`, " &
                    "r.ffcidpermintaan AS `ID Permintaan`, k.ffcnokandidat AS `No. Kandidat`, k.ffcnama AS `Nama Kandidat`, p.ffcnopermintaan AS `No. Permintaan`, p.ffckddepart AS `Kode Department`, p.ffckdbagian AS `Kode Bagian`, " &
                    "p.ffckdjabatan AS `Kode Jabatan`,r.ffdapply AS `Tanggal Apply`, r.ffcstatus AS `StatusCode`, CASE r.ffcstatus WHEN 'SCREENING' THEN 'Screening' WHEN 'TEST' THEN 'Test' WHEN 'INTERVIEW' THEN 'Interview' " &
                    "WHEN 'OFFER' THEN 'Penawaran' WHEN 'REJECTED' THEN 'Rejected' WHEN 'ACCEPTED' THEN 'Diterima' WHEN 'HIRED' THEN 'Hired' ELSE r.ffcstatus END AS `Status` " &
                    "FROM sakandidatrekrutmen r INNER JOIN sakandidat k ON k.ffcidkandidat = r.ffcidkandidat INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE 1 = 1 "

                '==================================================
                ' FILTER KEYWORD
                '==================================================

                If _keywordCari <> "" Then
                    sql &= "AND (k.ffcnokandidat LIKE @Keyword OR k.ffcnama LIKE @Keyword OR p.ffcnopermintaan LIKE @Keyword OR p.ffckddepart LIKE @Keyword OR p.ffckdbagian LIKE @Keyword OR p.ffckdjabatan LIKE @Keyword) "
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
                sql &= "ORDER BY r.ffdapply DESC, r.ffcidrekrutmen DESC "

                '==================================================
                ' PAGINATION
                '==================================================
                sql &= "LIMIT @Limit OFFSET @Offset "

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
    Private Sub SetupDataGridView()

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
            ' --- TAMBAHKAN DUA BARIS INI ---
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
        ' PROSES SELEKSI
        '======================================================

        Select Case _statusTerpilih

            Case "SCREENING"
                bProsesSeleksi.Enabled = True
            Case "TEST"
                bProsesSeleksi.Enabled = True
            Case "INTERVIEW"
                'Untuk tahap berikutnya
                'akan diproses melalui
                'Penilaian Interview
                bProsesSeleksi.Enabled = False
            Case "OFFER"
                bProsesSeleksi.Enabled = False
            Case "ACCEPTED"
                bProsesSeleksi.Enabled = False
            Case "HIRED"
                bProsesSeleksi.Enabled = False
            Case "REJECTED"
                bProsesSeleksi.Enabled = False

        End Select

    End Sub
#End Region

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

        If row.Cells("ID Kandidat").Value IsNot Nothing AndAlso
           Not IsDBNull(row.Cells("ID Kandidat").Value) Then
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

        If _idKandidatTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat terlebih dahulu.")
            Return

        End If


        '======================================================
        ' UNTUK SEMENTARA
        '======================================================
        '
        ' Di sini nanti kita buka:
        '
        ' frmKandidatAdd
        '
        ' dalam Mode View.
        '
        ' Saya sengaja belum menuliskan constructor /
        ' property-nya karena kita akan menyesuaikan
        ' dengan frmKandidatAdd versi terakhir Anda.
        '
        '======================================================
        PesanPopupPeringatan("Informasi", "Detail kandidat akan kita hubungkan ke frmKandidatAdd pada tahap berikutnya.")
    End Sub


    '==========================================================
    ' PROSES SELEKSI
    '==========================================================

    '==========================================================
    ' PROSES SELEKSI
    '==========================================================

    Private Sub bProsesSeleksi_Click(sender As Object, e As EventArgs) Handles bProsesSeleksi.Click


        If _idRekrutmenTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat terlebih dahulu.")
            Return

        End If




        If _idKandidatTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data kandidat tidak ditemukan.")
            Return

        End If



        Dim tahapAwal As String = ""

        Select Case _statusTerpilih

            Case "SCREENING"

                tahapAwal = "SCREENING"

            Case "TEST"

                tahapAwal = "TEST"

            Case Else
                PesanPopupPeringatan("Peringatan", "Kandidat tidak dapat diproses dari status " & GetStatusDisplay(_statusTerpilih) & ".")

                Return

        End Select


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
