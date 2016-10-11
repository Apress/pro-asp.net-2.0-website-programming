Imports System.IO

Partial Class ShowFiles
    Inherits System.Web.UI.UserControl


    Sub BindFiles()

        Dim DI As New DirectoryInfo(Server.MapPath("Files/"))
        Dim FIArray As FileInfo() = Nothing

        If (DI.Exists) Then
            FIArray = DI.GetFiles()
        End If

        gridFiles.DataSource = FIArray
        gridFiles.DataBind()

    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        BindFiles()
    End Sub

End Class
