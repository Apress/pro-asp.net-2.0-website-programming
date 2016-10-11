Imports System.Data
Imports System.Data.SqlClient

Partial Class DatabaseMultipleFileUpload
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.Enctype = "multipart/form-data"
    End Sub

    '***************************************************************************
    Protected Sub btnUpload_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnUpload.Click

        For index As Integer = 0 To Request.Files.Count - 1

            Dim postedFile As HttpPostedFile = Request.Files(index)

            If Not postedFile.FileName = String.Empty Then

                Dim fileBytes(CInt(postedFile.InputStream.Length)) As Byte
                postedFile.InputStream.Read(fileBytes, 0, _
                  CInt(postedFile.InputStream.Length))

                Dim dbConn As SqlConnection = Data.GetConnection()
                Dim dbCmd As SqlCommand = New SqlCommand( _
                  "DELETE FROM [Files] WHERE [FileName]=@FileName;" & _
                  "INSERT INTO [Files] VALUES (@FileName, @FileSize, " & _
                  "  @FileData);", dbConn)

                dbCmd.Parameters.AddWithValue("@FileName", _
                  System.IO.Path.GetFileName(postedFile.FileName))
                dbCmd.Parameters.AddWithValue("@FileSize", fileBytes.Length)
                dbCmd.Parameters.AddWithValue("@FileData", fileBytes)

                dbConn.Open()
                dbCmd.ExecuteNonQuery()
                dbConn.Close()

            End If

        Next        

    End Sub

End Class
