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
            ConnStr = "Data Source=VIDHYAMINI\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
           // ConnStr = "Data Source=LIGHT\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
           // ConnStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    od.OrderId = (Guid)rdr["OrderId"];
                    od.TotalCost = rdr["TotalCost"].ToString();
                    od.Date = (DateTime)rdr["Date"];
                    od.OrderStatus = rdr["OrderStatus"].ToString();
                    od.UserUserName = rdr["UserUserName"].ToString();
                }
                return od;

            }
        }
        public Order GetOrderbyStatus(string OrderStatus, string UserName)
        {
            Order od = new Order();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders where UserUserName=@UserName AND OrderStatus=@OrderStatus", con);
                cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                cmd.Parameters.AddWithValue("@UserName", UserName);

                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    od.OrderId = (Guid)rdr["OrderId"];
                    od.TotalCost = rdr["TotalCost"].ToString();
                    od.Date = (DateTime)rdr["Date"];
                    od.OrderStatus = rdr["OrderStatus"].ToString();
                    od.UserUserName = rdr["UserUserName"].ToString();
                }
                return od;

            }
        }
        public bool AnyOrderStandBy(String UserName) {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders where UserUserName=@UserName AND OrderStatus='Inprogress'", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) {
                    return rdr.HasRows;
                }
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
                        odr.Date = (DateTime)rdr["Date"];
                        odr.OrderStatus = rdr["OrderStatus"].ToString();
                        odr.UserUserName = rdr["UserUserName"].ToString();
                        Orders.Add(odr);
                    }
                }
                return Orders;
            }
        }
        public ICollection<Order> GetAllOrdersbyUserName(string UserName)
        {
            List<Order> Orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders where UserUserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Order odr = new Order();
                        odr.OrderId = (Guid)rdr["OrderId"];
                        odr.TotalCost = rdr["TotalCost"].ToString();
                        odr.Date = (DateTime)rdr["Date"];
                        odr.OrderStatus = rdr["OrderStatus"].ToString();
                        odr.UserUserName = rdr["UserUserName"].ToString();
                        Orders.Add(odr);
                    }
                }
                return Orders;
            }
        } 
        public ICollection<Order> GetAllOrdersbyStatus(string Status)
        {
            List<Order> Orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Orders where OrderStatus=@Status", con);
                cmd.Parameters.AddWithValue("@Status", Status);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Order odr = new Order();
                        odr.OrderId = (Guid)rdr["OrderId"];
                        odr.TotalCost = rdr["TotalCost"].ToString();
                        odr.Date = (DateTime)rdr["Date"];
                        odr.OrderStatus = rdr["OrderStatus"].ToString();
                        odr.UserUserName = rdr["UserUserName"].ToString();
                        Orders.Add(odr);
                    }
                }
                return Orders;
            }
        }

        /*public static void Main(String [] args) { 
             OrderDAO orderdao = new OrderDAO();
             CartItemDAO cartitemdao = new CartItemDAO();
             MenuItemDAO menuitemdao = new MenuItemDAO();



             //addOrder
             *//*Order odr1 = new Order();
             odr1.OrderId = Guid.NewGuid();
             odr1.TotalCost = "120";
             odr1.Date = DateTime.Now;
             odr1.OrderStatus = "Order Placed";
             odr1.UserUserName = "hari";


            CartItem cartitem = new CartItem();
           cartitem.ItemId = Guid.NewGuid();
             cartitem.OrderOrderId = odr1.OrderId;
             cartitem.MenuItemItemName = "Dosa";
             cartitem.Quantity = "2";


             CartItem cartitem1 = new CartItem();
             cartitem1.ItemId = Guid.NewGuid();
             cartitem1.OrderOrderId = odr1.OrderId;
             cartitem1.MenuItemItemName = "Idly";
             cartitem1.Quantity = "2";


             odr1.TotalCost = Convert.ToInt32(cartitem.Quantity) * Convert.ToInt32(menuitemdao.GetMenuItem(cartitem.MenuItemItemName).Cost) +
                              Convert.ToInt32(cartitem1.Quantity) * Convert.ToInt32(menuitemdao.GetMenuItem(cartitem1.MenuItemItemName).Cost)  + "";

            orderdao.AddOrder(odr1);
             cartitemdao.AddItem(cartitem);
             cartitemdao.AddItem(cartitem1);*//*

             //EditOrder
             *//* Order c=orderdao.GetOrder(new Guid("3777e19c-2a5f-40e4-8e32-c074cda9699b"));
             c.OrderStatus = "order delivered";
             orderdao.EditOrder(c);*//*

             //GetOrder
             *//* var order = orderdao.GetOrder(new Guid("8DE932B6-3694-409B-A379-8976273AE149"));
             Console.WriteLine(order.UserUserName+" "+order.Date+" "+order.OrderStatus+" "+order.TotalCost);*//*

             //GetAllOrders
             *//*foreach (var o in orderdao.GetAllOrders()) {
                 Console.WriteLine(o.UserUserName + " " + o.Date + " " + o.OrderStatus + " " + o.TotalCost);
             }*//*

             //DeleteOrder
             //orderdao.DeleteOrder(new Guid("3777e19c-2a5f-40e4-8e32-c074cda9699b"));



             //CartItem Operations
            *//* CartItem obj=cartitemdao.GetItem(new Guid("5d13e521-cd00-4da5-b827-b4fa628cdac5"));
             obj.Quantity = "3";
             cartitemdao.EditItem(obj);*/

        /*foreach(var c in cartitemdao.GetItemsbyOrderId(new Guid("8de932b6-3694-409b-a379-8976273ae149")))
        {
            Console.WriteLine(c.MenuItemItemName + " " + c.OrderOrderId + " " + c.Quantity);
        }*/
        /* cartitemdao.DeleteItem(new Guid("7d5ca85f-e075-4b34-96b1-3954a24bc549"));
         Console.ReadKey();*//*
     }

 */
    }
}