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
            ConnStr = "Data Source=LAPTOP-I89K45BK\\SQLEXPRESS01;Initial Catalog=HotelManagement;Integrated Security=True";
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
                                                "@OrderStatus, UserName=@UserName where OrderId=@OrderId", con);
                cmd.Parameters.AddWithValue("@TotalCost", odr.TotalCost);
                cmd.Parameters.AddWithValue("@Date", odr.Date);
                cmd.Parameters.AddWithValue("@OrderStatus", odr.OrderStatus);
                cmd.Parameters.AddWithValue("@UserName", odr.UserUserName);
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
                cmd.Parameters.AddWithValue("@OrderId",od.OrderId);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    od.OrderId = (Guid)rdr["OrderId"];
                    od.TotalCost = rdr["TotalCost"].ToString();
                    od.Date= (DateTime)rdr["Date"];
                    od.OrderStatus = rdr["OrderStatus"].ToString();
                    od.UserUserName = rdr["UserName"].ToString();
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
                        odr.UserUserName=rdr["UserName"].ToString();
                        Orders.Add(odr);
                    }
                }
                return Orders;
            }
        }
        /*
        public static void Main(String [] args) { 
            OrderDAO orderdao = new OrderDAO();
            Order odr1 = new Order();
            odr1.OrderId = 123;odr1.TotalCost = "300 Rs";odr1.Date = "06/08/2022";odr1.OrderStatus = "Order Ready";odr1.UserUserName = "Haritha";
            Order odr2 = new Order();
            odr2.OrderId = "234";odr2.TotalCost = "500 Rs";odr2.Date = "05/08/2022"; odr2.OrderStatus = "Order served";
            odr2.UserUserName = "Vidhya";

            orderdao.AddOrder(odr1);
            orderdao.AddOrder(odr2);
            odr2.UserUserName = "Vidhyamini";
            orderdao.EditOrder(odr2);
            orderdao.DeleteOrder("123");
            foreach (var usr in orderdao.GetAllOrders()) { 
                Console.WriteLine(odr2.OrderId+" "+odr2.TotalCost+" "+usr.Date+" "+usr.OrderStatus+" "+usr.UserUserName);
            }

           var odr3 = orderdao.GetOrder("234");
            Console.WriteLine(odr3.OrderId+ " " + odr3.TotalCost + " " + odr3.Date + " " + odr3.OrderStatus + " " + odr3.UserUserName);
           
            Console.ReadKey();
        }
        */
    }
}

