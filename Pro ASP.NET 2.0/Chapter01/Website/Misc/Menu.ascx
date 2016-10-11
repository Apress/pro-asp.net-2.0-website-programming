<%@ Control Language="VB" AutoEventWireup="False" CodeFile="Menu.ascx.vb" Inherits="Menu_ascx" %>
<table width="149"  border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td><asp:Image Runat=server ID=MenuHeader ImageUrl="~/images/left.menu.heading.contents.gif" AlternateText="Section Contents" width="149" height="30" /></td>
    </tr>
    <tr>
        <td>
            <table width="149" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="17"><asp:Image Runat=server ID="imgSpacer01" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td width="132"><asp:Image Runat=server ID="imgSpacer02" ImageUrl="~/images/spacer.gif" width="132" height="1" /></td>
                </tr>
                <tr>
                    <td><asp:Image Runat=server ID="Image2" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id=link03 Runat=server NavigateUrl="~/ConfigSettings.aspx">Config Settings</asp:HyperLink></td>
                </tr>                
                <tr>
                    <td><asp:Image Runat=server ID="Image1" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td>&nbsp;</td>
                </tr>                                
                <tr>
                    <td><asp:Image Runat=server ID="imgSpacer03" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id=link01 Runat=server NavigateUrl="~/CacheBenchmark.aspx">Cache Benchmark</asp:HyperLink></td>
                </tr>
                <tr>
                    <td><asp:Image Runat=server ID="imgSpacer04" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td>&nbsp;</td>
                </tr>                                
                <tr>
                    <td><asp:Image Runat=server ID="imgSpacer05" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id=link02 Runat=server NavigateUrl="~/IconDisplayPage.aspx">Icon Display Page</asp:HyperLink></td>
                </tr>
                <tr>
                    <td><asp:Image Runat=server ID="Image3" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td>&nbsp;</td>
                </tr>                                
                <tr>
                    <td><asp:Image Runat=server ID="Image4" ImageUrl="~/images/spacer.gif" width="17" height="8" /></td>
                    <td><asp:HyperLink id=HyperLink1 Runat=server NavigateUrl="~/DataConfigSettings.aspx">DataConfig Settings</asp:HyperLink></td>
                </tr>                
            </table>
        </td>
    </tr>
</table>