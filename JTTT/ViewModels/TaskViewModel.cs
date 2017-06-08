using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using JTTT.Dtos;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace JTTT.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private static int currentId = 3;
        private int id;
        private string title;
        private IfThisViewModel ifThisPage;
        private ThenThatViewModel thenThatPage;
        private IfThisViewModel ifThis;
        private ThenThatViewModel thenThat;

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
            get => ifThisPage ?? (ifThisPage = new IsImageViewModel());
            set
            {
                ifThisPage = value;
                OnPropertyChanged(nameof(IfThisPage));
            }
        }

        public ThenThatViewModel ThenThatPage
        {
            get => thenThatPage ?? (thenThatPage = new SendMailViewModel());
            set
            {
                thenThatPage = value;
                OnPropertyChanged(nameof(thenThatPage));
            }
        }

        public TaskViewModel()
        {
            IfThisPage = new IsImageViewModel();
            ThenThatPage = new SendMailViewModel();
        }

        public TaskViewModel(IfThisViewModel ifThis, ThenThatViewModel thenThat)
        {
            this.ifThis = ifThis;
            this.thenThat = thenThat;
        }

        public void Act()
        {
            var dtoType = IfThisPage.TypeOfDto;

            if (dtoType == typeof(IsImageDto))
            {
                var data = IfThisPage.GetData() as IsImageDto;
                thenThatPage.Act(data);
            }
            else if (dtoType == typeof(TestDto))
            {
                var data = IfThisPage.GetData() as TestDto;
                thenThatPage.Act(data);
            }
        }

        public bool IsValid()
        {
            return IfThisPage.IsValid() && ThenThatPage.IsValid() && !string.IsNullOrWhiteSpace(Title);
        }

        public static void ResetId()
        {
            currentId = 1;
        }
    }
}
