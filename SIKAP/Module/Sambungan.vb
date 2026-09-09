Imports System.Drawing
Imports System.Windows.Forms
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports SIKAP.f_pesan
Module Sambungan
    Public sambung As String = "server=localhost;user id=root;database=salary_new; password= danang;Convert Zero Datetime=True;pooling=false;connection Timeout=3600"
    'Public sambung As String = "server=192.168.1.87;user id=server;database=salary; password= danang;Convert Zero Datetime=True;pooling=false;connection Timeout=3600"
    Public Sub ApplyGridTheme(ByVal grid As Guna2DataGridView)

        grid.SuspendLayout()

        With grid

            '====================================================
            ' BASIC
            '====================================================
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.FromArgb(229, 231, 235)

            .EnableHeadersVisualStyles = False

            .RowHeadersVisible = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = False

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            .ReadOnly = True

            .RowTemplate.Height = 38
            .ColumnHeadersHeight = 24

            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

            '====================================================
            ' HEADER
            '====================================================

            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 95, 209)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            .ColumnHeadersDefaultCellStyle.Font =
                New Font("Segoe UI Semibold", 10.0F)

            .ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(31, 95, 209)

            .ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White

            '====================================================
            ' ROW
            '====================================================

            .DefaultCellStyle.BackColor = Color.White

            .DefaultCellStyle.ForeColor =
                Color.FromArgb(31, 41, 55)

            .DefaultCellStyle.Font =
                New Font("Segoe UI", 9.0F)

            .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft

            .DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254)

            .DefaultCellStyle.SelectionForeColor =
                Color.Black

            '====================================================
            ' ALTERNATE ROW
            '====================================================

            .AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252)

            '====================================================
            ' GUNA THEME STYLE
            '====================================================

            .ThemeStyle.BackColor = Color.White

            .ThemeStyle.GridColor =
                Color.FromArgb(229, 231, 235)

            ' Header

            .ThemeStyle.HeaderStyle.BackColor =
                Color.FromArgb(31, 95, 209)

            .ThemeStyle.HeaderStyle.ForeColor =
                Color.White

            .ThemeStyle.HeaderStyle.Font =
                New Font("Segoe UI Semibold", 10)

            .ThemeStyle.HeaderStyle.Height = 24

            .ThemeStyle.HeaderStyle.BorderStyle =
                DataGridViewHeaderBorderStyle.None

            ' Rows

            .ThemeStyle.RowsStyle.BackColor =
                Color.White

            .ThemeStyle.RowsStyle.ForeColor =
                Color.FromArgb(31, 41, 55)

            .ThemeStyle.RowsStyle.Font =
                New Font("Segoe UI", 9)

            .ThemeStyle.RowsStyle.Height = 38

            .ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254)

            .ThemeStyle.RowsStyle.SelectionForeColor =
                Color.Black

            .ThemeStyle.RowsStyle.BorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal

            ' Alternate Rows

            .ThemeStyle.AlternatingRowsStyle.BackColor =
                Color.FromArgb(248, 250, 252)

        End With

        grid.ResumeLayout()

    End Sub
    ' ====== Pop up pesan =======
    Public Function PesanPopupKonfirmasi(ByVal judul As String, ByVal isi As String) As DialogResult
        Using msg As New f_pesan()
            msg.TampilkanPesan(judul, isi, JenisPesan.Konfirmasi)
            Return msg.HasilKonfirmasi
        End Using
    End Function
    Public Sub PesanPopupPeringatan(ByVal judul As String, ByVal isi As String)
        Using msg As New f_pesan()
            msg.TampilkanPesan(judul, isi, JenisPesan.Peringatan)
        End Using
    End Sub
    Public Sub PesanPopupSukses(ByVal judul As String, ByVal isi As String)
        Using msg As New f_pesan()
            msg.TampilkanPesan(judul, isi, JenisPesan.Sukses)
        End Using
    End Sub
    Public Sub PesanPopupError(ByVal judul As String, ByVal isi As String)
        Using msg As New f_pesan()
            msg.TampilkanPesan(judul, isi, JenisPesan.Error)
        End Using
    End Sub
    Public Sub PesanPopupInfo(ByVal judul As String, ByVal isi As String)
        Using msg As New f_pesan()
            msg.TampilkanPesan(judul, isi, JenisPesan.Info)
        End Using
    End Sub
End Module
