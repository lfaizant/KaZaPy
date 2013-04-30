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
            Console.WriteLine("Option : id ou email");

            string option = Console.ReadLine();

            switch (option)
            {
                case "id":
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("id : " + id);
                    break;
                case "email":
                    string email = Console.ReadLine();
                    Console.WriteLine("email !! " + email);
                    break;
            }
        }

    }
}
