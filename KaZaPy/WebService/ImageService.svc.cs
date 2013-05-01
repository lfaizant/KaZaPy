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
    /// <summary>
    /// Provides all services needed to process KaZaPy images
    /// </summary>
    public class ImageService : IImageService
    {
        /// <summary>
        /// Store a new KaZaPy image into the database
        /// </summary>
        /// <param name="data">image to store</param>
        public void AddImage(ImageUploadRequest data)
        {
            byte[] blob = null;
            MemoryStream imageMemoryStream = new MemoryStream();
            data.ImageData.CopyTo(imageMemoryStream);
            blob = imageMemoryStream.ToArray();
            DBAccess.AddImage(new Image(blob, data.ImageInfo.Album));
            imageMemoryStream.Close();
        }

        /// <summary>
        /// Get a KaZaPy image by its unique identifier
        /// </summary>
        /// <param name="data">image ID</param>
        /// <returns>KaZaPy image</returns>
        public ImageDownloadResponse GetImage(ImageDownloadRequest data)
        {
            byte[] blob = DBAccess.GetImageById(data.ImageInfo.Id).Blob;
            MemoryStream imageMemoryStream = new MemoryStream(blob);
            ImageDownloadResponse idr = new ImageDownloadResponse();
            idr.ImageData = imageMemoryStream;
            return idr;
        }

        /// <summary>
        /// Delete a KaZaPy image from the database
        /// </summary>
        /// <param name="data">image to delete</param>
        public void DeleteImage(ImageDeleteRequest data)
        {
            Image image = DBAccess.GetImageById(data.ImageInfo.Id);
            DBAccess.DeleteImage(image);
        }
    }
}
