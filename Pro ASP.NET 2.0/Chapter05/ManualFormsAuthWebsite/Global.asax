<%@ Application Language="VB" %>
<%@ Import Namespace="System.Security.Principal" %>

<script runat="server">
     
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
    '***************************************************************************
    Protected Sub Application_AuthenticateRequest(ByVal sender As Object, _
      ByVal e As System.EventArgs)
        
        'Declare variables
        Dim authCookie As HttpCookie
        Dim authTicket As FormsAuthenticationTicket
        Dim roles() As String        
        Dim identity As FormsIdentity
        Dim principal As GenericPrincipal
        
        'Acquire the authorization cookie
        authCookie = Request.Cookies(FormsAuthentication.FormsCookieName)
        
        'Only process the authorization cookie if it is available
        If Not authCookie Is Nothing Then
            
            'Decrypt authorization cookie to acquire the authentication ticket
            authTicket = FormsAuthentication.Decrypt(authCookie.Value)
            
            'Make sure the authentication ticket has not expired
            If Not authTicket.Expired Then
            
                'Parse the pipe-delimited role string into a string array
                If Not authTicket.UserData = Nothing Then
                    roles = authTicket.UserData.Trim.Split("|")
                Else
                    roles = New String() {}
                End If
                
                'Create the principal object and assign it to Context.User
                identity = New FormsIdentity(authTicket)
                principal = New GenericPrincipal(identity, roles)
                Context.User = principal
                
            End If
                                    
        End If
                
    End Sub
    
</script>