using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DBAccess
    {
        // Initialize the connection to the database
        private const string connectionStr = "Server=LOÏC-PC;Database=KaZaPy_DB;Integrated Security=true;";
        private static SqlConnection oConnection = new SqlConnection(connectionStr);

        public static void ResetTables()
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
        /// Get an user ID by its email
        /// </summary>
        /// <param name="email">user's email</param>
        /// <returns>user's ID</returns>
        public static int GetUserId(string email)
        {
            int userId = -1;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id " +
                    "FROM [User] " +
                    "WHERE email = @email;", oConnection);
                oCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, email.Length).Value = email;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user ID
                if (oReader.Read())
                    userId = oReader.GetInt32(0);
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
                oConnection.Close();
            }

            // Return the user ID
            return userId;
        }

        /// <summary>
        /// Store a new user to the database
        /// </summary>
        /// <param name="firstName">user's first name</param>
        /// <param name="lastName">user's last name</param>
        /// <param name="email">user's email</param>
        /// <param name="password">user's password</param>
        /// <param name="privilege">admin privilege</param>
        /// <param name="logged">user's log state</param>
        public static void AddUser(string firstName, string lastName, string email, string password, bool privilege = false, bool logged = true)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition command
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO [User] (firstName, lastName, email, password, privilege, logged) " +
                    "VALUES(@firstName, @lastName, @email, @password, @privilege, @logged)", oConnection);
                oCommand.Parameters.Add("@firstName", System.Data.SqlDbType.NVarChar, firstName.Length).Value = firstName;
                oCommand.Parameters.Add("@lastName", System.Data.SqlDbType.NVarChar, lastName.Length).Value = lastName;
                oCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, email.Length).Value = email;
                oCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, password.Length).Value = password;
                oCommand.Parameters.Add("@privilege", System.Data.SqlDbType.Bit).Value = privilege;
                oCommand.Parameters.Add("@logged", System.Data.SqlDbType.Bit).Value = logged;

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

        /// <summary>
        /// Delete an user from the database
        /// </summary>
        /// <param name="userId">user's ID</param>
        public static void DeleteUser(int userId)
        {
            // Initialize data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize query for the getting of user's albums ID
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id " +
                    "FROM Album " +
                    "WHERE owner = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;

                // Execute the getting query
                oReader = oCommand.ExecuteReader();

                // Get user's albums ID
                List<int> albumsId = new List<int>();
                while(oReader.Read())
                    albumsId.Add(oReader.GetInt32(0));

                // Close the data reader
                oReader.Close();

                // Browse returned albums ID
                foreach (int i in albumsId)
                    // Delete current album
                    DeleteAlbum(i, true);

                // Initialize the deletion query
                oCommand = null;
                oCommand = new SqlCommand(
                    "DELETE FROM [User] " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = userId;

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
                // Close the data reader and the database connection
                oReader.Close();
                oConnection.Close();
            }
        }

        /// <summary>
        /// Log in an user to KaZaPy
        /// </summary>
        /// <param name="userId">user's ID</param>
        public static void LogInUser(int userId)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "UPDATE [User] " +
                    "SET logged = 1 " +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;

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
                oConnection.Close();
            }
        }

        /// <summary>
        /// Log out an user to KaZaPy
        /// </summary>
        /// <param name="userId">user's ID</param>
        public static void LogOutUser(int userId)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "UPDATE [User] " +
                    "SET logged = 0 " +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;

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
                oConnection.Close();
            }
        }
#endregion

