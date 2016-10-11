<%@ Control Language="VB" %>
<asp:Panel Runat=server ID=SystemMessagesPanel Visible=False>
  <script language=javascript>
    var SystemMessages = "System Message\n";
    <asp:Repeater Runat=server id=SystemMessagesRepeater>
      <ItemTemplate>
        SystemMessages += 
          ' - <%#CType(Container.DataItem, Messaging.MessageData).Message%>\n';
      </ItemTemplate>
    </asp:Repeater>
    alert(SystemMessages);
  </script>            
</asp:Panel>
<asp:Panel Runat=server ID=MessagesPanel Visible=False>
  <script language=javascript>
    var Messages = "Messages:\n";
    <asp:Repeater Runat=server id=MessagesRepeater>
      <ItemTemplate>
        Messages += 
          ' - <%#CType(Container.DataItem, Messaging.MessageData).Message%>\n';
      </ItemTemplate>
    </asp:Repeater>         
    alert(Messages);
  </script>       
</asp:Panel>
<asp:Panel Runat=server ID=ErrorMessagesPanel Visible=False>
  <script language=javascript>
    var ErrorMessages = "Error Messages:\n";
      <asp:Repeater Runat=server id=ErrorMessagesRepeater>
        <ItemTemplate>
          ErrorMessages += 
            ' - <%#CType(Container.DataItem, Messaging.MessageData).Message%>\n';
        </ItemTemplate>
      </asp:Repeater>         
    alert(ErrorMessages);
  </script>       
</asp:Panel>