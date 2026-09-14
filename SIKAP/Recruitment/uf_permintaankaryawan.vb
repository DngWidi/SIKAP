Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
'Imports FontAwesome.Sharp
Imports System.Drawing
Public Class uf_permintaankaryawan
    '========================================
    ' VARIABLE PENCARIAN
    '========================================
    Private _keywordCari As String = ""
    Private _statusCari As String = ""
    '========================================
    ' ID PERMINTAAN YANG DIPILIH
    '========================================
    Private _idPermintaanTerpilih As Long = 0
    '========================================
    ' STATUS PERMINTAAN YANG DIPILIH
    '========================================
    Private _statusTerpilih As String = ""
#Region "Function"
    Private Function GetTotalRecord() As Integer
        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT COUNT(*) FROM sapermintaankaryawan WHERE 1 = 1 "

                '========================================
                ' FILTER KEYWORD
                '========================================

                If _keywordCari <> "" Then
                    sql &= " AND (ffcnopermintaan LIKE @Keyword OR ffckdjabatan LIKE @Keyword OR ffckddepart LIKE @Keyword ) "
                End If

                '========================================
                ' FILTER STATUS
                '========================================

                If _statusCari <> "" Then
                    sql &= " AND ffcstatus = @Status "
                End If


                Using cmd As New MySqlCommand(sql, conn)

                    '========================================
                    ' PARAMETER KEYWORD
                    '========================================

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@Keyword", "%" & _keywordCari & "%")
                    End If


                    '========================================
                    ' PARAMETER STATUS
                    '========================================

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@Status", _statusCari)
                    End If


                    Return Convert.ToInt32(
                            cmd.ExecuteScalar()
                        )

                End Using

            End Using


        Catch ex As Exception
            PesanPopupError("Error", "Gagal menghitung data." & vbCrLf & ex.Message)
            Return 0
        End Try

    End Function
    Private Function GetStatusCode() As String
        Select Case cstatus.SelectedIndex
            Case 0
                Return ""
            Case 1
                Return "DRAFT"
            Case 2
                Return "WAITING_DEPARTMENT"
            Case 3
                Return "WAITING_HRD"
            Case 4
                Return "REJECTED"
            Case 5
                Return "APPROVED"
            Case 6
                Return "PROCESSING"
            Case 7
                Return "PARTIALLY_FULFILLED"
            Case 8
                Return "ON_HOLD"
            Case 9
                Return "COMPLETED"
            Case Else
                Return ""
        End Select

    End Function
    Private Function BuatIconKandidat() As Bitmap
        Dim iconPicture As New FontAwesome.Sharp.IconPictureBox()

        Try
            ' 1. Ubah icon menjadi UserPlus agar user tahu ini untuk menambah data
            iconPicture.IconChar = FontAwesome.Sharp.IconChar.UserPlus
            iconPicture.IconFont = FontAwesome.Sharp.IconFont.Auto

            ' 2. Perkecil ukuran icon agar pas di dalam baris
            iconPicture.IconSize = 14

            ' 3. Gunakan warna abu-abu gelap kehitaman
            iconPicture.IconColor = Color.FromArgb(45, 45, 45)
            iconPicture.BackColor = Color.Transparent

            ' 4. Sesuaikan ukuran bitmap
            iconPicture.Size = New Size(16, 16)

            Dim bmp As New Bitmap(16, 16)

            iconPicture.DrawToBitmap(
                bmp,
                New Rectangle(0, 0, 16, 16)
            )

            Return bmp

        Finally
            iconPicture.Dispose()
        End Try
    End Function
#End Region

