using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebScraper_ConsoleApp.Utils
{
    public class HttpResponse
    {
        private readonly HttpClient _httpClient;

        public HttpResponse()
        {
            _httpClient = Factory.GetHttpClient();
        }

        public async Task<string> ParseAsync(string sourceUri)
        {
            var response = await _httpClient.GetAsync(sourceUri);
            if (!response.IsSuccessStatusCode) throw new Exception();
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}