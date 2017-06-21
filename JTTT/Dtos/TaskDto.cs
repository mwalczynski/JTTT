using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT.Dtos
{
    public class TaskDto
    {
        public string Title { get; set; }
        public ConditionDto Condition { get; set; }
        public ActionDto Action { get; set; }
    }
}
