Imports System.Data
Imports System.Drawing
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports SIKAP.frmKaryawanAdd

Public Class uf_karyawan

    Private _keywordCari As String = String.Empty
    Private _statusCari As String = String.Empty
    Private _nikTerpilih As String = String.Empty
    Private _formSudahLoad As Boolean = False

    Private ReadOnly _warnaBiru As Color = Color.FromArgb(31, 95, 209)
    Private ReadOnly _warnaTeks As Color = Color.FromArgb(31, 41, 55)
    Private ReadOnly _warnaGaris As Color = Color.FromArgb(229, 231, 235)
    Private ReadOnly _warnaHover As Color = Color.FromArgb(239, 246, 255)

#Region "FORM LOAD"

    Private Sub uf_karyawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupFilterStatus()
            SetupDataGridView()

            paginationKaryawan.CurrentPage = 1
            paginationKaryawan.PageSize = 10

            ResetPilihan()
            _formSudahLoad = True
            LoadData()

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal menyiapkan menu Data Karyawan." &
                            Environment.NewLine & ex.Message)
        End Try
    End Sub

    Private Sub SetupFilterStatus()
        cFilter.Items.Clear()
        cFilter.Items.Add("Semua Status")
        cFilter.Items.Add("Kontrak")
        cFilter.Items.Add("Permanent")
        cFilter.Items.Add("Internship")
        cFilter.SelectedIndex = 0
    End Sub

#End Region

#Region "DATAGRIDVIEW"

    Private Sub SetupDataGridView()
        With dgvDataKaryawan
            .Columns.Clear()
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .ScrollBars = ScrollBars.Both
            .ColumnHeadersHeight = 38
            .RowTemplate.Height = 34
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = _warnaGaris
            .EnableHeadersVisualStyles = False

            .ColumnHeadersDefaultCellStyle.BackColor = _warnaBiru
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0F)
            .ColumnHeadersDefaultCellStyle.SelectionBackColor = _warnaBiru
            .ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White

            .DefaultCellStyle.Font = New Font("Segoe UI", 9.0F)
            .DefaultCellStyle.ForeColor = _warnaTeks
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.SelectionBackColor = _warnaHover
            .DefaultCellStyle.SelectionForeColor = _warnaTeks
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
        End With

        ' Nomor urut
        TambahKolom("colNo", "No.", "", 45)

        ' NIK digunakan sebagai identitas untuk Detail/Edit.
        TambahKolom("ffcnik", "NIK", "ffcnik", 90)
        TambahKolom("ffcnama", "Nama Karyawan", "ffcnama", 190)
        TambahKolom("colSex", "L/P", "ffcsex", 55)
        TambahKolom("colDepartemen", "Departemen", "NamaDepartment", 145)
        TambahKolom("colBagian", "Bagian", "NamaBagian", 145)
        TambahKolom("colJabatan", "Jabatan", "NamaJabatan", 145)
        TambahKolom("ffdmasuk", "Tanggal Masuk", "ffdmasuk", 110)
        TambahKolom("ffcstatuspeg", "Status Pegawai", "ffcstatuspeg", 115)

        dgvDataKaryawan.Columns("ffdmasuk").DefaultCellStyle.Format = "dd/MM/yyyy"
        dgvDataKaryawan.Columns("colSex").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter
        dgvDataKaryawan.Columns("ffcstatuspeg").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter

        AddHandler dgvDataKaryawan.CellPainting,
            AddressOf dgvPegawai_CellPainting
        AddHandler dgvDataKaryawan.SelectionChanged,
            AddressOf dgvPegawai_SelectionChanged
    End Sub

    Private Sub TambahKolom(nama As String,
                            judul As String,
                            sumberData As String,
                            lebar As Integer)

        Dim kolom As New DataGridViewTextBoxColumn()

        With kolom
            .Name = nama
            .HeaderText = judul
            .DataPropertyName = sumberData
            .Width = lebar
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        dgvDataKaryawan.Columns.Add(kolom)
    End Sub

    Private Sub dgvPegawai_CellPainting(sender As Object,
                                        e As DataGridViewCellPaintingEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvDataKaryawan.Columns(e.ColumnIndex).Name <> "colNo" Then Return

        e.PaintBackground(e.CellBounds, True)

        Dim nomor As Integer = paginationKaryawan.Offset + e.RowIndex + 1
        TextRenderer.DrawText(
            e.Graphics,
            nomor.ToString(),
            New Font("Segoe UI", 9.0F),
            e.CellBounds,
            _warnaTeks,
            TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

        e.Handled = True
    End Sub

    Private Sub dgvPegawai_SelectionChanged(sender As Object, e As EventArgs)
        AmbilDataBarisTerpilih()
    End Sub

#End Region

#Region "QUERY DATA"

    Private Function BuatKondisiFilter() As String
        Dim kondisi As String = " WHERE 1=1 "

        If _keywordCari <> String.Empty Then
            kondisi &= " AND (p.ffcnik LIKE @keyword " &
                       "OR p.ffcnama LIKE @keyword " &
                       "OR p.ffcktp LIKE @keyword) "
        End If

        If _statusCari <> String.Empty Then
            kondisi &= " AND p.ffcstatuspeg = @status "
        End If

        Return kondisi
    End Function

    Private Sub TambahParameterFilter(cmd As MySqlCommand)
        If _keywordCari <> String.Empty Then
            cmd.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
        End If

        If _statusCari <> String.Empty Then
            cmd.Parameters.AddWithValue("@status", _statusCari)
        End If
    End Sub

    Private Function GetTotalRecord() As Integer
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()

                Dim sql As String = "SELECT COUNT(*) FROM sajatidiri p " & BuatKondisiFilter()

                Using cmd As New MySqlCommand(sql, conn)
                    TambahParameterFilter(cmd)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal menghitung data karyawan." &
                            Environment.NewLine & ex.Message)
            Return 0
        End Try
    End Function

    Private Sub LoadData()
        If Not _formSudahLoad Then Return

        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()

                Dim sql As String = "SELECT p.ffcnik, p.ffcnama, p.ffcsex, p.ffcdepart, p.ffcbagian, p.ffcjabatan, p.ffdmasuk, " &
                    "p.ffcstatuspeg, COALESCE(d.ffcnama, p.ffcdepart) AS NamaDepartment, COALESCE(b.ffcnama, p.ffcbagian) AS NamaBagian, COALESCE(j.ffcnama, p.ffcjabatan) AS NamaJabatan " &
                    "FROM sajatidiri p LEFT JOIN sadepartment d ON p.ffcdepart = d.ffckode LEFT JOIN sabagian b ON p.ffcbagian = b.ffcbag LEFT JOIN sajabatan j ON p.ffcjabatan = j.ffckls " &
                    BuatKondisiFilter() & " ORDER BY p.ffdmasuk DESC, p.ffcnik DESC LIMIT @offset, @pageSize"

                Using cmd As New MySqlCommand(sql, conn)
                    TambahParameterFilter(cmd)
                    cmd.Parameters.AddWithValue("@offset", paginationKaryawan.Offset)
                    cmd.Parameters.AddWithValue("@pageSize", paginationKaryawan.PageSize)

                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgvDataKaryawan.DataSource = dt
                End Using
            End Using

            UpdatePagination()
            UpdateInfoData()

            If dgvDataKaryawan.Rows.Count > 0 Then
                dgvDataKaryawan.ClearSelection()
                dgvDataKaryawan.CurrentCell =
                    dgvDataKaryawan.Rows(0).Cells("ffcnik")
                dgvDataKaryawan.Rows(0).Selected = True
                AmbilDataBarisTerpilih()
            Else
                ResetPilihan()
            End If

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat data karyawan." &
                            Environment.NewLine & ex.Message)
        End Try
    End Sub

