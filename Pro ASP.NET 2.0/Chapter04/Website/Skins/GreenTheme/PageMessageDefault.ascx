<%@ Control Language="VB" %>
<div style="background-color:Gainsboro; width:100%;
            border:1px solid black;padding:5px;">
    <asp:Panel Runat=server ID=SystemMessagesPanel Visible=False>
        <asp:Repeater Runat=server id=SystemMessagesRepeater>
            <HeaderTemplate>
                <table cellspacing=0 cellpadding=2>
            </HeaderTemplate>
            <ItemTemplate>
                <TR>      
                    <td style="width:5px;font-weight:bold;">-</td>              
                    <td style='color:DarkGreen;'>
                     <%#CType(Container.DataItem, Messaging.MessageData).Message%>
                    </td>                
                </TR>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>    
    <asp:Panel Runat=server ID=MessagesPanel Visible=False>
        <asp:Repeater Runat=server id=MessagesRepeater>
            <HeaderTemplate>
                <table cellspacing=0 cellpadding=2>
            </HeaderTemplate>
            <ItemTemplate>
                <TR>      
                    <td style="width:5px;font-weight:bold;">-</td>              
                    <td style='color:DarkGreen;'>
                     <%#CType(Container.DataItem, Messaging.MessageData).Message%>
                    </td>
                </TR>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    <asp:Panel Runat=server ID=ErrorMessagesPanel Visible=False>
        <asp:Repeater Runat=server id=ErrorMessagesRepeater>
            <HeaderTemplate>
                <table cellspacing=0 cellpadding=2>
            </HeaderTemplate>
            <ItemTemplate>
                <TR>      
                    <td style="width:5px;font-weight:bold;">-</td>              
                    <td style='color:DarkRed;'>
                     <%#CType(Container.DataItem, Messaging.MessageData).Message%>
                    </td>
                </TR>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</div>
<br />