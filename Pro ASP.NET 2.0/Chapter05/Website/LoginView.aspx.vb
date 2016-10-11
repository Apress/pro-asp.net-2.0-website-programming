
Partial Class LoginView_aspx
    Inherits Page

    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim chkEmployee As CheckBox = LoginView1.FindControl("chkEmployee")
            Dim chkEmployeeRO As CheckBox = LoginView1.FindControl("chkEmployeeRO")
            Dim chkExecutive As CheckBox = LoginView1.FindControl("chkExecutive")

            If Not chkEmployee Is Nothing Then chkEmployee.Checked = User.IsInRole("Employee")
            If Not chkEmployeeRO Is Nothing Then chkEmployeeRO.Checked = User.IsInRole("Employee (Read Only)")
            If Not chkExecutive Is Nothing Then chkExecutive.Checked = User.IsInRole("Executive")
        End If
    End Sub

    Protected Sub chkEmployee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Roles.RoleExists("Employee") Then Roles.CreateRole("Employee")
        Dim chkEmployee As CheckBox = DirectCast(sender, CheckBox)
        If chkEmployee.Checked Then
            Roles.AddUserToRole(User.Identity.Name, "Employee")
        Else
            Roles.RemoveUserFromRole(User.Identity.Name, "Employee")
        End If
    End Sub

    Protected Sub chkEmployeeRO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Roles.RoleExists("Employee (Read Only)") Then Roles.CreateRole("Employee (Read Only)")
        Dim chkEmployeeRO As CheckBox = DirectCast(sender, CheckBox)
        If chkEmployeeRO.Checked Then
            Roles.AddUserToRole(User.Identity.Name, "Employee (Read Only)")
        Else
            Roles.RemoveUserFromRole(User.Identity.Name, "Employee (Read Only)")
        End If
    End Sub

    Protected Sub chkExecutive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Roles.RoleExists("Executive") Then Roles.CreateRole("Executive")
        Dim chkEmployeeRO As CheckBox = DirectCast(sender, CheckBox)
        If chkEmployeeRO.Checked Then
            Roles.AddUserToRole(User.Identity.Name, "Executive")
        Else
            Roles.RemoveUserFromRole(User.Identity.Name, "Executive")
        End If
    End Sub
End Class
