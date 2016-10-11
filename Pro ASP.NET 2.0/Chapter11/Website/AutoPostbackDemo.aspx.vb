
Partial Class AutoPostbackDemo
    Inherits System.Web.UI.Page

    Protected Sub ddlOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlOptions.SelectedIndexChanged

        Dim hasFile As Boolean = False

        For index As Integer = 0 To Request.Files.Count - 1
            If Not String.IsNullOrEmpty(Request.Files(index).FileName) Then
                hasFile = True
            End If
        Next

        If hasFile Then
            Me.lblInfo.Text = "You uploaded a file on an auto-post back!  Notice that it is no longer presnent in the file upload text box."
        End If

    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click

        Dim hasFile As Boolean = False

        For index As Integer = 0 To Request.Files.Count - 1
            If Not String.IsNullOrEmpty(Request.Files(index).FileName) Then
                hasFile = True
            End If
        Next

        If hasFile Then
            Me.lblInfo.Text = "You uploaded a file after clicking the submit button!"
        Else
            Me.lblInfo.Text = "You did NOT upload a file when you clicked on the submit button!"
        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblInfo.Text = ""
    End Sub
End Class
