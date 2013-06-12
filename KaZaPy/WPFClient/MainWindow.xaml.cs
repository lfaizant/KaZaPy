using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using ObjectClass;

namespace WPFClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private string openFolderName;

        private ImageCollection imageCollection1;
        private ImageCollection imageCollection2;
        private WPFClient.AlbumObject.AlbumCollection albumCollection;
        ListBox dragSource = null;

        private int currentAlbumId;
        private string albumName;

        private bool displayAlbum = false;

        private string emailConnexion;
        private string passwordConnexion;
        private User u;

        public MainWindow()
        {
            InitializeComponent();

            connexion();

            imageCollection1 = new ImageCollection();
            imageCollection2 = new ImageCollection();
            albumCollection = new AlbumObject.AlbumCollection();

            DisplayAllAlbumUser();
        }

        private void connexion()
        {
            Connexion c = new Connexion();
            c.ShowDialog();
            emailConnexion = c.getEmail();
            passwordConnexion = c.getPassword();

            u = DBAccess.GetUserByEmail(emailConnexion);
            if(u.Password.Equals(passwordConnexion, System.StringComparison.Ordinal))
            {
                DBAccess.LogInUser(u);
              //  connexion();
            }

        }

        Point startpoint;
        private void StartDrag(object sender, MouseButtonEventArgs e)
        {
            startpoint = e.GetPosition(null);
        }

        private void ImageDragEvent(object sender, MouseEventArgs e)
        {
            if (!displayAlbum)
            {
                Point mousePos = e.GetPosition(null);
                Vector diff = startpoint - mousePos;

                if (e.LeftButton == MouseButtonState.Pressed &&
                    (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    ListBox parent = (ListBox)sender;
                    dragSource = parent;
                    object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
                    if (data != null)
                    {
                        DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
                    }
                }
            }
        }

        // On ajoute l'objet dans la nouvelle ListBox et on le supprime de l'ancienne 
        private void ImageDropEvent(object sender, DragEventArgs e)
        {
            if (!displayAlbum)
            {
                ListBox parent = (ListBox)sender;
                ImageObject data = (ImageObject)e.Data.GetData(typeof(ImageObject));
                ((IList)dragSource.ItemsSource).Remove(data);
                ((IList)parent.ItemsSource).Add(data);
            }
        }

        // On récupére l'objet que que l'on a dropé 
        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = (UIElement)source.InputHitTest(point);
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = (UIElement)VisualTreeHelper.GetParent(element);
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }

        private void OpenAlbum(object sender, MouseButtonEventArgs e)
        {
            if (displayAlbum)
            {
                ListBoxItem parent = (ListBoxItem)sender;
                AlbumObject ao = (AlbumObject)parent.Content;
                currentAlbumId = ao.ID;
                DisplayAlbumId(ao.ID);
                displayAlbum = false;
                ButtonCreateAlbum.Visibility = Visibility.Hidden;
                TextBoxAlbum.Visibility = Visibility.Hidden;
                Back.Visibility = Visibility.Visible;
            }

        }

        private void LoadLocalImages(object sender, MouseButtonEventArgs e)
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                openFolderName = folderBrowserDialog1.SelectedPath;
            }

            DisplayLocalFolder(openFolderName);
        }

        private void DisplayAllAlbumUser()
        {
            albumCollection = new AlbumObject.AlbumCollection();
            // Get user id

            // Get album from the user           
            //AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
            //Album[] listAl = asc.GetAllAlbums();
            List<Album> listAl = DBAccess.GetAlbumsByUser(u);
            foreach (Album a in listAl)
            {
                albumCollection.Add(new AlbumObject(a.Id, a.Name, null));
            }

            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML 
            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = albumCollection;

            displayAlbum = true;
            ButtonCreateAlbum.Visibility = Visibility.Visible;
            TextBoxAlbum.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Hidden;
        }

        private void DisplayAlbumId(int id)
        {
            imageCollection1 = new ImageCollection();

            /*AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
            Album a = asc.GetAlbumById(id);*/
            Album a = DBAccess.GetAlbumById(id);
            List<ObjectClass.Image> lia = a.Images;

            foreach(ObjectClass.Image img in lia)
            {
                imageCollection1.Add(new ImageObject(img.Id.ToString(), img.Id, img.Blob));
            }

            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = imageCollection1;
        }

        private void DisplayLocalFolder(string path)
        {
            imageCollection2 = new ImageCollection();
            string jpg = ".jpg";
            string[] FilesList = System.IO.Directory.GetFiles(path);   
            for (int i = 0; i < FilesList.Length; i++)
            {
                if(jpg.Equals(System.IO.Path.GetExtension(FilesList[i]), System.StringComparison.OrdinalIgnoreCase))
                {
                    imageCollection2.Add(new ImageObject(System.IO.Path.GetFileName(FilesList[i]), -1, readFile(FilesList[i])));
                }
            }

            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ImageCollection2");
            imageSource.ObjectInstance = imageCollection2;
        }

        private static byte[] readFile(string path)
        {
            byte[] data = null;
            FileInfo fileInfo = new FileInfo(path);
            int nbBytes = (int)fileInfo.Length;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            data = br.ReadBytes(nbBytes);
            return data;
        }

        private void uploadImage(int IdAlbum, byte[] image)
        {
            DBAccess.AddImage(new ObjectClass.Image(image, IdAlbum));
           /* MemoryStream imageMemoryStream = new MemoryStream(image);
            ImageService.ImageServiceClient isc = new ImageService.ImageServiceClient();
            ImageService.ImageInfo imageInfo = new ImageService.ImageInfo();
            imageInfo.Album = IdAlbum;
            isc.AddImage(imageInfo, imageMemoryStream);*/
        }

        private void ImageUploadEvent(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            ImageObject data = (ImageObject)e.Data.GetData(typeof(ImageObject));
            uploadImage(currentAlbumId, data.Image);
            DisplayAlbumId(currentAlbumId);
        }

        private void ImageDownloadEvent(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            if (e.Data.GetData(typeof(ImageObject)) != null)
            {
                ImageObject data = (ImageObject)e.Data.GetData(typeof(ImageObject));

                if (data.Nom != null)
                {
                    string newpath = System.IO.Path.Combine(openFolderName, data.Nom);
                    newpath += ".jpg";

                    try
                    {
                        using (FileStream fs = new FileStream(newpath, FileMode.Create))
                        {
                            fs.Write(data.Image, 0, data.Image.Length);
                        }
                        DisplayLocalFolder(openFolderName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Image already existing");
                    }
                }
            }
        }

        private void DeleteAlbum(object sender, KeyEventArgs k)
        {
            if (Key.Delete == k.Key)
            {
                Console.WriteLine("delete");
                ListBoxItem parent = (ListBoxItem)sender;
                AlbumObject ao = (AlbumObject)parent.Content;
                DBAccess.DeleteAlbum(DBAccess.GetAlbumById(ao.ID));
                DisplayAllAlbumUser();
            }
        }

        private void CreateAlbum(object sender, MouseButtonEventArgs e)
        {
            DBAccess.AddAlbum(new Album(albumName, u.Id));
            DisplayAllAlbumUser();
        }

        private void BackEvent(object sender, MouseButtonEventArgs e)
        {
            DisplayAllAlbumUser();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox parent = (TextBox)sender;
            albumName = parent.Text;
        }

        private void Logout(object sender, MouseButtonEventArgs e)
        {
            DBAccess.LogOutUser(u);
            this.Close();
        }

       
    }
}
