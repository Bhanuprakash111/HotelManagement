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
        public void AddItem(User UserName)
        {
                UserDAO.AddUser(UserName);
        }
        public void EditItem(User UserName)
        {
                UserDAO.EditUser(UserName);
        }
        public void DeleteUser(string UserName)
        {
            UserDAO.DeleteUser(UserName);
        }
        public void GetUser(string UserName)
        {
            UserDAO.GetUser(UserName);
        }
        public ICollection<User> GetAllUsers()
        {
                return UserDAO.GetAllUsers();
        }

    }
}
