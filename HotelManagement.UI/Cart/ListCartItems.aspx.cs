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
                OrderBO ob = new OrderBO();
                
                Entities.Order order=ob.GetOrderbyStatus("Inprogress");
                Repeater1.DataSource = cb.GetItemsbyOrderId(order.OrderId);
                Repeater1.DataBind();

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
            /*TextBox tb = (TextBox)sender;
            Guid id = new Guid(tb.);
            Entities.CartItem item = cb.GetItem(id) ;
            
            item.Quantity = tb.Text;

            cb.EditItem(item);*/
        }
        
    }
}