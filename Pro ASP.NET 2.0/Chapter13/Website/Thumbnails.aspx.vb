Imports System.IO

Partial Class Thumbnails
    Inherits System.Web.UI.Page

    '******************************************************************************
    Private Function IsSupportedExtension(ByVal FI As FileInfo) As Boolean
        Select Case UCase(FI.Extension)
            Case ".GIF", ".JPG", ".JPEG" : Return True
            Case Else : Return False
        End Select
    End Function

    '******************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles Me.Load

        Dim Dir As New DirectoryInfo(Server.MapPath("Pictures"))
        Dim Files As FileInfo() = Dir.GetFiles()
        Dim img As HyperLink
        Dim lit As Literal

        For index As Integer = 0 To Files.Length - 1
            If IsSupportedExtension(Files(index)) Then
                img = New HyperLink()
                lit = New Literal()

                img.NavigateUrl = "~/Pictures/" & Files(index).Name
                img.ImageUrl = "~/Thumbnails/" & Files(index).Name
                lit.Text = String.Format( _
                            "<BR><A HREF='Pictures/{0}'>{0}</A><BR><BR>", _
                            Files(index).Name)
                phThumbnails.Controls.Add(img)
                phThumbnails.Controls.Add(lit)
            End If
        Next


    End Sub

End Class
