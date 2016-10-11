<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="MultipleFileUpload.aspx.vb" Inherits="MultipleFileUpload" title="Multiple File Upload" %>
<%@ Register Src="ShowFiles.ascx" TagName="ShowFiles" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <script language="javascript" type="text/javascript">
    
        ////////////////////////////////////////////////////////////////////////
        var fileCount = 1;
    
        ////////////////////////////////////////////////////////////////////////
        function AddFileInput(){
        
            var fileSectionDiv = document.getElementById("files");
            var fileItemDiv = document.createElement("div");
            
            //Increment the file counter
            fileCount++;                        
            
            //Setup the fileItemDiv properties and append element
            fileItemDiv.id = "fileItemDiv" + fileCount;
            fileItemDiv.innerHTML = "<input type=file name=fileUpload" + 
                fileCount + ">&nbsp;<a href='javascript:RemoveFileInput(" + 
                fileCount + ");'>Remove</a>"
            fileSectionDiv.appendChild(fileItemDiv);                        
        }
        
        ////////////////////////////////////////////////////////////////////////
        function RemoveFileInput(fileIndex){
            var fileSectionDiv = document.getElementById("files");
            var fileItemDiv = document.getElementById("fileItemDiv" + fileIndex);
            fileSectionDiv.removeChild(fileItemDiv);
        }                     
    </script>
    
    <strong>Multiple File Upload</strong><br /><br />
    
    This page demonstrates how to upload multiple files to the file system.  Use the file upload 
    controls below to upload as many files as you wish.  You will see the files you upload appear 
    in the list of files stored on the file system below the upload control.<br /><br />    

    <div id="files">
        <input type="file" name="fileUpload1" /><br />
    </div>
    
    <input type="button" value="Add File" onclick="AddFileInput();"/>
    
    <asp:Button runat="server" ID="btnUpload" Text="Upload Files" />
    
    <br /><br />
    
    <uc1:ShowFiles ID="ShowFiles1" runat="server" />
    
</asp:Content>

