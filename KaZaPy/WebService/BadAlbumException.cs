using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    /// <summary>
    /// Exception thrown when an image is added to a bad album
    /// </summary>
    public class BadAlbumException : Exception
    {
        public BadAlbumException(int image, int album) : base("IDs doesn't match between image and album : image ID = " + image + ", album ID = " + album) { }
    }
}