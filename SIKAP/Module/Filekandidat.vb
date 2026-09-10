Imports System.IO
Module Filekandidat

#Region "Konfigurasi"

    '========================================================
    ' ROOT PENYIMPANAN FILE KANDIDAT
    '========================================================

    Public Const ROOT_FILE_KANDIDAT As String = "\\192.168.1.250\backup data\DataKandidat"


#End Region


#Region "Folder Kandidat"

    '========================================================
    ' Mendapatkan folder utama kandidat
    '
    ' Contoh:
    ' \\192.168.1.250\backup data\Kandidat\Kandidat\KND-202609-0001
    '========================================================

    Public Function GetFolderKandidat(noKandidat As String) As String

        If String.IsNullOrWhiteSpace(noKandidat) Then
            Throw New ArgumentException("Nomor kandidat tidak boleh kosong.")
        End If


        Return Path.Combine(ROOT_FILE_KANDIDAT, "Kandidat", noKandidat.Trim())

    End Function


    '========================================================
    ' Mendapatkan folder Foto
    '========================================================

    Public Function GetFolderFoto(noKandidat As String) As String

        Return Path.Combine(GetFolderKandidat(noKandidat), "Foto")

    End Function


    '========================================================
    ' Mendapatkan folder Sertifikat
    '========================================================

    Public Function GetFolderSertifikat(noKandidat As String) As String

        Return Path.Combine(GetFolderKandidat(noKandidat), "Sertifikat")

    End Function


    '========================================================
    ' Mendapatkan folder Dokumen
    '========================================================

    Public Function GetFolderDokumen(noKandidat As String) As String

        Return Path.Combine(GetFolderKandidat(noKandidat), "Dokumen")

    End Function


#End Region


#Region "Create Folder"

    '========================================================
    ' Membuat seluruh folder kandidat
    '========================================================

    Public Sub BuatFolderKandidat(noKandidat As String)

        Dim folderKandidat As String = GetFolderKandidat(noKandidat)
        Dim folderFoto As String = GetFolderFoto(noKandidat)
        Dim folderSertifikat As String = GetFolderSertifikat(noKandidat)
        Dim folderDokumen As String = GetFolderDokumen(noKandidat)
        Directory.CreateDirectory(folderKandidat)
        Directory.CreateDirectory(folderFoto)
        Directory.CreateDirectory(folderSertifikat)
        Directory.CreateDirectory(folderDokumen)

    End Sub


#End Region


