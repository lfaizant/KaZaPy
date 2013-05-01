using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract]
        void AddImage(ImageUploadRequest data);

        [OperationContract]
        ImageDownloadResponse GetImage(ImageDownloadRequest data);

        [OperationContract]
        void DeleteImage(ImageDeleteRequest data);
    }

    [MessageContract]
    public class ImageUploadRequest
    {
        [MessageHeader(MustUnderstand = true)]
        public ImageInfo ImageInfo;

        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }

    [MessageContract]
    public class ImageDownloadResponse
    {
        [MessageBodyMember(Order = 1)]
        public Stream ImageData;
    }

    [MessageContract]
    public class ImageDownloadRequest
    {
        [MessageBodyMember(Order = 1)]
        public ImageInfo ImageInfo;
    }

    [MessageContract]
    public class ImageDeleteRequest
    {
        [MessageBodyMember(Order = 1)]
        public ImageInfo ImageInfo;
    }

    [DataContract]
    public class ImageInfo
    {
        [DataMember(Order = 1, IsRequired = true)]
        public int Id { get; set; }
        [DataMember(Order = 2, IsRequired = true)]
        public int Album { get; set; }
    }
}
