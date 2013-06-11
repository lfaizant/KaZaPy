using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; 

namespace WPFClient
{
    //Permet de contenir une image
    public class ImageObject
    {
        public int Id { get; set; }
        public String Nom { get; set; } 
        public byte[] Image { get; set; } 
 
        public ImageObject(String Nom, int Id,  byte[] Image) 
        { 
            this.Nom = Nom; 
            this.Image = Image;
            this.Id = Id;
        } 
    }

    //Permet de contenir une collection d'image
    public class ImageCollection : ObservableCollection<ImageObject>
    { 
    }
}
