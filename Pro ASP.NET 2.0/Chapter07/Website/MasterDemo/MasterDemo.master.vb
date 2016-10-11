
Partial Class MasterDemo
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim x As String = WebPartManager1.Personalization.ProviderName
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender

        With WebPartManager1


        End With


        'Determine whether or not to show the toggle scope button
        If Me.WebPartManager1.Personalization.CanEnterSharedScope Then
            Me.btnChangeScope.Visible = True
            Me.lblChangeScopeSeperator.Visible = True
        End If

        'Initially, show all web part zone cells and hide the others
        cellZoneLeft.Visible = True
        cellZoneRight.Visible = True
        ModeEdit.Visible = False
        ModeCatalog.Visible = False

        'Determine the page mode and make adjustments to zone cells as necessary
        If WebPartManager1.DisplayMode Is WebPartManager.BrowseDisplayMode Then

            'Hide unused zone cells
            cellZoneLeft.Visible = CBool(zoneLeft.WebParts.Count > 0)
            cellZoneRight.Visible = CBool(zoneRight.WebParts.Count > 0)

        ElseIf WebPartManager1.DisplayMode Is WebPartManager.CatalogDisplayMode Then
            ModeCatalog.Visible = True

        ElseIf WebPartManager1.DisplayMode Is WebPartManager.EditDisplayMode _
         And Not WebPartManager1.SelectedWebPart Is Nothing Then
            ModeEdit.Visible = True

        ElseIf WebPartManager1.DisplayMode Is WebPartManager.DesignDisplayMode Then
            'Do nothing

        End If

        'Determine text of the change scope button
        Select Case WebPartManager1.Personalization.Scope
            Case PersonalizationScope.Shared
                Me.btnChangeScope.Text = "Change to Personal Scope"
            Case PersonalizationScope.User
                Me.btnChangeScope.Text = "Change to Shared Scope"
        End Select

    End Sub

    Protected Sub btnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As LinkButton = DirectCast(sender, LinkButton)

        Select Case btn.CommandArgument
            Case "Browse"
                WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode
            Case "Catalog"
                WebPartManager1.DisplayMode = WebPartManager.CatalogDisplayMode
            Case "Design"
                WebPartManager1.DisplayMode = WebPartManager.DesignDisplayMode
            Case "Edit"
                WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode
            Case "Scope"
                If WebPartManager1.Personalization.CanEnterSharedScope Then
                    WebPartManager1.Personalization.ToggleScope()
                End If
            Case "Connect"
                WebPartManager1.DisplayMode = WebPartManager.ConnectDisplayMode

        End Select
    End Sub


End Class

