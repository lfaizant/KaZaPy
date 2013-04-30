using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectClass
{
    /// <summary>
    /// A KaZaPy user, admin or not
    /// </summary>
    public class User
    {
#region Attributes
        /// <summary>
        /// User's unique identifier
        /// </summary>
        private int id;
        /// <summary>
        /// User's first name
        /// </summary>
        private string firstName;
        /// <summary>
        /// User's last name
        /// </summary>
        private string lastName;
        /// <summary>
        /// User's email
        /// </summary>
        private string email;
        /// <summary>
        /// User's password
        /// </summary>
        private string password;
        /// <summary>
        /// User's privilege : admin or not
        /// </summary>
        bool privilege;
        /// <summary>
        /// User's status : logged or not
        /// </summary>
        bool logged;
#endregion

#region Constructors
        /// <summary>
        /// Construct a new KaZaPy user
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="id">User's unique identifier</param>
        /// <param name="privilege">User's privilege</param>
        /// <param name="logged">User's status</param>
        public User(string firstName, string lastName, string email, string password, int id = 0, bool privilege = false, bool logged = true)
        {
            // Set user's attributes
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.privilege = privilege;
            this.logged = logged;
        }
#endregion

#region Properties
        /// <summary>
        /// User's unique identifier
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// User's email
        /// </summary>
        public string Email
        {
            get { return email; }
        }

        /// <summary>
        /// User's password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// User's privilege
        /// </summary>
        public bool Privilege
        {
            get { return privilege; }
            set { privilege = value; }
        }

        /// <summary>
        /// User's status
        /// </summary>
        public bool Logged
        {
            get { return logged; }
            set { logged = value; }
        }
#endregion

#region Methods
        /// <summary>
        /// Check equality between two KaZaPy users
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>equality between the two KaZaPy users</returns>
        public override bool Equals(object obj)
        {
            // Cast object into a KaZaPy user
            User u = obj as User;

            // Check the object type
            if (u == null)
                return false;
            // Check equality between the two user IDs and between the two user emails
            else
                return (this.Id.Equals(u.Id) && this.Email.Equals(u.Email));
        }
#endregion
    }
}