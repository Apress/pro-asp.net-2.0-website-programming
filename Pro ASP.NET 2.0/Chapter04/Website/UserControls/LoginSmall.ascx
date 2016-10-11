<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LoginSmall.ascx.vb" Inherits="LoginSmall_ascx" %>
<div style="width:95px; padding:3px; border:1px solid black;">
    <span style="font-size: 8pt; font-family: arial;">Username</span><br />
    <asp:TextBox ID="txtUsername" Runat="server" Width="86px" Height="22px"></asp:TextBox><br />
    <span style="font-size: 8pt; font-family: arial;">Password</span><br />
    <asp:TextBox ID="txtPassword" Runat="server" Width="86px" Height="22px"></asp:TextBox><br />
    <asp:Button ID="btnLogin" Runat="server" Text="Login" Font-Size="8pt"/><br />
    <asp:Label Runat=server id=ErrorMessage ForeColor="Red" Font-Size="8pt">[Error Message]</asp:Label>
</div>