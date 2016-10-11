Imports System.Data.SqlClient

Partial Class DatabaseFileUpload
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub btnUpload_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnUpload.Click

        Dim dbConn As SqlConnection
        Dim dbCmd As SqlCommand

        If FileUploader.HasFile Then

            'Open the connection and setup the SQL statement
            dbConn = Data.GetConnection()
            dbCmd = New SqlCommand( _
               "DELETE FROM [Files] WHERE [FileName]=@FileName;" & _
               "INSERT INTO [Files] VALUES (@FileName, @FileSize, @FileData);", _
               dbConn)

            'Add values using parameters
            dbCmd.Parameters.AddWithValue("@FileName", _
              System.IO.Path.GetFileName(FileUploader.FileName))
            dbCmd.Parameters.AddWithValue("@FileSize", _
              FileUploader.FileContent.Length)
            dbCmd.Parameters.AddWithValue("@FileData", FileUploader.FileBytes)

            'Execute and close
            dbConn.Open()
            dbCmd.ExecuteNonQuery()
            dbConn.Close()

        End If

    End Sub

End Class
