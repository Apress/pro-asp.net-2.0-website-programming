<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="TargetedAdExample.aspx.vb" Inherits="TargetedAdExample_aspx" title="Targeted Ad Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <b>Targed Advertisement Example Page</b><br /><br /> 
    
    This page demonstrates how you can create targeted advertisements (or content) for
    users based on their profiles. Most sites have many pages, but each page probably
    fits nicely into a specific category. For instance, a sports news site may
    have thousands of stores, but chances are each story will fit nicely under a category
    like Baseball, Football, Basketball, Hockey, Racing, etc.<br /><br />
    
    There are four links below. Each link represents a category. There are
    also four profile properties that track the number of times you click on each category.
    This number is conveniently displayed next to the link so you can see it.<br /><br />
    
    There is also an advertisement at the bottom of this page that uses that profile
    information to choose an appropriate advertisment. Click on the links below and see how the ad changes in response to which links you click. You will
    see that it shows you a book from the category that you have clicked on the most.<br /><br />
    
    Also notice that you can close the browser down and return to this page and
    your click count is maintained across browser sessions assuming you have cookies enabled.<br /><br />
    
    <asp:LinkButton ID="lnkBaseball" Runat="server">Baseball</asp:LinkButton>
    <asp:Label ID="lblBaseball" Runat="server"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="lnkBasketball" Runat="server">Basketball</asp:LinkButton>
    <asp:Label ID="lblBasketball" Runat="server"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="lnkFootball" Runat="server">Football</asp:LinkButton>
    <asp:Label ID="lblFootball" Runat="server"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="lnkHockey" Runat="server">Hockey</asp:LinkButton>
    <asp:Label ID="lblHockey" Runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <b>Hey, check out this sports advertisement...<br />
    </b>
    <br />
    <asp:Image ID="imgAd" Runat="server" ImageUrl="~/ProductImages/Baseball.jpg" />

</asp:Content>
