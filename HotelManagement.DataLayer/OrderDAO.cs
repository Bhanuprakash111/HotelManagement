using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using HotelManagement.Entities;

namespace HotelManagement.DataLayer
{
    public class OrderDAO
    {
        private String ConnStr;
        public OrderDAO()
        {
            /*ConnStr = ConfigurationManager.ConnectionStrings["HotelMgmtConn"].ConnectionString;*/
            ConnStr = "Data Source=LIGHT\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
        }

        public void AddOrder(Order odr)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Insert into Orders Values(@OrderId,@TotalCost,@Date," +
                                                "@OrderStatus,@UserName)", con);
                cmd.Parameters.AddWithValue("@OrderId", odr.OrderId);
                cmd.Parameters.AddWithValue("@TotalCost", odr.TotalCost);
                cmd.Parameters.AddWithValue("@Date", odr.Date);
                cmd.Parameters.AddWithValue("@OrderStatus", odr.OrderStatus);
                cmd.Parameters.AddWithValue("@UserName", odr.UserUserName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditOrder(Order odr)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Update Orders set TotalCost=@TotalCost, Date=@Date, OrderStatus=" +
                                                "@OrderStatus where OrderId=@OrderId", con);
                cmd.Parameters.AddWithValue("@TotalCost", odr.TotalCost);
                cmd.Parameters.AddWithValue("@Date", odr.Date);
                cmd.Parameters.AddWithValue("@OrderStatus", odr.OrderStatus);
                cmd.Parameters.AddWithValue("@OrderId", odr.OrderId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteOrder(Guid OrderId)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Delete from Orders where OrderId=@OrderId", con);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Order GetOrder(Guid OrderId)
        {
            Order od = new Order();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders where OrderId=@OrderId", con);
                cmd.Parameters.AddWithValue("@OrderId",OrderId);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    od.OrderId = (Guid)rdr["OrderId"];
                    od.TotalCost = rdr["TotalCost"].ToString();
                    od.Date= (DateTime)rdr["Date"];
                    od.OrderStatus = rdr["OrderStatus"].ToString();
                    od.UserUserName = rdr["UserUserName"].ToString();
                }
                return od;

            }
        }

        
        public ICollection<Order> GetAllOrders()
        {
            List<Order> Orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Order odr = new Order();
                        odr.OrderId = (Guid)rdr["OrderId"];
                        odr.TotalCost = rdr["TotalCost"].ToString();
                        odr.Date= (DateTime)rdr["Date"];
                        odr.OrderStatus = rdr["OrderStatus"].ToString();
                        odr.UserUserName=rdr["UserUserName"].ToString();
                        Orders.Add(odr);
                    }
                }
                return Orders;
            }
        }
        
       public static void Main(String [] args) { 
            OrderDAO orderdao = new OrderDAO();
            CartItemDAO cartitemdao = new CartItemDAO();
            MenuItemDAO menuitemdao = new MenuItemDAO();    

            Order odr1 = new Order();
            /*odr1.OrderId = Guid.NewGuid()*/;odr1.Date = DateTime.Now;odr1.OrderStatus = "Order Placed";
            odr1.UserUserName = "Haritha";

            CartItem cartitem = new CartItem();
/*            cartitem.ItemId = Guid.NewGuid();*/
            cartitem.OrderOrderId = odr1.OrderId;
            cartitem.MenuItemItemName = "IceCream";
            cartitem.Quantity = "10";
            
            CartItem cartitem1 = new CartItem();
/*            cartitem1.ItemId = Guid.NewGuid();*/
            cartitem1.OrderOrderId = odr1.OrderId;
            cartitem1.MenuItemItemName = "Biriyani";
            cartitem1.Quantity = "40";

            odr1.TotalCost = Convert.ToInt32(cartitem.Quantity) * Convert.ToInt32(menuitemdao.GetMenuItem(cartitem.MenuItemItemName).Cost) +
                             Convert.ToInt32(cartitem1.Quantity) * Convert.ToInt32(menuitemdao.GetMenuItem(cartitem1.MenuItemItemName).Cost)  + "";

            /*orderdao.AddOrder(odr1);*/

            orderdao.GetOrder(new Guid("643aeb09-4269-4d8f-a447-a6bd52b52d51")).OrderStatus = "Order Delivered";
            orderdao.EditOrder(orderdao.GetOrder(new Guid("643aeb09-4269-4d8f-a447-a6bd52b52d51")));

            /*var order = orderdao.GetOrder(odr1.OrderId);
            Console.WriteLine(order.UserUserName+" "+order.Date+" "+order.OrderStatus+" "+order.TotalCost);*/

            foreach (var o in orderdao.GetAllOrders()) {
                Console.WriteLine(o.UserUserName + " " + o.Date + " " + o.OrderStatus + " " + o.TotalCost);
            }

            /*orderdao.DeleteOrder(odr1.OrderId);*/

            Console.ReadKey();
        }
        
    }
}

