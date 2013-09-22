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
using Microsoft.Phone.Tasks;

namespace Poche
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            // signaler un bug
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "[BUG][PocheWP]";
            email.To = "thomas.citharet@gmail.com";
            email.Show();
            
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            // twitter
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.twitter.com/tcitworld");
            webBrowserTask.Show();

        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            // infos licence Make Better Sofware
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.tcit.fr/makebettersoftware/");
            webBrowserTask.Show();
        }

        private void HyperlinkButton_Click_2(object sender, RoutedEventArgs e)
        {
            // mail dev
            EmailComposeTask email = new EmailComposeTask();
            email.Subject = "[PocheWP]";
            email.To = "thomas.citharet@gmail.com";
            email.Show();
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            // goto inthepoche.com
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.inthepoche.com");
            webBrowserTask.Show();
        }
    }
}