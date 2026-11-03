
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class uf_kontrakkerja

    Private isLoading As Boolean = False

#Region "Form Load"

    Private Sub uf_kontrakkerja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        isLoading = True

        'Filter status kontrak
        cFilter.Items.Clear()
        cFilter.Items.Add("Semua Status")
        cFilter.Items.Add("DRAFT")
        cFilter.Items.Add("AKTIF")
        cFilter.Items.Add("NONAKTIF")
        cFilter.Items.Add("DIBATALKAN")
        cFilter.SelectedIndex = 0

        'Pengaturan DataGridView
        SetupGridKontrak()

        'Pengaturan pagination
        paginationKontrakKerja.PageSize = 10
        paginationKontrakKerja.CurrentPage = 1

        isLoading = False

        LoadDataKontrak()

    End Sub

#End Region

#Region "Setup Grid"

    Private Sub SetupGridKontrak()

        With dgvKontrakKerja

            .AutoGenerateColumns = False
            .Columns.Clear()
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "No", .HeaderText = "No", .DataPropertyName = "No", .FillWeight = 35})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcidkontrak", .HeaderText = "ID Kontrak", .DataPropertyName = "ffcidkontrak", .Visible = False})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcno", .HeaderText = "No. Kontrak", .DataPropertyName = "ffcno", .FillWeight = 115})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcnik", .HeaderText = "NIK", .DataPropertyName = "ffcnik", .FillWeight = 65})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcnama", .HeaderText = "Nama Karyawan", .DataPropertyName = "ffcnama", .FillWeight = 140})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcjenisproses", .HeaderText = "Jenis Proses", .DataPropertyName = "ffcjenisproses", .FillWeight = 105})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffctipekontrak", .HeaderText = "Tipe", .DataPropertyName = "ffctipekontrak", .FillWeight = 55})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffctanggalmulai", .HeaderText = "Tanggal Mulai", .DataPropertyName = "ffctanggalmulai", .FillWeight = 85})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffctanggalakhir", .HeaderText = "Tanggal Akhir", .DataPropertyName = "ffctanggalakhir", .FillWeight = 85})
            .Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ffcstatuskontrak", .HeaderText = "Status", .DataPropertyName = "ffcstatuskontrak", .FillWeight = 75})

            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False

        End With

        'Menggunakan tema grid standar SIKAP
        ApplyGridTheme(dgvKontrakKerja)

        dgvKontrakKerja.ColumnHeadersHeight = 35
        dgvKontrakKerja.RowTemplate.Height = 32

    End Sub

#End Region

