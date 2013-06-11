using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string email, string password) :
            base("The password is incorrect for the specified user : user's email = " + email + ", password = " + password) { }
    }
}
