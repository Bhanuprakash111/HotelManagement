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
        public Order GetOrder(Guid OrderId)
        {
            return OrderDAO.GetOrder(OrderId);
        }
        public Order GetOrderbyStatus(string OrderStatus)
        {
            return OrderDAO.GetOrderbyStatus(OrderStatus);
        }
        public ICollection<Order> GetAllOrders()
        {
            return OrderDAO.GetAllOrders();
        }
    }
}
