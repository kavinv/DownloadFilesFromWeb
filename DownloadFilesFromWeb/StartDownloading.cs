using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DownloadFilesFromWeb
{
    class StartDownloading : WebClient
    {
        private readonly Uri _uri;

        public StartDownloading(Uri inputUri)
        {
            this._uri = inputUri;
            GetRequest(_uri);
        }



        /// <summary>
        /// This will output the data after stripping out the HTML tags. Change the cookie before executing this application.
        /// </summary>
        /// <param name="webRequestUri"></param>
        public void GetRequest(Uri webRequestUri)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.Cookie, "PHPSESSID=fh3653u79i45327iletd94cbj3");
            var htmlDoc = new HtmlDocument();

            var htmlDataDownloadString = client.DownloadString(webRequestUri);
            htmlDoc.LoadHtml(htmlDataDownloadString);
            var result = htmlDoc.DocumentNode.InnerText;
            Console.WriteLine(result);
            client.Dispose();
        }
        
    }


    class Program
    {
        /// <summary>
        /// Change the URL of the data to be downloaded before running this application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Uri uri = new Uri("https://www.yutalent.co.uk/c/cloud/get-file?type=note&file=notes_2013_11/2819/58/f9d81ff01aec9a8625983fe8f5c382f0.txt&id=16722");
            StartDownloading sdDownloading = new StartDownloading(uri);
            Console.WriteLine("Finished Downloading!");
            Console.ReadKey();
        }
    }
}

