
Partial Class MessageConsumer
    Inherits WebPartUserControl

#Region "WebPartUserControl Overrides"

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "Message Consumer"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleIconImageUrl() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleUrl() As String
        Return String.Empty
    End Function

#End Region

    '***************************************************************************
    Private MessageData As IMessage

    '***************************************************************************
    <ConnectionConsumer("Message", "MyConsumerConnectionPoint")> _
    Sub AcquireInterface(ByVal MessageDataIn As IMessage)
        MessageData = MessageDataIn
        MessageData.PassBackConsumerData(Me.Title)
    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreRender

        If (MessageData) Is Nothing Then
            lblMessage.Text = "No connection available"
        Else
            If MessageData.Message = String.Empty Then
                lblMessage.Text = "&lt;No Message&gt;"
            Else
                lblMessage.Text = MessageData.Message
            End If
        End If

    End Sub

End Class
