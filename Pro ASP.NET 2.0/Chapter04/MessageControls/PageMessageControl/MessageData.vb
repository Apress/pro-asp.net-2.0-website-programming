Public Class MessageData

    '***************************************************************************
    Private _Message As String = String.Empty

    '***************************************************************************
    Public Sub New(ByVal Message As String)
        _Message = Message
    End Sub

    '***************************************************************************
    Public Property Message() As String
        Get  
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property

End Class
