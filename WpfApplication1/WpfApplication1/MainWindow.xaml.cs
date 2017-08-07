using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    // using Json.net 9.0.1 because newer versions do not work iwth VS 2012/2013 ----- https://stackoverflow.com/questions/44532170/newtonsoft-json-already-has-a-dependency-defined-for-microsoft-csharp

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            WebClient client = new WebClient();

           



            string result = client.DownloadString("https://www.reddit.com/r/prequelmemes/search.json?q=obi&sort=new&restrict_sr=on&limit=5");
            var jsonresult =  JObject.Parse(result);
            


            var jsonurl = jsonresult["data"]["children"][0]["data"]["url"];//[0]["url"];
            Console.WriteLine(jsonurl.ToString());
            //Title.Text = jsonurl.ToString();  --- was for testing



            Uri uristring = new Uri(jsonurl.ToString() );
            var image = new BitmapImage(uristring );
            Meme.Source = image ;
                
                

           
           // Console.WriteLine(response.ContentType);

        }
    }
}
