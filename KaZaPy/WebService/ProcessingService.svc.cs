using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectClass;
using DataAccess;

namespace WebService
{
    public class ProcessingService : IProcessingService
    {
        //private int album;

        /*public void UploadImage(Stream image, int albumId)
        {
            album = albumId;
            UploadImage(image);
        }*/

        /*public void UploadImage(Stream image, int albumId)
        {
            byte[] blob = null;
            MemoryStream imageMemoryStream = new MemoryStream();
            image.CopyTo(imageMemoryStream);
            blob = imageMemoryStream.ToArray();

            // TODO
            DBAccess.AddImage(new Image(blob, albumId));
            //
            imageMemoryStream.Close();
            image.Close();
        }

        public Stream DownloadImage(int imageId)
        {
            byte[] blob = DBAccess.GetImageById(imageId).Blob;
            MemoryStream imageStreamEnMemoire = new MemoryStream(blob);
            return imageStreamEnMemoire;
        }*/

        public void Upload(ImageUploadRequest data)
        {
            byte[] blob = null;
            MemoryStream imageMemoryStream = new MemoryStream();
            data.ImageData.CopyTo(imageMemoryStream);
            blob = imageMemoryStream.ToArray();
            DBAccess.AddImage(new Image(blob, data.ImageInfo.Album));
            imageMemoryStream.Close();
        }

        public ImageDownloadResponse Download(ImageDownloadRequest data)
        {
            byte[] blob = DBAccess.GetImageById(data.ImageInfo.Id).Blob;
            MemoryStream imageStreamEnMemoire = new MemoryStream(blob);
            ImageDownloadResponse idr = new ImageDownloadResponse();
            idr.ImageData = imageStreamEnMemoire;
            return idr;
        }
    }
}
