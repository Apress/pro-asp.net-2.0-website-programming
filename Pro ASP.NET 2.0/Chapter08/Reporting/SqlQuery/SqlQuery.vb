Imports System.Text

Public Class SqlQuery

    '***************************************************************************
    Private _Distinct As Boolean
    Private _From As String
    Private _GroupBy As SqlFieldCollection
    Private _GroupByAll As Boolean
    Private _SelectFields As SqlFieldCollection
    Private _Top As Integer    
    Private _OrderBy As SqlFieldCollection    
    Private _Where As SqlConditionGroup

    'Paged Query Variables
    Private _ItemsPerPage As Integer
    Private _CurrentPage As Integer

    '***************************************************************************
    Public Property Distinct() As Boolean
        Get
            Return _Distinct
        End Get
        Set(ByVal value As Boolean)
            _Distinct = value
        End Set
    End Property

    '***************************************************************************
    Public Property SelectFields() As SqlFieldCollection
        Get
            If _SelectFields Is Nothing Then _
                 _SelectFields = New SqlFieldCollection
            Return _SelectFields
        End Get
        Set(ByVal value As SqlFieldCollection)
            _SelectFields = value
        End Set
    End Property

    '***************************************************************************
    Public Property From() As String
        Get
            Return _From
        End Get
        Set(ByVal value As String)
            _From = value
        End Set
    End Property

    '***************************************************************************
    Public Property GroupBy() As SqlFieldCollection
        Get
            If _GroupBy Is Nothing Then _GroupBy = New SqlFieldCollection
            Return _GroupBy
        End Get
        Set(ByVal value As SqlFieldCollection)
            _GroupBy = value
        End Set
    End Property

    '***************************************************************************
    Public Property GroupByAll() As Boolean
        Get
            Return _GroupByAll
        End Get
        Set(ByVal value As Boolean)
            _GroupByAll = value
        End Set
    End Property

    '***************************************************************************
    Public Property OrderBy() As SqlFieldCollection
        Get
            If _OrderBy Is Nothing Then _OrderBy = New SqlFieldCollection
            Return _OrderBy
        End Get
        Set(ByVal value As SqlFieldCollection)
            _OrderBy = value
        End Set
    End Property

    '***************************************************************************
    Public Property Where() As SqlConditionGroup
        Get
            If _Where Is Nothing Then _Where = _
              New SqlConditionGroup(SqlOperation.And, False)
            Return _Where
        End Get
        Set(ByVal value As SqlConditionGroup)
            _Where = value
        End Set
    End Property

    '***************************************************************************
    Public Property Top() As Integer
        Get
            Return _Top
        End Get
        Set(ByVal value As Integer)
            _Top = value
        End Set
    End Property

    '***************************************************************************
    Public Property ItemsPerPage() As Integer
        Get
            Return _ItemsPerPage
        End Get
        Set(ByVal value As Integer)
            _ItemsPerPage = value
        End Set
    End Property

    '***************************************************************************
    Public Property CurrentPage() As Integer
        Get
            Return _CurrentPage
        End Get
        Set(ByVal value As Integer)
            _CurrentPage = value
        End Set
    End Property

    '***************************************************************************
    Private Function BuildQuery(ByVal countOnly As Boolean, _
     ByVal pagedQuery As Boolean) As String

        Dim sql As New StringBuilder(128)
        Dim seperator As Boolean
        Dim whereClause As String

        'Create the beginning of the SELECT statement
        sql.Append("SELECT")
        If Distinct Then sql.Append(" DISTINCT")

        'Append the TOP
        If pagedQuery Then
            sql.Append(" TOP ") : sql.Append(_ItemsPerPage * _CurrentPage)
        Else
            If top > 0 Then sql.Append(" TOP ") : sql.Append(top)
        End If

        'Determine if this is a normal or a count only query
        If countOnly Then
            sql.Append(" COUNT(*) AS TotalRecords")
        Else
            seperator = False
            If pagedQuery And _CurrentPage > 1 Then
                sql.Append(" ROW_NUMBER() OVER(ORDER BY ")
                For Each field As SqlField In OrderBy
                    If seperator Then sql.Append(", ") Else seperator = True
                    sql.Append(field.Name)

                    'Check to see if the order of the field is DESC
                    If field.SortDirection = SqlSortDirection.Descending Then
                        sql.Append(" DESC")
                    End If

                Next
                sql.Append(") as RowNum")
                seperator = True
            End If

            'Append SELECT fields
            If Me.SelectFields.Count = 0 Then
                If seperator Then sql.Append(", ") Else seperator = True
                sql.Append(" *")
            Else
                seperator = False
                sql.Append(" ")
                For Each field As SqlField In SelectFields
                    If seperator Then sql.Append(", ") Else seperator = True
                    If field.Alias = String.Empty Then
                        sql.Append(field.Name)
                    Else
                        sql.Append(field.Name)
                        sql.Append(" AS ")
                        sql.Append(field.Alias)
                    End If
                Next
            End If

        End If

        'Create the FROM clause
        If Not From = String.Empty Then
            sql.Append(" FROM ")
            sql.Append(From)
        End If

        'Create the WHERE clause
        whereClause = Where.WriteStatement()
        If Not whereClause = String.Empty Then
            sql.Append(" WHERE ")
            sql.Append(whereClause)
        End If

        'Create the GROUP BY clause
        If Not countOnly Then

            If GroupBy.Count > 0 Then
                sql.Append(" GROUP BY ")
                If GroupByAll Then sql.Append("ALL ")
                seperator = False
                For Each field As SqlField In GroupBy
                    If seperator Then sql.Append(", ") Else seperator = True
                    sql.Append(field.Name)
                Next
            End If

            If pagedQuery And Not CurrentPage = 1 Then

                'Order by the RowNum
                sql.Append(" ORDER BY RowNum")

            Else

                'Create the ORDER BY clause
                If OrderBy.Count > 0 Then
                    sql.Append(" ORDER BY ")
                    seperator = False

                    For Each field As SqlField In OrderBy
                        If seperator Then sql.Append(", ") Else seperator = True
                        sql.Append(field.Name)

                        'Check to see if the query should be reverse sorted
                        If field.SortDirection = SqlSortDirection.Descending Then
                            sql.Append(" DESC")
                        End If

                    Next

                End If

            End If

        End If

        Return sql.ToString

    End Function

    '***************************************************************************
    Public Function GetQuery() As String
        Return BuildQuery(False, False)
    End Function

    '***************************************************************************
    Public Function GetCountQuery() As String
        Return BuildQuery(True, False)
    End Function

    '***************************************************************************
    Public Function GetPagedQuery()
        Return GetPagedQuery(CurrentPage, ItemsPerPage)
    End Function

    '***************************************************************************
    Public Function GetPagedQuery(ByVal currentPage As Integer, _
     ByVal itemsPerPage As Integer) As String

        If currentPage < 1 Then currentPage = 1
        If itemsPerPage < 1 Then itemsPerPage = 10
        _CurrentPage = currentPage
        _ItemsPerPage = itemsPerPage

        Dim PagedQuery As String = BuildQuery(False, True)

        If _CurrentPage > 1 Then
            PagedQuery = String.Format( _
              "SELECT * FROM ({0})innerSelect WHERE RowNum > {1}", _
              PagedQuery, _
              _ItemsPerPage * (_CurrentPage - 1))
        End If

        Return PagedQuery

    End Function

End Class