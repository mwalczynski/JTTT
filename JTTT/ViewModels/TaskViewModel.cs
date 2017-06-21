﻿using System;
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
            var data = IfThisPage.GetData();
            thenThatPage.Act(data);
        }

        public bool IsValid()
        {
            return IfThisPage.IsValid() && ThenThatPage.IsValid() && !string.IsNullOrWhiteSpace(Title);
        }
    }
}