#Region "Private"
    Private Sub SetupStatus()

        cstatus.Items.Clear()

        cstatus.Items.Add("Semua Status")
        cstatus.Items.Add("Draft")
        cstatus.Items.Add("Waiting Department Approval")
        cstatus.Items.Add("Waiting HR Approval")
        cstatus.Items.Add("Rejected")
        cstatus.Items.Add("Approved")
        cstatus.Items.Add("Processing")
        cstatus.Items.Add("Partially Fulfilled")
        cstatus.Items.Add("On Hold")
        cstatus.Items.Add("Completed")

        cstatus.SelectedIndex = 0

    End Sub
    Private Sub DataPermintaanKaryawan()
        Try
            '========================================
            ' 1. HITUNG TOTAL RECORD
            '========================================
            paginationPermintaan.TotalRecord = GetTotalRecord()

            '========================================
            ' 2. PASTIKAN CURRENT PAGE VALID
            '========================================

            If paginationPermintaan.CurrentPage >
               paginationPermintaan.TotalPage Then

                paginationPermintaan.CurrentPage = paginationPermintaan.TotalPage

            End If

            '========================================
            ' 3. LOAD DATA
            '========================================
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                '    Dim sql As String = "SELECT ffcidpermintaan AS `ID`,ffcnopermintaan AS `No. Permintaan`,ffdtglpermintaan AS `Tanggal`,ffcnikrequester AS `NIK Requester`," &
                '   "ffckddepart AS `Department`, ffckdbagian AS `Bagian`,ffckdjabatan AS `Jabatan`,ffnjumlah AS `Jumlah`,ffcjnskebutuhan AS `Jenis Kebutuhan`," &
                '   "ffcprioritas AS `Prioritas`,ffcstatuskaryawan AS `Status Karyawan`,ffdtglbutuh AS `Tanggal Dibutuhkan`,ffcstatus AS `StatusCode`," &
                '   "CASE ffcstatus  WHEN 'DRAFT' THEN 'Draft' WHEN 'WAITING_DEPARTMENT' THEN 'Waiting Department Approval' WHEN 'WAITING_HRD' " &
                '   "THEN 'Waiting HR Approval' WHEN 'REJECTED' THEN 'Rejected' WHEN 'APPROVED' THEN 'Approved' WHEN 'PROCESSING' THEN 'Processing' " &
                '   "WHEN 'PARTIALLY_FULFILLED' THEN 'Partially Fulfilled' WHEN 'ON_HOLD' THEN 'On Hold' WHEN 'COMPLETED' THEN 'Completed' ELSE ffcstatus " &
                '   " END AS `Status` FROM sapermintaankaryawan WHERE 1 = 1 "

                Dim sql As String = "SELECT  p.ffcidpermintaan As `ID`, p.ffcnopermintaan As `No. Permintaan`,p.ffdtglpermintaan As `Tanggal`,p.ffcnikrequester As `NIK Requester`, " &
                "p.ffckddepart As `Department`,p.ffckdbagian As `Bagian`,p.ffckdjabatan As `Jabatan`,p.ffnjumlah As `Jumlah`,p.ffcjnskebutuhan As `Jenis Kebutuhan`, " &
                "p.ffcprioritas As `Prioritas`,p.ffcstatuskaryawan As `Status Karyawan`,p.ffdtglbutuh As `Tanggal Dibutuhkan`,p.ffcstatus As `StatusCode`, (Select COUNT(*) " &
                "FROM sakandidatrekrutmen r  WHERE r.ffcidpermintaan = p.ffcidpermintaan) As `JumlahKandidat`, CASE p.ffcstatus  When 'DRAFT' THEN 'Draft' " &
                "WHEN 'WAITING_DEPARTMENT' THEN 'Waiting Department Approval' WHEN 'WAITING_HRD' THEN 'Waiting HR Approval' WHEN 'REJECTED' THEN 'Rejected' " &
                "WHEN 'APPROVED' THEN 'Approved' WHEN 'PROCESSING' THEN 'Processing' WHEN 'PARTIALLY_FULFILLED' THEN 'Partially Fulfilled' " &
                "WHEN 'ON_HOLD' THEN 'On Hold' WHEN 'COMPLETED' THEN 'Completed'  ELSE p.ffcstatus  END AS `Status`FROM sapermintaankaryawan p WHERE 1 = 1 "


                '========================================
                ' FILTER KEYWORD
                '========================================

                If _keywordCari <> "" Then
                    sql &= "AND (p.ffcnopermintaan LIKE @Keyword OR p.ffckdjabatan LIKE @Keyword OR p.ffckddepart LIKE @Keyword) "
                End If

                '========================================
                ' FILTER STATUS
                '========================================

                If _statusCari <> "" Then
                    sql &= "AND p.ffcstatus = @Status "
                End If

                '========================================
                ' SORTING + PAGINATION
                '========================================
                sql &= "ORDER BY p.ffcidpermintaan DESC LIMIT @Limit OFFSET @Offset "

                Using cmd As New MySqlCommand(sql, conn)
                    '========================================
                    ' PARAMETER KEYWORD
                    '========================================
                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@Keyword", "%" & _keywordCari & "%")
                    End If

                    '========================================
                    ' PARAMETER STATUS
                    '========================================

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@Status", _statusCari)
                    End If

                    '========================================
                    ' PARAMETER PAGINATION
                    '========================================

                    cmd.Parameters.AddWithValue("@Limit", paginationPermintaan.PageSize)
                    cmd.Parameters.AddWithValue("@Offset", paginationPermintaan.Offset)
                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvPermintaan.DataSource = dt
                    End Using

                    ' --- PANGGIL DI SINI ---
                    SetupKolomKandidat()

                    If dgvPermintaan.Columns.Contains("JumlahKandidat") Then
                        dgvPermintaan.Columns("JumlahKandidat").Visible = False
                    End If
                End Using
            End Using

            '========================================
            ' 4. FORMAT DATAGRIDVIEW
            '========================================

            FormatDataGridView()

            '========================================
            ' 5. RESET SELECTED DATA
            '========================================
            _idPermintaanTerpilih = 0
            _statusTerpilih = ""

            '========================================
            ' 6. UPDATE INFORMASI PAGINATION
            '========================================
            UpdatePaginationInfo()

            '========================================
            ' 7. UPDATE BUTTON
            '========================================

            UpdateActionButtons()
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memuat data permintaan karyawan !!" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub UpdatePaginationInfo()
        lblInfo.Text = String.Format("Menampilkan {0} - {1} dari {2} Data", paginationPermintaan.StartRecord, paginationPermintaan.EndRecord, paginationPermintaan.TotalRecord)
    End Sub
    Private Sub paginationPermintaan_PageChanged(sender As Object, e As EventArgs) Handles paginationPermintaan.PageChanged
        DataPermintaanKaryawan()
    End Sub

