<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="HotelManagement.UI.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <h4 class="text-center mt-3 offset-3">Hurry Up! Delicious Food is Waiting for You</h4>
    </div>
    <hr />
    <div class="container">
        <div class="row mt-3">
            <div class="col-lg-6 col-sm-12 text-center">
                <asp:Image ID="Image1" ImageUrl="~/Content/images/Signup.jpg" CssClass="img-fluid rounded" Height="550px" runat="server" />
            </div>
            <div class="col-lg-6 mt-3">
                <form id="form2" runat="server" class=" mt-4 offset-3">
                    <div class="form-group">
                        <label for="username">UserName</label>
                        <asp:TextBox ID="userName" class="form-control" AutoCompleteType="DisplayName" runat="server" required="true" Width="400px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Password</label>
                        <asp:TextBox ID="password" type="password" class="form-control" runat="server" MaxLength="50" required="true" Width="400px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="address">Address</label>
                        <textarea class="form-control" id="address" runat="server" rows="3" maxlength="250" style="resize: none;width:400px"></textarea>
                    </div>
                    <div class="form-group">
                        <label for="mobilenumber">Mobile Number</label>
                        <asp:TextBox ID="mobileNumber" class="form-control" type="number" required="true" runat="server" Width="400px"></asp:TextBox>
                    </div>
                    <asp:Label ID="SignUpWarningText" CssClass="text-center d-block" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Button ID="Button1" runat="server" class="offset-3 mt-2 btn btn-primary" Text="Register" OnClick="Button1_Click" />
                    <asp:LinkButton ID="LinkButton1" href="login.aspx" class="btn btn-dark mt-2 ml-3" runat="server">Back</asp:LinkButton>
                </form>
            </div>
        </div>
    </div>
   
</body>
</html>
