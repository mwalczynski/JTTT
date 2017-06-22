using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT.DaoModels
{
    class JtttConditionWeather : JtttCondition
    {
        public string City { get; set; }
        public int Temperature { get; set; }
    }
}
