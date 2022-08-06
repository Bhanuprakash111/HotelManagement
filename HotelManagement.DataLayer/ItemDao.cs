using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HotelManagement.Entities;


namespace HotelManagement.DataLayer
{
    //LAPTOP-N11IRFB2\SQLEXPRESS
    public class ItemDAO
    {
        private String ConnStr;
        public ItemDAO()
        {
            /*ConnStr = ConfigurationManager.ConnectionStrings["HotelMgmtConn"].ConnectionString;*/
            ConnStr = "Data Source=LAPTOP-N11IRFB2\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
        }
        public void AddItem(Item itm)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Insert into Items Values(@ItemId,@Quantity)", con);
                cmd.Parameters.AddWithValue("@ItemId", itm.ItemId);
                cmd.Parameters.AddWithValue("@Quantity", itm.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EditItem(Item itm)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Update  Items set ItemId=@ItemId,Quantity=@Quantity ", con);
                cmd.Parameters.AddWithValue("@ItemId", itm.ItemId);
                cmd.Parameters.AddWithValue("@Quantity", itm.Quantity);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteItem(Guid ItemId)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Delete from Items where ItemId=@ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", ItemId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public Item GetItem(Guid ItemId)
        {
            Item itm = new Item();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Items where ItemId=@ItemId", con);
                cmd.Parameters.AddWithValue("@ItemId", ItemId);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    itm.ItemId = (Guid)rdr["ItemId"];
                    itm.Quantity = rdr["Quantity"].ToString();

                }
                return itm;

            }
        }
        public ICollection<Item> GetItems()
        {
            List<Item> itm = new List<Item>();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from Items", con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Item  it = new Item();
                        it.ItemId = (Guid) rdr["ItemId"];
                        it.Quantity = rdr["Quantity"].ToString();
                        
                    }
                }
                return itm;
            }
        }
    }
}