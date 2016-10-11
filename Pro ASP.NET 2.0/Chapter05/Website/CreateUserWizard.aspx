<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="CreateUserWizard.aspx.vb" Inherits="CreateUserWizard_aspx" title="CreateUserWizard Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>CreateUserWizard Control</strong><br /><br />
    The CreateUserWizard control displays fields that the user can fill out to create an account.  
    Please enter user information into the form below to create an account.  Upon creation, the 
    system sends an email to the user informing them that they have a new user account.<br /><br />
    
    <asp:CreateUserWizard ID="CreateUserWizard1" Runat="server" ContinueDestinationPageUrl="~/Login.aspx" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" >
        <MailDefinition BodyFileName="~/EmailContent.txt" From="Damon&lt;damon@nowhere.com&gt;"
            Subject="Test">
        </MailDefinition>
        <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
            ForeColor="White" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
    <asp:Label runat="server" ID="lblError" Visible="false" EnableViewState=false /></asp:Content>
