<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ThrowExceptionDemo.aspx.vb" Inherits="ThrowExceptionDemo_aspx" title="Throw Exception Demo" enableviewstate="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Throwing Exceptions Demo</strong><br /><br />
    You can throw your own exceptions by using the Throw keyword.  This page demonstrates how
    to throw different types of exceptions.  Click on a button to throw an exception.  The
    exception will be caught, and the page will display the exception information.
    <br />
    <br />
    <asp:Label ID="lblInfo" Runat="server" Text="No Exception was Thrown" ForeColor="DarkGreen"></asp:Label>
    <br /><br />
    <div>
        <asp:Button Runat=server ID=btnThrowException Text="Throw System.Exception" OnClick="btnThrowException_Click" /><br />
        <asp:Button Runat=server ID=btnArgumentNullException Text="Throw  System.ArgumentNullException" Height="24px" OnClick="btnArgumentNullException_Click" />
        <br />
        <asp:Button Runat=server ID=btnThrowIndexOutOfRangeException Text="Throw System.IndexOutOfRangeException" Height="24px" OnClick="btnIndexOutOfRangeException_click" />
    </div>
    
</asp:Content>
