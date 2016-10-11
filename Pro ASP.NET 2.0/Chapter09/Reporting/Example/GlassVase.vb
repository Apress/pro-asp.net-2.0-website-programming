Public Class GlassVase
    Inherits HouseHoldItem

    '***************************************************************************
    Public Overrides Function PostDropStatus() As String
        Return "Shattered into a thousand pieces"        
    End Function

End Class
