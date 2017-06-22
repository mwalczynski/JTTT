using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.ViewModels.BaseViewModels;

namespace JTTT.ViewModels.IfThisViewModels
{
    public abstract class IfThisViewModel : IfThisThenThatBaseViewModel
    {
        public abstract DataCI GetData();
    }
}
