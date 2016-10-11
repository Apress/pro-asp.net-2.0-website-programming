<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="AspectRatios.aspx.vb" Inherits="AspectRatios" title="Aspect Ratios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Aspect Ratios</strong><br /><br />
    
    When you resize an image, it is important to maintain aspect ratios (the ratio of width to height).  
    Failure to maintain aspect ratios can result into images that appears to be distorted (stretched 
    out or squished together).  Below you will see a few image demonstrating aspect ratios.<br /><br />

    <asp:Image ID="imgNormal" runat="server" ImageUrl="~/Pictures/Dog.jpg" Height="500px" Width="350px" /><br />
    <div>Normal Image (350x500)</div><br /><br />
    <asp:Image ID="imgAspectGood" runat="server" Height="125px" ImageUrl="~/Pictures/Dog.jpg" Width="175px" /><br />
    <div>
        Poor Aspect Ratio (175x125)</div><br /><br /><asp:Image ID="Image1" runat="server" Height="250px" ImageUrl="~/Pictures/Dog.jpg" Width="88px" /><br />
    <div>Poor Aspect Ratio (88x250)<br />
        <br /><br /><asp:Image ID="Image2" runat="server" Height="250px" ImageUrl="~/Pictures/Dog.jpg" Width="175px" /><br />
    Correct Aspect Ratio (175x250)</div><br /><br />
    
</asp:Content>

