
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class frmKontrakKerja

    Private ShadowForm As New Guna.UI2.WinForms.Guna2ShadowForm()

#Region "Property Form"

    Public Property ModeForm As String = "TAMBAH"
    Public Property IdKontrak As Long = 0
    Public Property IdKaryawan As String = ""

    Private isInitializing As Boolean = False

#End Region

#Region "Form Load"

    Private Sub frmKontrakKerja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ShadowForm.SetShadowForm(Me)

        SetupForm()

        isInitializing = True

        SetupComboBox()
        SetupKontrolAwal()

        isInitializing = False

        AturKontrolBerdasarkanProses()
        AturKontrolBerdasarkanTipe()

    End Sub

#End Region

#Region "Private"

    Private Sub SetupComboBox()

        'Jenis Proses
        With cmbJenisKontrak
            .Items.Clear()
            .Items.Add("KONTRAK_AWAL")
            .Items.Add("PERPANJANGAN")
            .Items.Add("PENGANGKATAN_TETAP")
            .Items.Add("PERUBAHAN")
            .SelectedIndex = -1
        End With

        'Tipe Kontrak
        With cmbTipeKontrak
            .Items.Clear()
            .Items.Add("PKWT")
            .Items.Add("PKWTT")
            .SelectedIndex = -1
        End With

        'Kontrak Sebelumnya
        With cmbKontrak
            .DataSource = Nothing
            .Items.Clear()
            .SelectedIndex = -1
            .Enabled = False
        End With

    End Sub

    Private Sub SetupKontrolAwal()

        'Identitas karyawan
        tNikKaryawan.ReadOnly = False
        tNamaKaryawan.ReadOnly = True
        tDepartment.ReadOnly = True
        tBagian.ReadOnly = True
        tJabatan.ReadOnly = True

        BersihkanIdentitasKaryawan()

        'Tanggal
        dtTanggalTandaTangan.Value = Date.Today
        dtTanggalMulai.Value = Date.Today
        dtTanggalAkhir.Value = Date.Today

        dtTanggalAkhir.Enabled = False

    End Sub

    Private Sub AturKontrolBerdasarkanProses()

        If isInitializing Then Return

        Dim jenisProses As String =
            cmbJenisKontrak.Text.Trim().ToUpper()

        Select Case jenisProses

            Case "KONTRAK_AWAL"

                BersihkanKontrakSebelumnya()

                cmbTipeKontrak.Enabled = True
                cmbTipeKontrak.SelectedIndex = -1

            Case "PERPANJANGAN"

                cmbTipeKontrak.Enabled = True
                cmbTipeKontrak.SelectedIndex = 0

            Case "PENGANGKATAN_TETAP"

                cmbTipeKontrak.SelectedIndex = 1
                cmbTipeKontrak.Enabled = False

            Case "PERUBAHAN"

                cmbTipeKontrak.Enabled = True
                cmbTipeKontrak.SelectedIndex = -1

            Case Else

                BersihkanKontrakSebelumnya()

                cmbTipeKontrak.Enabled = False
                cmbTipeKontrak.SelectedIndex = -1

        End Select

        AturKontrolBerdasarkanTipe()

        'Muat ulang kontrak sebelumnya sesuai jenis proses
        If tNamaKaryawan.Text.Trim() <> "" Then
            MuatKontrakSebelumnya()
        End If

    End Sub

    Private Sub AturKontrolBerdasarkanTipe()

        Dim tipeKontrak As String =
            cmbTipeKontrak.Text.Trim().ToUpper()

        Select Case tipeKontrak

            Case "PKWT"

                dtTanggalAkhir.Enabled = True

            Case "PKWTT"

                dtTanggalAkhir.Enabled = False

            Case Else

                dtTanggalAkhir.Enabled = False

        End Select

    End Sub

    Private Sub ValidasiNIKKaryawan()

        Dim nik As String = tNikKaryawan.Text.Trim()

        If nik = "" Then
            BersihkanIdentitasKaryawan()
            BersihkanKontrakSebelumnya()
            Return
        End If

        Try

            Dim sql As String = "SELECT p.ffcnik, p.ffcnama, COALESCE(d.ffcnama, '') AS NamaDepartment, COALESCE(b.ffcnama, '') AS NamaBagian, COALESCE(j.ffcnama, '') AS NamaJabatan " &
                "FROM sajatidiri p LEFT JOIN sadepartment d ON p.ffcdepart = d.ffckode LEFT JOIN sabagian b ON p.ffcbagian = b.ffcbag LEFT JOIN sajabatan j ON p.ffcjabatan = j.ffckls " &
                "WHERE p.ffcnik = @nik LIMIT 1"

            Dim dataDitemukan As Boolean = False

            Using conn As New MySqlConnection(sambung)

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@nik", nik)

                    conn.Open()

                    Using rd As MySqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then

                            tNikKaryawan.Text = rd("ffcnik").ToString()
                            tNamaKaryawan.Text = rd("ffcnama").ToString()
                            tDepartment.Text = rd("NamaDepartment").ToString()
                            tBagian.Text = rd("NamaBagian").ToString()
                            tJabatan.Text = rd("NamaJabatan").ToString()

                            dataDitemukan = True

                        End If

                    End Using

                End Using

            End Using

            If dataDitemukan Then

                'Memuat kontrak setelah reader ditutup
                MuatKontrakSebelumnya()

            Else

                BersihkanIdentitasKaryawan()
                BersihkanKontrakSebelumnya()

                MessageBox.Show("NIK karyawan tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                tNikKaryawan.Focus()
                tNikKaryawan.SelectAll()

            End If

        Catch ex As Exception

            BersihkanIdentitasKaryawan()
            BersihkanKontrakSebelumnya()

            MessageBox.Show("Gagal memvalidasi NIK: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub BersihkanIdentitasKaryawan()

        tNamaKaryawan.Clear()
        tDepartment.Clear()
        tBagian.Clear()
        tJabatan.Clear()

    End Sub

    Private Sub BersihkanKontrakSebelumnya()

        cmbKontrak.DataSource = Nothing
        cmbKontrak.Items.Clear()
        cmbKontrak.SelectedIndex = -1
        cmbKontrak.Enabled = False

    End Sub

    Private Sub MuatKontrakSebelumnya()

        Dim nik As String = tNikKaryawan.Text.Trim()

        Dim jenisProses As String =
            cmbJenisKontrak.Text.Trim().ToUpper()

        BersihkanKontrakSebelumnya()

        If nik = "" Then Return

        If jenisProses = "" OrElse
           jenisProses = "KONTRAK_AWAL" Then

            Return

        End If

        Try

            Dim sql As String = "SELECT ffcidkontrak, ffcno, ffctipekontrak, ffctanggalmulai, ffctanggalakhir FROM sakontrakkerja WHERE ffcnik = @nik AND ffcstatuskontrak = 'AKTIF' "

            If jenisProses = "PERPANJANGAN" OrElse jenisProses = "PENGANGKATAN_TETAP" Then
                sql &= "AND ffctipekontrak = 'PKWT' "
            End If

            sql &= "ORDER BY ffctanggalmulai DESC"

            Using conn As New MySqlConnection(sambung)

                Using cmd As New MySqlCommand(sql, conn)

                    cmd.Parameters.AddWithValue("@nik", nik)

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()

                        da.Fill(dt)

                        If dt.Rows.Count > 0 Then

                            cmbKontrak.DisplayMember = "ffcno"
                            cmbKontrak.ValueMember = "ffcidkontrak"
                            cmbKontrak.DataSource = dt

                            cmbKontrak.SelectedIndex = -1
                            cmbKontrak.Enabled = True

                        Else

                            BersihkanKontrakSebelumnya()

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception
            BersihkanKontrakSebelumnya()
            MessageBox.Show("Gagal memuat kontrak sebelumnya: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

#Region "Setup Form"

    Private Sub SetupForm()

        ModeForm = ModeForm.Trim().ToUpper()

        Select Case ModeForm

            Case "TAMBAH"

                Me.Text = "Tambah Kontrak Kerja"

            Case "EDIT"

                Me.Text = "Edit Kontrak Kerja"

                If IdKontrak <= 0 Then
                    MessageBox.Show("ID kontrak tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Return
                End If

            Case "DETAIL"
                Me.Text = "Detail Kontrak Kerja"
                If IdKontrak <= 0 Then
                    MessageBox.Show("ID kontrak tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                    Return
                End If

            Case Else
                MessageBox.Show("Mode form tidak dikenali.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return

        End Select

    End Sub

#End Region

#Region "Event Control"

    Private Sub bTutup_Click(sender As Object, e As EventArgs) Handles bTutup.Click
        Me.Close()

    End Sub

    Private Sub bClose_Click(sender As Object, e As EventArgs) Handles bClose.Click

        Me.Close()

    End Sub

    Private Sub cmbJenisKontrak_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisKontrak.SelectedIndexChanged

        AturKontrolBerdasarkanProses()

    End Sub

    Private Sub cmbTipeKontrak_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipeKontrak.SelectedIndexChanged
        AturKontrolBerdasarkanTipe()
    End Sub

    Private Sub tNikKaryawan_KeyDown(sender As Object, e As KeyEventArgs) Handles tNikKaryawan.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ValidasiNIKKaryawan()

        End If

    End Sub

#End Region

End Class
