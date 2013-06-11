using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Drawing;
using System.Collections.ObjectModel;
using ObjectClass;

namespace WPFClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private string openFileName;

        private ImageCollection imageCollection1;
        private ImageCollection imageCollection2;
        private WPFClient.AlbumObject.AlbumCollection albumCollection;
        ListBox dragSource = null; 

        public MainWindow()
        {
            InitializeComponent();
            imageCollection1 = new ImageCollection();
            imageCollection2 = new ImageCollection();
            albumCollection = new AlbumObject.AlbumCollection();

            DisplayAllAlbumUser();

            ObjectDataProvider imageSource2 = (ObjectDataProvider)FindResource("ImageCollection2");
            imageSource2.ObjectInstance = imageCollection2; 
        }

        // On initie le Drag and Drop 
        private void ImageDragEvent(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));
            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        // On ajoute l'objet dans la nouvelle ListBox et on le supprime de l'ancienne 
        private void ImageDropEvent(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            ImageObject data = (ImageObject)e.Data.GetData(typeof(ImageObject));
            ((IList)dragSource.ItemsSource).Remove(data);
            ((IList)parent.ItemsSource).Add(data);
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
            Console.WriteLine("Clique");
           
            ListBoxItem parent = (ListBoxItem)sender;
            AlbumObject ao = (AlbumObject)parent.Content;
            DisplayAlbumId(ao.ID);
        }

        private void LoadLocalImages(object sender, MouseButtonEventArgs e)
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                openFileName = folderBrowserDialog1.SelectedPath;
            }

            DisplayLocalFolder(openFileName);
        }

        private void DisplayAllAlbumUser()
        {
            // Get user id

            // Get album from the user
            // List<Album> listAl = DBAccess.GetAlbumsByUser(    );            
            List<Album> listAl = DBAccess.GetAllAlbums();
            foreach (Album a in listAl)
            {
                albumCollection.Add(new AlbumObject(a.Id, a.Name, null));
            }

            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML 
            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = albumCollection;

        }

        private void DisplayAlbumId(int id)
        {
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
            FileStream fileStream = new FileStream(path, FileMode.Open,
            FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            data = br.ReadBytes(nbBytes);
            return data;
        }
        
    }
}
