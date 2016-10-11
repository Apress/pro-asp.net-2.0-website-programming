Imports System.Data.SqlClient

Partial Class ShowDBFiles
    Inherits System.Web.UI.UserControl


    '***************************************************************************
    Sub BindFiles()

        Dim dbConn As SqlConnection = Data.GetConnection()
        Dim dbCmd As New SqlCommand( _
                          "SELECT FileName, FileSize FROM [Files];", dbConn)
        dbConn.Open()
        Dim dbDR As SqlDataReader = dbCmd.ExecuteReader()

        gridFiles.DataSource = dbDR
        gridFiles.DataBind()

        dbDR.Close()
        dbConn.Close()        

    End Sub

    '***************************************************************************
    Protected Sub Page_PreRender(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreRender
        BindFiles()
    End Sub

End Class
