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

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace WpfApplication1 {
    
    // using Json.net 9.0.1 because newer versions do not work with VS 2012/2013 ----- https://stackoverflow.com/questions/44532170/newtonsoft-json-already-has-a-dependency-defined-for-microsoft-csharp

    public partial class MainWindow : Window {

        /*************************************************************
        Filter variables.
        *************************************************************/

        public string SearchSubReddit = "prequelmemes"; // Only prequel memes at the moment but can expand to more later on.
        public string SearchTitle = "Obi"; //Defaults to Obi memes.
        public string SearchSort = "new"; //Defaults to the newest memes.
        public int SearchAmount = 5; //Not used yet but will be used once the Application can display multiple results. Defaults to 5 so it will get the five newest and display the newest one out of them.



        /*************************************************************
        Main method to display results.
        *************************************************************/


        public MainWindow() {
            InitializeComponent();

            //Get the post from reddit.
            DataSorter.DataRetriever datagetter = new DataSorter.DataRetriever(String.Format("https://www.reddit.com/r/{0}/search.json?q={1}&sort={2}&restrict_sr=on&limit={3}", SearchSubReddit, SearchTitle, SearchSort, SearchAmount));
            dynamic memedata = datagetter.RetreieveData();

            //If the post is an image display it.
            if (memedata.GetType() == typeof(BitmapImage)) {
                Meme.Source = memedata;
            }
           
        }


       
       
    }
}
