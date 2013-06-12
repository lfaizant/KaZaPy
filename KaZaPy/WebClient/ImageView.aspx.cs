using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class ImageView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String imageId = Request.QueryString["ImageId"];

            if (imageId != null)
            {
                ImageService.ImageServiceClient isc = new ImageService.ImageServiceClient();
                ImageService.ImageInfo imageInfo = new ImageService.ImageInfo();
                imageInfo.Id = Convert.ToInt32(imageId);
                MemoryStream imageStream = new MemoryStream();
                Stream s = isc.GetImage(ref imageInfo);
                s.CopyTo(imageStream);

                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(imageStream.ToArray());
                Response.Flush();
                Response.End();
            }
        }
    }
}