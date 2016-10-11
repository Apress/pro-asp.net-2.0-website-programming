
Partial Class GenericErrorPageDemo_aspx
    Inherits System.Web.UI.Page

    '***************************************************************************
    Sub btnCreateException_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Throw New Exception("Demo Exception")
    End Sub

End Class
