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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string CurrentLoggedInUser = "Bhanu";
                OrderBO ob = new OrderBO();
                if (ob.AnyOrderStandBy(CurrentLoggedInUser))
                {
                    Entities.Order order = ob.GetOrderbyStatus("Inprogress", CurrentLoggedInUser);
                    ListView1.DataSource = cb.GetItemsbyOrderId(order.OrderId);
                    ListView1.DataBind();
                    GrandTotalValue.Text = order.TotalCost;
                }
                else { 
                    ListView1.DataSource=null;
                    ListView1.DataBind();
                }
            }

        }
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Guid id = new Guid(btn.CommandArgument);
            cb.DeleteItem(id);
            Response.Redirect("ListCartItems");
        }

        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            HiddenField hf  =(HiddenField)tb.Parent.FindControl("HiddenItemId");
            OrderBO ob = new OrderBO();
            Guid id = new Guid(hf.Value);

            Entities.CartItem item = cb.GetItem(id);
            item.Quantity = tb.Text;
            item.ItemTotal = (Convert.ToInt32(item.Quantity)) * (item.ItemCost);
            cb.EditItem(item);
            Entities.Order order = ob.GetOrder(item.OrderOrderId);
            order.TotalCost = cb.GetTotalCost(item.OrderOrderId)+"";
            ob.EditOrder(order);
            GrandTotalValue.Text = order.TotalCost;
             Response.Redirect("ListCartItems");
        }
        
    }
}