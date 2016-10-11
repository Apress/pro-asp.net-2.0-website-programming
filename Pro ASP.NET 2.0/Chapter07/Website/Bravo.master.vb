
Partial Class Bravo
    Inherits System.Web.UI.MasterPage

    Protected Sub btnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As LinkButton = DirectCast(sender, LinkButton)

        Select Case btn.CommandArgument
            Case "Login"
                FormsAuthentication.RedirectToLoginPage()

            Case "Logout"
                FormsAuthentication.SignOut()
                FormsAuthentication.RedirectToLoginPage()
        End Select

    End Sub


End Class

