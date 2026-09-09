Imports MySql.Data.MySqlClient
Public Class frmKeahlianAdd
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
#Region "ENUM"

    Public Enum ModeForm
        Tambah
        Edit
    End Enum

#End Region

#Region "PRIVATE"

    Private _mode As ModeForm = ModeForm.Tambah

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


    Public Property IdKeahlian As Long = 0

    Public Property Keahlian As String = String.Empty

    Public Property Tingkat As String = String.Empty

    Public Property Keterangan As String = String.Empty

#End Region

#Region "FORM LOAD"

    Private Sub frmKeahlianAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupForm()
        SetupTingkat()
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
            lblTitle.Text = "Tambah Keahlian"
            lblDescription.Text = "Tambahkan keahlian kandidat"
            bSimpan.Text = "Simpan"
        Else
            lblTitle.Text = "Edit Keahlian"
            lblDescription.Text = "Ubah data keahlian kandidat"
            bSimpan.Text = "Simpan Perubahan"
        End If

    End Sub

#End Region

#Region "SETUP TINGKAT"

    Private Sub SetupTingkat()
        ctingkat.Items.Clear()
        ctingkat.Items.Add("Dasar")
        ctingkat.Items.Add("Menengah")
        ctingkat.Items.Add("Mahir")
        ctingkat.Items.Add("Expert")

    End Sub

#End Region

#Region "MODE TAMBAH"

    Private Sub ModeTambah()
        ClearForm()
        tkeahlian.Focus()

    End Sub

#End Region

#Region "MODE EDIT"

    Private Sub ModeEdit()
        tkeahlian.Text = Keahlian
        ctingkat.SelectedItem = Tingkat
        tketerangan.Text = Keterangan
        tkeahlian.Focus()
    End Sub

#End Region

#Region "CLEAR FORM"

    Private Sub ClearForm()
        tkeahlian.Clear()
        ctingkat.SelectedIndex = -1
        tketerangan.Clear()
    End Sub

#End Region

#Region "VALIDASI"

    Private Function ValidasiInput() As Boolean

        If String.IsNullOrWhiteSpace(tkeahlian.Text) Then
            PesanPopupPeringatan("Peringatan", "Keahlian wajib diisi.")
            tkeahlian.Focus()
            Return False
        End If

        If ctingkat.SelectedIndex = -1 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih tingkat keahlian.")
            ctingkat.Focus()
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
        Keahlian = tkeahlian.Text.Trim()
        Tingkat = ctingkat.Text.Trim()
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