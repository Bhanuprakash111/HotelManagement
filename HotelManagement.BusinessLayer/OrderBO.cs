using HotelManagement.DataLayer;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer
{
    public class OrderBO
    {
        public OrderDAO OrderDAO;
        public OrderBO()
        {
            OrderDAO = new OrderDAO();
        }
        public void AddOrder(Order OrderId)
        {
            OrderDAO.AddOrder(OrderId);
        }
        public void EditOrder(Order OrderId)
        {
            OrderDAO.EditOrder(OrderId);
        }
        public void DeleteOrder(Guid OrderId)
        {
            OrderDAO.DeleteOrder(OrderId);
        }
        public void GetOrder(Guid OrderId)
        {
            OrderDAO.GetOrder(OrderId);
        }
        public ICollection<Order> GetAllOrders()
        {
            return OrderDAO.GetAllOrders();
        }
    }
}
