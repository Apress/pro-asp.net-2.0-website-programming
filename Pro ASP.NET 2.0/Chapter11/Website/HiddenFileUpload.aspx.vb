Partial Class HiddenFileUpload
    Inherits System.Web.UI.Page

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click

        For index As Integer = 0 To Request.Files.Count - 1
            Request.Files(index).SaveAs(Server.MapPath("Files/") + _
              System.IO.Path.GetFileName(Request.Files(index).FileName))
        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Enctype = "multipart/form-data"        
    End Sub

End Class
