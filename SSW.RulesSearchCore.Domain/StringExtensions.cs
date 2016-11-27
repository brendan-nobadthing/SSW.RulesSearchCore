using HtmlAgilityPack;

namespace SSW.RulesSearchCore.Domain
{
    public static class StringExtensions
    {
        public static string StripHtml(this string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml($"<body>{html}</body>");
            return doc.DocumentNode.SelectSingleNode("//body").InnerText;
        }
    }
}