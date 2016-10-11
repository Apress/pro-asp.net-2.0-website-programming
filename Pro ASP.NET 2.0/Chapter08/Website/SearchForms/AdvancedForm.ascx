<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdvancedForm.ascx.vb" 
    Inherits="advancedForm" %>

<span>
  Please enter a few keywords in the form below. This advanced search form has 
  the ability to query based on the employee id, employee name, title, and 
  birthdate range.
</span><br /><br />
<span>Employee ID</span><br />
<asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>
<asp:RangeValidator ID="RangeValidator1" runat="server" 
    ControlToValidate="txtEmployeeID"
    ErrorMessage="Employee ID must be an integer greater than zero" 
    MaximumValue="9999999"
    MinimumValue="0" Type="Integer">*</asp:RangeValidator><br />
<span>Employee Name</span><br />
<asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox><br />
<span>Title</span><br />
<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
<span>Birthdate (Start Date Range)</span><br />
<asp:TextBox ID="txtBirthDateStart" runat="server"></asp:TextBox>&nbsp;<asp:RangeValidator
    ID="RangeValidator2" runat="server" ControlToValidate="txtBirthDateStart" ErrorMessage="Birth Date (Start Date Range) must be a valid date"
    MaximumValue="12/31/9999" MinimumValue="1/1/1800" Type="Date">*</asp:RangeValidator><br />
Birthdate (End Date Range)<br />
<asp:TextBox ID="txtBirthDateEnd" runat="server"></asp:TextBox>
<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtBirthDateEnd"
    ErrorMessage="Birth Date End Date Range) must be a valid date" MaximumValue="12/31/9999"
    MinimumValue="1/1/1800" Type="Date">*</asp:RangeValidator>
<br />
&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
    ShowSummary="False" />
