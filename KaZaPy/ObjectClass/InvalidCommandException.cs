using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
            : base("Specified command is not available. Enter 'help' to see available commands")
        { }
    }
}
