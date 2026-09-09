Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class uf_kodeabsen
#Region "Private"

    Private _keywordCari As String = ""
    Private Sub DataKodeAbsen()

        Try
            '========================================
            ' 1. HITUNG TOTAL RECORD
            '========================================
            paginationKodeAbsen.TotalRecord = GetTotalRecord()



            '========================================
            ' 2. PASTIKAN CURRENT PAGE VALID
            '========================================

            If paginationKodeAbsen.CurrentPage > paginationKodeAbsen.TotalPage Then

                paginationKodeAbsen.CurrentPage = paginationKodeAbsen.TotalPage

            End If


            If paginationKodeAbsen.CurrentPage < 1 Then

                paginationKodeAbsen.CurrentPage = 1

            End If
            '========================================
            ' 3. LOAD DATA
            '========================================


            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffcabs AS `Kode` ,ffcjns AS `Jenis`  ,ffcsat AS  `Satuan`,ffnjum1 AS `Freq periode ini` ,ffnjum2  AS `Freq tahun ini`,ffcket AS `Keterangan` " &
                "FROM sakodeabsen a WHERE ffcabs Like @Cari Or ffcket Like @Cari ORDER BY ffcabs LIMIT @Limit OFFSET @Offset"

                Using cmd As New MySqlCommand(sql, conn)
                    '========================================
                    ' PARAMETER PENCARIAN
                    '========================================
                    cmd.Parameters.Add("@Cari", MySqlDbType.VarChar).Value = "%" & _keywordCari & "%"
                    cmd.Parameters.Add("@Limit", MySqlDbType.Int32).Value = paginationKodeAbsen.PageSize

                    cmd.Parameters.Add("@Offset", MySqlDbType.Int32).Value = paginationKodeAbsen.Offset


                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using


                    dgvKodeAbsen.DataSource = dt

                End Using

            End Using

            UpdatePaginationInfo()

        Catch ex As Exception

            PesanPopupError("Error", "Gagal memuat data kode absen !!" & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub UpdatePaginationInfo()

        lblInfo.Text = String.Format("Menampilkan {0} - {1} dari {2} Data", paginationKodeAbsen.StartRecord, paginationKodeAbsen.EndRecord, paginationKodeAbsen.TotalRecord)

    End Sub
    Private Sub paginationKodeAbsen_PageChanged(sender As Object, e As EventArgs) Handles paginationKodeAbsen.PageChanged
        DataKodeAbsen()
    End Sub
    Private Function GetTotalRecord() As Integer
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim mysql As String = "SELECT COUNT(*) FROM sakodeabsen  WHERE ffcabs LIKE @Cari  OR ffcket LIKE @Cari"
                Using comm As New MySqlCommand(mysql, conn)
                    comm.Parameters.Add("@Cari", MySqlDbType.VarChar).Value = "%" & _keywordCari & "%"
                    Return Convert.ToInt32(comm.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil jumlah data kode absen !!")
            Return 0
        End Try

    End Function

#End Region
    Private Sub uf_kodeabsen_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Style Grid
        ApplyGridTheme(dgvKodeAbsen)


        ' Load Data
        DataKodeAbsen()
    End Sub

    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Using frm As New frmDepartmentAdd()

            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then

                DataKodeABsen()

            End If

        End Using
    End Sub

    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click

        '========================================
        ' CEK APAKAH ADA DATA YANG DIPILIH
        '========================================
        If dgvKodeAbsen.CurrentRow Is Nothing Then

            PesanPopupPeringatan("Pilih Kode Absen", "Silakan pilih kode absen yang ingin diedit.")

            Exit Sub

        End If


        '========================================
        ' AMBIL DATA DARI ROW TERPILIH
        '========================================
        Dim kode As String =
        dgvKodeAbsen.CurrentRow.Cells("Kode").Value.ToString()

        Dim nama As String =
        dgvKodeAbsen.CurrentRow.Cells("Keterangan").Value.ToString()


        '========================================
        ' BUKA FORM EDIT
        '========================================
        Using frm As New frmDepartmentAdd()

            frm.ModeEdit = True
            frm.KodeLama = kode

            frm.tkode.Text = kode
            frm.tNama.Text = nama


            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then

                DataKodeABsen()

            End If

        End Using

    End Sub

    Private Sub bHapus_Click(sender As Object, e As EventArgs) Handles bHapus.Click
        '========================================
        ' CEK DATA YANG DIPILIH
        '========================================
        If dgvKodeAbsen.CurrentRow Is Nothing Then

            PesanPopupPeringatan("Pilih Kode Absen", "Silakan pilih kode absen yang ingin dihapus.")

            Exit Sub

        End If


        '========================================
        ' AMBIL DATA
        '========================================
        Dim kode As String =
            dgvKodeAbsen.CurrentRow.Cells("Kode").Value.ToString()

        Dim nama As String =
            dgvKodeAbsen.CurrentRow.Cells("Keterangan").Value.ToString()


        '========================================
        ' KONFIRMASI
        '========================================
        Dim hasil As DialogResult =
            PesanPopupKonfirmasi("Hapus Kode Absen", "Apakah Anda yakin ingin menghapus kode absen berikut?" & vbCrLf & vbCrLf & "Kode : " & kode & vbCrLf & "Nama : " & nama)


        If hasil <> DialogResult.Yes Then

            Exit Sub

        End If


        '========================================
        ' DELETE DATABASE
        '========================================
        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "DELETE FROM sakodeabsen WHERE ffckode = @Kode"

                Using comm As New MySqlCommand(sql, conn)

                    comm.Parameters.Add("@Kode", MySqlDbType.VarChar).Value = kode

                    comm.ExecuteNonQuery()

                End Using

            End Using


            '========================================
            ' PESAN SUKSES
            '========================================
            PesanPopupSukses("Sukses", "Kode Absen berhasil dihapus.")


            '========================================
            ' REFRESH DATA
            '========================================
            DataKodeAbsen()


        Catch ex As MySqlException

            PesanPopupError("Error", "Gagal menghapus kode absen !!" & vbCrLf & ex.Message)

        Catch ex As Exception

            PesanPopupError("Error", "Terjadi kesalahan !!" & vbCrLf & ex.Message)

        End Try
    End Sub

    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click
        '========================================
        ' SIMPAN KEYWORD PENCARIAN
        '========================================
        _keywordCari = tPencarian.Text.Trim()


        '========================================
        ' KEMBALI KE HALAMAN 1
        '========================================
        paginationKodeAbsen.CurrentPage = 1


        '========================================
        ' LOAD DATA HASIL PENCARIAN
        '========================================
        DataKodeABsen()

    End Sub
    Private Sub tPencarian_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPencarian.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            e.Handled = True

            bCari.PerformClick()

        End If

    End Sub
    Private Sub tPencarian_TextChanged(sender As Object, e As EventArgs) Handles tPencarian.TextChanged
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

    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click
        '========================================
        ' KOSONGKAN PENCARIAN
        '========================================
        tPencarian.Clear()

        _keywordCari = ""


        '========================================
        ' KEMBALI KE HALAMAN 1
        '========================================
        paginationKodeAbsen.CurrentPage = 1


        '========================================
        ' LOAD ULANG DATA
        '========================================
        DataKodeABsen()

    End Sub


End Class
