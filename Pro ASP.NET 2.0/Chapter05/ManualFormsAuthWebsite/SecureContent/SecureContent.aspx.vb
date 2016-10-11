
Partial Class SecureContent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddLabelText("You are logged in as " & User.Identity.Name)
        If User.IsInRole("admin") Then AddLabelText("You are in the admin role")
        If User.IsInRole("contractor") Then AddLabelText("You are in the contractor role")
        If User.IsInRole("employee") Then AddLabelText("You are in the employee role")
        If User.IsInRole("executive") Then AddLabelText("You are in the executive role")
        If User.IsInRole("marketing") Then AddLabelText("You are in the marketing role")
        If User.IsInRole("sales") Then AddLabelText("You are in the sales role")
        If User.IsInRole("support") Then AddLabelText("You are in the support role")

    End Sub

    '***************************************************************************
    Sub DeleteAllUsersInRole(ByVal roleName As String)

        Dim usernameList() As String = Roles.GetUsersInRole(roleName)

        For Each username As String In usernameList
            Membership.DeleteUser(username, True)
        Next

    End Sub

    Private Sub AddLabelText(ByVal text As String)
        If Not Me.lblInfo.Text = "" Then Me.lblInfo.Text &= "<BR>"
        Me.lblInfo.Text &= text
    End Sub

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        FormsAuthentication.SignOut()
        Response.Redirect(Page.ResolveUrl(FormsAuthentication.LoginUrl))
    End Sub


End Class
