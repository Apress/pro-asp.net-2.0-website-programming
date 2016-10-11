<%@ Page Language="VB" MasterPageFile="~/MasterPageExamples/Bravo.master" AutoEventWireup="false" CodeFile="PageLayoutExample.aspx.vb" Inherits="PageLayoutExample" title="Bravo Master Layout" Theme="Bravo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="QuickLinks" Runat="Server">
    <div style="font-size:12pt; border:dashed 1px black;">
        <center>Quick Links</center>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="font-size:50pt; border:1px dashed black; width:100%; height:400px;">
        <br /><br />
        <center>Content</center>
    </div>    
    <BR />
    This page outlines the layout of the Bravo Corp master page.  There are two ContentPlaceHolders denoted by the 
    dashed outlines:  the Content area allows you to define content for the page, and the Quick Links area 
    allows you to add context-sensitive links to the page.  You can have as many ContentPlaceHolder controls
    in your master page as you so desire.<br /><br />
    <a href="BravoHome.aspx">Go back to the Bravo Homepage.</a>
</asp:Content>

