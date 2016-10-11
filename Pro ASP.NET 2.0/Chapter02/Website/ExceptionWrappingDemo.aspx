<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ExceptionWrappingDemo.aspx.vb" Inherits="ExceptionWrappingDemo_aspx" title="Exception Wrapping Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Exception Wrapping Demo</strong><br /><br />
    
    Each exception object has an InnerException property that can reference another exception object. 
    This is useful for chaining related exceptions together or for wrapping a nondescript or confusing 
    exception object in another more descriptive exception object.<br /><br />
    
    In the following example, the code iterates through a series of comma seperated integer values.  
    If you do not provide a valid integer value in the comma seperated list, the code generates an 
    exception.  That exception is then "wrapped" in another exception that contains a more user-friendly
    error message.<br /><br />
    
    Enter a list of numbers seperated by a comma, and also enter a number spelled out so an error is 
    generated (i.e. 1,2,3,4,five).  Then click on the "Create Wrapped Exception" button below to see a 
    demonstration of exception wrapping.<br /><br />
    
    Numbers: <asp:TextBox ID="txtNumbers" Runat="server">1,2,3,4,five</asp:TextBox>
    <br />
    <br />
    <asp:Button Runat="server" ID="btnCreateWrappedException" Text="Create Wrapped Exception" OnClick="btnCreateWrappedException_Click" />
    <br />
    <br />
    <asp:Label ID="lblInfo" Runat="server"></asp:Label>         
</asp:Content>
