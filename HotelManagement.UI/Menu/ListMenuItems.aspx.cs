using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI.Menu
{
    public partial class ListMenuItems : System.Web.UI.Page
    {
        MenuItemBO menuItemBO = new MenuItemBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            CardRepeater.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDown.SelectedValue);
            CardRepeater.DataBind();
            WarningLabel.Text = "";
        }

        protected void MenuDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            CardRepeater.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDown.SelectedValue);
            CardRepeater.DataBind();
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            string CurrentLoggedInUser = "Bhanu";
            LinkButton addBtn = (LinkButton)sender;
            OrderBO orderBO = new OrderBO();
            CartItemBO cartItemBO = new CartItemBO();
            Entities.CartItem ct = new Entities.CartItem();
            
            ct.ItemId = Guid.NewGuid();
            ct.MenuItemItemName = addBtn.CommandArgument;
            ct.Quantity = "1";
            ct.ItemCost = Convert.ToInt32(menuItemBO.GetMenuItem(ct.MenuItemItemName).Cost);
            ct.ItemTotal = ct.ItemCost;

            if (orderBO.AnyOrderStandBy(CurrentLoggedInUser))
            {
                Entities.Order order = orderBO.GetOrderbyStatus("Inprogress",CurrentLoggedInUser);
                ct.OrderOrderId = order.OrderId;
            }
            else {
                Entities.Order order = new Entities.Order();
                order.OrderId = Guid.NewGuid();
                order.UserUserName = CurrentLoggedInUser;
                order.Date = DateTime.Now;
                order.TotalCost = "";
                order.OrderStatus = "Inprogress";
                orderBO.AddOrder(order);
                ct.OrderOrderId=order.OrderId;
            }
            
            if (!cartItemBO.isInCart(ct.MenuItemItemName, ct.OrderOrderId))
            {
                cartItemBO.AddItem(ct);
            }
            else {
                WarningLabel.Text = "Item is Already in the cart";
            }
            
        }
    }
}