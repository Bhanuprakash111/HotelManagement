<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="OrdersPlaced.aspx.cs" Inherits="HotelManagement.UI.Orders.OrdersPlaced" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="modal fade" id="MoreInfo" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">More Info</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                             <h3>User Details:</h3>
                            <table>
                                <tr>
                                    <th>UserName </th>
                                    <td>:   <asp:Label ID="UserName" runat="server" ></asp:Label></td>
                                </tr>
                                 <tr>
                                    <th>Address</th>
                                    <td>:   <asp:Label ID="Address" runat="server" ></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Mobile Number</th>
                                    <td>:   <asp:Label ID="Mobile_Number" runat="server" ></asp:Label></td>
                                </tr>
                           </table><br />

                            <h3>Item Details:</h3> 
                            <asp:ListView ID="ListView1" runat="server">
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
                                        <td>
                                            <%#DataBinder.Eval(Container,"DataItem.MenuItemItemName") %> 
                                        </td>
                                    
                                        <td>
                                             <%#DataBinder.Eval(Container,"DataItem.Quantity") %>  
                                        </td>
                                    
                                        <td>
                                              <%#DataBinder.Eval(Container,"DataItem.ItemCost") %>  
                                        </td>
                                    
                                        <td>
                                             <%#DataBinder.Eval(Container,"DataItem.ItemTotal") %>  
                                        </td>
                                    </tr>

                                </ItemTemplate>
                            </asp:ListView>
                            
                                                 
                    
                        </ContentTemplate>
                        
                     </asp:UpdatePanel>
                </div>
                <div class="text-right mr-5 font-weight-bold">Grand Total :  <asp:Label ID="GrandTotal" runat="server" ></asp:Label></div>
                <div class="modal-footer">                    
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    
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

    
</asp:Content>
