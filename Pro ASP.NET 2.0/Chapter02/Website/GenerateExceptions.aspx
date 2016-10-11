<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="GenerateExceptions.aspx.vb" Inherits="GenerateExceptions" title="Generate Exceptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Generate Exceptions</strong><br /><br />
    Use the following form to generate new exceptions.  You can opt to create exceptions with up to 5 inner exceptions.  The message property defines the exception message of the exception.  <br />
    <br />
    Number of Exceptions to Generate:<br />
    <asp:DropDownList runat="server" ID="ddlCount" Width="350px">
        <asp:ListItem Value="1">Generate Exception (No Inner Exceptions)</asp:ListItem>
        <asp:ListItem Value="2">Generate Exception (w/1 Inner Exception)</asp:ListItem>
        <asp:ListItem Value="3">Generate Exception (w/2 Inner Exception)</asp:ListItem>
        <asp:ListItem Value="4">Generate Exception (w/3 Inner Exception)</asp:ListItem>
        <asp:ListItem Value="5">Generate Exception (w/4 Inner Exception)</asp:ListItem>
        <asp:ListItem Value="6">Generate Exception (w/5 Inner Exception)</asp:ListItem>
    </asp:DropDownList><br />
    <br />
    Message:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMessage"
        ErrorMessage="Message is Required"> (Required)</asp:RequiredFieldValidator><br />
    <asp:TextBox runat=server ID=txtMessage Width="350px"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnGenerate" runat="server" Text="Generate Exception(s)" /></asp:Content>

