using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace JTTT.ViewModels
{
    public class MailSenderViewModel : BaseViewModel
    {
        private string url;
        private string text;
        private string email;

        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged(nameof(url));
            }
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(text));
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        public ICommand SendCommand { get; }

        public MailSenderViewModel()
        {
            SendCommand = new RelayCommand(Send, CanSend); 
        }

        private void Send()
        {
            var foundImages = HtmlSample.SearchNodes(text, url);
            MailSender.SendAllNodes(foundImages, email);
        }

        private bool CanSend()
        {
            return !string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(email);
        }
    }
}
