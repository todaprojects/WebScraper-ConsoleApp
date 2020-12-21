using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebScraper_ConsoleApp.utils
{
    public static class HttpResponse
    {
        public static async Task<string> ParseAsync(string sourceUri)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(sourceUri);
            if (!response.IsSuccessStatusCode) throw new Exception();
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}