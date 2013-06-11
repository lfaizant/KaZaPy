using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class ExitCommand : AbstractCommand
    {
        public ExitCommand()
            : base() { }

        public override void Execute()
        {
            Console.Write("Press any key to exit... ");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
