<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="PasswordRecovery_aspx" title="ChangePassword Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>ChangePassword Control</strong><br /><br />
    The ChangePassword control allows the current user to change their password.<br /><br />

    <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; padding-top: 10px;">
        <asp:ChangePassword ID="ChangePassword1" Runat="server" OnChangedPassword="ChangePassword1_ChangedPassword" SuccessPageUrl="~/ChangePasswordSuccess.aspx" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" >
            <ChangePasswordTemplate>
                <table cellpadding="1" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" border="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        Change Your Password</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label Runat="server" AssociatedControlID="CurrentPassword" ID="CurrentPasswordLabel">Password:</asp:Label></td>
                                    <td>
                                        <asp:TextBox Runat="server" TextMode="Password" ID="CurrentPassword"></asp:TextBox>
                                        <asp:RequiredFieldValidator Runat="server" ControlToValidate="CurrentPassword" ValidationGroup="ChangePassword1"
                                            ErrorMessage="Password is required." ToolTip="Password is required." ID="CurrentPasswordRequired">
                                            *</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label Runat="server" AssociatedControlID="NewPassword" ID="NewPasswordLabel">New Password:</asp:Label></td>
                                    <td>
                                        <asp:TextBox Runat="server" TextMode="Password" ID="NewPassword"></asp:TextBox>
                                        <asp:RequiredFieldValidator Runat="server" ControlToValidate="NewPassword" ValidationGroup="ChangePassword1"
                                            ErrorMessage="New Password is required." ToolTip="New Password is required."
                                            ID="NewPasswordRequired">
                                            *</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label Runat="server" AssociatedControlID="ConfirmNewPassword" ID="ConfirmNewPasswordLabel">Confirm New Password:</asp:Label></td>
                                    <td>
                                        <asp:TextBox Runat="server" TextMode="Password" ID="ConfirmNewPassword"></asp:TextBox>
                                        <asp:RequiredFieldValidator Runat="server" ControlToValidate="ConfirmNewPassword"
                                            ValidationGroup="ChangePassword1" ErrorMessage="Confirm New Password is required."
                                            ToolTip="Confirm New Password is required." ID="ConfirmNewPasswordRequired">
                                            *</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator Runat="server" ControlToValidate="ConfirmNewPassword" ValidationGroup="ChangePassword1"
                                            ID="NewPasswordCompare" Display="Dynamic" ErrorMessage="The confirm New Password must match the New Password entry."
                                            ControlToCompare="NewPassword">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Button Runat="server" Text="Change Password" ValidationGroup="ChangePassword1"
                                            CommandName="ChangePassword" ID="ChangePasswordPushButton" />
                                    </td>
                                    <td>
                                        <asp:Button Runat="server" CausesValidation="False" Text="Cancel" CommandName="Cancel"
                                            ID="CancelPushButton" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="color: Red;">
                                        <asp:Literal Runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ChangePasswordTemplate>
            <SuccessTemplate>
                <table cellpadding="1" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" border="0">
                                <tr>
                                    <td align="center" colspan="2">
                                        Change Password Complete</td>
                                </tr>
                                <tr>
                                    <td>
                                        Your password has been changed!</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button Runat="server" CausesValidation="False" Text="Continue" CommandName="Continue"
                                            ID="ContinuePushButton" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </SuccessTemplate>
            <CancelButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <PasswordHintStyle Font-Italic="True" ForeColor="#888888" />
            <ChangePasswordButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <TextBoxStyle Font-Size="0.8em" />
        </asp:ChangePassword>
        <br />
    </div>
</asp:Content>
