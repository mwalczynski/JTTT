using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override IsImageDto GetData()
        {
            var imageDto = new IsImageDto
            {
                Text = text,
                Url = url
            };

            return imageDto;
        }
    }
}
