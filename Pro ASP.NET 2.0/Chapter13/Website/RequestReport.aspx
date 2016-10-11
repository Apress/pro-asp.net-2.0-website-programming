<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="RequestReport.aspx.vb" Inherits="RequestReport" title="Report Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    
    <strong><span style="text-decoration: underline">Report A - Web Statistics<br />
    </span></strong>Contains a listing of the pages on the company website and the number
    of hits those pages received for the given date.&nbsp; Please select a date and
    click the "Get Report A" button below.&nbsp; Clicking this link will redirect you
    to a fake URL for an Excel file.&nbsp; The request for that Excel file will be intercepted
    by the XlsReportHandler and routed to Reports/ReportA.aspx where the request will
    be fulfilled.<br />
    <br />
    <table>
        <tr>
            <td style="height: 26px">
                Date</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtReportADate" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtReportADate" ValidationGroup="ReportA">Required</asp:RequiredFieldValidator><asp:RangeValidator
                    ID="valReportADate" runat="server" ControlToValidate="txtReportADate" ErrorMessage="RangeValidator"
                    MaximumValue="12/31/9999" MinimumValue="1/1/1000" Type="Date" ValidationGroup="ReportA">(Invalid Date)</asp:RangeValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:button ID="btnGetReportA" runat="server" Text="Get Report A" ValidationGroup="ReportA"/></td>
        </tr>
    </table>
    <br />
    You can also display normal hyperlinks containing the fake URL.&nbsp; The following
    link will take you to the ReportA.aspx report for today:&nbsp;
    <asp:HyperLink ID="hlnkReportA" runat="server"></asp:HyperLink><br />
    <br />
    <br />
    <strong><span style="text-decoration: underline">Report B - Room Reserveration Schedule<br />
    </span></strong>Contains a listing of the pages on the company website and the number
    of hits those pages received for the given date.&nbsp; Please select a date and
    click the "Get Report A" button below.&nbsp; Clicking this link will redirect you
    to a fake URL for an Excel file.&nbsp; The request for that Excel file will be intercepted
    by the XlsReportHandler and routed to Reports/ReportA.aspx where the request will
    be fulfilled.<br />
    <br />
    <table>
        <tr>
            <td style="height: 26px">
                Room</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoom"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="ReportB">Required</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 26px">
                Date</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtReportBDate" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReportBDate"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="ReportB">Required</asp:RequiredFieldValidator><asp:RangeValidator
                        ID="RangeValidator1" runat="server" ControlToValidate="txtReportBDate" ErrorMessage="RangeValidator"
                        MaximumValue="12/31/9999" MinimumValue="1/1/1000" Type="Date" ValidationGroup="ReportB">(Invalid Date)</asp:RangeValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:button ID="btnGetReportB" runat="server" Text="Get Report B" ValidationGroup="ReportB"/></td>
        </tr>
    </table>
    <br />
    You can also display normal hyperlinks containing the fake URL.&nbsp; The following
    link will take you to the ReportA.aspx report for today:&nbsp;
    <asp:HyperLink ID="hlnkReportB" runat="server"></asp:HyperLink><br />
    <br />
    <strong><span style="text-decoration: underline">Report C - Employee Time Sheet<br />
    </span></strong>Contains a listing of the pages on the company website and the number
    of hits those pages received for the given date.&nbsp; Please select a date and
    click the "Get Report A" button below.&nbsp; Clicking this link will redirect you
    to a fake URL for an Excel file.&nbsp; The request for that Excel file will be intercepted
    by the XlsReportHandler and routed to Reports/ReportA.aspx where the request will
    be fulfilled.<br />
    <br />
    <table>
        <tr>
            <td style="height: 26px">
                Employee</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmployee"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="ReportC">Required</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 26px">
                Date</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtReportCDate" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtReportCDate"
                    ErrorMessage="RequiredFieldValidator" ValidationGroup="ReportC">Required</asp:RequiredFieldValidator><asp:RangeValidator
                        ID="RangeValidator2" runat="server" ControlToValidate="txtReportCDate" ErrorMessage="RangeValidator"
                        MaximumValue="12/31/9999" MinimumValue="1/1/1000" Type="Date" ValidationGroup="ReportC">(Invalid Date)</asp:RangeValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:button ID="btnGetReportC" runat="server" Text="Get Report C" ValidationGroup="ReportC"/></td>
        </tr>
    </table>
    <br />
    You can also display normal hyperlinks containing the fake URL.&nbsp; The following
    link will take you to the ReportA.aspx report for today:&nbsp;
    <asp:HyperLink ID="hlnkReportC" runat="server"></asp:HyperLink>
</asp:Content>

