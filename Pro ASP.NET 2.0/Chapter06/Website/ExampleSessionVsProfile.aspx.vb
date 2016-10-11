Imports Microsoft.VisualBasic

Partial Class ExampleSessionVsProfile_aspx
    Inherits Page

    '******************************************************************************
    Private Function GetAge(ByVal DOB As Date) As Long
        Return DateDiff(DateInterval.Year, DOB, Now)        
    End Function

    '******************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load

        'Setup Session and Profile to ensure they have values
        Session("DateOfBirth") = #8/20/1980#
        Profile.DateOfBirth = #8/20/1980#

        'Notice that you have use casting for the Session but not the Profile
        Me.lblAge.Text = GetAge(CType(Session("DateOfBirth"), Date)).ToString()
        Me.lblAge.Text = GetAge(Profile.DateOfBirth).ToString()

    End Sub

End Class
