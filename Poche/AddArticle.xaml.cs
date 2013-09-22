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
using System.Text;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;

namespace Poche.Properties
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        { 
            string URL = URLInput.Text;
            if (validateURL(URL))
            {
                if (sendURL(URL))
                {
                    // tester si ok 
                }
            }
        }

        private string getPocheServerURL()
        {
            try
            {
                string baseurl;
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                settings.TryGetValue<string>("Adresse", out baseurl);
                return baseurl;
            }
            catch
            {
                return "";
            }
        }
        private bool sendURL(string URL)
        {
            //throw new NotImplementedException();
            // convert url string en bytes puis en base64
            byte[] urlbytes = Encoding.UTF8.GetBytes(URL);
            string base64 = Convert.ToBase64String(urlbytes);
            //Status.Text = base64;

            if (getPocheServerURL() == "")
            {
                MessageBox.Show("Vous n'avez pas entré l'adresse de votre serveur Poche ! ");
                NavigationService.Navigate(new Uri("/confserv.xaml", UriKind.Relative));
            }
            else
            {
                string fullurl = getPocheServerURL() + "?action=add&url=" + base64;
                //MessageBox.Show(fullurl);
                Uri base64url = new Uri(fullurl);



                WebBrowserTask webbrowser = new WebBrowserTask();
                webbrowser.Uri = base64url;
                webbrowser.Show();
            
            //webBrowserControl.Navigate(base64url);

            }
            // GET monserveurpoche/?url=urlenbase64
            return true;

        }
        
        private bool validateURL(string URL)
        {
            //throw new NotImplementedException();
            // si bonne url : http:// ; .ext
            if (URL.Contains("http://"))
            {
                //MessageBox.Show("URL Validée");

                return true;
            }
            else
            {
                MessageBox.Show("URL non valide");
                return false;
            }

        }

        public string URL { get; set; }

        public string result { get; set; }
    }
}