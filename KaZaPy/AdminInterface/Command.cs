using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminInterface
{
    class Command
    {
        public Command() { }

        public void execute(string cmd)
        {
            string[] elem = cmd.Split(' ');

            switch (elem[0])
            {
                case "deleteuser" :
                    switch (elem[1])
                    {
                        case "id" : deleteUserId(int.Parse(elem[2]));
                            break;
                        case "email": deleteUserEmail(elem[2]);
                            break;
                    }
                    break;
                case "deletealbum" :
                    switch (elem[1])
                    {
                        case "id": deleteAlbumId(int.Parse(elem[2]));
                            break;
                        case "nom": deleteAlbumNom(elem[2]);
                            break;
                    }
                    break;
                case "deleteimage" : 
                    switch (elem[1])
                    {
                        case "id": deleteImageId(int.Parse(elem[2]));
                            break;
                        case "nom": deleteImageNom(elem[2]);
                            break;
                    }
                    break;                    
            }


        }

        public void deleteUserId(int id)
        {

        }

        public void deleteUserEmail(string email)
        {

        }

        public void deleteAlbumId(int id)
        {

        }

        public void deleteAlbumNom(string nom)
        {

        }
        public void deleteImageId(int id)
        {

        }

        public void deleteImageNom(string nom)
        {

        }

    }
}
