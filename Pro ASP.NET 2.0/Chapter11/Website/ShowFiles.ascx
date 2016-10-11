<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowFiles.ascx.vb" Inherits="ShowFiles" %>
    <asp:GridView runat=server ID=gridFiles AutoGenerateColumns=false CellPadding=3>
        <Columns>
            <asp:TemplateField HeaderText="File Name">
                <ItemTemplate>
                    <%#Container.DataItem.Name%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size (Bytes)">
                <ItemStyle HorizontalAlign=right />
                <ItemTemplate>
                    <%#Container.DataItem.Length%>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField ShowHeader=false>
                <ItemTemplate>
                    <a href='Files/<%#Container.DataItem.Name%>'>Download</a>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
        <EmptyDataTemplate>
            There are no files to display
        </EmptyDataTemplate>
    </asp:GridView>