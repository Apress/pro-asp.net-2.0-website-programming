Partial Class ControlStateDemo_aspx
    Inherits Page

    '*********************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.rbViewStateOn.Checked Then
            Me.EnableViewState = True
        Else
            Me.EnableViewState = False
        End If
    End Sub

    '*********************************************************************************
    Sub btnClearCounters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearCounters.Click
        Me.ExampleControl1.ClearCounters()
    End Sub



End Class
