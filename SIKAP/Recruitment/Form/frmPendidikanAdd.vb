Imports MySql.Data.MySqlClient

Public Class frmPendidikanAdd
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()



#Region "Enum"

    Public Enum ModeForm
            Tambah
            Edit
        End Enum

#End Region

#Region "Private"

        Private _mode As ModeForm = ModeForm.Tambah

#End Region

#Region "Properties"

        Public Property Mode As ModeForm
            Get
                Return _mode
            End Get

            Set(value As ModeForm)
                _mode = value
            End Set
        End Property

        '========================================
        ' ID DATABASE
        '========================================

        Public Property IdPendidikan As Long = 0

        '========================================
        ' DATA PENDIDIKAN
        '========================================

        Public Property Tingkat As String = String.Empty

        Public Property NamaInstitusi As String = String.Empty

        Public Property Jurusan As String = String.Empty

        Public Property TahunMasuk As Integer = 0

        Public Property TahunLulus As Integer = 0

        Public Property Nilai As String = String.Empty

        Public Property Keterangan As String = String.Empty

#End Region

#Region "Form Load"

    Private Sub frmKandidatPendidikanAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            SetupForm()

            SetupTingkat()
            ShadowForm.SetShadowForm(Me)
            If _mode = ModeForm.Tambah Then

                ModeTambah()

            ElseIf _mode = ModeForm.Edit Then

                ModeEdit()

            End If

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal memuat form pendidikan : " & ex.Message)

        End Try

    End Sub

#End Region

#Region "Setup"

    Private Sub SetupForm()

        Me.StartPosition = FormStartPosition.CenterParent

        Me.FormBorderStyle = FormBorderStyle.None

        lblTitle.Text = If(_mode = ModeForm.Tambah, "Tambah Pendidikan", "Edit Pendidikan")

        lblDescription.Text = If(_mode = ModeForm.Tambah, "Tambahkan riwayat pendidikan kandidat", "Ubah data riwayat pendidikan kandidat")

        bSimpan.Text = If(_mode = ModeForm.Tambah, "Simpan", "Simpan Perubahan")

    End Sub

    Private Sub SetupTingkat()

            ctingkat.Items.Clear()

            ctingkat.Items.Add("SD")
            ctingkat.Items.Add("SMP")
            ctingkat.Items.Add("SMA")
            ctingkat.Items.Add("SMK")
            ctingkat.Items.Add("D1")
            ctingkat.Items.Add("D2")
            ctingkat.Items.Add("D3")
            ctingkat.Items.Add("D4")
            ctingkat.Items.Add("S1")
            ctingkat.Items.Add("S2")
            ctingkat.Items.Add("S3")

        End Sub

#End Region

#Region "Mode"

        Private Sub ModeTambah()

            ClearForm()

            ttahunmasuk.Minimum = 1950
            ttahunmasuk.Maximum = Date.Now.Year

            ttahunlulus.Minimum = 1950
            ttahunlulus.Maximum = Date.Now.Year + 1

            ctingkat.Focus()

        End Sub

    Private Sub ModeEdit()

        ctingkat.SelectedItem = Tingkat

        tinstitusi.Text = NamaInstitusi

        tjurusan.Text = Jurusan

        If TahunMasuk > 0 Then
            ttahunmasuk.Value = TahunMasuk
        End If

        If TahunLulus > 0 Then
            ttahunlulus.Value = TahunLulus
        End If

        tnilai.Text = Nilai

        tketerangan.Text = Keterangan

        ctingkat.Focus()

    End Sub

#End Region

#Region "Function"

    Private Sub ClearForm()
        ctingkat.SelectedIndex = -1
        tinstitusi.Clear()
        tjurusan.Clear()
        ttahunmasuk.Value = Date.Now.Year
        ttahunlulus.Value = Date.Now.Year
        tnilai.Clear()
        tketerangan.Clear()

    End Sub

    Private Function ValidasiInput() As Boolean

            If ctingkat.SelectedIndex = -1 Then

            PesanPopupPeringatan("Peringatan", "Silakan pilih tingkat pendidikan.")

            ctingkat.Focus()

                Return False

            End If


        If String.IsNullOrWhiteSpace(tinstitusi.Text) Then

            PesanPopupPeringatan("Peringatan", "Nama institusi wajib diisi.")

            tinstitusi.Focus()

            Return False

        End If


        If ttahunlulus.Value < ttahunmasuk.Value Then

            PesanPopupPeringatan("Peringatan", "Tahun lulus tidak boleh lebih kecil dari tahun masuk.")

            ttahunlulus.Focus()

            Return False

        End If


        Return True

        End Function

#End Region

#Region "Button"

    Private Sub bSimpan_Click(sender As Object,
            e As EventArgs) Handles bSimpan.Click

        If Not ValidasiInput() Then
            Return
        End If


        '========================================
        ' KEMBALIKAN DATA KE PARENT
        '========================================
        Tingkat = ctingkat.Text.Trim()
        NamaInstitusi = tinstitusi.Text.Trim()
        Jurusan = tjurusan.Text.Trim()
        TahunMasuk = Convert.ToInt32(ttahunmasuk.Value)
        TahunLulus = Convert.ToInt32(ttahunlulus.Value)
        Nilai = tnilai.Text.Trim()
        Keterangan = tketerangan.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub


    Private Sub bBatal_Click(sender As Object,
            e As EventArgs) Handles bBatal.Click

        Me.DialogResult = DialogResult.Cancel

        Me.Close()

    End Sub

#End Region

End Class

