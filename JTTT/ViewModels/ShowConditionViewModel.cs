using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using JTTT.ViewModels.BaseViewModels;

namespace JTTT.ViewModels
{
    public class ShowConditionViewModel : BaseViewModel
    {
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private string htmlContent;
        public string HtmlContent
        {
            get => htmlContent;
            set
            {
                htmlContent = value;
                OnPropertyChanged(nameof(HtmlContent));
            }
        }

        public ShowConditionViewModel(string title, string text, string htmlContent)
        {
            Title = title;
            Text = text;
            HtmlContent = htmlContent;
        }
    }
}
