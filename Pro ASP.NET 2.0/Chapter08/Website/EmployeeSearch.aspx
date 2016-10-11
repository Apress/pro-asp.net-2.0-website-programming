<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="EmployeeSearch.aspx.vb" Inherits="EmployeeSearch" title="Employee Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Simple and Advanced Search Demo</strong><br /><br />
    Use the following search form to enter your employee search criteria. You can toggle
    between the simple and advanced search form by clicking on the Advancd / Simple
    link below the form.<br />
    <br />
    <asp:PlaceHolder ID=phForm runat="server" />
    <br />
    <br />
    <asp:Button ID="btnDisplayQuery" runat="server" Text="Display Query" /><br /><br />
    <asp:LinkButton ID="lnkToggleForm" runat="server" EnableViewState="False"></asp:LinkButton>
    <br />
    <br />
    <b>Query Output:&nbsp; </b><asp:Label ID="lblQueryOutput" runat="server" EnableViewState="False"></asp:Label><br />
    <br />
    <div style="overflow: scroll; height:300px; width:600px; border:1px solid black;" >
        <asp:GridView ID="MyGrid" runat="server">
        </asp:GridView>
    </div>
</asp:Content>

