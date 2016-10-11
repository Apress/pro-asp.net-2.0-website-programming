<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ColorEntryWebPart.ascx.vb" Inherits="ColorEntryWebPart" %>
<asp:Label ID="lblRGB" runat="server" Text="RGB Definition"></asp:Label>
<asp:RangeValidator ID="rngValR" runat="server" ControlToValidate="txtR" ErrorMessage="Red (R) portion of the RGB value must be an integer between 0 and 255" MaximumValue="255" MinimumValue="0" Type="Integer" ValidationGroup="RGBGroup">*</asp:RangeValidator>
<asp:RangeValidator ID="rngValG" runat="server" ControlToValidate="txtG" ErrorMessage="Green (G) portion of the RGB value must be an integer between 0 and 255" MaximumValue="255" MinimumValue="0" Type="Integer" ValidationGroup="RGBGroup">*</asp:RangeValidator>
<asp:RangeValidator ID="rngValB" runat="server" ControlToValidate="txtB" ErrorMessage="Blue (B) portion of the RGB value must be an integer between 0 and 255" MaximumValue="255" MinimumValue="0" Type="Integer" ValidationGroup="RGBGroup">*</asp:RangeValidator><br />
<asp:TextBox ID="txtR" runat="server" Width="40px" MaxLength="3">0</asp:TextBox>
<asp:TextBox ID="txtG" runat="server" Width="40px" MaxLength="3">0</asp:TextBox>
<asp:TextBox ID="txtB" runat="server" Width="40px" MaxLength="3">0</asp:TextBox>
<asp:Button ID="btnRGB" runat="server" Text="Go" ValidationGroup="RGBGroup" /><br />
<asp:Label ID="Label1" runat="server" Text="Hex Definition"></asp:Label><asp:RegularExpressionValidator
    ID="valHex" runat="server" ErrorMessage="Hex colors consist of exactly 6 hex characters ranging from 0-9 and A-F.  The preceeding # is optional"
    ValidationExpression="#?[0-9A-Fa-f]{6}" ValidationGroup="HexGroup" ControlToValidate="txtHex">*</asp:RegularExpressionValidator><br />
<asp:TextBox ID="txtHex" runat="server" Width="128px" MaxLength="7">#000000</asp:TextBox>&nbsp;<asp:Button
    ID="btnHex" runat="server" Text="Go" ValidationGroup="HexGroup" /><br />
<asp:Label ID="Label2" runat="server" Text="Color Name (e.g. Red)"></asp:Label><br />
<asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>&nbsp;<asp:Button
    ID="btnNamed" runat="server" Text="Go" /><br />
    <asp:Label runat=server ID=lblConsumers EnableViewState=false/>