<%@ Control Language="VB" AutoEventWireup="false" 
            CodeFile="MessageProvider.ascx.vb" 
            Inherits="MessageProvider" %>
Enter a message:<br />
<asp:TextBox runat=server ID=txtMessage />
<asp:Button runat=server ID=btnSubmit Text="Send Message" /><br />
<asp:Label runat=server ID=lblConsumers EnableViewState=false/>