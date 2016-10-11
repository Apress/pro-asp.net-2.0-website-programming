<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="InnerExceptionDemo.aspx.vb" Inherits="InnerExceptionDemo_aspx" title="Inner Exception Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Inner Exception Demo</strong><br /><br />
    Each exception object has an InnerException property that can reference another exception
    object. This is useful for chaining related exceptions together or for wrapping a nondescript or
    confusing exception object in another more descriptive exception object. The
    System.Web.Mail.SmtpMail.SendMail function, although marked obsolete in ASP.NET 2.0,
    provides a great example of both exception chaining and exception wrapping when used
    improperly. When calling the function, you’re supposed to pass in a from address, a to address,
    a subject, and a message. If you fail to pass in a to or from address, then the function will throw
    an exception.<br /><br />
    
    Click on the "Send Invalid Email" button to execute the System.Web.Mail.SmtpMail.SendMail function
    without the appropriate parameters.  The page will then display the exception and inner exception
    information the function throws.<br /><br />      
    
    <asp:Button Runat="server" id="btnGenerateException" Text="Send Invalid Email" OnClick="btnGenerateException_Click" />
    <br /><br />        
    <asp:Label ID="lblInfo" Runat="server" Text="No exception has occurred."></asp:Label>
</asp:Content>
    
