using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI.UserActions
{
    public partial class UserProfile : System.Web.UI.Page
    {
        UserBO ub = new UserBO();
        Entities.User usr;
        protected void Page_Load(object sender, EventArgs e)
        {
             usr = ub.GetUser(Session["username"].ToString());
            string username = usr.UserName;
            List<string> lst = username.Split(' ').ToList<string>();
            if (lst.Count > 1)
                userProfilePic.ImageUrl = "https://ui-avatars.com/api/?name="+lst[0]+"+"+lst[1]+"&background=random&bold=true&size=512";
            else
                userProfilePic.ImageUrl = "https://ui-avatars.com/api/?name="+lst[0]+"&background=random&bold=true&size=512";

            UsernameLabel.Text = usr.UserName;
            AddressLabel.Text = usr.Address;
            PhoneLabel.Text = usr.MobileNumber;
        }

        protected void ShowUpdate_Click(object sender, EventArgs e)
        {
            DisplayUser.Visible = false;
            EditUser.Visible = false;
            PasswordPanel.Visible = true;  
        }

        protected void ShowEdit_Click(object sender, EventArgs e)
        {
            EditAddress.Value = usr.Address;
            EditPhone.Text = usr.MobileNumber;
            DisplayUser.Visible = false;
            PasswordPanel.Visible = false;
            EditUser.Visible = true;
            
        }

        protected void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            OrderBO ob = new OrderBO();
            CartItemBO cb = new CartItemBO();
            foreach (var order in ob.GetAllOrdersbyUserName(usr.UserName)) {
                foreach (var cartitem in cb.GetItemsbyOrderId(order.OrderId)){
                    cb.DeleteItem(cartitem.ItemId);
                }
                ob.DeleteOrder(order.OrderId);
            }

            ub.DeleteUser(usr.UserName);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("User Deleted successfully", "success", "../login.aspx"), true);
            //Response.Redirect("../login.aspx");
        }

        protected void EditSave_Click(object sender, EventArgs e)
        {
            if (EditAddress.Value.Equals("") || EditPhone.Text.Equals(""))
            {
                //WarningLabel.Text = "All fields are required";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("All fields are required", "info", ""), true);

            }
            else if (EditPhone.Text.Length != 10) {
                //WarningLabel.Text = "Phone number should be 10 digits";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Phone number must have 10 digits", "info", ""), true);

            }
            else {
                Entities.User u = new Entities.User();
                u.UserName = usr.UserName;
                u.Password = usr.Password;
                u.Address = EditAddress.Value;
                u.MobileNumber = EditPhone.Text;
                u.UserRole = usr.UserRole;
                ub.EditUser(u);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Details Updated!", "success", ""), true);

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void EditCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void UpdatePass_Click(object sender, EventArgs e)
        {
            if (OldPassword.Text.Equals("") || NewPassword.Text.Equals("") || ConfirmNewPassword.Text.Equals("")) {
                //WarningLabel.Text = "All fields are required!!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("All fields required", "warning", ""), true);

            }
            else if (!OldPassword.Text.Equals(usr.Password))
            {
                //WarningLabel.Text = "You have entered a wrong password!!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Wrong Password!!", "warning", ""), true);

            }
            else if (OldPassword.Text.Equals(NewPassword.Text))
            {
                //WarningLabel.Text = "Your new password cannot be your existing password!!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("New Password should not match existing", "warning", ""), true);

            }
            else if (!NewPassword.Text.Equals(ConfirmNewPassword.Text))
            {
                //WarningLabel.Text = "Confirm password donot match with new password!!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Passwords does not match!", "warning", ""), true);

            }
            else {
                Entities.User u = new Entities.User();
                u.UserName=usr.UserName;
                u.Password = NewPassword.Text;
                u.Address = usr.Address;
                u.MobileNumber=usr.MobileNumber;
                u.UserRole= usr.UserRole;
                ub.EditUser(u);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void CancelUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        private string CallToastr(string msg, string status,string func)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("$(document).ready(function () {");
            sb.Append("ToastrNotification('");
            sb.Append(msg);
            sb.Append("','");
            sb.Append(status);
            sb.Append("','");
            sb.Append(func);
            sb.Append("');");
            sb.Append("})");
            return sb.ToString();
        }
    }
}