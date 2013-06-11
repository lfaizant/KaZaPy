using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string commandType, string commandSyntax)
            : base("The given syntax is invalid : <" + commandType + "> " + commandSyntax) { }
    }
}
