Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls

<ToolboxData("<{0}:PageMessageControl runat=server></{0}:PageMessageControl>"), _
 Designer(GetType(PageMessageControlDesigner))> _
Public Class PageMessageControl
    Inherits SkinnedWebControl

    '***************************************************************************
    Private Shared _SystemMessages As MessageDataCollection = Nothing
    Private _Messages As MessageDataCollection = Nothing
    Private _ErrorMessages As MessageDataCollection = Nothing

    Private MessagesPanel As Panel = Nothing
    Private ErrorMessagesPanel As Panel = Nothing
    Private SystemMessagesPanel As Panel = Nothing

    Private MessagesRepeater As Repeater = Nothing
    Private ErrorMessagesRepeater As Repeater = Nothing
    Private SystemMessagesRepeater As Repeater = Nothing

    '***************************************************************************
    Public Shared ReadOnly Property SystemMessages() As MessageDataCollection
        Get
            If _SystemMessages Is Nothing Then _
               _SystemMessages = New MessageDataCollection
            Return _SystemMessages
        End Get
    End Property

    '***************************************************************************
    Public Shared Sub AddSystemMessage(ByVal Message As String)
        SystemMessages.Add(New MessageData(Message))
    End Sub

    '***************************************************************************
    Public Shared Sub RemoveSystemMessage(ByVal Index As Integer)
        SystemMessages.RemoveAt(Index)
    End Sub

    '***************************************************************************
    Public Shared Sub ClearSystemMessages()
        If Not _SystemMessages Is Nothing Then _SystemMessages.Clear()
    End Sub

    '***************************************************************************
    Public Sub New()
        If Me.SkinFileName = String.Empty Then _
            Me.SkinFileName = "PageMessageDefault.ascx"
    End Sub

    '***************************************************************************
    Public ReadOnly Property Messages() As MessageDataCollection
        Get
            If _Messages Is Nothing Then _Messages = New MessageDataCollection
            Return _Messages
        End Get
    End Property

    '***************************************************************************
    Public ReadOnly Property ErrorMessages() As MessageDataCollection
        Get
            If _ErrorMessages Is Nothing Then _
               _ErrorMessages = New MessageDataCollection
            Return _ErrorMessages
        End Get
    End Property

    '***************************************************************************
    Public Property AllowSetFocus() As Boolean
        Get
            If ViewState("AllowSetFocus") Is Nothing Then Return True
            Return CBool(ViewState("AllowSetFocus"))
        End Get
        Set(ByVal value As Boolean)
            ViewState("AllowSetFocus") = value
        End Set
    End Property

    '***************************************************************************
    Protected Overrides Sub CreateChildControls()

        If Me.HasMessages Or Me.HasErrorMessages Or Me.HasSystemMessages Then
            If Me.AllowSetFocus Then
                'Add the focus anchor
                Dim AnchorLiteral As Literal = New Literal()
                AnchorLiteral.Text = "<a name='PageMessages'></a>"
                Controls.Add(AnchorLiteral)

                Page.ClientScript.RegisterStartupScript( _
                    GetType(PageMessageControl), _
                    "MsgFocus", _
                    "window.location='#PageMessages';", _
                    True)
            End If

            MyBase.CreateChildControls()

        End If

    End Sub

    '***************************************************************************
    Protected Overrides Sub InitializeSkin(ByRef Skin As System.Web.UI.Control)

        'Find Controls
        MessagesRepeater = Skin.FindControl("MessagesRepeater")
        MessagesPanel = Skin.FindControl("MessagesPanel")

        ErrorMessagesRepeater = Skin.FindControl("ErrorMessagesRepeater")
        ErrorMessagesPanel = Skin.FindControl("ErrorMessagesPanel")

        SystemMessagesRepeater = Skin.FindControl("SystemMessagesRepeater")
        SystemMessagesPanel = Skin.FindControl("SystemMessagesPanel")

        'Setup Messages
        SetupRepeaterAndPanel(MessagesRepeater, MessagesPanel, _Messages)
        SetupRepeaterAndPanel(ErrorMessagesRepeater, ErrorMessagesPanel, _
            _ErrorMessages)
        SetupRepeaterAndPanel(SystemMessagesRepeater, SystemMessagesPanel, _
            _SystemMessages)
    End Sub

    '***************************************************************************
    Private Sub SetupRepeaterAndPanel(ByRef R As Repeater, ByRef P As Panel, _
                                      ByRef Data As MessageDataCollection)
        If Not R Is Nothing Then
            R.DataSource = Data
            R.DataBind()
        End If

        If Not P Is Nothing Then
            If Data Is Nothing OrElse Data.Count = 0 Then
                P.Visible = False
            Else
                P.Visible = True
            End If
        End If

    End Sub

    '***************************************************************************
    Public Sub AddMessage(ByVal Message As String)
        Me.Messages.Add(New MessageData(Message))
    End Sub

    '***************************************************************************
    Public Sub AddErrorMessage(ByVal Message As String)
        Me.ErrorMessages.Add(New MessageData(Message))
    End Sub

    '***************************************************************************
    Public Sub ClearMessages()
        _Messages.Clear()
    End Sub

    '***************************************************************************
    Public Sub ClearErrorMessages()
        _ErrorMessages.Clear()
    End Sub

    '***************************************************************************
    Public ReadOnly Property HasMessages() As Boolean
        Get
            If _Messages Is Nothing Then Return False
            If _Messages.Count = 0 Then Return False Else Return True
        End Get
    End Property

    '***************************************************************************
    Public ReadOnly Property HasErrorMessages() As Boolean
        Get
            If _ErrorMessages Is Nothing Then Return False
            If _ErrorMessages.Count = 0 Then Return False Else Return True
        End Get
    End Property

    '***************************************************************************
    Public Shared ReadOnly Property HasSystemMessages() As Boolean
        Get
            If _SystemMessages Is Nothing Then Return False
            If _SystemMessages.Count = 0 Then Return False Else Return True
        End Get
    End Property

End Class