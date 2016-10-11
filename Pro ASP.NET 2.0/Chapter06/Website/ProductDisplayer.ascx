<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProductDisplayer.ascx.vb" Inherits="ProductDisplayer" EnableViewState="false" %>
<div style="text-align: center; width: 200px; height:250px; border:1px solid black; padding:5px;">
    <asp:image id="imgProduct" Runat="Server"></asp:image><br /><br />
    <asp:Label Runat=Server ID="lblProductName" Font-Bold="True"></asp:Label><br />
    <asp:Label Runat=Server ID="lblPrice"></asp:Label><br />
    Qnty <asp:TextBox Runat=server ID="txtQuantity" Width="27px" Height="22px">1</asp:TextBox>
    <asp:Button Runat=server ID=btnAdd Text="Add" OnClick="btnAdd_Click" />
</div>
