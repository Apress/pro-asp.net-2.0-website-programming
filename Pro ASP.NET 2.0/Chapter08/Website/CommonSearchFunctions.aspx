<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="CommonSearchFunctions.aspx.vb" Inherits="CommonSearchFunctions" title="Common Search Functions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong><span style="text-decoration: underline">Date Range Demo</span></strong><br />
    
    The following form demonstrates the CreateDateRange function. Enter
    as much or as little of the information you want below, then click the "Generate
    Query" button. A SQL query will be generated using the information you entered.<br /><br />
    
    <span style="width:100px;">Customer ID:</span><asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox><br />
    <span style="width:100px;">Start Date:</span><asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox><br />
    <span style="width:100px;">End Date:</span><asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox><br />
    <span style="width:100px;">&nbsp;</span><asp:Button ID="btnDateRangeQuery" runat="server" Text="Generate Query" /><br /><br />
    
    <asp:Label ID="lblDateRangeQuery" runat="server"></asp:Label><br /><br /><br />
    
    <strong><span style="text-decoration: underline">Keyword Demo</span></strong><br />
    The following form demonstrates the CreateDateRange function.&nbsp; Enter
    as much or as little of the information you want below, then click the "Generate
    Query" button.&nbsp; A SQL query will be generated using the information you entered.<br />
    <br />
    <span style="width:100px;">Keywords:</span><asp:TextBox ID="txtKeywords" runat="server"></asp:TextBox><br />
    <span style="width:100px;">&nbsp;</span><asp:Button ID="btnKeywords" runat="server" Text="Generate Query" /><br />
    <br />
    <asp:Label ID="lblKeywordQuery" runat="server"></asp:Label></asp:Content>

