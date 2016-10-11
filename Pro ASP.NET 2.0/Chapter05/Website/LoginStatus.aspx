<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="LoginStatus.aspx.vb" Inherits="LoginStatus_aspx" title="LoginStatus Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>LoginStatus Control</strong><br /><br />
    The LoginStatus control displays a link to the login page if the current user has not yet logged on, a link
    that logs the user out of the system if the user has already logged on.  Below you will find an example
    of the LoginStatus control.<br /><br />

    <asp:LoginStatus ID="LoginStatus1" Runat="server" />
    
</asp:Content>
