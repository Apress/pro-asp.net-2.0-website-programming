
Partial Class ThemeDemo_aspx
    Inherits Page

    '***************************************************************************
    'Theme can only be set before the Pre-Init Event
    '***************************************************************************
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Select Case Request.Form("ThemeName")
            Case "GreenTheme"
                Page.Theme = "GreenTheme"
            Case "RedTheme"
                Page.Theme = "RedTheme"
            Case Else
                Page.Theme = "Default"                
        End Select
    End Sub

    '***************************************************************************
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.litOptThemes.Text = CreateOptionGroup()
    End Sub


    '***************************************************************************
    Function CreateOptionGroup() As String
        Return String.Format( _
                "<input type=radio name='ThemeName' value='Default'{0}/>Default<br />" & _
                "<input type=radio name='ThemeName' value='GreenTheme'{1}/>Green Theme<br />" & _
                "<input type=radio name='ThemeName' value='RedTheme'{2}/>Red Theme<br />", _
                IIf(Request.Form("ThemeName") = "Default" Or Request.Form("ThemeName") = String.Empty, " checked ", ""), _
                IIf(Request.Form("ThemeName") = "GreenTheme", " checked ", ""), _
                IIf(Request.Form("ThemeName") = "UglyRed", " checked ", ""))
    End Function

    '***************************************************************************
    Sub btnSetTheme_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    
End Class
