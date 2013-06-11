using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClass;
using DataAccess;

namespace AdminInterface
{
    class DeleteImageCommand : AbstractCommand
    {
        private Image image;

        public DeleteImageCommand(string[] args)
            : base()
        {
            if (args.Length < 2)
                throw new SyntaxException("delete_image", "[id]");

            image = DBAccess.GetImageById(Convert.ToInt32(args[1]));
        }

        public override void Execute()
        {
            DBAccess.DeleteImage(image);
            Console.WriteLine("Image deleted.");
        }
    }
}
