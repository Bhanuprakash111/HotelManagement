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
<body >
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
            <div class="col-lg-6 mt-1">
                <form id="form2" runat="server" class=" mt-4 offset-3 needs-validation">
                    <div class="form-group">
                        <label for="username">UserName</label>
                        <asp:TextBox ID="userName" class="form-control" AutoCompleteType="DisplayName" runat="server" required="true" Width="400px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="password">Password</label>
                           <input type="password" class="form-control" id="validationPassword" runat="server" minlength="8" name="password" placeholder="Password" value="" required="required"/>
                            <div class="progress" style="height: 5px;">
                                <div id="progressbar" class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 10%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                            </div>
                            <small id="passwordHelpBlock" class="form-text text-muted">Your password must be 8-20 characters long,  must contain special characters "!@#$%&*_?", numbers, lower and upper letters only.
                            </small>
                            <div id="feedbackin" class="valid-feedback">
                                Strong Password!
                            </div>
                            <div id="feedbackirn" class="invalid-feedback">
                                Atlead 8 characters, Number, special character  Caplital Letter and Small letters
                            </div>
                    </div>
                    <div class="form-group">
                        <label for="address">Address</label>
                        <textarea class="form-control" id="address" runat="server" rows="3" maxlength="250" style="resize: none; width: 400px"></textarea>
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
    <script type="text/javascript">
        (function () {
            'use strict';
            window.addEventListener('load', function () {
                // Fetch all the forms we want to apply custom Bootstrap validation styles to
                var forms = document.getElementsByClassName('needs-validation');
                // Loop over them and prevent submission
                var validation = Array.prototype.filter.call(forms, function (form) {
                    // making sure password enters the right characters
                    form.validationPassword.addEventListener('keypress', function (event) {
                        console.log("keypress");
                        console.log("event.which: " + event.which);
                        var checkx = true;
                        var chr = String.fromCharCode(event.which);
                        console.log("char: " + chr);


                        var matchedCase = new Array();
                        matchedCase.push("[!@#$%&*_?]"); // Special Charector
                        matchedCase.push("[A-Z]");      // Uppercase Alpabates
                        matchedCase.push("[0-9]");      // Numbers
                        matchedCase.push("[a-z]");

                        for (var i = 0; i < matchedCase.length; i++) {
                            if (new RegExp(matchedCase[i]).test(chr)) {
                                console.log("checkx: is true");
                                checkx = false;
                            }
                        }

                        if (form.validationPassword.value.length >= 20)
                            checkx = true;

                        if (checkx) {
                            event.preventDefault();
                            event.stopPropagation();
                        }

                    });

                    //Validate Password to have more than 8 Characters and A capital Letter, small letter, number and special character
                    // Create an array and push all possible values that you want in password
                    var matchedCase = new Array();
                    matchedCase.push("[$@$$!%*#?&]"); // Special Charector
                    matchedCase.push("[A-Z]");      // Uppercase Alpabates
                    matchedCase.push("[0-9]");      // Numbers
                    matchedCase.push("[a-z]");     // Lowercase Alphabates


                    form.validationPassword.addEventListener('keyup', function () {

                        var messageCase = new Array();
                        messageCase.push(" Special Charector"); // Special Charector
                        messageCase.push(" Upper Case");      // Uppercase Alpabates
                        messageCase.push(" Numbers");      // Numbers
                        messageCase.push(" Lower Case");     // Lowercase Alphabates

                        var ctr = 0;
                        var rti = "";
                        for (var i = 0; i < matchedCase.length; i++) {
                            if (new RegExp(matchedCase[i]).test(form.validationPassword.value)) {
                                if (i == 0) messageCase.splice(messageCase.indexOf(" Special Charector"), 1);
                                if (i == 1) messageCase.splice(messageCase.indexOf(" Upper Case"), 1);
                                if (i == 2) messageCase.splice(messageCase.indexOf(" Numbers"), 1);
                                if (i == 3) messageCase.splice(messageCase.indexOf(" Lower Case"), 1);
                                ctr++;
                                //console.log(ctr);
                                //console.log(rti);
                            }
                        }


                        //console.log(rti);
                        // Display it
                        var progressbar = 0;
                        var strength = "";
                        var bClass = "";
                        switch (ctr) {
                            case 0:
                            case 1:
                                strength = "Way too Weak";
                                progressbar = 15;
                                bClass = "bg-danger";
                                break;
                            case 2:
                                strength = "Very Weak";
                                progressbar = 25;
                                bClass = "bg-danger";
                                break;
                            case 3:
                                strength = "Weak";
                                progressbar = 34;
                                bClass = "bg-warning";
                                break;
                            case 4:
                                strength = "Medium";
                                progressbar = 65;
                                bClass = "bg-warning";
                                break;
                        }

                        if (strength == "Medium" && form.validationPassword.value.length >= 8) {
                            strength = "Strong";
                            bClass = "bg-success";
                            form.validationPassword.setCustomValidity("");
                        } else {
                            form.validationPassword.setCustomValidity(strength);
                        }

                        var sometext = "";

                        if (form.validationPassword.value.length < 8) {
                            var lengthI = 8 - form.validationPassword.value.length;
                            sometext += ` ${lengthI} more Characters, `;
                        }

                        sometext += messageCase;
                        console.log(sometext);

                        console.log(sometext);

                        if (sometext) {
                            sometext = " You Need" + sometext;
                        }

                        $("#feedbackin, #feedbackirn").text(strength + sometext);
                        $("#progressbar").removeClass("bg-danger bg-warning bg-success").addClass(bClass);
                        var plength = form.validationPassword.value.length;
                        if (plength > 0) progressbar += ((plength - 0) * 1.75);
                        //console.log("plength: " + plength);
                        var percentage = progressbar + "%";
                        form.validationPassword.parentNode.classList.add('was-validated');
                        //console.log("pacentage: " + percentage);
                        $("#progressbar").width(percentage);

                        if (form.validationPassword.checkValidity() === true) {
                            form.verifyPassword.disabled = false;
                        } else {
                            form.verifyPassword.disabled = true;
                        }
                    });
                });
            }, false);
        })();
    </script>
</body>
</html>
