<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="DataConfigSettings.aspx.vb" Inherits="DataConfigSettings_aspx" title="Data Config Settings" EnableViewState="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <div>
        <strong>DataConfig Class Settings Display Page</strong><br /><br />
        This page shows the settings that were loaded into the DataConfig class from
        your database.  If you update a setting in the database, it will not be
        reflected in the DataConfig class until you clear the cache.  You can click
        the "Clear Cache" button to call the ClearCache() method, which will force
        the DataConfig class to reload the data from the database.  
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
        </table>
    <asp:Button ID="btnClearCache" Runat="server" Text="Clear Cache" OnClick="btnClearCache_Click" />
    <br />


</asp:Content>
