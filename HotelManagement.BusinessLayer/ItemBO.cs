using HotelManagement.DataLayer;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer
{
    public class ItemBO
    {
        public CartItemDAO ItemDAO;
        public ItemBO()
        {
            ItemDAO = new CartItemDAO();
        }
        public void AddItem(Item Item)
        {
            ItemDAO.AddItem(Item);
        }
        public void EditItem(Item Item)
        {
            ItemDAO.EditItem(Item);
        }
        public void DeleteItem(Guid ItemId)
        {
            ItemDAO.DeleteItem(ItemId);
        }
        public void GetItem(Guid ItemId)
        {
            ItemDAO.GetItem(ItemId);
        }

        public ICollection<Item> GetItems()
        {
            return ItemDAO.GetItems();
        }
    }

}

