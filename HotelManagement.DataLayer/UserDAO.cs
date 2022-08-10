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
    public class UserDAO
    {
        private String ConnStr;
        public UserDAO() {
            /*ConnStr = ConfigurationManager.ConnectionStrings["HotelMgmtConn"].ConnectionString;*/
            ConnStr = "Data Source=VIDHYAMINI\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
            //ConnStr = "Data Source=LIGHT\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";

        }

        public void AddUser(User usr) {
            using (SqlConnection con = new SqlConnection(ConnStr)) {
                SqlCommand cmd = new SqlCommand("Insert into Users Values(@UserName,@Password,@Address," +
                                                "@MobileNumber,@UserRole)", con);
                cmd.Parameters.AddWithValue("@UserName", usr.UserName);
                cmd.Parameters.AddWithValue("@Password", usr.Password);
                cmd.Parameters.AddWithValue("@Address", usr.Address);
                cmd.Parameters.AddWithValue("@MobileNumber", usr.MobileNumber);
                cmd.Parameters.AddWithValue("@UserRole", usr.UserRole);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditUser(User usr) {
            using (SqlConnection con = new SqlConnection(ConnStr)) {
                SqlCommand cmd = new SqlCommand("Update Users set Password=@Password, Address=@Address, MobileNumber=" +
                                                "@MobileNumber, UserRole=@UserRole where UserName=@UserName", con );
                cmd.Parameters.AddWithValue("@Password",usr.Password);
                cmd.Parameters.AddWithValue("@Address",usr.Address);
                cmd.Parameters.AddWithValue("@MobileNumber",usr.MobileNumber);
                cmd.Parameters.AddWithValue("@UserRole",usr.UserRole);
                cmd.Parameters.AddWithValue("@UserName",usr.UserName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(string UserName) { 
            using(SqlConnection con = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand("Delete from Users where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public User GetUser(string UserName)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(ConnStr)) {
                SqlCommand cmd = new SqlCommand("Select * from Users where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    user.UserName = rdr["UserName"].ToString();
                    user.Password = rdr["Password"].ToString();
                    user.Address = rdr["Address"].ToString();
                    user.MobileNumber = rdr["MobileNumber"].ToString();
                    user.UserRole = rdr["UserRole"].ToString();
                }
                return user;
                
            } 
        }
        
        public bool IsUserNameAvailable(string UserName)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(ConnStr)) {
                SqlCommand cmd = new SqlCommand("Select * from Users where UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                return cmd.ExecuteReader().HasRows;
                
            } 
        }

        public ICollection<User> GetAllUsers() {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(ConnStr)) {
                SqlCommand cmd = new SqlCommand("Select * from Users",con);
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) {
                    while (rdr.Read()) { 
                        User usr = new User();
                        usr.UserName = rdr["UserName"].ToString();
                        usr.Password = rdr["Password"].ToString();
                        usr.Address = rdr["Address"].ToString();
                        usr.MobileNumber = rdr["MobileNumber"].ToString();
                        usr.UserRole = rdr["UserRole"].ToString();
                        users.Add(usr);
                    }
                }
                return users;
            }   
        }
    }
}
