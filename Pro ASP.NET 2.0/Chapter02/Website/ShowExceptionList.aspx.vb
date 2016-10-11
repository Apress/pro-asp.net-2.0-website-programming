Imports SqlExceptionLogging
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient

Partial Class ShowExceptionList
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load

        Dim dbConn As New _
          SqlConnection(ConnectionStrings("Chapter02").ConnectionString)
        Dim ExceptionCol As New ExceptionLogCollection
        dbConn.Open()
        ExceptionCol.LoadAll(dbConn)
        dbConn.Close()
        gridExceptions.DataSource = ExceptionCol
        gridExceptions.DataBind()

        If ExceptionCol.Count > 0 Then
            litGenExceptions.Visible = True
        Else
            litGenExceptions.Visible = False
        End If

    End Sub

End Class
