Partial Class TargetedAdExample_aspx
    Inherits Page

    '***************************************************************************
    Sub lnkBaseball_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles lnkBaseball.Click
        Profile.CategoryTracking.Baseball += 1
    End Sub

    '***************************************************************************
    Sub lnkBasketball_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles lnkBasketball.Click
        Profile.CategoryTracking.Basketball += 1
    End Sub

    '***************************************************************************
    Sub lnkFootball_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles lnkFootball.Click
        Profile.CategoryTracking.Football += 1
    End Sub

    '***************************************************************************
    Sub lnkHockey_click(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles lnkHockey.Click
        Profile.CategoryTracking.Hockey += 1
    End Sub

    '***************************************************************************
    Private Sub Page_PreRender(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.PreRender

        With Profile.CategoryTracking

            If .Baseball >= .Basketball And _
                .Baseball >= .Football And _
                  .Baseball >= .Hockey Then
                imgAd.ImageUrl = "~/ProductImages/Baseball.jpg"
            ElseIf .Basketball >= .Football And _
                    .Basketball >= .Hockey Then
                imgAd.ImageUrl = "~/ProductImages/Basketball.jpg"
            ElseIf .Football >= .Hockey Then
                imgAd.ImageUrl = "~/ProductImages/Football.jpg"
            Else
                imgAd.ImageUrl = "~/ProductImages/Hockey.jpg"
            End If

            Me.lblBaseball.Text = String.Format("({0})", .Baseball)
            Me.lblBasketball.Text = String.Format("({0})", .Basketball)
            Me.lblFootball.Text = String.Format("({0})", .Football)
            Me.lblHockey.Text = String.Format("({0})", .Hockey)

        End With



    End Sub

    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As New System.Web.Profile.ProfileBase
        Dim y As New System.Web.Profile.SqlProfileProvider
        Dim z As ProfileCommon



    End Sub
End Class
