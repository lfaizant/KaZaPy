﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class DisplayImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Visualiser_Click(object sender, EventArgs e)
        {
            ImageCourante.ImageUrl = "Image.aspx?ImageID=" + ImageIDBox.Text;
        } 

    }
}