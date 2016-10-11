<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="LoginName.aspx.vb" Inherits="LoginName_aspx" title="LoginName Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">

    <strong>LoginName Control</strong><br /><br />
    The LoginName control displays the user name of the currently logged in user, or 
    nothing (i.e. an empty string) if the current user has not yet logged into the 
    system.  You can also specify a format string and the control will inject the user 
    name in the format string at the appropriate location.  See the HTML markup of this 
    page to see the definition of the format string.  Below you will find an example of 
    the LoginName control<br /><br />
    
    Also, if there is nothing displayed below it means that you haven't logged in.<br /><br />

    <asp:LoginName ID="LoginName1" Runat="server" FormatString="You are logged in as {0}." />
</asp:Content>
