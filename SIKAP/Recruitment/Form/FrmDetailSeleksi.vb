Imports System.Data
Imports System.Windows.Forms.LinkLabel
Imports MySql.Data.MySqlClient
Public Class FrmDetailSeleksi
    Private _idKandidat As Long = 0
    Private _idRekrutmen As Long = 0
    Private _idProsesTerpilih As Long = 0
    Public Property IdKandidat As Long
        Get
            Return _idKandidat
        End Get
        Set(value As Long)
            _idKandidat = value
        End Set
    End Property

    Public Property IdRekrutmen As Long
        Get
            Return _idRekrutmen
        End Get
        Set(value As Long)
            _idRekrutmen = value
        End Set
    End Property
#Region "Private"
    Private Sub LoadKandidat()
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "SELECT ffcnokandidat, ffcnama, ffcnik, ffcnotelp,ffcemail FROM sakandidat WHERE ffcidkandidat = @idkandidat LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat
                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then
                            lNoKandidat.Text = If(IsDBNull(rd("ffcnokandidat")), "-", rd("ffcnokandidat").ToString())
                            lNamaKandidat.Text = If(IsDBNull(rd("ffcnama")), "-", rd("ffcnama").ToString())
                            lNikKandidat.Text = If(IsDBNull(rd("ffcnik")), "-", rd("ffcnik").ToString())
                            lNoHp.Text = If(IsDBNull(rd("ffcnotelp")), "-", rd("ffcnotelp").ToString())
                            lEmail.Text = If(IsDBNull(rd("ffcemail")), "-", rd("ffcemail").ToString())
                        Else
                            PesanPopupPeringatan("Peringatan", "Data kandidat tidak ditemukan.")
                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil data kandidat." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub LoadRecruitment()

        Try

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT r.ffcidrekrutmen, r.ffcidpermintaan, r.ffcstatus, r.ffdapply, p.ffcnopermintaan, p.ffckddepart, " &
                        "p.ffckdbagian, p.ffckdjabatan FROM sakandidatrekrutmen r INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE r.ffcidrekrutmen = @idrekrutmen AND r.ffcidkandidat = @idkandidat LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then
                            lNoRecruitment.Text = rd("ffcidrekrutmen").ToString()
                            lNoPermintaan.Text = If(IsDBNull(rd("ffcnopermintaan")), "-", rd("ffcnopermintaan").ToString())
                            lDepartment.Text = If(IsDBNull(rd("ffckddepart")), "-", rd("ffckddepart").ToString())
                            lBagian.Text = If(IsDBNull(rd("ffckdbagian")), "-", rd("ffckdbagian").ToString())
                            lJabatan.Text = If(IsDBNull(rd("ffckdjabatan")), "-", rd("ffckdjabatan").ToString())

                            If Not IsDBNull(rd("ffdapply")) Then
                                Dim tanggalApply As DateTime = Convert.ToDateTime(rd("ffdapply"))
                                lTanggalApply.Text =
                                    tanggalApply.ToString("dd/MM/yyyy HH:mm")
                            Else
                                lTanggalApply.Text = "-"
                            End If

                            If Not IsDBNull(rd("ffcstatus")) Then
                                lStatusRecruitment.Text = rd("ffcstatus").ToString()
                            Else
                                lStatusRecruitment.Text = "-"
                            End If

                        Else
                            PesanPopupPeringatan("Peringatan", "Data recruitment tidak ditemukan.")
                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil data recruitment." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SetupGridRiwayat()

        dgvRiwayatSeleksi.DataSource = Nothing
        dgvRiwayatSeleksi.Columns.Clear()

        dgvRiwayatSeleksi.AutoGenerateColumns = False
        dgvRiwayatSeleksi.AllowUserToAddRows = False
        dgvRiwayatSeleksi.AllowUserToDeleteRows = False
        dgvRiwayatSeleksi.ReadOnly = True
        dgvRiwayatSeleksi.MultiSelect = False
        dgvRiwayatSeleksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ApplyGridTheme(dgvRiwayatSeleksi)

        Dim colId As New DataGridViewTextBoxColumn()

        colId.Name = "ffcidproses"
        colId.HeaderText = "ID"
        colId.DataPropertyName = "ffcidproses"
        colId.Visible = False

        dgvRiwayatSeleksi.Columns.Add(colId)

        dgvRiwayatSeleksi.Columns.Add("ffctahap", "Tahap")
        dgvRiwayatSeleksi.Columns("ffctahap").DataPropertyName = "ffctahap"
        dgvRiwayatSeleksi.Columns.Add("ffdjadwal", "Jadwal")
        dgvRiwayatSeleksi.Columns("ffdjadwal").DataPropertyName = "ffdjadwal"
        dgvRiwayatSeleksi.Columns.Add("ffdproses", "Tanggal Proses")
        dgvRiwayatSeleksi.Columns("ffdproses").DataPropertyName = "ffdproses"
        dgvRiwayatSeleksi.Columns.Add("ffcstatus", "Status")
        dgvRiwayatSeleksi.Columns("ffcstatus").DataPropertyName = "ffcstatus"
        dgvRiwayatSeleksi.Columns.Add("ffcinterviewer", "Interviewer")
        dgvRiwayatSeleksi.Columns("ffcinterviewer").DataPropertyName = "ffcinterviewer"
        dgvRiwayatSeleksi.Columns.Add("ffcnilai", "Nilai")
        dgvRiwayatSeleksi.Columns("ffcnilai").DataPropertyName = "ffcnilai"
        dgvRiwayatSeleksi.Columns.Add("ffchasil", "Hasil")
        dgvRiwayatSeleksi.Columns("ffchasil").DataPropertyName = "ffchasil"
        dgvRiwayatSeleksi.Columns.Add("ffccatatan", "Catatan")
        dgvRiwayatSeleksi.Columns("ffccatatan").DataPropertyName = "ffccatatan"

    End Sub
    Private Sub LoadRiwayatSeleksi()

        Try

            Dim dt As New DataTable()

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                Dim sql As String = "SELECT ffcidproses,ffctahap, ffdjadwal,ffdproses, ffcstatus,ffcinterviewer, ffcnilai,ffchasil,ffccatatan FROM saprosesseleksi " &
                    "WHERE ffcidrekrutmen = @idrekrutmen AND ffcidkandidat = @idkandidat ORDER BY CASE WHEN ffdjadwal IS NULL THEN 1 ELSE 0 END, ffdjadwal ASC, ffcidproses ASC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@idrekrutmen", MySqlDbType.Int64).Value = _idRekrutmen
                    cmd.Parameters.Add("@idkandidat", MySqlDbType.Int64).Value = _idKandidat
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            dgvRiwayatSeleksi.DataSource = Nothing
            dgvRiwayatSeleksi.DataSource = dt

            If dgvRiwayatSeleksi.Rows.Count > 0 Then
                dgvRiwayatSeleksi.ClearSelection()
            End If

        Catch ex As Exception
            PesanPopupError("Error", "Gagal mengambil riwayat seleksi." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub ResetDetailProses()

        lDetailTahap.Text = "-"
        lDetailStatus.Text = "-"
        lDetailJadwal.Text = "-"
        lDetailProses.Text = "-"
        lDetailInterviewer.Text = "-"
        lDetailNilai.Text = "-"
        lDetailHasil.Text = "-"

        tDetailCatatan.ResetText()

    End Sub
    Private Sub ResetProsesTerpilih()

        _idProsesTerpilih = 0

        bEditProses.Enabled = False

    End Sub
#End Region
    Private Sub frmDetailSeleksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            If _idKandidat <= 0 Then
                PesanPopupPeringatan("Peringatan", "Data kandidat belum ditentukan.")
                Return
            End If

            If _idRekrutmen <= 0 Then
                PesanPopupPeringatan("Peringatan", "Data recruitment belum ditentukan.")
                Return

            End If
            ResetDetailProses()
            SetupGridRiwayat()
            LoadKandidat()
            LoadRecruitment()
            LoadRiwayatSeleksi()
            ResetProsesTerpilih()
        Catch ex As Exception
            PesanPopupError("Error", "Gagal membuka detail seleksi." & vbCrLf & ex.Message)

        End Try

    End Sub
    Private Sub dgvRiwayatSeleksi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRiwayatSeleksi.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        Dim row As DataGridViewRow = dgvRiwayatSeleksi.Rows(e.RowIndex)

        '==========================================================
        ' ID PROSES
        '==========================================================
        If row.Cells("ffcidproses").Value IsNot Nothing AndAlso
       Not IsDBNull(row.Cells("ffcidproses").Value) Then

            _idProsesTerpilih =
            Convert.ToInt64(row.Cells("ffcidproses").Value)

            bEditProses.Enabled = True

        Else

            _idProsesTerpilih = 0
            bEditProses.Enabled = False

        End If


        If row.Cells("ffctahap").Value IsNot Nothing Then
            lDetailTahap.Text = row.Cells("ffctahap").Value.ToString()
        Else
            lDetailTahap.Text = "-"
        End If

        If row.Cells("ffcstatus").Value IsNot Nothing Then
            lDetailStatus.Text = row.Cells("ffcstatus").Value.ToString()
        Else
            lDetailStatus.Text = "-"
        End If

        If row.Cells("ffdjadwal").Value IsNot Nothing AndAlso
           Not IsDBNull(row.Cells("ffdjadwal").Value) Then

            lDetailJadwal.Text = Convert.ToDateTime(row.Cells("ffdjadwal").Value).ToString("dd/MM/yyyy HH:mm")
        Else
            lDetailJadwal.Text = "-"

        End If

        If row.Cells("ffdproses").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffdproses").Value) Then
            lDetailProses.Text = Convert.ToDateTime(row.Cells("ffdproses").Value).ToString("dd/MM/yyyy HH:mm")
        Else
            lDetailProses.Text = "-"

        End If

        If row.Cells("ffcinterviewer").Value IsNot Nothing Then
            lDetailInterviewer.Text = row.Cells("ffcinterviewer").Value.ToString()
        Else
            lDetailInterviewer.Text = "-"
        End If

        If row.Cells("ffcnilai").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("ffcnilai").Value) Then
            lDetailNilai.Text = Convert.ToDecimal(row.Cells("ffcnilai").Value).ToString("0.00")
        Else
            lDetailNilai.Text = "-"
        End If

        If row.Cells("ffchasil").Value IsNot Nothing Then
            lDetailHasil.Text = row.Cells("ffchasil").Value.ToString()
        Else
            lDetailHasil.Text = "-"
        End If

        If row.Cells("ffccatatan").Value IsNot Nothing Then
            tDetailCatatan.Text = row.Cells("ffccatatan").Value.ToString()
        Else
            tDetailCatatan.Text = ""
        End If

    End Sub
    Private Sub bEditProses_Click(sender As Object, e As EventArgs) Handles bEditProses.Click

        If _idProsesTerpilih <= 0 Then
            PesanPopupPeringatan("Peringatan", "Silakan pilih proses seleksi yang akan diedit.")

            Return

        End If

        Using frm As New frmProsesSeleksi()

            frm.IdKandidat = _idKandidat
            frm.IdRekrutmen = _idRekrutmen
            frm.IdProses = _idProsesTerpilih
            frm.ModeForm = "Edit"

            frm.ShowDialog()

        End Using
        LoadRiwayatSeleksi()
        ResetDetailProses()
        ResetProsesTerpilih()
    End Sub
    Private Sub bSimpan_Click(sender As Object, e As EventArgs) Handles bSimpan.Click
        Me.Close()
    End Sub
End Class