using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JTTT.DaoModels;
using JTTT.ViewModels.IfThisViewModels;

namespace JTTT.Dtos
{
    public class ConditionDto
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }

        public IfThisViewModel CreateViewModel()
        {
            if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(Text))
                return Mapper.Map<CheckWeatherViewModel>(this);

            return Mapper.Map<IsImageViewModel>(this);
        }

        public JtttCondition CreateDao()
        {
            if (string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(Text))
                return Mapper.Map<JtttConditionWeather>(this);

            return Mapper.Map<JtttConditionImgAlt>(this);
        }
    }
}
