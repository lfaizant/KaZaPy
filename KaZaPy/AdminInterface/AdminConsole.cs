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
            Command c = new Command();
            bool notExit = true;

            while (notExit)
            {
                string command = Console.ReadLine();
                c.execute(command);
            }

            Console.ReadKey();

        }
    }
}
