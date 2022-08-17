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
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,700;0,800;0,900;1,700;1,800;1,900&display=swap" rel="stylesheet" />

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
    <style type="text/css">
        .my-container {
            width: 100%;
            height: 0vh;
            position: relative;
        }

            .my-container video {
                width: 100%;
                height: 500px;
                object-fit: cover;
            }

        .text-box {
            position: absolute;
            top: 0;
            left: 0;
            background: #fff;
            height: 500px;
            width: 100%;
            color: #000;
            display: flex;
            align-items: center;
            justify-content: center;
            font-family: 'Montserrat', sans-serif;
            font-weight: 900;
            font-size: 130px;
            mix-blend-mode: screen;
        }
    </style>
</head>
<body>
    <div class="" style="overflow-x: hidden;overflow-y: hidden;max-width: 100%;">
        <asp:Image ID="headerFood" Height="120px" CssClass="img-fluid img" Width="100%" ImageUrl="~/Content/images/Food_header.jpg" AlternateText="FoodHeader" runat="server" />
       
        <div class="row mt-3 ml-5">
            <div class="col-lg-6 col-sm-12 text-center">
                <div class="my-container">
                    <video autoplay="autoplay" loop="loop" muted="muted">
                        <source type="audio/mp4" src="~/Content/videos/video1.mp4" runat="server" />
                    </video>
                    <div class="text-box">
                        FOOD MAFIA
                        <div class="h1 font-italic">Food For Every Taste</div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 mt-5">
                <h4 class="text-center mt-5">LogIn to Your Food Mafia Account!</h4>
                <form id="form1" runat="server" class=" mt-5 offset-3">

                    <div class="form-group">
                        <label for="username" class="font-weight-bold">User Name</label>
                        <asp:TextBox class="form-control" required="true" ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password" class="font-weight-bold">Password</label>
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
