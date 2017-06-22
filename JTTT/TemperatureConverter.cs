using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public static class TemperatureConverter
    {
        public static double ToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
        public static double ToKelvin(double celsius)
        {
            return celsius + 273.15;
        }
    }
}
