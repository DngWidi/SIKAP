Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class uf_penilaianinterview
    '==========================================================
    ' PENCARIAN
    '==========================================================
    Private _keywordCari As String = ""
    Private _tahapCari As String = ""
    Private _statusCari As String = ""

    '==========================================================
    ' ID DATA TERPILIH
    '==========================================================
    Private _idProsesTerpilih As Long = 0
    Private _idRekrutmenTerpilih As Long = 0
    Private _idKandidatTerpilih As Long = 0

    '==========================================================
    ' PAGINATION
    '==========================================================
    Private CurrentPage As Integer = 1
    Private PageSize As Integer = 10
    Private TotalRecord As Integer = 0
    Private TotalPage As Integer = 0
    Private Offset As Integer = 0
    Private Sub ResetDataTerpilih()

        _idProsesTerpilih = 0
        _idRekrutmenTerpilih = 0
        _idKandidatTerpilih = 0

        dgvPenilaian.ClearSelection()

    End Sub
    Private Sub SetupComboTahap()

        cTahap.Items.Clear()

        cTahap.Items.Add("Semua Tahap")
        cTahap.Items.Add("INTERVIEW_HR")
        cTahap.Items.Add("INTERVIEW_USER")

        cTahap.SelectedIndex = 0

    End Sub
    Private Sub SetupComboStatus()

        cstatus.Items.Clear()

        cstatus.Items.Add("Semua Status")
        cstatus.Items.Add("WAITING")
        cstatus.Items.Add("SCHEDULED")
        cstatus.Items.Add("PROCESS")
        cstatus.Items.Add("PASSED")
        cstatus.Items.Add("FAILED")
        cstatus.Items.Add("CANCELLED")

        cstatus.SelectedIndex = 0

    End Sub
    Private Sub SetupGrid()

        '==========================================================
        ' MATIKAN GENERATE OTOMATIS
        '==========================================================

        dgvPenilaian.AutoGenerateColumns = False


        '==========================================================
        ' HAPUS SEMUA KOLOM YANG ADA
        '==========================================================

        dgvPenilaian.Columns.Clear()


        '==========================================================
        ' ID PROSES
        '==========================================================

        Dim colIdProses As New DataGridViewTextBoxColumn()

        With colIdProses
            .Name = "ffcidproses"
            .HeaderText = "ID Proses"
            .Visible = False
        End With

        dgvPenilaian.Columns.Add(colIdProses)


        '==========================================================
        ' ID REKRUTMEN
        '==========================================================

        Dim colIdRekrutmen As New DataGridViewTextBoxColumn()

        With colIdRekrutmen
            .Name = "ffcidrekrutmen"
            .HeaderText = "ID Recruitment"
            .Visible = False
        End With

        dgvPenilaian.Columns.Add(colIdRekrutmen)


        '==========================================================
        ' ID KANDIDAT
        '==========================================================

        Dim colIdKandidat As New DataGridViewTextBoxColumn()

        With colIdKandidat
            .Name = "ffcidkandidat"
            .HeaderText = "ID Kandidat"
            .Visible = False
        End With

        dgvPenilaian.Columns.Add(colIdKandidat)


        '==========================================================
        ' NO KANDIDAT
        '==========================================================

        Dim colNoKandidat As New DataGridViewTextBoxColumn()

        With colNoKandidat
            .Name = "ffcnokandidat"
            .HeaderText = "No. Kandidat"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 110
        End With

        dgvPenilaian.Columns.Add(colNoKandidat)


        '==========================================================
        ' NAMA KANDIDAT
        '==========================================================

        Dim colNama As New DataGridViewTextBoxColumn()

        With colNama
            .Name = "ffcnama"
            .HeaderText = "Nama Kandidat"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 180
        End With

        dgvPenilaian.Columns.Add(colNama)


        '==========================================================
        ' DEPARTMENT
        '==========================================================

        Dim colDepartment As New DataGridViewTextBoxColumn()

        With colDepartment
            .Name = "department"
            .HeaderText = "Department"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 120
        End With

        dgvPenilaian.Columns.Add(colDepartment)


        '==========================================================
        ' BAGIAN
        '==========================================================

        Dim colBagian As New DataGridViewTextBoxColumn()

        With colBagian
            .Name = "bagian"
            .HeaderText = "Bagian"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 120
        End With

        dgvPenilaian.Columns.Add(colBagian)


        '==========================================================
        ' JABATAN
        '==========================================================

        Dim colJabatan As New DataGridViewTextBoxColumn()

        With colJabatan
            .Name = "jabatan"
            .HeaderText = "Jabatan"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 120
        End With

        dgvPenilaian.Columns.Add(colJabatan)


        '==========================================================
        ' TAHAP
        '==========================================================

        Dim colTahap As New DataGridViewTextBoxColumn()

        With colTahap
            .Name = "ffctahap"
            .HeaderText = "Tahap"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 130
        End With

        dgvPenilaian.Columns.Add(colTahap)


        '==========================================================
        ' JADWAL
        '==========================================================

        Dim colJadwal As New DataGridViewTextBoxColumn()

        With colJadwal
            .Name = "ffdjadwal"
            .HeaderText = "Jadwal"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 130
        End With

        dgvPenilaian.Columns.Add(colJadwal)


        '==========================================================
        ' INTERVIEWER
        '==========================================================

        Dim colInterviewer As New DataGridViewTextBoxColumn()

        With colInterviewer
            .Name = "ffcinterviewer"
            .HeaderText = "Interviewer"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 150
        End With

        dgvPenilaian.Columns.Add(colInterviewer)


        '==========================================================
        ' STATUS
        '==========================================================

        Dim colStatus As New DataGridViewTextBoxColumn()

        With colStatus
            .Name = "ffcstatus"
            .HeaderText = "Status"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 100
        End With

        dgvPenilaian.Columns.Add(colStatus)


        '==========================================================
        ' NILAI
        '==========================================================

        Dim colNilai As New DataGridViewTextBoxColumn()

        With colNilai
            .Name = "ffcnilai"
            .HeaderText = "Nilai"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 70
        End With

        dgvPenilaian.Columns.Add(colNilai)


        '==========================================================
        ' HASIL
        '==========================================================

        Dim colHasil As New DataGridViewTextBoxColumn()

        With colHasil
            .Name = "ffchasil"
            .HeaderText = "Hasil"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 180
        End With

        dgvPenilaian.Columns.Add(colHasil)


        '==========================================================
        ' KONFIGURASI GRID
        '==========================================================

        With dgvPenilaian

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True

            .SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

            .MultiSelect = False

            .RowHeadersVisible = False

        End With


        '==========================================================
        ' APPLY THEME
        '==========================================================

        ApplyGridTheme(dgvPenilaian)


    End Sub
    Private Sub LoadData()

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                '==========================================================
                ' RESET GRID
                '==========================================================

                dgvPenilaian.Rows.Clear()

                ResetDataTerpilih()


                '==========================================================
                ' KONDISI FILTER
                '==========================================================

                Dim kondisi As String = ""

                kondisi = " WHERE s.ffctahap IN ('INTERVIEW_HR','INTERVIEW_USER') "


                '==========================================================
                ' SEARCH
                '==========================================================

                If Not String.IsNullOrWhiteSpace(_keywordCari) Then

                    kondisi &= " AND (k.ffcnokandidat LIKE @keyword OR k.ffcnama LIKE @keyword OR CAST(r.ffcidrekrutmen AS CHAR) LIKE @keyword)"

                End If


                '==========================================================
                ' FILTER TAHAP
                '==========================================================

                If Not String.IsNullOrWhiteSpace(_tahapCari) Then

                    kondisi &= " AND s.ffctahap = @tahap"

                End If


                '==========================================================
                ' FILTER STATUS
                '==========================================================

                If Not String.IsNullOrWhiteSpace(_statusCari) Then

                    kondisi &= " AND s.ffcstatus = @status"

                End If


                '==========================================================
                ' HITUNG TOTAL RECORD
                '==========================================================

                Dim sqlCount As String = "SELECT COUNT(*) FROM saprosesseleksi s INNER JOIN sakandidatrekrutmen r ON s.ffcidrekrutmen = r.ffcidrekrutmen INNER JOIN sakandidat k ON s.ffcidkandidat = k.ffcidkandidat " &
                "LEFT JOIN sapermintaankaryawan p ON r.ffcidpermintaan = p.ffcidpermintaan " & kondisi

                Using cmdCount As New MySqlCommand(sqlCount, conn)
                    If Not String.IsNullOrWhiteSpace(_keywordCari) Then
                        cmdCount.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
                    End If
                    If Not String.IsNullOrWhiteSpace(_tahapCari) Then
                        cmdCount.Parameters.AddWithValue("@tahap", _tahapCari)
                    End If
                    If Not String.IsNullOrWhiteSpace(_statusCari) Then
                        cmdCount.Parameters.AddWithValue("@status", _statusCari)
                    End If
                    TotalRecord = Convert.ToInt32(cmdCount.ExecuteScalar())
                End Using


                '==========================================================
                ' HITUNG TOTAL PAGE
                '==========================================================

                If TotalRecord > 0 Then
                    TotalPage = CInt(Math.Ceiling(TotalRecord / CDbl(PageSize)))
                Else
                    TotalPage = 1
                End If


                '==========================================================
                ' PASTIKAN CURRENT PAGE VALID
                '==========================================================

                If CurrentPage < 1 Then
                    CurrentPage = 1
                End If

                If CurrentPage > TotalPage Then
                    CurrentPage = TotalPage
                End If


                '==========================================================
                ' HITUNG OFFSET
                '==========================================================

                Offset = (CurrentPage - 1) * PageSize


                '==========================================================
                ' QUERY DATA
                '==========================================================

                Dim sql As String = "SELECT s.ffcidproses, s.ffcidrekrutmen, s.ffcidkandidat, k.ffcnokandidat, k.ffcnama, p.ffckddepart AS department, p.ffckdbagian AS bagian,p.ffckdjabatan AS jabatan, " &
                "s.ffctahap, s.ffdjadwal, s.ffcinterviewer, s.ffcstatus,s.ffcnilai,s.ffchasil FROM saprosesseleksi s INNER JOIN sakandidatrekrutmen r ON s.ffcidrekrutmen = r.ffcidrekrutmen " &
                "INNER JOIN sakandidat k ON s.ffcidkandidat = k.ffcidkandidat LEFT JOIN sapermintaankaryawan p ON r.ffcidpermintaan = p.ffcidpermintaan " & kondisi & " ORDER BY " &
                "CASE WHEN s.ffdjadwal IS NULL THEN 1 ELSE 0 END, s.ffdjadwal DESC, s.ffcidproses DESC LIMIT @limit OFFSET @offset"


                Using cmd As New MySqlCommand(sql, conn)

                    '======================================================
                    ' PARAMETER FILTER
                    '======================================================

                    If Not String.IsNullOrWhiteSpace(_keywordCari) Then
                        cmd.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
                    End If


                    If Not String.IsNullOrWhiteSpace(_tahapCari) Then
                        cmd.Parameters.AddWithValue("@tahap", _tahapCari)
                    End If

                    If Not String.IsNullOrWhiteSpace(_statusCari) Then
                        cmd.Parameters.AddWithValue("@status", _statusCari)
                    End If


                    '======================================================
                    ' PAGINATION
                    '======================================================
                    cmd.Parameters.AddWithValue("@limit", PageSize)
                    cmd.Parameters.AddWithValue("@offset", Offset)


                    '======================================================
                    ' BACA DATA
                    '======================================================

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        While rd.Read()

                            Dim rowIndex As Integer = dgvPenilaian.Rows.Add()
                            Dim row As DataGridViewRow = dgvPenilaian.Rows(rowIndex)

                            '==================================================
                            ' ID
                            '==================================================
                            row.Cells("ffcidproses").Value = rd("ffcidproses")
                            row.Cells("ffcidrekrutmen").Value = rd("ffcidrekrutmen")
                            row.Cells("ffcidkandidat").Value = rd("ffcidkandidat")


                            '==================================================
                            ' KANDIDAT
                            '==================================================
                            row.Cells("ffcnokandidat").Value = If(IsDBNull(rd("ffcnokandidat")), "", rd("ffcnokandidat").ToString())
                            row.Cells("ffcnama").Value = If(IsDBNull(rd("ffcnama")), "", rd("ffcnama").ToString())


                            '==================================================
                            ' DEPARTMENT
                            '==================================================
                            row.Cells("department").Value = If(IsDBNull(rd("department")), "", rd("department").ToString())


                            '==================================================
                            ' BAGIAN
                            '==================================================
                            row.Cells("bagian").Value = If(IsDBNull(rd("bagian")), "", rd("bagian").ToString())

                            '==================================================
                            ' JABATAN
                            '==================================================
                            row.Cells("jabatan").Value = If(IsDBNull(rd("jabatan")), "", rd("jabatan").ToString())


                            '==================================================
                            ' TAHAP
                            '==================================================

                            row.Cells("ffctahap").Value = If(IsDBNull(rd("ffctahap")), "", rd("ffctahap").ToString())


                            '==================================================
                            ' JADWAL
                            '==================================================

                            If IsDBNull(rd("ffdjadwal")) Then
                                row.Cells("ffdjadwal").Value = ""
                            Else
                                row.Cells("ffdjadwal").Value = Convert.ToDateTime(rd("ffdjadwal")).ToString("dd-MM-yyyy HH:mm")
                            End If


                            '==================================================
                            ' INTERVIEWER
                            '==================================================

                            row.Cells("ffcinterviewer").Value = If(IsDBNull(rd("ffcinterviewer")), "", rd("ffcinterviewer").ToString())

                            '==================================================
                            ' STATUS
                            '==================================================

                            row.Cells("ffcstatus").Value = If(IsDBNull(rd("ffcstatus")), "", rd("ffcstatus").ToString())

                            '==================================================
                            ' NILAI
                            '==================================================

                            row.Cells("ffcnilai").Value = If(IsDBNull(rd("ffcnilai")), "", rd("ffcnilai").ToString())
                            '==================================================
                            ' HASIL
                            '==================================================

                            row.Cells("ffchasil").Value = If(IsDBNull(rd("ffchasil")), "", rd("ffchasil").ToString())
                        End While
                    End Using
                End Using
            End Using

            '==============================================================
            ' UPDATE INFO PAGINATION
            '==============================================================

            UpdateInfoPagination()


        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat data penilaian interview: " & ex.Message)
        End Try

    End Sub
    Private Sub UpdateInfoPagination()

        If TotalRecord <= 0 Then
            lblInfo.Text = "Menampilkan 0 - 0 dari 0 Data"
            Return
        End If
        Dim startRecord As Integer = ((CurrentPage - 1) * PageSize) + 1
        Dim endRecord As Integer = Math.Min(CurrentPage * PageSize, TotalRecord)
        lblInfo.Text = "Menampilkan " & startRecord & " - " & endRecord & " dari " & TotalRecord & " Data"

    End Sub
    Private Sub cTahap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTahap.SelectedIndexChanged

        If cTahap.SelectedIndex <= 0 Then
            _tahapCari = ""
        Else

            _tahapCari = cTahap.Text.Trim().ToUpper()

        End If
        CurrentPage = 1
        Offset = 0

        LoadData()

    End Sub
    Private Sub cstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cstatus.SelectedIndexChanged

        If cstatus.SelectedIndex <= 0 Then
            _statusCari = ""
        Else
            _statusCari = cstatus.Text.Trim().ToUpper()
        End If


        CurrentPage = 1
        Offset = 0

        LoadData()

    End Sub
    Private Sub dgvPenilaian_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPenilaian.CellClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        Dim row As DataGridViewRow = dgvPenilaian.Rows(e.RowIndex)

        If row.Cells("ffcidproses").Value Is Nothing Then
            Exit Sub
        End If

        _idProsesTerpilih = Convert.ToInt64(row.Cells("ffcidproses").Value)
        _idRekrutmenTerpilih = Convert.ToInt64(row.Cells("ffcidrekrutmen").Value)
        _idKandidatTerpilih = Convert.ToInt64(row.Cells("ffcidkandidat").Value)

    End Sub
    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click

        If _idProsesTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat terlebih dahulu.")
            Exit Sub

        End If


        Dim frm As New frmPenilaianInterviewAdd()
        frm.IdProses = _idProsesTerpilih
        frm.IdRekrutmen = _idRekrutmenTerpilih
        frm.IdKandidat = _idKandidatTerpilih
        frm.ModeForm = "Edit"

        If frm.ShowDialog() = DialogResult.OK Then
            LoadData()
            _idProsesTerpilih = 0
            _idRekrutmenTerpilih = 0
            _idKandidatTerpilih = 0

        End If

    End Sub
    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click

        If _idProsesTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat terlebih dahulu.")
            Exit Sub

        End If
        Dim frm As New frmPenilaianInterviewAdd()
        frm.IdProses = _idProsesTerpilih
        frm.IdRekrutmen = _idRekrutmenTerpilih
        frm.IdKandidat = _idKandidatTerpilih
        frm.ModeForm = "View"
        frm.ShowDialog()

    End Sub
    Private Sub dgvPenilaian_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPenilaian.CellDoubleClick

        If e.RowIndex < 0 Then
            Exit Sub
        End If
        dgvPenilaian.Rows(e.RowIndex).Selected = True
        dgvPenilaian_CellClick(sender, e)
        bEdit.PerformClick()
    End Sub
    Private Sub uf_penilaianinterview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            SetupComboTahap()
            SetupComboStatus()

            CurrentPage = 1
            Offset = 0
            LoadData()
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal membuka menu Penilaian Interview: " & ex.Message)

        End Try

    End Sub


End Class
