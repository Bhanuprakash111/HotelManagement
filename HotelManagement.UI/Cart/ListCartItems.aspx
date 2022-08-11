<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ListCartItems.aspx.cs" Inherits="HotelManagement.UI.Cart.ListCartItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">

    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table class="table" id="itemPlaceHolderContainer" runat="server">
                <thead>
                    <tr>
                        <th>Item Name           
                        </th>

                        <th>Cost
                        </th>
                        <th>Quantity
                        </th>
                        <th>Total
                        </th>
                        <th>Actions
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
                <td>
                    <asp:Label ID="ItemCost" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ItemCost")%>'></asp:Label>
                </td>
                <asp:HiddenField ID="HiddenItemId" runat="server" Value='<%#DataBinder.Eval(Container,"DataItem.ItemId")%>'/>
                
                <td>
                    <asp:TextBox ID="Quantity" runat="server" type="number" Text='<%#DataBinder.Eval(Container,"DataItem.Quantity") %> ' AutoPostBack="True" OnTextChanged="Quantity_TextChanged">

                    </asp:TextBox>
                </td>
                
                <td>
                    <asp:Label ID="Total" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.ItemTotal")%>'></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="DeleteCartItem" class=" ml-2 btn btn-danger" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ItemId")%>' OnClick="DeleteButton_Click">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z" />
                                    </svg>
                                     
                    </asp:LinkButton>
                </td>
               
            </tr>
                         

        </ItemTemplate>
        <EmptyDataTemplate>
            <div class="mt-5 h2 text-center">What are you looking At?</div>
            <div class="h3 text-center">Your Cart is Empty</div>
        </EmptyDataTemplate>

    </asp:ListView>
   <asp:Label ID="GrandTotal" runat="server" Text="GrandTotal : " CssClass="offset-8"></asp:Label> 
   <asp:Label ID="GrandTotalValue" runat="server" ></asp:Label> 

</asp:Content>
