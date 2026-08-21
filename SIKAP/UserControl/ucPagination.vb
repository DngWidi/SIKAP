Imports Guna.UI2.WinForms
Imports System.Drawing

Public Class ucPagination

#Region "Variable"

    Private _pagination As New Pagination()

#End Region

#Region "Events"

    Public Event PageChanged As EventHandler

#End Region

#Region "Properties"

    Public Property CurrentPage As Integer

        Get
            Return _pagination.CurrentPage
        End Get

        Set(value As Integer)

            If value < 1 Then
                value = 1
            End If

            If value > _pagination.TotalPage Then
                value = _pagination.TotalPage
            End If

            _pagination.CurrentPage = value

            RefreshPagination()

        End Set

    End Property


    Public Property PageSize As Integer

        Get
            Return _pagination.PageSize
        End Get

        Set(value As Integer)

            If value <= 0 Then
                value = 10
            End If

            _pagination.PageSize = value

            If _pagination.CurrentPage > _pagination.TotalPage Then
                _pagination.CurrentPage = _pagination.TotalPage
            End If

            RefreshPagination()

        End Set

    End Property


    Public Property TotalRecord As Integer

        Get
            Return _pagination.TotalRecord
        End Get

        Set(value As Integer)

            If value < 0 Then
                value = 0
            End If

            _pagination.TotalRecord = value

            If _pagination.CurrentPage > _pagination.TotalPage Then
                _pagination.CurrentPage = _pagination.TotalPage
            End If

            RefreshPagination()

        End Set

    End Property


    Public ReadOnly Property Offset As Integer

        Get
            Return _pagination.Offset
        End Get

    End Property


    Public ReadOnly Property TotalPage As Integer

        Get
            Return _pagination.TotalPage
        End Get

    End Property


    Public ReadOnly Property StartRecord As Integer

        Get
            Return _pagination.StartRecord
        End Get

    End Property


    Public ReadOnly Property EndRecord As Integer

        Get
            Return _pagination.EndRecord
        End Get

    End Property

#End Region

#Region "Form Load"

    Private Sub ucPagination_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbPageSize.Items.Clear()

        cmbPageSize.Items.Add(10)
        cmbPageSize.Items.Add(25)
        cmbPageSize.Items.Add(50)
        cmbPageSize.Items.Add(100)

        cmbPageSize.SelectedItem = 10

        _pagination.PageSize = 10
        _pagination.CurrentPage = 1

        CreatePageButtons()

    End Sub

#End Region

#Region "Pagination Button"

    Private Sub bFirst_Click(sender As Object, e As EventArgs) Handles bFirst.Click

        If _pagination.CurrentPage = 1 Then Return

        _pagination.CurrentPage = 1

        RefreshPagination()

        RaisePageChanged()

    End Sub


    Private Sub bPrev_Click(sender As Object, e As EventArgs) Handles bPrev.Click

        If _pagination.CurrentPage <= 1 Then Return

        _pagination.CurrentPage -= 1

        RefreshPagination()

        RaisePageChanged()

    End Sub


    Private Sub bNext_Click(sender As Object, e As EventArgs) Handles bNext.Click

        If _pagination.CurrentPage >= _pagination.TotalPage Then Return

        _pagination.CurrentPage += 1

        RefreshPagination()

        RaisePageChanged()

    End Sub


    Private Sub bLast_Click(sender As Object, e As EventArgs) Handles bLast.Click

        If _pagination.CurrentPage >= _pagination.TotalPage Then Return

        _pagination.CurrentPage =
            _pagination.TotalPage

        RefreshPagination()

        RaisePageChanged()

    End Sub

#End Region

#Region "Page Number"

    Private Sub PageButton_Click(sender As Object, e As EventArgs)
        Dim btn As Guna2Button =
            DirectCast(sender, Guna2Button)

        Dim page As Integer =
            CInt(btn.Tag)

        If page = _pagination.CurrentPage Then
            Return
        End If

        _pagination.CurrentPage = page

        RefreshPagination()

        RaisePageChanged()

    End Sub

#End Region

#Region "Page Size"

    Private Sub cmbPageSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPageSize.SelectedIndexChanged

        If cmbPageSize.SelectedIndex < 0 Then
            Return
        End If

        _pagination.PageSize =
            CInt(cmbPageSize.SelectedItem)

        _pagination.CurrentPage = 1

        CreatePageButtons()

        RaisePageChanged()

    End Sub

#End Region

#Region "Pagination UI"

    Private Sub CreatePageButtons()

        flpPagination.Controls.Clear()

        flpPagination.Controls.Add(lblRows)
        flpPagination.Controls.Add(cmbPageSize)

        flpPagination.Controls.Add(bFirst)
        flpPagination.Controls.Add(bPrev)

        For i As Integer = 1 To _pagination.TotalPage

            Dim btn As New Guna2Button()

            btn.Name = "bPage" & i
            btn.Text = i.ToString()

            btn.Width = 32
            btn.Height = 32

            btn.BorderRadius = 6

            btn.FillColor = Color.White
            btn.ForeColor =
                Color.FromArgb(31, 41, 55)

            btn.BorderThickness = 1

            btn.BorderColor =
                Color.FromArgb(209, 213, 219)

            btn.Font =
                New Font("Segoe UI", 9.0F)

            btn.Tag = i
            btn.Cursor = Cursors.Hand

            AddHandler btn.Click,
                AddressOf PageButton_Click

            flpPagination.Controls.Add(btn)

        Next

        flpPagination.Controls.Add(bNext)
        flpPagination.Controls.Add(bLast)

        UpdateButtonState()

    End Sub


    Private Sub RefreshPagination()

        CreatePageButtons()

    End Sub


    Private Sub UpdateButtonState()

        bFirst.Enabled =
            _pagination.CurrentPage > 1

        bPrev.Enabled =
            _pagination.CurrentPage > 1

        bNext.Enabled =
            _pagination.CurrentPage <
            _pagination.TotalPage

        bLast.Enabled =
            _pagination.CurrentPage <
            _pagination.TotalPage

    End Sub

#End Region

#Region "Helper"

    Private Sub RaisePageChanged()

        RaiseEvent PageChanged(
            Me,
            EventArgs.Empty)

    End Sub

#End Region

End Class