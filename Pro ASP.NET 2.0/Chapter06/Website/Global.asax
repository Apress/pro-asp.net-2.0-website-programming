<%@ Application Language="VB" %>

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
    Sub Profile_MigrateAnonymous(ByVal sender As Object, ByVal e As ProfileMigrateEventArgs)
        
        Dim AnonymousProfile As ProfileCommon = Profile.GetProfile(e.AnonymousID)
        
        if AnonymousProfile.ShoppingCart is Nothing then Exit Sub 
        If Profile.ShoppingCart is Nothing then Profile.ShoppingCart = New ShoppingCart.Cart()
        
        For Each p as ShoppingCart.Product in AnonymousProfile.ShoppingCart
            Profile.ShoppingCart.AddProduct(P)
        Next                   
                
    End Sub

    '***************************************************************************
    Sub Profile_MigrateAnonymousExample(ByVal sender As Object, ByVal e As ProfileMigrateEventArgs)
        
        Dim AnonymousProfile As ProfileCommon = Profile.GetProfile(e.AnonymousID)
        
        'Add the TotalPageHits Values Together    
        Profile.TotalPageHits += AnonymousProfile.TotalPageHits
        
        'Replace LastAdDate If More Recent
        If Profile.LastAdDate < AnonymousProfile.LastAdDate Then
            Profile.LastAdDate = AnonymousProfile.LastAdDate
        End If
            
    End Sub

    
    
       
</script>