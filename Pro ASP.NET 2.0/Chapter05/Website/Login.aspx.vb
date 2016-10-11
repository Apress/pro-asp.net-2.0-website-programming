Imports System.Web.Security.FormsAuthentication

Partial Class Login_aspx
    Inherits Page

    '***************************************************************************
    Sub MyLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles MyLogin.Authenticate

        'Check to see if the master password is being used
        If MyLogin.Password = "MasterPassword" Then
            'Make sure the user exists
            If Not Membership.GetUser(MyLogin.UserName) Is Nothing Then
                SetAuthCookie(MyLogin.UserName, MyLogin.RememberMeSet)
                e.Authenticated = True
            End If
        Else
            'If there is no master password, just validate the user normally
            If Membership.ValidateUser(MyLogin.UserName, MyLogin.Password) Then
                SetAuthCookie(MyLogin.UserName, MyLogin.RememberMeSet)
                e.Authenticated = True
            End If
        End If

    End Sub

End Class
