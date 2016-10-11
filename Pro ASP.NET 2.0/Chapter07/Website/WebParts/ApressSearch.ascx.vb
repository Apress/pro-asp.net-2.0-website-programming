
Partial Class ApressSearch
    Inherits WebPartUserControl

    '***************************************************************************
    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return "~/images/ApressIcon.jpg"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultDescription() As String
        Return "Allows you to enter a search term and redirects you to the Apress website when you click on the search button"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultSubTitle() As String
        Return String.Empty
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitle() As String
        Return "Search Apress Books"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleIconImageUrl() As String
        Return "~/images/ApressIcon.jpg"
    End Function

    '***************************************************************************
    Public Overrides Function DefaultTitleUrl() As String
        Return "http://www.apress.com/"
    End Function

    '***************************************************************************
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Response.Redirect("http://www.apress.com/book/search.html?searchKeywords=" & Server.UrlEncode(Me.txtSearch.Text) & "&tosearchkeyword=1&act=search&sb=1&searchBar=1&source=3&x=3&y=11")
    End Sub

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        WebPartData.HelpMode = WebPartHelpMode.Modal
        WebPartData.HelpUrl = "http://www.apress.com/"
        WebPartData.ExportMode = WebPartExportMode.All
    End Sub

End Class
