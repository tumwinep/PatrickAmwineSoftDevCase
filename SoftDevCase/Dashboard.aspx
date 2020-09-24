<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SoftDevCase.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMainContent" runat="server">
    <h3>DashBoard</h3>
    <p>Select Date Range:</p>
    <div class="input-group">
        <table style="width: 100%;">
            <tr>
                <td>From Date:</td>
                <td>
                    <div>
                        <asp:Calendar ID="cldr_fromDate" runat="server" Visible="false" OnSelectionChanged="cldr_fromDate_SelectionChanged"></asp:Calendar>
                    </div>
                    <asp:TextBox ID="txt_fromdatepicker" runat="server" ></asp:TextBox>
                    <asp:LinkButton ID="lnbtn_pickDate" runat="server" OnClick="lnbtn_pickDate_click">GetDate</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
                <td>To Date:</td>
                <td>
                    <div>
                        <asp:Calendar ID="cldr_toDate" runat="server" Visible="false" OnSelectionChanged="cldr_toDate_SelectionChanged"></asp:Calendar>
                    </div>
                    <asp:TextBox ID="txt_todatepicker" runat="server" ></asp:TextBox>
                    <asp:LinkButton ID="lnbtn_pickDateTo" runat="server" OnClick="lnbtn_pickDateTo_click">GetDate</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <div class="form-group">
                        <asp:Button ID="btnSubmit" runat="server" class="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </td>

            </tr>
        </table>


    </div>

    <asp:MultiView ID="mv_dashboardDetails" runat="server">
        <asp:View ID="vw_dashboard" runat="server">
            <h3>
                <asp:Label runat="server" Text="" ID="lbltotProfitDisplay"></asp:Label></h3>

            <div class="input-group">
                <asp:GridView ID="gv_totprofitDetail" runat="server" AllowPaging="True" PageSize="10" AutoGenerateColumns="false" OnPageIndexChanging="indexChangedTotprofit">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="150px" DataField="Order_Date" HeaderText="Order Date" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Order_Priority" HeaderText="Order Priority" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Units_Sold" HeaderText="Units Sold" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Unit_Price" HeaderText="Unit Price" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Total_Cost" HeaderText="Total Cost" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Total_Revenue" HeaderText="Total Revenue" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Item_Type" HeaderText="Item Type" />
                    </Columns>
                </asp:GridView>
            </div>
            <p></p>
            <p></p>
            <p></p>
            <h3>Top 5 Profitable Item Types</h3>
            <div class="input-group">
                <asp:GridView ID="gv_topItems" runat="server" AllowPaging="True" PageSize="10" AutoGenerateColumns="false" OnPageIndexChanging="indexChangedTopItems">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="150px" DataField="Item_Type" HeaderText="Item Type" />
                        <asp:BoundField ItemStyle-Width="150px" DataField="Total_Profit" HeaderText="Total Profit" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:View>
    </asp:MultiView>



</asp:Content>




