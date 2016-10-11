<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="RemoveInactiveProfiles.aspx.vb" Inherits="RemoveInactiveProfiles" title="Remove Inactive Profiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <strong>Remove Inactive Profiles</strong><br /><br />
    This page demonstrates how you can use the ProfileManager to remove inactive profiles from the database.
    To remove inactive profiles, enter a date in the textbox below.  Any profiles that have not been accessed
    since before that date will be deleted.  You can also opt to only delete anonymous profiles.  This allows
    you to retain profile information for registered users even if they have not visited your site for a
    while.<br /><br />

    Remove all profiles that have been inactive since the following date:<br />
    <asp:TextBox runat="server" ID="txtDate"></asp:TextBox><asp:RangeValidator ID="RangeValidator1"
        runat="server" ErrorMessage="You must specify a valid date" MinimumValue="1/1/1900"
        MaximumValue="12/31/9999" Type="Date" ControlToValidate="txtDate">*</asp:RangeValidator>
        <asp:RequiredFieldValidator runat="server" ID="RequiredValidator1" ErrorMessage="You must specify a date" 
        ControlToValidate="txtDate">*</asp:RequiredFieldValidator><br />
    <asp:CheckBox runat=server ID=chkAnonymousOnly Checked=true Text="Anonymous Profiles Only" /><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Delete Profiles" /><br /><br />
    <asp:Label runat="server" ID="lblInfo" Text="" EnableViewState="false" /><br /><br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    
</asp:Content>

