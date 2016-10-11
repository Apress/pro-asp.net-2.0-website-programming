
Partial Class BasicWizard
    Inherits System.Web.UI.Page

    Private Sub WriteEvent(ByVal Name As String)
        If String.IsNullOrEmpty(litEvents.Text) Then
            litEvents.Text = "<B><U>Wizard Events</U></B>"
        End If
        litEvents.Text &= "<BR>" & Name        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Protected Sub Wizard1_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.ActiveStepChanged
        WriteEvent("ActiveStepChanged")
    End Sub

    Protected Sub Wizard1_CancelButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Wizard1.CancelButtonClick
        WriteEvent("CancelButtonClick")
    End Sub

    Protected Sub Wizard1_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.FinishButtonClick
        WriteEvent("FinishButtonClick")
    End Sub

    Protected Sub Wizard1_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.NextButtonClick
        WriteEvent("NextButtonClick")
    End Sub

    Protected Sub Wizard1_PreviousButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.PreviousButtonClick
        WriteEvent("PreviousButtonClick")
    End Sub

    Protected Sub Wizard1_SideBarButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles Wizard1.SideBarButtonClick
        WriteEvent("SideBarButtonClick")
    End Sub

    Protected Sub WizardStep1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles WizardStep1.Deactivate

    End Sub
End Class
