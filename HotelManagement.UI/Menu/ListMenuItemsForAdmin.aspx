﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListMenuItemsForAdmin.aspx.cs" Inherits="HotelManagement.UI.Menu.ListMenuItemsForAdmin" %>

<asp:Content ID="Admin" ContentPlaceHolderID="AdminContent" runat="server">

    <div class="d-flex mt-3 offset-3">
        <span class="lead p-1">Select your Style : </span>
        <asp:DropDownList ID="MenuDropDownAdmin" CssClass="custom-select ml-4 w-25" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MenuDropDownAdmin_SelectedIndexChanged">
            <asp:ListItem>BreakFast</asp:ListItem>
            <asp:ListItem>Starters</asp:ListItem>
            <asp:ListItem>Desserts</asp:ListItem>
            <asp:ListItem>MainCourse</asp:ListItem>
            <asp:ListItem>IceCream</asp:ListItem>
        </asp:DropDownList>
        <div class="ml-3 lead btn btn-primary" style="cursor: pointer; color: dodgerblue" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight1" aria-controls="offcanvasRight">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-plus-square-fill" viewBox="0 0 16 16">
                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0z" />
            </svg>
            <span class="text-light">Add Item</span>
        </div>
    </div>
    <div class="row mt-3 ml-5">
        <asp:Repeater ID="CardRepeaterAdmin" runat="server">
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
                                    <p class="card-text lead">₹<%#DataBinder.Eval(Container,"DataItem.Cost")%></p>
                                </div>
                                <div class="d-flex justify-content-center mt-1">
                                    <div class="pr-3 ">Availability: </div>
                                    <p class="card-text "><%#DataBinder.Eval(Container,"DataItem.Availability")%> </p>
                                </div>
                            </div>
                            <div class="d-flex justity-content-center ml-3">
                                <div class="my-auto lead btn btn-success" style="cursor: pointer; color: dodgerblue" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="white" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                                        <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708l-3-3zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207l6.5-6.5zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.499.499 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11l.178-.178z" />
                                    </svg>
                                    <span class="text-light">Edit</span>
                                </div>
                                <asp:HyperLink ID="DeleteMenuItem" class=" ml-2 btn btn-danger" runat="server">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                                        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z" />
                                    </svg>
                                    Delete
                                </asp:HyperLink>
                                
                            </div>

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
