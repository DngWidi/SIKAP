Imports System.IO
Imports Guna.UI2.WinForms
Public Class frmDokumenAdd

    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()

#Region "ENUM"

    Public Enum ModeForm
        Tambah
        Edit
    End Enum

#End Region

#Region "PRIVATE"

    Private _mode As ModeForm = ModeForm.Tambah

    'File yang sedang dipilih
    Private _selectedFilePath As String = String.Empty
    Private _selectedFileName As String = String.Empty

    'File yang sudah tersimpan sebelumnya (untuk mode edit)
    Private _storedFilePath As String = String.Empty

#End Region

#Region "PROPERTY"
    Public Property Mode As ModeForm
        Get
            Return _mode
        End Get

        Set(value As ModeForm)
            _mode = value
        End Set
    End Property

    Public Property IdDokumen As Long = 0
    Public Property Jenis As String = String.Empty
    Public Property Nama As String = String.Empty
    Public Property FileName As String
        Get
            Return _selectedFileName
        End Get
        Set(value As String)
            _selectedFileName = value
        End Set
    End Property
    Public Property FilePath As String
        Get
            Return _selectedFilePath
        End Get
        Set(value As String)
            _selectedFilePath = value
        End Set
    End Property
    Public Property StoredFilePath As String
        Get
            Return _storedFilePath
        End Get
        Set(value As String)
            _storedFilePath = value
        End Set
    End Property
    Public Property TipeFile As String = String.Empty
    Public Property Ukuran As Long = 0
    Public Property Keterangan As String = String.Empty
#End Region


#Region "FORM LOAD"

    Private Sub frmKandidatDokumenAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
    End Sub


    Private Sub SetupForm()
        cjenis.Items.Clear()

        cjenis.Items.Add("KTP")
        cjenis.Items.Add("KK")
        cjenis.Items.Add("CV")
        cjenis.Items.Add("Ijazah")
        cjenis.Items.Add("Transkrip Nilai")
        cjenis.Items.Add("NPWP")
        cjenis.Items.Add("SIM")
        cjenis.Items.Add("Surat Pengalaman Kerja")
        cjenis.Items.Add("Pas Foto")
        cjenis.Items.Add("Sertifikat")
        cjenis.Items.Add("Dokumen Lainnya")

        If Mode = ModeForm.Tambah Then
            lblTitle.Text = "Tambah Dokumen"
            lblDescription.Text = "Tambah dokumen kandidat"
            cjenis.SelectedIndex = -1
            tnama.Clear()
            tfile.Clear()
            ttipefile.Clear()
            tukuran.Clear()
            tketerangan.Clear()
            _selectedFilePath = String.Empty
            _selectedFileName = String.Empty
            _storedFilePath = String.Empty
        End If

        If Mode = ModeForm.Edit Then

            lblTitle.Text = "Edit Dokumen"
            lblDescription.Text = "Ubah data dokumen kandidat"
            cjenis.SelectedItem = Jenis
            tnama.Text = Nama
            tfile.Text = FileName
            ttipefile.Text = TipeFile
            tukuran.Text = FormatUkuran(Ukuran)
            tketerangan.Text = Keterangan
            _selectedFilePath = FilePath
            _selectedFileName = FileName
            _storedFilePath = StoredFilePath
        End If

    End Sub

#End Region


#Region "PILIH FILE"

    Private Sub bPilihFile_Click(sender As Object, e As EventArgs) Handles bPilihFile.Click

        Try

            Using ofd As New OpenFileDialog()

                ofd.Title = "Pilih Dokumen Kandidat"

                ofd.Filter = "Dokumen|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx;*.xls;*.xlsx|" &
                    "PDF|*.pdf|" & "Gambar|*.jpg;*.jpeg;*.png|" &
                    "Word|*.doc;*.docx|" &
                    "Excel|*.xls;*.xlsx|" &
                    "Semua File|*.*"

                ofd.FilterIndex = 1
                ofd.Multiselect = False
                If ofd.ShowDialog() <> DialogResult.OK Then
                    Return
                End If

                _selectedFilePath = ofd.FileName
                _selectedFileName = Path.GetFileName(ofd.FileName)

                Dim fi As New FileInfo(_selectedFilePath)
                Dim ukuranFile As Long = fi.Length

                Dim tipeFile As String = Path.GetExtension(_selectedFilePath).ToLower()
                tfile.Text = _selectedFileName
                ttipefile.Text = tipeFile
                tukuran.Text = FormatUkuran(ukuranFile)
            End Using

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memilih file : " & ex.Message)
        End Try

    End Sub

#End Region


#Region "FORMAT UKURAN"

    Private Function FormatUkuran(ukuran As Long) As String
        If ukuran < 1024 Then
            Return ukuran.ToString() & " B"
        ElseIf ukuran < 1024 * 1024 Then
            Return Math.Round(ukuran / 1024.0, 2).ToString() & " KB"

        ElseIf ukuran < 1024 * 1024 * 1024 Then
            Return Math.Round(
                ukuran / (1024.0 * 1024.0), 2).ToString() & " MB"
        Else
            Return Math.Round(ukuran / (1024.0 * 1024.0 * 1024.0), 2).ToString() & " GB"
        End If

    End Function

#End Region


#Region "VALIDASI"

    Private Function ValidasiInput() As Boolean

        If cjenis.SelectedIndex = -1 Then
            PesanPopupPeringatan("Peringatan", "Jenis dokumen wajib dipilih.")
            cjenis.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(tnama.Text) Then
            PesanPopupPeringatan("Peringatan", "Nama dokumen wajib diisi.")
            tnama.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(_selectedFileName) AndAlso String.IsNullOrWhiteSpace(_storedFilePath) Then
            PesanPopupPeringatan("Peringatan", "File dokumen wajib dipilih.")
            Return False

        End If
        Return True

    End Function

#End Region


#Region "SIMPAN"

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click

        If Not ValidasiInput() Then
            Return
        End If
        Jenis = cjenis.Text.Trim()
        Nama = tnama.Text.Trim()

        FileName = _selectedFileName
        FilePath = _selectedFilePath
        StoredFilePath = _storedFilePath

        TipeFile = ttipefile.Text.Trim()


        'Ambil ukuran asli jika file masih tersedia
        If Not String.IsNullOrWhiteSpace(_selectedFilePath) AndAlso
           File.Exists(_selectedFilePath) Then
            Dim fi As New FileInfo(_selectedFilePath)
            Ukuran = fi.Length
        End If
        Keterangan = tketerangan.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

#End Region


#Region "BATAL"

    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

#End Region

End Class