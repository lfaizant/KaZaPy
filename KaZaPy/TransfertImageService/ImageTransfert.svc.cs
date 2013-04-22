using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using DataAccess;

namespace TransfertImageService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ImageTransfert" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ImageTransfert.svc ou ImageTransfert.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ImageTransfert : IImageTransfert
    {
        //private AccesDonnees accesDonnees = new AccesDonnees();
        DataAccess.DBAccess da = new DataAccess.DBAccess();

        public String UploadImage(Stream image, string album)
        {
            // Stocker l’image en BDD
            byte[] imageBytes = null;
            MemoryStream imageStreamEnMemoire = new MemoryStream();
            image.CopyTo(imageStreamEnMemoire);
            imageBytes = imageStreamEnMemoire.ToArray();
            String imageID = da.AddImage(imageBytes, album);
            imageStreamEnMemoire.Close();
            image.Close();
            return imageID;
        }
        public Stream DownloadImage(String imageID)
        {
            // Récupérer l'image stockée en BDD et la transférer au client
            byte[] imageBytes = da.getImage(imageID);
            MemoryStream imageStreamEnMemoire = new MemoryStream(imageBytes);
            return imageStreamEnMemoire;
        }
    }
}
