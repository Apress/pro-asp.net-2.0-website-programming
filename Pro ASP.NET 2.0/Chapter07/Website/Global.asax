<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        
        CreateRoleIfDoesNotExist("admin")
        
        If CreateUserIfDoesNotExist("bob", "bobpassword01!", "bob@nowhere.com") Then
            Roles.AddUserToRole("bob", "admin")
        End If
        
        CreateUserIfDoesNotExist("mary", "marypassword01!", "mary@nowhere.com")
        CreateUserIfDoesNotExist("jane", "janepassword01!", "jane@nowhere.com")                       
        
    End Sub
    
    Function CreateUserIfDoesNotExist(ByVal username As String, ByVal password As String, ByVal email As String) As Boolean
        
        Dim search As MembershipUser = Membership.GetUser(username)
        If search Is Nothing Then
            Membership.CreateUser(username, password, email, "What does 1+1 equal?", "2", True, Nothing)
            Return True
        End If
        Return False
        
    End Function
    
    Sub CreateRoleIfDoesNotExist(ByVal roleName As String)
        If Not Roles.RoleExists(roleName) Then
            Roles.CreateRole(roleName)
        End If
    End Sub
       
</script>