using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

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
            var data = new DataCI("Prognoza pogody");

            WeatherObject weather;
            using (var webClient = new WebClient())
            {
                var result = new WebClient().DownloadString("http://api.openweathermap.org/data/2.5/weather?q=%22%20+%20" + city + "%20+%20%22,pl&APPID=d538a4621323009617190bf710f443af");
                weather = JsonConvert.DeserializeObject<WeatherObject>(result);
            }

            data.IsConditionFulfilled = false;

            if (weather.main != null)
            {
                var celsius = TemperatureConverter.ToCelsius(weather.main.temp);
                if (celsius > Temperature)
                {
                    data.Text = $"Pogoda jest wystarczająco dobra! Dzisiejsza temperatura: {celsius}";
                    data.Images = new List<string>() { "http://openweathermap.org/img/w/" + weather.weather[0].icon + ".png" };
                    data.IsConditionFulfilled = true;
                }
            }

            return data;

        }
    }
}
