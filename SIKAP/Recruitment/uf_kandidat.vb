Imports MySql.Data.MySqlClient

Public Class uf_kandidat
    ' Private _idKandidatTerpilih As Long = 0
    ' Private _noKandidatTerpilih As String = ""
    '  Private _namaKandidatTerpilih As String = ""
    '  Private _statusTerpilih As String = ""

#Region "Function"
    Private Function GetTotalRecord() As Integer
        Try
            Dim sql As String = "SELECT COUNT(*) FROM sakandidat "
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            PesanPopupError("Error", "Gagal menghitung jumlah kandidat." & vbCrLf & ex.Message)
            Return 0
        End Try
    End Function
#End Region
#Region "Private"
    Private Sub DataKandidat()
        Try
            paginationKandidat.TotalRecord = GetTotalRecord()

            If paginationKandidat.CurrentPage > paginationKandidat.TotalPage Then
                paginationKandidat.CurrentPage = paginationKandidat.TotalPage
            End If

            If paginationKandidat.CurrentPage < 1 Then
                paginationKandidat.CurrentPage = 1
            End If


            '========================================
            ' 3. QUERY DATA
            '========================================
            Dim sql As String = "SELECT ffcidkandidat,ffcnokandidat AS `No Kandidat`,ffcnama AS `Nama`,ffdtgllahir `Tanggal Lahir`,ffcjeniskelamin AS `Jenis Kelamin`,ffcnik AS `Nik`,ffcnotelp AS `Telp`," &
            "ffcemail AS `Email`,ffcsumberkandidat AS `Sumber`,ffcstatus AS `Status`FROM sakandidat ORDER BY ffcidkandidat DESC LIMIT @Limit OFFSET @Offset "


            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@Limit", paginationKandidat.PageSize)
                    cmd.Parameters.AddWithValue("@Offset", paginationKandidat.Offset)
                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using


                    dgvKandidat.DataSource = dt
                    If dgvKandidat.Columns.Contains("ffcidkandidat") Then
                        dgvKandidat.Columns("ffcidkandidat").Visible = False
                    End If
                End Using

            End Using

            UpdatePaginationInfo()
            '   ResetKandidatTerpilih()

        Catch ex As Exception
            PesanPopupError("Error", "Gagal memuat data kandidat." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub UpdatePaginationInfo()
        lblInfo.Text = String.Format("Menampilkan {0} - {1} dari {2} Data", paginationKandidat.StartRecord, paginationKandidat.EndRecord, paginationKandidat.TotalRecord)
    End Sub
    '  Private Sub ResetKandidatTerpilih()
    '    _idKandidatTerpilih = 0
    '    _noKandidatTerpilih = ""
    '    _namaKandidatTerpilih = ""
    '    _statusTerpilih = ""
    '  End Sub
    Private Sub paginationKandidat_PageChanged(sender As Object, e As EventArgs) Handles paginationKandidat.PageChanged
        DataKandidat()
    End Sub
    Private Sub uf_kandidat_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Style Grid
        ApplyGridTheme(dgvKandidat)
        ' Load Data
        DataKandidat()
    End Sub
    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Using frm As New frmKandidatAdd()
            frm.Mode = frmKandidatAdd.ModeForm.Tambah
            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                DataKandidat()
            End If
        End Using
    End Sub
    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click

        '========================================
        ' VALIDASI PILIHAN
        '========================================
        If dgvKandidat.CurrentRow Is Nothing Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat yang ingin diedit.")
            Return
        End If

        Dim idKandidat As Long = Convert.ToInt64(dgvKandidat.CurrentRow.Cells("ffcidkandidat").Value)

        '========================================
        ' BUKA FORM EDIT
        '========================================
        Using frm As New frmKandidatAdd()
            frm.Mode = frmKandidatAdd.ModeForm.Edit
            frm.IdKandidat = idKandidat
            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                DataKandidat()
            End If
        End Using

    End Sub

    Private Sub bHapus_Click(sender As Object, e As EventArgs) Handles bHapus.Click

        '========================================
        ' VALIDASI PILIHAN
        '========================================
        If dgvKandidat.CurrentRow Is Nothing Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih kandidat yang ingin dinonaktifkan.")
            Return
        End If

        Dim idKandidat As Long = Convert.ToInt64(dgvKandidat.CurrentRow.Cells("ffcidkandidat").Value)
        Dim namaKandidat As String = Convert.ToString(dgvKandidat.CurrentRow.Cells("Nama").Value)
        Dim statusKandidat As String = Convert.ToString(dgvKandidat.CurrentRow.Cells("Status").Value)

        '========================================
        ' VALIDASI STATUS
        '========================================
        If statusKandidat.ToUpper() = "INACTIVE" Then
            PesanPopupPeringatan("Peringatan", "Kandidat tersebut sudah berstatus INACTIVE.")
            Return
        End If

        '========================================
        ' KONFIRMASI
        '========================================
        Dim hasil As DialogResult = PesanPopupKonfirmasi("Konfirmasi", "Apakah Anda yakin ingin menonaktifkan kandidat " & namaKandidat & "?")
        If hasil <> DialogResult.Yes Then
            Return
        End If

        Try
            Dim sql As String = "UPDATE sakandidat SET ffcstatus = 'INACTIVE',ffcuserupdate = @UserUpdate, ffdupdate = CURRENT_TIMESTAMP WHERE ffcidkandidat = @ID"

            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ID", idKandidat)
                    cmd.Parameters.AddWithValue("@UserUpdate", Environment.UserName)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            PesanPopupSukses("Berhasil", "Kandidat berhasil dinonaktifkan.")
            DataKandidat()
        Catch ex As Exception
            PesanPopupError("Error", "Gagal menonaktifkan kandidat." & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

End Class
