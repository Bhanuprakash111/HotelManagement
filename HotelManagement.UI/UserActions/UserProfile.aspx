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
                    <asp:Button runat="server" OnClick="DeleteUserBtn_Click" ID="DeleteUserBtn" class="btn btn-primary" Text="Continue"/>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div class="container my-5 mr-5 pr-5">
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
                                <asp:TextBox class="col-8 form-control" type="password" ID="NewPassword" runat="server"></asp:TextBox>
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
            <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#UserDeleteModal"> Delete My Profile </button>

        </div>
    </div>
</asp:Content>
