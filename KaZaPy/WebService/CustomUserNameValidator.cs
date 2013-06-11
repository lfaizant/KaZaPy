using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using DataAccess;
using ObjectClass;

namespace WebService
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(String email, String password)
        {
            if (email == null || password == null)
                throw new ArgumentNullException();

            User user = DBAccess.GetUserByEmail(email);
            if (user == null)
                throw new InvalidUserException(email);

            if (!user.Password.Equals(password))
                throw new InvalidPasswordException(email, password);
        }
    }
}