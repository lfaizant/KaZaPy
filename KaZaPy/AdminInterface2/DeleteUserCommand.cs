using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class DeleteUserCommand : ICommand
    {
        public DeleteUserCommand() { }

        public void Execute()
        {
            Console.WriteLine("Commande delete user");
        }

    }
}
