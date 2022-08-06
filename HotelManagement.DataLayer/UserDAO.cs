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
            ConnStr = "Data Source=LIGHT\\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True";
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

        /*public static void Main(String [] args) { 
            UserDAO userdao = new UserDAO();
            User user = new User();
            user.UserName = "Bhanu";user.Password = "Bhanu123";user.MobileNumber = "7013930455";user.UserRole = "Admin";user.Address = "Tenali";
            User user1 = new User();
            user1.UserName = "Vijay";user1.Password = "Vijay123";user1.MobileNumber = "6927352893"; user1.UserRole = "User";
            user1.Address = "Guntur";

            userdao.AddUser(user);
            userdao.AddUser(user1);
            user.Password = "Bhanu456";
            userdao.EditUser(user);
            userdao.DeleteUser("Vijay");
            foreach (var usr in userdao.GetAllUsers()) { 
                Console.WriteLine(usr.UserName+" "+usr.Password+" "+usr.Address+" "+usr.UserRole+" "+usr.MobileNumber);
            }

           var usr = userdao.GetUser("Bhanu");
            Console.WriteLine(usr.UserName + " " + usr.Password + " " + usr.Address + " " + usr.UserRole + " " + usr.MobileNumber);
           
            Console.ReadKey();
        }*/
    }
}
