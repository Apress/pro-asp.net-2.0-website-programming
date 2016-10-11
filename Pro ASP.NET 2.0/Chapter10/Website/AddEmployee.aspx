<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="AddEmployee.aspx.vb" Inherits="AddEmployee" title="Add Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Add Employee Page</strong><br /><br />
    
    This page demonstrates how to use a wizard to control the add employee process.
    Notice that this process forces the user to search for duplicates before adding
    a new employee. You can also use the wizard to place detailed instructions
    for each step of the process.  Add a few similarly named individuals
    to the database and see how the process picks up on possible duplicates.<br /><br />
    
    <asp:Wizard ID="AddWizard" runat="server" ActiveStepIndex="0" Width="450px" CellSpacing="5" CancelDestinationPageUrl="~/AddCancel.aspx" DisplayCancelButton="True" FinishDestinationPageUrl="~/AddSuccess.aspx">
        <SideBarStyle VerticalAlign="Top" Width="110px" BackColor="#EEEEEE" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" Wrap="True" CssClass="WizardLeftNav" />
        <WizardSteps>
            <asp:WizardStep runat="server" Title="Employee Name" ID="WizardStep1">
                <div style="border:1px solid black; padding:5px; background-color:#EEEEEE;">
                    <strong><span style="font-size: 10pt;">Please Enter an Employee Name</span></strong>
                </div>
                <br />
                <span>Welcome to the Add Employee Wizard.  This wizard will guide you through the process of adding a new employee and will ensure that you do not accidentally add a duplicate employee.  To begin, please enter the employee name below and click on the Next button.</span>
                <br /><br />
                <span style="width:100px;text-align:right;">First Name:&nbsp;</span><asp:TextBox runat=server ID=txtSearchFirstName Width="140px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchFirstName"
                    ErrorMessage="First Name is Required">*</asp:RequiredFieldValidator><br />
                <span style="width:100px;text-align:right;">Last Name:&nbsp;</span><asp:TextBox runat=server ID=txtSearchLastName Width="140px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSearchLastName"
                    ErrorMessage="Last Name is Required">*</asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Duplicate Check" ID="WizardStep2">
                <div style="border:1px solid black; padding:5px; background-color:#EEEEEE;">
                    <strong><span style="font-size: 10pt;">Please Check for Existing Data</span></strong></div><br />
                    <asp:Panel runat=server ID=pnlHasResults>
                    <div>Please review the list below to ensure you are not entering a duplicate employee.  The list was created using soundex features in SQL Server that phonetically match strings.</div><br />
                    </asp:Panel>
                    <asp:Panel runat=server ID=pnlNoResults>
                    <div>There were no existing employee matches for the employee name you entered.  You can be relatively assured that the employee you are entering is not a duplicate.  Please use your discretion when using a nick names or names with alternate spellings.</div><br />
                    </asp:Panel>
                <asp:GridView ID="GridDuplicates" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>                        
                        <asp:TemplateField HeaderText="View" ShowHeader="False">                        
                            <ItemTemplate>
                                <a href="ViewEmployee.aspx?EmployeeID=<%#Container.DataItem.EmployeeID%>">View</a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <%#Container.DataItem.LastName%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name">
                            <ItemTemplate>
                                <%#Container.DataItem.FirstName%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Personal Info" ID="WizardStep3">
                <div style="border-right: black 1px solid; padding-right: 5px; border-top: black 1px solid;
                    padding-left: 5px; padding-bottom: 5px; border-left: black 1px solid; padding-top: 5px;
                    border-bottom: black 1px solid; background-color: #eeeeee">
                    <strong><span style="font-size: 10pt">Please Enter the Employee's Personal Info</span></strong></div>
                <br />
                Use the fields below to fill out personal information regarding this employee.&nbsp;
                First and Last name are required.<br />
                <br />
                <span style="width:100px;text-align:right;">Title of Courtesy: </span><asp:DropDownList runat=server ID=ddlTitleOfCourtesy Width="70px">
                <asp:ListItem>Mr.</asp:ListItem>
                <asp:ListItem>Mrs.</asp:ListItem>
                <asp:ListItem>Ms.</asp:ListItem>
                <asp:ListItem>Dr.</asp:ListItem>
            </asp:DropDownList>
                <br />
                <span style="width:100px;text-align:right;">First Name: </span>
                <asp:TextBox runat=server ID=txtFirstName Width="140px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                    ErrorMessage="First Name is a Required Field">*</asp:RequiredFieldValidator>
                <br />
                <span style="width:100px;text-align:right;">Last Name: </span>
                <asp:TextBox runat=server ID=txtLastName Width="140px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="First Name is a Required Field">*</asp:RequiredFieldValidator>
                <br />
                <br />
                <span style="width:100px;text-align:right;">Birth Date: </span>
                <asp:TextBox runat=server ID=txtBirthDate Width="140px" />
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtBirthDate"
                    ErrorMessage="Invalid" MaximumValue="1/1/9999" MinimumValue="1/1/1880" Type="Date"></asp:RangeValidator>
                <br />
                <br />
                    <span style="width:100px;text-align:right;">Address:</span><asp:TextBox runat=server ID=txtAddress Width="140px" /><br />
                    <span style="width:100px;text-align:right;">City: </span>
                <asp:TextBox runat=server ID=txtCity Width="140px" />
                <br />
                <span style="width:100px;text-align:right;">State: </span>
                <asp:TextBox runat=server ID=txtState Width="140px" />
                <br />
                <span style="width:100px;text-align:right;">Postal Code:</span><asp:TextBox runat=server ID=txtPostalCode Width="140px" />
                <br />
                <span style="width:100px;text-align:right;">Country:</span><asp:TextBox runat=server ID=txtCountry Width="140px" />
                <br />
                <br />
                <span style="width:100px;text-align:right;">Home Phone:</span><asp:TextBox runat=server ID=txtHomePhone Width="140px" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
                <br />
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Job Info" ID="WizardStep4">
                <div style="border-right: black 1px solid; padding-right: 5px; border-top: black 1px solid;
                    padding-left: 5px; padding-bottom: 5px; border-left: black 1px solid; padding-top: 5px;
                    border-bottom: black 1px solid; background-color: #eeeeee">
                    <strong><span style="font-size: 10pt">Please Enter the Employee's Job Information</span></strong></div>
                <br />
                Use the fields below to enter the employee's job information<br />
                <br />
                <span style="width:100px;text-align:right;" id="SPAN1" language="javascript" onclick="return SPAN1_onclick()">
                Hire Date: </span>
                <asp:TextBox runat=server ID=txtHireDate Width="140px" />
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHireDate"
                    ErrorMessage="Invalid" MaximumValue="1/1/9999" MinimumValue="1/1/1880" Type="Date"></asp:RangeValidator>
                    <span style="width:100px;text-align:right;">Job Title:&nbsp;</span><asp:DropDownList runat=server ID=ddlJobTitle Width="140px">
                            <asp:ListItem>Sales Manager</asp:ListItem>
                            <asp:ListItem>Salesperson</asp:ListItem>
                            <asp:ListItem>Technical Support</asp:ListItem>
                            <asp:ListItem>Assistant</asp:ListItem>
                        </asp:DropDownList>
                <br />
                <span style="width:100px;text-align:right;" id="Span2" language="javascript" onclick="return SPAN1_onclick()">Extension:</span><asp:TextBox runat=server ID=txtExtension Width="140px" />
                <br />
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Notes" ID="WizardStep5">
                <div style="border-right: black 1px solid; padding-right: 5px; border-top: black 1px solid;
                    padding-left: 5px; padding-bottom: 5px; border-left: black 1px solid; padding-top: 5px;
                    border-bottom: black 1px solid; background-color: #eeeeee">
                    <strong><span style="font-size: 10pt">Please Enter Any Employee Notes</span></strong></div>
                <br />
                Make any notes that you want to retain for this employee in the text area below.&nbsp;
                For example, educational history, short bio, etc.<br />
                <br />
                <asp:TextBox runat=server ID=txtNotes Width="100%" Height="250px" TextMode="MultiLine" />
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>

