<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="HotelManagement.UI.UserActions.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CustomerContent" runat="server">
    <div class="modal fade" id="UserDeleteModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">User Deletion Alert!!</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div>Are you Sure?, All your Order History will also be deleted!!! </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" OnClick="DeleteUserBtn_Click" ID="DeleteUserBtn" class="btn btn-primary" Text="Continue" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div class="container my-5 offset-3 ">
        <asp:Label ID="WarningLabel" runat="server" ForeColor="Red" CssClass="h6 offset-3"></asp:Label>
        <div class="card mt-3" style="max-width: 800px;">
            <div class="row no-gutters">
                <div class="col-4">
                    <asp:Image runat="server" ID="userProfilePic" CssClass="img-fluid img-fluid rounded" />
                </div>
                <div class="col-8">
                    <div class="card-body">
                        <div class="row my-2">
                            <div class="col-4 font-weight-bolder">User Name :</div>
                            <asp:Label class="col-8 lead px-0" ID="UsernameLabel" runat="server"></asp:Label>
                        </div>
                        <asp:PlaceHolder runat="server" ID="DisplayUser" Visible="true">
                            <div class="row my-2">
                                <div class=" col-4 font-weight-bolder">Address:</div>
                                <asp:Label class="col-8 lead px-0" ID="AddressLabel" runat="server"></asp:Label>
                            </div>
                            <div class="row my-2">
                                <div class="col-4 font-weight-bolder">Mobile Number :</div>
                                <asp:Label class="col-8 lead px-0" ID="PhoneLabel" runat="server"></asp:Label>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder runat="server" ID="EditUser" Visible="false">
                            <div class="row my-2">
                                <div class=" col-4 font-weight-bolder">Address:</div>
                                <textarea class="col-8 form-control" id="EditAddress" runat="server" rows="3" maxlength="250" style="resize: none;"></textarea>
                            </div>
                            <div class="row my-2">
                                <div class="col-4 font-weight-bolder">Mobile Number:</div>
                                <asp:TextBox class="col-8 form-control" type="number" ID="EditPhone" runat="server"></asp:TextBox>
                            </div>

                            <asp:Button Text="Save" OnClick="EditSave_Click" ID="EditSave" runat="server" CssClass="offset-4 btn btn-outline-success" />
                            <asp:Button Text="Cancel" OnClick="EditCancel_Click" ID="EditCancel" runat="server" CssClass="ml-3 btn btn-outline-secondary" />
                        </asp:PlaceHolder>


                        <asp:PlaceHolder runat="server" ID="PasswordPanel" Visible="false">

                            <div class="row my-2">
                                <div class=" col-4 font-weight-bolder">Old Password:</div>
                                <asp:TextBox class="col-8 form-control" type="password" ID="OldPassword" runat="server"></asp:TextBox>
                            </div>
                            <div class="row my-2">
                                <div class=" col-4 font-weight-bolder">New Password:</div>

                                <div class="col-8 p-0 m-0 ">

                                    <input type="password" class="form-control" runat="server" id="validationPassword" minlength="8" name="password" placeholder="Password" value="">
                                    <div class="progress" style="height: 5px;">
                                        <div id="progressbar" class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" style="width: 10%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">
                                        </div>
                                    </div>
                                    <small id="passwordHelpBlock" class="form-text text-muted">Your password must be 8-20 characters long,  must contain special characters "!@#$%&*_?", numbers, lower and upper letters only.
                                    </small>
                                    <div id="feedbackin" class="valid-feedback">
                                        Strong Password!
                                    </div>
                                    <div id="feedbackirn" class="invalid-feedback">
                                        Atlead 8 characters,
					Number, special character 
					Caplital Letter and Small letters
                                    </div>
                                </div>
                            </div>


                            <div class="row my-2">
                                <div class=" col-4 font-weight-bolder">Confirm New Password:</div>
                                <asp:TextBox class="col-8 form-control" type="password" ID="ConfirmNewPassword" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button Text="Update" OnClick="UpdatePass_Click" ID="UpdatePass" runat="server" CssClass="offset-4 btn btn-outline-success" />

                            <asp:Button Text="Cancel" OnClick="CancelUpdate_Click" ID="CancelUpdate" runat="server" CssClass="ml-3 btn btn-outline-secondary" />

                        </asp:PlaceHolder>


                    </div>

                </div>
            </div>
        </div>
        <div class="mt-3 offset-2">
            <asp:Button Text="Update Password" OnClick="ShowUpdate_Click" ID="ShowUpdate" runat="server" CssClass="btn btn-outline-warning" />
            <asp:Button Text="Edit My Profile" OnClick="ShowEdit_Click" ID="ShowEdit" runat="server" CssClass="btn btn-outline-primary" />
            <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#UserDeleteModal">Delete My Profile </button>

        </div>
    </div>
    <script type="text/javascript">
        (function () {
            'use strict';
            window.addEventListener('load', function () {
                // Fetch all the forms we want to apply custom Bootstrap validation styles to
                var forms = document.getElementsByClassName('needs-validation');
                console.log(forms);
                // Loop over them and prevent submission
                var validation = Array.prototype.filter.call(forms, function (form) {
                    console.log(form);
                    // making sure password enters the right characters
                   form.CustomerContent_validationPassword.addEventListener('keypress', function (event) {
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

                       if (form.CustomerContent_validationPassword.value.length >= 20)
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


                   form.CustomerContent_validationPassword.addEventListener('keyup', function () {

                        var messageCase = new Array();
                        messageCase.push(" Special Charector"); // Special Charector
                        messageCase.push(" Upper Case");      // Uppercase Alpabates
                        messageCase.push(" Numbers");      // Numbers
                        messageCase.push(" Lower Case");     // Lowercase Alphabates

                        var ctr = 0;
                        var rti = "";
                        for (var i = 0; i < matchedCase.length; i++) {
                            if (new RegExp(matchedCase[i]).test(form.CustomerContent_validationPassword.value)) {
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

                        if (strength == "Medium" &&form.CustomerContent_validationPassword.value.length >= 8) {
                            strength = "Strong";
                            bClass = "bg-success";
                           form.CustomerContent_validationPassword.setCustomValidity("");
                        } else {
                           form.CustomerContent_validationPassword.setCustomValidity(strength);
                        }

                        var sometext = "";

                       if (form.CustomerContent_validationPassword.value.length < 8) {
                            var lengthI = 8 - form.CustomerContent_validationPassword.value.length;
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
                        var plength =form.CustomerContent_validationPassword.value.length;
                        if (plength > 0) progressbar += ((plength - 0) * 1.75);
                        //console.log("plength: " + plength);
                        var percentage = progressbar + "%";
                       form.CustomerContent_validationPassword.parentNode.classList.add('was-validated');
                        //console.log("pacentage: " + percentage);
                        $("#progressbar").width(percentage);

                       if (form.CustomerContent_validationPassword.checkValidity() === true) {
                            form.verifyPassword.disabled = false;
                        } else {
                            form.verifyPassword.disabled = true;
                        }


                    });



                });
            }, false);
        })();

    </script>
</asp:Content>
