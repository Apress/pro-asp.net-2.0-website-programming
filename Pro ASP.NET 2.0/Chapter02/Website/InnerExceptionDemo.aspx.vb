
Partial Class InnerExceptionDemo_aspx
    Inherits System.Web.UI.Page

    '***************************************************************************
    Sub btnGenerateException_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            'The following method is obsolete, but provides a good example of 
            'inner exceptions.  You should NOT use it in your code.
            System.Web.Mail.SmtpMail.Send("", "", "", "")

        Catch ex As Exception

            Dim UseSep As Boolean = False

            While Not ex Is Nothing
                If Not UseSep Then
                    Me.lblInfo.Text = "<span style='text-decoration:underline; font-weight:bold'>Exception Info</span><br />"
                    UseSep = True
                Else
                    Me.lblInfo.Text &= "<br /><br />"
                    Me.lblInfo.Text &= "<span style='text-decoration:underline; font-weight:bold'>Inner Exception Info</span><br />"
                End If

                Me.lblInfo.Text &= "<strong>Exception Type:</strong>"
                Me.lblInfo.Text &= ex.GetType.ToString & "<BR>"
                Me.lblInfo.Text &= "<strong>Message:</strong>"
                Me.lblInfo.Text &= ex.Message

                ex = ex.InnerException

            End While

        End Try

    End Sub

End Class
