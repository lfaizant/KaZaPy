using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class DisplayImageAlbum : System.Web.UI.Page
    {
        private int idAlbum;

        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = int.Parse(Request.QueryString["AlbumID"]);
            //Label1.Text = Request.QueryString["AlbumID"];
            idAlbum = int.Parse(Request.QueryString["AlbumID"]);

            //charger toutes les images de l'album id 

            for (int i = 0; i <= 3; i++)
            {
                Image nImg = new Image();
                nImg.ID = "ID" + i.ToString();
               /* ID.ImageUrl = "Image.aspx?ImageID=" + i.ToString;
                nImg.*/
                Control myControl = this.FindControl("Form1");
                myControl.Controls.Add(nImg);
            }

            
        }



    }
}