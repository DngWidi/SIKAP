
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Data
Public Class uf_calonpegawai

    Private _keywordCari As String = ""
    Private _statusCari As String = ""

    Private _idCalonPegawaiTerpilih As Long = 0

    Private _idKandidatTerpilih As Long = 0
    Private _idRekrutmenTerpilih As Long = 0
    Private _idOfferingTerpilih As Long = 0
    Private _statusTerpilih As String = ""

    Private _formSudahLoad As Boolean = False

    Private ReadOnly _warnaBiru As Color = Color.FromArgb(31, 95, 209)
    Private ReadOnly _warnaTeks As Color = Color.FromArgb(31, 41, 55)
    Private ReadOnly _warnaGaris As Color = Color.FromArgb(229, 231, 235)
    Private ReadOnly _warnaHover As Color = Color.FromArgb(239, 246, 255)

    Private Sub SalinDokumenDanSertifikat(conn As MySqlConnection, trans As MySqlTransaction, idKandidat As Long, nik As String, daftarFileBaru As List(Of String))

        ' Pemetaan ID dokumen kandidat ke ID dokumen pegawai.
        Dim petaDokumen As New Dictionary(Of Long, Long)

        ' =====================================================
        ' 1. BACA SELURUH DOKUMEN KANDIDAT
        ' =====================================================
        Dim dtDokumen As New DataTable()

        Using cmd As New MySqlCommand("SELECT ffciddokumen, ffcjenis, ffcnama, ffcfile, ffctipefile, ffnukurang, ffcketerangan " &
        "FROM sakandidatdokumen WHERE ffcidkandidat = @id ORDER BY ffciddokumen", conn, trans)

            cmd.Parameters.AddWithValue("@id", idKandidat)

            Using da As New MySqlDataAdapter(cmd)
                da.SelectCommand.Transaction = trans
                da.Fill(dtDokumen)
            End Using
        End Using

        ' =====================================================
        ' 2. SALIN FILE DAN INSERT METADATA DOKUMEN
        ' =====================================================
        For Each dr As DataRow In dtDokumen.Rows

            Dim idDokumenAsal As Long = Convert.ToInt64(dr("ffciddokumen"))
            Dim jenis As String = Convert.ToString(dr("ffcjenis"))
            Dim nama As String = Convert.ToString(dr("ffcnama"))
            Dim pathAsal As String = Convert.ToString(dr("ffcfile"))

            Dim folderTujuan As String = If(jenis.Trim().Equals("Sertifikat", StringComparison.OrdinalIgnoreCase), "Sertifikat", "Dokumen")

            '     Dim pathBaru As String = SalinFileKePegawai(pathAsal, nik, folderTujuan, daftarFileBaru)

            Using cmd As New MySqlCommand("INSERT INTO sapegawaidokumen (ffcnik, ffciddokumenasal, ffcjenis, ffcnama, ffcfile, ffctipefile, ffnukurang, ffcketerangan) " &
            "VALUES (@nik, @idAsal, @jenis, @nama, @file, @tipe, @ukuran, @keterangan)", conn, trans)

                cmd.Parameters.AddWithValue("@nik", nik)
                cmd.Parameters.AddWithValue("@idAsal", idDokumenAsal)
                cmd.Parameters.AddWithValue("@jenis", jenis)
                cmd.Parameters.AddWithValue("@nama", nama)
                cmd.Parameters.AddWithValue("@file", pathBaru)

                cmd.Parameters.AddWithValue("@tipe", If(IsDBNull(dr("ffctipefile")), CObj(DBNull.Value), dr("ffctipefile")))
                cmd.Parameters.AddWithValue("@ukuran", If(IsDBNull(dr("ffnukurang")), CObj(DBNull.Value), dr("ffnukurang")))
                cmd.Parameters.AddWithValue("@keterangan", If(IsDBNull(dr("ffcketerangan")), CObj(DBNull.Value), dr("ffcketerangan")))
                cmd.ExecuteNonQuery()

                petaDokumen(idDokumenAsal) = cmd.LastInsertedId
            End Using
        Next

        ' =====================================================
        ' 3. BACA SELURUH SERTIFIKAT KANDIDAT
        ' =====================================================
        Dim dtSertifikat As New DataTable()

        Using cmd As New MySqlCommand("SELECT ffcidsertifikat, ffciddokumen, ffcnamasertifikat, ffcpenerbit, ffcnomorsertifikat, " &
        "ffdtglterbit, ffdtglkadaluarsa, ffcketerangan FROM sakandidatsertifikat WHERE ffcidkandidat = @id ORDER BY ffcidsertifikat", conn, trans)

            cmd.Parameters.AddWithValue("@id", idKandidat)

            Using da As New MySqlDataAdapter(cmd)
                da.SelectCommand.Transaction = trans
                da.Fill(dtSertifikat)
            End Using
        End Using

        ' =====================================================
        ' 4. SALIN DETAIL SERTIFIKAT DAN RELASI DOKUMEN
        ' =====================================================
        For Each dr As DataRow In dtSertifikat.Rows

            Dim idSertifikatAsal As Long = Convert.ToInt64(dr("ffcidsertifikat"))

            Dim idDokumenPegawai As Object = DBNull.Value

            If Not IsDBNull(dr("ffciddokumen")) Then
                Dim idDokumenAsal As Long = Convert.ToInt64(dr("ffciddokumen"))

                If petaDokumen.ContainsKey(idDokumenAsal) Then
                    idDokumenPegawai = petaDokumen(idDokumenAsal)
                End If
            End If

            Using cmd As New MySqlCommand("INSERT INTO sapegawisertifikat (ffcnik, ffcidsertifikatasal, ffcidpegawaidokumen, ffcnamasertifikat, ffcpenerbit, ffcnomorsertifikat, ffdtglterbit, ffdtglkadaluarsa, ffcketerangan) " &
            "VALUES (@nik, @idAsal, @idDokumen, @nama, @penerbit,@nomor, @terbit, @kadaluarsa, @keterangan)", conn, trans)

                cmd.Parameters.AddWithValue("@nik", nik)
                cmd.Parameters.AddWithValue("@idAsal", idSertifikatAsal)
                cmd.Parameters.AddWithValue("@idDokumen", idDokumenPegawai)
                cmd.Parameters.AddWithValue("@nama", dr("ffcnamasertifikat"))
                cmd.Parameters.AddWithValue("@penerbit", dr("ffcpenerbit"))
                cmd.Parameters.AddWithValue("@nomor", dr("ffcnomorsertifikat"))
                cmd.Parameters.AddWithValue("@terbit", dr("ffdtglterbit"))
                cmd.Parameters.AddWithValue("@kadaluarsa", dr("ffdtglkadaluarsa"))
                cmd.Parameters.AddWithValue("@keterangan", dr("ffcketerangan"))

                cmd.ExecuteNonQuery()
            End Using
        Next

    End Sub


    '==========================================================
    ' FORM LOAD
    '==========================================================
    Private Sub uf_calonpegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            SetupStatusFilter()
            SetupDataGridView()

            paginationCalon.CurrentPage = 1
            paginationCalon.PageSize = 10

            _formSudahLoad = True
            LoadData()

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal menyiapkan menu Calon Pegawai." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    '==========================================================
    ' FILTER STATUS
    '==========================================================
    Private Sub SetupStatusFilter()

        cTahap.Items.Clear()

        cTahap.Items.Add("Semua Status")
        cTahap.Items.Add("CALON_PEGAWAI")
        cTahap.Items.Add("DATA_LENGKAP")
        cTahap.Items.Add("SIAP_MENJADI_PEGAWAI")
        cTahap.Items.Add("MENJADI_PEGAWAI")
        cTahap.Items.Add("BATAL")

        cTahap.SelectedIndex = 0

    End Sub

    '==========================================================
    ' SETUP DATAGRIDVIEW
    '==========================================================
    Private Sub SetupDataGridView()

        With dgvCalonPegawai

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
            .ColumnHeadersDefaultCellStyle.Font =
                New Font("Segoe UI Semibold", 9.0F)

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
        TambahKolom("colNo", "No", "", 45)

        ' ID disimpan tersembunyi untuk kebutuhan proses
        TambahKolom("ffcidcalonpegawai", "", "ffcidcalonpegawai", 0, False)
        TambahKolom("ffcidkandidat", "", "ffcidkandidat", 0, False)
        TambahKolom("ffcidrekrutmen", "", "ffcidrekrutmen", 0, False)
        TambahKolom("ffcidoffering", "", "ffcidoffering", 0, False)

        TambahKolom("ffcnokandidat", "No Kandidat", "ffcnokandidat", 125)
        TambahKolom("ffcnama", "Nama Kandidat", "ffcnama", 180)
        TambahKolom("ffcktp", "No. KTP", "ffcktp", 135)
        TambahKolom("ffcnopenawaran", "No. Offering", "ffcnopenawaran", 140)

        TambahKolom("colJabatan", "Jabatan", "NamaJabatan", 140)
        TambahKolom("colDepartemen", "Departemen", "NamaDepartment", 130)
        TambahKolom("colBagian", "Bagian", "NamaBagian", 130)

        TambahKolom("ffdmulai", "Tanggal Mulai", "ffdmulai", 110)
        dgvCalonPegawai.Columns("ffdmulai").DefaultCellStyle.Format =
            "dd/MM/yyyy"

        TambahKolom("ffcjeniskaryawan", "Jenis Karyawan", "ffcjeniskaryawan", 120)
        TambahKolom("ffctempatkerja", "Tempat Kerja", "ffctempatkerja", 150)

        TambahKolom("ffcstatus", "Status", "ffcstatus", 190)

        ' Format kolom status
        dgvCalonPegawai.Columns("ffcstatus").DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter

        ' Warna status dan baris
        AddHandler dgvCalonPegawai.CellFormatting,
            AddressOf dgvCalonPegawai_CellFormatting

        ' Nomor urut
        AddHandler dgvCalonPegawai.CellPainting, AddressOf dgvCalonPegawai_CellPainting

        AddHandler dgvCalonPegawai.SelectionChanged, AddressOf dgvCalonPegawai_SelectionChanged

    End Sub

    Private Sub TambahKolom(nama As String, judul As String, sumberData As String, lebar As Integer, Optional terlihat As Boolean = True)

        Dim kolom As New DataGridViewTextBoxColumn()

        With kolom
            .Name = nama
            .HeaderText = judul
            .DataPropertyName = sumberData
            .Width = If(lebar > 0, lebar, 100)
            .Visible = terlihat
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        dgvCalonPegawai.Columns.Add(kolom)

    End Sub

    '==========================================================
    ' LOAD DATA
    '==========================================================
    Private Sub LoadData()

        If Not _formSudahLoad Then Return

        Try
            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT cp.ffcidcalonpegawai,cp.ffcidkandidat,cp.ffcidrekrutmen,cp.ffcidoffering, cp.ffcktp, cp.ffcnik,cp.ffcstatus,cp.ffdmulai, cp.ffdbergabung, cp.ffcjabatan, cp.ffcdepartemen, " &
                    "cp.ffcbagian, cp.ffcjeniskaryawan, cp.ffctempatkerja,k.ffcnokandidat, k.ffcnama, o.ffcnopenawaran, COALESCE(j.ffcnama, cp.ffcjabatan) AS NamaJabatan, COALESCE(d.ffcnama, cp.ffcdepartemen) AS NamaDepartment, " &
                    "COALESCE(b.ffcnama, cp.ffcbagian) AS NamaBagian FROM sacalonpegawai cp INNER JOIN sakandidat k ON cp.ffcidkandidat = k.ffcidkandidat INNER JOIN sapenawarankerja o ON cp.ffcidoffering = o.ffcidoffering " &
                    "LEFT JOIN sajabatan j ON cp.ffcjabatan = j.ffckls LEFT JOIN sadepartment d ON cp.ffcdepartemen = d.ffckode LEFT JOIN sabagian b ON cp.ffcbagian = b.ffcbag WHERE 1=1 "

                If _keywordCari <> "" Then
                    sql &= "AND (k.ffcnokandidat LIKE @keyword OR k.ffcnama LIKE @keyword OR cp.ffcktp LIKE @keyword OR o.ffcnopenawaran LIKE @keyword ) "
                End If

                If _statusCari <> "" Then
                    sql &= "AND cp.ffcstatus = @status "
                End If

                sql &= "ORDER BY CASE WHEN cp.ffcstatus = 'BATAL' THEN 1 WHEN cp.ffcstatus = 'MENJADI_PEGAWAI' THEN 2 ELSE 0 END, cp.ffdinput DESC, cp.ffcidcalonpegawai DESC "

                sql &= "LIMIT @offset, @pageSize"

                Using cmd As New MySqlCommand(sql, conn)

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
                    End If

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@status", _statusCari)
                    End If
                    cmd.Parameters.AddWithValue("@offset", paginationCalon.Offset)
                    cmd.Parameters.AddWithValue("@pageSize", paginationCalon.PageSize)

                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgvCalonPegawai.DataSource = dt

                End Using

            End Using

            UpdatePagination()
            UpdateInfoData()
            If dgvCalonPegawai.Rows.Count > 0 Then

                'Pilih kembali baris pertama setelah data dimuat
                dgvCalonPegawai.CurrentCell = dgvCalonPegawai.Rows(0).Cells("ffcnokandidat")

                dgvCalonPegawai.Rows(0).Selected = True

                'Aktifkan tombol berdasarkan data terpilih
                AmbilDataBarisTerpilih()
            Else
                'Jika tidak ada data, tombol tetap nonaktif
                ResetPilihan()

            End If

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat data calon pegawai." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    '==========================================================
    ' TOTAL RECORD
    '==========================================================
    Private Function GetTotalRecord() As Integer

        Try
            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT COUNT(*) FROM sacalonpegawai cp INNER JOIN sakandidat k ON cp.ffcidkandidat = k.ffcidkandidat INNER JOIN sapenawarankerja o ON cp.ffcidoffering = o.ffcidoffering WHERE 1=1 "

                If _keywordCari <> "" Then
                    sql &= "AND (k.ffcnokandidat LIKE @keyword OR k.ffcnama LIKE @keyword OR cp.ffcktp LIKE @keyword OR o.ffcnopenawaran LIKE @keyword ) "
                End If

                If _statusCari <> "" Then
                    sql &= "AND cp.ffcstatus = @status "
                End If

                Using cmd As New MySqlCommand(sql, conn)

                    If _keywordCari <> "" Then
                        cmd.Parameters.AddWithValue("@keyword", "%" & _keywordCari & "%")
                    End If

                    If _statusCari <> "" Then
                        cmd.Parameters.AddWithValue("@status", _statusCari)
                    End If

                    Return Convert.ToInt32(cmd.ExecuteScalar())

                End Using

            End Using

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal menghitung data calon pegawai." & Environment.NewLine & ex.Message)
            Return 0
        End Try

    End Function
    Private Function KonversiJenisKelamin(nilai As Object) As String

        If nilai Is Nothing OrElse IsDBNull(nilai) Then
            Return ""
        End If

        Dim jenisKelamin As String =
        Convert.ToString(nilai).Trim().ToUpperInvariant()

        Select Case jenisKelamin
            Case "L", "M", "LAKI-LAKI", "LAKI LAKI", "MALE"
                Return "M"

            Case "P", "F", "PEREMPUAN", "FEMALE"
                Return "F"

            Case Else
                Return ""
        End Select

    End Function
    '==========================================================
    ' PAGINATION DAN INFO DATA
    '==========================================================
    Private Sub UpdatePagination()
        paginationCalon.TotalRecord = GetTotalRecord()
    End Sub

    Private Sub UpdateInfoData()

        Dim total As Integer = paginationCalon.TotalRecord

        If total = 0 OrElse dgvCalonPegawai.Rows.Count = 0 Then
            lblInfo.Text = "Tidak ada data calon pegawai."
            Return
        End If

        Dim awal As Integer = paginationCalon.Offset + 1
        Dim akhir As Integer = paginationCalon.Offset + dgvCalonPegawai.Rows.Count

        lblInfo.Text = "Menampilkan " & awal.ToString() & "-" & akhir.ToString() & " dari " & total.ToString() & " Data"

    End Sub

    Private Sub paginationCalon_PageChanged(sender As Object, e As EventArgs) Handles paginationCalon.PageChanged

        LoadData()

    End Sub

    '==========================================================
    ' CARI
    '==========================================================
    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click

        _keywordCari = tPencarian.Text.Trim()

        If cTahap.SelectedIndex <= 0 Then
            _statusCari = ""
        Else
            _statusCari = cTahap.Text.Trim()
        End If

        paginationCalon.CurrentPage = 1
        LoadData()

    End Sub

    '==========================================================
    ' RESET
    '==========================================================
    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click
        tPencarian.Clear()
        cTahap.SelectedIndex = 0

        _keywordCari = ""
        _statusCari = ""

        paginationCalon.CurrentPage = 1

        LoadData()

    End Sub

    '==========================================================
    ' NOMOR URUT
    '==========================================================
    Private Sub dgvCalonPegawai_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
        If dgvCalonPegawai.Columns(e.ColumnIndex).Name <> "colNo" Then
            Return
        End If

        e.PaintBackground(e.CellBounds, True)

        Dim nomor As Integer = paginationCalon.Offset + e.RowIndex + 1

        TextRenderer.DrawText(e.Graphics, nomor.ToString(), New Font("Segoe UI", 9.0F), e.CellBounds, _warnaTeks, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)

        e.Handled = True

    End Sub

    '==========================================================
    ' FORMAT STATUS
    '==========================================================
    Private Sub dgvCalonPegawai_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        If dgvCalonPegawai.Columns(e.ColumnIndex).Name <> "ffcstatus" Then
            Return
        End If

        Dim status As String =
            If(e.Value Is Nothing OrElse IsDBNull(e.Value),
               "",
               e.Value.ToString().Trim())

        Select Case status

            Case "CALON_PEGAWAI"
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235)

            Case "DATA_LENGKAP"
                e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9)

            Case "SIAP_MENJADI_PEGAWAI"
                e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105)

            Case "MENJADI_PEGAWAI"
                e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52)

            Case "BATAL"
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38)

            Case Else
                e.CellStyle.ForeColor = _warnaTeks

        End Select

        e.CellStyle.Font = New Font("Segoe UI Semibold", 8.5F)

    End Sub

    '==========================================================
    ' PILIH BARIS
    '==========================================================
    Private Sub dgvCalonPegawai_SelectionChanged(sender As Object, e As EventArgs)
        AmbilDataBarisTerpilih()

    End Sub

    Private Sub AmbilDataBarisTerpilih()

        ResetPilihan()

        If dgvCalonPegawai.CurrentRow Is Nothing Then Return
        If dgvCalonPegawai.CurrentRow.IsNewRow Then Return

        Dim row As DataGridViewRow = dgvCalonPegawai.CurrentRow

        _idCalonPegawaiTerpilih = AmbilLong(row, "ffcidcalonpegawai")
        _idKandidatTerpilih = AmbilLong(row, "ffcidkandidat")
        _idRekrutmenTerpilih = AmbilLong(row, "ffcidrekrutmen")
        _idOfferingTerpilih = AmbilLong(row, "ffcidoffering")
        _statusTerpilih = AmbilString(row, "ffcstatus")

        bDetail.Enabled = _idCalonPegawaiTerpilih > 0
        bProses.Enabled = _idCalonPegawaiTerpilih > 0

        bJadikanPegawai.Enabled = _idCalonPegawaiTerpilih > 0 AndAlso _statusTerpilih = "SIAP_MENJADI_PEGAWAI"

    End Sub

    Private Function AmbilLong(row As DataGridViewRow, namaKolom As String) As Long

        If Not dgvCalonPegawai.Columns.Contains(namaKolom) Then
            Return 0
        End If

        Dim nilai As Object = row.Cells(namaKolom).Value

        If nilai Is Nothing OrElse IsDBNull(nilai) Then Return 0

        Return Convert.ToInt64(nilai)

    End Function

    Private Function AmbilString(row As DataGridViewRow, namaKolom As String) As String

        If Not dgvCalonPegawai.Columns.Contains(namaKolom) Then
            Return ""
        End If

        Dim nilai As Object = row.Cells(namaKolom).Value

        If nilai Is Nothing OrElse IsDBNull(nilai) Then Return ""

        Return nilai.ToString().Trim()

    End Function

    Private Sub ResetPilihan()

        _idCalonPegawaiTerpilih = 0
        _idKandidatTerpilih = 0
        _idRekrutmenTerpilih = 0
        _idOfferingTerpilih = 0
        _statusTerpilih = ""

        bDetail.Enabled = False
        bProses.Enabled = False
        bJadikanPegawai.Enabled = False

    End Sub

    '==========================================================
    ' DETAIL
    '==========================================================
    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click

        If _idCalonPegawaiTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Pilih data calon pegawai terlebih dahulu.")
            Return
        End If
        'Ambil ID calon pegawai dari baris yang dipilih
        Dim idCalonPegawaiTerpilih As Long = Convert.ToInt64(dgvCalonPegawai.CurrentRow.Cells("ffcidcalonpegawai").Value)

        'Buka form detail calon pegawai
        Dim frm As New frmCalonPegawai()
        frm.IdCalonPegawai = idCalonPegawaiTerpilih
        frm.ShowDialog()

    End Sub

    '==========================================================
    ' PROSES
    '==========================================================
    Private Sub bProses_Click(sender As Object, e As EventArgs) Handles bProses.Click
        Try
            Using frm As New frmCalonPegawai()

                frm.IdCalonPegawai = _idCalonPegawaiTerpilih
                frm.ModeProses = True
                frm.ShowDialog(Me)

            End Using

            'Muat ulang data setelah form ditutup
            LoadData()

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal membuka proses calon pegawai." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    '==========================================================
    ' JADIKAN PEGAWAI
    '==========================================================



    Private Sub bJadikanPegawai_Click(sender As Object, e As EventArgs) Handles bJadikanPegawai.Click



        If _idCalonPegawaiTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Pilih calon pegawai terlebih dahulu.")
            Return
        End If

        If _statusTerpilih <> "SIAP_MENJADI_PEGAWAI" Then
            PesanPopupPeringatan("Peringatan", "Hanya calon pegawai berstatus SIAP_MENJADI_PEGAWAI yang dapat dikonversi.")
            Return
        End If


        Dim HasilKonfirmasi As DialogResult = PesanPopupKonfirmasi("Konfirmasi", "Jadikan calon pegawai ini sebagai pegawai?" & Environment.NewLine & " Data pegawai, penghasilan, dokumen, dan sertifikat akan diproses.")
        If HasilKonfirmasi = DialogResult.No Then
            Return
        End If





        Dim nikBaru As String = String.Empty
        Dim daftarFileBaru As New List(Of String)
        Dim prosesBerhasil As Boolean = False

        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()

                Using trans As MySqlTransaction = conn.BeginTransaction()

                    Try
                        ' ==================================================
                        ' 1. AMBIL DATA CALON PEGAWAI DAN OFFERING
                        ' ==================================================
                        Dim dt As New DataTable()

                        Dim sqlData As String = "SELECT cp.ffcidcalonpegawai, cp.ffcidkandidat, cp.ffcidoffering, cp.ffcktp, cp.ffdmulai, cp.ffcjabatan, cp.ffcdepartemen, cp.ffcbagian, cp.ffcjeniskaryawan, cp.ffctempatkerja, " &
                        "k.ffcnama, k.ffctempatlahir, k.ffdtgllahir, k.ffcjeniskelamin, k.ffcstatuspernikahan, k.ffcnik AS ktp, k.ffcnpwp, k.ffcnotelp, k.ffcemail, k.ffcalamat, k.ffcdomisili, " &
                        "k.ffcagama, o.ffngajipokok, o.ffntunjangantetap, o.ffntunjanganlain, o.ffntransport, o.ffnmakan FROM sacalonpegawai cp INNER JOIN sakandidat k ON k.ffcidkandidat = cp.ffcidkandidat " &
                        "INNER JOIN sapenawarankerja o ON o.ffcidoffering = cp.ffcidoffering WHERE cp.ffcidcalonpegawai = @id AND cp.ffcstatus = 'SIAP_MENJADI_PEGAWAI' AND o.ffcstatus = 'ACCEPTED' FOR UPDATE"

                        Using cmd As New MySqlCommand(sqlData, conn, trans)
                            cmd.Parameters.AddWithValue("@id", _idCalonPegawaiTerpilih)

                            Using da As New MySqlDataAdapter(cmd)
                                da.Fill(dt)
                            End Using
                        End Using

                        If dt.Rows.Count <> 1 Then
                            Throw New Exception("Data calon pegawai tidak ditemukan, status berubah, " & "atau Offering belum berstatus ACCEPTED.")
                        End If

                        Dim dr As DataRow = dt.Rows(0)
                        Dim idKandidat As Long = Convert.ToInt64(dr("ffcidkandidat"))

                        ' ==================================================
                        ' 2. GENERATE NIK PEGAWAI YYMMSS
                        ' ==================================================
                        Dim prefix As String = Date.Today.ToString("yyMM")
                        Dim nomorUrut As Integer = 1

                        Dim sqlMax As String = "SELECT COALESCE(MAX(CAST(RIGHT(ffcnik, 2) As UNSIGNED)), 0) FROM sajatidiri WHERE LEFT(ffcnik, 4) = @prefix And RIGHT(ffcnik, 2) REGEXP '^[0-9]{2}$'"

                        Using cmd As New MySqlCommand(sqlMax, conn, trans)
                            cmd.Parameters.AddWithValue("@prefix", prefix)
                            nomorUrut = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                        End Using

                        If nomorUrut > 99 Then
                            Throw New Exception("Nomor urut NIK bulan ini sudah mencapai batas 99.")
                        End If

                        nikBaru = prefix & nomorUrut.ToString("00")

                        ' Pastikan NIK belum digunakan.
                        Using cmd As New MySqlCommand("SELECT COUNT(*) FROM sajatidiri WHERE ffcnik = @nik", conn, trans)
                            cmd.Parameters.AddWithValue("@nik", nikBaru)
                            If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                                Throw New Exception("NIK " & nikBaru & " sudah digunakan. Silakan coba kembali.")
                            End If
                        End Using

                        ' ==================================================
                        ' 3. KONVERSI JENIS KELAMIN KE M / F
                        ' ==================================================
                        Dim sex As String = KonversiJenisKelamin(dr("ffcjeniskelamin"))

                        If sex <> "M" AndAlso sex <> "F" Then
                            Throw New Exception("Jenis kelamin kandidat tidak valid.  Nilai harus dapat dikonversi menjadi M atau F.")
                        End If

                        ' ==================================================
                        ' 4. INSERT MASTER PEGAWAI
                        ' ==================================================
                        Dim sqlPegawai As String = "INSERT INTO sajatidiri (ffcnik, ffcktp, ffcnama, ffcdepart, ffcbagian, ffcjabatan, ffcsex, ffdmasuk, ffcstatuspeg, ffcnpwp, ffclahir, ffdlahir, ffcagama, ffcemail, " &
                        "ffcstatuskawin, ffctelp, ffcalamatktp, ffcdomisili) VALUES (@nik, @ktp, @nama, @depart, @bagian, @jabatan,@sex, @masuk, @statuspeg, @npwp, @lahir, @tgllahir, @agama, @email, @statuskawin, " &
                        "@telp, @alamat, @domisili)"

                        Using cmd As New MySqlCommand(sqlPegawai, conn, trans)

                            cmd.Parameters.AddWithValue("@nik", nikBaru)
                            cmd.Parameters.AddWithValue("@ktp", dr("ktp"))
                            cmd.Parameters.AddWithValue("@nama", dr("ffcnama"))
                            cmd.Parameters.AddWithValue("@depart", dr("ffcdepartemen"))
                            cmd.Parameters.AddWithValue("@bagian", dr("ffcbagian"))
                            cmd.Parameters.AddWithValue("@jabatan", dr("ffcjabatan"))
                            cmd.Parameters.AddWithValue("@sex", sex)
                            cmd.Parameters.AddWithValue("@masuk", dr("ffdmulai"))
                            cmd.Parameters.AddWithValue("@statuspeg", dr("ffcjeniskaryawan"))
                            cmd.Parameters.AddWithValue("@npwp", dr("ffcnpwp"))
                            cmd.Parameters.AddWithValue("@lahir", dr("ffctempatlahir"))
                            cmd.Parameters.AddWithValue("@tgllahir", dr("ffdtgllahir"))
                            cmd.Parameters.AddWithValue("@agama", dr("ffcagama"))
                            cmd.Parameters.AddWithValue("@email", dr("ffcemail"))
                            cmd.Parameters.AddWithValue("@statuskawin", dr("ffcstatuspernikahan"))
                            cmd.Parameters.AddWithValue("@telp", dr("ffcnotelp"))
                            cmd.Parameters.AddWithValue("@alamat", dr("ffcalamat"))
                            cmd.Parameters.AddWithValue("@domisili", dr("ffcdomisili"))

                            cmd.ExecuteNonQuery()
                        End Using

                        ' ==================================================
                        ' 5. INSERT DETAIL PENGHASILAN
                        ' ==================================================
                        Dim sqlDetail As String = "INSERT INTO sajatidiri_detil1 (ffcnik, ffcgp, ffctunjabat, ffctunlain, ffntrans, ffnmakan) VALUES (@nik, @gp, @tunjabat, @tunlain, @trans, @makan)"

                        Using cmd As New MySqlCommand(sqlDetail, conn, trans)

                            cmd.Parameters.AddWithValue("@nik", nikBaru)
                            cmd.Parameters.AddWithValue("@gp", dr("ffngajipokok"))
                            cmd.Parameters.AddWithValue("@tunjabat", dr("ffntunjangantetap"))
                            cmd.Parameters.AddWithValue("@tunlain", dr("ffntunjanganlain"))
                            cmd.Parameters.AddWithValue("@trans", dr("ffntransport"))
                            cmd.Parameters.AddWithValue("@makan", dr("ffnmakan"))

                            cmd.ExecuteNonQuery()
                        End Using

                        ' ==================================================
                        ' 6. SALIN DOKUMEN DAN SERTIFIKAT
                        '    Semua INSERT memakai transaksi yang sama.
                        ' ==================================================
                        SalinDokumenDanSertifikat(conn, trans, idKandidat, nikBaru, daftarFileBaru)

                        ' ==================================================
                        ' 7. UPDATE STATUS PALING AKHIR
                        ' ==================================================
                        Using cmd As New MySqlCommand("UPDATE sacalonpegawai SET ffcstatus = 'MENJADI_PEGAWAI', ffcnik = @nik, ffdupdate = NOW() " &
                        "WHERE ffcidcalonpegawai = @id AND ffcstatus = 'SIAP_MENJADI_PEGAWAI'", conn, trans)

                            cmd.Parameters.AddWithValue("@nik", nikBaru)
                            cmd.Parameters.AddWithValue("@id", _idCalonPegawaiTerpilih)

                            If cmd.ExecuteNonQuery() <> 1 Then
                                Throw New Exception("Status calon pegawai gagal diperbarui.Transaksi dibatalkan.")
                            End If
                        End Using

                        ' ==================================================
                        ' 8. COMMIT
                        ' ==================================================
                        trans.Commit()
                        prosesBerhasil = True

                    Catch
                        ' Rollback seluruh perubahan database.
                        Try
                            trans.Rollback()
                        Catch
                            ' Jangan menutupi error utama.
                        End Try

                        Throw
                    End Try
                End Using
            End Using

        Catch ex As Exception

            ' ======================================================
            ' HAPUS FILE FISIK BARU JIKA PROSES GAGAL
            ' ======================================================
            For Each pathFile As String In daftarFileBaru
                Try
                    If Not String.IsNullOrWhiteSpace(pathFile) AndAlso File.Exists(pathFile) Then
                        File.Delete(pathFile)
                    End If
                Catch
                    ' Jika file gagal dihapus, proses utama tetap dilaporkan.
                End Try
            Next

            PesanPopupError("ERROR", "Gagal menjadikan pegawai." & Environment.NewLine & ex.Message)

            Return
        End Try

        ' ==========================================================
        ' 9. SUKSES: TAMPILKAN NIK DAN MUAT ULANG GRID
        ' ==========================================================
        If prosesBerhasil Then
            PesanPopupSukses("SUKSES", "Calon pegawai berhasil menjadi pegawai." &
            Environment.NewLine & "NIK Pegawai: " & nikBaru)

            LoadData()
        End If

    End Sub





End Class

