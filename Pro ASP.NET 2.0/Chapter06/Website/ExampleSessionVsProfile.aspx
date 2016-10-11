<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ExampleSessionVsProfile.aspx.vb" Inherits="ExampleSessionVsProfile_aspx" title="Session vs. Profile Example" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>Session vs. Profile Example</strong><br /><br />
    This page demonstrates the differences between accessing data stored in the Session object
    versus data stored in the Profile object.  You will need to look at the code-behind file to
    see the full effect.  The following label displays the age of the user based their birth date 
    in the Profile object.  The birthdate is set to 8/20/1980 on this page for demonstration
    purposes.<br /><br />

    Your Age: <asp:Label ID="lblAge" Runat="server" Text="Label"></asp:Label>
    
</asp:Content>
