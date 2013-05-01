using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectClass;

namespace WebService
{
    /// <summary>
    /// Provides all services needed to process KaZaPy users
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// Get a KaZaPy user by his unique identifier
        /// </summary>
        /// <param name="userId">user's I</param>
        /// <returns>KaZaPy user</returns>
        [OperationContract]
        User GetUserById(int userId);

        /// <summary>
        /// Get a KaZaPy user by his email
        /// </summary>
        /// <param name="email">user's email</param>
        /// <returns>KaZaPy user</returns>
        [OperationContract]
        User GetUserByEmail(string email);

        /// <summary>
        /// Store a new KaZaPy user in the database
        /// </summary>
        /// <param name="user">user to add</param>
        [OperationContract]
        void AddUser(User user);

        /// <summary>
        /// Delete a KaZaPy user from the database
        /// </summary>
        /// <param name="user">user to delete</param>
        [OperationContract]
        void DeleteUser(User user);

        /// <summary>
        /// Log an user in KaZaPy
        /// </summary>
        /// <param name="user">user to log in</param>
        [OperationContract]
        void LogInUser(User user);

        /// <summary>
        /// Log an user out KaZaPy
        /// </summary>
        /// <param name="user">user to log out</param>
        [OperationContract]
        void LogOutUser(User user);
    }
}
