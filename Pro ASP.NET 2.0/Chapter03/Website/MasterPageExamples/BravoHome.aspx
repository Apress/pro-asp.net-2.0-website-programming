<%@ Page Language="VB" MasterPageFile="~/MasterPageExamples/Bravo.master" AutoEventWireup="false" CodeFile="BravoHome.aspx.vb" Inherits="BravoHome" title="Bravo Homepage" Theme="Bravo" %>
<%@ MasterType VirtualPath="~/MasterPageExamples/Bravo.master" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
    Welcome to the Bravo Homepage!<br /><br />
    
    <div style="font-weight:bold; text-decoration:underline;">Bravo Corporate</div>
    View the Bravo Corp <a href="PageLayoutExample.aspx">Master Page Layout Example</a>.<br />
    View the Bravo Corp <a href="ContactList.aspx">Contact List</a> (uses Bravo Corp Master Page).<br />
    <br />
    <div style="font-weight:bold; text-decoration:underline;">Marketing Department</div>
    View the Bravo Marketing Department <a href="Marketing/MarketingPageLayout.aspx">Nested Master Page Layout</a>.<br />
    View the Bravo Marketing Department <a href="Marketing/MarketingHome.aspx">Home Page</a> (uses Marketing nested master page).<br />
    View the Bravo Marketing Department <a href="Marketing/MarketingContactList.aspx">Contact List</a> (uses Marketing nested master page).<br />
    <br />
    <div style="font-weight:bold; text-decoration:underline;">Sales Department</div>
    View the Bravo Sales Department <a href="Sales/SalesPageLayout.aspx">Nested Master Page Layout</a>.<br />
    View the Bravo Sales Department <a href="Sales/SalesHome.aspx">Home Page</a> (uses Sales nested master page).<br />
    View the Bravo Sales Department <a href="Sales/SalesContactList.aspx">Contact List</a> (uses Sales nested master page).<br />
            
</asp:Content>

