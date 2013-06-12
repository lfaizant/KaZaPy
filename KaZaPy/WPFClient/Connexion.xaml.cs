using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFClient
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        private string email;
        private string password;

        public Connexion()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, MouseButtonEventArgs e)
        {
            email = emailBox.Text;
            password = passwordBox.Password;
            this.Close();
        }

        public String getEmail() { return email; }
        public String getPassword() { return password; }


    }
}