#Region "Load Data"

    Private Sub LoadDataKontrak()

        Try

            Dim keyword As String = tPencarian.Text.Trim()
            Dim status As String = cFilter.Text.Trim()

            Dim kondisi As String = " WHERE 1=1 "

            If keyword <> "" Then
                kondisi &= " AND (k.ffcnik LIKE @keyword " &
                           " OR k.ffcnama LIKE @keyword " &
                           " OR sk.ffcno LIKE @keyword) "
            End If

            If status <> "" AndAlso status <> "Semua Status" Then
                kondisi &= " AND sk.ffcstatuskontrak = @status "
            End If

            Using conn As New MySqlConnection(sambung)

                conn.Open()

                'Hitung total data
                Dim sqlCount As String = "SELECT COUNT(*) FROM sakontrakkerja sk INNER JOIN sajatidiri k ON sk.ffcnik = k.ffcnik " &
                    kondisi

                Dim totalRecord As Integer

                Using cmdCount As New MySqlCommand(sqlCount, conn)

                    If keyword <> "" Then
                        cmdCount.Parameters.AddWithValue("@keyword", "%" & keyword & "%")
                    End If

                    If status <> "" AndAlso status <> "Semua Status" Then
                        cmdCount.Parameters.AddWithValue("@status", status)
                    End If

                    totalRecord = Convert.ToInt32(cmdCount.ExecuteScalar())

                End Using

                'Perbarui pagination
                paginationKontrakKerja.TotalRecord = totalRecord

                Dim pageSize As Integer = paginationKontrakKerja.PageSize
                Dim offset As Integer = paginationKontrakKerja.Offset

                'Ambil data sesuai halaman
                Dim sqlData As String = "SELECT sk.ffcidkontrak, sk.ffcno, sk.ffcnik,k.ffcnama,sk.ffcjenisproses, sk.ffctipekontrak, sk.ffctanggalmulai, sk.ffctanggalakhir, " &
                    "sk.ffcstatuskontrak FROM sakontrakkerja sk INNER JOIN sajatidiri k ON sk.ffcnik = k.ffcnik " &
                    kondisi & " ORDER BY sk.ffdtglinput DESC, sk.ffcidkontrak DESC  LIMIT @limit OFFSET @offset"

                Dim dt As New DataTable

                Using cmdData As New MySqlCommand(sqlData, conn)

                    If keyword <> "" Then
                        cmdData.Parameters.AddWithValue("@keyword", "%" & keyword & "%")
                    End If

                    If status <> "" AndAlso status <> "Semua Status" Then
                        cmdData.Parameters.AddWithValue("@status", status)
                    End If

                    cmdData.Parameters.AddWithValue("@limit", pageSize)
                    cmdData.Parameters.AddWithValue("@offset", offset)

                    Using adapter As New MySqlDataAdapter(cmdData)
                        adapter.Fill(dt)
                    End Using

                End Using

                'Tambahkan nomor urut
                dt.Columns.Add("No", GetType(Integer))

                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("No") = offset + i + 1
                Next

                dgvKontrakKerja.DataSource = dt

                'Format tanggal
                dgvKontrakKerja.Columns("ffctanggalmulai").DefaultCellStyle.Format = "dd/MM/yyyy"
                dgvKontrakKerja.Columns("ffctanggalakhir").DefaultCellStyle.Format = "dd/MM/yyyy"

                'Informasi jumlah data
                If totalRecord = 0 Then
                    lblInfo.Text = "Tidak ada data kontrak"
                Else
                    lblInfo.Text = "Menampilkan " &
                        paginationKontrakKerja.StartRecord.ToString() &
                        "-" &
                        paginationKontrakKerja.EndRecord.ToString() &
                        " dari " & totalRecord.ToString() & " Data"
                End If

            End Using

            AturTombolAksi()

        Catch ex As Exception

            MessageBox.Show("Gagal memuat data kontrak kerja: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

#End Region

#Region "Pencarian dan Filter"

    Private Sub bCari_Click(sender As Object, e As EventArgs) Handles bCari.Click

        paginationKontrakKerja.CurrentPage = 1
        LoadDataKontrak()

    End Sub

    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click

        tPencarian.Clear()
        cFilter.SelectedIndex = 0

        paginationKontrakKerja.CurrentPage = 1

        LoadDataKontrak()

    End Sub

    Private Sub tPencarian_KeyDown(sender As Object, e As KeyEventArgs) Handles tPencarian.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            paginationKontrakKerja.CurrentPage = 1
            LoadDataKontrak()

        End If

    End Sub

#End Region

#Region "Pagination"

    Private Sub paginationKontrakKerja_PageChanged(sender As Object, e As EventArgs) Handles paginationKontrakKerja.PageChanged

        If isLoading Then Return

        LoadDataKontrak()

    End Sub

#End Region

#Region "Tombol Aksi"

    Private Sub dgvKontrakKerja_SelectionChanged(sender As Object, e As EventArgs) Handles dgvKontrakKerja.SelectionChanged

        AturTombolAksi()

    End Sub

    Private Sub AturTombolAksi()
        Dim adaData As Boolean =
            dgvKontrakKerja.CurrentRow IsNot Nothing AndAlso
            dgvKontrakKerja.Rows.Count > 0

        bEdit.Enabled = adaData
        bDetail.Enabled = adaData

    End Sub

    Private Function GetIdKontrakTerpilih() As Long
        If dgvKontrakKerja.CurrentRow Is Nothing Then
            Return 0
        End If

        Return Convert.ToInt64(dgvKontrakKerja.CurrentRow.Cells("ffcidkontrak").Value)

    End Function



#End Region
    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click

        Using frm As New frmKontrakKerja()
            frm.ModeForm = "TAMBAH"
            frm.ShowDialog()
        End Using

    End Sub
    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click

        Dim id As Long = GetIdKontrakTerpilih()
        If id <= 0 Then Return
        Using frm As New frmKontrakKerja()
            frm.ModeForm = "EDIT"
            frm.IdKontrak = id
            frm.ShowDialog()

        End Using

    End Sub
    Private Sub bDetail_Click(sender As Object, e As EventArgs) Handles bDetail.Click

        Dim id As Long = GetIdKontrakTerpilih()
        If id <= 0 Then Return
        Using frm As New frmKontrakKerja()
            frm.ModeForm = "DETAIL"
            frm.IdKontrak = id
            frm.ShowDialog()

        End Using

    End Sub
End Class
