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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserBO userBO = new UserBO();
            var x=userBO.GetUser(TextBox1.Text);
            if (TextBox1.Text ==x.UserName && TextBox2.Text == x.Password)
            {

                
                Response.Redirect("Menu/ListMenuItems.aspx");
            }
            else
            {
                Label1.Text = "Enter valid details ";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }
    }
}