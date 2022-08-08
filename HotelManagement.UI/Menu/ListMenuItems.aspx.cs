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
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuItemBO menuItemBO = new MenuItemBO();

            CardRepeater.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDown.SelectedValue);
            CardRepeater.DataBind();
        }

        protected void MenuDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuItemBO menuItemBO = new MenuItemBO();

            CardRepeater.DataSource = menuItemBO.GetAllMenuItemsByCategory(MenuDropDown.SelectedValue);
            CardRepeater.DataBind();
        }
    }
}