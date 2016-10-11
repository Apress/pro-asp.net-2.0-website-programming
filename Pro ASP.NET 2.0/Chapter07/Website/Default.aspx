<%@ Page Language="VB" MasterPageFile="~/Bravo.master" AutoEventWireup="false" CodeFile="Default.aspx.vb"
    Inherits="_Default" Title="Untitled Page" Theme="Bravo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="padding-left: 10px;">
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <br />
                <div style="width:550px;">
                Welcome to the Bravo Corp Employee Portal.  Please login to the portal using
                one of the user's listed below.  You will then be taken to your personal portal
                page where you can see ASP.NET 2.0 Web Parts in action.<br /><br />
                
                When you get to your portal page, use the links in the upper right hand side
                of the screen to change into the various display modes:  Browse, Design, Edit, Catalog,
                and Connection display modes.  Also remember that you can modify shared scope using
                "bob" because that account is in the admin role.<br /><br />
                
                </div>
                
                
                <table cellpadding="5" cellspacing="0" style="border:1px solid black; width:300px;" >
                    <tr>
                        <td style="font-weight: bold; color: white; background-color: #0000AA">Username</td>
                        <td style="font-weight: bold; color: white; background-color: #0000AA">Password</td>
                        <td style="font-weight: bold; color: white; background-color: #0000AA">Roles</td>
                    </tr>
                    <tr>
                        <td>bob</td>
                        <td>bobpassword01!</td>
                        <td>admin</td>
                    </tr>
                    <tr>
                        <td>mary</td>
                        <td>marypassword01!</td>
                        <td>-</td>
                    </tr>
                    <tr>
                        <td>jane</td>
                        <td>janepassword01!</td>
                        <td>-</td>
                    </tr>                                        
                </table>
                
                <br /><br />
                
                <asp:Login ID="UserLogin" runat="server" BorderColor="#000000" BorderPadding="4"
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#333333"
                    DestinationPageUrl="~/BravoPortal/Portal.aspx">
                    <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" ForeColor="#284E98" />
                    <LayoutTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="2" cellspacing="0" style="color: #333333; font-family: Verdana;
                                        font-size: 10pt;">
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; color: white; background-color: #0000AA">
                                                Bravo Portal Login</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="UserLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="UserLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: red">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                                    BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana"
                                                    ForeColor="#284E98" Text="Log In" ValidationGroup="UserLogin" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                </asp:Login>
            </AnonymousTemplate>
            <LoggedInTemplate>
                You have already logged in!
            </LoggedInTemplate>
        </asp:LoginView>
        <br />
        <br />
        &nbsp; &nbsp;<br />
        &nbsp;</div>
</asp:Content>
