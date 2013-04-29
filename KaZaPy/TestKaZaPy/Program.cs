using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using WebService;

namespace TestKaZaPy
{
    class Program
    {
        private static void TestDBAccess()
        {
            Console.WriteLine("--- TEST : DBAccess ---\n");

            DBAccess.ResetTables();

            DBAccess.AddUser(new User("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty"));
            DBAccess.AddAlbum(new Album("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            Album album = DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id);
            DBAccess.AddImage(new Image(new byte[512], album.Id));
            DBAccess.AddImage(new Image(new byte[1024], DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id).Id));
            List<Image> images = DBAccess.GetImagesByAlbum(DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            DBAccess.DeleteImage(images.ElementAt(0));
            DBAccess.DeleteAlbum(DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            DBAccess.AddAlbum(new Album("Party", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
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
