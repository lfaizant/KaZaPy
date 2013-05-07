﻿using System;
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

namespace WPFClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageCollection imageCollection1;
        private ImageCollection imageCollection2;
        ListBox dragSource = null; 

        public MainWindow()
        {
            InitializeComponent();

            // On crée notre collection d'image et on y ajoute deux images 
            imageCollection1 = new ImageCollection();
            imageCollection1.Add(new ImageObject("voyage1", readImage("C:/Users/user/Desktop/voyage1.jpg")));
            imageCollection1.Add(new ImageObject("voyage2", readImage("C:/Users/user/Desktop/voyage2.jpg")));

            imageCollection2 = new ImageCollection();
            imageCollection2.Add(new ImageObject("voyage3", readImage("C:/Users/user/Desktop/voyage3.jpg")));

            // On lie la collectionau ObjectDataProvider déclaré dans le fichier XAML 
            ObjectDataProvider imageSource = (ObjectDataProvider)FindResource("ImageCollection1");
            imageSource.ObjectInstance = imageCollection1;

            ObjectDataProvider imageSource2 = (ObjectDataProvider)FindResource("ImageCollection2");
            imageSource2.ObjectInstance = imageCollection2; 
        }

        //A supprimer après ajout
        private byte[] readImage(string path)
        {
            byte[] blob = null;
            FileInfo fileInfo = new FileInfo(path);
            int nbBytes = (int)fileInfo.Length;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fileStream);
            blob = br.ReadBytes(nbBytes);
            return blob;
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
    }
}
