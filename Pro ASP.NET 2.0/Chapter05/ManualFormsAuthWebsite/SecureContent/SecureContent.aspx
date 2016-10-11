<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SecureContent.aspx.vb" Inherits="SecureContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        You are seeing secure content so you must be logged in<br />
        <br />
        <asp:Label runat="server" ID="lblInfo" Text="" /><br />
        <br />
        <asp:Button runat="server" ID="btnLogout" Text="Logout" />               
    </div>
    </form>
</body>
</html>
