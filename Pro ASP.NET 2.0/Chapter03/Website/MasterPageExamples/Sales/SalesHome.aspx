<%@ Page Language="VB" MasterPageFile="~/MasterPageExamples/Sales/BravoSales.master" AutoEventWireup="false" CodeFile="SalesHome.aspx.vb" Inherits="SalesHome" title="Sales Home" Theme="Bravo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SalesQuickLinks" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SalesMainContent" Runat="Server">
    Welcome to the Sales homepage, where you can find lots of sales information!<br /><br />
    View the Bravo Sales Department <a href="SalesContactList.aspx">Contact List</a> (uses Sales nested master page).<br />    
</asp:Content>

