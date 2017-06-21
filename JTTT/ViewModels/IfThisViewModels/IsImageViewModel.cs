using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace JTTT.ViewModels.IfThisViewModels
{
    public class IsImageViewModel : IfThisViewModel
    {
        protected override string Title { get; } = "Znalezione obrazki";

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

        public override DataCI GetData()
        {
            var nodes = HtmlSearcher.SearchNodes(text, url);
            var images = FindAllNodes(nodes);
            var data = new DataCI(Title, images);
            return data;
        }

        private List<string> FindAllNodes(IEnumerable<HtmlNode> nodes)
        {
            var images = nodes.Select(n => n.GetAttributeValue("src", "")).ToList();
            return images;
        }
    }
}
