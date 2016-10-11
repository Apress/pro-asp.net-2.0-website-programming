<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ConfigSettings.aspx.vb" Inherits="ConfigSettings_aspx" title="Configuration Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <div>
        <strong>Config Class Settings Display Page</strong><br /><br />
        This page shows the settings that were loaded into the Config class from
        the web.config file.  If you update a setting in the web.config file, the
        application will reload, and the change will be reflected on this page.        
    </div>
    <br /><br />        
    <strong>Settings from the Config Class</strong><hr />
    <table cellpadding="3">
        <tr>
            <td style="height: 25px" valign="top">
                MyString</td>
            <td style="height: 25px">
                <asp:Label ID="lblMyString" Runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                MyInteger</td>
            <td>
                <asp:Label ID="lblMyInteger" Runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                MyDateTime</td>
            <td>
                <asp:Label ID="lblMyDateTime" Runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                MyBoolean</td>
            <td>
                <asp:Label ID="lblMyBoolean" Runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                MyPrimeNumberArrayList</td>
            <td>
                <asp:Label ID="lblMyPrimeList" Runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                MyConnectionString</td>
            <td>
                <asp:Label ID="lblMyConnectionString" Runat="server"></asp:Label>
            </td>
        </tr>
    </table>
               
</asp:Content>
