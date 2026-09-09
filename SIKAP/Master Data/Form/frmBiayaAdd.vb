Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class frmBiayaAdd
    Public Property ModeEdit As Boolean = False
    Public Property KodeLama As String = ""

    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()


#Region "Private Method"

    Private Function ValidasiInput() As Boolean

        '========================================
        ' VALIDASI KODE
        '========================================
        If String.IsNullOrWhiteSpace(tkode.Text) Then

            PesanPopupPeringatan("Validasi", "Kode biaya belum diisi.")

            tkode.Focus()

            Return False

        End If


        '========================================
        ' VALIDASI NAMA
        '========================================
        If String.IsNullOrWhiteSpace(tNama.Text) Then

            PesanPopupPeringatan("Validasi", "Nama biaya belum diisi.")

            tNama.Focus()

            Return False

        End If


        Return True

    End Function


    Private Function CekKodeBiaya(ByVal kode As String) As Boolean

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT COUNT(*) FROM sabiaya " & "WHERE ffckode = @kode"

                ' Jika mode Edit, jangan anggap kode lama sebagai duplicate
                If ModeEdit Then

                    sql &= " AND ffckode <> @kodeLama"

                End If


                Using comm As New MySqlCommand(sql, conn)

                    comm.Parameters.AddWithValue("@kode", kode)

                    If ModeEdit Then
                        comm.Parameters.AddWithValue("@kodeLama", KodeLama)
                    End If

                    Dim jumlah As Integer =
                        Convert.ToInt32(comm.ExecuteScalar())

                    Return jumlah > 0

                End Using

            End Using

        Catch ex As Exception

            PesanPopupError("Error", "Gagal memeriksa kode biaya." & vbCrLf & ex.Message)

            Return True

        End Try

    End Function


#End Region


#Region "Button"

    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub


    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub


    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click

        '========================================
        ' VALIDASI INPUT
        '========================================
        If Not ValidasiInput() Then
            Return
        End If


        '========================================
        ' CEK DUPLICATE KODE
        '========================================
        If CekKodeBiaya(tkode.Text.Trim()) Then

            PesanPopupPeringatan("Kode Biaya", "Kode biaya '" & tkode.Text.Trim() & "' sudah digunakan.")

            tkode.Focus()

            Return

        End If


        Using conn As New MySqlConnection(sambung)

            conn.Open()

            Dim mTransaksi As MySqlTransaction = conn.BeginTransaction()

            Try

                '========================================
                ' MODE TAMBAH
                '========================================
                If Not ModeEdit Then
                    Using comm As New MySqlCommand("INSERT INTO sabiaya " & "(ffckode, ffcnama) " & "VALUES (@kode, @nama)", conn, mTransaksi)

                        comm.Parameters.AddWithValue("@kode", tkode.Text.Trim())
                        comm.Parameters.AddWithValue("@nama", tNama.Text.Trim())
                        comm.ExecuteNonQuery()

                    End Using


                    mTransaksi.Commit()


                    PesanPopupSukses("Sukses", "Kode Biaya : " & tkode.Text.Trim() & " berhasil disimpan.")


                    '========================================
                    ' MODE EDIT
                    '========================================
                Else

                    Using comm As New MySqlCommand("UPDATE sabiaya SET " & "ffcnama = @nama " & "WHERE ffckode = @kodeLama", conn, mTransaksi)

                        comm.Parameters.AddWithValue("@nama", tNama.Text.Trim())

                        comm.Parameters.AddWithValue("@kodeLama", KodeLama)

                        comm.ExecuteNonQuery()

                    End Using

                    mTransaksi.Commit()


                    PesanPopupSukses("Sukses", "Biaya dengan kode : " & KodeLama & " berhasil diperbarui.")

                End If


                '========================================
                ' TUTUP FORM
                '========================================
                Me.DialogResult = DialogResult.OK
                Me.Close()


            Catch ex As MySqlException

                Try
                    mTransaksi.Rollback()
                Catch
                End Try

                PesanPopupError("Error MySQL: Kesalahan Database", ex.Message)


            Catch ex As Exception

                Try
                    mTransaksi.Rollback()
                Catch
                End Try

                PesanPopupError("Error umum: Proses dibatalkan", ex.Message)

            End Try

        End Using

    End Sub





    Private Sub KontrolC_TextChanged(sender As Object, e As EventArgs) Handles tNama.TextChanged, tkode.TextChanged

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


    Private Sub KontrolT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tNama.KeyPress, tkode.KeyPress

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


    Private Sub frmBiayaAdd_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.BeginInvoke(New MethodInvoker(
                Sub()

                    tkode.Focus()
                    tkode.Select()

                End Sub))

    End Sub

    Private Sub frmBiayaAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShadowForm.SetShadowForm(Me)
    End Sub

#End Region
End Class