Imports Guna.UI2.WinForms

Public Class f_pesan

    '==========================================================
    ' SHADOW
    '==========================================================
    Private ShadowForm As New Guna2ShadowForm()

    '==========================================================
    ' TIMER ANIMASI
    '==========================================================
    Private WithEvents TimerFadeIn As New Timer()
    Private WithEvents TimerFadeOut As New Timer()

    '==========================================================
    ' VARIABEL
    '==========================================================
    Private IsClosing As Boolean = False

    Public Enum JenisPesan
        Info
        Sukses
        [Error]
        Peringatan
        Konfirmasi
    End Enum

    Public Property HasilKonfirmasi As DialogResult = DialogResult.None


#Region "FORM LOAD"

    Private Sub f_pesan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '======================================================
        ' SHADOW
        '======================================================
        ShadowForm.SetShadowForm(Me)

        '======================================================
        ' POSISI FORM
        '======================================================
        Me.StartPosition = FormStartPosition.CenterParent

        '======================================================
        ' OPACITY AWAL
        '======================================================
        Me.Opacity = 0

        '======================================================
        ' TIMER FADE IN
        '======================================================
        TimerFadeIn.Interval = 15
        TimerFadeIn.Start()

    End Sub

#End Region


#Region "FADE IN"

    Private Sub TimerFadeIn_Tick(sender As Object, e As EventArgs) Handles TimerFadeIn.Tick

        If Me.Opacity < 1 Then

            Me.Opacity += 0.04

        Else

            Me.Opacity = 1
            TimerFadeIn.Stop()

        End If

    End Sub

#End Region


#Region "FADE OUT"

    Private Sub TimerFadeOut_Tick(sender As Object, e As EventArgs) Handles TimerFadeOut.Tick

        If Me.Opacity > 0 Then

            Me.Opacity -= 0.12

        Else

            TimerFadeOut.Stop()

            IsClosing = True

            Me.Close()

        End If

    End Sub

#End Region


#Region "TAMPILKAN PESAN"

    Public Sub TampilkanPesan(ByVal judul As String, ByVal isiPesan As String, ByVal jenis As JenisPesan, Optional ByVal owner As Form = Nothing)

        '======================================================
        ' ISI PESAN
        '======================================================

        lJudul.Text = judul
        lPesan.Text = isiPesan

        '======================================================
        ' RESET HASIL
        '======================================================

        HasilKonfirmasi = DialogResult.None

        '======================================================
        ' RESET TOMBOL
        '======================================================

        bOk.Visible = False
        bYes.Visible = False
        bNo.Visible = False

        '======================================================
        ' RESET WARNA
        '======================================================

        bOk.FillColor = Color.FromArgb(31, 95, 209)

        bYes.FillColor = Color.FromArgb(31, 95, 209)
        bNo.FillColor = Color.FromArgb(226, 232, 240)

        bYes.ForeColor = Color.White
        bNo.ForeColor = Color.FromArgb(51, 65, 85)

        '======================================================
        ' BACKGROUND POPUP
        '======================================================

        Me.BackColor = Color.White

        '======================================================
        ' JENIS PESAN
        '======================================================

        Select Case jenis

            '--------------------------------------------------
            ' SUKSES
            '--------------------------------------------------

            Case JenisPesan.Sukses

                picIcon.Image = My.Resources.Success

                bOk.FillColor = Color.FromArgb(22, 163, 74)

                bOk.Visible = True


            '--------------------------------------------------
            ' ERROR
            '--------------------------------------------------

            Case JenisPesan.Error

                picIcon.Image = My.Resources.Eror

                bOk.FillColor = Color.FromArgb(220, 53, 69)

                bOk.Visible = True


            '--------------------------------------------------
            ' PERINGATAN
            '--------------------------------------------------

            Case JenisPesan.Peringatan

                picIcon.Image = My.Resources.Warning

                bOk.FillColor = Color.FromArgb(245, 158, 11)

                bOk.Visible = True


            '--------------------------------------------------
            ' INFO
            '--------------------------------------------------

            Case JenisPesan.Info

                picIcon.Image = My.Resources.Info

                bOk.FillColor = Color.FromArgb(31, 95, 209)

                bOk.Visible = True


            '--------------------------------------------------
            ' KONFIRMASI
            '--------------------------------------------------

            Case JenisPesan.Konfirmasi

                picIcon.Image = My.Resources.Question

                bYes.FillColor = Color.FromArgb(31, 95, 209)
                bNo.FillColor = Color.FromArgb(226, 232, 240)

                bYes.ForeColor = Color.White
                bNo.ForeColor = Color.FromArgb(51, 65, 85)

                bYes.Visible = True
                bNo.Visible = True

        End Select

        '======================================================
        ' TAMPILKAN POPUP
        '======================================================

        If owner Is Nothing Then

            Me.ShowDialog()

        Else

            Me.ShowDialog(owner)

        End If

    End Sub

#End Region


#Region "BUTTON OK"

    Private Sub bOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bOk.Click

        HasilKonfirmasi = DialogResult.OK

        TutupPopup()

    End Sub

#End Region


#Region "BUTTON YES"

    Private Sub bYes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bYes.Click

        HasilKonfirmasi = DialogResult.Yes

        TutupPopup()

    End Sub

#End Region


#Region "BUTTON NO"

    Private Sub bNo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bNo.Click

        HasilKonfirmasi = DialogResult.No

        TutupPopup()

    End Sub

#End Region


#Region "TUTUP POPUP"

    Private Sub TutupPopup()

        '======================================================
        ' CEGAH DOUBLE CLICK
        '======================================================

        If IsClosing Then Exit Sub

        IsClosing = True

        '======================================================
        ' HENTIKAN FADE IN
        '======================================================

        TimerFadeIn.Stop()

        '======================================================
        ' MULAI FADE OUT
        '======================================================

        TimerFadeOut.Interval = 10
        TimerFadeOut.Start()

    End Sub

#End Region


#Region "FORM CLOSING"

    Private Sub f_pesan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        '======================================================
        ' JIKA FORM DITUTUP DARI X
        '======================================================

        If Not IsClosing Then

            HasilKonfirmasi = DialogResult.Cancel

        End If

    End Sub

#End Region

End Class