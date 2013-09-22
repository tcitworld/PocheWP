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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;
using Poche.ViewModels;
using Microsoft.Phone.Shell;

namespace Poche
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public int index;
        public List<Article> articles;
        public Article article;
        // Constructeur
        public DetailsPage()
        {
            InitializeComponent();
            // aller chercher le contenu ?
        }

        // Lors de l'accès à la page, affectez l'élément sélectionné dans la liste au contexte de données
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
           // articles = (List<Article>)PhoneApplicationService.Current.State["Articles"];

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            // Rafraîchir l'article
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            // Ajouter aux articles favoris
            //MessageBox.Show(index.ToString());

            /*article = articles.ElementAt(index);
            if (article.Favorite)
            {
                MessageBox.Show(" Déjà Favori !");
            }
            else
            { article.Favorite = true; }
            PhoneApplicationService.Current.State["Articles"] = articles;
            IsolatedStorageSettings.ApplicationSettings["ListeArticles"] = articles;
            IsolatedStorageSettings.ApplicationSettings.Save();
         */   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ouvre IE
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.google.fr");
            webBrowserTask.Show();

        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            // supprimer article
            if (MessageBox.Show("Voulez-vous vraiment supprimer l'article ?", "Suppression de l'article", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                // supprimer
                //back to home
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                // do nothing
            }

        }
    }
}