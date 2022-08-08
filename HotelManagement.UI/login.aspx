<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HotelManagement.UI.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Content/css") %>
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/MsAjaxJs") %>
    </asp:PlaceHolder>
</head>
<body>
    <div class="d-flex align-items-center justify-content-center">
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
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />

                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /><br /> 
                <br />
                <asp:Button ID="Button2" runat="server" Text="Signup" OnClick="Button2_Click" />

            </form>
        </div>
    </div>
           
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/jquery") %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
    </asp:PlaceHolder>
</body>
</html>
