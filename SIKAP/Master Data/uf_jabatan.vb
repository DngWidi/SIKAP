Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Public Class uf_jabatan
    Private _keywordCari As String = ""
    Private Sub DataJabatan()

        Try
            '========================================
            ' 1. HITUNG TOTAL RECORD
            '========================================
            paginationJabatan.TotalRecord = GetTotalRecord()



            '========================================
            ' 2. PASTIKAN CURRENT PAGE VALID
            '========================================

            If paginationJabatan.CurrentPage > paginationJabatan.TotalPage Then

                paginationJabatan.CurrentPage = paginationJabatan.TotalPage

            End If


            If paginationJabatan.CurrentPage < 1 Then

                paginationJabatan.CurrentPage = 1

            End If
            '========================================
            ' 3. LOAD DATA
            '========================================


            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffckls AS `Kode`,ffcnama As `Nama Jabatan` FROM sajabatan WHERE ffckls LIKE @Cari OR ffcnama LIKE @Cari ORDER BY ffckls LIMIT @Limit OFFSET @Offset"

                Using cmd As New MySqlCommand(sql, conn)
                    '========================================
                    ' PARAMETER PENCARIAN
                    '========================================
                    cmd.Parameters.Add("@Cari", MySqlDbType.VarChar).Value = "%" & _keywordCari & "%"
                    cmd.Parameters.Add("@Limit", MySqlDbType.Int32).Value = paginationJabatan.PageSize

                    cmd.Parameters.Add("@Offset", MySqlDbType.Int32).Value = paginationJabatan.Offset


                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using


                    dgvJabatan.DataSource = dt

                End Using

            End Using

            UpdatePaginationInfo()

        Catch ex As Exception

            PesanPopupError("Error", "Gagal memuat data jabatan !!" & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub UpdatePaginationInfo()

        lblInfo.Text = String.Format("Menampilkan {0} - {1} dari {2} Data", paginationJabatan.StartRecord, paginationJabatan.EndRecord, paginationJabatan.TotalRecord)

    End Sub
    Private Sub paginationJabatan_PageChanged(sender As Object, e As EventArgs) Handles paginationJabatan.PageChanged
        DataJabatan()
    End Sub


    Private Function GetTotalRecord() As Integer
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim mysql As String = "SELECT COUNT(*) FROM sajabatan  WHERE ffckls LIKE @Cari  OR ffcnama LIKE @Cari"
                Using comm As New MySqlCommand(mysql, conn)
                    comm.Parameters.Add("@Cari", MySqlDbType.VarChar).Value = "%" & _keywordCari & "%"
                    Return Convert.ToInt32(comm.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil jumlah data jabatan !!")
            Return 0
        End Try

    End Function
    Private Sub uf_jabatan_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Style Grid
        ApplyGridTheme(dgvJabatan)


        ' Load Data
        DataJabatan()
    End Sub
    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Using frm As New frmJabatanAdd()

            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then

                DataJabatan()

            End If

        End Using
    End Sub

    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click

        '========================================
        ' CEK APAKAH ADA DATA YANG DIPILIH
        '========================================
        If dgvJabatan.CurrentRow Is Nothing Then

            PesanPopupPeringatan("Pilih Jabatan", "Silakan pilih jabatan yang ingin diedit.")

            Exit Sub

        End If


        '========================================
        ' AMBIL DATA DARI ROW TERPILIH
        '========================================
        Dim kode As String =
        dgvJabatan.CurrentRow.Cells("Kode").Value.ToString()

        Dim nama As String =
        dgvJabatan.CurrentRow.Cells("Nama Jabatan").Value.ToString()


        '========================================
        ' BUKA FORM EDIT
        '========================================
        Using frm As New frmJabatanAdd()

            frm.ModeEdit = True
            frm.KodeLama = kode

            frm.tkode.Text = kode
            frm.tNama.Text = nama


            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then

                DataJabatan()

            End If

        End Using

    End Sub

    Private Sub bHapus_Click(sender As Object, e As EventArgs) Handles bHapus.Click
        '========================================
        ' CEK DATA YANG DIPILIH
        '========================================
        If dgvJabatan.CurrentRow Is Nothing Then

            PesanPopupPeringatan("Pilih Jabatan", "Silakan pilih jabatan yang ingin dihapus.")

            Exit Sub

        End If


        '========================================
        ' AMBIL DATA
        '========================================
        Dim kode As String =
            dgvJabatan.CurrentRow.Cells("Kode").Value.ToString()

        Dim nama As String =
            dgvJabatan.CurrentRow.Cells("Nama Jabatan").Value.ToString()


        '========================================
        ' KONFIRMASI
        '========================================
        Dim hasil As DialogResult =
            PesanPopupKonfirmasi("Hapus Jabatan", "Apakah Anda yakin ingin menghapus jabatan berikut?" & vbCrLf & vbCrLf & "Kode : " & kode & vbCrLf & "Nama : " & nama)


        If hasil <> DialogResult.Yes Then

            Exit Sub

        End If


        '========================================
        ' DELETE DATABASE
        '========================================
        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "DELETE FROM sajabatan WHERE ffckls = @Kode"

                Using comm As New MySqlCommand(sql, conn)

                    comm.Parameters.Add("@Kode", MySqlDbType.VarChar).Value = kode

                    comm.ExecuteNonQuery()

                End Using

            End Using


            '========================================
            ' PESAN SUKSES
            '========================================
            PesanPopupSukses("Sukses", "Jabatan berhasil dihapus.")


            '========================================
            ' REFRESH DATA
            '========================================
            DataJabatan()


        Catch ex As MySqlException

            PesanPopupError("Error", "Gagal menghapus jabatan !!" & vbCrLf & ex.Message)

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
        paginationJabatan.CurrentPage = 1


        '========================================
        ' LOAD DATA HASIL PENCARIAN
        '========================================
        DataJabatan()

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
        paginationJabatan.CurrentPage = 1


        '========================================
        ' LOAD ULANG DATA
        '========================================
        DataJabatan()

    End Sub


End Class
