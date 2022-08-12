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
        /*I have only included AjaxToolKit but havenot used it*/
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
            EditItemName.Value = menuItem.ItemName;
            EditItemCategory.Value = menuItem.Category;
            EditItemCost.Text = menuItem.Cost.ToString();
            EditItemAvailability.Text=menuItem.Availability;
            EditItemImage.Text = menuItem.Image;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "EditModal", "$('#EditModal').modal();", true);
            upModal.Update();
        }

        protected void SaveEditChanges_Click(object sender, EventArgs e)
        {
            Entities.MenuItem menuItem = new Entities.MenuItem();
            menuItem.ItemName = EditItemName.Value;
            menuItem.Category = EditItemCategory.Value;
            menuItem.Cost = EditItemCost.Text;
            menuItem.Availability = EditItemAvailability.Text;
            menuItem.Image = EditItemImage.Text;
            menuItemBO.EditMenuItem(menuItem);
            Response.Redirect("ListMenuItemsForAdmin");

        }
        protected void CreateButton_Click(Object sender, EventArgs e)
        {
            Entities.MenuItem menuItem=new Entities.MenuItem();
            menuItem.ItemName = AddItemName.Text;
            menuItem.Category = AddItemCategory.Text;
            menuItem.Cost= AddItemCost.Text;
            menuItem.Availability= AddItemAvailability.Text;
            menuItem.Image=AddItemImage.Text;
            if (menuItemBO.isItemAvailable(menuItem.ItemName)) {
                AddWarning.Text = "Item is already in the Menu"; 
                
            }
            else {
                menuItemBO.AddMenuItem(menuItem);
                Response.Redirect("ListMenuItemsForAdmin");
            }
           

        }
    }
}