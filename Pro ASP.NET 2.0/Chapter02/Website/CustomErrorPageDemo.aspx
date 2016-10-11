<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="CustomErrorPageDemo.aspx.vb" Inherits="CustomErrorPageDemo_aspx" title="Custom Error Page Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Custom Error Pages</strong><br /><br />
    You can define a redirection location for specific error types that occur on the server.  This
    page demonstrates how to redirect a user to a custom 404 error page when the user attempts to 
    access a resource that does not exist.  The link below points to a page that does not exist on 
    this site, so a 404 error will be generated when you try to go there.<br /><br />
    <a href="SomePageThatDoesNotExist.html">Click on this Broken Link</a>
</asp:Content>
