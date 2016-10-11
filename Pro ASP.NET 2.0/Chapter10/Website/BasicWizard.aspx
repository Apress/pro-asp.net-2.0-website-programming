<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="BasicWizard.aspx.vb" Inherits="BasicWizard" title="Basic Wizard Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Basic Wizard Example</strong><br /><br />
    
    This page demonstrates the basics of building steps into a web based wizard and the events that
    fire as you move through the wizard.  Look at the bottom of the page to see which events have fired 
    during the course of the request.<br /><br />
    
    YOu will also see a "phantom" step which occurs when you fail to put a title or ID into a WizardStep 
    element.  You willwant to avoid phantom steps because they can confuse your users.<br /><br />
    
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" Height="150px" Width="400px" DisplayCancelButton="True">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">               
                    <div style="padding:10px;">
                        <b><u>This is the 1st Step</u></b><br /><br />
                        This is the first step in the Wizard.  Notice that this step only has a "Next" button.
                    </div>
                </asp:WizardStep>
                <asp:WizardStep runat="server">               
                    <div style="padding:10px;">
                        <b><u>This is a Phantom Step</u></b><br /><br />
                        Notice there is no ID or Title in the definition for this step so it does not 
                        appear in the left navigation.  You should avoid this situation because it can 
                        confuse your users.  Always make sure to include a Title and an ID.
                    </div>
                </asp:WizardStep>                
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">               
                    <div style="padding:10px;">
                        <b><u>This is the 2nd Step</u></b><br /><br />
                        This represents the middle steps in the wizard.  You can have more than one 
                        middle step.  It displays a Next and a Back button.
                    </div>
                </asp:WizardStep>                
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">               
                    <div style="padding:10px;">
                        <b><u>This is the 3rd Step</u></b><br /><br />
                        This is the last step in the wizard. Notice that you can move back using 
                        the Previous button or Finish the wizard
                    </div>
                </asp:WizardStep>                
            </WizardSteps>
            <StepStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" VerticalAlign="Top" />
            <SideBarStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="100px" VerticalAlign="Top" />
            <NavigationStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />            
    <SideBarTemplate>
        <div style="padding-left:10px;">
            <asp:DataList ID="SideBarList" runat="server">
                <SelectedItemStyle Font-Bold="True" />
                <ItemTemplate>
                    <asp:LinkButton ID="SideBarButton" runat="server"></asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </SideBarTemplate>
        </asp:Wizard>      
    
    <br />
    <asp:Literal runat="server" ID="litEvents" EnableViewState="false" />
    
</asp:Content>