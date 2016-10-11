Public Class SqlField

    '*******************************************************************************
    Private _Name As String
    Private _Alias As String
    Private _SortDirection As SqlSortDirection = SqlSortDirection.Ascending

    '*******************************************************************************
    Public Sub New(ByVal Name As String)
        _Name = Name
    End Sub

    '*******************************************************************************
    Sub New(ByVal Name As String, ByVal [Alias] As String)
        _Name = Name
        _Alias = [Alias]
    End Sub

    '*******************************************************************************
    Sub New(ByVal Name As String, ByVal SortDirection As SqlSortDirection)
        _Name = Name
        _SortDirection = SortDirection
    End Sub

    '*******************************************************************************
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    '*******************************************************************************
    Public Property [Alias]() As String
        Get
            Return _Alias
        End Get
        Set(ByVal value As String)
            _Alias = value
        End Set
    End Property

    '*******************************************************************************
    Public Property SortDirection() As SqlSortDirection
        Get
            Return _SortDirection
        End Get
        Set(ByVal value As SqlSortDirection)
            _SortDirection = value
        End Set
    End Property

End Class
