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
            Page pg = (Page)sender;
            CardRepeater.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDown.SelectedValue);
            WarningLabel.Text = "";
            CardRepeater.DataBind();
        }

        protected void MenuDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardRepeater.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDown.SelectedValue);
            CardRepeater.DataBind();
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            string CurrentLoggedInUser = Session["username"].ToString();
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
                order.TotalCost =( Convert.ToInt32(order.TotalCost) + ct.ItemTotal).ToString();
                if (!cartItemBO.isInCart(ct.MenuItemItemName, ct.OrderOrderId))
                {
                    orderBO.EditOrder(order);
                }
                    
                
            }
            else {
                Entities.Order order = new Entities.Order();
                order.OrderId = Guid.NewGuid();
                order.UserUserName = CurrentLoggedInUser;
                order.Date = DateTime.Now;
                order.TotalCost = ct.ItemTotal.ToString();
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

        protected void CardRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Entities.MenuItem item = (Entities.MenuItem)e.Item.DataItem;
            if (item.Availability.Equals("no")){
                LinkButton btn = (LinkButton)e.Item.FindControl("AddToCart");
                btn.Attributes.Add("disabled", "true");
            };
            Image btn1 = (Image)e.Item.FindControl("ClientImage");
            btn1.ImageUrl = "~/Content/images/" + item.Image + ".jpg";
        }
    }
}