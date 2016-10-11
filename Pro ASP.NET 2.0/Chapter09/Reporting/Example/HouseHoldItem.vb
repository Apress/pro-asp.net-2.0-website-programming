Public MustInherit Class HouseHoldItem

    MustOverride Function PostDropStatus() As String
    Private _Status As String

    '***************************************************************************
    Public ReadOnly Property Status() As String
        Get
            Return _Status
        End Get
    End Property

    '***************************************************************************
    Public Sub Drop()
        _Status = PostDropStatus()        
    End Sub

End Class
