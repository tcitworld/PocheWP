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
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.Xml;

namespace Poche.ViewModels
{
    public class Settings
    {
        const string filename = "settings.xml";

        public String[] titre { set; get; }

        public Settings()
        {

            titre[0] = "yolo";

        }

        public void Save()
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream stream = storage.CreateFile(filename);
            XmlSerializer xml = new XmlSerializer(GetType());
            xml.Serialize(stream, this);
            stream.Close();
            stream.Dispose();
        }

    }
}
