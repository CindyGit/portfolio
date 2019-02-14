<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="OrderMgtServer.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvOrder_RowDataBound"
                CssClass="table-bordered" Width="100%" ShowHeaderWhenEmpty="true">
                <EmptyDataTemplate>尚無訂單資料</EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="訂單編號" />
                    <asp:TemplateField HeaderText="訂單編號" >
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkOrderID" runat="server" OnClick="lnkOrderID_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderDate" HeaderText="訂單日" />
                    <asp:BoundField DataField="RequiredDate" HeaderText="交貨日" />
                    <asp:BoundField DataField="ShippedDate" HeaderText="貨運日" />
                    <asp:TemplateField HeaderText="客戶名稱" >
                        <ItemTemplate>
                            <asp:Label ID="lbCustomer" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="業務員" >
                        <ItemTemplate>
                            <asp:Label ID="lbSales" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </div>

</asp:Content>
