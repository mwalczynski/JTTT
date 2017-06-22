using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace JTTT.ViewModels.IfThisViewModels
{
    public class CheckWeatherViewModel : IfThisViewModel
    {
        private string city;
        private int temperature;

        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public int Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(city);
        }

        public override DataCI GetData()
        {
            return null;
        }
    }
}
