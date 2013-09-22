using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Poche
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _Titre;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public string Titre
        {
            get
            {
                return _Titre;
            }
            set
            {
                if (value != _Titre)
                {
                    _Titre = value;
                    NotifyPropertyChanged("Titre");
                }
            }
        }

        private string _URL;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public string URL
        {
            get
            {
                return _URL;
            }
            set
            {
                if (value != _URL)
                {
                    _URL = value;
                    NotifyPropertyChanged("URL");
                }
            }
        }

        private string _Id;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (value != _Id)
                {
                    _Id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private string _Contenu;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public string Contenu
        {
            get
            {
                return _Contenu;
            }
            set
            {
                if (value != _Contenu)
                {
                    _Contenu = value;
                    NotifyPropertyChanged("Contenu");
                }
            }
        }

        private string _LastTimeUpdated;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public string LastTimeUpdated
        {
            get
            {
                return _LastTimeUpdated;
            }
            set
            {
                if (value != _LastTimeUpdated)
                {
                    _LastTimeUpdated = value;
                    NotifyPropertyChanged("LastTimeUpdated");
                }
            }
        }

        private bool _Favorite;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public bool Favorite
        {
            get
            {
                return _Favorite;
            }
            set
            {
                if (value != _Favorite)
                {
                    _Favorite = value;
                    NotifyPropertyChanged("Favorite");
                }
            }
        }

        private bool _Read;
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        /// <returns></returns>
        public bool Read
        {
            get
            {
                return _Read;
            }
            set
            {
                if (value != _Read)
                {
                    _Read = value;
                    NotifyPropertyChanged("Read");
                }
            }
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