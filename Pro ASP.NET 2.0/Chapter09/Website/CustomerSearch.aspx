<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="CustomerSearch.aspx.vb" Inherits="CustomerSearch" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Customer Search Demo</strong><br /><br />
    
    Use the form below to execute a query.  You will see results displayed below using the reporting
    framework.  Notice that you switch back and forth between a simple and advanced form, and
    when the search results are displayed, you can easily page through and sort the values.<br /><br />

    <asp:PlaceHolder ID="MyReportPlaceHolder" runat="server" 
         EnableViewState=false /><br /><br />
    <asp:LinkButton ID="ToggleSearchForm" runat="server" EnableViewState=false />
    <br /><br />
    <asp:GridView ID="MyReportGrid" runat="server" AutoGenerateColumns=False
         EnableViewState=False Width="100%">
        <Columns>            
            <asp:BoundField DataField="CustomerID"   HeaderText="ID"      
                 SortExpression="CustomerID" />
            <asp:BoundField DataField="CompanyName"  HeaderText="Company" 
                 SortExpression="CompanyName" />
            <asp:BoundField DataField="ContactName"  HeaderText="Contact" 
                 SortExpression="ContactName" />
            <asp:BoundField DataField="ContactTitle" HeaderText="Title"   
                 SortExpression="ContactTitle" />
            <asp:BoundField DataField="Phone"        HeaderText="Phone"   
                 SortExpression="Phone" />                                    
        </Columns>
        <EmptyDataTemplate>
            Your search did not return any results
        </EmptyDataTemplate>
    </asp:GridView><br />
    <asp:PlaceHolder ID="MyPagingControls" runat="server" EnableViewState=false />
</asp:Content>