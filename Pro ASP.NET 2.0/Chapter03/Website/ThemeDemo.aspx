<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ThemeDemo.aspx.vb" Inherits="ThemeDemo_aspx" title="Theme Demo" EnableViewState="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Theme Demo</strong><br />
    <br />
    This page demonstrates how themes and control skins in ASP.NET 2.0 work.  You can use the radio
    buttons below to select a theme.  When you do, the page will be reloaded the the page will be themed 
    using your selection.  Control skins in the themes directory are also applied when you choose
    a particular theme.  Please take a look at the .skin files in the various themes directories under the 
    App_Themes folder for styling information about each control skin.<br />
    <br />
    <asp:Literal Runat=server ID=litOptThemes />
    <asp:Button Runat=Server ID=btnSetTheme Text="Set Theme" OnClick="btnSetTheme_Click" /><br />
    <br />
    <hr />
    <asp:Label Runat=server ID="lblNamedSkin" SkinID="Title" Text="This text will never be displayed!"/><br />
    <br />
    <asp:Label Runat=Server ID="lblSingleLineTextbox">Single-Line Textbox</asp:Label><br />
    <asp:TextBox Runat=server ID="txtSingleLine"></asp:TextBox><br /><br />
    <asp:Label Runat=Server ID="lblMuliLineTextBox">Multi-Line Textbox</asp:Label><br />
    <asp:TextBox Runat=server ID="txtMultiLine" SkinID="MultiLine" TextMode="MultiLine" ></asp:TextBox><br /><br />
    <asp:Label Runat=Server ID="lblNoTheme">Textbox with Skinning Disabled</asp:Label><br />
    <asp:TextBox Runat=server id="txtNoTheme" EnableTheming=false></asp:TextBox><br />    
    Notice that this last textbox does not have a theme because themeing has been explicitly disabled
    <hr />
</asp:Content>
