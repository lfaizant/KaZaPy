using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClass;
using DataAccess;

namespace AdminInterface
{
    class DeleteUserCommand : AbstractCommand
    {
        private User user;

        public DeleteUserCommand(string[] args)
            : base()
        {
            if (args.Length < 3)
                throw new SyntaxException("delete_user", "[-i | -e] [id | email]");

            if (args[1].Equals("-i"))
                user = DBAccess.GetUserById(Convert.ToInt32(args[2]));
            else if (args[1].Equals("-e"))
                user = DBAccess.GetUserByEmail(args[2]);
            else
                throw new SyntaxException("delete_user", "[-i | -e] [id | email]");
        }

        public override void Execute()
        {
            DBAccess.DeleteUser(user);
            Console.WriteLine("User deleted.");
        }
    }
}
