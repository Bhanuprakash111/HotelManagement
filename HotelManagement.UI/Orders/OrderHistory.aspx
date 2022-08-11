﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="HotelManagement.UI.Orders.OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">
    <div class="container">
        <div class="h4 mt-3 mb-3">Your Order History :</div>
        <asp:ListView ID="OrderListView" runat="server">
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
                        <asp:LinkButton ID="OrderMoreInfo" runat="server" href="#" class="btn btn-outline-primary" OnClick="OrderMoreInfo_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.OrderId")%>'>
                    More info</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
