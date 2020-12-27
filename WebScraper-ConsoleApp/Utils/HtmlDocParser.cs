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
            _htmlDocument = Factory.GeHtmlDocument();
            _httpResponse = Factory.GeHttpResponse();
        }

        public async Task<List<HtmlNode>> ParseHtmlNodesAsync()
        {
            var responseBody = await _httpResponse.ParseAsync(ResourceUri);
           
            _htmlDocument.LoadHtml(responseBody);
            
            var htmlNodes = _htmlDocument.DocumentNode.Descendants()
                .Where(node => node.HasClass(Classname)).ToList();

            return htmlNodes;
        }
    }
}