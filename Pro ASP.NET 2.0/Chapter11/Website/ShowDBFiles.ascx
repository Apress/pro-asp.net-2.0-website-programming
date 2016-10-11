<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowDBFiles.ascx.vb" Inherits="ShowDBFiles" %>
    <asp:GridView runat=server ID=gridFiles AutoGenerateColumns=false CellPadding=3>
        <Columns>
            <asp:TemplateField HeaderText="File Name">
                <ItemTemplate>
                    <%#Container.DataItem("FileName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size (Bytes)">
                <ItemStyle HorizontalAlign=right />
                <ItemTemplate>
                    <%#Container.DataItem("FileSize")%>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField ShowHeader=false>
                <ItemTemplate>
                    <a href='GetDBFile.aspx?FileName=<%#Server.UrlEncode(Container.DataItem("FileName"))%>'>Download</a>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
        <EmptyDataTemplate>
            There are no files to display
        </EmptyDataTemplate>
    </asp:GridView>