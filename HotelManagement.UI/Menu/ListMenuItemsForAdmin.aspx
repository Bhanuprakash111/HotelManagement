<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListMenuItemsForAdmin.aspx.cs" Inherits="HotelManagement.UI.Menu.ListMenuItemsForAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Admin" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="h4 my-3 ml-5 pl-2">Welcome Admin, <span class="font-italic text-info"><%=Session["username"] %></span></div>
    <div class="d-flex mt-3 offset-3">
        <span class="lead p-1">Select your Style : </span>
        <asp:DropDownList ID="MenuDropDownAdmin" CssClass="custom-select ml-4 w-25" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MenuDropDownAdmin_SelectedIndexChanged" AppendDataBoundItems="True">
            <asp:ListItem>Breakfast</asp:ListItem>
            <asp:ListItem>Starters</asp:ListItem>
            <asp:ListItem>Desserts</asp:ListItem>
            <asp:ListItem>MainCourse</asp:ListItem>
            <asp:ListItem>Snacks</asp:ListItem>
            <asp:ListItem>Drinks</asp:ListItem>
            <asp:ListItem>Soups</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton class="ml-3 lead btn btn-primary" runat="server" Style="cursor: pointer; color: dodgerblue" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight1" aria-controls="offcanvasRight" data-toggle="modal" data-target="#AddMenuItem">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-plus-square-fill" viewBox="0 0 16 16">
                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0z" />
            </svg>
            <span class="text-light">Add Item</span>
        </asp:LinkButton>
    </div>
    <asp:Label ID="AddWarning" ForeColor="Red" CssClass="offset-5" runat="server"></asp:Label>
    <div class="modal fade" id="AddMenuItem" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Add New MenuItem</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label>Item Name</label>
                    <asp:TextBox class="form-control mb-2" ID="AddItemName" runat="server" Type="string"></asp:TextBox>
                    <label>Item Category</label>
                    <asp:DropDownList ID="AddItemCategory" CssClass="custom-select " runat="server">
                        <asp:ListItem>Breakfast</asp:ListItem>
                        <asp:ListItem>Starters</asp:ListItem>
                        <asp:ListItem>Desserts</asp:ListItem>
                        <asp:ListItem>MainCourse</asp:ListItem>
                        <asp:ListItem>Snacks</asp:ListItem>
                        <asp:ListItem>Drinks</asp:ListItem>
                        <asp:ListItem>Soups</asp:ListItem>
                    </asp:DropDownList>
                    <label>Item Cost</label>
                    <asp:TextBox class="form-control " ID="AddItemCost" type="number" runat="server"></asp:TextBox>
                    <label>Item Availability</label>
                    <asp:DropDownList ID="AddItemAvailability" CssClass="custom-select mb-2" runat="server">
                        <asp:ListItem Value="yes">Yes</asp:ListItem>
                        <asp:ListItem Value="no">No</asp:ListItem>
                    </asp:DropDownList>
                    <label>Item Image</label>
                    <asp:DropDownList ID="AddItemImage" CssClass="custom-select " runat="server">
                        <asp:ListItem Value="blueberry">Blueberry</asp:ListItem>
                        <asp:ListItem Value="butterscotch">Butterscotch</asp:ListItem>
                        <asp:ListItem Value="chicken_biryani">Chicken Biryani</asp:ListItem>
                        <asp:ListItem Value="chicken_dum_biryani">Chicken Dum Biryani</asp:ListItem>
                        <asp:ListItem Value="chicken_soup">Chicken Soup</asp:ListItem>
                        <asp:ListItem Value="chilly_chicken">Chilly Chicken</asp:ListItem>
                        <asp:ListItem Value="chips">Chips</asp:ListItem>
                        <asp:ListItem Value="chocolate_icecream">Chocolate Icecream</asp:ListItem>
                        <asp:ListItem Value="death_by_choclate">Death By Chocolate</asp:ListItem>
                        <asp:ListItem Value="dosa">Dosa</asp:ListItem>
                        <asp:ListItem Value="faluda">Faluda</asp:ListItem>
                        <asp:ListItem Value="fanta">Fanta</asp:ListItem>
                        <asp:ListItem Value="fishfry">Fishfry</asp:ListItem>
                        <asp:ListItem Value="french_fries">French Fries</asp:ListItem>
                        <asp:ListItem Value="idli">Idli</asp:ListItem>
                        <asp:ListItem Value="idli_sambar">Idly Sambar</asp:ListItem>
                        <asp:ListItem Value="maggie">Maggie</asp:ListItem>
                        <asp:ListItem Value="manchuria">Manchuria</asp:ListItem>
                        <asp:ListItem Value="mojito">Mojito</asp:ListItem>
                        <asp:ListItem Value="mutton_dum_biriyani">Mutton Dum Biriyani</asp:ListItem>
                        <asp:ListItem Value="mutton_soup">Mutton Soup</asp:ListItem>
                        <asp:ListItem Value="panneer_tikka">Panner Tikka</asp:ListItem>
                        <asp:ListItem Value="panner_biryani">Panner Biryani</asp:ListItem>
                        <asp:ListItem Value="pepsi">Pepsi</asp:ListItem>
                        <asp:ListItem Value="poori">Poori</asp:ListItem>
                        <asp:ListItem Value="prawns_biryani">Prawns Biryani</asp:ListItem>
                        <asp:ListItem Value="samosa">Samosa</asp:ListItem>
                        <asp:ListItem Value="sushi">Sushi</asp:ListItem>
                        <asp:ListItem Value="tandoori">Tandoori</asp:ListItem>
                        <asp:ListItem Value="vada">Vada</asp:ListItem>
                        <asp:ListItem Value="vanilla">Vanilla</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button ID="CreateItem" Class="btn btn-primary" runat="server" Text="Create new menuItem" OnClick="CreateButton_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="EditModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Edit MenuItem</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="EditItemName" runat="server" />
                            <asp:HiddenField ID="EditItemCategory" runat="server" />
                            <label>Item Cost</label>
                            <asp:TextBox class="form-control mb-2" ID="EditItemCost" type="number" runat="server"></asp:TextBox>
                            <label>Item Availability</label>
                            <asp:DropDownList ID="EditItemAvailability" CssClass="custom-select mb-2" runat="server">
                                <asp:ListItem Value="yes">Yes</asp:ListItem>
                                <asp:ListItem Value="no">No</asp:ListItem>
                            </asp:DropDownList>
                            <label>Item Image</label>
                            <asp:DropDownList ID="EditItemImage" CssClass="custom-select " runat="server">
                                <asp:ListItem Value="blueberry">Blueberry</asp:ListItem>
                                <asp:ListItem Value="butterscotch">Butterscotch</asp:ListItem>
                                <asp:ListItem Value="chicken_biryani">Chicken Biryani</asp:ListItem>
                                <asp:ListItem Value="chicken_dum_biryani">Chicken Dum Biryani</asp:ListItem>
                                <asp:ListItem Value="chicken_soup">Chicken Soup</asp:ListItem>
                                <asp:ListItem Value="chilly_chicken">Chilly Chicken</asp:ListItem>
                                <asp:ListItem Value="chips">Chips</asp:ListItem>
                                <asp:ListItem Value="chocolate_icecream">Chocolate Icecream</asp:ListItem>
                                <asp:ListItem Value="death_by_choclate">Death By Chocolate</asp:ListItem>
                                <asp:ListItem Value="dosa">Dosa</asp:ListItem>
                                <asp:ListItem Value="faluda">Faluda</asp:ListItem>
                                <asp:ListItem Value="fanta">Fanta</asp:ListItem>
                                <asp:ListItem Value="fishfry">Fishfry</asp:ListItem>
                                <asp:ListItem Value="french_fries">French Fries</asp:ListItem>
                                <asp:ListItem Value="idli">Idli</asp:ListItem>
                                <asp:ListItem Value="idli_sambar">Idly Sambar</asp:ListItem>
                                <asp:ListItem Value="maggie">Maggie</asp:ListItem>
                                <asp:ListItem Value="manchuria">Manchuria</asp:ListItem>
                                <asp:ListItem Value="mojito">Mojito</asp:ListItem>
                                <asp:ListItem Value="mutton_dum_biriyani">Mutton Dum Biriyani</asp:ListItem>
                                <asp:ListItem Value="mutton_soup">Mutton Soup</asp:ListItem>
                                <asp:ListItem Value="panneer_tikka">Panner Tikka</asp:ListItem>
                                <asp:ListItem Value="panner_biryani">Panner Biryani</asp:ListItem>
                                <asp:ListItem Value="pepsi">Pepsi</asp:ListItem>
                                <asp:ListItem Value="poori">Poori</asp:ListItem>
                                <asp:ListItem Value="prawns_biryani">Prawns Biryani</asp:ListItem>
                                <asp:ListItem Value="samosa">Samosa</asp:ListItem>
                                <asp:ListItem Value="sushi">Sushi</asp:ListItem>
                                <asp:ListItem Value="tandoori">Tandoori</asp:ListItem>
                                <asp:ListItem Value="vada">Vada</asp:ListItem>
                                <asp:ListItem Value="vanilla">Vanilla</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" id="CloseModal" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:Button ID="SaveEditChanges" class="btn btn-primary" runat="server" Text="Save changes" OnClick="SaveEditChanges_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-3 ml-5">
        <asp:Repeater ID="CardRepeaterAdmin" runat="server" OnItemDataBound="CardRepeaterAdmin_ItemDataBound">
            <ItemTemplate>
                <div class="card mb-3 mx-2 col-4 col-md-6 col-sm-12 p-0" style="max-width: 400px;">
                    <div class="row no-gutters">
                        <div class="col-6 img-fluid img">
                            <asp:Image id="AdminImage" CssClass="rounded" runat="server" />
                        </div>
                        <div class="col-6">
                            <div class="card-body">
                                <h5 class="h3 text-center"><%#DataBinder.Eval(Container,"DataItem.ItemName")%> </h5>
                                <div class="d-flex justify-content-center">
                                    <div class="pr-3 lead">Cost:</div>
                                    <p class="card-text lead">₹<%#DataBinder.Eval(Container,"DataItem.Cost")%></p>
                                </div>
                                <div class="d-flex justify-content-center mt-1">
                                    <div class="pr-3 ">Availability: </div>
                                    <p class="card-text "><%#DataBinder.Eval(Container,"DataItem.Availability")%> </p>
                                </div>
                            </div>
                            <div class="d-flex justity-content-center ml-3">

                                <asp:LinkButton class=" btn btn-primary" ID="EditMenuItem" OnClick="EditButton_Click" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ItemName")%>'>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                                        <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                                    </svg>
                                 <span class="text-light">Edit</span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="DeleteMenuItem" class=" ml-2 btn btn-danger" runat="server" CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ItemName")%>' OnClick="DeleteButton_Click">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z" />
                                    </svg>
                                     <span class="text-light">Delete</span>
                                </asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
