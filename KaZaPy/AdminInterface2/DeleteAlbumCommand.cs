using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class DeleteAlbumCommand : ICommand 
    {
        public DeleteAlbumCommand() { }

        public void Execute()
        {
            Console.WriteLine("Commande delete album");
        }
    }
}
