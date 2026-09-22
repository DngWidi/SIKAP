Imports Guna.UI2.WinForms
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
    Private Sub KontrolC_TextChanged(sender As Object, e As EventArgs) Handles _
        tinstitusi.TextChanged, tketerangan.TextChanged, tjurusan.TextChanged
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
       tinstitusi.KeyPress, tketerangan.KeyPress, tjurusan.KeyPress
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
       tnilai.KeyPress, ttahunlulus.KeyPress, ttahunmasuk.KeyPress
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
End Class

