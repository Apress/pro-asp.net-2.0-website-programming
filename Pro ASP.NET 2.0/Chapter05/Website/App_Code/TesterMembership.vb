Imports Microsoft.VisualBasic

Public Class TesterMembership
    Inherits RoleProvider

    Public Overrides Sub Initialize(ByVal name As String, ByVal config As System.Collections.Specialized.NameValueCollection)

    End Sub

    Public Overrides Sub AddUsersToRoles(ByVal usernames() As String, ByVal roleNames() As String)

    End Sub

    Public Overrides Property ApplicationName() As String
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Overrides Sub CreateRole(ByVal roleName As String)

    End Sub

    Public Overrides Function DeleteRole(ByVal roleName As String, ByVal throwOnPopulatedRole As Boolean) As Boolean

    End Function

    Public Overrides Function FindUsersInRole(ByVal roleName As String, ByVal usernameToMatch As String) As String()

    End Function

    Public Overrides Function GetAllRoles() As String()

    End Function

    Public Overrides Function GetRolesForUser(ByVal username As String) As String()

    End Function

    Public Overrides Function GetUsersInRole(ByVal roleName As String) As String()

    End Function

    Public Overrides Function IsUserInRole(ByVal username As String, ByVal roleName As String) As Boolean

    End Function

    Public Overrides Sub RemoveUsersFromRoles(ByVal usernames() As String, ByVal roleNames() As String)

    End Sub

    Public Overrides Function RoleExists(ByVal roleName As String) As Boolean

    End Function

End Class