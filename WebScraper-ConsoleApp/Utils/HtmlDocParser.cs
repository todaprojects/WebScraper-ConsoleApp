using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebScraper_ConsoleApp.Utils
{
    public class HtmlDocParser
    {
        public string ResourceUri { get; set; }
        public string Classname { get; set; }

        private readonly HtmlDocument _htmlDocument;
        private readonly HttpResponse _httpResponse;

        public HtmlDocParser()
        {
            _htmlDocument = new HtmlDocument();
            _httpResponse = new HttpResponse();
        }

        public async Task<List<string>> ParseAsync()
        {
            var responseBody = await _httpResponse.ParseAsync(ResourceUri);
           
            _htmlDocument.LoadHtml(responseBody);
            
            var links = _htmlDocument.DocumentNode.Descendants()
                .Where(node => node.HasClass(Classname)).ToList();
            
            var titles = links.Select(link =>link.FirstChild.FirstChild.InnerHtml).ToList();
            
            return titles;
        }
    }
}