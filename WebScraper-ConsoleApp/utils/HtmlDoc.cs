using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScraper_ConsoleApp.utils
{
    public static class HtmlDoc
    {
        public static async Task<List<string>> ParseAsync(string resourceUri, string classname)
        {
            var responseBody = await HttpResponse.ParseAsync(resourceUri);
            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);
            
            var links = htmlDoc.DocumentNode.Descendants()
                .Where(node => node.HasClass(classname)).ToList();
            
            var titles = links.Select(link =>link.FirstChild.FirstChild.InnerHtml).ToList();
            
            return titles;
        }
    }
}