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
    /// <summary>
    /// Provides all services needed to process KaZaPy users
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Get a KaZaPy user by his unique identifier
        /// </summary>
        /// <param name="userId">user's I</param>
        /// <returns>KaZaPy user</returns>
        public User GetUserById(int userId)
        {
            return DBAccess.GetUserById(userId);
        }

        /// <summary>
        /// Get a KaZaPy user by his email
        /// </summary>
        /// <param name="email">user's email</param>
        /// <returns>KaZaPy user</returns>
        public User GetUserByEmail(string email)
        {
            return DBAccess.GetUserByEmail(email);
        }

        /// <summary>
        /// Store a new KaZaPy user in the database
        /// </summary>
        /// <param name="user">user to add</param>
        public void AddUser(User user)
        {
            DBAccess.AddUser(user);
        }

        /// <summary>
        /// Delete a KaZaPy user from the database
        /// </summary>
        /// <param name="user">user to delete</param>
        public void DeleteUser(User user)
        {
            DBAccess.DeleteUser(user);
        }

        /// <summary>
        /// Log an user in KaZaPy
        /// </summary>
        /// <param name="user">user to log in</param>
        public void LogInUser(User user)
        {
            DBAccess.LogInUser(user);
        }

        /// <summary>
        /// Log an user out KaZaPy
        /// </summary>
        /// <param name="user">user to log out</param>
        public void LogOutUser(User user)
        {
            DBAccess.LogOutUser(user);
        }
    }
}
