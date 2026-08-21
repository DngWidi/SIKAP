Imports System.Drawing

Public Class Thememanager
    Private Sub New()

    End Sub
    Public Shared ReadOnly PrimaryBlue As Color =
       Color.FromArgb(31, 95, 209)

    Public Shared ReadOnly SidebarBlue As Color =
        Color.FromArgb(30, 58, 138)

    Public Shared ReadOnly HoverBlue As Color =
        Color.FromArgb(59, 130, 246)

    Public Shared ReadOnly SelectedBlue As Color =
        Color.FromArgb(96, 165, 250)

    '=============================
    ' BACKGROUND
    '=============================

    Public Shared ReadOnly Background As Color =
        Color.FromArgb(245, 247, 251)

    Public Shared ReadOnly White As Color =
        Color.White

    Public Shared ReadOnly Border As Color =
        Color.FromArgb(229, 231, 235)

    '=============================
    ' TEXT
    '=============================

    Public Shared ReadOnly TextDark As Color =
        Color.FromArgb(31, 41, 55)

    Public Shared ReadOnly TextGray As Color =
        Color.FromArgb(107, 114, 128)

    '=============================
    'FONT
    '=============================

    Public Shared ReadOnly FontTitle As New Font(
    "Segoe UI",
    16,
    FontStyle.Bold)

    Public Shared ReadOnly FontMenu As New Font(
        "Segoe UI",
        10,
        FontStyle.Regular)

    Public Shared ReadOnly FontContent As New Font(
        "Segoe UI",
        9,
        FontStyle.Regular)

    Public Shared ReadOnly FontSmall As New Font(
        "Segoe UI",
        8,
        FontStyle.Regular)

    Public Const RadiusSmall As Integer = 6

    Public Const RadiusMedium As Integer = 8

    Public Const RadiusLarge As Integer = 12
End Class
