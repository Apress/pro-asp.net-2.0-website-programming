<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CustomerSimple.ascx.vb" Inherits="CustomerSimple" %>
<div style="width:400px;"><strong><span style="text-decoration: underline">Simple Search Form</span></strong><br />
Please enter customer keywords in the textbox below.&nbsp; Those keywords will be
used to match items in the CustomerID, CompanyName, ContactName, and ContactTitle
fields.</div><br />
Customer Information Keywords:<br />
<asp:TextBox ID=txtCustomerInfo runat=server /><asp:Button ID=btnSearch runat=server text="Search"/><br />