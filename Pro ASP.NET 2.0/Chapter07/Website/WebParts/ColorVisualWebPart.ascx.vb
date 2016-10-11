
Partial Class ColorVisualWebPart
    Inherits WebPartUserControl

#Region "WebPartUserControl Overrides"

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return "Display the Actual Color of the Incomming IColor Information"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "Color Display"
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
    <ConnectionConsumer("Color Info (Visual Consumer)")> _
    Public Sub SetIColorInfo(ByVal Data As IColorInfo)
        ColorInfo = Data
        ColorInfo.RegisterConsumerName(Me.Title)
    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
     ByVal e As System.EventArgs) Handles Me.PreRender

        divColor.Style.Add("width", "100px")
        divColor.Style.Add("height", "100px")
        divColor.Style.Add("border", "1px solid black")
        If (ColorInfo Is Nothing) Then
            divColor.Style.Add("background-color", "#FFFFFF")
            divColor.InnerHtml = "No Connection"
        Else
            divColor.Style.Add("background-color", ColorInfo.HexValue)            
        End If
    End Sub

End Class
