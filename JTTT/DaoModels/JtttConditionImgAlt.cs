using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Interfaces;

namespace JTTT.DaoModels
{
    [Table("JtttConditionImgAlt")]
    public class JtttConditionImgAlt : JtttCondition
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
