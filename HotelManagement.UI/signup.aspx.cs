using HotelManagement.BusinessLayer;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SignUpWarningText.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserBO userBO = new UserBO();
            if (mobileNumber.Text.Length != 10)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Mobile number should have 10 digits", "warning"), true);
                //SignUpWarningText.Text = "Mobile number should have 10 digits";
            }
            else if(userBO.IsUserNameAvailable(userName.Text)) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("UserName is Already Taken", "error"), true);
                //SignUpWarningText.Text = "UserName is Already Taken";
            }
            else
            {
                User usr = new User();
                usr.UserName = userName.Text;
                usr.Password = password.Text;
                usr.Address = address.Value;
                usr.MobileNumber = mobileNumber.Text;
                userBO.AddUser(usr);
                
                Response.Redirect("login.aspx");
            }
        }

        private string CallToastr(string msg, string status)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("$(document).ready(function () {");
            sb.Append("ToastrNotification('");
            sb.Append(msg);
            sb.Append("','");
            sb.Append(status);
            sb.Append("');");
            sb.Append("})");
            return sb.ToString();
        }
    }
}