<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="HotelManagement.UI.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Content/css") %>
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/MsAjaxJs") %>
    </asp:PlaceHolder>
</head>
<body>
     <div class="container ">
     <div class="d-flex justify-content-center">
    <form id="form1" runat="server">
        
        <div class="font-weight-bold">
         <asp:Label class="btn-block mb-4" ID="Label2" runat="server" Text="Login to you Account" Font-Size="20pt" ForeColor="#000066" Width="400px" BackColor="#CCCCCC"></asp:Label>

        </div>
        <br />
            <div class="form-group">
                <label for="exampleInputEmail1">UserName</label>
                <asp:TextBox class="form-control" ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <asp:TextBox ID="TextBox2" type="password" class="form-control" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
            </div>
        <div class="form-group">
                <label for="exampleInputEmail1">Address</label>
                <asp:TextBox class="form-control" ID="TextBox3" runat="server" Width="400px"></asp:TextBox>
            </div>
        <div class="form-group">
                <label for="exampleInputEmail1">Mobile Number</label>
                <asp:TextBox class="form-control" ID="TextBox4" runat="server" Width="400px"></asp:TextBox>
            </div>
        <div class="form-group">
                <label for="exampleInputEmail1">User Role</label>
                <asp:TextBox class="form-control" ID="TextBox5" runat="server" Width="400px"></asp:TextBox>
            </div>


        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />

        <asp:Button ID="Button1" runat="server" class="Primary" Text="Register"  OnClick="Button1_Click" /><br /> <br />
        
        
    </form>
         
     </div>
        </div>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/jquery") %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
    </asp:PlaceHolder>
</body>
</html>
