using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI
{
    public partial class Customer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            CartItemBO cb = new CartItemBO();
            OrderBO ob = new OrderBO();
            if (ob.AnyOrderStandBy(Session["username"].ToString()))
            {
                Entities.Order o = ob.GetOrderbyStatus("Inprogress", Session["username"].ToString());
                Cart_Count.Text = cb.GetCount(o.OrderId).ToString();
            }
            else {
                Cart_Count.Text = "0";
            }
            
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../login.aspx");
        }
    }
}