<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LoginLarge.ascx.vb" Inherits="LoginLarge_ascx" %>

<div style="width:255px; border:1px solid black;padding:5px;">
    <span style="font-family:Arial;font-size:10pt;">
        Please enter your username and password in the text boxes
        below, then click on the Login button.
    </span><br /><br />
    <span style="width:75px;font-family:Arial;font-size:10pt;">Username</span><asp:TextBox ID="txtUsername" Runat="server" Height="22px" Width="165px"></asp:TextBox><br />
    <span style="width:75px;font-family:Arial;font-size:10pt;">Password</span><asp:TextBox ID="txtPassword" Runat="server" Height="22px" Width="165px"></asp:TextBox><br />
    <span style="width:75px;font-family:Arial;font-size:10pt;">&nbsp;</span><asp:Button ID="btnLogin" Runat="server" Text="Login" /><br /><br />
    <asp:Label Runat=server id=ErrorMessage ForeColor="Red" Font-Size="10pt">[Error Message]</asp:Label>
</div>