#End Region
#Region "DataGridView"
    Private Sub SetupDataGridView()
        With dgvPermintaan
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' --- TAMBAHKAN DUA BARIS INI ---
            .ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(31, 95, 209)
            .ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White
        End With
    End Sub
    Private Sub SetupKolomKandidat()
        If dgvPermintaan.Columns.Contains("colKandidat") Then
            dgvPermintaan.Columns.Remove("colKandidat")
        End If

        Dim colKandidat As New DataGridViewTextBoxColumn()

        With colKandidat

            .Name = "colKandidat"
            .HeaderText = "Kandidat"

            .Width = 90
            .MinimumWidth = 90

            .ReadOnly = True

            .SortMode =
                DataGridViewColumnSortMode.NotSortable

            .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter

            .DefaultCellStyle.BackColor =
                Color.White

            .DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254)

            .DefaultCellStyle.SelectionForeColor =
                Color.Black

        End With
        dgvPermintaan.Columns.Add(colKandidat)

    End Sub
    Private Sub FormatDataGridView()
        If dgvPermintaan.Columns.Count = 0 Then
            Return
        End If
        '========================================
        ' SEMBUNYIKAN KOLOM INTERNAL
        '========================================
        If dgvPermintaan.Columns.Contains("ID") Then
            dgvPermintaan.Columns("ID").Visible = False
        End If

        If dgvPermintaan.Columns.Contains("StatusCode") Then
            dgvPermintaan.Columns("StatusCode").Visible = False
        End If


        '========================================
        ' LEBAR KOLOM
        '========================================

        If dgvPermintaan.Columns.Contains("No. Permintaan") Then
            dgvPermintaan.Columns("No. Permintaan").Width = 130

        End If

        If dgvPermintaan.Columns.Contains("Tanggal") Then
            dgvPermintaan.Columns("Tanggal").Width = 90
        End If

        If dgvPermintaan.Columns.Contains("NIK Requester") Then
            dgvPermintaan.Columns("NIK Requester").Width = 100
        End If

        If dgvPermintaan.Columns.Contains("Department") Then
            dgvPermintaan.Columns("Department").Width = 100
        End If

        If dgvPermintaan.Columns.Contains("Bagian") Then
            dgvPermintaan.Columns("Bagian").Width = 100
        End If

        If dgvPermintaan.Columns.Contains("Jabatan") Then
            dgvPermintaan.Columns("Jabatan").Width = 100
        End If

        If dgvPermintaan.Columns.Contains("Jumlah") Then
            dgvPermintaan.Columns("Jumlah").Width = 70
        End If

        If dgvPermintaan.Columns.Contains("Jenis Kebutuhan") Then
            dgvPermintaan.Columns("Jenis Kebutuhan").Width = 130
        End If

        If dgvPermintaan.Columns.Contains("Prioritas") Then
            dgvPermintaan.Columns("Prioritas").Width = 90
        End If

        If dgvPermintaan.Columns.Contains("Status Karyawan") Then
            dgvPermintaan.Columns("Status Karyawan").Width = 110
        End If
        If dgvPermintaan.Columns.Contains("Tanggal Dibutuhkan") Then
            dgvPermintaan.Columns("Tanggal Dibutuhkan").Width = 120
        End If
        If dgvPermintaan.Columns.Contains("Status") Then
            dgvPermintaan.Columns("Status").Width = 180
        End If


        '========================================
        ' FORMAT TANGGAL
        '========================================

        If dgvPermintaan.Columns.Contains("Tanggal") Then
            dgvPermintaan.Columns("Tanggal").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If

        If dgvPermintaan.Columns.Contains("Tanggal Dibutuhkan") Then
            dgvPermintaan.Columns("Tanggal Dibutuhkan").DefaultCellStyle.Format = "dd/MM/yyyy"
        End If

        '========================================
        ' ALIGNMENT
        '========================================

        If dgvPermintaan.Columns.Contains("Jumlah") Then
            dgvPermintaan.Columns("Jumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        If dgvPermintaan.Columns.Contains("Status") Then
            dgvPermintaan.Columns("Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub
    Private Sub dgvPermintaan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermintaan.CellClick

        '==================================================
        ' VALIDASI HEADER
        '==================================================
        If e.RowIndex < 0 Then

            _idPermintaanTerpilih = 0
            _statusTerpilih = ""

            UpdateActionButtons()

            Return

        End If

        '==================================================
        ' AMBIL BARIS
        '==================================================
        Dim row As DataGridViewRow =
        dgvPermintaan.Rows(e.RowIndex)

        '==================================================
        ' AMBIL ID PERMINTAAN
        '==================================================
        _idPermintaanTerpilih = 0

        If row.Cells("ID").Value IsNot Nothing AndAlso
       Not IsDBNull(row.Cells("ID").Value) Then

            Long.TryParse(row.Cells("ID").Value.ToString(), _idPermintaanTerpilih)

        End If

        '==================================================
        ' AMBIL STATUS DATABASE
        '==================================================
        _statusTerpilih = ""

        If row.Cells("StatusCode").Value IsNot Nothing AndAlso
       Not IsDBNull(row.Cells("StatusCode").Value) Then

            _statusTerpilih = row.Cells("StatusCode").Value.ToString().Trim()

        End If

        '==================================================
        ' UPDATE ACTION BUTTON
        '==================================================
        UpdateActionButtons()

        '==================================================
        ' CEK APAKAH YANG DIKLIK KOLOM KANDIDAT
        '==================================================
        If Not dgvPermintaan.Columns.Contains("colKandidat") Then
            Return
        End If

        If e.ColumnIndex <> dgvPermintaan.Columns("colKandidat").Index Then

            Return

        End If

        '==================================================
        ' VALIDASI ID
        '==================================================
        If _idPermintaanTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "ID permintaan tidak valid.")
            Return

        End If

        '==================================================
        ' BUKA FORM KANDIDAT
        '==================================================
        Using frm As New frmPermintaanKandidat(_idPermintaanTerpilih)

            frm.ShowDialog(Me.FindForm())

        End Using

        '==================================================
        ' REFRESH JUMLAH KANDIDAT
        '==================================================
        DataPermintaanKaryawan()

    End Sub

    Private Sub dgvPermintaan_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvPermintaan.CellPainting

        '==================================================
        ' BUKAN DATA ROW
        '==================================================
        If e.RowIndex < 0 Then
            Return
        End If

        '==================================================
        ' PASTIKAN KOLOM KANDIDAT ADA
        '==================================================
        If Not dgvPermintaan.Columns.Contains("colKandidat") Then
            Return
        End If

        '==================================================
        ' HANYA KOLOM KANDIDAT
        '==================================================
        If e.ColumnIndex <>
       dgvPermintaan.Columns("colKandidat").Index Then

            Return

        End If

        '==================================================
        ' JANGAN PROSES NEW ROW
        '==================================================
        If dgvPermintaan.Rows(e.RowIndex).IsNewRow Then
            Return
        End If

        '==================================================
        ' AMBIL JUMLAH KANDIDAT
        '==================================================
        Dim jumlahKandidat As Integer = 0

        If dgvPermintaan.Columns.Contains("JumlahKandidat") Then

            Dim value As Object = dgvPermintaan.Rows(e.RowIndex).Cells("JumlahKandidat").Value

            If value IsNot Nothing AndAlso Not IsDBNull(value) Then

                Integer.TryParse(value.ToString(), jumlahKandidat)

            End If

        End If

        '==================================================
        ' PAINT BACKGROUND
        '==================================================
        e.PaintBackground(e.CellBounds, True)

        '==================================================
        ' PAINT BORDER
        '==================================================
        e.Paint(e.CellBounds, DataGridViewPaintParts.Border)

        '==================================================
        ' BUAT ICON KANDIDAT
        '==================================================
        Using kandidatBitmap As Bitmap = BuatIconKandidat()

            '================================================
            ' TEXT JUMLAH
            '================================================
            Dim jumlahText As String =
            jumlahKandidat.ToString()

            Using textFont As New Font("Segoe UI", 9, FontStyle.Regular)

                '============================================
                ' UKUR TEXT
                '============================================
                Dim textSize As SizeF = e.Graphics.MeasureString(jumlahText, textFont)

                Dim spacing As Integer = 4

                '============================================
                ' TOTAL LEBAR
                '============================================
                Dim totalWidth As Single = kandidatBitmap.Width + spacing + textSize.Width

                '============================================
                ' POSISI X
                '============================================
                Dim startX As Single = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2

                '============================================
                ' POSISI Y ICON
                '============================================
                Dim iconY As Single = e.CellBounds.Y + (e.CellBounds.Height - kandidatBitmap.Height) / 2

                '============================================
                ' POSISI Y TEXT
                '============================================
                Dim textY As Single = e.CellBounds.Y + (e.CellBounds.Height - textSize.Height) / 2

                '============================================
                ' DRAW ICON
                '============================================
                e.Graphics.DrawImage(kandidatBitmap, startX, iconY)

                '============================================
                ' DRAW JUMLAH
                '============================================
                e.Graphics.DrawString(jumlahText, textFont, Brushes.Blue, startX + kandidatBitmap.Width + spacing, textY)

            End Using

        End Using

        '==================================================
        ' HENTIKAN DEFAULT PAINT
        '==================================================
        e.Handled = True

    End Sub
    Private Sub dgvPermintaan_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPermintaan.CellMouseMove

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso dgvPermintaan.Columns.Contains("colKandidat") AndAlso e.ColumnIndex = dgvPermintaan.Columns("colKandidat").Index Then
            dgvPermintaan.Cursor = Cursors.Hand
        Else
            dgvPermintaan.Cursor = Cursors.Default
        End If

    End Sub
    Private Sub dgvPermintaan_CellToolTipTextNeeded(sender As Object, e As DataGridViewCellToolTipTextNeededEventArgs) Handles dgvPermintaan.CellToolTipTextNeeded
        ' Pastikan bukan area header
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Cek apakah ini kolom Kandidat
            If dgvPermintaan.Columns.Contains("colKandidat") AndAlso e.ColumnIndex = dgvPermintaan.Columns("colKandidat").Index Then
                ' Set pesan tooltip yang akan muncul
                e.ToolTipText = "Klik di sini untuk melihat atau menambah data Kandidat"
            End If
        End If
    End Sub

#End Region
#Region "Action Button"
    Private Sub UpdateActionButtons()
        '========================================
        ' DEFAULT
        '========================================

        bEdit.Enabled = False
        bHapus.Enabled = False
        bDetail.Enabled = False
        bSubmit.Enabled = False

        '========================================
        ' TIDAK ADA DATA TERPILIH
        '========================================

        If _idPermintaanTerpilih <= 0 Then
            Return
        End If

        '========================================
        ' DETAIL
        '========================================

        bDetail.Enabled = True

        '========================================
        ' ACTION BERDASARKAN STATUS
        '========================================

        Select Case _statusTerpilih
            Case "DRAFT"
                bEdit.Enabled = True
                bHapus.Enabled = True
                bSubmit.Enabled = True
            Case "WAITING_DEPARTMENT"
                'Tidak ada Edit
                'Tidak ada Hapus
                'Tidak ada Submit
            Case "WAITING_HRD"
                'Tidak ada Edit
                'Tidak ada Hapus
                'Tidak ada Submit
            Case "REJECTED"
                'Nanti kita tambahkan
                'button Revisi
            Case "APPROVED"
                'Read Only
            Case "PROCESSING"
                'Read Only
            Case "PARTIALLY_FULFILLED"
                'Read Only
            Case "ON_HOLD"
                'Read Only
            Case "COMPLETED"
                'Read Only
        End Select

    End Sub
#End Region
    Private Sub uf_permintaankaryawan_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupDataGridView()
        '  SetupKolomKandidat()
        ' ApplyGridTheme(dgvPermintaan)
        SetupStatus()
        DataPermintaanKaryawan()
    End Sub
    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click
        '========================================
        ' KOSONGKAN PENCARIAN
        '========================================
        tPencarian.Clear()

        _keywordCari = ""
        _statusCari = ""
        '========================================
        ' RESET STATUS
        '========================================
        cstatus.SelectedIndex = 0
        '========================================
        ' KEMBALI KE HALAMAN 1
        '========================================
        paginationPermintaan.CurrentPage = 1
        '========================================
        ' LOAD ULANG DATA
        '========================================

        DataPermintaanKaryawan()
    End Sub
    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Using frm As New frmPermintaanKaryawanAdd()
            frm.Mode = frmPermintaanKaryawanAdd.ModeForm.Tambah

            frm.IdPermintaan = _idPermintaanTerpilih
            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                DataPermintaanKaryawan()
            End If
        End Using
    End Sub
    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click
        '========================================
        ' AMBIL KEYWORD
        '========================================

        _keywordCari = tPencarian.Text.Trim()

        '========================================
        ' AMBIL STATUS
        '========================================
        _statusCari = GetStatusCode()
        '========================================
        ' KEMBALI KE HALAMAN 1
        '========================================

        paginationPermintaan.CurrentPage = 1

        '========================================
        ' LOAD DATA
        '========================================
        DataPermintaanKaryawan()
    End Sub
    Private Sub tPencarian_TextChanged(sender As Object, e As EventArgs) Handles tPencarian.TextChanged
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
    Private Sub tPencarian_KeyDown(sender As Object, e As KeyEventArgs) Handles tPencarian.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            bCari.PerformClick()

        End If

    End Sub
    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click
        '========================================
        ' VALIDASI PILIHAN
        '========================================
        If _idPermintaanTerpilih <= 0 Then

            PesanPopupPeringatan("Peringatan", "Silakan pilih data yang ingin diedit.")
            Return

        End If

        '========================================
        ' VALIDASI STATUS
        '========================================

        If _statusTerpilih <> "DRAFT" Then
            PesanPopupPeringatan("Peringatan", "Hanya permintaan dengan status Draft yang dapat diedit.")
            Return
        End If

        '========================================
        ' BUKA FORM EDIT
        '========================================

        Using frm As New frmPermintaanKaryawanAdd()
            frm.Mode = frmPermintaanKaryawanAdd.ModeForm.Edit
            frm.IdPermintaan = _idPermintaanTerpilih
            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                DataPermintaanKaryawan()
            End If
        End Using
    End Sub

    Private Sub bHapus_Click(sender As Object, e As EventArgs) Handles bHapus.Click
        '========================================
        ' VALIDASI PILIHAN
        '========================================

        If _idPermintaanTerpilih <= 0 Then
            PesanPopupPeringatan("Peringanatan", "Silakan pilih data yang ingin dihapus.")
            Return

        End If

        '========================================
        ' VALIDASI STATUS
        '========================================

        If _statusTerpilih <> "DRAFT" Then
            PesanPopupPeringatan("Peringatan", "Hanya permintaan dengan status Draft yang dapat dihapus.")
            Return

        End If

        '========================================
        ' KONFIRMASI
        '========================================

        Dim result As DialogResult = PesanPopupKonfirmasi("Konfirmasi", "Apakah Anda yakin ingin menghapus permintaan ini?")

        If result <> DialogResult.Yes Then
            Return
        End If

        '========================================
        ' DELETE DATABASE
        '========================================
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Dim mTrans As MySqlTransaction = conn.BeginTransaction()
            Try

                Dim sql As String = "DELETE FROM sapermintaankaryawan WHERE ffcidpermintaan = @ID AND ffcstatus = 'DRAFT' "
                Using comm As New MySqlCommand(sql, conn, mTrans)
                    comm.Parameters.AddWithValue("@ID", _idPermintaanTerpilih)
                    Dim affectedRows As Integer = comm.ExecuteNonQuery()
                    If affectedRows > 0 Then
                        mTrans.Commit()
                        PesanPopupSukses("Sukses", "Draft berhasil dihapus.")
                    Else
                        mTrans.Rollback()
                        PesanPopupPeringatan("Data tidak dapat dihapus.", "Data mungkin sudah berubah atau tidak lagi berstatus Draft.")
                    End If
                End Using

                '========================================
                ' RESET
                '========================================
                _idPermintaanTerpilih = 0
                _statusTerpilih = ""

                '========================================
                ' LOAD ULANG
                '========================================
                DataPermintaanKaryawan()
            Catch ex As MySqlException
                mtrans.Rollback()
                PesanPopupError("Error", "Gagal menghapus no permintaan !!" & vbCrLf & ex.Message)
            Catch ex As Exception
                mTrans.Rollback()
                PesanPopupError("Error", "Terjadi kesalahan !!" & vbCrLf & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click
        If _idPermintaanTerpilih <= 0 Then
            PesanPopupPeringatan("Pilih data permintaan terlebih dahulu.", "Silakan pilih data yang ingin dilihat.")
            Return
        End If
        '========================================
        ' NANTI KITA BUAT FORM DETAIL
        '========================================

        Using frm As New frmPermintaanKaryawanAdd()
            frm.Mode = frmPermintaanKaryawanAdd.ModeForm.View
            frm.IdPermintaan = _idPermintaanTerpilih
            frm.ShowDialog(Me.FindForm())
        End Using
    End Sub

    Private Sub bSubmit_Click(sender As Object, e As EventArgs) Handles bSubmit.Click
        '========================================
        ' VALIDASI PILIHAN
        '========================================

        If _idPermintaanTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih draft yang ingin disubmit.")
            Return
        End If

        '========================================
        ' VALIDASI STATUS
        '========================================

        If _statusTerpilih <> "DRAFT" Then
            PesanPopupPeringatan("Peringatan", "Hanya permintaan dengan status Draft yang dapat disubmit.")
            Return
        End If

        '========================================
        ' KONFIRMASI
        '========================================

        Dim result As DialogResult = PesanPopupKonfirmasi("Konfirmasi", "Apakah Anda yakin ingin mengirim permintaan ini untuk proses approval?")
        If result <> DialogResult.Yes Then
            Return
        End If

        '========================================
        ' SUBMIT
        '========================================
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Using trans As MySqlTransaction = conn.BeginTransaction()
                Try
                    '========================================
                    ' 1. UPDATE STATUS REQUEST
                    '========================================

                    Dim sqlUpdate As String = " UPDATE sapermintaankaryawan SET ffcstatus = 'WAITING_DEPARTMENT'  WHERE ffcidpermintaan = @ID  AND ffcstatus = 'DRAFT' "
                    Dim affectedRows As Integer
                    Using cmdUpdate As New MySqlCommand(sqlUpdate, conn, trans)
                        cmdUpdate.Parameters.AddWithValue("@ID", _idPermintaanTerpilih)
                        affectedRows = cmdUpdate.ExecuteNonQuery()
                    End Using
                    trans.Commit()
                    PesanPopupSukses("Sukses", "Permintaan berhasil disubmit.")
                    _idPermintaanTerpilih = 0
                    _statusTerpilih = ""
                    DataPermintaanKaryawan()
                Catch ex As Exception
                    trans.Rollback()
                    PesanPopupError("Gagal melakukan submit.", ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class
