Public Class IconConfigurationItem

    '***************************************************************************
    Private _IconImageUrl As String
    Private _Description As String
    Private _Extension As String

    '***************************************************************************
    Public Property IconImageUrl As String
        Get
            Return _IconImageUrl
        End Get
        Set(ByVal value As String)
            _IconImageUrl = value
        End Set
    End Property
    '***************************************************************************
    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    '***************************************************************************
    Public Property Extension As String
        Get
            Return _Extension
        End Get
        Set(ByVal value As String)
            _Extension = value
        End Set
    End Property

    '***************************************************************************
    Public Sub New(ByVal IconImageUrlParam As String, _
      ByVal DescriptionParam As String, _
      ByVal ExtensionParam As String)
        IconImageUrl = IconImageUrlParam
        Description = DescriptionParam
        Extension = ExtensionParam
    End Sub

End Class
