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
        CartItemBO cb = new CartItemBO();
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
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument);  //Get the OrderId OnButton Click
            
            Entities.Order odr = ob.GetOrder(id); //Printing user details
            UserName.Text = odr.UserUserName;
            UserBO ub = new UserBO();
            Entities.User usr = ub.GetUser(UserName.Text);
            Address.Text = usr.Address;
            Mobile_Number.Text = usr.MobileNumber;

            CartItemBO cb = new CartItemBO();  //Printing Item Details using Orderid that we got from button            
            ListView1.DataSource = cb.GetItemsbyOrderId(id);   //Listview return value
            ListView1.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MoreInfo", "$('#MoreInfo').modal();", true); //Calling the modal
            upModal.Update();

            GrandTotal.Text = odr.TotalCost;
        }
        
    }
}