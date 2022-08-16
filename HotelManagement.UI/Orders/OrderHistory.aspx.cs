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

        protected void OrderMoreInfo_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument);
            CartItemBO cb = new CartItemBO();
            ModalListView.DataSource=cb.GetItemsbyOrderId(id);
            ModalListView.DataBind();

            Entities.Order odr = ob.GetOrder(id);
            GrandTotal.Text = odr.TotalCost;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OrderInfoModal", "$('#OrderInfoModal').modal();", true);
            ModalUpdatePanel.Update();

        }

        protected void OrderListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Entities.Order order =  (Entities.Order)e.Item.DataItem;
            Label l = (Label)e.Item.FindControl("status");
            if (order.OrderStatus.Equals("Inprogress")) { l.ForeColor = System.Drawing.Color.Red; }
            else if (order.OrderStatus.Equals("Placed")) { l.ForeColor = System.Drawing.Color.Orange; }
            else if (order.OrderStatus.Equals("Delivered")) { l.ForeColor = System.Drawing.Color.Green; }
        }
    }
}