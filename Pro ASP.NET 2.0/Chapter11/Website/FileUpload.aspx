<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="FileUpload.aspx.vb" Inherits="FileUpload" title="File Upload" %>
<%@ Register Src="ShowFiles.ascx" TagName="ShowFiles" TagPrefix="uc1" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>File Upload</strong><br /><br />
    
    This page demonstrates how to upload a single file to the file system.  Use the file upload control
    below to upload a file.  You will see the file you upload appear in the list of files stored
    in the file system below the upload control.<br /><br />
    
    <asp:FileUpload ID="FileUploader" runat="server" />
    <br />
    <asp:Button ID="btnUpload" runat="server" Text="Upload File" /><br />
    <br />
    <uc1:ShowFiles ID="ShowFiles1" runat="server" />
</asp:Content>