using HotelManagement.DataLayer;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessLayer
{
    public class UserBO
    {
        public UserDAO UserDAO;
        public UserBO()
        {
                UserDAO = new UserDAO();
        }
        public void AddUser(User UserName)
        {
                UserDAO.AddUser(UserName);
        }
        public void EditUser(User UserName)
        {
                UserDAO.EditUser(UserName);
        }
        public void DeleteUser(string UserName)
        {
            UserDAO.DeleteUser(UserName);
        }
        public User GetUser(string UserName)
        {
            return UserDAO.GetUser(UserName);
        }
        public ICollection<User> GetAllUsers()
        {
                return UserDAO.GetAllUsers();
        }

    }
}
