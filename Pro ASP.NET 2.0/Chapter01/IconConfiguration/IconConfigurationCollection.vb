Public Class IconConfigurationCollection
    Inherits CollectionBase

    '***************************************************************************
    Public UnknownIconInfo As IconConfigurationItem

    '***************************************************************************
    Private Function GetExtensionIndex(ByVal Extension As String) As Integer

        Dim IconConfigItem As IconConfigurationItem
        Extension = Extension.ToUpper

        For index As Integer = 0 To List.Count - 1
            IconConfigItem = DirectCast(List.Item(index), IconConfigurationItem)
            If IconConfigItem.Extension.ToUpper = Extension Then
                Return index
            End If
        Next

        Return -1

    End Function

    '***************************************************************************
    Default ReadOnly Property GetIconInfo(ByVal Extension As String) As IconConfigurationItem
        Get
            Dim Index As Integer = GetExtensionIndex(Extension)
            If Index = -1 Then Return UnknownIconInfo
            Return DirectCast(List.Item(Index), IconConfigurationItem)            
        End Get
    End Property

    '***************************************************************************
    Public Function Add(ByRef obj As IconConfigurationItem) As Integer
        Return List.Add(obj)
    End Function

End Class
