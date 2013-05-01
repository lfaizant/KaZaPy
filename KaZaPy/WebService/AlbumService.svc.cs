using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess;
using ObjectClass;

namespace WebService
{
    /// <summary>
    /// Provides all services needed to process KaZaPy albums
    /// </summary>
    public class AlbumService : IAlbumService
    {
        /// <summary>
        /// Get a KaZaPy album by its unique identifier
        /// </summary>
        /// <param name="albumId">album ID</param>
        /// <returns>KaZaPy album</returns>
        public Album GetAlbumById(int albumId)
        {
            return DBAccess.GetAlbumById(albumId);
        }

        /// <summary>
        /// Get a KaZaPy album by its name and its owner
        /// </summary>
        /// <param name="name">album name</param>
        /// <param name="owner">album owner</param>
        /// <returns>KaZaPy album</returns>
        public Album GetAlbumByNameAndOwner(string name, int owner)
        {
            return DBAccess.GetAlbumByNameAndOwner(name, owner);
        }

        /// <summary>
        /// Get KaZaPy albums by their owner
        /// </summary>
        /// <param name="user">albums owner</param>
        /// <returns>User's KaZaPy albums</returns>
        public List<Album> GetAlbumsByUser(User user)
        {
            return DBAccess.GetAlbumsByUser(user);
        }

        /// <summary>
        /// Get all KaZaPy albums stored in the database
        /// </summary>
        /// <returns>KaZaPy albums</returns>
        public List<Album> GetAllAlbums()
        {
            return DBAccess.GetAllAlbums();
        }

        /// <summary>
        /// Store a new KaZaPy album in the database
        /// </summary>
        /// <param name="album">album to store</param>
        public void AddAlbum(Album album)
        {
            DBAccess.AddAlbum(album);
        }

        /// <summary>
        /// Delete a KaZaPy album from the database
        /// </summary>
        /// <param name="album">album to delete</param>
        public void DeleteAlbum(Album album)
        {
            DBAccess.DeleteAlbum(album);
        }
    }
}
