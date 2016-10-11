<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login_aspx" title="Login Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">&nbsp;

    <strong>Login Control</strong><br /><br />
    The Login control allows users to login to a website by entering their username and password.  
    It can also display links for users to create a new account or retrieve a forgotten password.
    If you have not already done so, please use the <a href=CreateUserWizard.aspx>CreateUserWizard</a> 
    page to create a new account, then you can login to that account from this page.<br /><br />
    
    <asp:Login ID="MyLogin" Runat="server" DestinationPageUrl="~/LoginView.aspx" CreateUserText="Create New Account" PasswordRecoveryText="Forgot Password" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#333333" CreateUserUrl="~/CreateUserWizard.aspx" PasswordRecoveryUrl="~/PasswordRecovery.aspx">
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TextBoxStyle Font-Size="0.8em" />
        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
    </asp:Login>
    
    <br /><br />
    
    <asp:LoginView ID="LoginView1" Runat="server">
        <LoggedInTemplate>
            You are logged in as <asp:LoginName ID="LoginName1" Runat="server" />, so 
            you do not need to login again!  Use the navigation menu at right to visit
            another page.
        </LoggedInTemplate>
        <AnonymousTemplate>
            You are not logged in.  Please login using the Login control above.
        </AnonymousTemplate>
    </asp:LoginView>
    
</asp:Content>
