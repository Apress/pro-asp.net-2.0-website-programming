
Partial Class RemoveInactiveProfiles
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim authOption As ProfileAuthenticationOption = ProfileAuthenticationOption.All
        If chkAnonymousOnly.Checked Then authOption = ProfileAuthenticationOption.Anonymous
        DeleteInActiveProfiles(CDate(txtDate.Text), authOption)
    End Sub


    '***************************************************************************
    Public Sub DeleteInActiveProfiles(ByVal beforeDate As Date, _
      ByVal authOption As ProfileAuthenticationOption)

        Dim counter As Integer = 0
        Dim ProfilesToDelete As ProfileInfoCollection _
              = ProfileManager.GetAllInactiveProfiles(authOption, beforeDate)

        For Each ProfileObj As ProfileInfo In ProfilesToDelete
            ProfileManager.DeleteProfile(ProfileObj.UserName)
            counter += 1
        Next

        lblInfo.Text = String.Format( _
          "You deleted {0} profiles from the database.", counter)

    End Sub

End Class
