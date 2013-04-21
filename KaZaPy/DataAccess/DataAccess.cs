using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        // Initialize the connection to the database
        private const string connectionStr = "Server=LOÏC-PC;Database=TestDB;Integrated Security=true;";
        private static SqlConnection oConnection = new SqlConnection(connectionStr);

#region User
        /// <summary>
        /// Get an user ID by its email
        /// </summary>
        /// <param name="email">user's email</param>
        /// <returns>user's ID</returns>
        public static string GetUserId(string email)
        {
            string userId = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id" +
                    "FROM User" +
                    "WHERE email = @email;", oConnection);
                oCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, email.Length).Value = email;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user ID
                if (oReader.Read())
                    userId = oReader.GetString(0);
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
                "INSERT INTO User" +
                "VALUES(NEWID(), @firstName, @lastName, @email, @password, @privilege, @logged);", oConnection);
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
        public static void DeleteUser(string userId)
        {
            // Initialize data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize query for the getting of user's albums ID
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id" +
                    "FROM Album" +
                    "WHERE owner = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.UniqueIdentifier, userId.Length).Value = userId;

                // Execute the getting query
                oReader = oCommand.ExecuteReader();

                // Get user's albums ID
                List<string> albumsId = new List<string>();
                while(oReader.Read())
                    albumsId.Add(oReader.GetString(0));

                // Browse returned albums ID
                foreach (string s in albumsId)
                    // Delete current album
                    DeleteAlbum(s);

                // Initialize the deletion query
                oCommand = null;
                oCommand = new SqlCommand(
                    "DELETE FROM User" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier, userId.Length).Value = userId;

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
        public static void LogInUser(string userId)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "UPDATE User" +
                    "SET logged = 1" +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.UniqueIdentifier, userId.Length).Value = userId;

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
        public static void LogOutUser(string userId)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "UPDATE User" +
                    "SET logged = 0" +
                    "WHERE id = @userId;", oConnection);
                oCommand.Parameters.Add("@userId", System.Data.SqlDbType.UniqueIdentifier, userId.Length).Value = userId;

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
        public static string GetAlbumId(string name, string owner)
        {
            string albumId = null;

            // Initialize a data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the getting command
                SqlCommand oCommand = new SqlCommand(
                    "SELECT id" +
                    "FROM Album" +
                    "WHERE name = @name AND owner = @owner;", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, name.Length).Value = name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.UniqueIdentifier, owner.Length).Value = owner;

                // Execute the getting commande
                oReader = oCommand.ExecuteReader();

                // Get the returned user ID
                if (oReader.Read())
                    albumId = oReader.GetString(0);
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
        public static void AddAlbum(string name, string owner)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition query
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Album" +
                    "VALUES(NEWID(), @name, @owner);", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, name.Length).Value = name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.UniqueIdentifier, owner.Length).Value = owner;

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
        public static void DeleteAlbum(string albumId)
        {
            try
            {
                // Connect to the database
                if(oConnection.State == System.Data.ConnectionState.Closed)
                    oConnection.Open();

                // Initialize query for the deletion of images of the album
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM Image" +
                    "WHERE album = @albumId;", oConnection);
                oCommand.Parameters.Add("@albumId", System.Data.SqlDbType.UniqueIdentifier, albumId.Length).Value = albumId;

                // Execute the deletion query
                oCommand.ExecuteNonQuery();

                // Initialize the deletion query
                oCommand = new SqlCommand(
                    "DELETE FROM Album" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier, albumId.Length).Value = albumId;

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
        public List<byte[]> GetImagesByAlbum(string albumId)
        {
            List<byte[]> images = new List<byte[]>();

            // Initialize data reader
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the getting query
                SqlCommand oCommand = new SqlCommand(
                    "SELECT size, blob" +
                    "FROM Image" +
                    "WHERE album = @albumId;", oConnection);
                oCommand.Parameters.Add("@albumID", System.Data.SqlDbType.UniqueIdentifier, albumId.Length).Value = albumId;

                // Execute the getting query
                oReader = oCommand.ExecuteReader();

                // Browse returned images
                while (oReader.Read())
                {
                    // Get the size of the current image
                    int size = oReader.GetInt32(0);
                    // Get the blob of the current image
                    byte[] blob = new byte[size];
                    oReader.GetBytes(1, 0, blob, 0, size);
                    // Add the current blob to the list
                    images.Add(blob);
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
        public static void AddImage(byte[] image, string album)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addtion query
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Image" +
                    "VALUES(NEWID(), @size, @blob, @album)", oConnection);
                oCommand.Parameters.Add("@size", System.Data.SqlDbType.Int).Value = image.Length;
                oCommand.Parameters.Add("@blob", System.Data.SqlDbType.Image, image.Length).Value = image;
                oCommand.Parameters.Add("@album", System.Data.SqlDbType.UniqueIdentifier, album.Length).Value = album;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();

                // Initialize query for update the album
                oCommand = null;
                oCommand = new SqlCommand(
                    "UPDATE Album" +
                    "SET modificationDate = @modificationDate" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.Date).Value = DateTime.Now;
                oCommand.Parameters.Add("@album", System.Data.SqlDbType.UniqueIdentifier, album.Length).Value = album;

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
        public static void DeleteImage(string imageId)
        {
            SqlDataReader oReader = null;
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize getting query for the ID of the album to update
                SqlCommand oCommand = new SqlCommand(
                    "SELECT album" +
                    "FROM Image" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier).Value = imageId;

                // Execute the getting command
                oReader = oCommand.ExecuteReader();

                // Get the album ID
                string albumId = null;
                if (oReader.Read())
                    albumId = oReader.GetString(0);

                // Initialize the deletion query
                oCommand = null;
                oCommand = new SqlCommand(
                    "DELETE FROM Image" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier).Value = imageId;

                // Execute the addtion query
                oCommand.ExecuteNonQuery();
                

                // Initialize query for the update of the modification date of the album
                oCommand = null;
                oCommand = new SqlCommand(
                    "UPDATE Album" +
                    "SET modificationDate = @modificationDate" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@modificationDate", System.Data.SqlDbType.Date).Value = DateTime.Now;
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier, albumId.Length).Value = albumId;

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
#endregion
    }
}
