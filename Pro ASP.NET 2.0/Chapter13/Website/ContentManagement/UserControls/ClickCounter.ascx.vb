
Partial Class ClickCounter
    Inherits System.Web.UI.UserControl

    '***************************************************************************
    Private Function GetClickCount() As Integer
        If IsNumeric(Me.lblClickCount.Text) Then
            Return CInt(Me.lblClickCount.Text)
        Else
            Return 0
        End If
    End Function

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.lblClickCount.Text = "0"
        End If
    End Sub

    '***************************************************************************
    Protected Sub btnClickMe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClickMe.Click
        Me.lblClickCount.Text = CStr(GetClickCount() + 1)
    End Sub

    '***************************************************************************
    Protected Sub linkReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkReset.Click
        Me.lblClickCount.Text = "0"
    End Sub

End Class
