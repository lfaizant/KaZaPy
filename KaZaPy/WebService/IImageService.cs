using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    /// <summary>
    /// Provides all services needed to process KaZaPy images
    /// </summary>
    [ServiceContract]
    public interface IImageService
    {
        /// <summary>
        /// Store a new KaZaPy image into the database
        /// </summary>
        /// <param name="data">image to store</param>
        [OperationContract]
        void AddImage(ImageUploadRequest data);

        /// <summary>
        /// Get a KaZaPy image by its unique identifier
        /// </summary>
        /// <param name="data">image ID</param>
        /// <returns>KaZaPy image</returns>
        [OperationContract]
        ImageDownloadResponse GetImage(ImageDownloadRequest data);

        /// <summary>
        /// Delete a KaZaPy image from the database
        /// </summary>
        /// <param name="data">image to delete</param>
        [OperationContract]
        void DeleteImage(ImageDeleteRequest data);
    }

    /// <summary>
    /// Request to upload an image
    /// </summary>
    [MessageContract]
    public class ImageUploadRequest
    {
        /// <summary>
        /// Image informations
        /// </summary>
        [MessageHeader(MustUnderstand = true)]
        public ImageInfo ImageInfo;

        /// <summary>
        /// Image contents
        /// </summary>
        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }

    /// <summary>
    /// Response to an image download
    /// </summary>
    [MessageContract]
    public class ImageDownloadResponse
    {
        /// <summary>
        /// Image contents
        /// </summary>
        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }

    /// <summary>
    /// Request to download an image
    /// </summary>
    [MessageContract]
    public class ImageDownloadRequest
    {
        /// <summary>
        /// Image informations
        /// </summary>
        [MessageBodyMember(Order = 1)]
        //[MessageHeader(MustUnderstand = true)]
        public ImageInfo ImageInfo;
    }

    /// <summary>
    /// Request to delete an image
    /// </summary>
    [MessageContract]
    public class ImageDeleteRequest
    {
        /// <summary>
        /// Image informations
        /// </summary>
        [MessageBodyMember(Order = 1)]
        public ImageInfo ImageInfo;
    }

    /// <summary>
    /// Image information
    /// </summary>
    [DataContract]
    public class ImageInfo
    {
        /// <summary>
        /// Image unique identifier
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public int Id { get; set; }

        /// <summary>
        /// Album that contains the image
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public int Album { get; set; }
    }
}
