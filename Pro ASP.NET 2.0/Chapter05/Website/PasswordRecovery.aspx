<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="PasswordRecovery.aspx.vb" Inherits="PasswordRecovery_aspx" title="PasswordRecovery Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">

    <strong>Password Recovery Control</strong><br /><br />
    The PasswordRecovery control allows users to retrieve their forgotten password.  To retrieve a password, users can enter their 
    name and (optionally) their password recovery question and answer.  The application then emails the user a new automatically
    generated password.<br /><br />
    
    <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px;">
        <asp:PasswordRecovery ID="PasswordRecovery1" Runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
            <UserNameTemplate>
                <table cellpadding="1" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" border="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        Forgot Your Password?</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        Enter your User Name to receive your password.</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label Runat="server" AssociatedControlID="UserName" ID="UserNameLabel">User Name:</asp:Label></td>
                                    <td>
                                        <asp:TextBox Runat="server" ID="UserName"></asp:TextBox>
                                        <asp:RequiredFieldValidator Runat="server" ControlToValidate="UserName" ValidationGroup="PasswordRecovery1"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ID="UserNameRequired">
                                            *</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button Runat="server" Text="Submit" ValidationGroup="PasswordRecovery1" CommandName="Submit"
                                            ID="Button" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="color: Red;">
                                        <asp:Literal Runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </UserNameTemplate>
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <SuccessTextStyle Font-Bold="True" ForeColor="#5D7B9D" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <SubmitButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <MailDefinition From="NoReply@localhost.com" Subject="Password Recovery">
            </MailDefinition>
     </asp:PasswordRecovery>
     
     <asp:Label runat="server" ID="lblError" Visible="false" EnableViewState=false /></asp:Content>
    
