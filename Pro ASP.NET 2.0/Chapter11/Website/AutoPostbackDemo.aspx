<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="AutoPostbackDemo.aspx.vb" Inherits="AutoPostbackDemo" title="AutoPostBack Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>AutoPostBack Demo</strong><br /><br />
    When you have a file upload control on the page, remember to watch out for controls that
    have the AutoPostBack property set to true.  When an AutoPostBack fires, the file
    in the file upload control is sent back to the server, which may not be what you intended
    to happen.  The following page demonstrates this concept.<br /><br />
    
    Browse to a file using the "Upload" button, then select an item from the drop down list.  
    The drop down list has the AutoPostBack property set to true.  Notice that the file disappears 
    after the page posts back.<br /><br />

    <asp:FileUpload runat="server" ID="FileUploader" /><br />
    
    <asp:DropDownList runat="server" ID="ddlOptions" AutoPostBack="true">
        <asp:ListItem>Item #1</asp:ListItem>
        <asp:ListItem>Item #2</asp:ListItem>
        <asp:ListItem>Item #3</asp:ListItem>
        <asp:ListItem>Item #4</asp:ListItem>
    </asp:DropDownList><br />
    
    <asp:Button runat="server" ID="btnUpload" Text="Upload" /><br /><br />
    
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
</asp:Content>

