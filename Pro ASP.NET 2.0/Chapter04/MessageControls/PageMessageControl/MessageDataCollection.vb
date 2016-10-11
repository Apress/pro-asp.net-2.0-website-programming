Public Class MessageDataCollection
    Inherits System.Collections.CollectionBase

    '***************************************************************************
    Public Function Add(ByVal obj As MessageData) As Integer
        Return List.Add(obj)
    End Function

    '***************************************************************************
    Default Public Property Item(ByVal index As Integer) As MessageData
        Get
            Return List.Item(index)
        End Get
        Set(ByVal value As MessageData)
            List.Item(index) = value
        End Set
    End Property    

End Class
