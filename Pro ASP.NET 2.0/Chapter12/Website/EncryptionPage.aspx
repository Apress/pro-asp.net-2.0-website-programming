<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="EncryptionPage.aspx.vb" Inherits="EncryptionPage" title="Encryption Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Encryption Demo</strong><br /><br />
    
    This page demonstrates the encryption capabilities of ASP.NET 2.0.  To use this page, enter 
    a value in the field below, choose an encryption algorithm, and click the "Execute" button.  
    A key and initialization vector are automatically generated for you and the encrypted value 
    appears in the Value field.  You will also see an output message at the bottom of the page 
    indicating success or failure of the encryption.<br /><br />
    
    You can then choose the decrypt option from the drop down list, click "Execute", and the value
    will be decrypted.  Make sure you are using the same algorithm, key, and initialization vector
    that you used to encrypt the data if you want it decrypted successfully.<br /><br />

    <span style="width:120px;">Value</span><asp:TextBox runat="server" ID="txtValue" Width="275px" /><br />
    <span style="width:120px;">Key</span><asp:TextBox runat="server" ID="txtKey" Width="275px" />
    <asp:Button runat="server" ID="btnGenKey" Text="Generate Key" Width="120px" /><br />
    <span style="width:120px;">Init. Vector</span><asp:TextBox runat="server" ID="txtIV" Width="275px" />
    <asp:Button runat="server" ID="btnGenIV" Text="Generate IV" Width="120px" /><br />
    <span style="width:120px;">Direction</span><asp:DropDownList runat="server" ID="ddlDirection" Width="100px" >
        <asp:ListItem>Encrypt</asp:ListItem>
        <asp:ListItem>Decrypt</asp:ListItem>
    </asp:DropDownList><br />
    <span style="width:120px;">Algorithm</span><asp:DropDownList runat="server" ID="ddlAlgorithm" Width="100px" >
        <asp:ListItem>DES</asp:ListItem>
        <asp:ListItem>RC2</asp:ListItem>
        <asp:ListItem>Rijndael</asp:ListItem>
        <asp:ListItem>TripleDES</asp:ListItem>        
    </asp:DropDownList><br />
    <span style="width:120px;">&nbsp;</span><asp:Button runat="server" ID="btnExecute" Text="Execute" Width="100px" />
    <br />
    <br />    
    <span style="width:120px;">Output:</span><asp:Label runat="server" ID="lblOutput" />
    </asp:Content>


