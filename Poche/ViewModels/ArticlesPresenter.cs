using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Windows.Threading;
using System.IO.IsolatedStorage;



namespace Poche.ViewModels
{
    public class ArticlesPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ListeArticles listeArticles;

        public ArticlesPresenter()
        {
            // ouvrir le fichier de cache
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("data.xml", FileMode.Open, IsolatedStorageFile.GetUserStoreForApplication()))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string xmlfile = reader.ReadToEnd();
                    parseresult(xmlfile);
                }
            }
            /*
             * Uri uri = new Uri(poche);
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += OnDownloadStringCompleted;
            webClient.DownloadStringAsync(uri);
            */

        }

        void parseresult(string xmlfile)
        {
            StringReader reader = new StringReader(xmlfile);
            XmlSerializer xml = new XmlSerializer(typeof(ListeArticles));
            listeArticles = xml.Deserialize(reader) as ListeArticles;

        }

        public ListeArticles listearticles
        {
            protected set
            {
                if (listeArticles != value)
                {

                    listeArticles = value;

                    OnPropertyChanged("ListeArticles");
                }
            }
            get
            {

                return listeArticles;

            }
        }

        protected virtual void OnPropertyChanged(string propChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propChanged));
        }

    }
}
