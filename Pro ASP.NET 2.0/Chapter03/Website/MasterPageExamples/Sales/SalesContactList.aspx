<%@ Page Language="VB" MasterPageFile="~/MasterPageExamples/Sales/BravoSales.master" AutoEventWireup="false" CodeFile="SalesContactList.aspx.vb" Inherits="MasterPageExamples_Sales_SalesContactList" title="Sales Contact List" Theme="Bravo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SalesQuickLinks" Runat="Server">
 | <a href="javascript:alert('This link would have taken you to the phone system help page');">Phone System Help</a> |
   <a href="javascript:alert('This link would have taken you to the update my contact info page');">Update My Contact Info</a>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SalesMainContent" Runat="Server">
    <div style="width:400px;">
        Welcome to the employee directory page.  You can find a list of
        phone numbers in the table below.  Have fun calling people!<br /><br />
    </div>
    <table cellpadding=5 style="border:1px solid black;">
        <tr style="font-weight:bold; color:White; background-color:DarkBlue;">
            <td>Name</td><td>Extension</td>
        </tr>
        <tr><td>Ragan, Dave</td><td>x 1967</td></tr>
        <tr><td>Reed, Nick</td><td>x 1212</td></tr>        
        <tr><td>Schall, Jason</td><td>x 1972</td></tr>
        <tr><td>Skinner, Ted</td><td>x 7849</td></tr>
        <tr><td>Yell, Vanessa</td><td>x 4390</td></tr>
    </table>
</asp:Content>

