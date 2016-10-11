Imports IconConfiguration
Imports System.IO

Partial Class IconDisplayPage_aspx
    Inherits Page

    '***************************************************************************
    Private Sub OutputFile(ByVal Filename As String)

        Dim IconInfo As IconConfigurationItem
        IconInfo = Config.IconData.GetIconInfo(Path.GetExtension(Filename))

        'Add HTML to the literal control to display file and associated icon
        myLiteral.Text &= "<img src='" & IconInfo.IconImageUrl & "'"
        myLiteral.Text &= "alt='" & IconInfo.Description & "'> "
        myLiteral.Text &= Filename & "<BR>"

    End Sub

    '***************************************************************************
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles Me.Load

        'Print out documents
        OutputFile("WordDocument.doc")
        OutputFile("ExcelDocument.xls")
        OutputFile("ImageFile.bmp")
        OutputFile("SourceFile.vb")

    End Sub

End Class
