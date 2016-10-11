<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="HiddenFileUpload.aspx.vb" Inherits="HiddenFileUpload" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="Server">
    <script language=javascript>
    
        ////////////////////////////////////////////////////////////////////////
        function GetHiddenDivReference(){            
            var hiddenFileDiv = document.getElementById("hiddenFileDiv");
            if(!hiddenFileDiv){
                hiddenFileDiv = document.createElement("div");
                hiddenFileDiv.id = "hiddenFileDiv";                
                hiddenFileDiv.style.display = "" //"none";
                document.forms[0].appendChild(hiddenFileDiv);            
            } 
            return hiddenFileDiv;
        }
    
        ////////////////////////////////////////////////////////////////////////
        function AddFile(){

            //First, make sure the div that holds the items is in the form
            var hiddenFileDiv = GetHiddenDivReference();
            var fileUpload = document.createElement("input");
            var fileCount = (hiddenFileDiv.childNodes.length)
            
            //Set input properties
            fileUpload.type = "file";
            fileUpload.name = "file" + (fileCount+1);
            fileUpload.id = fileUpload.name;                        
            
            //Add the file upload to the hidden div
            hiddenFileDiv.appendChild(fileUpload); 
            
            //Popup the file browser dialog box
            fileUpload.click();
            
            //Determine whether or not the user selected a file
            if(fileUpload.value==""){
                //If nothing was selected, then remove the file input
                hiddenFileDiv.removeChild(fileUpload);
            }else{
                UpdateFileList(hiddenFileDiv);
            }
            
        }//AddFile()
        
        ////////////////////////////////////////////////////////////////////////
        function UpdateFileList(hiddenFileDiv){
        
            var fileList = document.getElementById("files");
            
            if(hiddenFileDiv.childNodes.length==0){
                fileList.innerHTML = "<div class='NoFilesSection'>" + 
                                        "No Files Selected</div><br/>";
                return;
            }else{
                var innerHTML = "<table cellpadding=3 class='fileSection'>";            
                for(i=0; i<hiddenFileDiv.childNodes.length; i++){                                
                    innerHTML += "<tr><td>" + hiddenFileDiv.childNodes[i].value + "</td><td><a href=\"javascript:RemoveFile(" + i + ");\">Remove</a></td></tr>";                
                } 
                innerHTML += "</table><br>"
                fileList.innerHTML = innerHTML;                
            }
        }
        
        ////////////////////////////////////////////////////////////////////////
        function RemoveFile(fileIndex){
            var hiddenFileDiv = GetHiddenDivReference();
            if(fileIndex < hiddenFileDiv.childNodes.length){                
                hiddenFileDiv.removeChild(hiddenFileDiv.childNodes[fileIndex]);    
                UpdateFileList(hiddenFileDiv);                         
            }
        }        
        
        ////////////////////////////////////////////////////////////////////////
        function HasFiles(){
            var hiddenFileDiv = GetHiddenDivReference();
           
            if(hiddenFileDiv && hiddenFileDiv.childNodes.length > 0) {
                return true;
            }else{
                alert("You have not selected any files to upload!");
                return false;
            }
        }
          
    </script>

    You are about to upload the following files:<br /><br />    
    <div id=files>
        <div class='NoFilesSection'>No Files Selected</div><br />
    </div>    
    <div id=hiddenFileDiv style="">        
    </div>
    
    <input type=button value="Add File" onclick="AddFile();"/>
    <asp:Button runat=server ID=btnUpload Text="Upload Files" />
    
    
    
</asp:Content>

