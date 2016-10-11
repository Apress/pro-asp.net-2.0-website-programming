Imports System.Web.UI.Design

Public Class PageMessageControlDesigner
    Inherits System.Web.UI.Design.ControlDesigner

    '===========================================================================
    Public Overrides Function GetDesignTimeHtml() As String

        Const Style As String = "width:100%; padding:2px; " & _
                                "background-color:Gainsboro;" & _
                                "border:1px solid black;"

        Return String.Format("<div style='{0}'>Page Messages ({1})</div><br />", _
                             Style, ID)

    End Function

End Class
