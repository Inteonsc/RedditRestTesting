using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Media.Imaging;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DataSorter {


    public class DataRetriever {

        string _RequestString {get; set;}
        


        public DataRetriever(string requeststring) {

            _RequestString = requeststring;


        }


        public dynamic RetreieveData() {
            WebClient client = new WebClient();

            // Get Json from the reddit api.
            string result = client.DownloadString(_RequestString);
            var jsonresult = JObject.Parse(result);

            bool textpost = false;

            if (jsonresult["data"]["children"][0]["data"]["selftext"] != null && jsonresult["data"]["children"][0]["data"]["selftext"].ToString() != "") {
                textpost = true;
                Console.WriteLine(jsonresult["data"]["children"][0]["data"]["selftext_html"]);
            }

            if (textpost == true) {
                return GetSelfTextData(jsonresult);
            }
            else {
               return GetBitmapImage(jsonresult);
            }
            

        }



        public BitmapImage GetBitmapImage(JObject data) {

            


            // Get the source URL from the Json.
            var jsonurl = data["data"]["children"][0]["data"]["url"];
            Console.WriteLine(jsonurl.ToString());


            // Get the image from the URL.
            Uri uristring = new Uri(jsonurl.ToString());
            return new BitmapImage(uristring);


        }


        public String GetSelfTextData(JObject data) {

            // Get the Text data from the Reddit post
            return data["data"]["children"][0]["data"]["selftext"].ToString() ;
            

            
            
        }


        // getters and setters for private values;
        public void SetRequestString(string value){
            _RequestString = value;
        }

        public string GetRequestString() {
            return _RequestString;
        }

    }


}
