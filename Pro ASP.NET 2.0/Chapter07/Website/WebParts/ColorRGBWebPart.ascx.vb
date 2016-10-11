
Partial Class ColorRGBWebPart
    Inherits WebPartUserControl

#Region "WebPartUserControl Overrides"

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return "Display the RGB Value of the Incomming IColor Information"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return ""
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "RGB Display"
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
    <ConnectionConsumer("Color Info (RGB Consumer)")> _
    Public Sub SetIColorInfo(ByVal Data As IColorInfo)
        ColorInfo = Data
        ColorInfo.RegisterConsumerName(Me.Title)
    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
     ByVal e As System.EventArgs) Handles Me.PreRender

        If ColorInfo Is Nothing Then
            Me.lblR.Text = "No Connection"
            Me.lblG.Text = "-"
            Me.lblB.Text = "-"
        Else
            Me.lblR.Text = ColorInfo.R.ToString
            Me.lblG.Text = ColorInfo.G.ToString
            Me.lblB.Text = ColorInfo.B.ToString
        End If

    End Sub

End Class
