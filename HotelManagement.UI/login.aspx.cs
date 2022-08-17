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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserBO userBO = new UserBO();
            if (userBO.IsUserNameAvailable(TextBox1.Text))
            {
                var user = userBO.GetUser(TextBox1.Text);
                Session["username"] = user.UserName;
                Session["userrole"] = user.UserRole;
                Session.Timeout = 60;

                if (TextBox2.Text.Equals(user.Password))
                {
                    Label1.Text = "";
                    if (user.UserRole.Equals("Admin"))
                        Response.Redirect("Menu/ListMenuItemsForAdmin.aspx");
                    Response.Redirect("Menu/ListMenuItems.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Login Failed", "error"), true);
                    Label1.Text = "Incorrect UserName/Password";
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Login Failed","error"),true);
                Label1.Text = "Incorrect UserName/Password";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        private string CallToastr(string msg, string status) {
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