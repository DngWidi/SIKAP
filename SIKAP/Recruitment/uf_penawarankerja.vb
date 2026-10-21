Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class uf_penawarankerja

    '==========================================================
    ' VARIABLE PENCARIAN
    '==========================================================
    Private _keywordCari As String = ""
    Private _statusCari As String = ""
    Private _tanggalDari As DateTime
    Private _tanggalSampai As DateTime


    Private Function CreateRoundedRectangle(rect As Rectangle, radius As Integer) As Drawing2D.GraphicsPath

        Dim path As New Drawing2D.GraphicsPath()

        Dim diameter As Integer = radius * 2

        Dim arc As New Rectangle(rect.X, rect.Y, diameter, diameter)

        path.AddArc(arc, 180, 90)

        arc.X = rect.Right - diameter

        path.AddArc(arc, 270, 90)

        arc.Y = rect.Bottom - diameter

        path.AddArc(arc, 0, 90)

        arc.X = rect.X
        path.AddArc(arc, 90, 90)

        path.CloseFigure()

        Return path
    End Function

    '==========================================================
    ' FORM LOAD
    '==========================================================
    Private Sub uf_penawarankerja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetupStatusFilter()
        SetupDataGridView()

        dtpDari.Value =
        New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)

        dtpSampai.Value = DateTime.Now

        _tanggalDari = dtpDari.Value.Date
        _tanggalSampai = dtpSampai.Value.Date

        paginationPenawaran.CurrentPage = 1
        paginationPenawaran.PageSize = 10

        LoadData()

    End Sub

    '==========================================================
    ' SETUP STATUS FILTER
    '==========================================================
    Private Sub SetupStatusFilter()

        cstatus.Items.Clear()

        cstatus.Items.Add("Semua")
        cstatus.Items.Add("WAITING")
        cstatus.Items.Add("ACCEPTED")
        cstatus.Items.Add("REJECTED")
        cstatus.Items.Add("CANCELLED")

        cstatus.SelectedIndex = 0

    End Sub

    '==========================================================
    ' SETUP DATAGRIDVIEW
    '==========================================================

    Private Sub SetupDataGridView()

        dgvPenawaranKerja.Columns.Clear()

        With dgvPenawaranKerja

            '==================================================
            ' BASIC
            '==================================================
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

            '==================================================
            ' NO
            '==================================================
            Dim colNo As New DataGridViewTextBoxColumn()

            With colNo
                .Name = "colNo"
                .HeaderText = "No"
                .Width = 50
                .ReadOnly = True
                .SortMode =
                DataGridViewColumnSortMode.NotSortable

                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter
            End With

            .Columns.Add(colNo)


            '==================================================
            ' ID OFFERING - HIDDEN
            '==================================================
            Dim colIdOffering As New DataGridViewTextBoxColumn()

            With colIdOffering
                .Name = "ffcidoffering"
                .DataPropertyName = "ffcidoffering"
                .Visible = False
            End With

            .Columns.Add(colIdOffering)


            '==================================================
            ' ID KANDIDAT - HIDDEN
            '==================================================
            Dim colIdKandidat As New DataGridViewTextBoxColumn()

            With colIdKandidat
                .Name = "ffcidkandidat"
                .DataPropertyName = "ffcidkandidat"
                .Visible = False
            End With

            .Columns.Add(colIdKandidat)


            '==================================================
            ' ID REKRUTMEN - HIDDEN
            '==================================================
            Dim colIdRekrutmen As New DataGridViewTextBoxColumn()

            With colIdRekrutmen
                .Name = "ffcidrekrutmen"
                .DataPropertyName = "ffcidrekrutmen"
                .Visible = False
            End With

            .Columns.Add(colIdRekrutmen)


            '==================================================
            ' NO PENAWARAN
            '==================================================
            Dim colNoPenawaran As New DataGridViewTextBoxColumn()

            With colNoPenawaran
                .Name = "ffcnopenawaran"
                .HeaderText = "No Penawaran"
                .DataPropertyName = "ffcnopenawaran"
                .Width = 140
            End With

            .Columns.Add(colNoPenawaran)


            '==================================================
            ' NO KANDIDAT
            '==================================================
            Dim colNoKandidat As New DataGridViewTextBoxColumn()

            With colNoKandidat
                .Name = "ffcnokandidat"
                .HeaderText = "No Kandidat"
                .DataPropertyName = "ffcnokandidat"
                .Width = 120
            End With

            .Columns.Add(colNoKandidat)


            '==================================================
            ' NAMA KANDIDAT
            '==================================================
            Dim colNama As New DataGridViewTextBoxColumn()

            With colNama
                .Name = "ffcnama"
                .HeaderText = "Nama Kandidat"
                .DataPropertyName = "ffcnama"
                .Width = 180
            End With

            .Columns.Add(colNama)


            '==================================================
            ' NO PERMINTAAN
            '==================================================
            Dim colNoPermintaan As New DataGridViewTextBoxColumn()

            With colNoPermintaan
                .Name = "ffcnopermintaan"
                .HeaderText = "No Permintaan"
                .DataPropertyName = "ffcnopermintaan"
                .Width = 140
            End With

            .Columns.Add(colNoPermintaan)


            '==================================================
            ' JABATAN
            '==================================================
            Dim colJabatan As New DataGridViewTextBoxColumn()

            With colJabatan
                .Name = "colJabatan"
                .HeaderText = "Jabatan"
                .DataPropertyName = "NamaJabatan"
                .Width = 150
            End With

            .Columns.Add(colJabatan)

            '==================================================
            ' DEPARTEMEN
            '==================================================
            Dim colDepartemen As New DataGridViewTextBoxColumn()

            With colDepartemen
                .Name = "colDepartemen"
                .HeaderText = "Departemen"
                .DataPropertyName = "NamaDepartment"
                .Width = 130
            End With

            .Columns.Add(colDepartemen)


            '==================================================
            ' BAGIAN
            '==================================================
            Dim colBagian As New DataGridViewTextBoxColumn()

            With colBagian
                .Name = "colBagian"
                .HeaderText = "Bagian"
                .DataPropertyName = "NamaBagian"
                .Width = 130
            End With

            .Columns.Add(colBagian)


            '==================================================
            ' TANGGAL OFFERING
            '==================================================
            Dim colTanggalOffering As New DataGridViewTextBoxColumn()

            With colTanggalOffering
                .Name = "ffdpenawaran"
                .HeaderText = "Tgl Offering"
                .DataPropertyName = "ffdpenawaran"
                .Width = 110
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With

            .Columns.Add(colTanggalOffering)


            '==================================================
            ' TANGGAL MULAI
            '==================================================
            Dim colTanggalMulai As New DataGridViewTextBoxColumn()

            With colTanggalMulai
                .Name = "ffdmulai"
                .HeaderText = "Tgl Mulai"
                .DataPropertyName = "ffdmulai"
                .Width = 110
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With

            .Columns.Add(colTanggalMulai)


            '==================================================
            ' JENIS KARYAWAN
            '==================================================
            Dim colJenisKaryawan As New DataGridViewTextBoxColumn()

            With colJenisKaryawan
                .Name = "ffcjeniskaryawan"
                .HeaderText = "Jenis Karyawan"
                .DataPropertyName = "ffcjeniskaryawan"
                .Width = 120
            End With

            .Columns.Add(colJenisKaryawan)


            '==================================================
            ' TEMPAT KERJA
            '==================================================
            Dim colTempatKerja As New DataGridViewTextBoxColumn()

            With colTempatKerja
                .Name = "ffctempatkerja"
                .HeaderText = "Tempat Kerja"
                .DataPropertyName = "ffctempatkerja"
                .Width = 150
            End With

            .Columns.Add(colTempatKerja)


            '==================================================
            ' STATUS
            '==================================================
            Dim colStatus As New DataGridViewTextBoxColumn()

            With colStatus
                .Name = "ffcstatus"
                .HeaderText = "Status"
                .DataPropertyName = "ffcstatus"
                .Width = 100

                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter
            End With

            .Columns.Add(colStatus)



            '==================================================
            ' BUTTON DETAIL
            '==================================================
            Dim btnDetail As New DataGridViewButtonColumn()

            With btnDetail

                .Name = "btnDetail"
                .HeaderText = "Aksi"
                .Text = "Detail"
                .UseColumnTextForButtonValue = True

                .Width = 100

                .FlatStyle = FlatStyle.Flat
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.SelectionBackColor = Color.White
                .DefaultCellStyle.SelectionForeColor = Color.White
            End With

            .Columns.Add(btnDetail)




            '==================================================
            ' BUTTON PROSES
            '==================================================
            Dim btnProses As New DataGridViewButtonColumn()

            With btnProses

                .Name = "btnProses"
                .HeaderText = "Proses"
                .Text = "Proses"
                .UseColumnTextForButtonValue = True

                .Width = 105

                .FlatStyle = FlatStyle.Flat

                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.White
                .DefaultCellStyle.ForeColor = Color.White
                .DefaultCellStyle.SelectionBackColor = Color.White
                .DefaultCellStyle.SelectionForeColor = Color.White
            End With

            .Columns.Add(btnProses)

        End With

        '==================================================
        ' APPLY THEME
        '==================================================
        ApplyGridTheme(dgvPenawaranKerja)

    End Sub
    '==============================================
    ' LOAD DATA
    '==========================================================
    Private Sub LoadData()

        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim offset As Integer =
                   paginationPenawaran.Offset

                Dim pageSize As Integer =
                    paginationPenawaran.PageSize

                Dim sql As String = ""

                sql = "SELECT o.ffcidoffering, o.ffcidkandidat,o.ffcidrekrutmen, o.ffcnopenawaran,o.ffdpenawaran,o.ffdmulai, k.ffcnokandidat, k.ffcnama,r.ffcidpermintaan, p.ffcnopermintaan,o.ffcjabatan, " &
                "a.ffcnama AS NamaJabatan,o.ffcdepartemen, b.ffcnama AS NamaDepartment, o.ffcbagian, c.ffcnama AS NamaBagian, o.ffcjeniskaryawan, o.ffctempatkerja, o.ffngajipokok, o.ffntunjangantetap, " &
                "o.ffntunjanganlain, o.ffcmassapercobaan,o.ffcstatus, o.ffdrespon,o.ffcalasanreject, o.ffcalasancancel, o.ffcketerangan FROM sapenawarankerja o " &
                "INNER JOIN sakandidat k ON o.ffcidkandidat = k.ffcidkandidat INNER JOIN sakandidatrekrutmen r ON o.ffcidrekrutmen = r.ffcidrekrutmen INNER JOIN sapermintaankaryawan p ON r.ffcidpermintaan = p.ffcidpermintaan " &
                "LEFT JOIN sajabatan a ON o.ffcjabatan = a.ffckls LEFT JOIN sadepartment b ON o.ffcdepartemen = b.ffckode LEFT JOIN sabagian c ON o.ffcbagian = c.ffcbag WHERE 1=1 "
                '==================================================
                ' SEARCH
                '==================================================
                If _keywordCari <> "" Then

                    sql &= "AND (k.ffcnokandidat LIKE @keyword OR k.ffcnama LIKE @keyword OR o.ffcnopenawaran LIKE @keyword OR p.ffcnopermintaan LIKE @keyword OR o.ffcjabatan LIKE @keyword ) "

                End If

                '==================================================
                ' STATUS
                '==================================================
                If _statusCari <> "" Then
                    sql &= "AND o.ffcstatus = @status "
                End If

                '==================================================
                ' PERIODE
                '==================================================
                sql &= "AND o.ffdpenawaran BETWEEN @tanggalDari AND @tanggalSampai "

                '==================================================
                ' ORDER
                '==================================================
                sql &= "ORDER BY o.ffdpenawaran DESC, "
                sql &= "o.ffcidoffering DESC "

                '==================================================
                ' PAGINATION
                '==================================================
                sql &= "LIMIT @offset, @pageSize"

                Using cmd As New MySqlCommand(sql, conn)

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
                    End If

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@status", _statusCari)
                    End If

                    cmd.Parameters.AddWithValue("@tanggalDari", _tanggalDari.Date)
                    cmd.Parameters.AddWithValue("@tanggalSampai", _tanggalSampai.Date)
                    cmd.Parameters.AddWithValue("@offset", offset)
                    cmd.Parameters.AddWithValue("@pageSize", pageSize)
                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgvPenawaranKerja.DataSource = dt

                    '      For i As Integer = 0 To dgvPenawaranKerja.Rows.Count - 1
                    '      If Not dgvPenawaranKerja.Rows(i).IsNewRow Then
                    '      dgvPenawaranKerja.Rows(i).Cells("colNo").Value = offset + i + 1
                    '     End If
                    '
                    '                   Next

                End Using
                UpdatePagination()
            Catch ex As Exception
                PesanPopupError("ERROR", "Gagal memuat data penawaran kerja." & Environment.NewLine & ex.Message)
            End Try
        End Using


    End Sub

    Private Sub dgvPenawaranKerja_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvPenawaranKerja.CellPainting

        If e.RowIndex < 0 Then Return
        If e.ColumnIndex < 0 Then Return

        Dim columnName As String =
        dgvPenawaranKerja.Columns(e.ColumnIndex).Name


        '==========================================================
        ' KOLOM NOMOR
        '==========================================================
        If columnName = "colNo" Then

            Dim noBackColor As Color =
            dgvPenawaranKerja.Rows(e.RowIndex).
            DefaultCellStyle.BackColor

            If noBackColor = Color.Empty Then
                noBackColor = Color.White
            End If

            Using backBrush As New SolidBrush(noBackColor)

                e.Graphics.FillRectangle(
                backBrush,
                e.CellBounds)

            End Using


            '------------------------------------------------------
            ' NOMOR PAGINATION
            '------------------------------------------------------
            Dim nomor As Integer =
            paginationPenawaran.Offset +
            e.RowIndex +
            1


            Using fontNo As New Font(
            "Segoe UI",
            9.0F)

                Using brushText As New SolidBrush(
                Color.FromArgb(31, 41, 55))

                    Dim ukuran As SizeF =
                    e.Graphics.MeasureString(
                        nomor.ToString(),
                        fontNo)

                    Dim x As Single =
                    e.CellBounds.X +
                    (e.CellBounds.Width - ukuran.Width) / 2

                    Dim y As Single =
                    e.CellBounds.Y +
                    (e.CellBounds.Height - ukuran.Height) / 2

                    e.Graphics.DrawString(
                    nomor.ToString(),
                    fontNo,
                    brushText,
                    x,
                    y)

                End Using

            End Using


            e.Handled = True
            Return

        End If


        '==========================================================
        ' CUSTOM BUTTON
        '==========================================================
        If columnName <> "btnDetail" AndAlso
       columnName <> "btnProses" Then

            Return

        End If


        '==========================================================
        ' BACKGROUND CELL
        '==========================================================
        Dim cellBackColor As Color =
        dgvPenawaranKerja.Rows(e.RowIndex).
        DefaultCellStyle.BackColor

        If cellBackColor = Color.Empty Then
            cellBackColor = Color.White
        End If


        Using backBrush As New SolidBrush(cellBackColor)

            e.Graphics.FillRectangle(
            backBrush,
            e.CellBounds)

        End Using


        '==========================================================
        ' GARIS BAWAH GRID
        '==========================================================
        Using gridPen As New Pen(
        Color.FromArgb(229, 231, 235))

            e.Graphics.DrawLine(
            gridPen,
            e.CellBounds.Left,
            e.CellBounds.Bottom - 1,
            e.CellBounds.Right,
            e.CellBounds.Bottom - 1)

        End Using


        '==========================================================
        ' AREA BUTTON
        '==========================================================
        Dim buttonRect As New Rectangle(
        e.CellBounds.X + 8,
        e.CellBounds.Y + 5,
        e.CellBounds.Width - 16,
        e.CellBounds.Height - 10)


        '==========================================================
        ' WARNA BUTTON
        '==========================================================
        Dim buttonColor As Color

        If columnName = "btnDetail" Then

            buttonColor =
            Color.FromArgb(31, 95, 209)

        Else

            buttonColor =
            Color.FromArgb(16, 185, 129)

        End If


        '==========================================================
        ' ROUNDED BUTTON
        '==========================================================
        Using path As Drawing2D.GraphicsPath =
        CreateRoundedRectangle(
            buttonRect,
            6)

            Using brush As New SolidBrush(buttonColor)

                e.Graphics.FillPath(
                brush,
                path)

            End Using

        End Using


        '==========================================================
        ' TEXT BUTTON
        '==========================================================
        Dim textButton As String

        If columnName = "btnDetail" Then
            textButton = "Detail"
        Else
            textButton = "Proses"
        End If


        Using fontButton As New Font("Segoe UI Semibold", 9.0F)

            Using textBrush As New SolidBrush(Color.White)

                Dim textSize As SizeF = e.Graphics.MeasureString(textButton, fontButton)

                Dim textX As Single =
                buttonRect.X +
                (buttonRect.Width - textSize.Width) / 2

                Dim textY As Single =
                buttonRect.Y +
                (buttonRect.Height - textSize.Height) / 2

                e.Graphics.DrawString(
                textButton,
                fontButton,
                textBrush,
                textX,
                textY)

            End Using

        End Using


        e.Handled = True

    End Sub
    '==========================================================
    ' GET TOTAL RECORD
    '==========================================================
    Private Function GetTotalRecord() As Integer
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT COUNT(*) FROM sapenawarankerja o INNER JOIN sakandidat k ON o.ffcidkandidat = k.ffcidkandidat INNER JOIN sakandidatrekrutmen r ON o.ffcidrekrutmen = r.ffcidrekrutmen " &
                "INNER JOIN sapermintaankaryawan p ON r.ffcidpermintaan = p.ffcidpermintaan WHERE 1=1 "

                If _keywordCari <> "" Then
                    sql &= "AND (k.ffcnokandidat LIKE @keyword OR k.ffcnama LIKE @keyword OR o.ffcnopenawaran LIKE @keyword OR p.ffcnopermintaan LIKE @keyword OR o.ffcjabatan LIKE @keyword ) "
                End If

                If _statusCari <> "" Then
                    sql &= "AND o.ffcstatus = @status "
                End If

                sql &= "AND o.ffdpenawaran BETWEEN @tanggalDari AND @tanggalSampai "

                Using cmd As New MySqlCommand(sql, conn)

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
                    End If

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@status", _statusCari)

                    End If
                    cmd.Parameters.AddWithValue("@tanggalDari", _tanggalDari.Date)
                    cmd.Parameters.AddWithValue("@tanggalSampai", _tanggalSampai.Date)
                    Return Convert.ToInt32(cmd.ExecuteScalar())

                End Using
            Catch ex As Exception
                PesanPopupError("ERROR", "Gagal menghitung data penawaran kerja." & Environment.NewLine & ex.Message)
                Return 0
            End Try
        End Using


    End Function

    '==========================================================
    ' UPDATE PAGINATION
    '==========================================================
    Private Sub UpdatePagination()

        paginationPenawaran.TotalRecord = GetTotalRecord()


    End Sub

    '==========================================================
    ' BUTTON CARI
    '==========================================================
    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click

        _keywordCari = tPencarian.Text.Trim()
        If cstatus.SelectedIndex <= 0 Then
            _statusCari = ""
        Else
            _statusCari = cstatus.Text.Trim()

        End If

        _tanggalDari = dtpDari.Value.Date

        _tanggalSampai = dtpSampai.Value.Date

        If _tanggalDari > _tanggalSampai Then

            PesanPopupPeringatan("Peringatan", "Tanggal mulai tidak boleh lebih besar " & "dari tanggal akhir.")
            Return

        End If
        paginationPenawaran.CurrentPage = 1
        LoadData()

    End Sub

    '==========================================================
    ' BUTTON RESET
    '==========================================================
    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click

        tPencarian.Clear()
        cstatus.SelectedIndex = 0
        dtpDari.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpSampai.Value = DateTime.Now

        _keywordCari = ""
        _statusCari = ""

        _tanggalDari = dtpDari.Value.Date

        _tanggalSampai = dtpSampai.Value.Date

        paginationPenawaran.CurrentPage = 1

        LoadData()

    End Sub

    '==========================================================
    ' CELL CLICK
    '==========================================================
    Private Sub dgvPenawaranKerja_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPenawaranKerja.CellContentClick

        If e.RowIndex < 0 Then Return

        Dim columnName As String =
        dgvPenawaranKerja.Columns(e.ColumnIndex).Name

        Dim row As DataGridViewRow =
        dgvPenawaranKerja.Rows(e.RowIndex)

        '======================================================
        ' AMBIL ID
        '======================================================
        Dim idOffering As Long = 0
        Dim idKandidat As Long = 0
        Dim idRekrutmen As Long = 0
        Dim status As String = ""

        If row.Cells("ffcidoffering").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidoffering").Value) Then
            idOffering = Convert.ToInt64(row.Cells("ffcidoffering").Value)

        End If

        If row.Cells("ffcidkandidat").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidkandidat").Value) Then
            idKandidat = Convert.ToInt64(row.Cells("ffcidkandidat").Value)
        End If

        If row.Cells("ffcidrekrutmen").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidrekrutmen").Value) Then
            idRekrutmen = Convert.ToInt64(row.Cells("ffcidrekrutmen").Value)

        End If

        If row.Cells("ffcstatus").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcstatus").Value) Then
            status = row.Cells("ffcstatus").Value.ToString().Trim()
        End If


        '======================================================
        ' VALIDASI ID
        '======================================================
        If idOffering <= 0 Then
            PesanPopupPeringatan("Peringatan", "Data offering tidak valid.")
            Return

        End If


        '======================================================
        ' DETAIL
        '======================================================
        If columnName = "btnDetail" Then
            BukaDetailOffering(idOffering, idKandidat, idRekrutmen)
            Return

        End If


        '======================================================
        ' PROSES
        '======================================================
        If columnName = "btnProses" Then
            BukaProsesOffering(idOffering, idKandidat, idRekrutmen, status)

            Return

        End If

    End Sub
    Private Sub BukaProsesOffering(idOffering As Long, idKandidat As Long, idRekrutmen As Long, status As String)

        '======================================================
        ' OFFERING YANG SUDAH FINAL
        '======================================================
        If status = "REJECTED" Then
            PesanPopupPeringatan("Peringatan", "Offering ini sudah ditolak oleh kandidat.")
            Return

        End If


        If status = "CANCELLED" Then
            PesanPopupPeringatan("Peringatan", "Offering ini sudah dibatalkan.")
            Return

        End If


        '   If status = "ACCEPTED" Then
        '   PesanPopupPeringatan("Peringatan", "Offering ini sudah diterima oleh kandidat.")
        '   Return

        '    End If


        '======================================================
        ' PROSES OFFERING
        '======================================================
        Dim frm As New frmPenawaranKerjaAdd()

        frm.IdOffering = idOffering
        frm.IdKandidat = idKandidat
        frm.IdRekrutmen = idRekrutmen

        frm.ModeForm = frmPenawaranKerjaAdd.FormMode.Proses

        frm.ShowDialog()

        LoadData()

    End Sub
    Private Sub BukaDetailOffering(idOffering As Long, idKandidat As Long, idRekrutmen As Long)

        Dim frm As New frmPenawaranKerjaAdd()

        frm.IdOffering = idOffering
        frm.IdKandidat = idKandidat
        frm.IdRekrutmen = idRekrutmen
        frm.ModeForm = frmPenawaranKerjaAdd.FormMode.Detail
        frm.ShowDialog()
        LoadData()

    End Sub

    '==========================================================
    ' PAGINATION
    '==========================================================
    Private Sub paginationPenawaran_PageChanged(sender As Object, e As EventArgs) Handles paginationPenawaran.PageChanged
        LoadData()
    End Sub



End Class