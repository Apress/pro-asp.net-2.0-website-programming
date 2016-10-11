<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ShowException.aspx.vb" Inherits="ShowException" title="Show Exception" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>View Exception Information</strong><br /><br />
    
    This page displays information about an exception and where it is in the exception chain (it is highlighted).  You can click the "View" link next
    to another item in the exception chain to view details about that particular exception.  You can also delete the entire exception chain by
    clicking the "Delete Exception Chain" button.<br /><br />


    <table cellpadding=3 cellspacing=1>
        <tr>
            <td valign=top style="background-color:Gainsboro">Exception Chain</td>
            <td valign=top>
                <asp:GridView ID="gridExceptionChain" runat="server" AutoGenerateColumns="False" CellPadding=3>
                    <HeaderStyle HorizontalAlign="Left" BackColor="Gainsboro" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <a href='ShowException.aspx?ExceptionID=<%#Eval("ExceptionID")%>'>View</a>
                            </ItemTemplate>
                        </asp:TemplateField>        
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <%#Eval("ExceptionDate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemTemplate>
                                <%#Eval("ExceptionType")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Message">
                            <ItemTemplate>
                                <%#Eval("ExceptionMessage")%>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </Columns>                    
                </asp:GridView>
                <br />
                <asp:Button runat=server ID=btnDelete Text="Delete Exception Chain" />
            </td>
        </tr>            
        <tr>
            <td valign=top style="background-color:Gainsboro">Exception ID</td>
            <td valign=top><asp:Label runat=server ID=lblExceptionID></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Page</td>
            <td valign=top><asp:Label runat=server ID=lblPage></asp:Label></td>
        </tr>        
        <tr>
            <td valign=top style="background-color:Gainsboro">Exception Date</td>
            <td valign=top><asp:Label runat=server ID=lblExceptionDate></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Exception Type</td>
            <td valign=top><asp:Label runat=server ID=lblExceptionType></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Message</td>
            <td valign=top><asp:Label runat=server ID=lblMessage></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Machine Name</td>
            <td valign=top><asp:Label runat=server ID=lblMachineName></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">User ID</td>
            <td valign=top><asp:Label runat=server ID=lblUserID></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">User Agent</td>
            <td valign=top><asp:Label runat=server ID=lblUserAgent></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Query String Data</td>
            <td valign=top><asp:Label runat=server ID=lblQueryStringData></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Form Data</td>
            <td valign=top><asp:Label runat=server ID=lblFormData style="width:450px; overflow:scroll;"></asp:Label></td>
        </tr>
        <tr>
            <td valign=top style="background-color:Gainsboro">Stack Trace</td>
            <td valign=top><asp:Label runat=server ID=lblStackTrace></asp:Label></td>
        </tr>                
    </table>
</asp:Content>

