using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class HelpCommand : AbstractCommand
    {
        public HelpCommand()
            : base() { }

        public override void Execute()        {
            string helpMessage = "";

            helpMessage += "Available commands : \n";
            helpMessage += "\t - delete_image [id]\n";
            helpMessage += "\t - delete_album [-i | -no] [id | [name] [owner]]\n";
            helpMessage += "\t - delete_user [-i | -e] [id | email]\n";
            helpMessage += "\t - help\n";
            helpMessage += "\t - exit\n";

            Console.WriteLine(helpMessage);        }
    }
}
