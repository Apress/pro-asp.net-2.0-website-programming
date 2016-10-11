<%@ Page Language="VB" MasterPageFile="~/MasterPageExamples/Marketing/BravoMarketing.master" AutoEventWireup="false" CodeFile="MarketingContactList.aspx.vb" Inherits="MasterPageExamples_Marketing_MarketingContactList" title="Marketing Contact List" Theme="Bravo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MarketingQuickLinks" Runat="Server">
 | <a href="javascript:alert('This link would have taken you to the phone system help page');">Phone System Help</a> |
   <a href="javascript:alert('This link would have taken you to the update my contact info page');">Update My Contact Info</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MarketingMainContent" Runat="Server">
    <div style="width:400px;">
        Welcome to the Marketing employee directory page.  You can find a list of
        phone numbers in the table below.  Have fun calling people!<br /><br />
    </div>
    <table cellpadding=5 style="border:1px solid black;">
        <tr style="font-weight:bold; color:White; background-color:DarkBlue;">
            <td>Name</td><td>Extension</td>
        </tr>
        <tr><td>Anderson, Ty</td><td>x 5891</td></tr>
        <tr><td>Armstrong, Teresa</td><td>x 1212</td></tr>
        <tr><td>Haynes, Tim</td><td>x 2911</td></tr>
        <tr><td>Pucket, Amanda</td><td>x 1213</td></tr>
    </table>
</asp:Content>

