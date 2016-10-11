Partial Class MessageProvider
    Inherits WebPartUserControl
    Implements IMessage

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
        Return "Message Provider"
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
    Public ReadOnly Property Message() As String Implements IMessage.Message
        Get
            Return Me.txtMessage.Text
        End Get
    End Property

    '***************************************************************************
    Public Sub PassBackConsumerData(ByVal ConsumerName As String) Implements IMessage.PassBackConsumerData
        If lblConsumers.Text = String.Empty Then _
            lblConsumers.Text &= "<br/><b><u>Consumers</u></b>"
        lblConsumers.Text &= "<br/>&nbsp;&nbsp;" & ConsumerName
    End Sub

    '***************************************************************************
    <ConnectionProvider("Message Provider", "MyProviderConnectionPoint")> _
    Public Function ProvideInterface() As IMessage
        Return Me
    End Function

End Class
