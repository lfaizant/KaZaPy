using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClass;

namespace AdminInterface
{
    class DeleteAlbumCommand : AbstractCommand
    {
        private Album album;
        private AlbumService.AlbumServiceClient albumServiceClient;

        public DeleteAlbumCommand(string[] args)
            : base()
        {
            
            if (args.Length < 3)
                throw new SyntaxException("delete_album", "[-i | -no] [id | [name] [owner]]");

            albumServiceClient = new AlbumService.AlbumServiceClient();

            if (args[1].Equals("-i"))
                album = albumServiceClient.GetAlbumById(Convert.ToInt32(args[2]));
            else if (args[1].Equals("-no"))
            {
                if(args.Length < 4)
                    throw new SyntaxException("delete_album", "[-i | -no] [[id] | [name] [owner]]");

                album = albumServiceClient.GetAlbumByNameAndOwner(args[2], Convert.ToInt32(args[3]));
            }
            else
                throw new SyntaxException("delete_album", "[-i | -no] [[id] | [name] [owner]]");
        }

        public override void Execute()
        {
            albumServiceClient.DeleteAlbum(album);
            Console.WriteLine("Album deleted.");
        }
    }
}
