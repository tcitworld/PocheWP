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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Poche.ViewModels
{
    public class ListeArticles : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Article> articles = new ObservableCollection<Article>();

        string poche;
        public string Poche
        {
            set
            {
                if (poche != value)
                {
                    poche = value;
                    OnPropertyChanged("Poche");
                }
            }
            get
            {
                return poche;
            }
        }

        public ObservableCollection<Article> Articles
        {

            set
            {

                if (articles != value)
                {

                    articles = value;
                    OnPropertyChanged("Articles");
                }

            }

            get
            {

                return articles;

            }

        }

        protected virtual void OnPropertyChanged(string propChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propChanged));
        }

    }
}
