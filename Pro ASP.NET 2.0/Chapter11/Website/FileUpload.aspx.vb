Imports System.IO

Partial Class FileUpload
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub btnUpload_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnUpload.Click

        If FileUploader.HasFile Then

            FileUploader.SaveAs( _
              Path.Combine(Server.MapPath("Files/"), FileUploader.FileName))

        End If

    End Sub

End Class
