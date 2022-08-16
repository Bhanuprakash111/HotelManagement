<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="HotelManagement.UI.Orders.OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">

    <!-- Modal -->


    <div class="modal fade" id="OrderInfoModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Order Summary</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="ModalUpdatePanel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ListView ID="ModalListView" runat="server">
                                <LayoutTemplate>
                                    <table class="table" id="itemPlaceHolderContainer" runat="server">
                                        <thead>
                                            <tr>
                                                <th>Item Name      
                                                </th>
                                                <th>Quantity
                                                </th>
                                                <th>Item Cost
                                                </th>
                                                <th>Item Total
                                                </th>
                                            </tr>

                                        </thead>
                                        <tr id="itemPlaceHolder" runat="server">
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>

                                    <tr>
                                        <td><%#DataBinder.Eval(Container,"DataItem.MenuItemItemName") %>           
                                        </td>
                                        <td><%#DataBinder.Eval(Container,"DataItem.Quantity") %>           
                                        </td>
                                        <td><%#DataBinder.Eval(Container,"DataItem.ItemCost") %>           
                                        </td>
                                        <td>
                                            <%#DataBinder.Eval(Container,"DataItem.ItemTotal") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                            </asp:ListView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="text-right mr-5 font-weight-bold">Grand Total : 
                        <asp:Label ID="GrandTotal" runat="server"></asp:Label></div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="h4 mt-3 mb-3">Your Order History :</div>
        <asp:ListView ID="OrderListView" runat="server" OnItemDataBound="OrderListView_ItemDataBound">
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
                    <td>
                        <asp:Label class="font-weight-bolder" ID="status" runat="server"><%#DataBinder.Eval(Container,"DataItem.OrderStatus") %>           
                        </asp:Label>
                    </td>
                    <td><%#DataBinder.Eval(Container,"DataItem.TotalCost") %>           
                    </td>
                    <td>
                        <!-- Button trigger modal -->
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-primary"
                            OnClick="OrderMoreInfo_Click" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.OrderId")%>'>
                    More info</asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
