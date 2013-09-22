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
using System.ComponentModel;

namespace Poche.ViewModels
{
    public class Article : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string titre;
        string url;
        string content;
        string lastTimeUpdated;
        string id;
        bool favorite;
        bool isread;

        public string Titre
        {
            set
            {
                if (titre != value)
                {
                    titre = value;
                }
            }
            get
            {
                return titre;
            }
        }
        public string Url
        {
            set
            {
                if (url != value)
                {
                    url = value;
                }
            }
            get
            {
                return url;
            }
        }
        public string Id
        { 
            set
            {
                if (id != value)
                {
                    id = value;
                }
            }
            get
            {
                return id;
            }
        }
        public string Content
        {
            set
            {
                if (content != value)
                {
                    content = value;
                }
            }
            get
            {
                return content;
            }
        }
        public string LastTimeUpdated
        {
            set
            {
                if (lastTimeUpdated != value)
                {
                    lastTimeUpdated = value;
                }
            }
            get
            {
                return lastTimeUpdated;
            }
        }
        public bool Favorite
        {
            set
            {
                if (favorite != value)
                {
                    favorite = value;
                }
            }
            get
            {
                return favorite;
            }
        }
        public bool IsRead
        {
            set
            {
                if (isread != value)
                {
                    isread = value;
                }
            }
            get
            {
                return isread;
            }
        }

        /* Useless ?
         * 
         * public void setFavorite()
        {
            if(favorite != true)
        {
            favorite=true;
        }
        }
        public void setUnFavorite()
        {
            if (favorite == true)
            {
                favorite = false;
            }
        }
        public void markRead()
        {
            if (!IsRead)
            {
                isread = true;
            }
        }
        public void markUnRead()
        {
            if (IsRead == true)
            {
                isread = false;
            }
        }

        public Article()
        {
            favorite = false;
            isread = false;
            lastTimeUpdated = DateTime.Now.ToString();
        }
         */

        protected virtual void OnPropertyChanged(string propChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propChanged));
        }

    }
}
