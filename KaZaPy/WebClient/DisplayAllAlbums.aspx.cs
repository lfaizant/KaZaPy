using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectClass;

namespace WebClient
{
    public partial class DisplayAllAlbums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myControl = this.FindControl("Form1");

            //Load all albums from the data base through the web servcie
            AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
            ObjectClass.Album[] albums = asc.GetAllAlbums();

            if (albums != null)
            {
                foreach (Album a in albums)
                {
                    int idAlbum = a.Id;

                    ImageButton nImg = new ImageButton();
                    nImg.ID = idAlbum.ToString();
                    nImg.ImageUrl = "~/Images/album.jpg";
                    nImg.Click += new ImageClickEventHandler(openAlbum_Click);

                    Label lab = new Label();
                    lab.Text = a.Name;

                    myControl.Controls.Add(nImg);
                    myControl.Controls.Add(lab);

                }
            }
            else
            {
                Label lab = new Label();
                lab.Text = "0 album to display";
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