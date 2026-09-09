Imports MySql.Data.MySqlClient
Imports System.Globalization
Public Class frmPengalamanAdd
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
    Private _mode As ModeForm = ModeForm.Tambah
    Public Enum ModeForm
        Tambah
        Edit
    End Enum
    Public Property Mode As ModeForm
        Get
            Return _mode
        End Get
        Set(value As ModeForm)
            _mode = value
        End Set
    End Property
    Public Property IdPengalaman As Long = 0
    Public Property Perusahaan As String = String.Empty
    Public Property Jabatan As String = String.Empty
    Public Property TanggalMulai As Date = Date.Now
    Public Property TanggalSelesai As Date? = Nothing
    Public Property GajiTerakhir As Decimal = 0
    Public Property AlasanBerhenti As String = String.Empty
    Public Property Keterangan As String = String.Empty
#Region "Function"
    Private Function ValidasiInput() As Boolean

        '========================================
        ' PERUSAHAAN
        '========================================

        If String.IsNullOrWhiteSpace(tperusahaan.Text) Then
            PesanPopupPeringatan("Peringatan", "Nama perusahaan wajib diisi.")
            tperusahaan.Focus()
            Return False

        End If
        If String.IsNullOrWhiteSpace(tjabatan.Text) Then
            PesanPopupPeringatan("Peringatan", "Jabatan wajib diisi.")
            tjabatan.Focus()
            Return False
        End If

        If dtglmulai.Value > Date.Now Then
            PesanPopupPeringatan("Peringatan", "Tanggal mulai tidak boleh lebih besar dari hari ini.")
            dtglmulai.Focus()
            Return False

        End If

        If dtglselesai.Checked Then

            If dtglselesai.Value < dtglmulai.Value Then
                PesanPopupPeringatan("Peringatan", "Tanggal selesai tidak boleh lebih kecil dari tanggal mulai.")
                dtglselesai.Focus()
                Return False
            End If

        End If



        If Not String.IsNullOrWhiteSpace(tgajiterakhir.Text) Then
            Dim gaji As Decimal
            If Not Decimal.TryParse(tgajiterakhir.Text.Replace(".", "").Replace(",", ""), gaji) Then
                PesanPopupPeringatan("Peringatan", "Format gaji terakhir tidak valid.")
                tgajiterakhir.Focus()
                Return False
            End If

            If gaji < 0 Then
                PesanPopupPeringatan("Peringatan", "Gaji terakhir tidak boleh kurang dari 0.")
                tgajiterakhir.Focus()
                Return False
            End If

        End If
        Return True

    End Function
    Private Function GetGajiTerakhir() As Decimal

        If String.IsNullOrWhiteSpace(tgajiterakhir.Text) Then
            Return 0
        End If

        Dim angka As String = tgajiterakhir.Text.Replace(".", "").Replace(",", "")

        Dim hasil As Decimal

        If Decimal.TryParse(angka, hasil) Then
            Return hasil
        End If

        Return 0

    End Function
#End Region
#Region "Private Method"
    Private Sub SetupForm()

        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.None

        If _mode = ModeForm.Tambah Then

            lblTitle.Text = "Tambah Pengalaman Kerja"

            lblDescription.Text = "Tambahkan riwayat pengalaman kerja kandidat"

            bSimpan.Text = "Simpan"

        Else

            lblTitle.Text = "Edit Pengalaman Kerja"

            lblDescription.Text = "Ubah data riwayat pengalaman kerja kandidat"

            bSimpan.Text = "Simpan Perubahan"

        End If

    End Sub
    Private Sub SetupTanggal()

        'Tanggal mulai
        dtglmulai.Format = DateTimePickerFormat.Custom
        dtglmulai.CustomFormat = "dd/MM/yyyy"
        dtglmulai.ShowCheckBox = False

        'Tanggal selesai
        dtglselesai.Format = DateTimePickerFormat.Custom
        dtglselesai.CustomFormat = "dd/MM/yyyy"

        'Checkbox digunakan untuk menandakan
        'apakah kandidat masih bekerja
        dtglselesai.ShowCheckBox = True
        dtglselesai.Checked = False

    End Sub
    Private Sub ModeTambah()

        ClearForm()

        dtglmulai.Value = Date.Now

        dtglselesai.Value = Date.Now

        dtglselesai.Checked = False

        tperusahaan.Focus()

    End Sub
    Private Sub ModeEdit()

        tperusahaan.Text = Perusahaan

        tjabatan.Text = Jabatan

        If TanggalMulai <> Date.MinValue Then
            dtglmulai.Value = TanggalMulai
        Else
            dtglmulai.Value = Date.Now
        End If

        If TanggalSelesai.HasValue Then

            dtglselesai.Value = TanggalSelesai.Value
            dtglselesai.Checked = True

        Else

            dtglselesai.Value = Date.Now
            dtglselesai.Checked = False

        End If

        If GajiTerakhir > 0 Then

            tgajiterakhir.Text = GajiTerakhir.ToString("#,##0", CultureInfo.InvariantCulture)

        Else

            tgajiterakhir.Clear()

        End If

        talasanberhenti.Text = AlasanBerhenti

        tketerangan.Text = Keterangan

        tperusahaan.Focus()

    End Sub
    Private Sub ClearForm()

        tperusahaan.Clear()

        tjabatan.Clear()

        dtglmulai.Value = Date.Now

        dtglselesai.Value = Date.Now
        dtglselesai.Checked = False

        tgajiterakhir.Clear()

        talasanberhenti.Clear()

        tketerangan.Clear()

    End Sub
    Private Sub UpdateStatusPekerjaan()

        If dtglselesai.Checked Then

            talasanberhenti.Enabled = True

        Else

            talasanberhenti.Enabled = False

        End If

    End Sub
#End Region
    Private Sub frmPengalamanAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupForm()
        SetupTanggal()
        ShadowForm.SetShadowForm(Me)
        If _mode = ModeForm.Tambah Then
            ModeTambah()
        Else
            ModeEdit()
        End If
    End Sub
    Private Sub tgajiterakhir_Leave(sender As Object, e As EventArgs) Handles tgajiterakhir.Leave
        If String.IsNullOrWhiteSpace(tgajiterakhir.Text) Then
            Return
        End If

        Dim gaji As Decimal

        If Decimal.TryParse(tgajiterakhir.Text.Replace(".", "").Replace(",", ""), gaji) Then
            tgajiterakhir.Text = gaji.ToString("#,##0")

        End If

    End Sub
    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click

        If Not ValidasiInput() Then
            Return
        End If

        Perusahaan = tperusahaan.Text.Trim()
        Jabatan = tjabatan.Text.Trim()
        TanggalMulai = dtglmulai.Value.Date

        If dtglselesai.Checked Then
            TanggalSelesai = dtglselesai.Value.Date
        Else
            TanggalSelesai = Nothing
        End If

        GajiTerakhir = GetGajiTerakhir()
        AlasanBerhenti = talasanberhenti.Text.Trim()
        Keterangan = tketerangan.Text.Trim()
        Me.DialogResult = DialogResult.OK

        Me.Close()
    End Sub
    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.DialogResult = DialogResult.Cancel

        Me.Close()
    End Sub


    Private Sub dtglselesai_ValueChanged(sender As Object, e As EventArgs) Handles dtglselesai.ValueChanged
        UpdateStatusPekerjaan()
    End Sub
End Class