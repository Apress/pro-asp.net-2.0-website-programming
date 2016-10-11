<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ContentMgmtDemo.aspx.vb" Inherits="ContentMgmtDemo" title="Content Management Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Content Management Demo</strong><br /><br />
    
    This page provides links into the content management demo.  The links below point to pages
    that do not physically exist.  Instead, they are build dynamically from a content 
    management database when you request the item.  Please look at the "Pages" and "Content"
    tables in the database to see the page and page content definitions.<br /><br />
    
    <a href="ContentManagement/PageA.aspx">PageA.aspx</a><br />
    <a href="ContentManagement/PageB.aspx">PageB.aspx</a><br />
    <a href="ContentManagement/PageC.aspx">PageC.aspx</a>
    
</asp:Content>

