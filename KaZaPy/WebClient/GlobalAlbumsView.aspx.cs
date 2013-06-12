using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ObjectClass;

namespace WebClient
{
    public partial class GlobalAlbumsView : System.Web.UI.Page
    {
        private void AddAlbumControl(Control form, Album album, User owner)
        {
            Panel globalPanel = new Panel();
            globalPanel.HorizontalAlign = HorizontalAlign.Center;
            globalPanel.BorderStyle = BorderStyle.Solid;

            ImageButton albumButton = new ImageButton();
            albumButton.ID = Convert.ToString(album.Id);
            albumButton.ImageUrl = "~/resources/images/album.jpg";
            albumButton.Click += albumButton_Click;

            Label albumNameLabel = new Label();
            albumNameLabel.Text = "<br />" + album.Name;
            albumNameLabel.Font.Bold = true;
            albumNameLabel.Font.Size = FontUnit.Large;
            albumNameLabel.ForeColor = System.Drawing.Color.Red;

            Label albumOwnerLabel = new Label();
            albumOwnerLabel.Text = "<br />" + owner.FirstName + " " + owner.LastName;
            albumOwnerLabel.Font.Bold = true;

            Label creationDateLabel = new Label();
            creationDateLabel.Text = "<br />Date de création : " + album.CreationDate.Day + "/" + album.CreationDate.Month + "/" + album.CreationDate.Year;
            creationDateLabel.Font.Italic = true;
            creationDateLabel.Font.Size = FontUnit.Small;
            creationDateLabel.ForeColor = System.Drawing.Color.Blue;

            Label modificationDateLabel = new Label();
            modificationDateLabel.Text = "<br />Date de modification : " + album.ModificationDate.Day + "/" + album.ModificationDate.Month + "/" + album.ModificationDate.Year;
            modificationDateLabel.Font.Italic = true;
            modificationDateLabel.Font.Size = FontUnit.Small;
            modificationDateLabel.ForeColor = System.Drawing.Color.Blue;

            globalPanel.Controls.Add(albumButton);
            globalPanel.Controls.Add(albumNameLabel);
            globalPanel.Controls.Add(albumOwnerLabel);
            globalPanel.Controls.Add(creationDateLabel);
            globalPanel.Controls.Add(modificationDateLabel);

            form.Controls.Add(globalPanel);
        }

        void albumButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AlbumView.aspx?AlbumId=" + ((ImageButton)sender).ID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Control form = this.FindControl("GlobalAlbumsView");

            AlbumService.AlbumServiceClient asc = new AlbumService.AlbumServiceClient();
            Album[] albums = asc.GetAllAlbums();

            UserService.UserServiceClient usc = new UserService.UserServiceClient();
            if (albums != null)
            {
                foreach (Album album in albums)
                {
                    User albumOwner = usc.GetUserById(album.Owner);
                    AddAlbumControl(form, album, albumOwner);
                }
            }
            else
            {
                Label noAlbumLabel = new Label();
                noAlbumLabel.Text = "There is no album to display !";
                noAlbumLabel.Font.Size = FontUnit.Large;
                noAlbumLabel.Font.Bold = true;
                noAlbumLabel.ForeColor = System.Drawing.Color.Red;

                form.Controls.Add(noAlbumLabel);
            }
        }
    }
}