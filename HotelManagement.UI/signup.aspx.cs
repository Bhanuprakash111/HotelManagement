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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User usr = new User();
            usr.UserName = TextBox1.Text;
            usr.Password = TextBox2.Text;
            usr.Address = TextBox3.Text;
            usr.MobileNumber = TextBox4.Text;
            usr.UserRole = TextBox5.Text;

            UserBO userBO = new UserBO();
            userBO.AddUser(usr);


            Response.Redirect("login.aspx");
        }
    }
}