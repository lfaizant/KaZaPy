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
            Label1.Text = "Mon album";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Ouvrir l'album
            Label1.Text = "clique sur album";
        }

    }
}