
Partial Class CreateUserWizard_aspx
    Inherits Page

    '***************************************************************************
    Sub CreateUserWizard1_CreatedUser(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateUserWizard1.CreatedUser

        'Make sure the role exists before you create it...
        'Most of the time you would manually setup roles in the database, but since this
        'is an example application, we do it in code for the sake of simplicity
        If Not Roles.RoleExists("Customer") Then Roles.CreateRole("Customer")

        Roles.AddUserToRole(CreateUserWizard1.UserName, "Customer")        

    End Sub


    Protected Sub CreateUserWizard1_SendMailError(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SendMailErrorEventArgs) Handles CreateUserWizard1.SendMailError
        lblError.Text = String.Format("<BR><BR>The following error occured while trying to create the user account: <br/><br /><b>Error Type:</b> {0}<br /><b>Error Message:</b> {1}<br /><br /><font style=""color:darkred;text-decoration:underline;font-weight:bold;"">Note About SMTP Settings</font><BR> For email notifications to work on this page you must have a valid SMTP server setup in the web.config.  If you are running a local SMTP server via IIS, then you must also enable relaying from the local machine.  " & _
                                      "To do this, open the IIS management console, right click on your SMTP server and select properties from the drop down menu.  Click on the <b>Access</b> tab.  Click on the <b>Relay</b> button in the Relay Restrictions section.  The Relay Restrictions dialog appears.  Make sure <b>Only the list below</b> option is selected.  Click the <b>Add</b> button.  " & _
                                      "Select the <b>Single computer</b> option.  Type in 127.0.0.1 (or your local machine's IP address).  Click <b>OK<b/> on all the open windows and close down the IIS management console. ", e.Exception.GetType.ToString(), e.Exception.Message)
        lblError.Visible = True
        e.Handled = True
    End Sub

End Class
