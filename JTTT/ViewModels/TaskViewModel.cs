using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using JTTT.ViewModels.BaseViewModels;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace JTTT.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        public int DbId { get; set; }

        private int id;
        private string title;
        private IfThisViewModel ifThisPage;
        private ThenThatViewModel thenThatPage;

        public bool IsNew => Id == 0;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public IfThisViewModel IfThisPage
        {
            get => ifThisPage ?? (ifThisPage = ifThisToShow);
            set
            {
                ifThisPage = value;
                OnPropertyChanged(nameof(IfThisPage));
            }
        }

        public ThenThatViewModel ThenThatPage
        {
            get => thenThatPage ?? (thenThatPage = thenThatToShow);
            set
            {
                thenThatPage = value;
                OnPropertyChanged(nameof(thenThatPage));
            }
        }

        private static IfThisViewModel ifThisToShow = new IsImageViewModel();
        private static ThenThatViewModel thenThatToShow = new SendMailViewModel();

        public ICommand SetIsImageCommand { get; }
        public ICommand SetCheckWeatherCommand { get; }
        public ICommand SetSendMailCommand { get; }
        public ICommand SetShowCommand { get; }

        public TaskViewModel()
        {
            SetIsImageCommand = new RelayCommand(SetIsImage, CanSetIsImage);
            SetCheckWeatherCommand = new RelayCommand(SetCheckWeather, CanSetIsWeather);
            SetSendMailCommand = new RelayCommand(SetSendMail, CanSetSendMail);
            SetShowCommand = new RelayCommand(SetShow, CanSetShow);
        }

        public void SetIsImage()
        {
            ifThisToShow = new IsImageViewModel();
            IfThisPage = new IsImageViewModel();
        }

        public bool CanSetIsImage()
        {
            return !(ifThisToShow is IsImageViewModel);
        }

        public void SetCheckWeather()
        {
            ifThisToShow = new CheckWeatherViewModel();
            IfThisPage = new CheckWeatherViewModel();
        }

        public bool CanSetIsWeather()
        {
            return !(ifThisToShow is CheckWeatherViewModel);
        }
        public void SetSendMail()
        {
            thenThatToShow = new SendMailViewModel();
            ThenThatPage = new SendMailViewModel();
        }

        public bool CanSetSendMail()
        {
            return !(thenThatToShow is SendMailViewModel);
        }
        public void SetShow()
        {
            thenThatToShow = new ShowOnScreenViewModel();
            ThenThatPage = new ShowOnScreenViewModel();
        }

        public bool CanSetShow()
        {
            return !(thenThatToShow is ShowOnScreenViewModel);
        }

        public void Act()
        {
            var data = IfThisPage.GetData();
            thenThatPage.Act(data);
        }

        public bool IsValid()
        {
            return IfThisPage.IsValid() && ThenThatPage.IsValid() && !string.IsNullOrWhiteSpace(Title);
        }
    }
}
