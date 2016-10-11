
Partial Class ColorHexWebPart
    Inherits WebPartUserControl

#Region "WebPartUserControl Overrides"

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return "Display the Hex Value of the Incomming IColor Information"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "Hex Display"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleIconImageUrl() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleUrl() As String
        Return ""
    End Function

#End Region

    '***************************************************************************
    Private ColorInfo As IColorInfo

    '***************************************************************************
    <ConnectionConsumer("Color Info (Hex Consumer)")> _
    Public Sub SetIColorInfo(ByVal Data As IColorInfo)
        ColorInfo = Data
        ColorInfo.RegisterConsumerName(Me.Title)
    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
     ByVal e As System.EventArgs) Handles Me.PreRender
        If ColorInfo Is Nothing Then
            Me.lblHex.Text = "No Connection"
        Else
            Me.lblHex.Text = ColorInfo.HexValue
        End If
    End Sub

End Class
