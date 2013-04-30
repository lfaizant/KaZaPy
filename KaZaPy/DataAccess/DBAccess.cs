using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ObjectClass;

namespace DataAccess
{
    /// <summary>
    /// Provides all methods needed to access to the database
    /// </summary>
    public class DBAccess
    {
        // Initialize the connection to the database
        private const string connectionStr = "Server=LOÏC-PC;Database=KaZaPy_DB;Integrated Security=true;";
        private static SqlConnection oConnection = new SqlConnection(connectionStr);

        /// <summary>
        /// Reset all the database tables
        /// </summary>
        /// <param name="alreadyConnected">database connection status</param>
        public static void ResetTables(bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition command
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM Image; " +
                    "DELETE FROM Album; " +
                    "DELETE FROM [User];", oConnection);

                // Execute the addition command
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                oConnection.Close();
            }
        }

#region User
        /// <summary>
        /// Get a KaZaPy user by his unique identifier
        /// </summary>
        /// <param name="userId">user's ID</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>KaZaPy user</returns>
        public static User GetUserById(int userId, bool alreadyConnected = false)
        {
            User user = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT * " +
                    "FROM [User] " +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = userId;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user ID
                if (oReader.Read())
                    user = new User(oReader.GetString(1), oReader.GetString(2), oReader.GetString(3), oReader.GetString(4), oReader.GetInt32(0),
                        oReader.GetBoolean(5), oReader.GetBoolean(6));
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if(!alreadyConnected)
                    oConnection.Close();
            }

            // Return the user ID
            return user;
        }

        /// <summary>
        /// Get a KaZaPy user by his email
        /// </summary>
        /// <param name="email">user's email</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>KaZaPy user</returns>
        public static User GetUserByEmail(string email, bool alreadyConnected = false)
        {
            User user = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT * " +
                    "FROM [User] " +
                    "WHERE email = @email;", oConnection);
                oCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, email.Length).Value = email;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user
                if (oReader.Read())
                    user = new User(oReader.GetString(1), oReader.GetString(2), oReader.GetString(3), oReader.GetString(4), oReader.GetInt32(0),
                        oReader.GetBoolean(5), oReader.GetBoolean(6));
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if(!alreadyConnected)
                    oConnection.Close();
            }

            // Return the user
            return user;
        }

        /// <summary>
        /// Store a new KaZaPy user in the database
        /// </summary>
        /// <param name="user">user to add</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void AddUser(User user, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the addition command
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO [User] (firstName, lastName, email, password, privilege, logged) " +
                    "VALUES(@firstName, @lastName, @email, @password, @privilege, @logged)", oConnection);
                oCommand.Parameters.Add("@firstName", System.Data.SqlDbType.NVarChar, user.FirstName.Length).Value = user.FirstName;
                oCommand.Parameters.Add("@lastName", System.Data.SqlDbType.NVarChar, user.LastName.Length).Value = user.LastName;
                oCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, user.Email.Length).Value = user.Email;
                oCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, user.Password.Length).Value = user.Password;
                oCommand.Parameters.Add("@privilege", System.Data.SqlDbType.Bit).Value = user.Privilege;
                oCommand.Parameters.Add("@logged", System.Data.SqlDbType.Bit).Value = user.Logged;

                // Execute the addition command
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if(!alreadyConnected)
                    oConnection.Close();
            }
        }

        /// <summary>
        /// Delete a KaZaPy user from the database
        /// </summary>
        /// <param name="user">user to delete</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void DeleteUser(User user, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Get user's albums
                List<Album> albums = GetAlbumsByUser(user, true);
                // Delete user's albums
                foreach (Album a in albums)
                    DeleteAlbum(a, true);

                // Initialize the deletion query
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM [User] " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = user.Id;

                // Execute the deletion query
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if(!alreadyConnected)
                    oConnection.Close();
            }
        }

        /// <summary>
        /// Log an user in KaZaPy
        /// </summary>
        /// <param name="user">user to log in</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void LogInUser(User user, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if (!alreadyConnected)
                    oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "UPDATE [User] " +
                    "SET logged = 1 " +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = user.Id;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if (!alreadyConnected)
                    oConnection.Close();
            }
        }

        /// <summary>
        /// Log an user out KaZaPy
        /// </summary>
        /// <param name="user">user to log out</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void LogOutUser(User user, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if (!alreadyConnected)
                    oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "UPDATE [User] " +
                    "SET logged = 0 " +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = user.Id;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if (!alreadyConnected)
                    oConnection.Close();
            }
        }
