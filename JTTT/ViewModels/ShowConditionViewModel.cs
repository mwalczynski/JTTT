using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
