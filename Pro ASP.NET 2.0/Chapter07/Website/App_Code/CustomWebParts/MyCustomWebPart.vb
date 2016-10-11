Imports Microsoft.VisualBasic

Namespace CustomWebParts

    Public Class MyCustomWebPart
        Inherits WebParts.WebPart

        Protected Overrides Sub RenderContents(ByVal writer As System.Web.UI.HtmlTextWriter)
            writer.Write("this this a test!")
        End Sub

        Public Overrides Property Title() As String
            Get
                Return "Weather Web Part"
            End Get
            Set(ByVal value As String)

            End Set
        End Property



    End Class

End Namespace