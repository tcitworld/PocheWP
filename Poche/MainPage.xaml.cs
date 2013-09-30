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
using Poche.ViewModels;
using System.Diagnostics;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using Mangopollo.Tiles;


namespace Poche
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur

        public MainPage()
        {
            InitializeComponent();
            // Affecter l'exemple de données au contexte de données du contrôle ListBox
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            // créer le fichier


            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("data.xml", FileMode.Create, IsolatedStorageFile.GetUserStoreForApplication()))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?><elements><element id=\"0_\" favorite=\"0\" read=\"1\" date=\"12/08/2013\"><titre>Mon premier élément</titre><URL>http://premièreURL.fr</URL><contenu>Mon super long contenu.</contenu></element><element id=\"1\" favorite=\"1\" read=\"0\" date=\"12/08/2013\"><titre>Mon deuxième élément</titre><URL>http://deuxièmeURL.fr</URL><contenu>Mon super long contenu.</contenu></element><element id=\"2\" favorite=\"1\" read=\"1\" date=\"12/08/2013\"><titre>Mon troisième élément</titre><URL>http://troisièmeURL.fr</URL><contenu>Mon super long contenu.</contenu></element></elements>");
                }
            }


      // là faudrait faire le wget depuis le serveur
            // puis parsing, puis enregistrement dans le fichier xml

        }

        // Gérer la sélection modifiée sur ListBox
        /*private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Si l'index sélectionné a la valeur -1 (pas de sélection), ne rien faire
            if (MainListBox.SelectedIndex == -1)
                return;

            // Naviguer vers la nouvelle page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));

            // Réinitialiser l'index sélectionné sur -1 (pas de sélection)
            MainListBox.SelectedIndex = -1;
        }
        */
        // Charger les données pour les éléments ViewModel
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("firsttime"))
            {
                settings["firsttime"] = false;
                NavigationService.Navigate(new Uri("/confserv.xaml", UriKind.Relative));
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            addNewArticle();
        }

        private void addNewArticle()
        {
            //throw new NotImplementedException();
            NavigationService.Navigate(new Uri("/AddArticle.xaml", UriKind.Relative));

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {
            //throw new NotImplementedException();
            //App.ViewModel.RefreshData();

        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            // goto préférences
            NavigationService.Navigate(new Uri("/preferences.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            // goto conf serveur
            NavigationService.Navigate(new Uri("/confserv.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            // goto à propos
            NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

        public void updateTitle() { 
        FlipTileData TileData = new FlipTileData()
            {
            Title = "Poche",
            BackTitle = "[titre de la tuile arrière]",
            BackContent = "[contenu de la tuile arrière]",
            WideBackContent = "[contenu de la tuile arrière en affichage large]",
            Count = 2,
            SmallBackgroundImage = new Uri("/Images/tiles/poche159.png", UriKind.Relative),
            BackgroundImage = new Uri("/Images/tiles/poche336.png", UriKind.RelativeOrAbsolute),
            BackBackgroundImage = new Uri("/Images/tiles//poche336_2.png", UriKind.Relative),
            WideBackgroundImage = new Uri("/Images/tiles/poche 691×336.png", UriKind.RelativeOrAbsolute),
            WideBackBackgroundImage = new Uri("/Images/tiles/poche 691×336_2.png", UriKind.Relative)
            };
        }
    }
}