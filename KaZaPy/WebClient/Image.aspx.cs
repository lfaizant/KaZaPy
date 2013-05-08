using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
            int id = int.Parse(Request.QueryString["ImageID"]);
            
            if (id != null)
            {
                ImageService.ImageServiceClient isc = new ImageService.ImageServiceClient();
                ImageService.ImageInfo imageInfo = new ImageService.ImageInfo();
                imageInfo.Id = id;
                Stream imageStream = isc.GetImage(imageInfo);



                Byte[] bytes = imageStream.

                // et on crée le contenu de notre réponse à la requête HTTP  
                // (ici un contenu de type image) 
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            } 

        }
    }
}