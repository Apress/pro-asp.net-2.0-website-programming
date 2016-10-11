<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="GenericErrorPageDemo.aspx.vb" Inherits="GenericErrorPageDemo_aspx" title="Generic Error Page Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Generic Error Page Demonstration</strong><br /><br />
    Clicking on the button below will cause an exception to occur that will not be handled.
    Since the exception is not handled, the exception will propogate up until ASP.NET redirects
    you to the default redirect page configured in the &lt;customErrors&gt; section of your 
    web.config file.<br /><br />
    <asp:Button Runat=server ID=btnCreateException Text="Throw an Unhandled Exception" OnClick="btnCreateException_Click" /></asp:Content>
