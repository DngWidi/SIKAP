Imports System.IO
Imports System.Security
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class frmKandidatAdd
    Public Enum ModeForm
        Tambah
        Edit
        View
    End Enum
    Private _mode As ModeForm = ModeForm.Tambah
    Private _idKandidat As Long = 0
    Private _deletedPendidikanIds As New List(Of Long)
    Private _deletedPengalamanIds As New List(Of Long)
    Private _deletedKeahlianIds As New List(Of Long)
    Private _deletedSertifikatIds As New List(Of Long)
    Private _deletedDokumenIds As New List(Of Long)
    Private _fotoFileName As String = String.Empty
    'Path foto sementara
    Private _fotoPath As String = String.Empty
    Private _userLogin As String = Environment.UserName
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
    Public Property Mode As ModeForm
        Get
            Return _mode
        End Get
        Set(value As ModeForm)
            _mode = value
        End Set
    End Property

    Public Property IdKandidat As Long
        Get
            Return _idKandidat
        End Get
        Set(value As Long)
            _idKandidat = value
        End Set
    End Property

#Region "Function"
    Private Function NullIfEmpty(value As String) As Object

        If String.IsNullOrWhiteSpace(value) Then

            Return DBNull.Value

        End If

        Return value.Trim()

    End Function
    Private Function GetCellValue(row As DataGridViewRow,
    columnName As String) As Object

        If Not dgvColumnExists(row.DataGridView, columnName) Then

            Return DBNull.Value

        End If


        Dim value As Object = row.Cells(columnName).Value


        If value Is Nothing Then

            Return DBNull.Value

        End If


        If String.IsNullOrWhiteSpace(value.ToString()) Then

            Return DBNull.Value

        End If


        Return value

    End Function
    Private Function dgvColumnExists(dgv As DataGridView, columnName As String) As Boolean

        If dgv Is Nothing Then

            Return False

        End If


        Return dgv.Columns.Contains(columnName)

    End Function
    Private Function GenerateNoKandidat() As String

        '========================================
        ' FORMAT SEMENTARA
        ' KND-YYYYMM-XXXX
        '========================================

        Dim prefix As String =
            "KND-" & Date.Now.ToString("yyyyMM") & "-"

        Try

            Dim nomor As Integer = 1

            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "SELECT IFNULL(MAX(CAST(RIGHT(ffcnokandidat,4) AS UNSIGNED)),0) + 1 FROM sakandidat WHERE ffcnokandidat LIKE @Prefix"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Prefix", prefix & "%")
                    nomor = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
            Return prefix & nomor.ToString("0000")
        Catch ex As Exception
            'Fallback
            Return prefix & "0001"
        End Try
    End Function
    Private Function ValidasiInput() As Boolean

        If String.IsNullOrWhiteSpace(tnamalengkap.Text) Then
            PesanPopupPeringatan("Peringatan", "Nama lengkap kandidat wajib diisi.")
            tnamalengkap.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(tnik.Text) Then
            PesanPopupPeringatan("Peringatan", "NIK kandidat wajib diisi.")
            tnik.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(ttempatlahir.Text) Then
            PesanPopupPeringatan("Peringatan", "Tempat lahir wajib diisi.")
            ttempatlahir.Focus()
            Return False
        End If

        If ckelamin.SelectedIndex = -1 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih jenis kelamin.")
            ckelamin.Focus()
            Return False
        End If

        If cstatuspernikahan.SelectedIndex = -1 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih status pernikahan.")
            cstatuspernikahan.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(tnotelp.Text) Then
            PesanPopupPeringatan("Peringatan", "Nomor HP wajib diisi.")
            tnotelp.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(temail.Text) Then
            PesanPopupPeringatan("Peringatan", "Email wajib diisi.")
            temail.Focus()
            Return False

        End If


        '========================================
        ' VALIDASI EMAIL
        '========================================

        If Not IsValidEmail(temail.Text.Trim()) Then
            PesanPopupPeringatan("Peringatan", "Format email tidak valid.")
            temail.Focus()
            Return False
        End If
        Return True

    End Function
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr As New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try

    End Function
    Private Function SimpanFoto() As String

        If String.IsNullOrWhiteSpace(_fotoPath) Then

            Return String.Empty

        End If


        If Not File.Exists(_fotoPath) Then

            Return String.Empty

        End If


        Dim folderFoto As String = Path.Combine(Application.StartupPath, "Data", "Kandidat", "Foto")


        If Not Directory.Exists(folderFoto) Then

            Directory.CreateDirectory(folderFoto)

        End If


        Dim extension As String = Path.GetExtension(_fotoPath)


        Dim namaFile As String = tkandidat.Text.Trim() & extension


        Dim targetPath As String = Path.Combine(folderFoto, namaFile)


        File.Copy(_fotoPath, targetPath, True)


        Return Path.Combine("Data", "Kandidat", "Foto", namaFile)

    End Function
    Private Function GetYearValue(row As DataGridViewRow, columnName As String) As Object
        If Not dgvColumnExists(row.DataGridView, columnName) Then
            Return DBNull.Value
        End If

        Dim value As Object = row.Cells(columnName).Value
        If value Is Nothing OrElse IsDBNull(value) Then
            Return DBNull.Value
        End If

        Dim tahun As Integer

        If Integer.TryParse(value.ToString(), tahun) Then
            If tahun >= 1901 AndAlso tahun <= 2155 Then
                Return tahun
            End If

        End If
        Return DBNull.Value

    End Function
    Private Function GetDecimalValue(row As DataGridViewRow, columnName As String) As Object

        If row.Cells(columnName).Value Is Nothing OrElse IsDBNull(row.Cells(columnName).Value) Then
            Return DBNull.Value
        End If


        Dim value As String = row.Cells(columnName).Value.ToString().Trim()
        If String.IsNullOrWhiteSpace(value) Then
            Return DBNull.Value
        End If
        value = value.Replace("Rp", "")
        value = value.Replace(".", "")
        value = value.Replace(",", ".")
        value = value.Trim()

        Dim hasil As Decimal

        If Decimal.TryParse(value, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, hasil) Then
            Return hasil
        End If
        Return DBNull.Value

    End Function
    Private Function GetDateValue(row As DataGridViewRow, columnName As String) As Object
        Dim value As Object = row.Cells(columnName).Value
        If value Is Nothing OrElse value Is DBNull.Value OrElse String.IsNullOrWhiteSpace(value.ToString()) Then
            Return DBNull.Value
        End If

        Dim result As DateTime

        If DateTime.TryParse(value.ToString(), result) Then
            Return result.Date
        End If

        Return DBNull.Value

    End Function
    Private Function GetDateFromGrid(row As DataGridViewRow, columnName As String) As DateTime

        Dim value As Object = row.Cells(columnName).Value
        If value Is Nothing OrElse value Is DBNull.Value Then
            Return DateTime.MinValue
        End If

        Dim result As DateTime

        If DateTime.TryParse(value.ToString(), result) Then
            Return result

        End If
        Return DateTime.MinValue

    End Function
    Private Function GetNullableDateFromGrid(row As DataGridViewRow, columnName As String) As Nullable(Of DateTime)

        Dim value As Object = row.Cells(columnName).Value
        If value Is Nothing OrElse value Is DBNull.Value OrElse String.IsNullOrWhiteSpace(value.ToString()) Then
            Return Nothing
        End If

        Dim result As DateTime

        If DateTime.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return Nothing

    End Function
    Private Function GetLongValue(row As DataGridViewRow, columnName As String) As Object

        Dim value As Object = row.Cells(columnName).Value

        If value Is Nothing OrElse value Is DBNull.Value OrElse String.IsNullOrWhiteSpace(value.ToString()) Then
            Return DBNull.Value
        End If

        Dim result As Long
        If Long.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return DBNull.Value
    End Function
    Private Function GetLongFromGrid(row As DataGridViewRow, columnName As String) As Long

        If row.Cells(columnName).Value Is Nothing OrElse row.Cells(columnName).Value Is DBNull.Value Then
            Return 0
        End If
        Dim result As Long
        Long.TryParse(row.Cells(columnName).Value.ToString(), result)
        Return result

    End Function
    Private Function FormatFileSize(bytes As Long) As String

        If bytes < 1024 Then
            Return bytes.ToString() & " B"
        End If
        If bytes < 1024 * 1024 Then
            Return Math.Round(bytes / 1024.0, 2).ToString("0.##") & " KB"
        End If
        If bytes < 1024L * 1024L * 1024L Then
            Return Math.Round(bytes / (1024.0 * 1024.0), 2).ToString("0.##") & " MB"
        End If

        Return Math.Round(bytes / (1024.0 * 1024.0 * 1024.0), 2).ToString("0.##") & " GB"

    End Function
    Private Function FormatUkuran(ukuran As Long) As String
        If ukuran < 1024 Then
            Return ukuran.ToString() & " B"
        ElseIf ukuran < 1024 * 1024 Then
            Return Math.Round(ukuran / 1024.0, 2).ToString() & " KB"
        ElseIf ukuran < 1024 * 1024 * 1024 Then

            Return Math.Round(ukuran / (1024.0 * 1024.0), 2).ToString() & " MB"
        Else
            Return Math.Round(ukuran / (1024.0 * 1024.0 * 1024.0), 2).ToString() & " GB"
        End If

    End Function


    ' Private Function ProsesFileSertifikat(row As DataGridViewRow, noKandidat As String, fileBaru As List(Of String)) As String
    '
    '    Dim sourcePath As String = GetCellValue(row, "SourceFilePath")'
    '
    '    Dim storedPath As String = GetCellValue(row, "StoredFilePath")'
    '
    '    'Tidak ada file baru
    '    If String.IsNullOrWhiteSpace(sourcePath) Then
    '   Return storedPath
    '   End If
    ''
    '   'Ada file baru → copy ke server
    '   Dim newStoredPath As String = SimpanFile(sourcePath, noKandidat, "Sertifikat")
    '
    '   If String.IsNullOrWhiteSpace(newStoredPath) Then
    '   Throw New Exception("Gagal menyimpan file sertifikat ke server.")
    ''   End If
    '
    '        fileBaru.Add(newStoredPath)
    '
    '    Return newStoredPath
    ''
    ' End Function