#Region "Relative Path"

    '========================================================
    ' Membuat relative path file
    '
    ' Contoh hasil:
    '
    ' Kandidat/KND-202609-0001/Dokumen/CV.pdf
    '========================================================

    Public Function GetRelativeFilePath(noKandidat As String, jenisFolder As String, fileName As String) As String

        If String.IsNullOrWhiteSpace(noKandidat) Then
            Throw New ArgumentException("Nomor kandidat tidak boleh kosong.")
        End If


        If String.IsNullOrWhiteSpace(fileName) Then
            Throw New ArgumentException("Nama file tidak boleh kosong.")
        End If


        fileName = Path.GetFileName(fileName)


        Return Path.Combine("Kandidat", noKandidat.Trim(), jenisFolder, fileName).Replace("\", "/")

    End Function


    '========================================================
    ' Mengubah relative path menjadi full UNC path
    '
    ' DB:
    ' Kandidat/KND-202609-0001/Dokumen/CV.pdf
    '
    ' Hasil:
    ' \\192.168.1.2\DataKandidat\Kandidat\...
    '========================================================

    Public Function GetFullFilePath(relativePath As String) As String

        If String.IsNullOrWhiteSpace(relativePath) Then
            Return String.Empty
        End If
        Dim cleanPath As String = relativePath.Replace("/"c, "\"c)
        Return Path.Combine(ROOT_FILE_KANDIDAT, cleanPath)

    End Function


#End Region


#Region "File"

    '========================================================
    ' Mengecek apakah file tersedia
    '========================================================

    Public Function FileExists(relativePath As String) As Boolean

        Dim fullPath As String = GetFullFilePath(relativePath)

        If String.IsNullOrWhiteSpace(fullPath) Then
            Return False
        End If
        Return File.Exists(fullPath)
    End Function


    '========================================================
    ' Hapus file berdasarkan relative path
    '========================================================

    Public Sub HapusFile(relativePath As String)

        If String.IsNullOrWhiteSpace(relativePath) Then
            Return
        End If
        Dim fullPath As String = GetFullFilePath(relativePath)
        If File.Exists(fullPath) Then
            File.Delete(fullPath)
        End If

    End Sub


#End Region


#Region "Utility"

    '========================================================
    ' Membersihkan nama file
    '
    ' Contoh:
    ' "KTP Elang (1).pdf"
    '
    ' menjadi nama yang lebih aman.
    '========================================================

    Public Function SanitizeFileName(fileName As String) As String

        If String.IsNullOrWhiteSpace(fileName) Then
            Return String.Empty
        End If
        Dim invalidChars() As Char = Path.GetInvalidFileNameChars()
        Dim result As String = fileName
        For Each c As Char In invalidChars
            result = result.Replace(c, "_"c)
        Next

        Return result.Trim()

    End Function


    '========================================================
    ' Mendapatkan extension file
    '========================================================

    Public Function GetFileExtension(fileName As String) As String
        If String.IsNullOrWhiteSpace(fileName) Then
            Return String.Empty
        End If
        Return Path.GetExtension(fileName)

    End Function
    Public Function GenerateNamaFile(fileName As String) As String

        If String.IsNullOrWhiteSpace(fileName) Then
            Throw New ArgumentException("Nama file tidak boleh kosong.")
        End If
        Dim extension As String = Path.GetExtension(fileName)
        Dim originalName As String = Path.GetFileNameWithoutExtension(fileName)
        originalName = SanitizeFileName(originalName)
        Dim uniqueId As String = Guid.NewGuid().ToString("N").Substring(0, 8)
        Return uniqueId & "_" & originalName & extension
    End Function

    Public Function SimpanFile(sourceFilePath As String, noKandidat As String, jenisFolder As String) As String

        If String.IsNullOrWhiteSpace(sourceFilePath) Then
            Throw New ArgumentException("File sumber tidak ditemukan.")
        End If
        If Not File.Exists(sourceFilePath) Then
            Throw New FileNotFoundException("File sumber tidak ditemukan.", sourceFilePath)
        End If
        If String.IsNullOrWhiteSpace(noKandidat) Then
            Throw New ArgumentException("Nomor kandidat tidak boleh kosong.")
        End If
        If String.IsNullOrWhiteSpace(jenisFolder) Then
            Throw New ArgumentException("Folder file tidak boleh kosong.")
        End If


        '========================================================
        ' PASTIKAN FOLDER ADA
        '========================================================

        Dim targetFolder As String

        Select Case jenisFolder.ToUpper()
            Case "FOTO"
                targetFolder = GetFolderFoto(noKandidat)

            Case "SERTIFIKAT"
                targetFolder = GetFolderSertifikat(noKandidat)

            Case "DOKUMEN"
                targetFolder = GetFolderDokumen(noKandidat)

            Case Else
                Throw New ArgumentException("Jenis folder file tidak valid.")

        End Select


        Directory.CreateDirectory(targetFolder)


        '========================================================
        ' GENERATE NAMA FILE
        '========================================================

        Dim originalFileName As String = Path.GetFileName(sourceFilePath)


        Dim newFileName As String = GenerateNamaFile(originalFileName)


        Dim targetFilePath As String = Path.Combine(targetFolder, newFileName)


        '========================================================
        ' COPY FILE
        '========================================================

        File.Copy(sourceFilePath, targetFilePath, False)


        '========================================================
        ' RETURN RELATIVE PATH
        '========================================================

        Return GetRelativeFilePath(noKandidat, jenisFolder, newFileName)

    End Function
    Public Sub BukaFile(relativePath As String)

        If String.IsNullOrWhiteSpace(relativePath) Then
            Throw New FileNotFoundException("Path file kosong.")
        End If


        Dim fullPath As String = GetFullFilePath(relativePath)


        If Not File.Exists(fullPath) Then
            Throw New FileNotFoundException("File tidak ditemukan di server.", fullPath)
        End If


        Process.Start(New ProcessStartInfo With {.FileName = fullPath, .UseShellExecute = True})

    End Sub
#End Region
End Module
