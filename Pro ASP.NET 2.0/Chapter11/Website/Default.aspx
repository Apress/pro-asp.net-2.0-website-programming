<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Default_aspx" title="Chapter 11 - Uploading Files" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Introduction</strong><br /><br />
    
    Businesses generate millions of documents every day, so naturally business applications
    need to work with files. Workflow systems allow people to upload supplemental documents
    and reports to help in decision-making processes. Employee directories may use uploaded
    images to help people put names with faces. Collaboration systems allow team members to
    upload shared information to a centralized storage system. Even web-based email clients use
    file uploads when working with attachments. Although not every web application allows file
    uploads, many do, so it’s an important topic to understand.<br /><br />  
    
    This project contains samples from Chapter 11 in the book. Please use the navigation
    menu on the left hand side of each page to navigate through the samples. Instructions
    on how to use the samples are included on each page, where applicable.<br /><br />
    
    <strong>Important Note:</strong> The file you upload must be under the maximum size
    for the request.  You can configure the maximum request size in the web.config.  For
    this example, it is set to approximately 16 Megabytes.  Look for  the following line in
    the web.config:<br /><br />
    
    &lt;!-- Update this line if you want to change the maximum file upload size --&gt;<br />
    &lt;httpRuntime maxRequestLength="16384" /&gt;<br /><br />   
    
</asp:Content>