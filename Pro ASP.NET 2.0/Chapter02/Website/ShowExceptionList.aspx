<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ShowExceptionList.aspx.vb" Inherits="ShowExceptionList" title="Show Exception List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Exception List</strong><br /><br />
    
    This page demonstrates how to the use the exception logging tools from the chapter.  The following list shows all of the exceptions currently held in the database.
    You can add exceptions by visiting the <a href="GenerateExceptions.aspx">Generate Exceptions</a> page.  Click on the "View" link next to an exception
    to view information about the exception.<br /><br />
    
    <asp:GridView ID="gridExceptions" runat="server" 
      AutoGenerateColumns="False" CellPadding=3>
        <HeaderStyle HorizontalAlign="Left" BackColor=Gainsboro />
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
            <asp:TemplateField HeaderText="Page">
                <ItemTemplate>
                    <%#Eval("Page")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User ID">
                <ItemTemplate>
                    <%#Eval("UserID")%>
                </ItemTemplate>                               
            </asp:TemplateField>
        </Columns>        
        <EmptyDataTemplate>
            There are no exceptions to display.  Please visit <a href="GenerateExceptions.aspx">GenerateExceptions.aspx</a> to create a few
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Literal runat="server" ID="litGenExceptions"><br /><br />Visit <a href="GenerateExceptions.aspx">GenerateExceptions.aspx</a> to create additional exceptions.</asp:Literal> 
    
</asp:Content>

