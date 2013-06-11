using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string email)
            : base("Specified user does not exist in the database : user's email = " + email) { }
    }
}
