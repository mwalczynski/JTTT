using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;

namespace JTTT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IfThisViewModel ifThisPage;
        private ThenThatViewModel thenThatPage;
        private string message;

        public IfThisViewModel IfThisPage
        {
            get
            {
                if (ifThisPage == null)
                    ifThisPage = new IsImageViewModel();

                return ifThisPage;
            }
            set
            {
                ifThisPage = value;
                OnPropertyChanged(nameof(IfThisPage));
            }
        }

        public ThenThatViewModel ThenThatPage
        {
            get
            {
                if (thenThatPage == null)
                    thenThatPage = new SendMailViewModel();

                return thenThatPage;
            }
            set
            {
                thenThatPage = value;
                OnPropertyChanged(nameof(thenThatPage));
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

        public ICommand ActCommand { get; }

        public MainViewModel()
        {
            ActCommand = new RelayCommand(Act, CanAct);
            Message = "Wprowadź dane";
        }

        private void Act()
        {
            var data = ifThisPage.GetData();
            thenThatPage.Act(data);
            Message = "Wykonano zadanie";
        }

        private bool CanAct()
        {
            return ifThisPage.IsValid() && thenThatPage.IsValid();
        }
    }
}
