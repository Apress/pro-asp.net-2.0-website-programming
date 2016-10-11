<%@ Page Language="VB" MasterPageFile="~/MasterPageExamples/Sales/BravoSales.master" AutoEventWireup="false" CodeFile="SalesPageLayout.aspx.vb" Inherits="SalesPageLayout" title="Bravo Sales Master" Theme="Bravo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SalesQuickLinks" Runat="Server">
    <span style="border: 1px dashed black; padding:3px;">Quick Links</span>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SalesMainContent" Runat="Server">
    <div style="font-size:50pt; border:1px dashed black; width:100%; height:400px;">
        <br /><br />
        <center>Content</center>
    </div>  
    <br />
    This page outlines the layout of the Sales Department nested master page.  There are two ContentPlaceHolders denoted by the 
    dashed outlines:  the Content area allows you to define content for the page, and the Quick Links area allows you to add 
    context-sensitive links to the page.  Notice that there are already Sales-specific content quick links defined directly 
    in the nested master page that appear on every Sales page.<br /><br />
    <a href="../BravoHome.aspx">Go back to the Bravo Homepage.</a>
</asp:Content>

