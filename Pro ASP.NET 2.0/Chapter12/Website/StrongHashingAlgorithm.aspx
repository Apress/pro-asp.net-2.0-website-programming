<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="StrongHashingAlgorithm.aspx.vb" Inherits="StrongHashingAlgorithm" title="Strong Hashing Algorithm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Strong Hashing Algorithms</strong><br /><br />
    
    The algorithms demonstrated on this page are part of the .NET Framework and are considered
    strong hashing algorithms because two values are highly unlikely to produce the same hash.  Enter
    a value that you want hashed, choose an algorithm from the drop down, then click on the 
    "Run Hash Algorithm" button to see the resulting hash value.  <br /><br />
    
     Notice that when you run the hashing algorithm against a value , you always receive the
     same hash from the value.<br /><br />
    
    <span style="width:80px;">Value to Hash</span><asp:TextBox runat="server" ID="txtValueToHash" /><br />
    <span style="width:80px;">Algorithm</span><asp:DropDownList runat="server" ID="ddlAlgorithm" >
        <asp:ListItem>MD5</asp:ListItem>
        <asp:ListItem>SHA1</asp:ListItem>
        <asp:ListItem>SHA256</asp:ListItem>
        <asp:ListItem>SHA384</asp:ListItem>
        <asp:ListItem>SHA512</asp:ListItem>
    </asp:DropDownList><br />
    <span style="width:80px;">&nbsp;</span><asp:Button runat="server" ID="btnHashValue" Text="Run Hash Algorithm" />
    <br />    
    <span style="width:80px;">Hashed Value:</span><asp:Label runat="server" ID="lblHashedValue" /></asp:Content>

