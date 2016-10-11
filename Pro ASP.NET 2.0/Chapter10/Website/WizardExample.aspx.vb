
Partial Class WizardExample
    Inherits System.Web.UI.Page

    '***************************************************************************
    Protected Sub WizardStep1_Deactivate(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles WizardStep1.Deactivate

        If Not Me.chkStep1IsValid.Checked Then
            Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(WizardStep1)
        End If
        

    End Sub

    '***************************************************************************
    Protected Sub Wizard1_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Wizard1.Load

        If Me.chkRemoveStep2.Checked Then

            Wizard1.WizardSteps.Remove(WizardStep2)
            Me.chkSkipStep2.Checked = False

        End If

    End Sub

    '***************************************************************************
    Protected Sub Wizard1_NextButtonClick(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) _
      Handles Wizard1.NextButtonClick

        'Remember, step indexes are zero-based so index 1 represents step 2
        Select Case e.NextStepIndex
            Case 1 'Skip logic for step #2
                If Me.chkSkipStep2.Checked Then Wizard1.ActiveStepIndex = 2
            Case 2 'Skip logic for step #3
            Case 3 'Skip logic for step #4
        End Select

    End Sub

    '***************************************************************************
    Protected Sub SideBarButtonClick(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) _
      Handles Wizard1.SideBarButtonClick

        If e.NextStepIndex > e.CurrentStepIndex + 1 Then e.Cancel = True

    End Sub

 
    '***************************************************************************
    Protected Sub Wizard1_PreviousButtonClick(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) _
      Handles Wizard1.PreviousButtonClick

        Wizard1.ActiveStepIndex = e.CurrentStepIndex - 1

    End Sub

    '***************************************************************************
    Protected Sub SideBarList_ItemDataBound(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)

        If e.Item.ItemType = ListItemType.Item Or _
          e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim btnLink As LinkButton = _
              DirectCast(e.Item.FindControl("SideBarButton"), LinkButton)

            Dim linkStepIndex As Integer
            linkStepIndex = Wizard1.WizardSteps.IndexOf(e.Item.DataItem)

            If linkStepIndex > Wizard1.ActiveStepIndex Then
                btnLink.Enabled = False
            End If

        End If

    End Sub

End Class
