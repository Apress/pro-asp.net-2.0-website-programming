<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="DatabaseFileUpload.aspx.vb" Inherits="DatabaseFileUpload" title="Database File Upload" %>
<%@ Register Src="ShowDBFiles.ascx" TagName="ShowDBFiles" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Database File Upload</strong><br /><br />
    
    This page demonstrates how to upload a single file to the database.  Use the file upload control
    below to upload a file.  You will see the file you upload appear in the list of files stored
    in the database below the upload control.<br /><br />

    <asp:FileUpload ID="FileUploader" runat="server" />
    <br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload File" /><br />
    <br />
    <uc1:ShowDBFiles ID="ShowDBFiles1" runat="server" />
</asp:Content>