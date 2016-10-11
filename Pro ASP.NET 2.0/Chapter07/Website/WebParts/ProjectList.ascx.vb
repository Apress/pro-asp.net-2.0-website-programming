
Partial Class ProjectList
    Inherits WebPartUserControl



    Private _OnlyAssignedProjects As Boolean = False

    <Personalizable(PersonalizationScope.User), _
     WebBrowsable(), _
     WebDisplayName("Only Show My Projects"), _
     WebDescription("Select this option to display only those projects to which you are assigned")> _
    Public Property OnlyAssignedProjects() As Boolean
        Get
            Return _OnlyAssignedProjects
        End Get
        Set(ByVal value As Boolean)
            _OnlyAssignedProjects = value
        End Set
    End Property

    Public Overrides Function DefaultCatalogIconImageUrl() As String
        Return String.Empty
    End Function

    Public Overrides Function DefaultDescription() As String
        Return "Displays a list of projects that are going on in the company"
    End Function

    Public Overrides Function DefaultSubTitle() As String
        Return String.Empty
    End Function

    Public Overrides Function DefaultTitle() As String
        Return "Project List"
    End Function

    Public Overrides Function DefaultTitleIconImageUrl() As String
        Return String.Empty
    End Function

    Public Overrides Function DefaultTitleUrl() As String
        Return String.Empty
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
End Class
