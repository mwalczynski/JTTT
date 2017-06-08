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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string GetPageHtml(string url)
        {
            var html = "";
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                log.Info("getting page html for: " + url);
                html = System.Net.WebUtility.HtmlDecode(wc.DownloadString(url));
            }
            return html;
        }

        public static List<HtmlNode> SearchNodes(string text, string url)
        {
            log.Info("searching nodes in " + url + " for text " + text);
            var doc = new HtmlDocument();
            var pageHtml = GetPageHtml(url);
            doc.LoadHtml(pageHtml);
            var nodes = doc.DocumentNode.Descendants("img");
            log.Info("returning found nodes");
            return nodes.Where(n => n.GetAttributeValue("alt", "").ToLower().Contains(text.ToLower())).ToList();
        }
    }
}