#End Region
#Region "Private"

    Private Sub LoadDataKandidat(idKandidat As Long)
        Using conn As New MySqlConnection(sambung)
            conn.Open()

            Dim sql As String = "SELECT ffcnokandidat, ffcnama,ffctempatlahir,ffdtgllahir,ffcjeniskelamin,ffcstatuspernikahan,ffcnik,ffcnotelp,ffcemail,ffcalamat,ffckelurahan,ffckecamatan,ffckota,ffcprovinsi,ffckodepos, " &
            "ffcfilefoto FROM sakandidat WHERE ffcidkandidat = @ID"


            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idKandidat
                Using rd As MySqlDataReader =
                cmd.ExecuteReader()

                    If Not rd.Read() Then

                        PesanPopupError("ERROR", "Data kandidat tidak ditemukan.")

                        Me.Close()

                        Return

                    End If


                    tkandidat.Text = DBString(rd, "ffcnokandidat")
                    tnamalengkap.Text = DBString(rd, "ffcnama")
                    ttempatlahir.Text = DBString(rd, "ffctempatlahir")
                    tnik.Text = DBString(rd, "ffcnik")
                    tnotelp.Text = DBString(rd, "ffcnotelp")
                    temail.Text = DBString(rd, "ffcemail")
                    talamat.Text = DBString(rd, "ffcalamat")
                    tkelurahan.Text = DBString(rd, "ffckelurahan")
                    tkecamatan.Text = DBString(rd, "ffckecamatan")
                    tkota.Text = DBString(rd, "ffckota")
                    tprovinsi.Text = DBString(rd, "ffcprovinsi")
                    tkodepos.Text = DBString(rd, "ffckodepos")
                    SelectCombo(ckelamin, DBString(rd, "ffcjeniskelamin"))
                    SelectCombo(cstatuspernikahan, DBString(rd, "ffcstatuspernikahan"))
                    If Not IsDBNull(rd("ffdtgllahir")) Then
                        dtgllahir.Value = Convert.ToDateTime(rd("ffdtgllahir"))
                    End If

                    Dim fileFoto As String = DBString(rd, "ffcfilefoto")
                    If Not String.IsNullOrWhiteSpace(fileFoto) Then
                        Dim fullPath As String = Path.Combine(Application.StartupPath, fileFoto)

                        If File.Exists(fullPath) Then

                            Using fs As New FileStream(fullPath, FileMode.Open, FileAccess.Read)

                                PicFoto.Image = Image.FromStream(fs)

                            End Using

                        End If

                    End If

                End Using

            End Using

        End Using

    End Sub
    Private Sub AddParameter(cmd As MySqlCommand, parameterName As String, value As Object)

        If value Is Nothing Then

            cmd.Parameters.AddWithValue(parameterName, DBNull.Value)

        ElseIf TypeOf value Is String AndAlso
           String.IsNullOrWhiteSpace(value.ToString()) Then

            cmd.Parameters.AddWithValue(parameterName, DBNull.Value)

        Else

            cmd.Parameters.AddWithValue(parameterName, value)

        End If

    End Sub
    Private Function DBString(rd As MySqlDataReader, columnName As String) As String

        If IsDBNull(rd(columnName)) Then
            Return String.Empty
        End If
        Return rd(columnName).ToString()

    End Function
    Private Sub SelectCombo(combo As Guna.UI2.WinForms.Guna2ComboBox, value As String)

        combo.SelectedIndex = -1

        If String.IsNullOrWhiteSpace(value) Then
            Return
        End If


        For i As Integer = 0 To combo.Items.Count - 1

            If combo.Items(i).ToString() = value Then
                combo.SelectedIndex = i
                Exit For
            End If
        Next

    End Sub
    Private Sub SetupForm()

        '========================================
        ' TITLE
        '========================================
        Select Case _mode
            Case ModeForm.Tambah
                lblTitle.Text = "Tambah Kandidat"
                lblDescription.Text = "Tambah / edit data kandidat baru ke dalam sistem"
            Case ModeForm.Edit
                lblTitle.Text = "Edit Kandidat"
                lblDescription.Text = "Ubah data kandidat yang sudah tersimpan"
            Case ModeForm.View
                lblTitle.Text = "Detail Kandidat"
                lblDescription.Text = "Melihat informasi lengkap kandidat"

        End Select

        PicFoto.SizeMode = PictureBoxSizeMode.Zoom
        tkandidat.ReadOnly = True
        Tabkandidat.SelectedIndex = 0

    End Sub
    Private Sub setupComboBox()
        'Setup combobox jenis kelamin
        ckelamin.Items.Clear()
        ckelamin.Items.Add("Laki-laki")
        ckelamin.Items.Add("Perempuan")
        ckelamin.SelectedIndex = 0

        'Setup combobox status pernikahan
        cstatuspernikahan.Items.Clear()
        cstatuspernikahan.Items.Add("Belum Menikah")
        cstatuspernikahan.Items.Add("Menikah")
        cstatuspernikahan.Items.Add("Duda/Janda")
        cstatuspernikahan.SelectedIndex = 0
    End Sub
    Private Sub Setmodetambah()
        ClearForm()
        tkandidat.Text = GenerateNoKandidat()
        SetControlEnabled(True)
        tkandidat.ReadOnly = True
        tnamalengkap.Select()
        bSimpan.Visible = True

    End Sub
    Private Sub setmodeedit()
        If _idKandidat <= 0 Then

            PesanPopupError("ERROR", "ID kandidat tidak valid.")
            Me.Close()
            Return

        End If


        SetControlEnabled(True)

        tkandidat.ReadOnly = True
        'Load data kandidat
        LoadDataKandidat(_idKandidat)

        LoadPendidikan(_idKandidat)
        LoadPengalaman(_idKandidat)
        LoadKeahlian(_idKandidat)
        LoadSertifikat(_idKandidat)
        LoadDokumen(_idKandidat)

        bSimpan.Visible = True
    End Sub
    Private Sub SetModeView()
        If _idKandidat <= 0 Then
            PesanPopupError("ERROR", "ID kandidat tidak valid.")
            Me.Close()
            Return
        End If

        LoadDataKandidat(_idKandidat)

        LoadPendidikan(_idKandidat)
        LoadPengalaman(_idKandidat)
        LoadKeahlian(_idKandidat)
        LoadSertifikat(_idKandidat)
        LoadDokumen(_idKandidat)

        SetControlEnabled(False)

        bSimpan.Visible = False

    End Sub
    Private Sub ClearForm()
        _deletedPendidikanIds.Clear()
        _deletedPengalamanIds.Clear()
        _deletedKeahlianIds.Clear()
        _deletedSertifikatIds.Clear()
        _deletedDokumenIds.Clear()
        '========================================
        ' DATA PRIBADI
        '========================================

        tkandidat.Clear()
        tnamalengkap.Clear()
        tnik.Clear()
        ttempatlahir.Clear()
        tnotelp.Clear()
        temail.Clear()

        ckelamin.SelectedIndex = -1
        cstatuspernikahan.SelectedIndex = -1

        dtgllahir.Value = Date.Today


        '========================================
        ' ALAMAT
        '========================================

        talamat.Clear()
        tkelurahan.Clear()
        tkecamatan.Clear()
        tkota.Clear()
        tprovinsi.Clear()
        tkodepos.Clear()


        '========================================
        ' FOTO
        '========================================

        PicFoto.Image = Nothing

        _fotoPath = String.Empty
        _fotoFileName = String.Empty

        '========================================
        ' GRID
        '========================================

        If dgvpendidikan IsNot Nothing Then
            dgvpendidikan.Rows.Clear()
        End If

        If dgvpengalaman IsNot Nothing Then
            dgvpengalaman.Rows.Clear()
        End If

        If dgvkeahlian IsNot Nothing Then
            dgvkeahlian.Rows.Clear()
        End If

        If dgvsertifikat IsNot Nothing Then
            dgvsertifikat.Rows.Clear()
        End If

        If dgvdokumen IsNot Nothing Then
            dgvdokumen.Rows.Clear()
        End If

    End Sub

    Private Sub SetControlEnabled(enabled As Boolean)

        tnamalengkap.Enabled = enabled
        tnik.Enabled = enabled
        ttempatlahir.Enabled = enabled
        dtgllahir.Enabled = enabled
        ckelamin.Enabled = enabled
        cstatuspernikahan.Enabled = enabled
        tnotelp.Enabled = enabled
        temail.Enabled = enabled

        talamat.Enabled = enabled
        tkelurahan.Enabled = enabled
        tkecamatan.Enabled = enabled
        tkota.Enabled = enabled
        tprovinsi.Enabled = enabled
        tkodepos.Enabled = enabled

        bUploadFoto.Enabled = enabled

        bAddPendidikan.Enabled = enabled
        bAddPengalaman.Enabled = enabled
        bAddKeahlian.Enabled = enabled
        bAddSertifikat.Enabled = enabled
        bUploadDokumen.Enabled = enabled

    End Sub

#Region "PENDIDIKAN"
    Private Sub SetupGridPendidikan()
        dgvpendidikan.Columns.Clear() ' Bersihkan kolom bawaan jika ada

        With dgvpendidikan
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeight = 40
            ' ==========================================
            ' TAMBAHKAN DEFINISI KOLOM DI SINI
            ' ==========================================
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcidpendidikan", .HeaderText = "ID", .Visible = False})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Tingkat", .HeaderText = "Tingkat"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Institusi", .HeaderText = "Institusi"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Jurusan", .HeaderText = "Jurusan"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TahunMasuk", .HeaderText = "Tahun Masuk"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TahunLulus", .HeaderText = "Tahun Lulus"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nilai", .HeaderText = "Nilai"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Keterangan", .HeaderText = "Keterangan"})

            ' Tambahkan kolom action button (Edit dan Hapus) agar event CellContentClick Anda berfungsi
            .Columns.Add(New DataGridViewButtonColumn With {.Name = "Edit", .HeaderText = "", .Text = "Edit", .UseColumnTextForButtonValue = True})
            .Columns.Add(New DataGridViewButtonColumn With {.Name = "Hapus", .HeaderText = "", .Text = "Hapus", .UseColumnTextForButtonValue = True})
        End With

    End Sub
    Private Sub TambahRowPendidikan(frm As frmPendidikanAdd)
        Dim rowIndex As Integer = dgvpendidikan.Rows.Add()
        Dim row As DataGridViewRow = dgvpendidikan.Rows(rowIndex)
        row.Cells("ffcidpendidikan").Value = frm.IdPendidikan
        row.Cells("Tingkat").Value = frm.Tingkat
        row.Cells("Institusi").Value = frm.NamaInstitusi
        row.Cells("Jurusan").Value = frm.Jurusan
        row.Cells("TahunMasuk").Value = frm.TahunMasuk
        row.Cells("TahunLulus").Value = frm.TahunLulus
        row.Cells("Nilai").Value = frm.Nilai
        row.Cells("Keterangan").Value = frm.Keterangan
    End Sub
    Private Sub bAddPendidikan_Click(sender As Object, e As EventArgs) Handles bAddPendidikan.Click

        Using frm As New frmPendidikanAdd()

            frm.Mode = frmPendidikanAdd.ModeForm.Tambah
            If frm.ShowDialog(Me) = DialogResult.OK Then

                TambahRowPendidikan(frm)
            End If

        End Using

    End Sub
    Private Sub dgvpendidikan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpendidikan.CellContentClick

        If e.RowIndex < 0 Then
            Return
        End If

        If e.ColumnIndex < 0 Then
            Return
        End If


        Dim columnName As String = dgvpendidikan.Columns(e.ColumnIndex).Name


        If columnName = "Edit" Then

            EditPendidikan(e.RowIndex)

        ElseIf columnName = "Hapus" Then

            HapusPendidikan(e.RowIndex)

        End If

    End Sub
    Private Sub EditPendidikan(rowIndex As Integer)

        Dim row As DataGridViewRow = dgvpendidikan.Rows(rowIndex)


        Using frm As New frmPendidikanAdd()

            frm.Mode =
            frmPendidikanAdd.ModeForm.Edit


            If row.Cells("ffcidpendidikan").Value IsNot Nothing Then

                If Not IsDBNull(row.Cells("ffcidpendidikan").Value) Then

                    frm.IdPendidikan = Convert.ToInt64(row.Cells("ffcidpendidikan").Value)

                End If

            End If


            frm.Tingkat = If(row.Cells("Tingkat").Value, "").ToString()

            frm.NamaInstitusi = If(row.Cells("Institusi").Value, "").ToString()

            frm.Jurusan = If(row.Cells("Jurusan").Value, "").ToString()

            If Integer.TryParse(row.Cells("TahunMasuk").Value?.ToString(), frm.TahunMasuk) = False Then
                frm.TahunMasuk = 0
            End If

            If Integer.TryParse(row.Cells("TahunLulus").Value?.ToString(), frm.TahunLulus) = False Then
                frm.TahunLulus = 0
            End If


            frm.Nilai = If(row.Cells("Nilai").Value, "").ToString()

            frm.Keterangan = If(row.Cells("Keterangan").Value, "").ToString()

            If frm.ShowDialog(Me) = DialogResult.OK Then
                UpdateRowPendidikan(rowIndex, frm)

            End If

        End Using

    End Sub
    Private Sub UpdateRowPendidikan(rowIndex As Integer, frm As frmPendidikanAdd)

        Dim row As DataGridViewRow = dgvpendidikan.Rows(rowIndex)
        row.Cells("ffcidpendidikan").Value = frm.IdPendidikan
        row.Cells("Tingkat").Value = frm.Tingkat

        row.Cells("Institusi").Value = frm.NamaInstitusi

        row.Cells("Jurusan").Value = frm.Jurusan

        row.Cells("TahunMasuk").Value = frm.TahunMasuk

        row.Cells("TahunLulus").Value = frm.TahunLulus

        row.Cells("Nilai").Value = frm.Nilai

        row.Cells("Keterangan").Value = frm.Keterangan

    End Sub
    Private Sub HapusPendidikan(rowIndex As Integer)

        If rowIndex < 0 OrElse
       rowIndex >= dgvpendidikan.Rows.Count Then
            Return
        End If
        Dim row As DataGridViewRow = dgvpendidikan.Rows(rowIndex)
        Dim institusi As String = If(row.Cells("Institusi").Value, String.Empty).ToString()
        If Not PesanPopupKonfirmasi("Konfirmasi", "Apakah data pendidikan " & institusi & " akan dihapus?") Then
            Return
        End If
        Dim idPendidikan As Long = 0

        If row.Cells("ffcidpendidikan").Value IsNot Nothing AndAlso
       Not IsDBNull(row.Cells("ffcidpendidikan").Value) Then
            Long.TryParse(row.Cells("ffcidpendidikan").Value.ToString(), idPendidikan)
        End If

        If idPendidikan > 0 Then
            If Not _deletedPendidikanIds.Contains(idPendidikan) Then
                _deletedPendidikanIds.Add(idPendidikan)
            End If
        End If
        dgvpendidikan.Rows.RemoveAt(rowIndex)

    End Sub
