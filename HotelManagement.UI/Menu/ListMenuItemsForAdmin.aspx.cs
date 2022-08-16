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
            
           
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr(delBtn.CommandArgument.ToString() + " Deleted Successfully", "success", ""), true);

            //Response.Redirect("ListMenuItemsForAdmin");
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
            if (menuItem.Cost.StartsWith("-") || menuItem.Cost.Equals("0") || menuItem.Cost.Equals(""))
            {
                //AddWarning.Text = "Cost Cannot be less than or equal to zero(0)";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Cost Cannot be less than or equal to zero(0)", "warning", ""), true);
            }
            else
            {
                menuItemBO.EditMenuItem(menuItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr(menuItem.ItemName+" Edited Successfully", "success", Request.RawUrl), true);

                //Response.Redirect("ListMenuItemsForAdmin");
            }

        }
        protected void CreateButton_Click(Object sender, EventArgs e)
        {
            Entities.MenuItem menuItem=new Entities.MenuItem();
            menuItem.ItemName = AddItemName.Text;
            menuItem.Category = AddItemCategory.Text;
            menuItem.Cost= AddItemCost.Text;
            menuItem.Availability= AddItemAvailability.Text;
            menuItem.Image=AddItemImage.Text;
            if (menuItemBO.isItemAvailable(menuItem.ItemName))
            {
                // AddWarning.Text = "Item is already in the Menu";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Item is already in the Menu", "error", ""), true);


            }
            else if (menuItem.Cost.StartsWith("-") || menuItem.Cost.Equals("0") || menuItem.Cost.Equals(""))
            {
                //AddWarning.Text = "Cost Cannot be less than or equal to zero(0)";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Cost Cannot be less than or equal to zero(0)", "error", ""), true);

            }
            else if (menuItem.ItemName.Equals("")) {
                // AddWarning.Text = "Item Name Cannot be empty";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr("Item name cannot be empty", "error", ""), true);

            }
            else
            {
                menuItemBO.AddMenuItem(menuItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ToastrNotification", CallToastr(menuItem.ItemName+" Added Successfully", "success", Request.RawUrl), true);
                //Response.Redirect("ListMenuItemsForAdmin");
            }
           

        }

        protected void CardRepeaterAdmin_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Entities.MenuItem item = (Entities.MenuItem)e.Item.DataItem;
            Image btn = (Image)e.Item.FindControl("AdminImage");
            btn.ImageUrl = "~/Content/images/"+item.Image+".jpg";
        }
        private string CallToastr(string msg, string status, string func)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("$(document).ready(function () {");
            sb.Append("ToastrNotification('");
            sb.Append(msg);
            sb.Append("','");
            sb.Append(status);
            sb.Append("','");
            sb.Append(func);
            sb.Append("');");
            sb.Append("})");
            return sb.ToString();
        }
    }
}