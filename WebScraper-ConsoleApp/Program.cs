using System;
using System.Threading.Tasks;
using WebScraper_ConsoleApp.utils;

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
                var adTitles = await HtmlDoc.ParseAsync(ResourceUri, Classname);

                if (adTitles.Count == 0)
                {
                    Console.WriteLine("No results found. Please check if \"ResourceUri\" is correct.");
                }
                else
                {
                    foreach (var ad in adTitles)
                    {
                        Console.WriteLine(ad);
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