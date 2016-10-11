Imports System.Web.UI.WebControls.WebParts

Public MustInherit Class WebPartUserControl
    Inherits UserControl
    Implements IWebPart

    '***************************************************************************
    Public MustOverride Function DefaultCatalogIconImageUrl() As String
    Public MustOverride Function DefaultDescription() As String
    Public MustOverride Function DefaultSubTitle() As String
    Public MustOverride Function DefaultTitle() As String
    Public MustOverride Function DefaultTitleIconImageUrl() As String
    Public MustOverride Function DefaultTitleUrl() As String

    '***************************************************************************
    Private _WebPartData As GenericWebPart
    Private _CatalogIconImageUrl As String = DefaultCatalogIconImageUrl()
    Private _Description As String = DefaultDescription()
    Private _SubTitle As String = DefaultSubTitle()
    Private _Title As String = DefaultTitle()
    Private _TitleIconImageUrl As String = DefaultTitleIconImageUrl()
    Private _TitleUrl As String = DefaultTitleUrl()

    '***************************************************************************
    Public ReadOnly Property WebPartData() As GenericWebPart
        Get
            Try
                If _WebPartData Is Nothing Then
                    _WebPartData = WebPartManager.GetCurrentWebPartManager( _
                      Page).GetGenericWebPart(Me)
                End If
                Return _WebPartData
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    '***************************************************************************
    Public Property CatalogIconImageUrl() As String _
      Implements IWebPart.CatalogIconImageUrl
        Get
            Return _CatalogIconImageUrl
        End Get
        Set(ByVal value As String)
            _CatalogIconImageUrl = value
        End Set
    End Property

    '***************************************************************************
    Public Property Description() As String Implements IWebPart.Description
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    '***************************************************************************
    Public ReadOnly Property Subtitle() As String Implements IWebPart.Subtitle
        Get
            Return _SubTitle
        End Get
    End Property

    '***************************************************************************
    Public Property Title() As String Implements IWebPart.Title
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    '***************************************************************************
    Public Property TitleIconImageUrl() As String _
      Implements IWebPart.TitleIconImageUrl
        Get
            Return _TitleIconImageUrl
        End Get
        Set(ByVal value As String)
            _TitleIconImageUrl = value
        End Set
    End Property

    '***************************************************************************
    Public Property TitleUrl() As String Implements IWebPart.TitleUrl
        Get
            Return _TitleUrl
        End Get
        Set(ByVal value As String)
            _TitleUrl = value
        End Set
    End Property

End Class