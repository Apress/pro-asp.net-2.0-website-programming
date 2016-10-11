<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="IconDisplayPage.aspx.vb" Inherits="IconDisplayPage_aspx" title="Icon Display Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <div>
        <strong>Custom Configuration Section - Icon Display Page</strong><br /><br />
        This page uses configuration data available from the Config.IconData
        property to display files with their associated icons.  Config.IconData pulls exposes
        icon configuration information stored in the &lt;iconConfig&gt; section of the web.config file.  
        You will need to look more closely at the IconConfiguration assembly and the Config
        class for more detailed information on Custom Configuration Section
        Handlers.<br /><br />
        
        <strong>File Listing</strong><hr />
        <asp:Literal ID="myLiteral" Runat="server" EnableViewState=false></asp:Literal>        
        
    </div>
</asp:Content>
