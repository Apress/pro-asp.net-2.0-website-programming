
Partial Class Page_master
    Inherits MasterPage

    Private _rootPath As String = ""
    Public ReadOnly Property RootPath()
        Get
            If (String.IsNullOrEmpty(_rootPath)) Then
                _rootPath = Page.ResolveUrl("~")
            End If
            Return _rootPath
        End Get
    End Property


End Class

