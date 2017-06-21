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

        public IfThisViewModel CreateViewModel()
        {
            return Mapper.Map<IsImageViewModel>(this);
        }

        public JtttCondition CreateDao()
        {
            return Mapper.Map<JtttConditionImgAlt>(this);
        }
    }
}
