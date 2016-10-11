<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ClickCounter.ascx.vb" Inherits="ClickCounter" %>
<asp:Button ID="btnClickMe" runat="server" Text="Click Me!" /><br />
The "Click Me" Button has been clicked
<asp:Label ID="lblClickCount" runat="server"></asp:Label>&nbsp;times.<br />
<asp:LinkButton ID="linkReset" runat="server">Reset Counter</asp:LinkButton>
