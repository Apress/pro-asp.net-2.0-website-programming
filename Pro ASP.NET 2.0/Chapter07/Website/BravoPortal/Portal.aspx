<%@ Page Language="VB" MasterPageFile="~/Bravo.master" AutoEventWireup="false" CodeFile="Portal.aspx.vb" Inherits="Portal" title="Untitled Page" %>

<%@ Register Src="../WebParts/MessageProvider.ascx" TagName="MessageProvider" TagPrefix="uc1" %>
<%@ Register Src="../WebParts/MessageConsumer.ascx" TagName="MessageConsumer" TagPrefix="uc2" %>

<asp:Content ID="contentCommands" ContentPlaceHolderID=Commands runat=server>    
    <asp:LinkButton runat=server ID=btnBrowse ForeColor="black" OnClick="btnClick" CommandArgument="Browse">Browse</asp:LinkButton>&nbsp;|
    <asp:LinkButton runat=server ID=btnDesign ForeColor="black" OnClick="btnClick" CommandArgument="Design">Design Page</asp:LinkButton>&nbsp;|
    <asp:LinkButton runat=server ID=btnEdit ForeColor="black" OnClick="btnClick" CommandArgument="Edit">Edit Page</asp:LinkButton>&nbsp;|    
    <asp:LinkButton runat=server ID=btnCatalog ForeColor="black" OnClick="btnClick" CommandArgument="Catalog">View Catalog</asp:LinkButton>&nbsp;|
    <asp:LinkButton runat=server ID=btnConnect ForeColor="black" OnClick="btnClick" CommandArgument="Connect">Setup Connections</asp:LinkButton>&nbsp;|
    <asp:LinkButton runat=server ID=btnChangeScope ForeColor="black" OnClick="btnClick" CommandArgument="Scope" Visible=false>Scope</asp:LinkButton>
    <asp:Label runat=server ID=lblChangeScopeSeperator Visible=false>|</asp:Label>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">   
    <asp:WebPartManager ID="WebPartManager1" runat="server">
        <StaticConnections>
            <asp:WebPartConnection ID="StaticConnection1"
                ProviderID="MessageProvider1"
                ConsumerID="MessageConsumer1"
                ProviderConnectionPointID="MyProviderConnectionPoint"
                ConsumerConnectionPointID="MyConsumerConnectionPoint"                
            />
        </StaticConnections>
    </asp:WebPartManager>
    <table class=PortalMainTable cellpadding=0 cellspacing=5 width=100% border=0>
        <tr>
            <td valign=top runat=server id=cellZoneLeft width=200>
                <asp:WebPartZone ID="zoneLeft" runat="server" HeaderText="Left Zone">
                    <ZoneTemplate>
                        <uc1:MessageProvider ID="MessageProvider1" runat="server" />
                        <uc2:MessageConsumer ID="MessageConsumer1" runat="server" />
                    </ZoneTemplate>
                </asp:WebPartZone>                
            </td>
            <td valign=top runat=server id=cellZoneMiddle>
                <asp:WebPartZone ID="zoneMiddle" runat="server" HeaderText="Middle Zone">                    
                </asp:WebPartZone>
            </td>
            <td valign=top runat=server id=cellZoneRight width=200>
                <asp:WebPartZone ID="zoneRight" runat="server" HeaderText="Right Zone">
                </asp:WebPartZone>
            </td>
            <td valign=top runat=server id=ModeCatalog>
                <asp:CatalogZone ID="CatalogZone1" runat="server" HeaderText="Web Part Catalog">   
                    <ZoneTemplate>
                        <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" runat="server" Title="Web Part Catalog"  WebPartsListUserControlPath="~/WebParts/WebPartCatalog.ascx">
                            <WebPartsTemplate></WebPartsTemplate>
                        </asp:DeclarativeCatalogPart>
                        <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" Title="Inactive Web Parts on this Page"  />
                        <asp:ImportCatalogPart ID="ImportCatalogPart1" runat="server" Title="Import Web Parts" />
                    </ZoneTemplate>  
                </asp:CatalogZone>  
            </td>
            <td valign=top runat=server id=ModeEdit>
                <asp:EditorZone runat=server ID="EditorZone1" HeaderText="Web Part Editor" >
                    <ZoneTemplate>
                        <asp:PropertyGridEditorPart ID="PropertyGridEditorPart1" runat="server" Title="Custom Web Part Properties"  />        
                        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" runat=server />  
                        <asp:BehaviorEditorPart ID="BehaviorEditorPart1" runat=server />              
                        <asp:LayoutEditorPart ID="LayoutEditorPart1" runat=server />
                    </ZoneTemplate>
                </asp:EditorZone>
            </td>
            <td valign=top runat=server id=ModeConnect>
                <asp:ConnectionsZone runat=server ID=ConnectionsZone1>
                    
                </asp:ConnectionsZone>
            </td>
        </tr>    
    </table>  
    
    
    
</asp:Content>

