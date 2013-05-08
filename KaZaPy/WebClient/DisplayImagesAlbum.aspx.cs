using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectClass;

namespace WebClient
{
    public partial class DisplayImageAlbum : System.Web.UI.Page
    {
        private int idAlbum;

        protected void Page_Load(object sender, EventArgs e)
        {

            idAlbum = int.Parse(Request.QueryString["AlbumID"]);

            // Load all images of the album idAlbum
            AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
            Album album = asc.GetAlbumById(idAlbum);
            List<ObjectClass.Image> images = album.Images;

            foreach (ObjectClass.Image img in images)
            {
                int idImage = img.Id;

                System.Web.UI.WebControls.Image nImg = new System.Web.UI.WebControls.Image();
                nImg.ID = idImage.ToString();
                nImg.ImageUrl = "Image.aspx?ImageID=" + idImage.ToString();
                
                Control myControl = this.FindControl("Form1");
                myControl.Controls.Add(nImg);
            }
            
        }



    }
}