#endregion

#region Album
        /// <summary>
        /// Get a KaZaPy album by its unique identifier
        /// </summary>
        /// <param name="albumId">album ID</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>KaZaPy album</returns>
        public static Album GetAlbumById(int albumId, bool alreadyConnected = false)
        {
            Album album = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT * " +
                    "FROM Album " +
                    "WHERE id = @albumId;", oConnection);
                oCommand.Parameters.Add("@albumId", System.Data.SqlDbType.Int).Value = albumId;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned album
                if (oReader.Read())
                    album = new Album(oReader.GetString(1), oReader.GetInt32(2), null,
                        oReader.GetDateTime(3), oReader.GetDateTime(4), oReader.GetInt32(0));

                // Close the data reader
                oReader.Close();

                // Get images contained in the album
                album.Images = GetImagesByAlbum(album, true);

            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if(!alreadyConnected)
                    oConnection.Close();
            }

            // Return the album
            return album;
        }

        /// <summary>
        /// Get a KaZaPy album by its name and its owner
        /// </summary>
        /// <param name="name">album name</param>
        /// <param name="owner">album owner</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>KaZaPy album</returns>
        public static Album GetAlbumByNameAndOwner(string name, int owner, bool alreadyConnected = false)
        {
            Album album = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT * " +
                    "FROM Album " +
                    "WHERE name = @name AND owner = @owner;", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, name.Length).Value = name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.Int).Value = owner;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned album
                if (oReader.Read())
                    album = new Album(oReader.GetString(1), oReader.GetInt32(2), null,
                        oReader.GetDateTime(3), oReader.GetDateTime(4), oReader.GetInt32(0));

                // Close the data reader
                oReader.Close();

                // Get images contained in the album
                album.Images = GetImagesByAlbum(album, true);
                
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if(!alreadyConnected)
                    oConnection.Close();
            }

            // Return the album
            return album;
        }

        /// <summary>
        /// Get KaZaPy albums by their owner
        /// </summary>
        /// <param name="user">albums owner</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>User's KaZaPy albums</returns>
        public static List<Album> GetAlbumsByUser(User user, bool alreadyConnected = false)
        {
            List<Album> albums = new List<Album>();

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id " +
                    "FROM Album " +
                    "WHERE owner = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = user.Id;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get returned albums ID
                List<int> albumsId = new List<int>();
                while (oReader.Read())
                    albumsId.Add(oReader.GetInt32(0));

                // Close the data reader
                oReader.Close();

                // Get user's albums
                foreach (int i in albumsId)
                    albums.Add(GetAlbumById(i, true));
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if(!alreadyConnected)
                    oConnection.Close();
            }

            // Return albums
            return albums;
        }

        /// <summary>
        /// Store a new KaZaPy album in the database
        /// </summary>
        /// <param name="album">album to store</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void AddAlbum(Album album, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Album (name, owner, creationDate, modificationDate) " +
                    "VALUES(@name, @owner, @creationDate, @modificationDate);", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, album.Name.Length).Value = album.Name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.Int).Value = album.Owner;
                oCommand.Parameters.Add("@creationDate", System.Data.SqlDbType.DateTime).Value = album.CreationDate;
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.DateTime).Value = album.ModificationDate;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();

                // Store images contained in the album into the database
                foreach (Image i in album.Images)
                    AddImage(i, true);
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if(!alreadyConnected)
                    oConnection.Close();
            }
        }

        /// <summary>
        /// Delete a KaZaPy album from the database
        /// </summary>
        /// <param name="album">album to delete</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void DeleteAlbum(Album album, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Delete images contained in the album
                foreach (Image i in album.Images)
                    DeleteImage(i, true);

                // Initialize the deletion query
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM Album " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = album.Id;

                // Execute the deletion query
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if(!alreadyConnected)
                    oConnection.Close();
            }
        }
#endregion

