using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Dtos;

namespace JTTT.ViewModels.IfThisViewModels
{
    public abstract class IfThisViewModel : IfThisThenThatBaseViewModel
    {
        public abstract Type TypeOfDto { get; }
        public abstract Type TypeOfCondition { get; }
        public abstract IDto GetData();
    }
}
