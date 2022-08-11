<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="HotelManagement.UI.Orders.OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">

    <asp:ListView ID="OrderListView" runat="server">
        <EmptyDataTemplate>
            <div class="h4">No Order history</div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="card">
                <h5 class="card-header"><%# DataBinder.Eval(Container,"DataItem.Date")%></h5>
                <div class="card-body">
                    <h5 class="card-title"><%# DataBinder.Eval(Container,"DataItem.OrderStatus")%></h5>
                    <p class="card-text"><%# DataBinder.Eval(Container,"DataItem.TotalCost")%></p>
                    <a href="#" class="btn btn-primary">More info</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
