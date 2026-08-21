Imports MySql.Data.MySqlClient

Public Class uf_department

#Region "Private"

    Private Sub DataDepartment()

        Try
            '========================================
            ' 1. HITUNG TOTAL RECORD
            '========================================
            paginationDepartment.TotalRecord = GetTotalRecord()



            '========================================
            ' 2. PASTIKAN CURRENT PAGE VALID
            '========================================

            If paginationDepartment.CurrentPage > paginationDepartment.TotalPage Then

                paginationDepartment.CurrentPage = paginationDepartment.TotalPage

            End If


            If paginationDepartment.CurrentPage < 1 Then

                paginationDepartment.CurrentPage = 1

            End If
            '========================================
            ' 3. LOAD DATA
            '========================================


            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffckode AS `Kode`, ffcnama AS `Nama Department` FROM sadepartment ORDER BY ffckode LIMIT @Limit OFFSET @Offset"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.Add("@Limit", MySqlDbType.Int32).Value = paginationDepartment.PageSize

                    cmd.Parameters.Add("@Offset", MySqlDbType.Int32).Value =
                    paginationDepartment.Offset


                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using


                    dgvDepartment.DataSource = dt

                End Using

            End Using

            UpdatePaginationInfo()

        Catch ex As Exception

            PesanPopupError("Error", "Gagal memuat data department !!" & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub UpdatePaginationInfo()

        lblInfo.Text = String.Format("Menampilkan {0} - {1} dari {2} Data", paginationDepartment.StartRecord, paginationDepartment.EndRecord, paginationDepartment.TotalRecord)

    End Sub
    Private Sub paginationDepartment_PageChanged(sender As Object, e As EventArgs) Handles paginationDepartment.PageChanged

        DataDepartment()

    End Sub
    Private Function GetTotalRecord() As Integer
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim mysql As String = "SELECT COUNT(*) FROM sadepartment"
                Using comm As New MySqlCommand(mysql, conn)
                    Return Convert.ToInt32(comm.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil jumlah data department !!")
            Return 0
        End Try

    End Function

#End Region
    Private Sub uf_department_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Style Grid
        ApplyGridTheme(dgvDepartment)


        ' Load Data
        DataDepartment()
    End Sub

    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Using frm As New frmDepartmentAdd()

            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then

                DataDepartment()

            End If

        End Using
    End Sub

    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click

        '========================================
        ' CEK APAKAH ADA DATA YANG DIPILIH
        '========================================
        If dgvDepartment.CurrentRow Is Nothing Then

            PesanPopupPeringatan("Pilih Department", "Silakan pilih department yang ingin diedit.")

            Exit Sub

        End If


        '========================================
        ' AMBIL DATA DARI ROW TERPILIH
        '========================================
        Dim kode As String =
        dgvDepartment.CurrentRow.Cells("Kode").Value.ToString()

        Dim nama As String =
        dgvDepartment.CurrentRow.Cells("Nama Department").Value.ToString()


        '========================================
        ' BUKA FORM EDIT
        '========================================
        Using frm As New frmDepartmentAdd()

            frm.ModeEdit = True
            frm.KodeLama = kode

            frm.tkode.Text = kode
            frm.tNama.Text = nama


            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then

                DataDepartment()

            End If

        End Using

    End Sub

    Private Sub bHapus_Click(sender As Object, e As EventArgs) Handles bHapus.Click
        '========================================
        ' CEK DATA YANG DIPILIH
        '========================================
        If dgvDepartment.CurrentRow Is Nothing Then

            PesanPopupPeringatan("Pilih Department", "Silakan pilih department yang ingin dihapus.")

            Exit Sub

        End If


        '========================================
        ' AMBIL DATA
        '========================================
        Dim kode As String =
            dgvDepartment.CurrentRow.Cells("Kode").Value.ToString()

        Dim nama As String =
            dgvDepartment.CurrentRow.Cells("Nama Department").Value.ToString()


        '========================================
        ' KONFIRMASI
        '========================================
        Dim hasil As DialogResult =
            PesanPopupKonfirmasi("Hapus Department", "Apakah Anda yakin ingin menghapus department berikut?" & vbCrLf & vbCrLf & "Kode : " & kode & vbCrLf & "Nama : " & nama)


        If hasil <> DialogResult.Yes Then

            Exit Sub

        End If


        '========================================
        ' DELETE DATABASE
        '========================================
        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "DELETE FROM sadepartment WHERE ffckode = @Kode"

                Using comm As New MySqlCommand(sql, conn)

                    comm.Parameters.Add("@Kode", MySqlDbType.VarChar).Value = kode

                    comm.ExecuteNonQuery()

                End Using

            End Using


            '========================================
            ' PESAN SUKSES
            '========================================
            PesanPopupSukses("Sukses", "Department berhasil dihapus.")


            '========================================
            ' REFRESH DATA
            '========================================
            DataDepartment()


        Catch ex As MySqlException

            PesanPopupError("Error", "Gagal menghapus department !!" & vbCrLf & ex.Message)

        Catch ex As Exception

            PesanPopupError("Error", "Terjadi kesalahan !!" & vbCrLf & ex.Message)

        End Try
    End Sub
End Class
