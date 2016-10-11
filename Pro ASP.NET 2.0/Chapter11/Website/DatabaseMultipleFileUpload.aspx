<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="DatabaseMultipleFileUpload.aspx.vb" Inherits="DatabaseMultipleFileUpload" title="Multiple Database Upload" %>
<%@ Register Src="ShowDBFiles.ascx" TagName="ShowDBFiles" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <script language="javascript" type="text/javascript">
    
        ////////////////////////////////////////////////////////////////////////
        var fileCount = 1;
    
        ////////////////////////////////////////////////////////////////////////
        function AddFile(){
        
            var fileSectionDiv = document.getElementById("files");
            var fileItemDiv = document.createElement("div");
            
            //Increment the file counter
            fileCount++;                        
            
            //Setup the HTML content
            var content = "<input type=file name=fileUpload" + 
              fileCount + ">&nbsp;<a href='javascript:RemoveFile(" + 
              fileCount + ");'>Remove</a>"
            
            //Setup the fileItemDiv properties and append element
            fileItemDiv.id = "fileItemDiv" + fileCount;
            fileItemDiv.innerHTML = content;
            fileSectionDiv.appendChild(fileItemDiv);                        
        }
        
        ////////////////////////////////////////////////////////////////////////
        function RemoveFile(fileIndex){
            var fileSectionDiv = document.getElementById("files");
            var fileItemDiv = document.getElementById("fileItemDiv" + fileIndex);
            fileSectionDiv.removeChild(fileItemDiv);
        }                     
    </script>

    <strong>Multiple Database File Upload</strong><br /><br />
    
    This page demonstrates how to upload multiple files to the database.  Use the file upload 
    controls below to upload as many files as you wish.  You will see the files you upload appear 
    in the list of files stored in the database below the upload control.<br /><br />

    <div id="files">
        <input type="file" name="file1" id="file1" /><br />
    </div>
    <input type="button" value="Add File" onclick="AddFile();"/>
    <asp:Button runat="server" ID="btnUpload" Text="Upload Files" />
    <br />
    <br />
    <uc1:ShowDBFiles ID="ShowDBFiles1" runat="server" />
    
</asp:Content>

