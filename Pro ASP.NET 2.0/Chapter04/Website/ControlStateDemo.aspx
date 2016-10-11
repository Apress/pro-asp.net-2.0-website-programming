<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ControlStateDemo.aspx.vb" Inherits="ControlStateDemo_aspx" title="Control State Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <strong>ControlState Demo</strong><br /><br />
    
    This page demonstrates the difference between storing data in the ControlState vs. 
    the ViewState.  The ViewState can be turned off entirely, but sometimes data in a 
    control needs to be saved for the control to function appropriately.  Thus, the
    ControlState was created to ensure that required data for a control was always
    saved, even when the ViewState was disabled.
    <br /><br />
    
    Using the option buttons below, select whether or not you would like to enable or
    disable the ViewState, then click on the "Post-Back" button to post the page back.
    You will see the counter that relies on the ControlState will maintain an accurate
    Post-Back count while the counter that relies on the ViewState will not maintain
    an accurate count.<br /><br />
    
    <asp:RadioButton ID="rbViewStateOn" Runat="server" Checked="True"
         GroupName="ToggleViewState" Text="Enable View State" AutoPostBack="True"/>
    <asp:RadioButton ID="rbViewStateOff" Runat="server" Checked="False" 
         GroupName="ToggleViewState" Text="Disable View State" AutoPostBack="True"/>
    <br /><br />
    <msgControls:ControlStateExample ID="ExampleControl1" Runat="server" /><br />
    <br />
    <asp:Button ID="btnClearCounters" Runat="Server" Text="Clear Counters" 
         OnClick="btnClearCounters_Click"/>
    <asp:Button ID="btnPostBack" Runat="server" Text="Post-Back" />
</asp:Content>
