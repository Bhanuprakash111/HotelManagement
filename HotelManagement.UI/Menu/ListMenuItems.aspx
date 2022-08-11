<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ListMenuItems.aspx.cs" Inherits="HotelManagement.UI.Menu.ListMenuItems" %>

<asp:Content ID="Customer" ContentPlaceHolderID="CustomerContent" runat="server">
    <div class="h4 my-3 ml-5 pl-2">Welcome to Food Mafia, <span class="font-italic text-info"><%=Session["username"] %></span></div>
    <div class="d-flex mt-3 offset-3">
        <span class="lead p-1">Select your Category : </span>
        <asp:DropDownList ID="MenuDropDown" CssClass="custom-select ml-4 w-25" runat="server" OnSelectedIndexChanged="MenuDropDown_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>Breakfast</asp:ListItem>
            <asp:ListItem>Starters</asp:ListItem>
            <asp:ListItem>Desserts</asp:ListItem>
            <asp:ListItem>MainCourse</asp:ListItem>
            <asp:ListItem>Snacks</asp:ListItem>
            <asp:ListItem>Drinks</asp:ListItem>
            <asp:ListItem>Soups</asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:Label ID="WarningLabel" runat="server" ForeColor="Red" class="offset-5"></asp:Label>
    <div class="row mt-3 ml-5">
        <asp:Repeater ID="CardRepeater" runat="server">
            <ItemTemplate>
                    <div class="card mb-3 mx-2 col-4 col-md-6 col-sm-12 p-0" style="max-width: 400px;">
                        <div class="row no-gutters">
                            <div class="col-6 img-fluid img">
                                <img src="https://picsum.photos/200" alt="FoodImage">
                            </div>
                            <div class="col-6">
                                <div class="card-body">
                                    <h5 class="h3 text-center"><%#DataBinder.Eval(Container,"DataItem.ItemName")%> </h5>
                                    <div class="d-flex justify-content-center">
                                        <div class="pr-3 lead">Cost:</div>
                                        <p class="card-text lead">₹<%#DataBinder.Eval(Container,"DataItem.Cost")%>  </p>
                                    </div>
                                    <div class="d-flex justify-content-center mt-1">
                                        <div class="pr-3 ">Availability: </div>
                                        <p class="card-text "><%#DataBinder.Eval(Container,"DataItem.Availability")%> </p>
                                    </div>
                                </div>
                                <asp:LinkButton class="offset-2 btn btn-warning" ID="AddToCart" runat="server" style="cursor: pointer; color: dodgerblue" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ItemName")%>' OnClick="AddToCart_Click">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="black" class="bi bi-cart-plus-fill" viewBox="0 0 16 16">
                                        <path d="M.5 1a.5.5 0 0 0 0 1h1.11l.401 1.607 1.498 7.985A.5.5 0 0 0 4 12h1a2 2 0 1 0 0 4 2 2 0 0 0 0-4h7a2 2 0 1 0 0 4 2 2 0 0 0 0-4h1a.5.5 0 0 0 .491-.408l1.5-8A.5.5 0 0 0 14.5 3H2.89l-.405-1.621A.5.5 0 0 0 2 1H.5zM6 14a1 1 0 1 1-2 0 1 1 0 0 1 2 0zm7 0a1 1 0 1 1-2 0 1 1 0 0 1 2 0zM9 5.5V7h1.5a.5.5 0 0 1 0 1H9v1.5a.5.5 0 0 1-1 0V8H6.5a.5.5 0 0 1 0-1H8V5.5a.5.5 0 0 1 1 0z" />
                                    </svg>
                                    <span class="text-dark">Add to Cart</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
