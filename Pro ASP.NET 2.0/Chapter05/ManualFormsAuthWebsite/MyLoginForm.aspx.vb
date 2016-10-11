Partial Class MyLoginForm
    Inherits System.Web.UI.Page

    '***************************************************************************
    Private Function AuthenticateUser(ByVal Username As String, _
      ByVal Password As String) As Boolean
        Select Case UCase(Username)
            Case "BOB" : Return CBool(Password = "bobpassword")
            Case "JANE" : Return CBool(Password = "janepassword")
            Case "MARK" : Return CBool(Password = "markpassword")
            Case Else : Return False
        End Select

    End Function

    '***************************************************************************
    Private Function GetUserRoles(ByVal username As String) As String
        Select Case UCase(username)
            Case "BOB" : Return "employee|sales"
            Case "JANE" : Return "executive|marketing"
            Case "MARK" : Return "contractor|support|admin"
            Case Else : Return ""
        End Select
    End Function

    '***************************************************************************
    Private Sub CreateAuthenticationTicket(ByVal username As String, ByVal isPersistent As Boolean)

        'Setup variables for authentication ticket
        Dim version As Integer = 1
        Dim issueDate As DateTime = Now
        Dim expirationDate As Date
        Dim userData As String = GetUserRoles(username)
        Dim cookiePath As String = "/"

        'Set the expirationDate
        If isPersistent Then
            expirationDate = Now.AddYears(1)
        Else
            expirationDate = Now.AddMinutes(60)
        End If

        'Setup the authentication ticket
        Dim authTicket As FormsAuthenticationTicket = _
          New FormsAuthenticationTicket(version, username, issueDate, _
            expirationDate, isPersistent, userData, "/")

        'Encrypt the ticket content as a string so it can be stored in a cookie
        Dim EncTicket As String = FormsAuthentication.Encrypt(authTicket)

        'Place the encrypted ticket in a cookie
        Dim AuthCookie As HttpCookie = _
          New HttpCookie(FormsAuthentication.FormsCookieName, EncTicket)

        'Set cookie duration if necessary
        If isPersistent Then AuthCookie.Expires = Now.AddYears(1)

        'Send cookie back to user
        Response.Cookies.Add(AuthCookie)

        'Redirect user to the page from whence they came
        Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent))

    End Sub

    '***************************************************************************
    Protected Sub btnLogin_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnLogin.Click
        If AuthenticateUser(txtUsername.Text, txtPassword.Text) Then
            CreateAuthenticationTicket(txtUsername.Text, chkRememberMe.Checked)
        End If
    End Sub

    '***************************************************************************
    Protected Sub btnLoginNoRoles_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnLoginNoRoles.Click
        If AuthenticateUser(txtUsername.Text, txtPassword.Text) Then
            FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, _
              chkRememberMe.Checked)
        End If
    End Sub

End Class
