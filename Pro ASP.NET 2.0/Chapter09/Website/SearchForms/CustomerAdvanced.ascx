<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CustomerAdvanced.ascx.vb" Inherits="CustomerAdvanced" %>
<div style="width:400px;"><strong><span style="text-decoration: underline">Advanced Search Form<br />
</span></strong>Please enter customer keywords into the fields below.&nbsp; Each
field will search a specific field in the database for the keywords that you have
entered.</div><br />
<span style="width:100px">Customer ID</span><asp:TextBox runat=server ID=txtCustomerID /><br />
<span style="width:100px">Company Name</span><asp:TextBox runat=server ID=txtCompanyName /><br />
<span style="width:100px">Contact Name</span><asp:TextBox runat=server ID=txtContactName /><br />
<span style="width:100px">Contact Title</span><asp:TextBox runat=server ID=txtContactTitle /><br />
<span style="width:100px">&nbsp;</span><asp:Button ID=btnSearch runat=server text="Search"/><br />