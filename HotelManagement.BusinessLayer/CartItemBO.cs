using HotelManagement.DataLayer;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer
{
    public class CartItemBO
    {
        public CartItemDAO CartItemDAO;
        public CartItemBO()
        {
            CartItemDAO = new CartItemDAO();
        }
        public void AddItem(CartItem Item)
        {
            CartItemDAO.AddItem(Item);
        }
        public void EditItem(CartItem Item)
        {
            CartItemDAO.EditItem(Item);
        }
        public void DeleteItem(Guid ItemId)
        {
            CartItemDAO.DeleteItem(ItemId);
        }
        public CartItem GetItem(Guid ItemId)
        {
            return CartItemDAO.GetItem(ItemId);
        }

        public ICollection<CartItem> GetItemsbyOrderId(Guid OrderId)
        {
            return CartItemDAO.GetItemsbyOrderId(OrderId);
        }
    }

}

