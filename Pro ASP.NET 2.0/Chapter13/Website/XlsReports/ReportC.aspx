<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReportC.aspx.vb" Inherits="ReportC" %>
<table border="1" bordercolor="black">
    <tr>
        <td bgcolor="darkblue" colspan="2">
            <span style="font-size: 16pt; color: #ffffff;">
                <asp:label id="lblEmployeeName" runat="server"></asp:label>
                </span></td>
    </tr>
    <tr>
        <td bgcolor="gainsboro" colspan="2">
            <strong>Report Date:<asp:label id="lblReportDate" runat="server"></asp:label></strong></td>
    </tr>
    <tr>
        <td bgcolor="gainsboro" >
            <strong>Time Bucket</strong></td>
        <td bgcolor="gainsboro" >
            <strong>Hours</strong></td>
    </tr>
    <tr>
        <td>
            Paid Vacation</td>
        <td >
            </td>
    </tr>
    <tr>
        <td>
            Sick Leave</td>
        <td>
            </td>
    </tr>
    <tr>
        <td >
            Administrative</td>
        <td>
            2</td>
    </tr>
    <tr>
        <td>
            Project A</td>
        <td>
            5</td>
    </tr>
    <tr>
        <td>
            Project B</td>
        <td>
            3</td>
    </tr>
    <tr>
        <td>
            Project C</td>
        <td>
            1</td>
    </tr>
    <tr>
        <td bgcolor="gainsboro">
            <strong>Total</strong></td>
        <td bgcolor="gainsboro">
            <strong>11</strong></td>
    </tr>
</table>
<br />
