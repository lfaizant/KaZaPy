using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    abstract class AbstractCommand
    {
        public AbstractCommand() { }

        public abstract void Execute();
    }
}
