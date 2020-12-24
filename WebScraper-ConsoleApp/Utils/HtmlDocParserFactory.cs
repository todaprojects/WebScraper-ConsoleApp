namespace WebScraper_ConsoleApp.Utils
{
    public static class HtmlDocParserFactory
    {
        public static HtmlDocParser GetHtmlDocParser(string resourceUri, string classname)
        {
            return new HtmlDocParser()
            {
                ResourceUri = resourceUri,
                Classname = classname
            };
        }
    }
}