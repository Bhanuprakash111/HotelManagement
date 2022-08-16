<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HotelManagement.UI.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/Content/css") %>
        <%: Styles.Render("~/Content/toastr") %>
        <%: Scripts.Render("~/bundles/modernizr") %>
        <%: Scripts.Render("~/bundles/MsAjaxJs") %>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/jquery") %>
        <%: Scripts.Render("~/bundles/bootstrap") %>
        <%: Scripts.Render("~/bundles/toastr") %>
    </asp:PlaceHolder>
    <script type="text/javascript">
        function ToastrNotification(msg, status) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": true,
                "positionClass": "toast-top-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr[status](msg);
        };
        /*ToastrNotification('Login Failed', 'error');*/
        /*$(window).on("load", function () {
            toastr.error("login failed");
        });*/
        
    </script>
</head>
<body>
    <div class="d-flex mt-2">
        <div class="">
            <span class="font-weight-bolder h3 ml-5  d-block">Food Mafia</span>
            <span class="h6 ml-5 ">Food For Every Taste</span>
        </div>
        <h4 class="text-center mt-3 offset-3">Log In to Your Food Mafia Account!</h4>
    </div>
    <hr />
    <div class="container">
        <div class="row mt-3">
            <div class="col-lg-6 col-sm-12 text-center">
                <asp:Image ID="Image1" ImageUrl="~/Content/images/Login.jpg" CssClass="img-fluid rounded" Height="550px" runat="server" />
            </div>
            <div class="col-lg-6 mt-5">
                <form id="form1" runat="server" class=" mt-5 offset-3">
                    <div class="form-group">
                        <label for="username">UserName</label>
                        <asp:TextBox class="form-control" required="true" ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Password</label>
                        <asp:TextBox ID="TextBox2" type="password" required="true" class="form-control" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
                    </div>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
                    <div class="d-flex mt-2">
                        <asp:Button ID="Button1" class="offset-3 btn btn-primary" runat="server" Text="Login" OnClick="Button1_Click" /><br />
                        <asp:Button ID="Button2" class="ml-3 btn btn-info" runat="server" Text="Signup" OnClick="Button2_Click" UseSubmitBehavior="False" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
