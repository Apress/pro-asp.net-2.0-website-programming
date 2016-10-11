<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="ShoppingCartExample.aspx.vb" Inherits="ShoppingCartExample_aspx" title="Shopping Cart Example" %>
<%@ Register TagPrefix="uc1" TagName="ProductDisplayer" Src="ProductDisplayer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <b>Shopping Cart Example Page</b><br />
    <br /> 
    This page demonstrates the shopping cart functionality exposed by the ShoppingCart
    property of the Profile object.&nbsp; The shopping cart is actually a class defined
    in ShoppingCart.Cart, that stores a list of ShoppingCart.Product objects that have
    been added to the cart.<br />
    <br />
    Since the ShoppingCart property is an anonymous profile property, you do not have
    to be logged in to use the shopping cart.&nbsp; If you add items to your shopping
    cart as an anonymous user, and you have existing items in your authenticated profile,
    then those items will all be merged together when you login.&nbsp;
    <br />
    <br />
    <span style="text-decoration: underline">Exercise 1 - Item Retention Across Sessions</span><br />
    Try adding items to your shopping cart as an anonymous user.&nbsp; Exit the browser.&nbsp;
    When you return, you will notice that those items are still in your cart.&nbsp;
    <br />
    <br />
    <span style="text-decoration: underline">Exercise 2 - Anonymous and Authenticated Cart
    Merging</span><br />
    Clear your anonymous shopping cart if you just did Exercise 1, then Login to the
    site (username Guest, password Guest01!).&nbsp; Add some items to your authenticated
    shopping cart, then log out.&nbsp; As an anonymous user, add some items to your
    shopping cart.&nbsp; Then log back in.&nbsp; You will notice that all of the items from both your authenticated and your anonymous session will be in your authenticated
    cart.<br />
    <br />
    <b>Items You Can Add to Your Shopping Cart</b><br />
    <table cellpadding=3><tr>
            <td><uc1:ProductDisplayer id="ProductA" ImageUrl="~/ProductImages/Office2003.gif" ProductID="Office2003" ProductName="Office 2003 Programming" UnitPrice="39.99" runat="server"/></td>
            <td><uc1:ProductDisplayer id="ProductB" ImageUrl="~/ProductImages/SharePoint.gif" ProductID="SharePoint" ProductName="Advanced SharePoint" UnitPrice="59.99" runat="server"/></td>
        </tr>
        <tr>
            <td><uc1:ProductDisplayer id="ProductD" ImageUrl="~/ProductImages/SQLServer.gif" ProductID="SQL2005" ProductName="Pro SQL Server 2005" UnitPrice="49.99" runat="server" /></td>
            <td><uc1:ProductDisplayer id="ProductC" ImageUrl="~/ProductImages/MSMQ.gif" ProductID="MSMQ" ProductName="Pro MSMQ" UnitPrice="49.99" runat="server"/></td>
        </tr>        
    </table>
    <br />
    <br />
    <b>Items in Your Shopping Cart</b><br />
    <div style="padding-right: 3px; padding-left: 3px; padding-bottom: 3px; padding-top: 3px;">
        <asp:GridView ID="gridShoppingCart" Runat="server" AutoGenerateColumns="False" BorderColor="Black"
            BorderStyle="Solid" BorderWidth="1px" EnableViewState="False" ShowFooter="True" CellPadding="3">
            <FooterStyle BackColor="Gray"></FooterStyle>
            <HeaderStyle BackColor="#1A3C74" ForeColor="White"></HeaderStyle>
            <EmptyDataTemplate>
                There are no items in your shopping cart.&nbsp; Please add some!
            </EmptyDataTemplate>
            <AlternatingRowStyle BackColor="#E0E0E0"></AlternatingRowStyle>
            <Columns>
                <asp:TemplateField HeaderText="Product Name"><FooterTemplate>
                        <B>Total</B>
                    </FooterTemplate>
                    <ItemTemplate>
                        <%#Container.DataItem.ProductName%>
                    </ItemTemplate>
                    <HeaderStyle ForeColor="White" HorizontalAlign="Left"></HeaderStyle>
                    <FooterStyle ForeColor="Black"></FooterStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Product ID" DataField="ProductID"><HeaderStyle ForeColor="White" HorizontalAlign="Left"></HeaderStyle></asp:BoundField>
                <asp:BoundField HeaderText="Unit Price" DataField="UnitPrice">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Quantity" DataField="Quantity">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <HeaderStyle ForeColor="White" HorizontalAlign="Center"></HeaderStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Total">                 
                    <FooterTemplate>
                        <B><%=FormatCurrency(Profile.ShoppingCart.GetTotal(), 2)%></B>
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    <ItemTemplate>
                        <%#FormatCurrency(Container.DataItem.TotalPrice, 2)%>
                    </ItemTemplate>
                    <HeaderStyle ForeColor="White" HorizontalAlign="Right"></HeaderStyle>
                    <FooterStyle HorizontalAlign="Right" ForeColor="Black"></FooterStyle>
                </asp:TemplateField>
            </Columns>            
        </asp:GridView>
        <div style="padding-top: 3px;"><asp:LinkButton ID="linkClearShoppingCart" Runat="server" Enabled=false>Clear Shopping Cart</asp:LinkButton></div>
        <br /><br />
    </div>
    <asp:LoginView ID="LoginView1" Runat="server">
        <LoggedInTemplate>
            <DIV>
                <B>You are currently logged in as <asp:LoginName ID="LoginName1" Runat="server" /></B><br /><br />
                You can log out by clicking the button below.<br />
                <br />
                <asp:Button Runat=server ID=btnLogout Text="Log Out" OnClick="btnLogout_Click" />
            </DIV>                        
        </LoggedInTemplate>
        <AnonymousTemplate>
            <DIV>
                <B>You are not currently logged in.</B><br />
                You can login using the field below.  The username is Guest, and the password is Guest01!
                <br /><br />
            </DIV>                        
            <asp:Login ID="Login1" Runat="server" DisplayRememberMe="False" DestinationPageUrl="~/ShoppingCartExample.aspx" TitleText="" Width="100%" UserName="Guest"></asp:Login>
        </AnonymousTemplate>
    </asp:LoginView>
    <br />       
</asp:Content>
