using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI.Cart
{
    public partial class ListCartItems : System.Web.UI.Page
    {
        CartItemBO cb = new CartItemBO();
        OrderBO ob = new OrderBO();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string CurrentLoggedInUser = Session["username"].ToString();
                if (ob.AnyOrderStandBy(CurrentLoggedInUser))
                {
                    Entities.Order order = ob.GetOrderbyStatus("Inprogress", CurrentLoggedInUser);
                    ListView1.DataSource = cb.GetItemsbyOrderId(order.OrderId);
                    ListView1.DataBind();
                    GrandTotalValue.Text = order.TotalCost;
                    PlaceOrder1.Attributes.Add("Enabled","true");

                }
                else { 
                    ListView1.DataSource=null;
                    ListView1.DataBind();
                    PlaceOrder1.Attributes.Add("disabled", "true");
                }
            }
            if(ListView1.DataKeys.Count == 0) PlaceOrder1.Attributes.Add("disabled", "true");
        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument);
            
            Entities.CartItem item = cb.GetItem(id);
            Entities.Order order = ob.GetOrder(item.OrderOrderId);
            order.TotalCost = (Convert.ToInt32(order.TotalCost) - item.ItemTotal).ToString();
            ob.EditOrder(order);
            cb.DeleteItem(id);
            Response.Redirect("ListCartItems");
        }

        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            HiddenField hf  =(HiddenField)tb.Parent.FindControl("HiddenItemId");
            Guid id = new Guid(hf.Value);
            if(tb.Text.Equals("") || tb.Text.Equals("0") || tb.Text.StartsWith("-")){
                CartItemWarning.Text = "Quantity cannot be less than or equal to zero (0)";
                PlaceOrder1.Attributes.Add("disabled", "true");
            }
            else {
                Entities.CartItem item = cb.GetItem(id);
                item.Quantity = tb.Text;
                item.ItemTotal = (Convert.ToInt32(item.Quantity)) * (item.ItemCost);
                cb.EditItem(item);
                Entities.Order order = ob.GetOrder(item.OrderOrderId);
                order.TotalCost = cb.GetTotalCost(item.OrderOrderId) + "";
                ob.EditOrder(order);
                GrandTotalValue.Text = order.TotalCost;
                Response.Redirect("ListCartItems"); }
        }

        protected void PlaceOrder1_Click(object sender, EventArgs e)
        {
            Entities.Order order = ob.GetOrderbyStatus("Inprogress", Session["username"].ToString());
            order.OrderStatus = "Placed";
            ob.EditOrder(order);
            Response.Redirect("../Orders/OrderHistory");
        }
    }
}