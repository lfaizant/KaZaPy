using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using ObjectClass;

namespace TestKaZaPy
{
    class Test
    {
        private static void TestDataAccess()
        {
            Console.WriteLine("--- TEST : DBAccess ---\n");

            DBAccess.ResetTables();

            DBAccess.AddUser(new User("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty"));

            DBAccess.AddAlbum(new Album("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            DBAccess.AddAlbum(new Album("Party", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            Album album = DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id);

            DBAccess.AddImage(new Image(new byte[512], album.Id));
            DBAccess.AddImage(new Image(new byte[1024], album.Id));
            List<Image> images = DBAccess.GetImagesByAlbum(album);
            DBAccess.DeleteImage(images.ElementAt(0));

            List<Album> userAlbums = DBAccess.GetAlbumsByUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            List<Album> albums = DBAccess.GetAllAlbums();
            DBAccess.DeleteAlbum(albums.ElementAt(0));

            DBAccess.LogOutUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            DBAccess.LogInUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            DBAccess.DeleteUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));

            Console.WriteLine("--- END OF TEST ---");
            Console.ReadKey();
        }

        private static void TestUserService()
        {
            Console.WriteLine("--- TEST : UserService ---\n");

            DBAccess.ResetTables();

            UserService.UserServiceClient usc = new UserService.UserServiceClient();
            usc.AddUser(new User("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty"));
            usc.LogOutUser(usc.GetUserByEmail("suzy.paeta@gmail.com"));
            usc.LogInUser(usc.GetUserByEmail("suzy.paeta@gmail.com"));
            usc.DeleteUser(usc.GetUserByEmail("suzy.paeta@gmail.com"));
            usc.Close();

            Console.WriteLine("--- END OF TEST ---");
            Console.ReadKey();
        }

        private static void TestAlbumService()
        {
            Console.WriteLine("--- TEST : AlbumService ---\n");

            DBAccess.ResetTables();
            DBAccess.AddUser(new User("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty"));

            AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
            asc.AddAlbum(new Album("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            asc.AddAlbum(new Album("Party", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            asc.AddAlbum(new Album("Street Art", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));

            Album album = asc.GetAlbumById(asc.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id).Id);
            asc.DeleteAlbum(album);
            Album[] userAlbums = asc.GetAlbumsByUser(DBAccess.GetUserByEmail("suzy.paeta@gmail.com"));
            asc.DeleteAlbum(userAlbums[0]);
            Album[] albums = asc.GetAllAlbums();
            asc.DeleteAlbum(albums[0]);

            Console.WriteLine("--- END OF TEST ---");
            Console.ReadKey();
        }

        private static void TestImageService()
        {
            Console.WriteLine("--- TEST : ImageService ---\n");

            DBAccess.ResetTables();

            DBAccess.AddUser(new User("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty"));
            DBAccess.AddAlbum(new Album("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            Album album = DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id);

            MemoryStream imageMemoryStream = new MemoryStream(readImage(@"c:\image.jpg"));
            ImageService.ImageServiceClient isc = new ImageService.ImageServiceClient();
            ImageService.ImageInfo imageInfo = new ImageService.ImageInfo();
            imageInfo.Album = album.Id;
            isc.AddImage(imageInfo, imageMemoryStream);

            Image image = DBAccess.GetImagesByAlbum(album).ElementAt(0);
            imageInfo.Id = image.Id;
            Stream imageStream = isc.GetImage(imageInfo);

            isc.DeleteImage(imageInfo);

            isc.Close();

            Console.WriteLine("--- END OF TEST ---");
            Console.ReadKey();
        }

        private static byte[] readImage(string path)
        {
            byte[] blob = null;
            FileInfo fileInfo = new FileInfo(path);
            int nbBytes = (int)fileInfo.Length;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            blob = br.ReadBytes(nbBytes);
            return blob;
        }

        public static void Main(string[] args)
        {
            // TestDataAccess();
            // TestUserService();
            // TestAlbumService();
            TestImageService();
        }
    }
}
