using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;

namespace JTTT.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private static int currentId = 3;
        private int id;
        private string title;       
        private IfThisViewModel ifThisPage;
        private ThenThatViewModel thenThatPage;

        public bool IsCurrentTask;


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

        public void Act()
        {
            var data = ifThisPage.GetData();
            thenThatPage.Act(data);
        }

        public bool IsValid()
        {
            return IfThisPage.IsValid() && ThenThatPage.IsValid() && !string.IsNullOrWhiteSpace(Title);
        }

        public void SetId()
        {
            Id = currentId++;
        }

        public static void ResetId()
        {
            currentId = 1;
        }
    }
}
