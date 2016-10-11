<%@ Page Language="VB" MasterPageFile="~/MasterDemo/MasterDemo.master" AutoEventWireup="false" CodeFile="ProxyDemo.aspx.vb" Inherits="ProxyDemo" title="Proxy Demo" %>
<%@ MasterType VirtualPath="~/MasterDemo/MasterDemo.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="middleCellContent" Runat="Server">
    <asp:WebPartZone runat=server ID=middleZone HeaderText="Middle Zone">
    </asp:WebPartZone>
</asp:Content>

