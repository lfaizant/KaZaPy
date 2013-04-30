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

        private static void TestProcessingService()
        {
            DBAccess.ResetTables();

            DBAccess.AddUser(new User("Suzy", "Paeta", "suzy.paeta@gmail.com", "azerty"));
            DBAccess.AddAlbum(new Album("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id));
            Album album = DBAccess.GetAlbumByNameAndOwner("Holidays", DBAccess.GetUserByEmail("suzy.paeta@gmail.com").Id);

            MemoryStream imageMemoryStream = new MemoryStream(readImage(@"c:\image.jpg"));
            ProcessingService.ProcessingServiceClient psc = new ProcessingService.ProcessingServiceClient();
            ProcessingService.ImageInfo imageInfo = new ProcessingService.ImageInfo();
            imageInfo.Album = album.Id;
            psc.Upload(imageInfo, imageMemoryStream);

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
            // TestDBAccess();
            TestProcessingService();
        }
    }
}
