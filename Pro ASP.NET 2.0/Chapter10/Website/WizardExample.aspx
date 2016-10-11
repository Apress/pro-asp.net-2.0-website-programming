<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="WizardExample.aspx.vb" Inherits="WizardExample" title="Advanced Wizard Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">

    <strong>Advanced Wizard Example</strong><br /><br />
    This page contains a bit more advanced Wizard control that demonstrates how to validate a step
    before moving on, how to skip a step based on data from another step, how to remove a 
    step completely, and how to allow users to go back to a previous step but not forward
    to a future step.<br /><br />
    
    <div style="padding:20px;">
        <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" Width="350px" Height="150px" CancelDestinationPageUrl="http://www.google.com" DisplayCancelButton="True">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">               
                    <div style="padding:10px;">
                        <span style="text-decoration: underline"><strong>This is the 1st Step</strong></span><br />
                        <br />
                        Welcome to the first step in the wizard.&nbsp; You can only move to a subsequent
                        step if you check the following checkbox:<br />
                        <br />
                        <asp:CheckBox ID="chkStep1IsValid" runat="server" Text="Mark Step 1 as Valid" />
                        <br />
                        <asp:CheckBox ID="chkSkipStep2" runat="server" Text="Skip Step 2" />
                        <br />
                        <asp:CheckBox ID="chkRemoveStep2" runat="server" Text="Remove Step 2" />
                        <br />
                        <br />
                        FYI: You can either select Skip Step 2 or Remove Step 2.&nbsp; Selecing both causes
                        Step 2 to be removed and Skip Step 2 to be unchecked.</div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                    <div style="padding:10px;">
                        <strong><span style="text-decoration: underline">This is the 2nd Step</span></strong><br />
                        <br />
                        This represents the middle steps in the wizard. You can have more than one middle
                        step.&nbsp; &nbsp;It displays a next and a previous button.</div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep4" runat="server" Title="Step 3">
                    <div style="padding:10px;">
                        <strong><span style="text-decoration: underline">This is the 3rd Step</span></strong><br />
                        <br />
                        This represents the middle steps in the wizard. You can have more than one middle
                        step.&nbsp; &nbsp;It displays a next and a previous button.</div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep5" runat="server" Title="Step 4" EnableTheming="True">
                    <div style="padding:10px;">
                        <strong><span style="text-decoration: underline">This is the 4th Step</span></strong><br />
                        <br />
                        This represents the middle steps in the wizard. You can have more than one middle
                        step.&nbsp; &nbsp;It displays a next and a previous button.</div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep6" runat="server" Title="Step 5">
                    <div style="padding:10px;">
                        <strong><span style="text-decoration: underline">This is the 5th Step</span></strong><br />
                        <br />
                        This represents the middle steps in the wizard. You can have more than one middle
                        step.&nbsp; &nbsp;It displays a next and a previous button.</div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep7" runat="server" Title="Step 6">
                    <div style="padding:10px;">
                        <strong><span style="text-decoration: underline">This is the 6th Step</span></strong><br />
                        <br />
                        This represents the middle steps in the wizard. You can have more than one middle
                        step.&nbsp; &nbsp;It displays a next and a previous button.</div>
                </asp:WizardStep>                                                                
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 7">
                    <div style="padding:10px;">
                        <strong><span style="text-decoration: underline">This is the 7th Step</span></strong><br />
                        <br />
                        This is the last step in the wizard.&nbsp; Notice that you can move back using the
                        previous button or "Finish" the wizard.</div>
                </asp:WizardStep>
            </WizardSteps>
            <StepStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" VerticalAlign="Top" />
            <SideBarStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="100px" VerticalAlign="Top" />
            <NavigationStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />            
<SideBarTemplate>
    <asp:Label ID="lblTitle" runat="server" BackColor="Gainsboro" Font-Bold="True" ForeColor="Black"
        Text="Wizard Steps" Width="100%"></asp:Label>
    <asp:DataList ID="SideBarList" runat="server" 
      OnItemDataBound="SideBarList_ItemDataBound">
        <SelectedItemStyle Font-Bold="True" />
        <ItemTemplate>
            &nbsp;&nbsp;<asp:LinkButton ID="SideBarButton" runat="server"/>
        </ItemTemplate>
    </asp:DataList>
</SideBarTemplate>

        </asp:Wizard>
        <br />
        &nbsp;<br />
    </div>
</asp:Content>

