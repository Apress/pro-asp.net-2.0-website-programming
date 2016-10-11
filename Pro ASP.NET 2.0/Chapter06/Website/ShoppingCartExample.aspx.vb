
Partial Class ShoppingCartExample_aspx
    Inherits Page

    '***************************************************************************
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.gridShoppingCart.DataSource = Profile.ShoppingCart
        Me.gridShoppingCart.DataBind()

        'Create user account if necessary
        Dim search As MembershipUser = Membership.GetUser("Guest")
        If search Is Nothing Then
            Membership.CreateUser("Guest", "Guest01!", "guest@guest.com", "What is your user name?", "Guest", True, Nothing)
        End If

    End Sub

    '***************************************************************************
    Sub linkClearShoppingCart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkClearShoppingCart.Click
        If Not Profile.ShoppingCart Is Nothing Then Profile.ShoppingCart.Clear()
    End Sub

    '***************************************************************************
    Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        System.Web.Security.FormsAuthentication.SignOut()
        Response.Redirect("ShoppingCartExample.aspx")        
    End Sub

    '***************************************************************************
    Private Sub gridShoppingCart_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridShoppingCart.DataBound
        If gridShoppingCart.Rows.Count > 0 Then
            Me.linkClearShoppingCart.Enabled = True
        Else
            Me.linkClearShoppingCart.Enabled = False
        End If

    End Sub

End Class
