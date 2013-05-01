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
    public class ImageService : IImageService
    {
        public void AddImage(ImageUploadRequest data)
        {
            byte[] blob = null;
            MemoryStream imageMemoryStream = new MemoryStream();
            data.ImageData.CopyTo(imageMemoryStream);
            blob = imageMemoryStream.ToArray();
            DBAccess.AddImage(new Image(blob, data.ImageInfo.Album));
            imageMemoryStream.Close();
        }

        public ImageDownloadResponse GetImage(ImageDownloadRequest data)
        {
            byte[] blob = DBAccess.GetImageById(data.ImageInfo.Id).Blob;
            MemoryStream imageMemoryStream = new MemoryStream(blob);
            ImageDownloadResponse idr = new ImageDownloadResponse();
            idr.ImageData = imageMemoryStream;
            return idr;
        }

        public void DeleteImage(ImageDeleteRequest data)
        {
            Image image = DBAccess.GetImageById(data.ImageInfo.Id);
            DBAccess.DeleteImage(image);
        }
    }
}