#region Album
        /// <summary>
        /// Get an album ID by its name and its owner
        /// </summary>
        /// <param name="name">name of the album</param>
        /// <param name="owner">owner of the album</param>
        /// <returns>album ID</returns>
        public static int GetAlbumId(string name, int owner)
        {
            int albumId = -1;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id " +
                    "FROM Album " +
                    "WHERE name = @name AND owner = @owner;", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, name.Length).Value = name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.Int).Value = owner;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user ID
                if (oReader.Read())
                    albumId = oReader.GetInt32(0);
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
                oConnection.Close();
            }

            // Return the user ID
            return albumId;
        }

        /// <summary>
        /// Store a new album in the database
        /// </summary>
        /// <param name="name">name of the album</param>
        /// <param name="owner">owner of the album</param>
        public static void AddAlbum(string name, int owner)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Album (name, owner) " +
                    "VALUES(@name, @owner);", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, name.Length).Value = name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.Int, owner).Value = owner;

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
                oConnection.Close();
            }
        }

        /// <summary>
        /// Delete an album from the database
        /// </summary>
        /// <param name="albumId">album ID</param>
        public static void DeleteAlbum(int albumId, bool alreadyConnected = false)
        {
            try
            {
                // Connect to the database
                if(!alreadyConnected)
                    oConnection.Open();

                // Initialize query for the deletion of images of the album
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM Image " +
                    "WHERE album = @albumId;", oConnection);
                oCommand.Parameters.Add("@albumId", System.Data.SqlDbType.Int).Value = albumId;

                // Execute the deletion query
                oCommand.ExecuteNonQuery();

                // Initialize the deletion query
                oCommand = new SqlCommand(
                    "DELETE FROM Album " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = albumId;

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
        /// Get all the images of an album
        /// </summary>
        /// <param name="albumId">album ID</param>
        /// <returns>List of images</returns>
        public static Dictionary<int, byte[]> GetImagesByAlbum(int albumId)
        {
            Dictionary<int, byte[]> images = new Dictionary<int, byte[]>();

            // Initialize data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the getting query
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id, size, blob " +
                    "FROM Image " +
                    "WHERE album = @albumId;", oConnection);
                oCommand.Parameters.Add("@albumID", System.Data.SqlDbType.Int).Value = albumId;

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
                    images.Add(id, blob);
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
                oConnection.Close();
            }

            // Return the list of images
            return images;
        }

        /// <summary>
        /// Store a new image in the database
        /// </summary>
        /// <param name="image">image to store</param>
        /// <param name="album">album of the image</param>
        public static void AddImage(byte[] image, int album)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addtion query
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Image (size, blob, album) " +
                    "VALUES(@size, @blob, @album)", oConnection);
                oCommand.Parameters.Add("@size", System.Data.SqlDbType.Int).Value = image.Length;
                oCommand.Parameters.Add("@blob", System.Data.SqlDbType.Image, image.Length).Value = image;
                oCommand.Parameters.Add("@album", System.Data.SqlDbType.Int).Value = album;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();

                // Initialize query for update the album
                oCommand = null;
                oCommand = new SqlCommand(
                    "UPDATE Album " +
                    "SET modificationDate = @modificationDate " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.Date).Value = DateTime.Now;
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = album;

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
                oConnection.Close();
            }
        }

        /// <summary>
        /// Delete an image from the database
        /// </summary>
        /// <param name="imageId">image ID</param>
        public static void DeleteImage(int imageId)
        {
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize getting query for the ID of the album to update
                SqlCommand oCommand = new SqlCommand(
                    "SELECT album " +
                    "FROM Image " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = imageId;

                // Execute the getting command
                oReader = oCommand.ExecuteReader();

                // Get the album ID
                int albumId = -1;
                if (oReader.Read())
                    albumId = oReader.GetInt32(0);

                // Close the data reader
                oReader.Close();

                // Initialize the deletion query
                oCommand = null;
                oCommand = new SqlCommand(
                    "DELETE FROM Image " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = imageId;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();
                

                // Initialize query for the update of the modification date of the album
                oCommand = null;
                oCommand = new SqlCommand(
                    "UPDATE Album " +
                    "SET modificationDate = @modificationDate " +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.Date).Value = DateTime.Now;
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = albumId;

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
                // Close the data reader and the database connection
                oReader.Close();
                oConnection.Close();
            }
        }
#endregion
    }
}
