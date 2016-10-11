Partial Class MultipleFileUpload
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Enctype = "multipart/form-data"
    End Sub

    '***************************************************************************
    Protected Sub btnUpload_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnUpload.Click

        For index As Integer = 0 To Request.Files.Count - 1
            If Request.Files(index).FileName <> String.Empty Then
                Request.Files(index).SaveAs(Server.MapPath("Files/") + _
                  System.IO.Path.GetFileName(Request.Files(index).FileName))
            End If
        Next

    End Sub

End Class
