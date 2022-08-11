using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI.Orders
{
    public partial class OrdersPlaced : System.Web.UI.Page
    {
        OrderBO ob = new OrderBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderListViewAdmin.DataSource = ob.GetAllOrdersbyStatus("Placed");
            OrderListViewAdmin.DataBind();
            
        }
        protected void DeliverOrder_Click(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument);
            Entities.Order order = ob.GetOrder(id);
            order.OrderStatus = "Delivered";
            ob.EditOrder(order);
            Response.Redirect("OrdersPlaced");
        }
        protected void AdminOrderMoreInfo_Click(object sender, EventArgs e) {
            
        }
    }
}