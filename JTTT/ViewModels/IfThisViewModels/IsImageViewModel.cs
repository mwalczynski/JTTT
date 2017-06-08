using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JTTT.Dtos;

namespace JTTT.ViewModels.IfThisViewModels
{
    public class IsImageViewModel : IfThisViewModel
    {
        private string url;
        private string text;

        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged(nameof(Url));
            }
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(text);
        }

        public override string GetData()
        {
            var nodes = HtmlSearcher.SearchNodes(text, url);
            return FindAllNodes(nodes);
        }

        public string FindAllNodes(IEnumerable<HtmlNode> nodes)
        {
            var src = nodes.Select(n => n.GetAttributeValue("src", "")).ToList();

            var body = "";
            foreach (var node in src)
            {
                body += "<img src=\"" + node + "\" /><br />";
            }
            return body;
        }
    }
}
