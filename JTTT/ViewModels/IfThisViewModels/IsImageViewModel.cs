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
            var data = new DataCI("Znalezione obrazki");

            var nodes = HtmlSearcher.SearchNodes(text, url);
            if (!nodes.Any())
            {
                data.IsConditionFulfilled = false;
            }
            else
            {
                var images = FindAllNodes(nodes);
                data.Images = images;
                data.Text = $"Znaleziono obrazków: {images.Count}";
                data.IsConditionFulfilled = true;
            }
            return data;
        }

        private List<string> FindAllNodes(IEnumerable<HtmlNode> nodes)
        {
            var images = nodes.Select(n => n.GetAttributeValue("src", "")).ToList();
            return images;
        }
    }
}