#region Image
        /// <summary>
        /// Get a KaZaPy image by its unique identifier
        /// </summary>
        /// <param name="imageId">image ID</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>KaZaPy image</returns>
        public static Image GetImageById(int imageId, bool alreadyConnected = false)
        {
            Image image = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if (!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT * " +
                    "FROM Image " +
                    "WHERE id = @imageId;", oConnection);
                oCommand.Parameters.Add("@imageId", System.Data.SqlDbType.Int).Value = imageId;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user ID
                if (oReader.Read())
                {
                    // Get the image ID
                    int id = oReader.GetInt32(0);
                    // Get the size of the current image
                    int size = oReader.GetInt32(1);
                    // Get the blob of the current image
                    byte[] blob = new byte[size];
                    oReader.GetBytes(2, 0, blob, 0, size);
                    // Get the album that contained the image
                    int album = oReader.GetInt32(3);

                    // Construct the image
                    image = new Image(blob, album, id);
                }
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if (!alreadyConnected)
                    oConnection.Close();
            }

            // Return the user ID
            return image;
        }
        /// <summary>
        /// Get all images of a KaZaPy album
        /// </summary>
        /// <param name="album">album that contains images</param>
        /// <param name="alreadyConnected">database connection status</param>
        /// <returns>images contained in the album</returns>
        public static List<Image> GetImagesByAlbum(Album album, bool alreadyConnected = false)
        {
            List<Image> images = new List<Image>();

            // Initialize data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the getting query
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id, size, blob " +
                    "FROM Image " +
                    "WHERE album = @albumId;", oConnection);
                oCommand.Parameters.Add("@albumID", System.Data.SqlDbType.Int).Value = album.Id;

                // Execute the getting query
                oReader = oCommand.ExecuteReader();

                // Browse returned images
                while (oReader.Read())
                {
                    // Get the current image ID
                    int id = oReader.GetInt32(0);
                    // Get the size of the current image
                    int size = oReader.GetInt32(1);
                    // Get the blob of the current image
                    byte[] blob = new byte[size];
                    oReader.GetBytes(2, 0, blob, 0, size);
                    // Add the current blob to the list
                    images.Add(new Image(blob, album.Id, id));
                }
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the data reader and the database connection
                oReader.Close();
                if(!alreadyConnected)
                    oConnection.Close();
            }

            // Return the list of images
            return images;
        }

        /// <summary>
        /// Store a new KaZaPy image into the database
        /// </summary>
        /// <param name="image">image to store</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void AddImage(Image image, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the addtion query
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Image (size, blob, album) " +
                    "VALUES(@size, @blob, @album)", oConnection);
                oCommand.Parameters.Add("@size", System.Data.SqlDbType.Int).Value = image.Blob.Length;
                oCommand.Parameters.Add("@blob", System.Data.SqlDbType.Image, image.Blob.Length).Value = image.Blob;
                oCommand.Parameters.Add("@album", System.Data.SqlDbType.Int).Value = image.Album;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();

                // Initialize query for update the album
                oCommand = null;
                oCommand = new SqlCommand(
                    "UPDATE Album " +
                    "SET modificationDate = @modificationDate " +
                    "WHERE id = @albumId;", oConnection);
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                oCommand.Parameters.Add("@albumId", System.Data.SqlDbType.Int).Value = image.Album;

                // Execute the update query
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if(!alreadyConnected)
                    oConnection.Close();
            }
        }

        /// <summary>
        /// Delete an image from the database
        /// </summary>
        /// <param name="imageId">image ID</param>
        /// <param name="alreadyConnected">database connection status</param>
        public static void DeleteImage(Image image, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize the deletion query
                SqlCommand oCommand = null;
                oCommand = new SqlCommand(
                    "DELETE FROM Image " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = image.Id;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();
                
                // Initialize query for the update of the modification date of the album
                oCommand = null;
                oCommand = new SqlCommand(
                    "UPDATE Album " +
                    "SET modificationDate = @modificationDate " +
                    "WHERE id = @albumId;", oConnection);
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.Date).Value = DateTime.Now;
                oCommand.Parameters.Add("@albumId", System.Data.SqlDbType.Int).Value = image.Album;

                // Execute the update query
                oCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Print the error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                // Close the database connection
                if(!alreadyConnected)
                    oConnection.Close();
            }
        }
#endregion
    }
}
