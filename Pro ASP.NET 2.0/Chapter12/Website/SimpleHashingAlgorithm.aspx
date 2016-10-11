<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="SimpleHashingAlgorithm.aspx.vb" Inherits="SimpleHashingAlgorithm" title="Simple Hashing Algorithm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Simple Hashing Algorithm</strong><br /><br />
    
    The simple hashing algorithm takes a string and adds up the Asc() function values of each 
    invidial character to acquire the "hash" value.  This is a simple, or weak, hashing 
    algorithm but it demonstrates how hashing works.<br /><br />

    <span style="width:80px;">Value to Hash</span><asp:TextBox runat="server" ID="txtValueToHash" /><asp:Button runat="server" ID="btnHashValue" Text="Run Hash Algorithm" />
    <br />    
    <span style="width:80px;">Hashed Value:</span><asp:Label runat="server" ID="lblHashedValue" />
    
</asp:Content>

