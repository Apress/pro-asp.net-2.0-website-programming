Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.HttpContext


Public MustInherit Class SkinnedWebControl
    Inherits WebControl
    Implements INamingContainer

    '***************************************************************************
    Protected MustOverride Sub InitializeSkin(ByRef Skin As Control)

    '***************************************************************************
    Private _SkinFileName As String = String.Empty

    '***************************************************************************
    Public Property SkinFileName() As String
        Get
            Return _SkinFileName
        End Get
        Set(ByVal value As String)
            _SkinFileName = value
        End Set
    End Property

    '***************************************************************************
    Protected Function LoadSkin() As Control
        Dim Skin As Control
        Dim Theme As String = IIf(Page.Theme = String.Empty, "Default", Page.Theme)
        Dim SkinPath As String = "~/Skins/" & Theme & "/" & SkinFileName.TrimStart

        'Ensure that a skin filename has been provided
        If SkinFileName = String.Empty Then _
            Throw New Exception("You must specify a skin.")

        'Check if the skin exists before you try to load it up
        If Not File.Exists(Current.Server.MapPath(SkinPath)) Then
            SkinPath = "~/Skins/Default/" & SkinFileName.TrimStart
            If Not File.Exists(Current.Server.MapPath(SkinPath)) Then
                Throw New Exception("The skin file '" & SkinPath _
                                    & "' could be loaded.  This file must" _
                                    & " exist for this control to render.")
            End If
        End If

        'Attempt to load the skin now that you know it exists
        Try
            Skin = Page.LoadControl(SkinPath)
        Catch exSkinNotFound As Exception                
            Throw New Exception("Error loading the skin file '" & SkinPath & "'")
        End Try

        Return Skin

    End Function

    '***************************************************************************
    Protected Overrides Sub CreateChildControls()
        Dim Skin As Control = LoadSkin()
        InitializeSkin(Skin)
        Controls.Add(Skin)
    End Sub

End Class