
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated Then
            Response.Redirect(Page.ResolveUrl("~/BravoPortal/Portal.aspx"))
        End If
    End Sub

End Class
