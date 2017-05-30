using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT.ViewModels
{
    public abstract class IfThisThenThatBaseViewModel : BaseViewModel
    {
        public abstract bool IsValid();
    }
}
