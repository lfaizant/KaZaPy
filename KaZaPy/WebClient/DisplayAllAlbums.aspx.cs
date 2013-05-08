using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class DisplayAllAlbums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Charger tous les albums de la base de données via le web service

            for (int i = 0; i <= 3; i++)
            {
                ImageButton nImg = new ImageButton();
                nImg.ID = "ID" + i.ToString();
                nImg.ImageUrl = "~/Images/album.jpg";
                nImg.Click += new ImageClickEventHandler(openAlbum_Click);

                Label lab = new Label();
                lab.Text = nImg.ID;

                Control myControl = this.FindControl("Form1");
                myControl.Controls.Add(nImg);
                myControl.Controls.Add(lab);

            } 

        }

        protected void openAlbum_Click(object sender, ImageClickEventArgs e)
        {
            // Get the album id
            ImageButton imgSender = (ImageButton)sender;
            

            // Open a new page with all the images of the album
            Response.Redirect("DisplayImagesAlbum.aspx?AlbumID=" + imgSender.ID);
        }

    }
}