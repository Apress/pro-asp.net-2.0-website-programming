<%@ Control Language="VB" %>
<div style="background-color:GhostWhite; width:100%;border:1px solid black;padding:5px;">
    <asp:Panel Runat=server ID=SystemMessagesPanel Visible=False>
        <table>
            <tr>
                <td valign=top><asp:Image Runat=server ID=picSystem ImageUrl="~/Images/icon_systemmessage.gif" AlternateText="System Messages" /></td>
                <td>
                    <asp:Repeater Runat=server id=SystemMessagesRepeater>
                        <HeaderTemplate>
                            <table cellspacing=0 cellpadding=2>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <TR>      
                                <td style="width:5px;font-weight:bold;">-</td>              
                                <td style='color:DarkGreen;'><%#CType(Container.DataItem, Messaging.MessageData).Message%></td>                
                            </TR>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </asp:Panel>    
    <asp:Panel Runat=server ID=MessagesPanel Visible=False>
        <table>
            <tr>
                <td valign=top><asp:Image Runat=server ID=Image1 ImageUrl="~/Images/icon_message.gif" AlternateText="Page Messages"/></td>
                <td>
                    <asp:Repeater Runat=server id=MessagesRepeater>
                        <HeaderTemplate>
                            <table cellspacing=0 cellpadding=2>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <TR>      
                                <td style="width:5px;font-weight:bold;">-</td>              
                                <td style='color:DarkGreen;'><%#CType(Container.DataItem, Messaging.MessageData).Message%></td>                
                            </TR>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>                
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel Runat=server ID=ErrorMessagesPanel Visible=False>
        <table>
            <tr>
                <td valign=top><asp:Image Runat=server ID=Image2 ImageUrl="~/Images/icon_error.gif" AlternateText="Error Messages"/></td>
                <td>
                    <asp:Repeater Runat=server id=ErrorMessagesRepeater>
                        <HeaderTemplate>
                            <table cellspacing=0 cellpadding=2>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <TR>      
                                <td style="width:5px;font-weight:bold;">-</td>              
                                <td style='color:DarkRed;'><%#CType(Container.DataItem, Messaging.MessageData).Message%></td>                
                            </TR>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>                
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
<br />