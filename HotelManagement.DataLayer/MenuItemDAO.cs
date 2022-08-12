using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HotelManagement.Entities;
using dotenv.net;

namespace HotelManagement.DataLayer
{
    public class MenuItemDAO
    {
        public static string ConnStr;
        public MenuItemDAO()
        {
            IDictionary<string, string> envVars = DotEnv.Fluent()
            .WithExceptions().WithEnvFiles().WithTrimValues().WithOverwriteExistingVars().WithProbeForEnv(probeLevelsToSearch: 6).Read();
            ConnStr = envVars["CONNECTION_STRING"];

        }


        public void AddMenuItem(MenuItem mi)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Insert into MenuItems Values(@ItemName,@Cost,@Category,@Availability,@Image)", con);
                cmd.Parameters.AddWithValue("@ItemName", mi.ItemName);
                cmd.Parameters.AddWithValue("@Cost", mi.Cost);
                cmd.Parameters.AddWithValue("@Category", mi.Category);
                cmd.Parameters.AddWithValue("@Availability", mi.Availability); 
                cmd.Parameters.AddWithValue("@Image", mi.Image);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditMenuItem(MenuItem mi)
        {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Update MenuItems set Cost=@Cost,Category=@Category,Availability=@Availability,Image=@Image where ItemName=@ItemName", con);
                cmd.Parameters.AddWithValue("@ItemName", mi.ItemName);
                cmd.Parameters.AddWithValue("@Cost", mi.Cost);
                cmd.Parameters.AddWithValue("@Category", mi.Category);
                cmd.Parameters.AddWithValue("@Availability", mi.Availability);
                cmd.Parameters.AddWithValue("@Image", mi.Image);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
  

        public void DeleteMenuItem(string ItemName)
        {
            using(SqlConnection con=new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Delete from MenuItems where ItemName=@ItemName", con);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public MenuItem GetMenuItem(string ItemName)
        {
            MenuItem menuItem = new MenuItem();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from MenuItems where ItemName=@ItemName", con) ;
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                con.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    menuItem.ItemName = rdr["ItemName"].ToString();
                    menuItem.Cost = rdr["Cost"].ToString();
                    menuItem.Category = rdr["Category"].ToString();
                    menuItem.Availability = rdr["Availability"].ToString();
                    menuItem.Image = rdr["Image"].ToString();
                }
                return menuItem;
            }

        }
        public bool isItemAvailable(string ItemName) {
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from MenuItems where ItemName=@ItemName", con);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                { 
                    return rdr.HasRows;
                }
            }
        }
             

        public ICollection<MenuItem> GetAllMenuItemsByCategory(string Category)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Select * from MenuItems where Category=@Category", con);
                cmd.Parameters.AddWithValue("@Category", Category);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        MenuItem menuItem = new MenuItem();
                        menuItem.ItemName = rdr["ItemName"].ToString();
                        menuItem.Cost = rdr["Cost"].ToString();
                        menuItem.Category = rdr["Category"].ToString();
                        menuItem.Availability = rdr["Availability"].ToString();
                        menuItem.Image = rdr["Image"].ToString();
                        menuItems.Add(menuItem);
                    }
                }
                return menuItems;
            }
        }

/*        public static void Main() { 
            MenuItemDAO menuItemDAO = new MenuItemDAO();
            MenuItem menuItem1 = new MenuItem();
            MenuItem menuItem2 = new MenuItem();
            MenuItem menuItem3 = new MenuItem();
            menuItem1.ItemName = "Dosa";menuItem1.Cost = "25";menuItem1.Availability = "no";menuItem1.Category = "breakfast";menuItem1.Image = "";
            menuItem2.ItemName = "Biriyani";menuItem2.Cost = "250";menuItem2.Availability = "yes";menuItem2.Category = "maincourse";menuItem2.Image = "";
            menuItem3.ItemName = "IceCream"; menuItem3.Cost = "50"; menuItem3.Availability = "yes"; menuItem3.Category = "desserts"; menuItem3.Image = "";
            menuItemDAO.AddMenuItem(menuItem3);
        }*/

    }
}
