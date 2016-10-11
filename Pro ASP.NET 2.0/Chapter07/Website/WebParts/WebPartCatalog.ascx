<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebPartCatalog.ascx.vb" Inherits="WebPartCatalog" %>
<%@ Register Src="DateTimeWebPart.ascx" TagName="DateTimeWebPart" TagPrefix="WebParts" %>
<%@ Register Src="ApressSearch.ascx" TagName="ApressSearch" TagPrefix="WebParts" %>
<%@ Register Src="MessageConsumer.ascx" TagName="MessageConsumer" TagPrefix="WebParts" %>
<%@ Register Src="MessageProvider.ascx" TagName="MessageProvider" TagPrefix="WebParts" %>
<%@ Register Src="ProjectList.ascx" TagName="ProjectList" TagPrefix="WebParts" %>
<%@ Register Src="ColorEntryWebPart.ascx" TagName="ColorEntryWebPart" TagPrefix="WebParts" %>
<%@ Register Src="ColorRGBWebPart.ascx" TagName="ColorRGBWebPart" TagPrefix="WebParts" %>
<%@ Register Src="ColorHexWebPart.ascx" TagName="ColorHexWebPart" TagPrefix="WebParts" %>
<%@ Register Src="ColorVisualWebPart.ascx" TagName="ColorVisualWebPart" TagPrefix="WebParts" %>
<%@ Register Namespace="CustomWebParts" TagPrefix="WebParts"  %>

<WebParts:ApressSearch ID="ApressSearch1" runat="server" />
<WebParts:MessageConsumer ID="MessageConsumer1" runat="server" />
<WebParts:MessageProvider ID="MessageProvider1" runat="server" />
<WebParts:ProjectList ID="ProjectList1" runat="server" />
<WebParts:MyCustomWebPart ID="MyCustomWebPart1" runat="server" />
<WebParts:DateTimeWebPart ID="MyDateTimeWebPart1" runat="server" />
<WebParts:DateTimeWebPart2 ID="MyDateTimeWebPart2" runat="server" />
<WebParts:ColorEntryWebPart ID="ColorEntryWebPart1" runat="server" />
<WebParts:ColorRGBWebPart ID="ColorRGBWebPart1" runat="server" />
<WebParts:ColorHexWebPart ID="ColorHexWebPart1" runat="server" />
<WebParts:ColorVisualWebPart ID="ColorVisualWebPart1" runat="server" />
