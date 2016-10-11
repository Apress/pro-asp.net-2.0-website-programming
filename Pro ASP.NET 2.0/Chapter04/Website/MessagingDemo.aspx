<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="MessagingDemo.aspx.vb" Inherits="MessagingDemo_aspx" title="Messaging Demo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="server">
    <msgControls:PageMessageControl ID="msgHandler" Runat="server" />
    <strong>Page Message Demo</strong><br /><br />
    
    This page demonstrates both the page message control, and the various
    page message skins you can create for your sites.  Choose a skin to 
    use from the option boxes, select which type of messages you would
    like to generate, then click on the "Show Messages" button.<br /><br />
    
    <span style="text-decoration:underline;">Skins</span><br />
    <asp:RadioButton ID="rbDefault" Runat="server" GroupName="SkinType" text="Default Messages Skin" Checked="True" /><br />
    <asp:RadioButton ID="rbIcons"   Runat="server" GroupName="SkinType" text="Messages with Group Icon Skin" /><br />
    <asp:RadioButton ID="rbJava"    Runat="server" GroupName="SkinType" text="Messages via JavaScript Alert Skin" /><br />
    
    <br />
    
    <span style="text-decoration:underline;">Messages</span><br />
    <asp:RadioButton ID="rbMsgSystem" Runat="server" GroupName="MsgType" text="System Message" Checked="True" /><br />    
    <asp:RadioButton ID="rbMsgPage" Runat="server" GroupName="MsgType" text="Page Message" /><br />
    <asp:RadioButton ID="rbMsgPageMultiple" Runat="server" GroupName="MsgType" text="Multiple Page Messages" Checked="True" /><br />
    <asp:RadioButton ID="rbMsgError" Runat="server" GroupName="MsgType" text="Error Message" /><br />
    <asp:RadioButton ID="rbMsgErrorMultiple" Runat="server" GroupName="MsgType" text="Multiple Error Message" /><br />
    <asp:RadioButton ID="rbMsgPageAndError" Runat="server" GroupName="MsgType" text="Page Messages and Error Messages" /><br />
    
    <br />    
    
    <asp:Button ID="btnShowMessages" Runat="server" Text="Show Messages" OnClick="btnShowMessages_Click" />
    
</asp:Content>