Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Globalization
Imports Guna.UI2.WinForms
Imports System.Windows.Forms
Public Class frmSertifikatAdd
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
    Public Property IdSertifikat As Long = 0
    Public Property NamaSertifikat As String = String.Empty
    Public Property Penerbit As String = String.Empty
    Public Property NomorSertifikat As String = String.Empty
    Public Property TanggalTerbit As Date = Date.Today
    Public Property TanggalKadaluarsa As Date? = Nothing
    Public Property Keterangan As String = String.Empty
    Public Property FilePath As String
        Get
            Return _selectedFilePath
        End Get
        Set(value As String)
            _selectedFilePath = value
        End Set
    End Property
    Public Property FileName As String
        Get
            Return _selectedFileName
        End Get
        Set(value As String)
            _selectedFileName = value
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
#End Region
#End Region
#Region "FORM LOAD"

    Private Sub frmSertifikatAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
        SetupTanggal()
        ShadowForm.SetShadowForm(Me)
        If _mode = ModeForm.Tambah Then
            ModeTambah()
        Else
            ModeEdit()
        End If

    End Sub

#End Region

#Region "SETUP FORM"

    Private Sub SetupForm()
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.None
        If _mode = ModeForm.Tambah Then
            lblTitle.Text = "Tambah Sertifikat"
            lblDescription.Text = "Tambahkan sertifikat kandidat"
            bSimpan.Text = "Simpan"
        Else
            lblTitle.Text = "Edit Sertifikat"
            lblDescription.Text = "Ubah data sertifikat kandidat"
            bSimpan.Text = "Simpan Perubahan"
        End If
        tfile.ReadOnly = True

    End Sub

#End Region

#Region "SETUP TANGGAL"

    Private Sub SetupTanggal()
        dtglterbit.Format = DateTimePickerFormat.Custom
        dtglterbit.CustomFormat = "dd/MM/yyyy"
        dtglterbit.ShowCheckBox = False
        dtglkadaluarso.Format = DateTimePickerFormat.Custom
        dtglkadaluarso.CustomFormat = "dd/MM/yyyy"
        dtglkadaluarso.ShowCheckBox = True
    End Sub

#End Region

#Region "MODE TAMBAH"

    Private Sub ModeTambah()
        ClearForm()
        dtglterbit.Value = Date.Now
        dtglkadaluarso.Value = Date.Now
        dtglkadaluarso.Checked = False
        _selectedFileName = String.Empty
        _selectedFilePath = String.Empty
        tfile.Clear()
        tsertifikat.Focus()
    End Sub

#End Region

#Region "MODE EDIT"

    Private Sub ModeEdit()
        tsertifikat.Text = NamaSertifikat
        tpenerbit.Text = Penerbit
        tnosertifikat.Text = NomorSertifikat

        If TanggalTerbit <> Date.MinValue Then
            dtglterbit.Value = TanggalTerbit
        Else
            dtglterbit.Value = Date.Now
        End If
        If TanggalKadaluarsa.HasValue Then
            dtglkadaluarso.Value = TanggalKadaluarsa.Value
            dtglkadaluarso.Checked = True
        Else
            dtglkadaluarso.Value = Date.Now
            dtglkadaluarso.Checked = False
        End If
        _selectedFileName = FileName
        _selectedFilePath = FilePath

        If Not String.IsNullOrWhiteSpace(_fileName) Then
            tfile.Text = _selectedFileName
        Else
            tfile.Clear()
        End If
        tketerangan.Text = Keterangan
        tsertifikat.Focus()

    End Sub

#End Region

#Region "CLEAR FORM"

    Private Sub ClearForm()
        tsertifikat.Clear()
        tpenerbit.Clear()
        tnosertifikat.Clear()
        dtglterbit.Value = Date.Now
        dtglkadaluarso.Value = Date.Now
        dtglkadaluarso.Checked = False
        tfile.Clear()
        tketerangan.Clear()
        _fileName = String.Empty
        _filePath = String.Empty
    End Sub

#End Region

#Region "PILIH FILE"

    Private Sub bpilih_Click(sender As Object, e As EventArgs) Handles bpilih.Click

        Using dialog As New OpenFileDialog()
            dialog.Title = "Pilih File Sertifikat"
            dialog.Filter = "File Dokumen|*.pdf;*.jpg;*.jpeg;*.png|" & "PDF|*.pdf|" & "Gambar|*.jpg;*.jpeg;*.png|" & "Semua File|*.*"
            dialog.FilterIndex = 1
            dialog.Multiselect = False

            If dialog.ShowDialog() = DialogResult.OK Then
                _selectedFileName = dialog.FileName
                _selectedFileName = Path.GetFileName(dialog.FileName)
                tfile.Text = _selectedFileName
            End If
        End Using
    End Sub

#End Region

#Region "VALIDASI"

    Private Function ValidasiInput() As Boolean

        If String.IsNullOrWhiteSpace(tsertifikat.Text) Then
            PesanPopupPeringatan("Peringatan", "Nama sertifikat wajib diisi.")
            tsertifikat.Focus()
            Return False
        End If

        If dtglterbit.Value.Date >
           Date.Now.Date Then
            PesanPopupPeringatan("Peringatan", "Tanggal terbit tidak boleh lebih besar dari hari ini.")
            dtglterbit.Focus()
            Return False
        End If
        If dtglkadaluarso.Checked Then
            If dtglkadaluarso.Value.Date < dtglterbit.Value.Date Then
                PesanPopupPeringatan("Peringatan", "Tanggal kadaluarsa tidak boleh lebih kecil dari tanggal terbit.")
                dtglkadaluarso.Focus()
                Return False
            End If
        End If
        Return True
    End Function

#End Region

#Region "SIMPAN"

    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click

        If Not ValidasiInput() Then
            Return
        End If
        NamaSertifikat = tsertifikat.Text.Trim()
        Penerbit = tpenerbit.Text.Trim()
        NomorSertifikat = tnosertifikat.Text.Trim()
        TanggalTerbit = dtglterbit.Value.Date

        If dtglkadaluarso.Checked Then
            TanggalKadaluarsa = dtglkadaluarso.Value.Date
        Else
            TanggalKadaluarsa = Nothing
        End If
        FileName = _selectedFileName
        FilePath = _selectedFilePath
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