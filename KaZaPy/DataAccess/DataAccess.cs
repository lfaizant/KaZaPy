using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string getUserId(string email)
        {
            string userId = null;

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

                // Get the return user ID
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
        /// <param name="password">user's password</param>
        /// <param name="privilege">admin privilege</param>
        /// <param name="logged">user's log state</param>
        public static void addUser(string firstName, string lastName, string password, bool privilege = false, bool logged = true)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition command
                SqlCommand oCommand = new SqlCommand(
                "INSERT INTO User" +
                "VALUES(NEWID(), @firstName, @lastName, @password, @privilege, @logged);", oConnection);
                oCommand.Parameters.Add("@firstName", System.Data.SqlDbType.NVarChar, firstName.Length).Value = firstName;
                oCommand.Parameters.Add("@lastName", System.Data.SqlDbType.NVarChar, lastName.Length).Value = lastName;
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
        public static void deleteUser(string userId)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the deletion command
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM User" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier, userId.Length).Value = userId;

                // Execute the deletion command
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
        /// Store a new album in the database
        /// </summary>
        /// <param name="name">name of the album</param>
        /// <param name="owner">owner of the album</param>
        public static void addAlbum(string name, string owner)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the addition command
                SqlCommand oCommand = new SqlCommand(
                    "INSERT INTO Album" +
                    "VALUES(NEWID(), @name, @owner);", oConnection);
                oCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, name.Length).Value = name;
                oCommand.Parameters.Add("@owner", System.Data.SqlDbType.UniqueIdentifier, owner.Length).Value = owner;

                // Execute the addtion command
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
        public static void deleteAlbum(string albumId)
        {
            try
            {
                // Connect to the database
                oConnection.Open();

                // Initialize the deletion command
                SqlCommand oCommand = new SqlCommand(
                    "DELETE FROM Album" +
                    "WHERE id = @id;", oConnection);
                oCommand.Parameters.Add("@id", System.Data.SqlDbType.UniqueIdentifier, albumId.Length).Value = albumId;

                // Execute the addtion command
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
        /// Store a new image in the database
        /// </summary>
        /// <param name="image">image to store</param>
        /// <param name="album">album of the image</param>
        public static void addImage(byte[] image, string album)
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
        public static void deleteImage(string imageId)
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
