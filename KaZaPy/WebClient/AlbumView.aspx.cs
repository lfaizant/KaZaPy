using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectClass;

namespace WebClient
{
    public partial class AlbumView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control form = this.FindControl("AlbumView");

            String albumId = Request.QueryString["AlbumId"];
            if (albumId != null)
            {
                AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
                Album album = asc.GetAlbumById(Convert.ToInt32(albumId));

                foreach (ObjectClass.Image image in album.Images)
                {
                    System.Web.UI.WebControls.Image imageControl = new System.Web.UI.WebControls.Image();
                    imageControl.ImageUrl = "ImageView.aspx?ImageId=" + image.Id;

                    form.Controls.Add(imageControl);
                }
            }
        }
    }
}