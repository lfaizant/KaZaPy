using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess;
using ObjectClass;

namespace WebService
{
    public class UserService : IUserService
    {
        public User GetUserById(int userId)
        {
            return DBAccess.GetUserById(userId);
        }

        public User GetUserByEmail(string email)
        {
            return DBAccess.GetUserByEmail(email);
        }

        public void AddUser(User user)
        {
            DBAccess.AddUser(user);
        }

        public void DeleteUser(User user)
        {
            DBAccess.DeleteUser(user);
        }

        public void LogInUser(User user)
        {
            DBAccess.LogInUser(user);
        }

        public void LogOutUser(User user)
        {
            DBAccess.LogOutUser(user);
        }
    }
}
