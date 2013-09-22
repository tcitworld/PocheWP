using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using Poche.ViewModels;
using System.Xml;
using System.Xml.Linq;

namespace Poche
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// Collection pour les objets ItemViewModel.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Valeur de propriété d'un exemple de runtime";
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Crée et ajoute quelques objets ItemViewModel dans la collection Items.
        /// </summary>
        /// 

       /* public void RefreshData()
        {
            * wget de page principale
             * lister les <div class="entries">
             * pour chaque <div class="entries">, accéder au href du <a> contenu dans le <h2> et au texte du même <a>
             * (éventuellement limite de qq articles pour ne pas trop télécharger)
             * faire un wget sur l'url obtenue dans le href.
             * 
             * Mettre tout cela dans un objet

            // définition de quelques articles :

            Article article11 = new Article();
            article11.Titre = "Mon premier article";
            article11.Url = "Ma première URL";
            article11.Content = "Contenu de mon premier article";
            article11.Id = "0";
            article11.Favorite = true;
            article11.IsRead = true;

            // définition d'une liste d'articles :
            List<Article> articles = new List<Article>();
            articles.Add(article11);
            articles.Add(article12);
            articles.Add(article13);



            /*int nbrearticles = 0;
            string articleURL = "http://";
            List<Article> articles = new List<Article>();
            while (nbrearticles < 3)
            {
                if (articles.Count > 0)
                {
                    foreach (Article article2 in articles)
                    {
                        if (articleURL != article2.Url)
                        {
                            Article article = new Article();
                            article.Titre = "titre";
                            article.Id = nbrearticles.ToString();
                            article.Url = articleURL;
                            article.Content = "Mon contenu";
                            article.LastTimeUpdated = DateTime.Now.ToString();
                            articles.Add(article);
                        }
                    }
                }
                else
                {
                    Article article = new Article();
                    article.Titre = "titre du else";
                    article.Id = nbrearticles.ToString();
                    article.Url = articleURL;
                    article.Content = "Mon contenu";
                    article.LastTimeUpdated = DateTime.Now.ToString();
                    articles.Add(article);
                }
                nbrearticles++;
            }
             */ 
            
            /* à la fin, tout est contenu dans la liste articles
             * On met ensuite cette liste dans l'isolatedstorage
             *
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageSettings.ApplicationSettings["ListeArticles"] = articles;
            IsolatedStorageSettings.ApplicationSettings.Save();
            // détruire la liste pour être propre
            //articles.Clear();

        }
    */
        public void LoadData()
        {

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("data.xml", FileMode.Open, IsolatedStorageFile.GetUserStoreForApplication()))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string xmlfile = reader.ReadToEnd();
                    //MessageBox.Show(xmlfile);

                    XElement xmldata = XElement.Parse(xmlfile);
                    IEnumerable<XElement> elements = xmldata.Elements();
                    foreach (var element in elements)
                    {
                        Article article = new Article();
                        string Titre = element.Element("titre").Value.ToString();
                        string Url = element.Element("URL").Value.ToString();
                        string Content = element.Element("contenu").Value.ToString();
                        string Id = element.Attribute("id").Value.ToString();
                        bool Favorite = XmlConvert.ToBoolean(element.Attribute("favorite").Value.ToString());
                        bool IsRead = XmlConvert.ToBoolean(element.Attribute("read").Value.ToString());
                        string LastTimeUpdated = element.Attribute("date").Value.ToString();
                        this.Items.Add(new ItemViewModel(){Titre=Titre,URL=Url,Contenu=Content, Id=Id, Favorite=Favorite, Read=IsRead, LastTimeUpdated=LastTimeUpdated});
                    }
                }
                }

            /* A partir des données locales stockées dans l'isolated storage
             * tant qu'on a des données, les afficher. Eventuellement limite de 20 articles.
             * for titre sur page principale, prendre le titre, l'URL et puis le contenu à cette URL.
             * 
             * wget de page principale
             * lister les <div class="entries">
             * pour chaque <div class="entries">, accéder au href du <a> contenu dans le <h2> et au texte du même <a>             
             * (éventuellement limite de qq articles pour ne pas trop télécharger)
             * faire un wget sur l'url obtenue dans le href.
             * vérifier que certaines URL ne sont pas déjà dans l'index
             * this.Items.Add(new ItemViewModel() { Titre = "runtime seize", URL = "Nascetur pharetra placerat pulvinar", Contenu = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            */

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}