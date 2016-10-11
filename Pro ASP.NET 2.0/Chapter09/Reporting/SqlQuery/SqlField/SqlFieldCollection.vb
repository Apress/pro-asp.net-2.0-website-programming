Public Class SqlFieldCollection
    Inherits CollectionBase

    '*******************************************************************************
    Public Function Add(ByVal name As String) As Integer
        Return List.Add(New SqlField(name))
    End Function

    '*******************************************************************************
    Public Function Add(ByVal name As String, ByVal [alias] As String) As Integer
        Return List.Add(New SqlField(name, [alias]))
    End Function

    '*******************************************************************************
    Public Function Add(ByVal name As String, _
      ByVal SortDirection As SqlSortDirection) As Integer
        Return List.Add(New SqlField(name, SortDirection))
    End Function

    '*******************************************************************************
    Default Public ReadOnly Property Item(ByVal Index As Integer) As SqlField
        Get
            Return List.Item(Index)
        End Get
    End Property

    '*******************************************************************************
    Public Function Find(ByVal name As String) As SqlField
        name = UCase(name)  'Only uppercase the name once

        'Iterate through each field name looking for a match
        For index As Integer = 0 To Count - 1
            If UCase(Item(index).Name) = name Then Return Item(index)
        Next

        Return Nothing
    End Function

    '*******************************************************************************
    Public Sub Remove(ByVal item As SqlField)
        List.Remove(item)
    End Sub

    '*******************************************************************************
    Public Sub Remove(ByVal name As String)
        Dim item As SqlField = Find(name)
        If Not item Is Nothing Then List.Remove(item)
    End Sub

End Class
