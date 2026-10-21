
Imports System.IO
Imports System.Diagnostics

Module FileKaryawan

    '========================================================
    ' KONFIGURASI ROOT PENYIMPANAN FILE KARYAWAN
    '========================================================
    ' Root ini terpisah dari ROOT_FILE_KANDIDAT.
    ' Sesuaikan lokasinya jika server penyimpanan berubah.

    Public Const ROOT_FILE_KARYAWAN As String = "\\192.168.1.250\backup data\DataKandidat"


#Region "Folder Karyawan"

    '========================================================
    ' Mendapatkan folder utama berdasarkan NIK.
    '
    ' Contoh:
    ' D:\DataKaryawan\261001
    '========================================================

    Public Function GetFolderKaryawan(nik As String) As String

        If String.IsNullOrWhiteSpace(nik) Then
            Throw New ArgumentException("NIK karyawan tidak boleh kosong.")
        End If

        Return Path.Combine(ROOT_FILE_KARYAWAN, Path.GetFileName(nik.Trim()))

    End Function


    '========================================================
    ' Mendapatkan folder Foto
    '========================================================

    Public Function GetFolderFotoKaryawan(nik As String) As String

        Return Path.Combine(GetFolderKaryawan(nik), "Foto")

    End Function


    '========================================================
    ' Mendapatkan folder Sertifikat
    '========================================================

    Public Function GetFolderSertifikatKaryawan(nik As String) As String

        Return Path.Combine(GetFolderKaryawan(nik), "Sertifikat")

    End Function


    '========================================================
    ' Mendapatkan folder Dokumen
    '========================================================

    Public Function GetFolderDokumenKaryawan(nik As String) As String

        Return Path.Combine(GetFolderKaryawan(nik), "Dokumen")

    End Function


    '========================================================
    ' Membuat seluruh folder karyawan
    '========================================================

    Public Sub BuatFolderKaryawan(nik As String)

        Directory.CreateDirectory(GetFolderKaryawan(nik))

        Directory.CreateDirectory(GetFolderFotoKaryawan(nik))

        Directory.CreateDirectory(GetFolderSertifikatKaryawan(nik))

        Directory.CreateDirectory(GetFolderDokumenKaryawan(nik))

    End Sub

#End Region


