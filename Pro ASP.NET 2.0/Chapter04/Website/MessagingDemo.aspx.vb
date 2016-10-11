Imports Messaging

Partial Class MessagingDemo_aspx
    Inherits Page

    '***********************************************************************************************
    Sub btnShowMessages_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'Setup SkinFileName Property
        If Me.rbIcons.Checked Then
            Me.msgHandler.SkinFileName = "PageMessageIcons.ascx"
        ElseIf Me.rbJava.Checked Then
            Me.msgHandler.SkinFileName = "PageMessageJScriptAlert.ascx"
            Me.msgHandler.AllowSetFocus = False
        End If

        'Setup Messages
        If Me.rbMsgSystem.Checked Then
            PageMessageControl.AddSystemMessage("This is a system message!")
        ElseIf Me.rbMsgError.Checked Then
            msgHandler.AddErrorMessage("An error occured!")
        ElseIf Me.rbMsgPageAndError.Checked Then
            msgHandler.AddMessage("This is a page message!")
            msgHandler.AddMessage("This is a second page message!")
            msgHandler.AddErrorMessage("An error occured!")
            msgHandler.AddErrorMessage("And another error occured!")
        ElseIf Me.rbMsgPageMultiple.Checked Then
            msgHandler.AddMessage("This is the first message.")
            msgHandler.AddMessage("And this is the second message.")
        ElseIf Me.rbMsgErrorMultiple.Checked Then
            msgHandler.AddErrorMessage("This is the first error.")
            msgHandler.AddErrorMessage("And this is another error message.")
        Else
            msgHandler.AddMessage("This is a page message!")
        End If

    End Sub

    '***********************************************************************************************
    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'This ensures that the system messages added from this page
        'is cleared before moving on.  Usually, you would NOT clear
        'system messages on a Page Unload, but this is a DEMO.
        PageMessageControl.ClearSystemMessages()
    End Sub

End Class
