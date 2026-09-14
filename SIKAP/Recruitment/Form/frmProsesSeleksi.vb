Imports System.Windows.Forms.LinkLabel
Imports MySql.Data.MySqlClient

Public Class frmProsesSeleksi
    Private _idKandidat As Long = 0
    Private _idRekrutmen As Long = 0
    Private _idProses As Long = 0

    Private _mode As String = "Tambah"
    Public Property TahapAwal As String
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

    Private Sub SetupComboBox()

        '========================================
        ' TAHAP SELEKSI
        '========================================
        cTahap.Items.Clear()

        cTahap.Items.Add("SCREENING")
        cTahap.Items.Add("INTERVIEW_HR")
        cTahap.Items.Add("INTERVIEW_USER")
        cTahap.Items.Add("TEST")
        cTahap.Items.Add("MEDICAL_CHECK")
        cTahap.Items.Add("OFFERING")

        '========================================
        ' STATUS
        '========================================
        cStatus.Items.Clear()

        cStatus.Items.Add("WAITING")
        cStatus.Items.Add("SCHEDULED")
        cStatus.Items.Add("PROCESS")
        cStatus.Items.Add("PASSED")
        cStatus.Items.Add("FAILED")
        cStatus.Items.Add("CANCELLED")

        '========================================
        ' HASIL
        '========================================
        cHasil.Items.Clear()

        cHasil.Items.Add("LULUS")
        cHasil.Items.Add("TIDAK_LULUS")
        cHasil.Items.Add("DIREKOMENDASIKAN")
        cHasil.Items.Add("TIDAK_DIREKOMENDASIKAN")

    End Sub
    Private Sub LoadKandidat()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT ffcnokandidat,ffcnama,ffcnik,ffcnotelp,ffcemail FROM sakandidat WHERE ffcidkandidat = @idkandidat LIMIT 1 "
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            lNoKandidat.Text = If(IsDBNull(rd("ffcnokandidat")), "", rd("ffcnokandidat").ToString())
                            lNamaKandidat.Text = If(IsDBNull(rd("ffcnama")), "", rd("ffcnama").ToString())
                            lNikKandidat.Text = If(IsDBNull(rd("ffcnik")), "", rd("ffcnik").ToString())
                            lNoHp.Text = If(IsDBNull(rd("ffcnotelp")), "", rd("ffcnotelp").ToString())
                            lEmail.Text = If(IsDBNull(rd("ffcemail")), "", rd("ffcemail").ToString())
                        Else
                            PesanPopupPeringatan("Peringatan", "Data kandidat tidak ditemukan.")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                PesanPopupError("Error", "Gagal mengambil data kandidat." & vbCrLf & ex.Message)
            End Try
        End Using

    End Sub
    Private Sub LoadRecruitment()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try
                Dim sql As String = "SELECT r.ffcidrekrutmen,r.ffcidpermintaan,p.ffcnopermintaan,p.ffckddepart,p.ffckdbagian,p.ffckdjabatan FROM sakandidatrekrutmen r " &
                    "INNER JOIN sapermintaankaryawan p ON p.ffcidpermintaan = r.ffcidpermintaan WHERE r.ffcidrekrutmen = @idrekrutmen AND r.ffcidkandidat = @idkandidat LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        If rd.Read() Then
                            lNoPermintaan.Text = If(IsDBNull(rd("ffcnopermintaan")), "", rd("ffcnopermintaan").ToString())
                            lDepartment.Text = If(IsDBNull(rd("ffckddepart")), "", rd("ffckddepart").ToString())
                            lBagian.Text = If(IsDBNull(rd("ffckdbagian")), "", rd("ffckdbagian").ToString())
                            lJabatan.Text = If(IsDBNull(rd("ffckdjabatan")), "", rd("ffckdjabatan").ToString())
                        Else
                            PesanPopupPeringatan("Peringatan", "Data recruitment tidak ditemukan.")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                PesanPopupError("Error", "Gagal mengambil data recruitment." & vbCrLf & ex.Message)
            End Try
        End Using

    End Sub
    Private Sub SetupGridRiwayat()

        dgvRiwayatSeleksi.Columns.Clear()
        dgvRiwayatSeleksi.AutoGenerateColumns = False
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcidproses", .HeaderText = "ID", .Visible = False})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffctahap", .HeaderText = "Tahap", .Width = 140})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffdjadwal", .HeaderText = "Jadwal", .Width = 140})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffdproses", .HeaderText = "Tanggal Proses", .Width = 140})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcstatus", .HeaderText = "Status", .Width = 100})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcinterviewer", .HeaderText = "Interviewer", .Width = 150})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcnilai", .HeaderText = "Nilai", .Width = 70})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffchasil", .HeaderText = "Hasil", .Width = 130})
        dgvRiwayatSeleksi.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffccatatan", .HeaderText = "Catatan", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})

    End Sub
    Private Sub LoadRiwayatSeleksi()
        Using conn As New MySqlConnection(sambung)
            conn.Open()
            Try

                dgvRiwayatSeleksi.Rows.Clear()

                Dim sql As String = "SELECT ffcidproses,ffctahap,ffdjadwal,ffdproses,ffcstatus,ffcinterviewer,ffcnilai,ffchasil,ffccatatan FROM saprosesseleksi WHERE ffcidrekrutmen = @idrekrutmen " &
                    "And ffcidkandidat = @idkandidat ORDER BY CASE WHEN ffdjadwal Is NULL THEN 1 ELSE 0 END, ffdjadwal, ffcidproses"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@idrekrutmen", _idRekrutmen)
                    cmd.Parameters.AddWithValue("@idkandidat", _idKandidat)
                    Using rd As MySqlDataReader = cmd.ExecuteReader()
                        While rd.Read()

                            Dim rowIndex As Integer = dgvRiwayatSeleksi.Rows.Add()

                            With dgvRiwayatSeleksi.Rows(rowIndex)
                                .Cells("ffcidproses").Value = rd("ffcidproses")
                                .Cells("ffctahap").Value = If(IsDBNull(rd("ffctahap")), "", rd("ffctahap").ToString())
                                .Cells("ffdjadwal").Value = If(IsDBNull(rd("ffdjadwal")), "", Convert.ToDateTime(rd("ffdjadwal")).ToString("dd/MM/yyyy HH:mm"))
                                .Cells("ffdproses").Value = If(IsDBNull(rd("ffdproses")), "", Convert.ToDateTime(rd("ffdproses")).ToString("dd/MM/yyyy HH:mm"))
                                .Cells("ffcstatus").Value = If(IsDBNull(rd("ffcstatus")), "", rd("ffcstatus").ToString())
                                .Cells("ffcinterviewer").Value = If(IsDBNull(rd("ffcinterviewer")), "", rd("ffcinterviewer").ToString())
                                .Cells("ffcnilai").Value = If(IsDBNull(rd("ffcnilai")), "", rd("ffcnilai").ToString())
                                .Cells("ffchasil").Value = If(IsDBNull(rd("ffchasil")), "", rd("ffchasil").ToString())
                                .Cells("ffccatatan").Value = If(IsDBNull(rd("ffccatatan")), "", rd("ffccatatan").ToString())
                            End With
                        End While
                    End Using
                End Using
            Catch ex As Exception
                PesanPopupError("Error", "Gagal mengambil riwayat seleksi." & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub ResetInput()

        _idProses = 0
        _mode = "Tambah"

        If Not String.IsNullOrWhiteSpace(_TahapAwal) Then
            cTahap.SelectedItem = _TahapAwal
        Else
            cTahap.SelectedIndex = -1
        End If
        cStatus.SelectedIndex = -1

        tInterviewer.Clear()
        tNilai.Clear()
        cHasil.SelectedIndex = -1
        tCatatan.Clear()

        dtpJadwal.Value = DateTime.Now

    End Sub
    Private Sub frmProsesSeleksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            SetupComboBox()
            If _idKandidat <= 0 Then
                PesanPopupPeringatan("Peringatan", "Data kandidat belum ditentukan.")
                Return
            End If

            If _idRekrutmen <= 0 Then
                PesanPopupPeringatan("Peringatan", "Data recruitment belum ditentukan.")

                Return
            End If

            LoadKandidat()
            LoadRecruitment()
            LoadRiwayatSeleksi()


            ResetInput()

        Catch ex As Exception

            PesanPopupError("Error", "Gagal membuka proses seleksi." & vbCrLf & ex.Message)

        End Try

    End Sub

    Private Sub bBatal_Click(sender As Object, e As EventArgs) Handles bBatal.Click
        Me.Close()
    End Sub
End Class