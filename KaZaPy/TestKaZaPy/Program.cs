using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace TestKaZaPy
{
    class Program
    {
        private static void TestDBAccess()
        {
            Console.WriteLine("--- TEST : DBAccess ---\n");

            DBAccess.ResetTables();

            DBAccess.AddUser("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty");
            DBAccess.AddAlbum("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            DBAccess.AddImage(new byte[512], DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com")));
            DBAccess.AddImage(new byte[1024], DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com")));
            Dictionary<int, byte[]> images = DBAccess.GetImagesByAlbum(DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com")));
            DBAccess.DeleteImage(images.Keys.ElementAt(0));
            DBAccess.DeleteAlbum(DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com")));
            DBAccess.AddAlbum("Party", DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            DBAccess.LogOutUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            DBAccess.LogInUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            DBAccess.DeleteUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));

            Console.WriteLine("--- END OF TEST ---");
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            TestDBAccess();
        }
    }
}