#End Region
#Region "PENGALAMAN"
    Private Sub SetupGridPengalaman()

        ' Bersihkan kolom bawaan jika ada
        dgvpengalaman.Columns.Clear()

        With dgvpengalaman
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersHeight = 40
            .RowTemplate.Height = 36
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(229, 231, 235)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 95, 209)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .DefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254)
            .DefaultCellStyle.SelectionForeColor = Color.Black

            ' ==========================================
            ' DEFINISI KOLOM SESUAI URUTAN INSERT
            ' ==========================================
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcidpengalaman", .HeaderText = "ID", .Visible = False})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Perusahaan", .HeaderText = "Perusahaan"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Jabatan", .HeaderText = "Jabatan"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TanggalMulai", .HeaderText = "Tanggal Mulai"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TanggalSelesai", .HeaderText = "Tanggal Selesai"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "GajiTerakhir", .HeaderText = "Gaji Terakhir"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "AlasanBerhenti", .HeaderText = "Alasan Berhenti"})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Keterangan", .HeaderText = "Keterangan"})

            ' Kolom Tombol Action
            .Columns.Add(New DataGridViewButtonColumn With {.Name = "Edit", .HeaderText = "", .Text = "Edit", .UseColumnTextForButtonValue = True})
            .Columns.Add(New DataGridViewButtonColumn With {.Name = "Hapus", .HeaderText = "", .Text = "Hapus", .UseColumnTextForButtonValue = True})

            ' Opsional: Mengatur lebar kolom (Fill) agar memenuhi grid
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub
    Private Sub bAddPengalaman_Click(sender As Object, e As EventArgs) Handles bAddPengalaman.Click
        Using frm As New frmPengalamanAdd()
            frm.Mode = frmPengalamanAdd.ModeForm.Tambah
            If frm.ShowDialog(Me) = DialogResult.OK Then
                TambahRowPengalaman(frm)
            End If
        End Using
    End Sub
    Private Sub TambahRowPengalaman(frm As frmPengalamanAdd)

        Dim tanggalSelesai As Object = DBNull.Value

        If frm.TanggalSelesai.HasValue Then
            tanggalSelesai = frm.TanggalSelesai.Value.Date
        End If
        dgvpengalaman.Rows.Add(0, frm.Perusahaan, frm.Jabatan, frm.TanggalMulai.Date, tanggalSelesai, frm.GajiTerakhir, frm.AlasanBerhenti, frm.Keterangan, "Edit", "Hapus")

    End Sub
    Private Sub dgvpengalaman_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvpengalaman.CellFormatting

        If e.RowIndex < 0 Then
            Return
        End If
        If dgvpengalaman.Columns(e.ColumnIndex).Name = "GajiTerakhir" Then
            If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) Then
                Dim gaji As Decimal
                If Decimal.TryParse(e.Value.ToString(), gaji) Then

                    e.Value = gaji.ToString("C0", New Globalization.CultureInfo("id-ID"))
                    e.FormattingApplied = True
                End If

            End If

        End If
        If dgvpengalaman.Columns(e.ColumnIndex).Name = "TanggalSelesai" Then
            If e.Value Is Nothing OrElse IsDBNull(e.Value) OrElse String.IsNullOrWhiteSpace(e.Value.ToString()) Then
                e.Value = "Masih Bekerja"
                e.FormattingApplied = True
            End If

        End If

    End Sub
    Private Sub EditPengalaman(rowIndex As Integer)

        If rowIndex < 0 Then
            Return
        End If
        Dim row As DataGridViewRow =
        dgvpengalaman.Rows(rowIndex)
        Using frm As New frmPengalamanAdd()
            frm.Mode = frmPengalamanAdd.ModeForm.Edit

            If row.Cells("ffcidpengalaman").Value IsNot Nothing Then
                Long.TryParse(row.Cells("ffcidpengalaman").Value.ToString(), frm.IdPengalaman)

            End If
            frm.Perusahaan = Convert.ToString(row.Cells("Perusahaan").Value)
            frm.Jabatan = Convert.ToString(row.Cells("Jabatan").Value)

            If row.Cells("TanggalMulai").Value IsNot Nothing Then
                Dim tanggalMulai As Date
                If Date.TryParse(row.Cells("TanggalMulai").Value.ToString(), tanggalMulai) Then
                    frm.TanggalMulai = tanggalMulai
                End If
            End If
            Dim nilaiTanggalSelesai As String = Convert.ToString(row.Cells("TanggalSelesai").Value)


            If nilaiTanggalSelesai = "Masih Bekerja" OrElse
           String.IsNullOrWhiteSpace(nilaiTanggalSelesai) Then
                frm.TanggalSelesai = Nothing
            Else
                Dim tanggalSelesai As Date
                If Date.TryParse(nilaiTanggalSelesai, tanggalSelesai) Then
                    frm.TanggalSelesai = tanggalSelesai
                Else
                    frm.TanggalSelesai = Nothing
                End If

            End If

            Dim nilaiGaji As String = Convert.ToString(row.Cells("GajiTerakhir").Value)

            Dim gaji As Decimal
            Decimal.TryParse(nilaiGaji.Replace(".", "").Replace(",", ""), gaji)
            frm.GajiTerakhir = gaji
            frm.AlasanBerhenti = Convert.ToString(row.Cells("AlasanBerhenti").Value)
            frm.Keterangan = Convert.ToString(row.Cells("Keterangan").Value)
            If frm.ShowDialog(Me) = DialogResult.OK Then

                UpdateRowPengalaman(row, frm)

            End If

        End Using

    End Sub
    Private Sub UpdateRowPengalaman(row As DataGridViewRow, frm As frmPengalamanAdd)
        row.Cells("Perusahaan").Value = frm.Perusahaan
        row.Cells("Jabatan").Value = frm.Jabatan
        row.Cells("TanggalMulai").Value = frm.TanggalMulai
        If frm.TanggalSelesai.HasValue Then
            row.Cells("TanggalSelesai").Value = frm.TanggalSelesai.Value
        Else
            row.Cells("TanggalSelesai").Value = "Masih Bekerja"
        End If
        If frm.GajiTerakhir > 0 Then
            row.Cells("GajiTerakhir").Value = frm.GajiTerakhir.ToString("#,##0")
        Else
            row.Cells("GajiTerakhir").Value = String.Empty
        End If
        row.Cells("AlasanBerhenti").Value = frm.AlasanBerhenti
        row.Cells("Keterangan").Value = frm.Keterangan
    End Sub
    Private Sub HapusPengalaman(rowIndex As Integer)

        If rowIndex < 0 OrElse rowIndex >= dgvpengalaman.Rows.Count Then
            Return
        End If
        Dim row As DataGridViewRow = dgvpengalaman.Rows(rowIndex)
        Dim perusahaan As String = If(row.Cells("Perusahaan").Value, String.Empty).ToString()
        If Not PesanPopupKonfirmasi("Konfirmasi", "Apakah pengalaman kerja di " & perusahaan & " akan dihapus?") Then
            Return
        End If
        Dim idPengalaman As Long = 0

        If row.Cells("ffcidpengalaman").Value IsNot Nothing AndAlso
           Not IsDBNull(row.Cells("ffcidpengalaman").Value) Then
            Long.TryParse(row.Cells("ffcidpengalaman").Value.ToString(), idPengalaman)
        End If


        If idPengalaman > 0 Then

            If Not _deletedPengalamanIds.Contains(idPengalaman) Then
                _deletedPengalamanIds.Add(idPengalaman)
            End If

        End If

        dgvpengalaman.Rows.RemoveAt(rowIndex)

    End Sub
    Private Sub dgvpengalaman_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpengalaman.CellContentClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim namaKolom As String = dgvpengalaman.Columns(e.ColumnIndex).Name
        Select Case namaKolom
            Case "Edit"
                EditPengalaman(e.RowIndex)
            Case "Hapus"
                HapusPengalaman(e.RowIndex)
        End Select
    End Sub
