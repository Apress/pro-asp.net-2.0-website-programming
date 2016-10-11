
Partial Class ThrowExceptionDemo_aspx
    Inherits System.Web.UI.Page

    '***************************************************************************
    Public Sub DisplayErrorMessage(ByRef ex As Exception)
        Me.lblInfo.ForeColor = Drawing.Color.DarkRed
        Me.lblInfo.Text = "A " & ex.GetType.ToString & " was thrown."        
    End Sub

    '***************************************************************************
    Sub btnThrowException_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Throw New System.Exception("An Exception Occurred")
        Catch ex As Exception
            DisplayErrorMessage(ex)
        End Try
    End Sub

    '***************************************************************************
    Sub btnIndexOutOfRangeException_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Throw New System.IndexOutOfRangeException
        Catch ex As Exception
            DisplayErrorMessage(ex)
        End Try
    End Sub

    '***************************************************************************
    Sub btnArgumentNullException_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Throw New System.ArgumentNullException
        Catch ex As Exception
            DisplayErrorMessage(ex)
        End Try
    End Sub

End Class
