﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HotelManagement.Entities;


namespace HotelManagement.DataLayer
{
    //LAPTOP-N11IRFB2\SQLEXPRESS
    public class CartItemDAO
    {
        private String ConnStr;
        public CartItemDAO()
        {
            /*ConnStr = ConfigurationManager.ConnectionStrings["HotelMgmtConn"].ConnectionString;*/
            ConnStr = "Data Source=VIDHYAMINI\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
        }
        public void AddItem(CartItem itm)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Insert into CartItems Values(@ItemId,@OrderId,@ItemName,@Quantity)", con);
                cmd.Parameters.AddWithValue("@ItemId", itm.ItemId);
                cmd.Parameters.AddWithValue("@Quantity", itm.Quantity);
                cmd.Parameters.AddWithValue("@OrderId", itm.OrderOrderId);
                cmd.Parameters.AddWithValue("@ItemName", itm.MenuItemItemName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EditItem(CartItem itm)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Update CartItems set OrderOrderId=@OrderId,MenuItemItemName=@ItemName,Quantity=@Quantity where ItemId=@ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", itm.ItemId);
                cmd.Parameters.AddWithValue("@Quantity", itm.Quantity);
                cmd.Parameters.AddWithValue("@OrderId", itm.OrderOrderId);
                cmd.Parameters.AddWithValue("@ItemName", itm.MenuItemItemName);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteItem(Guid ItemId)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Delete from CartItems where ItemId=@ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", ItemId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public CartItem GetItem(Guid ItemId)
        {
            CartItem itm = new CartItem();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from CartItems where ItemId=@ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", ItemId);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    itm.ItemId = (Guid)rdr["ItemId"];
                    itm.Quantity = rdr["Quantity"].ToString();
                    itm.OrderOrderId = (Guid)rdr["OrderOrderId"];
                    itm.MenuItemItemName = rdr["MenuItemItemName"].ToString();

                }
                return itm;

            }
        }
        public ICollection<CartItem> GetItemsbyOrderId(Guid OrderId)
        {
            List<CartItem> itm = new List<CartItem>();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from CartItems where OrderOrderId=@OrderId", con);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        CartItem  it = new CartItem();
                        it.ItemId = (Guid) rdr["ItemId"];
                        it.Quantity = rdr["Quantity"].ToString();
                        it.OrderOrderId = (Guid)rdr["OrderOrderId"];
                        it.MenuItemItemName = rdr["MenuItemItemName"].ToString();
                        itm.Add(it);
                    }

                }
                return itm;
            }
        }
    }
}