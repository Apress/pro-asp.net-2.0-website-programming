<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="Thumbnails.aspx.vb" Inherits="Thumbnails" title="Thumbnail Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Thumbnail Demo</strong><br /><br />
    
    Following you will see thumnail images of all of the images located in the Pictures
    directory. All of these thumbnail images are being provided by the ThumnailHandler
    HTTP Handler.<br /><br />
    
    <div style="text-align:center;">
        <asp:PlaceHolder ID="phThumbnails" runat="server"></asp:PlaceHolder>
        <br /><br />
        <B>The following image is hardcoded in the HTML</B><br /><br />
        <img src="Thumbnails/Test/Image01.jpg" />
    </div>
    <br />
    <br />
</asp:Content>

