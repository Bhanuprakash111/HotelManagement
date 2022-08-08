<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ListMenuItems.aspx.cs" Inherits="HotelManagement.UI.Menu.ListMenuItems" %>

<asp:Content ID="Customer" ContentPlaceHolderID="CustomerContent" runat="server">
    <div class="dropdown">
        <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-expanded="false">Dropdown link
        </a>
        <div class="dropdown-menu">
            <a class="dropdown-item" href="#">Action</a>
            <a class="dropdown-item" href="#">Another action</a>
            <a class="dropdown-item" href="#">Something else here</a>
        </div>
    </div>
     <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/bootstrap") %>
    </asp:PlaceHolder>
</asp:Content>
