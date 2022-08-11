<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="OrdersPlaced.aspx.cs" Inherits="HotelManagement.UI.Orders.OrdersPlaced" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="container">
        <asp:ListView ID="OrderListViewAdmin" runat="server">
            <EmptyDataTemplate>
                <div class="mt-5 h2 text-center">No Order history</div>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table" id="itemPlaceHolderContainer" runat="server">
                    <thead>
                        <tr>    
                            <th>Order Date           
                            </th>
                            <th>Order Status
                            </th>
                            <th>Total Cost
                            </th>
                            <th>More Info
                            </th>
                            <th>Deliver
                            </th>
                        </tr>

                    </thead>
                    <tr id="itemPlaceHolder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#DataBinder.Eval(Container,"DataItem.Date") %>           
                    </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.OrderStatus") %>           
                    </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.TotalCost") %>           
                    </td>
                    <td>
                        <asp:LinkButton ID="AdminOrderMoreInfo" runat="server" class="btn btn-outline-primary" OnClick="AdminOrderMoreInfo_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.OrderId")%>'>
                    More info</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="Deliver" runat="server" class="btn btn-outline-warning" OnClick="DeliverOrder_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.OrderId")%>'>
                    Deliver Order</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
