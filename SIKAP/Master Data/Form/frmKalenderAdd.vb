Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class frmKalenderAdd
    Public Property ModeEdit As Boolean = False
    Public Property TanggalLama As String = "" ' Menyimpan tanggal awal sebelum diedit (format: yyyy-MM-dd)

    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()

#Region "Private Method"

    Private Function ValidasiInput() As Boolean
        '========================================
        ' VALIDASI TANGGAL
        '========================================
        If dTanggal.Value = DateTime.MinValue Then
            PesanPopupPeringatan("Validasi", "Tanggal libur belum dipilih.")
            dTanggal.Focus()
            Return False
        End If

        '========================================
        ' VALIDASI KETERANGAN
        '========================================
        If String.IsNullOrWhiteSpace(tKeterangan.Text) Then
            PesanPopupPeringatan("Validasi", "Keterangan libur belum diisi.")
            tKeterangan.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function CekTanggalLibur(ByVal tgl As String) As Boolean
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                ' Kolom tanggal di database Anda adalah ffdtgl
                Dim sql As String = "SELECT COUNT(*) FROM salibur WHERE ffdtgl = @tgl"

                ' Jika mode Edit dan tanggal tidak berubah, jangan anggap duplikat
                If ModeEdit Then
                    sql &= " AND ffdtgl <> @tglLama"
                End If

                Using comm As New MySqlCommand(sql, conn)
                    comm.Parameters.AddWithValue("@tgl", tgl)

                    If ModeEdit Then
                        comm.Parameters.AddWithValue("@tglLama", TanggalLama)
                    End If

                    Dim jumlah As Integer = Convert.ToInt32(comm.ExecuteScalar())
                    Return jumlah > 0
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal memeriksa data tanggal libur." & vbCrLf & ex.Message)
            Return True
        End Try
    End Function

#End Region

#Region "Button Events"

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
        ' 1. VALIDASI INPUT
        '========================================
        If Not ValidasiInput() Then
            Return
        End If

        Dim tanggalPilihStr As String = dTanggal.Value.ToString("yyyy-MM-dd")

        '========================================
        ' 2. CEK DUPLIKAT TANGGAL
        '========================================
        If CekTanggalLibur(tanggalPilihStr) Then
            PesanPopupPeringatan("Tanggal Libur", "Hari libur pada tanggal " & tanggalPilihStr & " sudah terdaftar di sistem.")
            dTanggal.Focus()
            Return
        End If

        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Dim mTransaksi As MySqlTransaction = conn.BeginTransaction()

            Try
                '========================================
                ' 3. MODE TAMBAH
                '========================================
                If Not ModeEdit Then
                    Using comm As New MySqlCommand("INSERT INTO salibur (ffdtgl, ffcket, ffc_id) VALUES (@tgl, @ket, @user)", conn, mTransaksi)
                        comm.Parameters.AddWithValue("@tgl", tanggalPilihStr)
                        comm.Parameters.AddWithValue("@ket", tKeterangan.Text.Trim())
                        comm.Parameters.AddWithValue("@user", "admin") ' Sesuaikan dengan ID user aktif jika ada
                        comm.ExecuteNonQuery()
                    End Using

                    mTransaksi.Commit()
                    PesanPopupSukses("Sukses", "Hari libur tanggal " & tanggalPilihStr & " berhasil ditambahkan.")

                    '========================================
                    ' 4. MODE EDIT
                    '========================================
                Else
                    Using comm As New MySqlCommand("UPDATE salibur SET ffdtgl = @tgl, ffcket = @ket WHERE ffdtgl = @tglLama", conn, mTransaksi)
                        comm.Parameters.AddWithValue("@tgl", tanggalPilihStr)
                        comm.Parameters.AddWithValue("@ket", tKeterangan.Text.Trim())
                        comm.Parameters.AddWithValue("@tglLama", TanggalLama)
                        comm.ExecuteNonQuery()
                    End Using

                    mTransaksi.Commit()
                    PesanPopupSukses("Sukses", "Data hari libur berhasil diperbarui.")
                End If

                '========================================
                ' 5. TUTUP FORM
                '========================================
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Catch ex As MySqlException
                Try
                    mTransaksi.Rollback()
                Catch
                End Try
                PesanPopupError("Error MySQL", ex.Message)

            Catch ex As Exception
                Try
                    mTransaksi.Rollback()
                Catch
                End Try
                PesanPopupError("Error", ex.Message)
            End Try
        End Using
    End Sub

#End Region

#Region "Control Interactivity & Formatting"

    ' Otomatis format huruf kapital di awal kata untuk TextBox keterangan
    Private Sub tKeterangan_TextChanged(sender As Object, e As EventArgs) Handles tKeterangan.TextChanged
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

    ' Navigasi Enter dan cegah karakter tanda kutip tunggal (') agar aman dari error SQL
    Private Sub tKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tKeterangan.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = "'"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmKalenderAdd_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.BeginInvoke(New MethodInvoker(
            Sub()
                tKeterangan.Focus()
                tKeterangan.Select()
            End Sub))
    End Sub

    Private Sub frmKalenderAdd_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShadowForm.SetShadowForm(Me)
    End Sub

#End Region

End Class