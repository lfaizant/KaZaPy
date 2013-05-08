using System;
using System.Collections.Generic;
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
            // On récupére la valeur du paramètre ImageID passé dans l’URL 
            int id = int.Parse(Request.QueryString["ImageID"]);
            // Si ce paramètre n'est pas nul 
            /*if (id != null)
            {
                // on récupére notre image là où il faut  

                //TODO
                //Changer de bd à utiliser le web service
                ObjectClass.Image img = (ObjectClass.Image)DataAccess.DBAccess.GetImageById(id, false);
                Byte[] bytes = img.Blob;

                // et on crée le contenu de notre réponse à la requête HTTP  
                // (ici un contenu de type image) 
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            } */

        }
    }
}