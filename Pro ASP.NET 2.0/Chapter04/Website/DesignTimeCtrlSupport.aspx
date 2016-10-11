<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="DesignTimeCtrlSupport.aspx.vb" Inherits="DesignTimeCtrlSupport" title="Design Time User Control Rendering" %>
<%@ Register Src="UserControls/MyUserControl.ascx" TagName="MyUserControl" TagPrefix="uc1" %>
<%@ Register Src="UserControls/VS2003Mockup.ascx" TagName="VS2003Mockup" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="Server">
    <div>
        <strong>Design-Time User Control Rendering Support</strong><br /><br />
        This page demonstrates the design-time rendering support of user controls in VS.NET 2005.  Make sure 
        you view the page in design mode in the IDE to see the rendering support in action.<br /><br /><br />
        
        <strong><span style="text-decoration: underline">MyUserControl - VS 2003</span></strong><br />
        This shows the design time rendering of the MyUserControl in Visual Studio 2003<br /><br />
        
        <uc2:VS2003Mockup id="VS2003Mockup1" runat="server" /><br />
        <span style="color: #ff0000">*Note: the above item is a "Mockup" of the control as it would appear in VS 2003</span><br /><br /><br />
        <span style="text-decoration: underline"><strong>MyUserControl - VS 2005</strong></span><br />
        This shows the design time rendering of the MyUserControl in Visual Studio 2005<br /><br />
        
        <uc1:MyUserControl id="MyUserControl2" runat="server" /><br />
    
    </div>

    
</asp:Content>

