Partial Class AddEmployee
    Inherits System.Web.UI.Page

    '***************************************************************************
    Private SideBarClicked As Boolean = False
    Private PrevButtonClicked As Boolean = False

    '***************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            AddWizard.ActiveStepIndex = 0
        End If

    End Sub

    '***************************************************************************
    Protected Sub WizardStep2_Activate(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles WizardStep2.Activate

        If PrevButtonClicked Then
            'Always return to step 1 if the previous button is clicked
            AddWizard.ActiveStepIndex = 0
        Else

            Dim EmployeeCol As EmployeeCollection
            EmployeeCol = EmployeeCollection.GetEmployeeMatches( _
                            txtSearchLastName.Text, txtSearchFirstName.Text)

            If EmployeeCol.Count > 0 Then
                GridDuplicates.DataSource = EmployeeCol
                GridDuplicates.DataBind()

                Me.pnlHasResults.Visible = True
                Me.pnlNoResults.Visible = False

            Else
                If SideBarClicked Then
                    Me.pnlHasResults.Visible = False
                    Me.pnlNoResults.Visible = True
                Else
                    'Skip the step
                    AddWizard.ActiveStepIndex = 2
                End If
            End If

        End If

    End Sub

    '***************************************************************************
    Protected Sub WizardStep3_Activate(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles WizardStep3.Activate

        If Me.txtFirstName.Text = String.Empty Then _
            Me.txtFirstName.Text = Me.txtSearchFirstName.Text
        If Me.txtLastName.Text = String.Empty Then _
            Me.txtLastName.Text = Me.txtSearchLastName.Text

    End Sub


    '***************************************************************************
    Protected Sub AddWizard_PreviousButtonClick(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) _
      Handles AddWizard.PreviousButtonClick

        PrevButtonClicked = True
        Me.AddWizard.ActiveStepIndex = e.CurrentStepIndex - 1

    End Sub

    '***************************************************************************
    Protected Sub AddWizard_SideBarButtonClick(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) _
      Handles AddWizard.SideBarButtonClick

        SideBarClicked = True
        If e.CurrentStepIndex < 2 And e.NextStepIndex > e.CurrentStepIndex + 1 Then
            e.Cancel = True
            Page.ClientScript.RegisterStartupScript(Me.GetType, "noJump", _
              "alert('You cannot jump over Step 2');", True)
        End If

    End Sub

    '***************************************************************************
    Protected Sub AddWizard_FinishButtonClick(ByVal sender As Object, _
      ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) _
        Handles AddWizard.FinishButtonClick

        Dim EmployeeObj As New Employee
        EmployeeObj.FirstName = txtFirstName.Text
        EmployeeObj.LastName = txtLastName.Text
        EmployeeObj.TitleOfCourtesy = ddlTitleOfCourtesy.SelectedValue
        EmployeeObj.BirthDate = Data.StringToDate(txtBirthDate.Text)
        EmployeeObj.Address = txtAddress.Text
        EmployeeObj.City = txtCity.Text
        EmployeeObj.Region = Me.txtCountry.Text
        EmployeeObj.PostalCode = Me.txtPostalCode.Text
        EmployeeObj.Country = Me.txtCountry.Text
        EmployeeObj.HomePhone = Me.txtHomePhone.Text

        EmployeeObj.HireDate = Data.StringToDate(txtHireDate.Text)
        EmployeeObj.Title = ddlJobTitle.SelectedValue
        EmployeeObj.Extension = txtExtension.Text

        EmployeeObj.Notes = txtNotes.Text

        If Not EmployeeObj.Add() Then
            e.Cancel = True
            ClientScript.RegisterStartupScript(Me.GetType, "AddFail", _
             "alert('Could not add employee to database');", True)
        End If

    End Sub


End Class
