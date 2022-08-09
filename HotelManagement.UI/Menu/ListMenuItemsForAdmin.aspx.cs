using HotelManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement.UI.Menu
{
    public partial class ListMenuItemsForAdmin : System.Web.UI.Page
    {
        MenuItemBO menuItemBO = new MenuItemBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            CardRepeaterAdmin.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDownAdmin.SelectedValue);
            CardRepeaterAdmin.DataBind();
        }

        protected void MenuDropDownAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            CardRepeaterAdmin.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDownAdmin.SelectedValue);
            CardRepeaterAdmin.DataBind();
        }
        protected void DeleteButton_Click(object sender, EventArgs e) {
                LinkButton delBtn = (LinkButton)sender;
                menuItemBO.DeleteMenuItem(delBtn.CommandArgument.ToString());
                Response.Redirect("ListMenuItemsForAdmin");
        }
        protected void EditButton_Click(object sender, EventArgs e) {
                LinkButton editBtn = (LinkButton)sender;
                var menuItem = menuItemBO.GetMenuItem(editBtn.CommandArgument.ToString());
                


        }
    }
}