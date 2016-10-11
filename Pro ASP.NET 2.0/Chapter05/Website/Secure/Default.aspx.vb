
Partial Class Default_aspx
    Inherits Page

    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.IsInRole("Employee") Then

        End If
    End Sub
End Class
