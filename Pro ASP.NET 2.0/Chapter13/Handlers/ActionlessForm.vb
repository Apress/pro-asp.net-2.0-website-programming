Imports System.Web.UI.HtmlControls

Public Class ActionlessForm
    Inherits HtmlForm

    '***************************************************************************
    Protected Overrides Sub RenderAttributes( _
      ByVal writer As System.Web.UI.HtmlTextWriter)
        writer.WriteAttribute("name", Me.Name)
        writer.WriteAttribute("method", Me.Method)
        Me.Attributes.Render(writer)
    End Sub

End Class