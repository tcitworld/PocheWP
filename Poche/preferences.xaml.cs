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

namespace Poche
{
    public partial class preferences : PhoneApplicationPage
    {
        public preferences()
        {
            InitializeComponent();

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string nbrelimitesaved;
            if (settings.TryGetValue<string>("nombreArticlesLimite", out nbrelimitesaved) && nbrelimitesaved!= null)
            {
                nbrelimite.IsEnabled = true;
                limitearticle.IsChecked = true;
                nbrelimite.Text = nbrelimitesaved;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            nbrelimite.IsEnabled = true;
        }

        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            nbrelimite.IsEnabled = false;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // enregistrer
            if ((bool)limitearticle.IsChecked && nbrelimite.Text != null)
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                settings["nombreArticlesLimite"] = nbrelimite.Text;
                settings.Save();
                // enregistrer ce paramètre
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else
            {//suite
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                settings["nombreArticlesLimite"] = null;
                settings.Save();
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}