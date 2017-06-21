using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Interfaces;

namespace JTTT.DaoModels
{
    [Table("JtttActionEmail")]
    public class JtttActionEmail : JtttAction
    {
        public string Email { get; set; }
    }
}
