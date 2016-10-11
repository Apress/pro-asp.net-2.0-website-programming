Imports System.Data.SqlClient

Partial Class GetDBFile
    Inherits System.Web.UI.Page

    '***************************************************************************
    Private ReadOnly Property FileName() As String
        Get
            Return Request.QueryString("FileName")
        End Get
    End Property


    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load

        Dim dbConn As SqlConnection
        Dim dbCmd As SqlCommand
        Dim fileData As Byte()

        'Acquire file data
        dbConn = Data.GetConnection()
        dbCmd = New SqlCommand( _
          "SELECT FileData FROM [Files] WHERE [FileName]=@FileName", dbConn)
        dbCmd.Parameters.AddWithValue("@FileName", FileName)
        dbConn.Open()
        fileData = DirectCast(dbCmd.ExecuteScalar(), Byte())
        dbConn.Close()

        If fileData Is Nothing Then
            Response.StatusCode = 404
        Else
            Response.AddHeader("Content-Disposition", _
              "attachment; filename= """ & FileName & """")
            Response.BinaryWrite(fileData)
        End If

        Response.End()

    End Sub

End Class
