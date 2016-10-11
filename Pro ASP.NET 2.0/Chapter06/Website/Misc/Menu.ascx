<%@ Control Language="VB" AutoEventWireup="False" CodeFile="Menu.ascx.vb" Inherits="Menu_ascx" %>
<table width="149"  border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td><asp:Image Runat=server ID=MenuHeader ImageUrl="~/images/left.menu.heading.contents.gif" AlternateText="Section Contents" width="149" height="30" /></td>
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
                    <td><asp:HyperLink id="HyperLink1" Runat="server" NavigateUrl="~/ExampleSessionVsProfile.aspx">Profile vs. Session Demo</asp:HyperLink></td>
                </tr>
                
                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image2" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image5" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image6" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink2" Runat="server" NavigateUrl="~/RemoveInactiveProfiles.aspx">Remove Inactive Profiles</asp:HyperLink></td>
                </tr>
                
                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image7" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image8" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image9" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink3" Runat="server" NavigateUrl="~/TargetedAdExample.aspx">Targeted Ad Example</asp:HyperLink></td>
                </tr>
                
                <tr>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image10" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td style="width:17px;"><asp:Image Runat="server" ID="Image11" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat="server" ID="Image12" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id="HyperLink4" Runat="server" NavigateUrl="~/ShoppingCartExample.aspx">Shopping Cart Example</asp:HyperLink></td>
                </tr>                      
                                
            </table>
        </td>
    </tr>
</table>