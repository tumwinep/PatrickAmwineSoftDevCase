<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ViewData.aspx.cs" Inherits="SoftDevCase.ViewData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteMainContent" runat="server">
    <h3>View Sales</h3>
    <p>Sales Report Detail</p>
    <div class="input-group">
        <asp:GridView ID="gv_salesRecords" runat="server" AllowPaging="True" PageSize="100" AutoGenerateColumns="false" OnPageIndexChanging="indexChanged">
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



</asp:Content>




