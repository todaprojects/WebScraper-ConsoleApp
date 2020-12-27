using System.Net.Http;
using HtmlAgilityPack;

namespace WebScraper_ConsoleApp.Utils
{
    public class Factory
    {
        public static HtmlDocParser GetHtmlDocParser(string resourceUri, string classname)
        {
            return new HtmlDocParser()
            {
                ResourceUri = resourceUri,
                Classname = classname
            };
        }
        
        public static HttpClient GetHttpClient()
        {
            return new HttpClient();
        }

        public static HtmlDocument GeHtmlDocument()
        {
            return new HtmlDocument();
        }

        public static HttpResponse GeHttpResponse()
        {
            return new HttpResponse();
        }
    }
}