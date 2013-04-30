using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class DeleteImageCommand : ICommand
    {
        public DeleteImageCommand() {}

        public void Execute()
        {
            Console.WriteLine("Commande delete image");
        }
    }
}
