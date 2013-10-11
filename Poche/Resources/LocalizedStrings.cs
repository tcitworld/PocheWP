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
using Poche.Resources;

namespace Poche
{
    public class LocalizedStrings
    {
        public LocalizedStrings()
        {
        }

        private static Poche.Resources.AppResources localizedResources = new Poche.Resources.AppResources();

        public Poche.Resources.AppResources LocalizedResources { get { return localizedResources; } }
    }
}