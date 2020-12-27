using System;
using System.Linq;
using System.Threading.Tasks;
using WebScraper_ConsoleApp.Utils;

namespace WebScraper_ConsoleApp
{
    class Program
    {
        private const string ResourceUri = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos";
        private const string Classname = "offer_primary_info";

        private static async Task Main(string[] args)
        {
            try
            {
                var htmlParser = Factory.GetHtmlDocParser(ResourceUri, Classname);

                var htmlNodes = await htmlParser.ParseHtmlNodesAsync();
                
                var titles = htmlNodes.Select(link =>link.FirstChild.FirstChild.InnerHtml).ToList();

                if (titles.Count == 0)
                {
                    Console.WriteLine("No results found. Please check if \"ResourceUri\" is correct.");
                }
                else
                {
                    foreach (var title in titles)
                    {
                        Console.WriteLine(title);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}