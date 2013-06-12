using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClass;

namespace AdminInterface
{
    class DeleteUserCommand : AbstractCommand
    {
        private User user;
        private UserService.UserServiceClient userServiceClient;

        public DeleteUserCommand(string[] args)
            : base()
        {
            if (args.Length < 3)
                throw new SyntaxException("delete_user", "[-i | -e] [id | email]");

            userServiceClient = new UserService.UserServiceClient();

            if (args[1].Equals("-i"))
                user = userServiceClient.GetUserById(Convert.ToInt32(args[2]));
            else if (args[1].Equals("-e"))
                user = userServiceClient.GetUserByEmail(args[2]);
            else
                throw new SyntaxException("delete_user", "[-i | -e] [id | email]");
        }

        public override void Execute()
        {
            userServiceClient.DeleteUser(user);
            Console.WriteLine("User deleted.");
        }
    }
}
