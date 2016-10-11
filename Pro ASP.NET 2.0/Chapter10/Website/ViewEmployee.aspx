<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ViewEmployee.aspx.vb" Inherits="ViewEmployee" title="View Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    &nbsp;<div style="border-right: black 1px solid; padding-right: 5px; border-top: black 1px solid;
        padding-left: 5px; padding-bottom: 5px; border-left: black 1px solid; padding-top: 5px;
        border-bottom: black 1px solid; background-color: #eeeeee">
        <strong><span style="font-size: 10pt">Employee Information:
            <asp:Label ID="lblHeading" runat="server"></asp:Label></span></strong></div>
    <br />
    
    Please use the Back button in your browser to return to the Add Employee Wizard.<br /><br />
    
    <span style="width: 100px; text-align: right"><strong>Title of Courtesy: </strong></span>
    &nbsp;&nbsp;<asp:Label ID="lblTitleOfCourtesy" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>First Name: </strong></span>&nbsp;&nbsp;<asp:Label ID="lblFirstName" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>Last Name: </strong></span>&nbsp;&nbsp;<asp:Label ID="lblLastName" runat="server"></asp:Label><br />
    <br />
    <span style="width: 100px; text-align: right"><strong>Birth Date: </strong></span>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblBirthDate" runat="server"></asp:Label><br />
    <br />
    <span style="width: 100px; text-align: right"><strong>Address:</strong></span> &nbsp;&nbsp;&nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>City: </strong></span>&nbsp;&nbsp;
    <asp:Label ID="lblCity" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>State: </strong></span>&nbsp;&nbsp;
    <asp:Label ID="lblState" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>Postal Code:</strong></span>
    &nbsp;
    <asp:Label ID="lblPostalCode" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>Country:</strong></span> &nbsp;
    <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
    <br />
    <span style="width: 100px; text-align: right"><strong>Home Phone:</strong></span>
    &nbsp;
    <asp:Label ID="lblHomePhone" runat="server"></asp:Label><br />
    <br />
    <span id="SPAN1" language="javascript" onclick="return SPAN1_onclick()" style="width: 100px;
        text-align: right"><strong>Hire Date: </strong></span>&nbsp;&nbsp;
    <asp:Label ID="lblHireDate" runat="server"></asp:Label><br />
    <span style="width: 100px; text-align: right"><strong>Job Title: </strong></span>
    &nbsp;&nbsp;
    <asp:Label ID="lblJobTitle" runat="server"></asp:Label><br />
    <span id="Span2" language="javascript" onclick="return SPAN1_onclick()" style="width: 100px;
        text-align: right"><strong>Extension:</strong></span> &nbsp;
    <asp:Label ID="lblExtension" runat="server"></asp:Label><br />
    <br />
    <strong>Notes:</strong><br />
    <asp:Label ID="lblNotes" runat="server"></asp:Label>
</asp:Content>

