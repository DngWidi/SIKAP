Public Class Pagination
    Public Property CurrentPage As Integer = 1

    Public Property PageSize As Integer = 10

    Public Property TotalRecord As Integer = 0

    Public ReadOnly Property TotalPage As Integer
        Get
            If PageSize <= 0 Then Return 1

            If TotalRecord <= 0 Then Return 1

            Return CInt(Math.Ceiling(TotalRecord / CDbl(PageSize)))
        End Get
    End Property

    Public ReadOnly Property Offset As Integer
        Get
            Return (CurrentPage - 1) * PageSize
        End Get
    End Property

    Public ReadOnly Property StartRecord As Integer
        Get
            If TotalRecord = 0 Then Return 0

            Return Offset + 1
        End Get
    End Property

    Public ReadOnly Property EndRecord As Integer
        Get
            If TotalRecord = 0 Then Return 0

            Return Math.Min(CurrentPage * PageSize, TotalRecord)
        End Get
    End Property

End Class
