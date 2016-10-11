<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MyLoginForm.aspx.vb" Inherits="MyLoginForm" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Manual Forms Auth Login</title>
</head>
<body>
    <form id="form1" runat="server">
            Welcome to the Manual Forms Authentication Website's default login page. You should
            enter your username and password in the textboxes below, then click on the 'Login'
            button.<br /><br />
            
            <strong>Usernames and Passwords</strong>
            <br />
            <table border=1 cellpadding=3 cellspacing=1>
                <tr><td>Username</td><td>Password</td><td>Roles</td></tr>
                <tr><td>Bob</td><td>bobpassword</td><td>employee, sales</td></tr>
                <tr><td>Jane</td><td>janepassword</td><td>executive, marketing</td></tr>
                <tr><td>Mark</td><td>markpassword</td><td>contractor, support, admin</td></tr>
            </table>
            
            <br />
            
            <span style="width: 75px;  ">Username:</span><asp:TextBox runat=server ID=txtUsername /><br />
            <span style="width: 75px;">Password:</span><asp:TextBox runat=server ID=txtPassword TextMode=password /><br />
            <span style="width: 75px;">&nbsp;</span><asp:CheckBox runat=server ID=chkRememberMe />&nbsp; Remember Me<br />
            <br />
            <span style="width: 75px;">&nbsp;</span><asp:Button runat=server ID=btnLogin Text="Login with Roles" /><br />
            <span style="width: 75px;">&nbsp;</span><asp:Button runat=server ID=btnLoginNoRoles Text="Login without Roles" />
            
    </form>
</body>
</html>
