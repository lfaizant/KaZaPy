using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class Remote
    {
        ICommand command = null;

        public Remote() { }

        public void invoke(string str)
        {
            switch (str)
            {
                case "deleteuser": command = new DeleteUserCommand();
                    break;
                case "deletealbum": command = new DeleteAlbumCommand();
                    break;
                case "deleteimage": command = new DeleteImageCommand();
                    break;
            }

            invoke(command);
        }

        public void invoke(ICommand cmd)
        {
            cmd.Execute();
        }
    }
}
