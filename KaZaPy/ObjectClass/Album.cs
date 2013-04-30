using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObjectClass
{
    /// <summary>
    /// A KaZaPy album of images
    /// </summary>
    public class Album
    {
#region Attributes
        /// <summary>
        /// Album unique identifier
        /// </summary>
        private int id;
        /// <summary>
        /// Album name
        /// </summary>
        private string name;
        /// <summary>
        /// Album owner
        /// </summary>
        private int owner;
        /// <summary>
        /// Images contained in the album
        /// </summary>
        private List<Image> images;
        /// <summary>
        /// Album creation date
        /// </summary>
        private DateTime creationDate;
        /// <summary>
        /// Album modification date
        /// </summary>
        private DateTime modificationDate;
#endregion

#region Constructors
        /// <summary>
        /// Create a new KaZaPy album
        /// </summary>
        /// <param name="name">Album name</param>
        /// <param name="owner">Album owner</param>
        /// <param name="id">Album unique identifier</param>
        public Album(string name, int owner, int id = 0)
        {
            // Set album attributes
            this.id = id;
            this.name = name;
            this.owner = owner;
            this.images = new List<Image>();
            this.creationDate = DateTime.Now;
            this.modificationDate = DateTime.Now;
        }

        /// <summary>
        /// Create a new KaZaPy album
        /// </summary>
        /// <param name="name">Album name</param>
        /// <param name="owner">Album owner</param>
        /// <param name="images">Images contained in the album</param>
        /// <param name="creationDate">Album creation date</param>
        /// <param name="modificationDate">Album modification date</param>
        /// <param name="id">Album unique identifier</param>
        public Album(string name, int owner, List<Image> images, DateTime creationDate, DateTime modificationDate, int id = 0)
        {
            // Set album attributes
            this.id = id;
            this.name = name;
            this.owner = owner;
            this.images = images;
            this.creationDate = creationDate;
            this.modificationDate = modificationDate;
        }
#endregion

#region Properties
        /// <summary>
        /// Album unique identifier
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Album name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Album owner
        /// </summary>
        public int Owner
        {
            get { return owner; }
        }

        /// <summary>
        /// Images contained in the album
        /// </summary>
        public List<Image> Images
        {
            get { return images; }
            set { images = value; }
        }

        /// <summary>
        /// Album creation date
        /// </summary>
        public DateTime CreationDate
        {
            get { return creationDate; }
        }

        /// <summary>
        /// Album modification date
        /// </summary>
        public DateTime ModificationDate
        {
            get { return modificationDate; }
        }
#endregion

#region Methods
        /// <summary>
        /// Check equality between two KaZaPy albums
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>equality between the two KaZaPy albums</returns>
        public override bool Equals(object obj)
        {
            // Cast object into a KaZaPy album
            Album a = obj as Album;

            // Check the object type
            if (a == null)
                return false;
            // Check equality between the two album IDs
            else
                return this.Id.Equals(a.Id);
        }

        /// <summary>
        /// Add an image to the album
        /// </summary>
        /// <param name="image">image to add</param>
        public void AddImage(Image image)
        {
            // Check the album attribute of the image
            if (!image.Album.Equals(image.Album))
                throw new BadAlbumException(image.Album, this.Id);

            // Add image to the album
            this.images.Add(image);
            // Update the album modification date
            this.modificationDate = DateTime.Now;
        }

        /// <summary>
        /// Delete an image from the album
        /// </summary>
        /// <param name="image">image to delete</param>
        public void DeleteImage(Image image)
        {
            // Delete image from the album
            this.images.Remove(image);
            // Update the album modification date
            this.modificationDate = DateTime.Now;
        }
#endregion
    }
}