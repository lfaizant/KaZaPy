using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectClass;

namespace WebService
{
    /// <summary>
    /// Provides all services needed to process KaZaPy albums
    /// </summary>
    [ServiceContract]
    public interface IAlbumService
    {
        /// <summary>
        /// Get a KaZaPy album by its unique identifier
        /// </summary>
        /// <param name="albumId">album ID</param>
        /// <returns>KaZaPy album</returns>
        [OperationContract]
        Album GetAlbumById(int albumId);

        /// <summary>
        /// Get a KaZaPy album by its name and its owner
        /// </summary>
        /// <param name="name">album name</param>
        /// <param name="owner">album owner</param>
        /// <returns>KaZaPy album</returns>
        [OperationContract]
        Album GetAlbumByNameAndOwner(string name, int owner);

        /// <summary>
        /// Get KaZaPy albums by their owner
        /// </summary>
        /// <param name="user">albums owner</param>
        /// <returns>User's KaZaPy albums</returns>
        [OperationContract]
        List<Album> GetAlbumsByUser(User user);

        /// <summary>
        /// Get all KaZaPy albums stored in the database
        /// </summary>
        /// <returns>KaZaPy albums</returns>
        [OperationContract]
        List<Album> GetAllAlbums();

        /// <summary>
        /// Store a new KaZaPy album in the database
        /// </summary>
        /// <param name="album">album to store</param>
        [OperationContract]
        void AddAlbum(Album album);

        /// <summary>
        /// Delete a KaZaPy album from the database
        /// </summary>
        /// <param name="album">album to delete</param>
        [OperationContract]
        void DeleteAlbum(Album album);
    }
}
