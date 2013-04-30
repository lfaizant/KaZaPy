using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectClass
{
    /// <summary>
    /// A KaZaPy image
    /// </summary>
    public class Image
    {
#region Attributes
        /// <summary>
        /// Image unique identifier
        /// </summary>
        private int id;
        /// <summary>
        /// Image size
        /// </summary>
        private int size;
        /// <summary>
        /// Image blob
        /// </summary>
        private byte[] blob;
        /// <summary>
        /// Album that contains the image
        /// </summary>
        private int album;
#endregion

#region Constructors
        /// <summary>
        /// Create a new KaZaPy image
        /// </summary>
        /// <param name="blob">image blob</param>
        /// <param name="album">album that contains the image</param>
        /// <param name="id">image unique identifier</param>
        public Image(byte[] blob, int album, int id = 0)
        {
            // Set image attributes
            this.id = id;
            this.size = blob.Length;
            this.blob = blob;
            this.album = album;
        }
#endregion

#region Properties
        /// <summary>
        /// Image unique identifier
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Image size
        /// </summary>
        public int Size
        {
            get { return size; }
        }

        /// <summary>
        /// Image blob
        /// </summary>
        public byte[] Blob
        {
            get { return blob; }
        }

        /// <summary>
        /// Album that contains the image
        /// </summary>
        public int Album
        {
            get { return album; }
        }
#endregion

#region Methods
        /// <summary>
        /// Check equality between two KaZaPy images
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>equality between the two KaZaPy image</returns>
        public override bool Equals(object obj)
        {
            // Cast object into a KaZaPy image
            Image i = obj as Image;

            // Check the object type
            if (i == null)
                return false;
            // Check equality between the two image IDs
            else
                return this.Id.Equals(i.Id);
        }
#endregion
    }
}