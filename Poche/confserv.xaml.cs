using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Navigation;

namespace Poche
{
    public partial class confserv : PhoneApplicationPage
    {
        public confserv()
        {
            InitializeComponent();
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            //string loginsaved;
            //string passwordsaved;
            string adresssaved;
                //if (settings.TryGetValue<string>("login", out loginsaved))
                   // if (settings.TryGetValue<string>("password", out passwordsaved))
                        if(settings.TryGetValue<string>("Adresse", out adresssaved))
                    {
                        adressePoche.Text = adresssaved;
                        //idPoche.Text = loginsaved;
                        //passPoche.Password = passwordsaved;
                    }
        }

        private void validateAdress_Click(object sender, RoutedEventArgs e)
        {
            // enregistrer l'adresse de Poche
            // enregistrer le login et le mdp
            string adresse = adressePoche.Text;
            //string login = idPoche.Text;
            //string password = passPoche.Password;
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                settings["Adresse"] = adresse;
                //settings["login"] = login;
                //settings["password"] = password;
                settings.Save();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
            

    }
}