Imports Guna.UI2.WinForms.Suite
Imports MySql.Data.MySqlClient
Public Class frmPilihKandidat
    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()
    Private ReadOnly _idPermintaan As Long
    Private _idKandidatTerpilih As Long = 0
    Private _idRekrutmenTerpilih As Long = 0
    Public Sub New(idPermintaan As Long)

        InitializeComponent()

        _idPermintaan = idPermintaan

    End Sub
    Private Sub LoadKandidat(Optional keyword As String = "")

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT " &
                "k.ffcidkandidat, k.ffcnokandidat, k.ffcnama, " &
                "k.ffcnik, k.ffcnotelp, k.ffcemail FROM sakandidat k WHERE k.ffcstatus = 'ACTIVE' " &
                "And Not EXISTS (SELECT 1 FROM sakandidatrekrutmen r  WHERE r.ffcidkandidat = k.ffcidkandidat " &
                " AND r.ffcidpermintaan = @IDPermintaan ) "

                If keyword <> "" Then

                    sql &= "AND (k.ffcnokandidat LIKE @Keyword OR k.ffcnama LIKE @Keyword " &
                       "OR k.ffcnik LIKE @Keyword ) "

                End If

                sql &= "ORDER BY k.ffcnama"

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@IDPermintaan", _idPermintaan)
                    If keyword <> "" Then
                        cmd.Parameters.AddWithValue("@Keyword", "%" & keyword & "%")
                    End If
                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    dgvKandidat.DataSource = dt
                End Using
            End Using

            SetupGridKandidat()

            _idKandidatTerpilih = 0

        Catch ex As Exception

            PesanPopupError("ERROR", "Gagal mencari kandidat." & Environment.NewLine & ex.Message)

        End Try

    End Sub
    Private Sub SetupGridKandidat()

        If dgvKandidat.Columns.Count = 0 Then
            Return
        End If
        ' MATIKAN AutoSizeColumnsMode AGAR NILAI .Width BEKERJA
        dgvKandidat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        '========================================
        ' HIDDEN ID
        '========================================

        If dgvKandidat.Columns.Contains("ffcidkandidat") Then
            dgvKandidat.Columns("ffcidkandidat").Visible = False
        End If

        '========================================
        ' HEADER
        '========================================

        If dgvKandidat.Columns.Contains("ffcnokandidat") Then

            With dgvKandidat.Columns("ffcnokandidat")
                .HeaderText = "No. Kandidat"
                .Width = 150
            End With

        End If
        If dgvKandidat.Columns.Contains("ffcnama") Then

            With dgvKandidat.Columns("ffcnama")
                .HeaderText = "Nama Kandidat"
                .Width = 220

            End With

        End If

        If dgvKandidat.Columns.Contains("ffcnik") Then
            With dgvKandidat.Columns("ffcnik")
                .HeaderText = "NIK"
                .Width = 150
            End With
        End If

        If dgvKandidat.Columns.Contains("ffcnotelp") Then
            With dgvKandidat.Columns("ffcnotelp")
                .HeaderText = "No. HP"
                .Width = 130
            End With

        End If

        If dgvKandidat.Columns.Contains("ffcemail") Then
            With dgvKandidat.Columns("ffcemail")
                .HeaderText = "Email"
                .Width = 220
            End With

        End If

        '========================================
        ' ALIGNMENT
        '========================================

        If dgvKandidat.Columns.Contains("ffcnokandidat") Then
            dgvKandidat.Columns("ffcnokandidat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If dgvKandidat.Columns.Contains("ffcnik") Then
            dgvKandidat.Columns("ffcnik").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

    End Sub
    Private Sub SimpanKandidat()

        If _idKandidatTerpilih <= 0 Then
            PesanPopupPeringatan("PERINGATAN", "Silakan pilih kandidat terlebih dahulu.")
            Return

        End If

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                '========================================
                ' CEK DUPLIKAT
                '========================================

                Dim sqlCek As String = "SELECT COUNT(*) FROM sakandidatrekrutmen " &
                "WHERE ffcidkandidat = @IDKandidat AND ffcidpermintaan = @IDPermintaan"

                Using cmdCek As New MySqlCommand(sqlCek, conn)
                    cmdCek.Parameters.AddWithValue("@IDKandidat", _idKandidatTerpilih)
                    cmdCek.Parameters.AddWithValue("@IDPermintaan", _idPermintaan)
                    Dim jumlah As Integer = Convert.ToInt32(cmdCek.ExecuteScalar())

                    If jumlah > 0 Then
                        PesanPopupPeringatan("PERINGATAN", "Kandidat tersebut sudah terdaftar " & "pada permintaan ini.")
                        Return
                    End If

                End Using

                '========================================
                ' INSERT
                '========================================

                Dim sql As String = "INSERT INTO sakandidatrekrutmen (ffcidkandidat, " &
                "ffcidpermintaan, ffcstatus, ffdapply,ffcusercreate, ffdcreate) VALUES (@IDKandidat, " &
                "@IDPermintaan, 'SCREENING', NOW(), @UserCreate, NOW())"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@IDKandidat", _idKandidatTerpilih)
                    cmd.Parameters.AddWithValue("@IDPermintaan", _idPermintaan)
                    cmd.Parameters.AddWithValue("@UserCreate", Environment.UserName)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            PesanPopupSukses("SUKSES", "Kandidat berhasil ditambahkan ke permintaan.")
            DialogResult = DialogResult.OK
            Close()

        Catch ex As MySqlException
            If ex.Number = 1062 Then
                PesanPopupPeringatan("PERINGATAN", "Kandidat tersebut sudah terdaftar " & "pada permintaan ini.")
            Else
                PesanPopupError("ERROR", "Gagal menambahkan kandidat." & Environment.NewLine & ex.Message)
            End If

        Catch ex As Exception
            PesanPopupError("ERROR", "Gagal menambahkan kandidat." & Environment.NewLine & ex.Message)
        End Try

    End Sub

    Private Sub frmPilihKandidat_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShadowForm.SetShadowForm(Me)
        LoadKandidat()
    End Sub
    Private Sub dgvKandidat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKandidat.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim value As Object = dgvKandidat.Rows(e.RowIndex).Cells("ffcidkandidat").Value
        If value Is Nothing OrElse
           IsDBNull(value) Then
            _idKandidatTerpilih = 0
            Return
        End If
        Long.TryParse(value.ToString(), _idKandidatTerpilih)

    End Sub
    Private Sub dgvKandidat_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKandidat.CellDoubleClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim value As Object = dgvKandidat.Rows(e.RowIndex).Cells("ffcidkandidat").Value
        If value Is Nothing OrElse
           IsDBNull(value) Then
            Return
        End If

        If Not Long.TryParse(value.ToString(), _idKandidatTerpilih) Then
            Return
        End If

        SimpanKandidat()

    End Sub

    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        SimpanKandidat()
    End Sub

    Private Sub bTutup_Click(sender As Object, e As EventArgs) Handles bTutup.Click
        DialogResult = DialogResult.Cancel

        Close()
    End Sub
    Private Sub tPencarian_TextChanged(sender As Object, e As EventArgs) Handles tPencarian.TextChanged
        LoadKandidat(tPencarian.Text.Trim())
    End Sub
End Class