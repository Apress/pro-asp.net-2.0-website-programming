<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportA.aspx.vb" Inherits="ReportA" %>
<table border="1" bordercolor="black">
    <tr>
        <td bgcolor="darkblue" colspan="2">
            <span style="font-size: 16pt; color: #ffffff;">Website Statistics</span></td>
    </tr>
    <tr>
        <td bgcolor="gainsboro" colspan="2">
            <strong>Report Date:<asp:label id="lblReportDate" runat="server"></asp:label></strong></td>
    </tr>
    <tr>
        <td bgcolor="gainsboro" >
            <strong>Page Title</strong></td>
        <td bgcolor="gainsboro" >
            <strong>Total Hits</strong></td>
    </tr>
    <tr>
        <td>
            Home Page</td>
        <td >
            5,309</td>
    </tr>
    <tr>
        <td>
            Products</td>
        <td>
            3,492</td>
    </tr>
    <tr>
        <td >
            Services</td>
        <td>
            4,209</td>
    </tr>
    <tr>
        <td>
            Customer Support</td>
        <td>
            1,204</td>
    </tr>
    <tr>
        <td>
            Contact Us</td>
        <td>
            2,278</td>
    </tr>
</table>