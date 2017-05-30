using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Dtos;

namespace JTTT.ViewModels.ThenThatViewModels
{
    public abstract class ThenThatViewModel : IfThisThenThatBaseViewModel
    {
        public abstract void Act(IsImageDto imageDto);
    }
}
