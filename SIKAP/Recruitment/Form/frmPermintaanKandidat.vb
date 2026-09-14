Imports Guna.UI2.WinForms.Suite
Imports MySql.Data.MySqlClient

Public Class frmPermintaanKandidat
    Private ReadOnly _idPermintaan As Long
    Private _idRekrutmenTerpilih As Long = 0
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
    Public Sub New(idPermintaan As Long)

        InitializeComponent()

        _idPermintaan = idPermintaan

    End Sub
#Region "Private"
    Private Sub LoadDataPermintaan()

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT a.ffcnopermintaan AS `No Permintaan`, a.ffckddepart AS `Kode Depart`,b.ffcnama AS `Nama Department`,a.ffckdbagian AS `Kode Bagian` ,c.ffcnama AS `Nama Bagian`, " &
                "a.ffckdjabatan AS `Kode Jabatan` ,d.ffcnama AS `Jabatan`, a.ffnjumlah as `Jumlah`, a.ffcstatus FROM sapermintaankaryawan a " &
                "LEFT JOIN sadepartment b ON a.ffckddepart = b.ffckode LEFT JOIN sabagian c ON a.ffckdbagian = c.ffcbag LEFT JOIN sajabatan d ON a.ffckdjabatan = d.ffckls  WHERE ffcidpermintaan = @ID"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@ID", _idPermintaan
                    )

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then

                            'Sesuaikan nama control
                            'dengan Designer Anda

                            lblNoPermintaan.Text = If(IsDBNull(rd("No Permintaan")), "", rd("No Permintaan").ToString())

                            lblDepartment.Text = If(IsDBNull(rd("Nama Department")), "", rd("Nama Department").ToString())

                            lblBagian.Text = If(IsDBNull(rd("Nama Bagian")), "", rd("Nama Bagian").ToString())

                            lblJabatan.Text = If(IsDBNull(rd("Jabatan")), "", rd("Jabatan").ToString())

                            lblJumlah.Text = If(IsDBNull(rd("Jumlah")), "0", rd("Jumlah").ToString())

                            ' lblStatus.Text = If(IsDBNull(rd("ffcstatus")), "", rd("ffcstatus").ToString())

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memuat data permintaan." & Environment.NewLine & ex.Message)

        End Try

    End Sub
    Private Sub LoadKandidat()

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT r.ffcidrekrutmen, r.ffcidkandidat, k.ffcnokandidat, k.ffcnama, k.ffcnik, k.ffcnotelp, k.ffcemail, " &
                    "r.ffcstatus, r.ffdapply, r.ffcketerangan FROM sakandidatrekrutmen r INNER JOIN sakandidat k ON k.ffcidkandidat = r.ffcidkandidat " &
                    "WHERE r.ffcidpermintaan = @ID ORDER BY r.ffdapply DESC"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@ID", _idPermintaan
                    )

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)

                        da.Fill(dt)

                    End Using

                    dgvPermintaanKandidat.DataSource = dt

                End Using

            End Using

            SetupGridKandidat()

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal memuat data kandidat." & Environment.NewLine & ex.Message)

        End Try

    End Sub
    Private Sub SetupGridKandidat()

        If dgvPermintaanKandidat.Columns.Count = 0 Then
            Return
        End If

        '========================================
        ' HIDDEN COLUMN
        '========================================

        If dgvPermintaanKandidat.Columns.Contains("ffcidrekrutmen") Then
            dgvPermintaanKandidat.Columns("ffcidrekrutmen").Visible = False
        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcidkandidat") Then
            dgvPermintaanKandidat.Columns("ffcidkandidat").Visible = False
        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcnik") Then
            dgvPermintaanKandidat.Columns("ffcnik").Visible = False
        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcnotelp") Then
            dgvPermintaanKandidat.Columns("ffcnotelp").Visible = False
        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcemail") Then
            dgvPermintaanKandidat.Columns("ffcemail").Visible = False
        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcketerangan") Then
            dgvPermintaanKandidat.Columns("ffcketerangan").Visible = False
        End If

        '========================================
        ' HEADER
        '========================================

        If dgvPermintaanKandidat.Columns.Contains("ffcnokandidat") Then

            dgvPermintaanKandidat.Columns("ffcnokandidat").
                HeaderText = "No. Kandidat"

        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcnama") Then

            dgvPermintaanKandidat.Columns("ffcnama").
                HeaderText = "Nama Kandidat"

        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcstatus") Then

            dgvPermintaanKandidat.Columns("ffcstatus").
                HeaderText = "Status"

        End If

        If dgvPermintaanKandidat.Columns.Contains("ffdapply") Then

            dgvPermintaanKandidat.Columns("ffdapply").
                HeaderText = "Tanggal Apply"

        End If

        '========================================
        ' ALIGNMENT
        '========================================

        If dgvPermintaanKandidat.Columns.Contains("ffcnokandidat") Then
            dgvPermintaanKandidat.Columns("ffcnokandidat").
                DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter
        End If

        If dgvPermintaanKandidat.Columns.Contains("ffcstatus") Then
            dgvPermintaanKandidat.Columns("ffcstatus").
                DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter
        End If

    End Sub
    Private Sub dgvPermintaanKandidat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPermintaanKandidat.CellClick
        If e.RowIndex < 0 Then
            _idRekrutmenTerpilih = 0
            Return
        End If

        Dim value As Object =
        dgvPermintaanKandidat.Rows(e.RowIndex).Cells("ffcidrekrutmen").Value

        If value Is Nothing OrElse IsDBNull(value) Then
            _idRekrutmenTerpilih = 0
            Return
        End If

        Long.TryParse(value.ToString(), _idRekrutmenTerpilih)

    End Sub
    Private Sub frmPermintaanKandidat_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShadowForm.SetShadowForm(Me)
        LoadDataPermintaan()

        LoadKandidat()
    End Sub

    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click
        Me.Close()
    End Sub

    Private Sub bTambahKandidat_Click(sender As Object, e As EventArgs) Handles bTambahKandidat.Click
        Using frm As New frmPilihKandidat(_idPermintaan)

            If frm.ShowDialog(Me) = DialogResult.OK Then

                LoadKandidat()

            End If

        End Using
    End Sub

    Private Sub bHapusKandidat_Click(sender As Object, e As EventArgs) Handles bHapusKandidat.Click
        If _idRekrutmenTerpilih <= 0 Then
            PesanPopupPeringatan("PERINGATAN", "Silakan pilih kandidat yang akan dihapus.")
            Return

        End If

        If MessageBox.Show("Apakah kandidat ini akan dilepas dari permintaan?" &
            Environment.NewLine & Environment.NewLine & "Data kandidat tetap tersimpan sebagai master kandidat.",
            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return

        End If

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "DELETE FROM sakandidatrekrutmen WHERE ffcidrekrutmen = @ID"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@ID", _idRekrutmenTerpilih)
                    cmd.ExecuteNonQuery()

                End Using

            End Using

            _idRekrutmenTerpilih = 0

            PesanPopupSukses("SUKSES", "Kandidat berhasil dilepas dari permintaan.")

            LoadKandidat()

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal menghapus kandidat." & Environment.NewLine & ex.Message)

        End Try
    End Sub
#End Region
End Class