#End Region
#Region "KEAHLIAN"
    Private Sub SetupGridKeahlian()
        dgvkeahlian.Columns.Clear()
        dgvkeahlian.AutoGenerateColumns = False
        dgvkeahlian.ColumnHeadersHeight = 40
        Dim colId As New DataGridViewTextBoxColumn()
        colId.Name = "ffcidkeahlian"
        colId.HeaderText = "ID"
        colId.Visible = False
        dgvkeahlian.Columns.Add(colId)
        dgvkeahlian.Columns.Add("Keahlian", "Keahlian")
        dgvkeahlian.Columns.Add("Tingkat", "Tingkat")
        dgvkeahlian.Columns.Add("Keterangan", "Keterangan")
        Dim colEdit As New DataGridViewButtonColumn()

        colEdit.Name = "Edit"
        colEdit.HeaderText = ""
        colEdit.Text = "Edit"
        colEdit.UseColumnTextForButtonValue = True
        dgvkeahlian.Columns.Add(colEdit)


        Dim colHapus As New DataGridViewButtonColumn()

        colHapus.Name = "Hapus"
        colHapus.HeaderText = ""
        colHapus.Text = "Hapus"
        colHapus.UseColumnTextForButtonValue = True

        dgvkeahlian.Columns.Add(colHapus)
    End Sub
    Private Sub bAddKeahlian_Click(sender As Object, e As EventArgs) Handles bAddKeahlian.Click
        Using frm As New frmKeahlianAdd()
            frm.Mode = frmKeahlianAdd.ModeForm.Tambah
            If frm.ShowDialog(Me) = DialogResult.OK Then
                TambahRowKeahlian(frm)
            End If

        End Using

    End Sub
    Private Sub TambahRowKeahlian(frm As frmKeahlianAdd)
        dgvkeahlian.Rows.Add(0, frm.Keahlian, frm.Tingkat, frm.Keterangan, "Edit", "Hapus")
    End Sub
    Private Sub EditKeahlian(rowIndex As Integer)

        If rowIndex < 0 OrElse rowIndex >= dgvkeahlian.Rows.Count Then
            Return
        End If

        Dim row As DataGridViewRow = dgvkeahlian.Rows(rowIndex)

        Using frm As New frmKeahlianAdd()

            frm.Mode = frmKeahlianAdd.ModeForm.Edit

            If row.Cells("ffcidkeahlian").Value IsNot Nothing Then
                Long.TryParse(row.Cells("ffcidkeahlian").Value.ToString(), frm.IdKeahlian)
            End If


            frm.Keahlian = If(row.Cells("Keahlian").Value, String.Empty).ToString()
            frm.Tingkat = If(row.Cells("Tingkat").Value, String.Empty).ToString()

            frm.Keterangan = If(row.Cells("Keterangan").Value, String.Empty).ToString()
            If frm.ShowDialog(Me) = DialogResult.OK Then
                UpdateRowKeahlian(rowIndex, frm)
            End If

        End Using

    End Sub
    Private Sub UpdateRowKeahlian(rowIndex As Integer, frm As frmKeahlianAdd)
        Dim row As DataGridViewRow = dgvkeahlian.Rows(rowIndex)
        row.Cells("Keahlian").Value = frm.Keahlian
        row.Cells("Tingkat").Value = frm.Tingkat
        row.Cells("Keterangan").Value = frm.Keterangan
    End Sub
    Private Sub HapusKeahlian(rowIndex As Integer)

        If rowIndex < 0 OrElse rowIndex >= dgvkeahlian.Rows.Count Then
            Return
        End If
        Dim row As DataGridViewRow = dgvkeahlian.Rows(rowIndex)
        Dim keahlian As String = If(row.Cells("Keahlian").Value, String.Empty).ToString()

        If Not PesanPopupKonfirmasi("Konfirmasi", "Apakah keahlian """ & keahlian & """ akan dihapus?") Then
            Return
        End If

        Dim idKeahlian As Long = 0


        If row.Cells("ffcidkeahlian").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidkeahlian").Value) Then
            Long.TryParse(row.Cells("ffcidkeahlian").Value.ToString(), idKeahlian)
        End If
        If idKeahlian > 0 Then
            If Not _deletedKeahlianIds.Contains(idKeahlian) Then
                _deletedKeahlianIds.Add(idKeahlian)
            End If
        End If

        dgvkeahlian.Rows.RemoveAt(rowIndex)

    End Sub
    Private Sub dgvkeahlian_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvkeahlian.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim columnName As String = dgvkeahlian.Columns(e.ColumnIndex).Name
        Select Case columnName
            Case "Edit"
                EditKeahlian(e.RowIndex)

            Case "Hapus"
                HapusKeahlian(e.RowIndex)

        End Select

    End Sub


#End Region

#Region "SERTIFIKAT"

    Private Sub SetupGridSertifikat()

        dgvsertifikat.Columns.Clear()
        dgvsertifikat.AutoGenerateColumns = False
        dgvsertifikat.ColumnHeadersHeight = 40
        '========================================================
        ' ID SERTIFIKAT
        '========================================================
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcidsertifikat", .HeaderText = "ID", .Visible = False})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffciddokumen", .HeaderText = "IDDokumen", .Visible = False})
        '========================================================
        ' DATA SERTIFIKAT
        '========================================================
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NamaSertifikat", .HeaderText = "Nama Sertifikat"})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Penerbit", .HeaderText = "Penerbit"})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NomorSertifikat", .HeaderText = "Nomor Sertifikat"})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TanggalTerbit", .HeaderText = "Tanggal Terbit"})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TanggalKadaluarsa", .HeaderText = "Tanggal Kadaluarsa"})

        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "File", .HeaderText = "File"})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "SourceFilePath", .HeaderText = "SourceFilePath", .Visible = False})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "StoredFilePath", .HeaderText = "StoredFilePath", .Visible = False})
        dgvsertifikat.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Keterangan", .HeaderText = "Keterangan"})
        dgvsertifikat.Columns.Add(New DataGridViewButtonColumn With {.Name = "LihatFile", .HeaderText = "File", .Text = "Lihat", .UseColumnTextForButtonValue = True})
        dgvsertifikat.Columns.Add(New DataGridViewButtonColumn With {.Name = "Edit", .HeaderText = "", .Text = "Edit", .UseColumnTextForButtonValue = True})
        dgvsertifikat.Columns.Add(New DataGridViewButtonColumn With {.Name = "Hapus", .HeaderText = "", .Text = "Hapus", .UseColumnTextForButtonValue = True})

    End Sub
    Private Sub bAddSertifikat_Click(sender As Object, e As EventArgs) Handles bAddSertifikat.Click

        Using frm As New frmSertifikatAdd()
            frm.Mode = frmSertifikatAdd.ModeForm.Tambah
            If frm.ShowDialog(Me) = DialogResult.OK Then
                TambahRowSertifikat(frm)
            End If

        End Using

    End Sub
    Private Sub TambahRowSertifikat(frm As frmSertifikatAdd)
        Try

            Dim rowIndex As Integer = dgvsertifikat.Rows.Add()

            Dim row As DataGridViewRow = dgvsertifikat.Rows(rowIndex)

            '====================================================
            ' ID
            '====================================================
            row.Cells("ffcidsertifikat").Value = 0

            '====================================================
            ' DATA SERTIFIKAT
            '====================================================
            row.Cells("NamaSertifikat").Value = frm.NamaSertifikat
            row.Cells("Penerbit").Value = frm.Penerbit
            row.Cells("NomorSertifikat").Value = frm.NomorSertifikat
            row.Cells("TanggalTerbit").Value = frm.TanggalTerbit
            If frm.TanggalKadaluarsa.HasValue Then
                row.Cells("TanggalKadaluarsa").Value = frm.TanggalKadaluarsa.Value
            Else
                row.Cells("TanggalKadaluarsa").Value = DBNull.Value
            End If

            '====================================================
            ' FILE
            '====================================================

            'Nama file
            row.Cells("File").Value = frm.FileName

            'File lokal yang dipilih user
            row.Cells("SourceFilePath").Value = frm.FilePath

            'Untuk data baru belum ada file server
            row.Cells("StoredFilePath").Value = frm.StoredFilePath

            '====================================================
            ' KETERANGAN
            '====================================================
            row.Cells("Keterangan").Value = frm.Keterangan

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal menambahkan sertifikat : " & ex.Message)

        End Try
    End Sub
    Private Sub EditSertifikat(rowIndex As Integer)

        Try

            If rowIndex < 0 OrElse rowIndex >= dgvsertifikat.Rows.Count Then
                Return
            End If

            Dim row As DataGridViewRow = dgvsertifikat.Rows(rowIndex)

            Using frm As New frmSertifikatAdd()

                frm.Mode = frmSertifikatAdd.ModeForm.Edit

                '================================================
                ' ID
                '================================================
                frm.IdSertifikat = GetLongValue(row, "ffcidsertifikat")

                '================================================
                ' DATA SERTIFIKAT
                '================================================
                frm.NamaSertifikat = GetCellValue(row, "NamaSertifikat")

                frm.Penerbit = GetCellValue(row, "Penerbit")

                frm.NomorSertifikat = GetCellValue(row, "NomorSertifikat")

                frm.TanggalTerbit = GetDateValue(row, "TanggalTerbit")

                Dim tanggalKadaluarsa As String = GetCellValue(row, "TanggalKadaluarsa")

                If String.IsNullOrWhiteSpace(tanggalKadaluarsa) Then
                    frm.TanggalKadaluarsa = Nothing
                Else
                    Dim dt As Date

                    If Date.TryParse(tanggalKadaluarsa, dt) Then
                        frm.TanggalKadaluarsa = dt
                    Else
                        frm.TanggalKadaluarsa = Nothing
                    End If

                End If

                '================================================
                ' FILE
                '================================================

                'Nama file
                frm.FileName = GetCellValue(row, "File")

                'JANGAN mengisi FilePath dari grid.
                '
                'FilePath hanya untuk file lokal baru.
                '
                'Saat edit file lama, SourceFilePath
                'harus kosong.

                frm.FilePath = String.Empty

                'Path server file lama
                frm.StoredFilePath = GetCellValue(row, "StoredFilePath")

                '================================================
                ' KETERANGAN
                '================================================
                frm.Keterangan = GetCellValue(row, "Keterangan")

                '================================================
                ' TAMPILKAN POPUP
                '================================================
                If frm.ShowDialog(Me) = DialogResult.OK Then

                    UpdateRowSertifikat(rowIndex, frm)
                End If

            End Using

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal mengedit sertifikat : " & ex.Message)

        End Try

    End Sub
    Private Sub UpdateRowSertifikat(rowIndex As Integer, frm As frmSertifikatAdd)

        Try

            If rowIndex < 0 OrElse rowIndex >= dgvsertifikat.Rows.Count Then
                Return
            End If

            Dim row As DataGridViewRow = dgvsertifikat.Rows(rowIndex)

            '====================================================
            ' ID
            '====================================================
            row.Cells("ffcidsertifikat").Value = frm.IdSertifikat

            '====================================================
            ' DATA
            '====================================================
            row.Cells("NamaSertifikat").Value = frm.NamaSertifikat
            row.Cells("Penerbit").Value = frm.Penerbit
            row.Cells("NomorSertifikat").Value = frm.NomorSertifikat
            row.Cells("TanggalTerbit").Value = frm.TanggalTerbit
            If frm.TanggalKadaluarsa.HasValue Then
                row.Cells("TanggalKadaluarsa").Value = frm.TanggalKadaluarsa.Value
            Else
                row.Cells("TanggalKadaluarsa").Value = DBNull.Value
            End If

            '====================================================
            ' FILE
            '====================================================

            row.Cells("File").Value = frm.FileName

            row.Cells("SourceFilePath").Value = frm.FilePath

            row.Cells("StoredFilePath").Value = frm.StoredFilePath

            '====================================================
            ' KETERANGAN
            '====================================================
            row.Cells("Keterangan").Value = frm.Keterangan

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memperbarui sertifikat : " & ex.Message)

        End Try

    End Sub

    Private Sub HapusSertifikat(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvsertifikat.Rows.Count Then
            Return
        End If
        If PesanPopupKonfirmasi("Konfirmasi", "Apakah data sertifikat ini akan dihapus?") = DialogResult.No Then
            Return
        End If
        Dim row As DataGridViewRow = dgvsertifikat.Rows(rowIndex)
        Dim id As Long = 0
        If row.Cells("ffcidsertifikat").Value IsNot Nothing AndAlso row.Cells("ffcidsertifikat").Value IsNot DBNull.Value Then
            Long.TryParse(row.Cells("ffcidsertifikat").Value.ToString(), id)
        End If

        If id > 0 Then
            If Not _deletedSertifikatIds.Contains(id) Then
                _deletedSertifikatIds.Add(id)
            End If
        End If
        dgvsertifikat.Rows.RemoveAt(rowIndex)

    End Sub
    Private Sub dgvsertifikat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsertifikat.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If
        Dim columnName As String = dgvsertifikat.Columns(e.ColumnIndex).Name
        Select Case columnName
            Case "Edit"
                EditSertifikat(e.RowIndex)
            Case "Hapus"
                HapusSertifikat(e.RowIndex)
            Case "LihatFile"
                LihatFileSertifikat(e.RowIndex)

        End Select

    End Sub

    Private Sub LihatFileSertifikat(rowIndex As Integer)

        If rowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvsertifikat.Rows(rowIndex)
        Dim relativePath As String = Convert.ToString(row.Cells("StoredFilePath").Value)

        If String.IsNullOrWhiteSpace(relativePath) Then
            PesanPopupPeringatan("Peringatan", "File sertifikat belum dipilih.")
            Return
        End If

        Try
            BukaFile(relativePath)
        Catch ex As Exception
            PesanPopupError("Error", "File sertifikat tidak dapat dibuka : " & ex.Message)
        End Try

    End Sub
#End Region

#Region "DOKUMEN"

    Private Sub SetupGridDokumen()
        dgvdokumen.Columns.Clear()
        dgvdokumen.AutoGenerateColumns = False
        dgvdokumen.ColumnHeadersHeight = 40

        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffciddokumen", .HeaderText = "ID", .Visible = False})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Jenis", .HeaderText = "Jenis"})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NamaFile", .HeaderText = "Nama Dokumen"})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "File", .HeaderText = "File"})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "SourceFilePath", .HeaderText = "SourceFilePath", .Visible = False})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "StoredFilePath", .HeaderText = "StoredFilePath", .Visible = False})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Ukuran", .HeaderText = "Ukuran"})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TipeFile", .HeaderText = "Tipe File"})
        dgvdokumen.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Keterangan", .HeaderText = "Keterangan"})
        dgvdokumen.Columns.Add(New DataGridViewButtonColumn With {.Name = "LihatFile", .HeaderText = "File", .Text = "Lihat", .UseColumnTextForButtonValue = True})
        dgvdokumen.Columns.Add(New DataGridViewButtonColumn With {.Name = "Edit", .HeaderText = "", .Text = "Edit", .UseColumnTextForButtonValue = True})
        dgvdokumen.Columns.Add(New DataGridViewButtonColumn With {.Name = "Hapus", .HeaderText = "", .Text = "Hapus", .UseColumnTextForButtonValue = True})

    End Sub
    Private Sub bAddDokumen_Click(sender As Object, e As EventArgs) Handles bUploadDokumen.Click
        Using frm As New frmDokumenAdd()
            frm.Mode = frmDokumenAdd.ModeForm.Tambah

            If frm.ShowDialog(Me) = DialogResult.OK Then
                TambahRowDokumen(frm)
            End If

        End Using
    End Sub
    Private Sub TambahRowDokumen(frm As frmDokumenAdd)
        Try

            Dim rowIndex As Integer = dgvdokumen.Rows.Add()

            Dim row As DataGridViewRow = dgvdokumen.Rows(rowIndex)

            row.Cells("ffciddokumen").Value = 0

            row.Cells("Jenis").Value = frm.Jenis
            row.Cells("NamaFile").Value = frm.Nama

            row.Cells("File").Value = frm.FileName

            row.Cells("SourceFilePath").Value = frm.FilePath

            row.Cells("StoredFilePath").Value = frm.StoredFilePath


            row.Cells("TipeFile").Value = frm.TipeFile


            row.Cells("Ukuran").Value = frm.Ukuran

            row.Cells("Keterangan").Value = frm.Keterangan

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal menambahkan dokumen : " & ex.Message)

        End Try
    End Sub
    Private Sub EditDokumen(rowIndex As Integer)
        Try

            If rowIndex < 0 OrElse
           rowIndex >= dgvdokumen.Rows.Count Then
                Return
            End If

            Dim row As DataGridViewRow = dgvdokumen.Rows(rowIndex)

            Using frm As New frmDokumenAdd()

                frm.Mode = frmDokumenAdd.ModeForm.Edit

                frm.IdDokumen = GetLongValue(row, "ffciddokumen")
                frm.Jenis = GetCellValue(row, "Jenis")

                frm.Nama = GetCellValue(row, "NamaFile")


                frm.FileName = GetCellValue(row, "File")

                'File lokal harus kosong ketika membuka
                'file lama untuk edit.
                frm.FilePath = String.Empty

                'Path server file lama
                frm.StoredFilePath = GetCellValue(row, "StoredFilePath")
                frm.TipeFile = GetCellValue(row, "TipeFile")
                frm.Ukuran = GetLongValue(row, "Ukuran")
                frm.Keterangan = GetCellValue(row, "Keterangan")
                If frm.ShowDialog(Me) = DialogResult.OK Then

                    UpdateRowDokumen(rowIndex, frm)
                End If

            End Using

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal mengedit dokumen : " & ex.Message)
        End Try

    End Sub
    Private Sub UpdateRowDokumen(rowIndex As Integer, frm As frmDokumenAdd)

        Try

            If rowIndex < 0 OrElse rowIndex >= dgvdokumen.Rows.Count Then
                Return
            End If

            Dim row As DataGridViewRow = dgvdokumen.Rows(rowIndex)

            row.Cells("ffciddokumen").Value = frm.IdDokumen

            row.Cells("Jenis").Value = frm.Jenis
            row.Cells("NamaFile").Value = frm.Nama
            row.Cells("File").Value = frm.FileName
            row.Cells("SourceFilePath").Value = frm.FilePath
            row.Cells("StoredFilePath").Value = frm.StoredFilePath

            row.Cells("TipeFile").Value = frm.TipeFile

            row.Cells("Ukuran").Value = frm.Ukuran

            row.Cells("Keterangan").Value = frm.Keterangan

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memperbarui dokumen : " & ex.Message)

        End Try

    End Sub
    Private Sub HapusDokumen(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= dgvdokumen.Rows.Count Then
            Return
        End If
        If PesanPopupKonfirmasi("Konfirmasi", "Apakah dokumen ini akan dihapus?") = DialogResult.No Then
            Return
        End If

        Dim row As DataGridViewRow = dgvdokumen.Rows(rowIndex)

        Dim idDokumen As Long = 0

        If row.Cells("ffciddokumen").Value IsNot Nothing AndAlso row.Cells("ffciddokumen").Value IsNot DBNull.Value Then
            Long.TryParse(row.Cells("ffciddokumen").Value.ToString(), idDokumen)
        End If

        If idDokumen > 0 Then
            If Not _deletedDokumenIds.Contains(idDokumen) Then
                _deletedDokumenIds.Add(idDokumen)
            End If
        End If


        dgvdokumen.Rows.RemoveAt(rowIndex)

    End Sub
    Private Sub dgvdokumen_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvdokumen.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If

        Dim columnName As String = dgvdokumen.Columns(e.ColumnIndex).Name

        Select Case columnName
            Case "LihatFile"
                LihatFileDokumen(e.RowIndex)
            Case "Edit"
                EditDokumen(e.RowIndex)
            Case "Hapus"
                HapusDokumen(e.RowIndex)
        End Select
    End Sub
    Private Sub LihatFileDokumen(rowIndex As Integer)
        Try
            Dim relativePath As String = If(dgvdokumen.Rows(rowIndex).Cells("StoredFilePath").Value, String.Empty).ToString()
            If String.IsNullOrWhiteSpace(relativePath) Then
                PesanPopupPeringatan("Peringatan", "File tidak ditemukan.")
                Return
            End If
            BukaFile(relativePath)
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal membuka file : " & ex.Message)
        End Try

    End Sub
    Private Sub dgvdokumen_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvdokumen.CellFormatting
        If e.RowIndex < 0 Then
            Return
        End If
        If dgvdokumen.Columns(e.ColumnIndex).Name <> "Ukuran" Then
            Return
        End If

        If e.Value Is Nothing OrElse e.Value Is DBNull.Value Then
            e.Value = "-"
            Return
        End If
        Dim bytes As Long
        If Long.TryParse(e.Value.ToString(), bytes) Then
            e.Value = FormatFileSize(bytes)
        End If

    End Sub
#End Region

    Private Sub LoadPendidikan(idKandidat As Long)

        Try

            dgvpendidikan.Rows.Clear()

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffcidpendidikan,ffctingkat,ffcnamainstitusi,ffcjurusan,ffctahunmasuk,ffctahunlulus,ffcnilai,ffcketerangan " &
                "FROM sakandidatpendidikan WHERE ffcidkandidat = @ID ORDER BY ffctahunlulus DESC, ffcidpendidikan DESC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idKandidat
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            Dim rowIndex As Integer = dgvpendidikan.Rows.Add()
                            Dim row As DataGridViewRow = dgvpendidikan.Rows(rowIndex)
                            row.Cells("ffcidpendidikan").Value = rd("ffcidpendidikan")
                            row.Cells("Tingkat").Value = DBString(rd, "ffctingkat")
                            row.Cells("Institusi").Value = DBString(rd, "ffcnamainstitusi")
                            row.Cells("Jurusan").Value = DBString(rd, "ffcjurusan")

                            row.Cells("Nilai").Value = DBString(rd, "ffcnilai")
                            row.Cells("Keterangan").Value = DBString(rd, "ffcketerangan")
                            If Not IsDBNull(rd("ffctahunmasuk")) Then
                                row.Cells("TahunMasuk").Value = Convert.ToInt32(rd("ffctahunmasuk"))
                            End If
                            If Not IsDBNull(rd("ffctahunlulus")) Then
                                row.Cells("TahunLulus").Value = Convert.ToInt32(rd("ffctahunlulus"))
                            End If
                        End While

                    End Using

                End Using

            End Using

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat data pendidikan." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub LoadPengalaman(idKandidat As Long)
        Try

            dgvpengalaman.Rows.Clear()

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffcidpengalaman,ffcperusahaan, ffcjabatan,ffdtglmulai, ffdtglselesai,ffcgajiterakhir,ffcalasanberhenti,ffcketerangan " &
                "FROM sakandidatpengalaman WHERE ffcidkandidat = @ID ORDER BY ffdtglmulai DESC, ffcidpengalaman DESC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idKandidat

                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            Dim rowIndex As Integer = dgvpengalaman.Rows.Add()
                            Dim row As DataGridViewRow = dgvpengalaman.Rows(rowIndex)
                            row.Cells("ffcidpengalaman").Value = rd("ffcidpengalaman")
                            row.Cells("Perusahaan").Value = DBString(rd, "ffcperusahaan")
                            row.Cells("Jabatan").Value = DBString(rd, "ffcjabatan")
                            If Not IsDBNull(rd("ffdtglmulai")) Then
                                row.Cells("TanggalMulai").Value = Convert.ToDateTime(rd("ffdtglmulai"))
                            End If

                            If Not IsDBNull(rd("ffdtglselesai")) Then
                                row.Cells("TanggalSelesai").Value = Convert.ToDateTime(rd("ffdtglselesai"))
                            End If
                            row.Cells("GajiTerakhir").Value = DBString(rd, "ffcgajiterakhir")
                            row.Cells("AlasanBerhenti").Value = DBString(rd, "ffcalasanberhenti")
                            row.Cells("Keterangan").Value = DBString(rd, "ffcketerangan")
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memuat pengalaman kerja." & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub LoadKeahlian(idKandidat As Long)
        Try
            dgvkeahlian.Rows.Clear()
            Using conn As New MySqlConnection(sambung)
                conn.Open()

                Dim sql As String = "SELECT ffcidkeahlian,ffckeahlian,ffctingkat,ffcketerangan FROM sakandidatkeahlian WHERE ffcidkandidat = @ID ORDER BY ffcidkeahlian DESC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idKandidat
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()
                            Dim rowIndex As Integer = dgvkeahlian.Rows.Add()
                            Dim row As DataGridViewRow = dgvkeahlian.Rows(rowIndex)
                            row.Cells("ffcidkeahlian").Value = rd("ffcidkeahlian")
                            row.Cells("Keahlian").Value = DBString(rd, "ffckeahlian")
                            row.Cells("Tingkat").Value = DBString(rd, "ffctingkat")
                            row.Cells("Keterangan").Value = DBString(rd, "ffcketerangan")
                        End While

                    End Using

                End Using

            End Using

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memuat data keahlian." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub LoadSertifikat(idKandidat As Long)
        Try
            dgvsertifikat.Rows.Clear()
            If idKandidat <= 0 Then
                Return
            End If
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT s.ffcidsertifikat, s.ffcnamasertifikat, s.ffcpenerbit, s.ffcnomorsertifikat, s.ffdtglterbit, s.ffdtglkadaluarsa, s.ffciddokumen, d.ffcfile, s.ffcketerangan " &
                                              "FROM sakandidatsertifikat s LEFT JOIN sakandidatdokumen d ON d.ffciddokumen = s.ffciddokumen " &
                                              "WHERE s.ffcidkandidat = @idkandidat ORDER BY s.ffcidsertifikat", conn)
                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = idKandidat
                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        While rd.Read()
                            Dim rowIndex As Integer = dgvsertifikat.Rows.Add()
                            Dim row As DataGridViewRow = dgvsertifikat.Rows(rowIndex)
                            row.Cells("ffcidsertifikat").Value = Convert.ToInt64(rd("ffcidsertifikat"))
                            row.Cells("NamaSertifikat").Value = DBString(rd, "ffcnamasertifikat")
                            row.Cells("Penerbit").Value = DBString(rd, "ffcpenerbit")
                            row.Cells("NomorSertifikat").Value = DBString(rd, "ffcnomorsertifikat")
                            row.Cells("ffciddokumen").Value = If(rd.IsDBNull(rd.GetOrdinal("ffciddokumen")), DBNull.Value, CObj(rd.GetInt64(rd.GetOrdinal("ffciddokumen"))))

                            If Not rd.IsDBNull(rd.GetOrdinal("ffdtglterbit")) Then
                                row.Cells("TanggalTerbit").Value = Convert.ToDateTime(rd("ffdtglterbit")).Date
                            Else
                                row.Cells("TanggalTerbit").Value = DBNull.Value
                            End If

                            If Not rd.IsDBNull(rd.GetOrdinal("ffdtglkadaluarsa")) Then
                                row.Cells("TanggalKadaluarsa").Value = Convert.ToDateTime(rd("ffdtglkadaluarsa")).Date
                            Else
                                row.Cells("TanggalKadaluarsa").Value = DBNull.Value
                            End If

                            Dim storedFilePath As String = DBString(rd, "ffcfile")

                            'Nama file untuk ditampilkan
                            If String.IsNullOrWhiteSpace(storedFilePath) Then
                                row.Cells("File").Value = String.Empty
                            Else
                                row.Cells("File").Value = Path.GetFileName(storedFilePath)
                            End If


                            '============================================
                            ' 11. SOURCE FILE PATH
                            '
                            ' Data dari database berarti file
                            ' sudah tersimpan di server.
                            '
                            ' Jadi SourceFilePath kosong.
                            '============================================
                            row.Cells("SourceFilePath").Value = String.Empty


                            '============================================
                            ' 12. STORED FILE PATH
                            '
                            ' Simpan relative path server.
                            '============================================
                            row.Cells("StoredFilePath").Value = storedFilePath


                            '============================================
                            ' 13. KETERANGAN
                            '============================================
                            row.Cells("Keterangan").Value = DBString(rd, "ffcketerangan")


                        End While

                    End Using

                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat sertifikat kandidat." & vbCrLf & ex.Message)
        End Try





    End Sub
    Private Sub LoadDokumen(idKandidat As Long)
        Try
            dgvdokumen.Rows.Clear()
            If idKandidat <= 0 Then
                Return
            End If
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "SELECT ffciddokumen, ffcjenis,ffcnama,ffcfile,ffctipefile,ffnukurang,ffcketerangan FROM sakandidatdokumen WHERE ffcidkandidat = @ID ORDER BY ffciddokumen DESC"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idKandidat

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        While rd.Read()
                            Dim rowIndex As Integer = dgvdokumen.Rows.Add()
                            Dim row As DataGridViewRow = dgvdokumen.Rows(rowIndex)
                            row.Cells("ffciddokumen").Value = Convert.ToInt64(rd("ffciddokumen"))
                            row.Cells("Jenis").Value = DBString(rd, "ffcjenis")
                            row.Cells("NamaFile").Value = DBString(rd, "ffcnama")
                            If Not rd.IsDBNull(rd.GetOrdinal("ffnukurang")) Then
                                row.Cells("Ukuran").Value = Convert.ToInt64(rd("ffnukurang"))
                            Else
                                row.Cells("Ukuran").Value = DBNull.Value
                            End If
                            '============================================
                            ' 9. TIPE FILE
                            '============================================
                            row.Cells("TipeFile").Value = DBString(rd, "ffctipefile")


                            '============================================
                            ' 10. FILE
                            '
                            ' Database:
                            '
                            ' Kandidat/KND-202609-0001/
                            ' Dokumen/CV.pdf
                            '
                            ' Grid File:
                            '
                            ' CV.pdf
                            '
                            ' StoredFilePath:
                            '
                            ' Kandidat/KND-202609-0001/Dokumen/CV.pdf
                            '============================================
                            Dim storedFilePath As String = DBString(rd, "ffcfile")

                            '============================================
                            ' 11. NAMA FILE YANG DITAMPILKAN
                            '============================================
                            If String.IsNullOrWhiteSpace(storedFilePath) Then

                                row.Cells("File").Value = String.Empty

                            Else

                                row.Cells("File").Value = Path.GetFileName(storedFilePath)

                            End If


                            '============================================
                            ' 12. SOURCE FILE PATH
                            '
                            ' Karena data berasal dari database,
                            ' file dianggap sudah tersimpan di server.
                            '============================================
                            row.Cells("SourceFilePath").Value = String.Empty


                            '============================================
                            ' 13. STORED FILE PATH
                            '============================================
                            row.Cells("StoredFilePath").Value = storedFilePath


                            '============================================
                            ' 14. KETERANGAN
                            '============================================
                            row.Cells("Keterangan").Value = DBString(rd, "ffcketerangan")

                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memuat dokumen kandidat." & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub SimpanPendidikan(conn As MySqlConnection, trans As MySqlTransaction, idKandidat As Long)
        For Each idPendidikan As Long In _deletedPendidikanIds
            Dim sqlDelete As String = "DELETE FROM sakandidatpendidikan WHERE ffcidpendidikan = @ID AND ffcidkandidat = @IDKandidat"
            Using cmd As New MySqlCommand(sqlDelete, conn, trans)
                cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idPendidikan
                cmd.Parameters.Add("@IDKandidat", MySqlDbType.Int64).Value = idKandidat
                cmd.ExecuteNonQuery()
            End Using
        Next
        For Each row As DataGridViewRow In dgvpendidikan.Rows

            If row.IsNewRow Then
                Continue For
            End If
            Dim idPendidikan As Long = 0
            If row.Cells("ffcidpendidikan").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidpendidikan").Value) Then
                Long.TryParse(row.Cells("ffcidpendidikan").Value.ToString(), idPendidikan)

            End If

            If idPendidikan <= 0 Then

                Dim sqlInsert As String = "INSERT INTO sakandidatpendidikan (ffcidkandidat,ffctingkat,ffcnamainstitusi,ffcjurusan,ffctahunmasuk,ffctahunlulus,ffcnilai,ffcketerangan) VALUES (@IDKandidat, " &
                "@Tingkat,@Institusi,@Jurusan, @TahunMasuk, @TahunLulus, @Nilai, @Keterangan)"
                Using cmd As New MySqlCommand(sqlInsert, conn, trans)

                    AddParameter(cmd, "@IDKandidat", idKandidat)
                    AddParameter(cmd, "@Tingkat", GetCellValue(row, "Tingkat"))
                    AddParameter(cmd, "@Institusi", GetCellValue(row, "Institusi"))
                    AddParameter(cmd, "@Jurusan", GetCellValue(row, "Jurusan"))
                    AddParameter(cmd, "@TahunMasuk", GetYearValue(row, "TahunMasuk"))
                    AddParameter(cmd, "@TahunLulus", GetYearValue(row, "TahunLulus"))
                    AddParameter(cmd, "@Nilai", GetCellValue(row, "Nilai"))
                    AddParameter(cmd, "@Keterangan", GetCellValue(row, "Keterangan"))
                    cmd.ExecuteNonQuery()
                End Using

            Else
                Dim sqlUpdate As String = "UPDATE sakandidatpendidikan SET ffctingkat = @Tingkat,ffcnamainstitusi = @Institusi, ffcjurusan = @Jurusan, ffctahunmasuk = @TahunMasuk, " &
                "ffctahunlulus = @TahunLulus, ffcnilai = @Nilai, ffcketerangan = @Keterangan, ffdupdate = NOW() WHERE ffcidpendidikan = @ID AND ffcidkandidat = @IDKandidat"
                Using cmd As New MySqlCommand(sqlUpdate, conn, trans)
                    AddParameter(cmd, "@ID", idPendidikan)
                    AddParameter(cmd, "@IDKandidat", idKandidat)
                    AddParameter(cmd, "@Tingkat", GetCellValue(row, "Tingkat"))
                    AddParameter(cmd, "@Institusi", GetCellValue(row, "Institusi"))
                    AddParameter(cmd, "@Jurusan", GetCellValue(row, "Jurusan"))
                    AddParameter(cmd, "@TahunMasuk", GetYearValue(row, "TahunMasuk"))
                    AddParameter(cmd, "@TahunLulus", GetYearValue(row, "TahunLulus"))
                    AddParameter(cmd, "@Nilai", GetCellValue(row, "Nilai"))
                    AddParameter(cmd, "@Keterangan", GetCellValue(row, "Keterangan"))
                    cmd.ExecuteNonQuery()

                End Using

            End If

        Next

    End Sub

    Private Sub SimpanPengalaman(conn As MySqlConnection, trans As MySqlTransaction, idKandidat As Long)

        For Each idPengalaman As Long In _deletedPengalamanIds
            Dim sqlDelete As String = "DELETE FROM sakandidatpengalaman WHERE ffcidpengalaman = @ID AND ffcidkandidat = @IDKandidat"
            Using cmd As New MySqlCommand(sqlDelete, conn, trans)
                cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idPengalaman
                cmd.Parameters.Add("@IDKandidat", MySqlDbType.Int64).Value = idKandidat
                cmd.ExecuteNonQuery()
            End Using

        Next
        For Each row As DataGridViewRow In dgvpengalaman.Rows

            If row.IsNewRow Then
                Continue For
            End If

            Dim idPengalaman As Long = 0
            If row.Cells("ffcidpengalaman").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidpengalaman").Value) Then
                Long.TryParse(row.Cells("ffcidpengalaman").Value.ToString(), idPengalaman)
            End If

            If idPengalaman <= 0 Then

                Dim sqlInsert As String = "INSERT INTO sakandidatpengalaman (ffcidkandidat, ffcperusahaan, ffcjabatan, ffdtglmulai,ffdtglselesai,ffcgajiterakhir,ffcalasanberhenti,ffcketerangan) VALUES (@IDKandidat, " &
                "@Perusahaan, @Jabatan, @TanggalMulai, @TanggalSelesai,@GajiTerakhir, @AlasanBerhenti, @Keterangan)"


                Using cmd As New MySqlCommand(sqlInsert, conn, trans)
                    AddParameter(cmd, "@IDKandidat", idKandidat)
                    AddParameter(cmd, "@Perusahaan", GetCellValue(row, "Perusahaan"))
                    AddParameter(cmd, "@Jabatan", GetCellValue(row, "Jabatan"))
                    AddParameter(cmd, "@TanggalMulai", GetDateValue(row, "TanggalMulai"))
                    AddParameter(cmd, "@TanggalSelesai", GetDateValue(row, "TanggalSelesai"))
                    AddParameter(cmd, "@GajiTerakhir", GetDecimalValue(row, "GajiTerakhir"))
                    AddParameter(cmd, "@AlasanBerhenti", GetCellValue(row, "AlasanBerhenti"))
                    AddParameter(cmd, "@Keterangan", GetCellValue(row, "Keterangan"))
                    cmd.ExecuteNonQuery()
                End Using

            Else

                Dim sqlUpdate As String = "UPDATE sakandidatpengalaman Set ffcperusahaan = @Perusahaan, ffcjabatan = @Jabatan, ffdtglmulai = @TanggalMulai, " &
                "ffdtglselesai = @TanggalSelesai, ffcgajiterakhir = @GajiTerakhir, ffcalasanberhenti = @AlasanBerhenti,ffcketerangan = @Keterangan WHERE ffcidpengalaman = @ID And ffcidkandidat = @IDKandidat"


                Using cmd As New MySqlCommand(sqlUpdate, conn, trans)

                    AddParameter(cmd, "@ID", idPengalaman)
                    AddParameter(cmd, "@IDKandidat", idKandidat)
                    AddParameter(cmd, "@Perusahaan", GetCellValue(row, "Perusahaan"))
                    AddParameter(cmd, "@Jabatan", GetCellValue(row, "Jabatan"))
                    AddParameter(cmd, "@TanggalMulai", GetDateValue(row, "TanggalMulai"))
                    AddParameter(cmd, "@TanggalSelesai", GetDateValue(row, "TanggalSelesai"))
                    AddParameter(cmd, "@GajiTerakhir", GetDecimalValue(row, "GajiTerakhir"))
                    AddParameter(cmd, "@AlasanBerhenti", GetCellValue(row, "AlasanBerhenti"))
                    AddParameter(cmd, "@Keterangan", GetCellValue(row, "Keterangan"))
                    cmd.ExecuteNonQuery()

                End Using

            End If

        Next

    End Sub
    Private Sub SimpanKeahlian(conn As MySqlConnection, trans As MySqlTransaction, idKandidat As Long)
        For Each idKeahlian As Long In _deletedKeahlianIds

            Dim sqlDelete As String = "DELETE FROM sakandidatkeahlian WHERE ffcidkeahlian = @ID AND ffcidkandidat = @IDKandidat"
            Using cmd As New MySqlCommand(sqlDelete, conn, trans)
                cmd.Parameters.Add("@ID", MySqlDbType.Int64).Value = idKeahlian
                cmd.Parameters.Add("@IDKandidat", MySqlDbType.Int64).Value = idKandidat
                cmd.ExecuteNonQuery()

            End Using

        Next
        For Each row As DataGridViewRow In dgvkeahlian.Rows
            If row.IsNewRow Then
                Continue For
            End If
            Dim idKeahlian As Long = 0

            If row.Cells("ffcidkeahlian").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcidkeahlian").Value) Then
                Long.TryParse(row.Cells("ffcidkeahlian").Value.ToString(), idKeahlian)
            End If
            If idKeahlian <= 0 Then

                Dim sqlInsert As String = "INSERT INTO sakandidatkeahlian (ffcidkandidat, ffckeahlian,ffctingkat, ffcketerangan) VALUES (@IDKandidat, " &
                "@Keahlian, @Tingkat, @Keterangan)"


                Using cmd As New MySqlCommand(sqlInsert, conn, trans)

                    AddParameter(cmd, "@IDKandidat", idKandidat)
                    AddParameter(cmd, "@Keahlian", GetCellValue(row, "Keahlian"))
                    AddParameter(cmd, "@Tingkat", GetCellValue(row, "Tingkat"))
                    AddParameter(cmd, "@Keterangan", GetCellValue(row, "Keterangan"))
                    cmd.ExecuteNonQuery()
                End Using

            Else

                Dim sqlUpdate As String = "UPDATE sakandidatkeahlian SET ffckeahlian = @Keahlian, " &
                "ffctingkat = @Tingkat,ffcketerangan = @Keterangan WHERE ffcidkeahlian = @ID AND ffcidkandidat = @IDKandidat"

                Using cmd As New MySqlCommand(sqlUpdate, conn, trans)
                    AddParameter(cmd, "@ID", idKeahlian)
                    AddParameter(cmd, "@IDKandidat", idKandidat)
                    AddParameter(cmd, "@Keahlian", GetCellValue(row, "Keahlian"))
                    AddParameter(cmd, "@Tingkat", GetCellValue(row, "Tingkat"))
                    AddParameter(cmd, "@Keterangan", GetCellValue(row, "Keterangan"))
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Next

    End Sub
    Private Sub SimpanSertifikat(conn As MySqlConnection, trans As MySqlTransaction, idKandidat As Long, noKandidat As String, fileBaru As List(Of String))

        '========================================
        ' 1. DELETE
        '========================================
        For Each id As Long In _deletedSertifikatIds
            Using cmd As New MySqlCommand("DELETE FROM sakandidatsertifikat WHERE ffcidsertifikat = @id AND ffcidkandidat = @idKandidat", conn, trans)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@idKandidat", idKandidat)
                cmd.ExecuteNonQuery()
            End Using
        Next

        '========================================
        ' 2. INSERT / UPDATE
        '========================================
        For Each row As DataGridViewRow In dgvsertifikat.Rows

            If row.IsNewRow Then Continue For

            Dim id As Long = GetLongValue(row, "ffcidsertifikat")

            Dim namaSertifikatObj As Object = GetCellValue(row, "NamaSertifikat")
            Dim namaSertifikat As String = If(namaSertifikatObj Is Nothing OrElse IsDBNull(namaSertifikatObj), String.Empty, namaSertifikatObj.ToString())

            Dim penerbitObj As Object = GetCellValue(row, "Penerbit")
            Dim penerbit As String = If(penerbitObj Is Nothing OrElse IsDBNull(penerbitObj), String.Empty, penerbitObj.ToString())

            Dim nomorSertifikatObj As Object = GetCellValue(row, "NomorSertifikat")
            Dim nomorSertifikat As String = If(nomorSertifikatObj Is Nothing OrElse IsDBNull(nomorSertifikatObj), String.Empty, nomorSertifikatObj.ToString())

            Dim tanggalTerbit As Object = GetDateValue(row, "TanggalTerbit")
            Dim tanggalKadaluarsa As Object = GetDateValue(row, "TanggalKadaluarsa")

            Dim keteranganObj As Object = GetCellValue(row, "Keterangan")
            Dim keterangan As String = If(keteranganObj Is Nothing OrElse IsDBNull(keteranganObj), String.Empty, keteranganObj.ToString())


            '   Dim id As Long = GetLongValue(row, "ffcidsertifikat")
            '   Dim namaSertifikat As String = GetCellValue(row, "NamaSertifikat")
            '   Dim penerbit As String = GetCellValue(row, "Penerbit")
            '  Dim nomorSertifikat As String = GetCellValue(row, "NomorSertifikat")
            '  Dim tanggalTerbit As Object = GetDateValue(row, "TanggalTerbit")
            '  Dim tanggalKadaluarsa As Object = GetDateValue(row, "TanggalKadaluarsa")
            ' Dim keterangan As String = GetCellValue(row, "Keterangan")

            ' ID dokumen yang sudah terhubung sebelumnya (0 jika belum ada)
            Dim idDokumen As Long = GetLongFromGrid(row, "ffciddokumen")

            ' Apakah user memilih file BARU untuk baris ini?
            Dim sourcePathBaru As String = Convert.ToString(GetCellValue(row, "SourceFilePath"))
            Dim adaFileBaru As Boolean = Not String.IsNullOrWhiteSpace(sourcePathBaru)

            If adaFileBaru Then

                ' Copy file fisik ke folder server
                Dim newStoredPath As String = SimpanFile(sourcePathBaru, noKandidat, "Sertifikat")
                If String.IsNullOrWhiteSpace(newStoredPath) Then
                    Throw New Exception("Gagal menyimpan file sertifikat ke server.")
                End If
                fileBaru.Add(newStoredPath)

                Dim namaFileBaru As String = Path.GetFileName(newStoredPath)

                If idDokumen > 0 Then
                    ' Sudah ada dokumen sebelumnya -> update record dokumennya
                    Using cmdDok As New MySqlCommand("UPDATE sakandidatdokumen SET ffcnama = @nama, ffcfile = @file, ffdupdate = NOW() WHERE ffciddokumen = @id", conn, trans)
                        cmdDok.Parameters.AddWithValue("@nama", namaFileBaru)
                        cmdDok.Parameters.AddWithValue("@file", newStoredPath)
                        cmdDok.Parameters.AddWithValue("@id", idDokumen)
                        cmdDok.ExecuteNonQuery()
                    End Using
                Else
                    ' Belum ada dokumen -> insert baru, ambil ID-nya
                    Using cmdDok As New MySqlCommand("INSERT INTO sakandidatdokumen (ffcidkandidat, ffcjenis, ffcnama, ffcfile) VALUES (@idkandidat, 'Sertifikat', @nama, @file)", conn, trans)
                        cmdDok.Parameters.AddWithValue("@idkandidat", idKandidat)
                        cmdDok.Parameters.AddWithValue("@nama", namaFileBaru)
                        cmdDok.Parameters.AddWithValue("@file", newStoredPath)
                        cmdDok.ExecuteNonQuery()
                    End Using
                    idDokumen = Convert.ToInt64(New MySqlCommand("SELECT LAST_INSERT_ID()", conn, trans).ExecuteScalar())
                End If
            End If

            Dim paramIdDokumen As Object = If(idDokumen > 0, CObj(idDokumen), DBNull.Value)

            If id <= 0 Then
                '========================================
                ' INSERT sertifikat baru
                '========================================
                Using cmd As New MySqlCommand("INSERT INTO sakandidatsertifikat (ffcidkandidat,ffcnamasertifikat,ffcpenerbit,ffcnomorsertifikat,ffdtglterbit,ffdtglkadaluarsa,ffciddokumen,ffcketerangan) VALUES (@idKandidat," &
                    "@nama,@penerbit,@nomor,@tglTerbit,@tglKadaluarsa,@idDokumen,@keterangan)", conn, trans)

                    cmd.Parameters.AddWithValue("@idKandidat", idKandidat)
                    cmd.Parameters.AddWithValue("@nama", namaSertifikat)
                    cmd.Parameters.AddWithValue("@penerbit", penerbit)
                    cmd.Parameters.AddWithValue("@nomor", nomorSertifikat)
                    cmd.Parameters.AddWithValue("@tglTerbit", tanggalTerbit)
                    cmd.Parameters.AddWithValue("@tglKadaluarsa", tanggalKadaluarsa)
                    cmd.Parameters.AddWithValue("@idDokumen", paramIdDokumen)
                    cmd.Parameters.AddWithValue("@keterangan", keterangan)
                    cmd.ExecuteNonQuery()

                End Using
            Else
                '========================================
                ' UPDATE sertifikat
                '========================================
                Using cmd As New MySqlCommand("UPDATE sakandidatsertifikat SET ffcnamasertifikat = @nama, ffcpenerbit = @penerbit,ffcnomorsertifikat = @nomor,ffdtglterbit = @tglTerbit,ffdtglkadaluarsa = @tglKadaluarsa," &
                                         " ffciddokumen = @idDokumen,ffcketerangan = @keterangan WHERE ffcidsertifikat = @id AND ffcidkandidat = @idKandidat", conn, trans)

                    cmd.Parameters.AddWithValue("@nama", namaSertifikat)
                    cmd.Parameters.AddWithValue("@penerbit", penerbit)
                    cmd.Parameters.AddWithValue("@nomor", nomorSertifikat)
                    cmd.Parameters.AddWithValue("@tglTerbit", tanggalTerbit)
                    cmd.Parameters.AddWithValue("@tglKadaluarsa", tanggalKadaluarsa)
                    cmd.Parameters.AddWithValue("@idDokumen", paramIdDokumen)
                    cmd.Parameters.AddWithValue("@keterangan", keterangan)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@idKandidat", idKandidat)

                    cmd.ExecuteNonQuery()

                End Using
            End If

        Next

    End Sub
    Private Sub SimpanDokumen(conn As MySqlConnection, trans As MySqlTransaction, idKandidat As Long, noKandidat As String, fileBaru As List(Of String))
        For Each id As Long In _deletedDokumenIds

            Using cmd As New MySqlCommand("DELETE FROM sakandidatdokumen WHERE ffciddokumen = @id  AND ffcidkandidat = @idkandidat", conn, trans)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.Parameters.AddWithValue("@idkandidat", idKandidat)
                cmd.ExecuteNonQuery()
            End Using
        Next

        For Each row As DataGridViewRow In dgvdokumen.Rows

            If row.IsNewRow Then
                Continue For
            End If
            Dim idDokumen As Long = 0

            If row.Cells("ffciddokumen").Value IsNot Nothing AndAlso row.Cells("ffciddokumen").Value IsNot DBNull.Value Then
                Long.TryParse(row.Cells("ffciddokumen").Value.ToString(), idDokumen)

            End If



            Dim jenis As String = GetCellValue(row, "Jenis")

            Dim namaFile As String = GetCellValue(row, "NamaFile")

            Dim tipeFile As String = GetCellValue(row, "TipeFile")

            Dim keterangan As String = GetCellValue(row, "Keterangan")

            '========================================
            ' FILE FISIK
            '========================================
            Dim sourcePathBaru As String = Convert.ToString(GetCellValue(row, "SourceFilePath"))
            Dim filePath As String
            Dim ukuran As Object

            If Not String.IsNullOrWhiteSpace(sourcePathBaru) Then

                ' Ada file baru -> copy fisik ke folder server
                Dim newStoredPath As String = SimpanFile(sourcePathBaru, noKandidat, "Dokumen")

                If String.IsNullOrWhiteSpace(newStoredPath) Then
                    Throw New Exception("Gagal menyimpan file dokumen ke server.")
                End If

                fileBaru.Add(newStoredPath)
                filePath = newStoredPath
                ukuran = New FileInfo(sourcePathBaru).Length

            Else
                ' Tidak ada file baru -> pakai path lama (mode edit tanpa ganti file)
                filePath = GetCellValue(row, "StoredFilePath")
                ukuran = GetLongValue(row, "Ukuran")

            End If

            If idDokumen <= 0 Then
                Using cmd As New MySqlCommand("INSERT INTO sakandidatdokumen (ffcidkandidat,ffcjenis,ffcnama,ffcfile,ffctipefile,ffnukurang,ffcketerangan) VALUES (@idkandidat," &
                                              " @jenis,@nama,@file,@tipefile, @ukurang, @keterangan )", conn, trans)
                    cmd.Parameters.AddWithValue("@idkandidat", idKandidat)
                    cmd.Parameters.AddWithValue("@jenis", jenis)
                    cmd.Parameters.AddWithValue("@nama", namaFile)
                    cmd.Parameters.AddWithValue("@file", filePath)
                    cmd.Parameters.AddWithValue("@tipefile", tipeFile)
                    cmd.Parameters.AddWithValue("@ukurang", ukuran)
                    cmd.Parameters.AddWithValue("@keterangan", keterangan)
                    cmd.ExecuteNonQuery()

                End Using

            Else

                Using cmd As New MySqlCommand("UPDATE sakandidatdokumen SET ffcjenis = @jenis,ffcnama = @nama,ffcfile = @file,ffctipefile = @tipefile,ffnukurang = @ukurang,ffcketerangan = @keterangan " &
                                              " WHERE ffciddokumen = @id AND ffcidkandidat = @idkandidat", conn, trans)
                    cmd.Parameters.AddWithValue("@id", idDokumen)
                    cmd.Parameters.AddWithValue("@idkandidat", idKandidat)
                    cmd.Parameters.AddWithValue("@jenis", jenis)
                    cmd.Parameters.AddWithValue("@nama", namaFile)
                    cmd.Parameters.AddWithValue("@file", filePath)
                    cmd.Parameters.AddWithValue("@tipefile", tipeFile)
                    cmd.Parameters.AddWithValue("@ukurang", ukuran)
                    cmd.Parameters.AddWithValue("@keterangan", keterangan)
                    cmd.ExecuteNonQuery()
                End Using

            End If

        Next

    End Sub

    Private Sub SimpanKandidat()

        Dim fileBaru As New List(Of String)

        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Using trans As MySqlTransaction = conn.BeginTransaction()

                Try

                    Dim namaFoto As String = SimpanFoto()
                    '========================================
                    ' INSERT DATA KANDIDAT
                    '========================================

                    Dim sql As String = "INSERT INTO sakandidat (ffcnokandidat, ffcnama, ffctempatlahir,ffdtgllahir,ffcjeniskelamin,ffcstatuspernikahan,ffcnik,ffcnotelp,ffcemail,ffcalamat,ffckelurahan, " &
                              "ffckecamatan, ffckota,ffcprovinsi,ffckodepos, ffcstatus, ffcfilefoto,ffcusercreate) VALUES (@NoKandidat,@Nama, @TempatLahir,@TanggalLahir,@JenisKelamin,@StatusPernikahan, " &
                              "@NIK, @NoTelp,@Email,@Alamat, @Kelurahan,@Kecamatan,@Kota,@Provinsi,@KodePos,'ACTIVE', @FileFoto, @UserCreate)"


                    Using cmd As New MySqlCommand(sql, conn, trans)
                        AddParameter(cmd, "@NoKandidat", tkandidat.Text.Trim())
                        AddParameter(cmd, "@Nama", tnamalengkap.Text.Trim())
                        AddParameter(cmd, "@TempatLahir", ttempatlahir.Text.Trim())
                        AddParameter(cmd, "@TanggalLahir", dtgllahir.Value.Date)
                        AddParameter(cmd, "@JenisKelamin", ckelamin.Text.Trim())
                        AddParameter(cmd, "@StatusPernikahan", cstatuspernikahan.Text.Trim())
                        AddParameter(cmd, "@NIK", tnik.Text.Trim())
                        AddParameter(cmd, "@NoTelp", tnotelp.Text.Trim())
                        AddParameter(cmd, "@Email", temail.Text.Trim())
                        AddParameter(cmd, "@Alamat", NullIfEmpty(talamat.Text))
                        AddParameter(cmd, "@Kelurahan", NullIfEmpty(tkelurahan.Text))
                        AddParameter(cmd, "@Kecamatan", NullIfEmpty(tkecamatan.Text))
                        AddParameter(cmd, "@Kota", NullIfEmpty(tkota.Text))
                        AddParameter(cmd, "@Provinsi", NullIfEmpty(tprovinsi.Text))
                        AddParameter(cmd, "@KodePos", NullIfEmpty(tkodepos.Text))
                        AddParameter(cmd, "@FileFoto", NullIfEmpty(namaFoto))
                        AddParameter(cmd, "@UserCreate", _userLogin)
                        cmd.ExecuteNonQuery()

                    End Using


                    '========================================
                    ' 3. AMBIL ID KANDIDAT
                    '========================================

                    _idKandidat = Convert.ToInt64(New MySqlCommand("SELECT LAST_INSERT_ID()", conn, trans).ExecuteScalar())



                    SimpanPendidikan(conn, trans, _idKandidat)
                    SimpanPengalaman(conn, trans, _idKandidat)
                    SimpanKeahlian(conn, trans, _idKandidat)
                    SimpanSertifikat(conn, trans, IdKandidat, tkandidat.Text.Trim(), fileBaru)
                    SimpanDokumen(conn, trans, _idKandidat, tkandidat.Text.Trim(), fileBaru)


                    trans.Commit()


                    PesanPopupSukses("SUKSES", "Data kandidat berhasil disimpan.")

                    Me.DialogResult = DialogResult.OK

                    Me.Close()




                Catch ex As MySqlException
                    trans.Rollback()
                    For Each relativePath As String In fileBaru
                        Try
                            HapusFile(relativePath)
                        Catch
                        End Try
                        PesanPopupError("Error MySQL: Kesalahan Database", ex.Message)
                    Next
                Catch ex As Exception
                    trans.Rollback()
                    For Each relativePath As String In fileBaru
                        Try
                            HapusFile(relativePath)
                        Catch
                        End Try
                    Next
                    PesanPopupError("Error umum: Proses dibatalkan", ex.Message)

                End Try


            End Using




        End Using

    End Sub
    Private Sub UpdateKandidat()
        Dim fileBaru As New List(Of String)
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Using trans As MySqlTransaction = conn.BeginTransaction()
                '  Try
                Dim namaFoto As String = SimpanFoto()
                    '========================================
                    ' UPDATE MASTER
                    '========================================

                    Dim sql As String = "UPDATE sakandidat SET ffcnama = @Nama, ffctempatlahir = @TempatLahir,ffdtgllahir = @TanggalLahir, ffcjeniskelamin = @JenisKelamin,ffcstatuspernikahan = @StatusPernikahan, " &
                            "ffcnik = @NIK, ffcnotelp = @NoTelp,ffcemail = @Email,ffcalamat = @Alamat,ffckelurahan = @Kelurahan,ffckecamatan = @Kecamatan,ffckota = @Kota,ffcprovinsi = @Provinsi,ffckodepos = @KodePos, " &
                            "ffcuserupdate = @UserUpdate, ffdupdate = NOW() "

                    If Not String.IsNullOrWhiteSpace(namaFoto) Then

                        sql &= ", ffcfilefoto = @FileFoto "

                    End If


                    sql &= "WHERE ffcidkandidat = @ID"


                    Using cmd As New MySqlCommand(sql, conn, trans)
                        AddParameter(cmd, "@Nama", tnamalengkap.Text.Trim())
                        AddParameter(cmd, "@TempatLahir", ttempatlahir.Text.Trim())
                        AddParameter(cmd, "@TanggalLahir", dtgllahir.Value.Date)
                        AddParameter(cmd, "@JenisKelamin", ckelamin.Text.Trim())
                        AddParameter(cmd, "@StatusPernikahan", cstatuspernikahan.Text.Trim())
                        AddParameter(cmd, "@NIK", tnik.Text.Trim())
                        AddParameter(cmd, "@NoTelp", tnotelp.Text.Trim())
                        AddParameter(cmd, "@Email", temail.Text.Trim())
                        AddParameter(cmd, "@Alamat", NullIfEmpty(talamat.Text))
                        AddParameter(cmd, "@Kelurahan", NullIfEmpty(tkelurahan.Text))
                        AddParameter(cmd, "@Kecamatan", NullIfEmpty(tkecamatan.Text))
                        AddParameter(cmd, "@Kota", NullIfEmpty(tkota.Text))
                        AddParameter(cmd, "@Provinsi", NullIfEmpty(tprovinsi.Text))
                        AddParameter(cmd, "@KodePos", NullIfEmpty(tkodepos.Text))
                        AddParameter(cmd, "@UserUpdate", _userLogin)
                        AddParameter(cmd, "@ID", _idKandidat)

                        If Not String.IsNullOrWhiteSpace(namaFoto) Then
                            AddParameter(cmd, "@FileFoto", namaFoto)
                        End If

                        cmd.ExecuteNonQuery()

                    End Using

                    SimpanPendidikan(conn, trans, _idKandidat)
                    SimpanPengalaman(conn, trans, _idKandidat)
                    SimpanKeahlian(conn, trans, _idKandidat)
                    SimpanSertifikat(conn, trans, IdKandidat, tkandidat.Text.Trim(), fileBaru)
                    SimpanDokumen(conn, trans, _idKandidat, tkandidat.Text.Trim(), fileBaru)

                    trans.Commit()


                    PesanPopupSukses("SUKSES", "Data kandidat berhasil diperbarui.")

                    Me.DialogResult = DialogResult.OK

                    Me.Close()

                'Catch ex As MySqlException
                '  trans.Rollback()
                ' PesanPopupError("Error MySQL: Kesalahan Database", ex.Message)

                '  Catch ex As Exception
                '  trans.Rollback()
                ' PesanPopupError("Error umum: Proses dibatalkan", ex.Message)

                '   End Try

            End Using

        End Using



    End Sub
#End Region
#Region "TEXT COMBOBOX DLL"
    Private Sub KontrolC_TextChanged(sender As Object, e As EventArgs) Handles _
        tnamalengkap.TextChanged, ttempatlahir.TextChanged, temail.TextChanged, talamat.TextChanged, tkelurahan.TextChanged, tkecamatan.TextChanged, tkota.TextChanged, tprovinsi.TextChanged
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
    Private Sub KontrolT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        tnamalengkap.KeyPress, ttempatlahir.KeyPress, temail.KeyPress, talamat.KeyPress, tkelurahan.KeyPress, tkecamatan.KeyPress, tkota.KeyPress, tprovinsi.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            SendKeys.Send("{TAB}")

            e.Handled = True

            Exit Sub

        End If


        ' Blokir karakter tanda kutip tunggal
        If e.KeyChar = "'"c Then

            e.Handled = True

        End If
    End Sub
    Private Sub KontrolA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
        tnik.KeyPress, tnotelp.KeyPress, tkodepos.KeyPress
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
#End Region

    Private Sub frmKandidatAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            SetupForm()
            setupComboBox()
            SetupGridDokumen()
            SetupGridKeahlian()
            SetupGridPendidikan()
            SetupGridPengalaman()
            SetupGridSertifikat()

            Select Case _mode
                Case ModeForm.Tambah
                    Setmodetambah()
                Case ModeForm.Edit
                    setmodeedit()
                Case ModeForm.View
                    SetModeView()
            End Select
            ShadowForm.SetShadowForm(Me)
        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat form kandidat : " & ex.Message)
        End Try

    End Sub
    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub
    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()
    End Sub

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click
        If Not ValidasiInput() Then
            Return
        End If

        Dim HasilKonfirmasi As DialogResult = PesanPopupKonfirmasi("Konfirmasi", "Apakah data kandidat akan disimpan ?")
        If HasilKonfirmasi = DialogResult.No Then
            Return
        End If



        If _mode = ModeForm.Tambah Then


            SimpanKandidat()


        ElseIf _mode = ModeForm.Edit Then

            UpdateKandidat()

        End If

    End Sub
    Private Sub bUploadFoto_Click(sender As Object, e As EventArgs) Handles bUploadFoto.Click
        Try
            Using ofd As New OpenFileDialog()
                ofd.Title = "Pilih Foto Kandidat"
                ofd.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.bmp"
                ofd.Multiselect = False
                If ofd.ShowDialog() = DialogResult.OK Then
                    _fotoPath = ofd.FileName
                    _fotoFileName = Path.GetFileName(ofd.FileName)

                    Using fs As New FileStream(_fotoPath, FileMode.Open, FileAccess.Read)

                        PicFoto.Image = Image.FromStream(fs)

                    End Using

                End If

            End Using

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat foto : " & ex.Message)
        End Try

    End Sub


End Class