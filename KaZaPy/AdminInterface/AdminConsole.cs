using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ObjectClass;

namespace AdminInterface
{
    class AdminConsole
    {
        private static void PrintHead()
        {
            string head = "";
            head += "****************************\n";
            head += "*     ---  KaZaPy  ---     *\n";
            head += "*      Admin Console       *\n";
            head += "****************************\n";

            Console.WriteLine(head);
        }

        private static void ExecuteCommand(string commandLine)
        {
            AbstractCommand command = null;
            string[] commandArgs = commandLine.Split(new char[] {' '});

            switch (commandArgs[0].ToLower().Trim())
            {
                case "delete_image" :
                    command =  new DeleteImageCommand(commandArgs);
                    break;
                case "delete_album" :
                    command = new DeleteAlbumCommand(commandArgs);
                    break;
                case "delete_user" :
                    command = new DeleteUserCommand(commandArgs);
                    break;
                case "help" :
                    command = new HelpCommand();
                    break;
                case "exit" :
                    command = new ExitCommand();
                    break;
                default :
                    throw new InvalidCommandException();
            }

            command.Execute();
        }

        public static void Main(string[] args)
        {
            PrintHead();

            while (true)
            {
                Console.Write("> ");
                string commandLine = Console.ReadLine();

                ExecuteCommand(commandLine);
            }

            /*Command c = new Command();
            bool notExit = true;

            while (notExit)
            {
                string command = Console.ReadLine();
                c.execute(command);
            }*/
        }
    }
}
