using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WPFClient
{
    public class AlbumObject
    {
        public int ID { get; set; }
        public String Nom { get; set; }
        public byte[] Image { get; set; }
        public AlbumObject(int ID, String Nom, byte[] Image)
        {
            this.Nom = Nom;
            this.Image = Image;
            this.ID = ID;
        }
        
        public class AlbumCollection : ObservableCollection<AlbumObject>
        { }
    }
}
