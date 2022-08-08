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
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuItemBO menuItemBO = new MenuItemBO();

            CardRepeaterAdmin.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDownAdmin.SelectedValue);
            CardRepeaterAdmin.DataBind();
        }

        protected void MenuDropDownAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuItemBO menuItemBO = new MenuItemBO();

            CardRepeaterAdmin.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDownAdmin.SelectedValue);
            CardRepeaterAdmin.DataBind();
        }
    }
}