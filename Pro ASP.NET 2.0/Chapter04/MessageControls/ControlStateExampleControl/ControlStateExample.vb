Imports System.Web.UI
Imports System.Web.UI.WebControls


<ToolboxData("<{0}:ControlStateExample runat=server></{0}:ControlStateExample>")> _
Public Class ControlStateExample
    Inherits WebControl

    '***************************************************************************
    Public Property ViewStateCounter() As Integer
        Get
            If ViewState("ViewStateCounter") Is Nothing Then Return 0
            Return CInt(ViewState("ViewStateCounter"))
        End Get
        Set(ByVal value As Integer)
            ViewState("ViewStateCounter") = value
        End Set
    End Property

    '***************************************************************************
    Private ControlStateCounter As Integer = 0

    '***************************************************************************
    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        Page.RegisterRequiresControlState(Me)
    End Sub

    '***************************************************************************
    Protected Overrides Function SaveControlState() As Object
        Return New Object() { _
            MyBase.SaveControlState(), _
            ControlStateCounter}
    End Function

    '***************************************************************************
    Protected Overrides Sub LoadControlState(ByVal savedState As Object)
        Dim StateArray() As Object = CType(savedState, Object())
        MyBase.LoadControlState(StateArray(0))
        ControlStateCounter = CInt(StateArray(1))
    End Sub

    '***************************************************************************
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        writer.WriteLine("<div>")
        writer.WriteLine("ViewState Counter: ")
        writer.WriteLine(ViewStateCounter)
        writer.WriteLine("<br />ControlState Counter:")
        writer.WriteLine(ControlStateCounter)
        writer.WriteLine("</div>")
    End Sub

    '***************************************************************************
    Private Sub ControlStateExample_Load(ByVal sender As Object, _
                                    ByVal e As System.EventArgs) Handles Me.Load
        ViewStateCounter += 1
        ControlStateCounter += 1
    End Sub

    '***************************************************************************
    Public Sub ClearCounters()
        ViewStateCounter = 1
        ControlStateCounter = 1
    End Sub


End Class
