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
            UserBO userBO = new UserBO();
            if (mobileNumber.Text.Length != 10)
            {
                SignUpWarningText.Text = "Mobile number should have 10 digits";
            }
            else if(userBO.IsUserNameAvailable(userName.Text)) {
                SignUpWarningText.Text = "UserName is Already Taken";
            }
            else
            {
                User usr = new User();
                usr.UserName = userName.Text;
                usr.Password = password.Text;
                usr.Address = address.Text;
                usr.MobileNumber = mobileNumber.Text;
                userBO.AddUser(usr);
                
                Response.Redirect("login.aspx");
            }
        }
    }
}