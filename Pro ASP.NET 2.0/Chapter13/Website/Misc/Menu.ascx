<%@ Control Language="VB" AutoEventWireup="False" CodeFile="Menu.ascx.vb" Inherits="Menu_ascx" %>
<table width="149"  border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td><asp:Image Runat="server" ID="MenuHeader" ImageUrl="~/images/left.menu.heading.contents.gif" AlternateText="Section Contents" width="149" height="30" /></td>
    </tr>
    <tr>
        <td>
            <table width="149" border="0" cellspacing="0" cellpadding="0">
                
                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image1" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image3" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image4" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink1" Runat="server" NavigateUrl="~/AspectRatios.aspx">Aspect Ratios</asp:HyperLink></td>
                </tr>

                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image2" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image5" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image6" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink2" Runat="server" NavigateUrl="~/Thumbnails.aspx">Thumbnail Demo</asp:HyperLink></td>
                </tr>
                
                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image7" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image8" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image9" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink3" Runat="server" NavigateUrl="~/SomePage.hello">HTTP Handler Demo</asp:HyperLink></td>
                </tr>

                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image13" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image14" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image15" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink5" Runat="server" NavigateUrl="~/RequestReport.aspx">Report Demo</asp:HyperLink></td>
                </tr>
                
                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image10" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image11" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image12" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink4" Runat="server" NavigateUrl="~/ContentMgmtDemo.aspx">Content Mangement Demo</asp:HyperLink></td>
                </tr>
                
                                                                
            </table>
        </td>
    </tr>
</table>