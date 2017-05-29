using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace JTTT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string url;
        private string text;
        private string email;
        private string message;

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

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ICommand SendCommand { get; }

        public MainViewModel()
        {
            SendCommand = new RelayCommand(Send, CanSend);
            Message = "Wprowadź dane";
        }

        private void Send()
        {
            Message = "Szukam obrazków";
            var foundImages = HtmlSearcher.SearchNodes(text, url);
            Message = "Wysyłam obrazki";
            MailSender.SendAllNodes(foundImages, email);
            Message = "Wysłano";
        }

        private bool CanSend()
        {
            return !string.IsNullOrWhiteSpace(url) && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(email);
        }
    }
}
