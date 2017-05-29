using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Mail;



namespace JTTT
{
    public class HtmlSearcher
    {
        private static string GetPageHtml(string url)
        {
            var html = "";
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                html = System.Net.WebUtility.HtmlDecode(wc.DownloadString(url));
            }
            return html;
        }

        public static List<HtmlNode> SearchNodes(string text, string url)
        {
            var doc = new HtmlDocument();
            var pageHtml = GetPageHtml(url);
            doc.LoadHtml(pageHtml);
            var nodes = doc.DocumentNode.Descendants("img");

            return nodes.Where(n => n.GetAttributeValue("alt", "").ToLower().Contains(text.ToLower())).ToList();
        }
    }
}