#Region "Relative Path"

    '========================================================
    ' Membuat relative path file karyawan.
    '
    ' Contoh:
    ' 261001/Foto/xxxxxxxx_foto.jpg
    ' 261001/Dokumen/xxxxxxxx_CV.pdf
    '========================================================

    Public Function GetRelativeFilePathKaryawan(nik As String, jenisFolder As String, namaFile As String) As String

        If String.IsNullOrWhiteSpace(nik) Then
            Throw New ArgumentException("NIK karyawan tidak boleh kosong.")
        End If

        If String.IsNullOrWhiteSpace(namaFile) Then
            Throw New ArgumentException("Nama file tidak boleh kosong.")
        End If

        Dim namaFolder As String = ValidasiJenisFolder(jenisFolder)

        Dim namaAman As String = Path.GetFileName(namaFile)

        Return Path.Combine(Path.GetFileName(nik.Trim()), namaFolder, namaAman).Replace("\", "/")

    End Function


    '========================================================
    ' Mengubah relative path menjadi full path karyawan.
    '
    ' Database:
    ' 261001/Dokumen/xxxxxxxx_CV.pdf
    '
    ' Hasil:
    ' D:\DataKaryawan\261001\Dokumen\xxxxxxxx_CV.pdf
    '========================================================

    Public Function GetFullFilePathKaryawan(relativePath As String) As String

        If String.IsNullOrWhiteSpace(relativePath) Then
            Return String.Empty
        End If

        Dim cleanPath As String = relativePath.Replace("/"c, "\"c)

        If Path.IsPathRooted(cleanPath) Then
            Throw New ArgumentException("Path karyawan harus berupa relative path.")
        End If

        Dim rootFull As String = Path.GetFullPath(ROOT_FILE_KARYAWAN)

        Dim fullPath As String = Path.GetFullPath(Path.Combine(rootFull, cleanPath))

        Dim rootPrefix As String = rootFull.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) & Path.DirectorySeparatorChar

        If Not fullPath.StartsWith(rootPrefix, StringComparison.OrdinalIgnoreCase) Then

            Throw New ArgumentException("Path file berada di luar folder DataKaryawan.")

        End If

        Return fullPath

    End Function

#End Region


#Region "Operasi File"

    '========================================================
    ' Menyimpan salinan file fisik ke folder karyawan.
    '
    ' sourceFilePath adalah path fisik sumber.
    ' File sumber tidak dihapus.
    '========================================================

    Public Function SalinFileKeKaryawan(sourceFilePath As String, nik As String, jenisFolder As String) As String

        If String.IsNullOrWhiteSpace(sourceFilePath) Then
            Throw New ArgumentException("Path file sumber tidak boleh kosong.")
        End If

        If Not File.Exists(sourceFilePath) Then
            Throw New FileNotFoundException("File sumber tidak ditemukan.", sourceFilePath)
        End If

        Dim namaFolder As String = ValidasiJenisFolder(jenisFolder)

        BuatFolderKaryawan(nik)

        Dim folderTujuan As String

        Select Case namaFolder

            Case "Foto"
                folderTujuan = GetFolderFotoKaryawan(nik)

            Case "Sertifikat"
                folderTujuan = GetFolderSertifikatKaryawan(nik)

            Case "Dokumen"
                folderTujuan = GetFolderDokumenKaryawan(nik)

            Case Else
                Throw New ArgumentException("Jenis folder tidak valid.")

        End Select

        Dim namaFileBaru As String = GenerateNamaFileKaryawan(Path.GetFileName(sourceFilePath))

        Dim pathTujuan As String =
            Path.Combine(folderTujuan, namaFileBaru)

        ' False: tidak menimpa file yang sudah ada.
        File.Copy(sourceFilePath, pathTujuan, False)

        Return GetRelativeFilePathKaryawan(nik, namaFolder, namaFileBaru)

    End Function


    '========================================================
    ' Menyalin file dari penyimpanan kandidat ke karyawan.
    '
    ' relativePathKandidat:
    ' Kandidat/KND-202610-0001/Dokumen/xxxxxxxx_CV.pdf
    '
    ' Path sumber diselesaikan menggunakan modul kandidat.
    ' Path hasil menggunakan root karyawan.
    '========================================================

    Public Function SalinFileKandidatKeKaryawan(relativePathKandidat As String, nik As String, jenisFolder As String) As String

        If String.IsNullOrWhiteSpace(relativePathKandidat) Then
            Return String.Empty
        End If

        ' Menggunakan ROOT_FILE_KANDIDAT melalui
        ' fungsi GetFullFilePath milik Filekandidat.vb.
        Dim pathSumber As String = Filekandidat.GetFullFilePath(relativePathKandidat)

        If Not File.Exists(pathSumber) Then
            Throw New FileNotFoundException("File kandidat tidak ditemukan.", pathSumber)
        End If

        Return SalinFileKeKaryawan(pathSumber, nik, jenisFolder)

    End Function


    '========================================================
    ' Mengecek apakah file karyawan tersedia
    '========================================================

    Public Function FileKaryawanExists(relativePath As String) As Boolean

        Dim fullPath As String = GetFullFilePathKaryawan(relativePath)

        If String.IsNullOrWhiteSpace(fullPath) Then
            Return False
        End If

        Return File.Exists(fullPath)

    End Function


    '========================================================
    ' Membuka file karyawan
    '========================================================

    Public Sub BukaFileKaryawan(relativePath As String)

        If String.IsNullOrWhiteSpace(relativePath) Then
            Throw New FileNotFoundException("Path file karyawan kosong.")
        End If

        Dim fullPath As String = GetFullFilePathKaryawan(relativePath)

        If Not File.Exists(fullPath) Then
            Throw New FileNotFoundException("File karyawan tidak ditemukan.", fullPath)
        End If

        Process.Start(New ProcessStartInfo With {.FileName = fullPath, .UseShellExecute = True})

    End Sub


    '========================================================
    ' Menghapus file berdasarkan relative path.
    ' Gunakan hanya ketika penghapusan memang diperlukan.
    '========================================================

    Public Sub HapusFileKaryawan(relativePath As String)

        If String.IsNullOrWhiteSpace(relativePath) Then
            Return
        End If

        Dim fullPath As String = GetFullFilePathKaryawan(relativePath)

        If File.Exists(fullPath) Then
            File.Delete(fullPath)
        End If

    End Sub

#End Region


#Region "Utility"

    '========================================================
    ' Validasi jenis folder
    '========================================================

    Private Function ValidasiJenisFolder(jenisFolder As String) As String

        If String.IsNullOrWhiteSpace(jenisFolder) Then
            Throw New ArgumentException("Jenis folder tidak boleh kosong.")
        End If

        Select Case jenisFolder.Trim().ToUpperInvariant()

            Case "FOTO"
                Return "Foto"

            Case "SERTIFIKAT"
                Return "Sertifikat"

            Case "DOKUMEN"
                Return "Dokumen"

            Case Else
                Throw New ArgumentException(
                    "Jenis folder harus Foto, Sertifikat, atau Dokumen."
                )

        End Select

    End Function


    '========================================================
    ' Membuat nama file unik.
    ' Tidak menggunakan nama fungsi dari Filekandidat
    ' agar tidak terjadi konflik nama fungsi.
    '========================================================

    Private Function GenerateNamaFileKaryawan(namaFile As String
    ) As String

        If String.IsNullOrWhiteSpace(namaFile) Then
            Throw New ArgumentException("Nama file tidak boleh kosong.")
        End If

        Dim ekstensi As String = Path.GetExtension(namaFile)

        Dim namaAsli As String = Path.GetFileNameWithoutExtension(namaFile)

        Dim karakterTidakValid() As Char = Path.GetInvalidFileNameChars()

        For Each karakter As Char In karakterTidakValid
            namaAsli = namaAsli.Replace(karakter, "_"c)
        Next

        Dim idUnik As String =
            Guid.NewGuid().ToString("N").Substring(0, 8)

        Return idUnik & "_" & namaAsli & ekstensi

    End Function

#End Region

End Module
