using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class AdminConsole
    {
        static void Main(string[] args)
        {
            Remote remote = new Remote();

            string command = Console.ReadLine();

            remote.invoke(command);

            Console.ReadKey();

        }
    }
}
