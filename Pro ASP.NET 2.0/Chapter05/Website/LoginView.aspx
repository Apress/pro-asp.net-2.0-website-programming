<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="LoginView.aspx.vb" Inherits="LoginView_aspx" title="LoginView Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">

    <strong>Login View</strong><br /><br />
    The Login View controls allows you to define different templates to display to users based on
    their current login status (logged in or anonymous) or their role.  In the following example,
    anonymous users are shown a link to the login page so they can login to the system.  Users who 
    have already logged in are shown a message depending on which role they are in.  You can change 
    your role by selecing or deselecting the various checkbox items below:<br /><br />
    
    <asp:LoginView ID="LoginView1" Runat="server">
        <LoggedInTemplate>
            Add / Remove Current User from Role<br />
            <asp:CheckBox runat="server" id="chkEmployee" Text="Employee Role" AutoPostBack="true" OnCheckedChanged="chkEmployee_CheckedChanged" /><br />
            <asp:CheckBox runat="server" id="chkEmployeeRO" Text="Employee (Read Only) Role"  AutoPostBack="true" OnCheckedChanged="chkEmployeeRO_CheckedChanged" /><br />
            <asp:CheckBox runat="server" id="chkExecutive" Text="Executive Role" AutoPostBack="true" OnCheckedChanged="chkExecutive_CheckedChanged" /><br /><br />            
        </LoggedInTemplate>
    </asp:LoginView>
        
    <asp:LoginView ID="LoginView2" Runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Executive">
                <ContentTemplate>
                    <asp:LoginView ID="ExecLoginView" Runat="server">                    
                        <RoleGroups>
                            <asp:RoleGroup Roles="Employee">
                                <ContentTemplate>
                                    You are an executive and an employee!
                                </ContentTemplate>
                            </asp:RoleGroup>
                        </RoleGroups>
                        <LoggedInTemplate>
                            You are just an executive.
                        </LoggedInTemplate>
                    </asp:LoginView>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Employee, Employee (Read Only)">
                <ContentTemplate>
                    You are an employee
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <LoggedInTemplate>
            You are logged in, but you are not an employee or an executive.
        </LoggedInTemplate>
        <AnonymousTemplate>
            You are not logged in.  Please visit the <a href="Login.aspx">Login</a> page.
        </AnonymousTemplate>
    </asp:LoginView>
    
</asp:Content>