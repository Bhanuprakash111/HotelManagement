using HotelManagement.DataLayer;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer
{
    public class MenuItemBO
    {
        public MenuItemDAO MenuItemDAO;
        public MenuItemBO()
        {
            MenuItemDAO = new MenuItemDAO();
        }
        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.AddMenuItem(menuItem);
        }
        public void EditMenuItem(MenuItem menuItem)
        {
            MenuItemDAO.EditMenuItem(menuItem);
        }
        public void DeleteMenuItem(string ItemName)
        {
            MenuItemDAO.DeleteMenuItem(ItemName);
        }
        public MenuItem GetMenuItem(string ItemName)
        {
            return MenuItemDAO.GetMenuItem(ItemName);
        }
        public bool isItemAvailable(string ItemName) { 
            return MenuItemDAO.isItemAvailable(ItemName);
        }
        public ICollection<MenuItem> GetAllMenuItemsByCategory(string Category)
        {
            return MenuItemDAO.GetAllMenuItemsByCategory(Category);
        }
    }
}
