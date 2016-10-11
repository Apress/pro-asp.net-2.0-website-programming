<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PagingControl.ascx.vb" Inherits="PagingControl" EnableViewState="false" %>
<table style="width: 100%;">
    <tr>
        <td style="vertical-align:top; text-align: left;"><asp:LinkButton id="lnkPrev" runat=server Text="Prev" CausesValidation="False" /></td>
        <td style="vertical-align:top; text-align: center;">
            Page <asp:TextBox id=txtCurrentPage runat=server Text="1" width="40px" ValidationGroup="Pagination" />&nbsp;
            of <asp:Label id=lblPageTotal runat=server /> [<asp:LinkButton ID=lnkGotoPage runat=server text="Go" ValidationGroup="Pagination"/>]<br />
            <asp:Label ID=lblRecordInfo runat=server />&nbsp;
            <asp:RangeValidator ID="rngPageNumber" runat="server" ErrorMessage="<BR>(Invalid Page Number)"
                Type="Integer" MinimumValue="1" MaximumValue="2147483647" ValidationGroup="Pagination" ControlToValidate="txtCurrentPage"></asp:RangeValidator>
        </td>
        <td style="vertical-align:top; text-align: right;"><asp:LinkButton ID="lnkNext" runat=server Text="Next" CausesValidation="False" /></td>
    </tr>
</table>
