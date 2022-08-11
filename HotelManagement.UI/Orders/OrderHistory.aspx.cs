using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI.Orders
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        OrderBO ob = new OrderBO();
        protected void Page_Load(object sender, EventArgs e)
        {

            OrderListView.DataSource=ob.GetAllOrdersbyUserName(Session["username"].ToString());
            OrderListView.DataBind();

        }

    }
}