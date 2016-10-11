Public Class Book
    Inherits HouseHoldItem

    '***************************************************************************
    Public Overrides Function PostDropStatus() As String
        Return "OK"
    End Function

End Class
