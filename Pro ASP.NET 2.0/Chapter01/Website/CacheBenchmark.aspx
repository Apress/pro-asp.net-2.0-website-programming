<%@ Page Language="VB" MasterPageFile="~/Page.master" AutoEventWireup="false" CodeFile="CacheBenchmark.aspx.vb" Inherits="CacheBenchmark_aspx" title="Cache Benchmark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" Runat="server">
    <div>
        <strong>Configuration Caching Benchmark Instructions</strong><br /><br />
        This page allows you to benchmark the caching abilities in the Config class.  Enter the number of times you to
        read the configuration data using a cached property, and the number of times you want to read the data using a 
        non-cached property.  Then click on the "Run Test" button.  The page will loop using a non-cached configuration 
        item the specified number of times, then run through a cached item the specified number of times.  The total time 
        for each will then be displayed below, along with other statistical information.  You will notice that the 
        non-cached data is exceptionally slower than the cached data.<br /><br />
        
        Please note that the higher these numbers are, the more accurate the benchmark will be.  But, higher numbers will
        also take a lot longer time to process, so please be patient as the page executes.<br /><br />
        
    </div>
    <div>
        <table>
            <tr>
                <td>
                    Number of Non-Cached&nbsp; Iterations</td>
                <td>
                    <asp:TextBox ID="txtIterationsNonCached" Runat="server" EnableViewState="False">5000000</asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnRunTest" Runat="server" Text="Run Test" EnableViewState="False" OnClick="btnRunTest_Click" /></td>
            </tr>
            <tr>
                <td>
                    Number of Cached Iterations</td>
                <td>
                    <asp:TextBox ID="txtIterationsCached" Runat="server" EnableViewState="False">500000000</asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />        
    </div>
    <asp:Panel ID="pnlResults" Runat="server" Visible="False" EnableViewState="False">
        <table cellspacing="5" cellpadding="0">
            <tr>
                <td nowrap colspan=2><strong>Results</strong></td>
            </tr>
            <tr>
                <td nowrap>
                    Non-Cached</td>
                <td nowrap>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblNonCached" Runat="server" EnableViewState="False"></asp:Label>
                </td>
                <td><asp:Label ID="lblNonCachedPerSecond" Runat="server" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td nowrap>
                    Cached</td>
                <td nowrap>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCached" Runat="server" EnableViewState="False"></asp:Label>
                </td>
                <td><asp:Label ID="lblCachedPerSecond" Runat="server" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td colspan=3>&nbsp;</td>
            </tr>
            <tr>
                <td colspan=3><asp:Label Runat=server ID=lblDifference /></td>
            </tr>                
        </table>                        
    </asp:Panel>
</asp:Content>