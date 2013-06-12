using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectClass;

namespace AdminInterface
{
    class DeleteImageCommand : AbstractCommand
    {
        private ImageService.ImageInfo imageInfo;
        private ImageService.ImageServiceClient imageServiceClient;

        public DeleteImageCommand(string[] args)
            : base()
        {
            if (args.Length < 2)
                throw new SyntaxException("delete_image", "[id]");

            imageServiceClient = new ImageService.ImageServiceClient();
            imageInfo = new ImageService.ImageInfo();
            imageInfo.Id = Convert.ToInt32(args[1]);
        }

        public override void Execute()
        {
            imageServiceClient.DeleteImage(imageInfo);
            Console.WriteLine("Image deleted.");
        }
    }
}