#End Region

#Region "PAGINATION"

    Private Sub UpdatePagination()
        paginationKaryawan.TotalRecord = GetTotalRecord()
    End Sub

    Private Sub UpdateInfoData()
        Dim total As Integer = paginationKaryawan.TotalRecord

        If total = 0 OrElse dgvDataKaryawan.Rows.Count = 0 Then
            lblInfo.Text = "Tidak ada data karyawan."
            Return
        End If

        Dim awal As Integer = paginationKaryawan.Offset + 1
        Dim akhir As Integer = paginationKaryawan.Offset + dgvDataKaryawan.Rows.Count

        lblInfo.Text = "Menampilkan " & awal.ToString() & "-" &
                       akhir.ToString() & " dari " & total.ToString() & " Data"
    End Sub

    Private Sub paginationCalon_PageChanged(sender As Object, e As EventArgs) Handles paginationKaryawan.PageChanged
        LoadData()
    End Sub

#End Region

#Region "PENCARIAN DAN RESET"

    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click
        TerapkanFilter()
    End Sub

    Private Sub TerapkanFilter()
        _keywordCari = tPencarian.Text.Trim()

        If cFilter.SelectedIndex <= 0 Then
            _statusCari = String.Empty
        Else
            _statusCari = cFilter.Text.Trim()
        End If

        paginationKaryawan.CurrentPage = 1
        LoadData()
    End Sub

    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click
        tPencarian.Clear()
        cFilter.SelectedIndex = 0

        _keywordCari = String.Empty
        _statusCari = String.Empty

        paginationKaryawan.CurrentPage = 1
        LoadData()
    End Sub

    Private Sub tPencarian_KeyDown(sender As Object,
                                   e As KeyEventArgs) Handles tPencarian.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TerapkanFilter()
        End If
    End Sub

#End Region

#Region "PILIH DATA"

    Private Sub AmbilDataBarisTerpilih()
        ResetPilihan()

        If dgvDataKaryawan.CurrentRow Is Nothing Then Return
        If dgvDataKaryawan.CurrentRow.IsNewRow Then Return

        Dim nilai As Object =
            dgvDataKaryawan.CurrentRow.Cells("ffcnik").Value

        If nilai Is Nothing OrElse IsDBNull(nilai) Then Return

        _nikTerpilih = Convert.ToString(nilai).Trim()

        bDetail.Enabled = _nikTerpilih <> String.Empty
        bEdit.Enabled = _nikTerpilih <> String.Empty
    End Sub

    Private Sub ResetPilihan()
        _nikTerpilih = String.Empty
        bDetail.Enabled = False
        bEdit.Enabled = False
    End Sub

    Private Function ValidasiPilihan() As Boolean
        If String.IsNullOrWhiteSpace(_nikTerpilih) Then
            PesanPopupPeringatan("Peringatan", "Pilih data karyawan terlebih dahulu.")
            Return False
        End If

        Return True
    End Function

#End Region

#Region "TOMBOL AKSI"
    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Dim frm As New frmKaryawanAdd()

        frm.ModeForm = ModeFormPegawai.Tambah
        frm.ShowDialog()
    End Sub

    ' Tombol Edit pada Designer lama bernama bEdit.
    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click
        Dim frm As New frmKaryawanAdd()

        frm.ModeForm = ModeFormPegawai.Edit
        frm.NikPegawai = "261001"
        frm.ShowDialog()
    End Sub

    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click
        Dim frm As New frmKaryawanAdd()

        frm.ModeForm = ModeFormPegawai.Detail
        frm.NikPegawai = "261001"
        frm.ShowDialog()
    End Sub

#End Region

End Class
