Imports System.Net.Http
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class uf_kalenderlibur

#Region "Model Class JSON API"
    Private Class HolidayModel
        <JsonProperty("date")>
        Public Property tanggal As String

        <JsonProperty("description")>
        Public Property keterangan As String
    End Class
#End Region

#Region "Private Variables (Kalender)"
    Private _currentMonth As Integer = DateTime.Now.Month
    Private _currentYear As Integer = DateTime.Now.Year

    ' Variabel untuk melacak kotak tanggal yang diklik user
    Private _selectedDate As DateTime? = Nothing
    Private _selectedPanel As Panel = Nothing
#End Region

#Region "Render FlowLayoutPanel Kalender"

    Private Sub DataKalenderLibur()
        Try
            ' 1. Kosongkan kalender & reset pilihan
            flpKalender.Controls.Clear()
            _selectedDate = Nothing
            _selectedPanel = Nothing

            ' 2. Ambil data libur bulan ini dari Database
            Dim liburBulanIni As Dictionary(Of Integer, String) = AmbilDataLiburSebulan(_currentMonth, _currentYear)

            ' 3. Kalkulasi ukuran kotak agar pas 7 kolom
            ' (Lebar FlowLayoutPanel dibagi 7, dikurangi margin sedikit agar tidak turun baris)
            Dim itemWidth As Integer = (flpKalender.ClientSize.Width - 14) \ 7
            Dim headerHeight As Integer = 35
            Dim dayHeight As Integer = 80

            ' 4. RENDER HEADER (Minggu - Sabtu)
            Dim namaHari() As String = {"Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu"}
            For Each hari In namaHari
                Dim pnlHeader As New Panel() With {
                    .Size = New Size(itemWidth, headerHeight),
                    .BackColor = Color.FromArgb(11, 99, 246), ' Biru Terang
                    .Margin = New Padding(1)
                }
                Dim lblHeader As New Label() With {
                    .Text = hari,
                    .ForeColor = Color.White,
                    .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                pnlHeader.Controls.Add(lblHeader)
                flpKalender.Controls.Add(pnlHeader)
            Next

            ' 5. KALKULASI TANGGAL
            Dim tanggalPertama As New DateTime(_currentYear, _currentMonth, 1)
            Dim totalHari As Integer = DateTime.DaysInMonth(_currentYear, _currentMonth)
            Dim indeksHariAwal As Integer = CInt(tanggalPertama.DayOfWeek) ' Minggu = 0, Senin = 1

            ' 6. RENDER KOTAK KOSONG (Sebelum tanggal 1)
            For i As Integer = 0 To indeksHariAwal - 1
                Dim pnlKosong As New Panel() With {
                    .Size = New Size(itemWidth, dayHeight),
                    .BackColor = Color.FromArgb(245, 245, 245), ' Abu-abu terang
                    .Margin = New Padding(1)
                }
                flpKalender.Controls.Add(pnlKosong)
            Next

            ' 7. RENDER KOTAK TANGGAL UTAMA
            For hari As Integer = 1 To totalHari
                Dim currentDate As New DateTime(_currentYear, _currentMonth, hari)
                Dim isMinggu As Boolean = (currentDate.DayOfWeek = DayOfWeek.Sunday)
                Dim isLibur As Boolean = liburBulanIni.ContainsKey(hari)

                ' Buat Panel Hari
                Dim pnlHari As New Panel() With {
                    .Size = New Size(itemWidth, dayHeight),
                    .BackColor = If(isLibur, Color.FromArgb(255, 240, 240), Color.White),
                    .Margin = New Padding(1),
                    .Tag = currentDate, ' Simpan tanggal di Tag untuk saat di-klik
                    .Cursor = Cursors.Hand
                }

                ' Label Angka Tanggal
                Dim lblAngka As New Label() With {
                    .Text = hari.ToString(),
                    .ForeColor = If(isLibur OrElse isMinggu, Color.Red, Color.Black),
                    .Font = New Font("Segoe UI", 10, If(isLibur, FontStyle.Bold, FontStyle.Regular)),
                    .Location = New Point(5, 5),
                    .AutoSize = True
                }

                ' Label Keterangan Libur (Jika ada)
                Dim lblKeterangan As New Label() With {
                    .Text = If(isLibur, liburBulanIni(hari), ""),
                    .ForeColor = Color.Red,
                    .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                    .Location = New Point(5, 25),
                    .Size = New Size(itemWidth - 10, dayHeight - 30),
                    .AutoEllipsis = True ' Jika teks terlalu panjang, muncul ...
                }

                ' Tambahkan Event Click agar kotak bisa dipilih
                AddHandler pnlHari.Click, AddressOf KotakHari_Click
                AddHandler lblAngka.Click, AddressOf KotakHari_Click
                AddHandler lblKeterangan.Click, AddressOf KotakHari_Click

                pnlHari.Controls.Add(lblAngka)
                pnlHari.Controls.Add(lblKeterangan)
                flpKalender.Controls.Add(pnlHari)
            Next

            ' 8. Update Label Informasi
            Dim namaBulan As String = tanggalPertama.ToString("MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
            lblInfo.Text = $"Menampilkan Kalender: {namaBulan}"

        Catch ex As Exception
            PesanPopupError("Error", "Gagal merender kalender !!" & vbCrLf & ex.Message)
        End Try
    End Sub

    ' Event saat user mengklik kotak tanggal di kalender
    Private Sub KotakHari_Click(sender As Object, e As EventArgs)
        Dim ctrl As Control = CType(sender, Control)
        ' Deteksi panel utama (karena yang ter-klik mungkin label angka/keterangannya)
        Dim pnl As Panel = If(TypeOf ctrl Is Panel, CType(ctrl, Panel), CType(ctrl.Parent, Panel))

        If pnl.Tag Is Nothing Then Return ' Jangan proses jika mengklik kotak kosong

        ' 1. Kembalikan warna panel yang sebelumnya dipilih ke warna aslinya
        If _selectedPanel IsNot Nothing AndAlso _selectedPanel.Tag IsNot Nothing Then
            Dim tglLama As DateTime = CType(_selectedPanel.Tag, DateTime)
            Dim apakahLamaLibur As Boolean = AmbilDataLiburSebulan(tglLama.Month, tglLama.Year).ContainsKey(tglLama.Day)
            _selectedPanel.BackColor = If(apakahLamaLibur, Color.FromArgb(255, 240, 240), Color.White)
            _selectedPanel.BorderStyle = BorderStyle.None
        End If

        ' 2. Beri efek sorotan (highlight) pada panel yang baru diklik
        pnl.BackColor = Color.FromArgb(235, 243, 255) ' Biru sangat muda (Highlight)
        pnl.BorderStyle = BorderStyle.FixedSingle

        ' 3. Simpan data tanggal yang terpilih ke variabel
        _selectedPanel = pnl
        _selectedDate = CType(pnl.Tag, DateTime)
    End Sub

    Private Function AmbilDataLiburSebulan(bulan As Integer, tahun As Integer) As Dictionary(Of Integer, String)
        Dim dictLibur As New Dictionary(Of Integer, String)()
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "SELECT DAY(ffdtgl) AS `Hari`, ffcket AS `Keterangan` FROM salibur " &
                                    "WHERE MONTH(ffdtgl) = @Bulan AND YEAR(ffdtgl) = @Tahun"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.Add("@Bulan", MySqlDbType.Int32).Value = bulan
                    cmd.Parameters.Add("@Tahun", MySqlDbType.Int32).Value = tahun

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim hari As Integer = Convert.ToInt32(reader("Hari"))
                            Dim keterangan As String = reader("Keterangan").ToString()

                            If dictLibur.ContainsKey(hari) Then
                                dictLibur(hari) &= vbCrLf & "- " & keterangan
                            Else
                                dictLibur.Add(hari, "- " & keterangan)
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Abaikan error baca, kembalikan dictionary kosong
        End Try
        Return dictLibur
    End Function

#End Region

#Region "API Hari Libur Sync Engine"

    Private Async Function SyncHariLiburFromApi(tahun As Integer, Optional khususBulanBerikutnya As Boolean = False) As Task
        Dim urlApi As String = $"https://api-hari-libur.vercel.app/api?year={tahun}"
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

        Using client As New HttpClient()
            Try
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)")
                Dim response As HttpResponseMessage = Await client.GetAsync(urlApi)

                If Not response.IsSuccessStatusCode Then
                    Exit Function
                End If

                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim daftarLibur As List(Of HolidayModel) = Nothing

                Dim jsonObj As JObject = JObject.Parse(jsonString)
                Dim arrayToken As JToken = Nothing
                Dim possibleKeys As String() = {"data", "holidays", "result", "items"}

                For Each key In possibleKeys
                    Dim token = jsonObj(key)
                    If token IsNot Nothing AndAlso token.Type = JTokenType.Array Then
                        arrayToken = token
                        Exit For
                    End If
                Next

                If arrayToken IsNot Nothing Then
                    daftarLibur = arrayToken.ToObject(Of List(Of HolidayModel))()
                Else
                    daftarLibur = JsonConvert.DeserializeObject(Of List(Of HolidayModel))(jsonString)
                End If

                If daftarLibur Is Nothing OrElse daftarLibur.Count = 0 Then
                    Exit Function
                End If

                If khususBulanBerikutnya Then
                    Dim targetBulan As Integer = DateTime.Now.AddMonths(1).Month
                    Dim targetTahun As Integer = DateTime.Now.AddMonths(1).Year

                    daftarLibur = daftarLibur.Where(Function(h)
                                                        Dim tgl As DateTime
                                                        If DateTime.TryParse(h.tanggal, tgl) Then
                                                            Return tgl.Month = targetBulan AndAlso tgl.Year = targetTahun
                                                        End If
                                                        Return False
                                                    End Function).ToList()
                End If

                Dim insertedCount As Integer = 0
                Using conn As New MySqlConnection(sambung)
                    conn.Open()
                    Dim sql As String = "INSERT INTO salibur (ffdtgl, ffcket, ffc_id) " &
                                        "VALUES (@Tanggal, @Keterangan, @IsCuti) " &
                                        "ON DUPLICATE KEY UPDATE ffcket = VALUES(ffcket)"

                    For Each h In daftarLibur
                        Using cmd As New MySqlCommand(sql, conn)
                            cmd.Parameters.Add("@Tanggal", MySqlDbType.Date).Value = DateTime.Parse(h.tanggal)
                            cmd.Parameters.Add("@Keterangan", MySqlDbType.VarChar).Value = h.keterangan
                            cmd.Parameters.Add("@IsCuti", MySqlDbType.VarChar).Value = "admin"
                            cmd.ExecuteNonQuery()
                            insertedCount += 1
                        End Using
                    Next
                End Using

                If Not khususBulanBerikutnya AndAlso insertedCount > 0 Then
                    PesanPopupSukses("Sukses Sync", $"Berhasil mendownload {insertedCount} hari libur nasional tahun {tahun}.")
                End If

            Catch ex As Exception
                PesanPopupError("Error API", "Terjadi kesalahan sistem: " & ex.Message)
            End Try
        End Using
    End Function

#End Region

#Region "Form Events & Navigasi"

    Private Async Sub uf_kalenderlibur_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Process Otomatis Sync Hari Libur Bulan Berikutnya
        Await SyncHariLiburFromApi(DateTime.Now.AddMonths(1).Year, khususBulanBerikutnya:=True)

        ' Tampilkan Kalender Bulan Ini
        DataKalenderLibur()
    End Sub

    Private Async Sub bSyncApi_Click(sender As Object, e As EventArgs) Handles bSyncApi.Click
        Dim tahunInput As Integer = _currentYear
        Dim hasil As DialogResult = PesanPopupKonfirmasi("Sync Hari Libur", $"Apakah Anda yakin ingin menyinkronkan seluruh data hari libur tahun {tahunInput} dari internet?")

        If hasil = DialogResult.Yes Then
            bSyncApi.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Await SyncHariLiburFromApi(tahunInput, khususBulanBerikutnya:=False)
            DataKalenderLibur()
            Me.Cursor = Cursors.Default
            bSyncApi.Enabled = True
        End If
    End Sub

    ' Silakan arahkan 'Handles' ke tombol navigasi Anda (misal tombol '<' dan '>')
    Private Sub bPrevMonth_Click(sender As Object, e As EventArgs) ' Handles bPrev.Click
        Dim dt As New DateTime(_currentYear, _currentMonth, 1)
        dt = dt.AddMonths(-1)
        _currentMonth = dt.Month
        _currentYear = dt.Year
        DataKalenderLibur()
    End Sub

    Private Sub bNextMonth_Click(sender As Object, e As EventArgs) ' Handles bNext.Click
        Dim dt As New DateTime(_currentYear, _currentMonth, 1)
        dt = dt.AddMonths(1)
        _currentMonth = dt.Month
        _currentYear = dt.Year
        DataKalenderLibur()
    End Sub

    Private Sub bRefresh_Click(sender As Object, e As EventArgs) Handles bRefresh.Click
        _currentMonth = DateTime.Now.Month
        _currentYear = DateTime.Now.Year
        DataKalenderLibur()
    End Sub

#End Region

#Region "Aksi Tambah, Edit, Hapus"

    Private Sub bTambah_Click(sender As Object, e As EventArgs) Handles bTambah.Click
        Using frm As New frmKalenderAdd()
            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                DataKalenderLibur()
            End If
        End Using
    End Sub

    Private Sub bEdit_Click(sender As Object, e As EventArgs) Handles bEdit.Click
        ' 1. Cek apakah user sudah mengklik salah satu kotak tanggal di kalender
        If Not _selectedDate.HasValue Then
            PesanPopupPeringatan("Pilih Tanggal", "Silakan klik kotak tanggal di kalender yang ingin Anda edit terlebih dahulu.")
            Exit Sub
        End If

        ' 2. Ambil keterangan libur dari kontrol Label di dalam Panel yang dipilih
        Dim keteranganLama As String = ""
        If _selectedPanel IsNot Nothing Then
            ' Cari label keterangan di dalam panel (biasanya kontrol kedua di dalam panel)
            For Each ctrl As Control In _selectedPanel.Controls
                If TypeOf ctrl Is Label AndAlso ctrl.Location.Y > 10 Then ' Label keterangan berada di bawah label angka
                    keteranganLama = ctrl.Text.Trim()
                    ' Bersihkan prefix tanda hubung jika ada (misal "- Hari Raya")
                    If keteranganLama.StartsWith("-") Then
                        keteranganLama = keteranganLama.TrimStart("-"c).Trim()
                    End If
                    Exit For
                End If
            Next
        End If

        ' 3. Buka Form Tambah/Edit Kalender dengan membawa data yang dipilih
        Using frm As New frmKalenderAdd()
            frm.ModeEdit = True
            frm.TanggalLama = _selectedDate.Value.ToString("yyyy-MM-dd")

            ' Set nilai kontrol di form Edit
            frm.dTanggal.Value = _selectedDate.Value
            frm.tKeterangan.Text = keteranganLama

            ' Jika form ditutup dengan menekan tombol Simpan (DialogResult.OK)
            If frm.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                ' Refresh tampilan kalender agar data terbaru langsung termuat
                DataKalenderLibur()
            End If
        End Using
    End Sub

    Private Sub bPrev_Click(sender As Object, e As EventArgs) Handles bPrev.Click
        ' Buat tanggal dari bulan dan tahun saat ini, lalu kurangi 1 bulan
        Dim dt As New DateTime(_currentYear, _currentMonth, 1)
        dt = dt.AddMonths(-1)

        ' Update variabel global
        _currentMonth = dt.Month
        _currentYear = dt.Year

        ' Render ulang kalender dengan bulan yang baru
        DataKalenderLibur()
    End Sub

    Private Sub bNext_Click(sender As Object, e As EventArgs) Handles bNext.Click
        ' Buat tanggal dari bulan dan tahun saat ini, lalu tambah 1 bulan
        Dim dt As New DateTime(_currentYear, _currentMonth, 1)
        dt = dt.AddMonths(1)

        ' Update variabel global
        _currentMonth = dt.Month
        _currentYear = dt.Year

        ' Render ulang kalender dengan bulan yang baru
        DataKalenderLibur()
    End Sub

    Private Sub bHapus_Click(sender As Object, e As EventArgs) Handles bHapus.Click
        ' 1. Cek apakah user sudah mengklik salah satu kotak tanggal di kalender
        If Not _selectedDate.HasValue Then
            PesanPopupPeringatan("Pilih Tanggal", "Silakan klik kotak tanggal di kalender yang ingin Anda hapus terlebih dahulu.")
            Exit Sub
        End If

        Dim tanggalStr As String = _selectedDate.Value.ToString("yyyy-MM-dd")

        ' 2. Konfirmasi penghapusan data
        Dim hasil As DialogResult = PesanPopupKonfirmasi("Hapus Hari Libur", $"Apakah Anda yakin ingin menghapus data libur pada tanggal {tanggalStr}?")

        If hasil <> DialogResult.Yes Then
            Exit Sub
        End If

        ' 3. Eksekusi perintah Delete ke database MySQL
        Try
            Using conn As New MySqlConnection(sambung)
                conn.Open()
                Dim sql As String = "DELETE FROM salibur WHERE ffdtgl = @Tanggal"

                Using comm As New MySqlCommand(sql, conn)
                    comm.Parameters.Add("@Tanggal", MySqlDbType.Date).Value = _selectedDate.Value
                    comm.ExecuteNonQuery()
                End Using
            End Using

            PesanPopupSukses("Sukses", "Data hari libur berhasil dihapus.")

            ' 4. Refresh tampilan kalender agar tanggal yang dihapus kembali normal
            DataKalenderLibur()

        Catch ex As MySqlException
            PesanPopupError("Error", "Gagal menghapus data hari libur !!" & vbCrLf & ex.Message)
        Catch ex As Exception
            PesanPopupError("Error", "Terjadi kesalahan !!" & vbCrLf & ex.Message)
        End Try
    End Sub



#End Region

End Class