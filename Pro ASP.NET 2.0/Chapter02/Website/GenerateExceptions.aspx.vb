Imports SqlExceptionLogging

Partial Class GenerateExceptions
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub btnGenerate_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnGenerate.Click

        Dim ex As Exception
        Dim message As String = ""

        For index As Integer = CInt(ddlCount.SelectedValue) - 1 To 0 Step -1
            message = Me.txtMessage.Text
            If index > 0 Then message &= " (Inner Exception #" & index & ")"
            ex = New Exception(message, ex)
        Next

        ExceptionLogger.Log(ex)

        Response.Redirect("ShowExceptionList.aspx")

    End Sub

End Class
