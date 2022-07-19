using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для PopularCurrentyView.xaml
    /// </summary>
    
    public partial class PopularCurrentyView : UserControl
    {
        public static string GetContenidoWeb(string url)
        {

            if (!url.Contains("http://api.coincap.io/v2/assets") || !url.Contains("https://"))
            {
                url = "http://api.coincap.io/v2/assets";
            }

            Uri uri = new Uri(url);
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(uri);
            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();

            System.IO.StreamReader input = new System.IO.StreamReader(res.GetResponseStream());

            char[] chrBuff = new char[256];
            int intLen = 0;
            string strSource = "";

            do
            {
                intLen = input.Read(chrBuff, 0, 256);
                string strBuff = new string(chrBuff, 0, intLen);
                strSource += strBuff;
            } while (intLen > 0);

            return strSource;

        }
        public PopularCurrentyView()
        {
            InitializeComponent();
        }

    }
}
