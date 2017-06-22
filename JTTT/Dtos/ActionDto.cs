using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JTTT.DaoModels;
using JTTT.ViewModels.IfThisViewModels;
using JTTT.ViewModels.ThenThatViewModels;

namespace JTTT.Dtos
{
    public class ActionDto
    {
        public string Email { get; set; }

        public ThenThatViewModel CreateViewModel()
        {
            if (string.IsNullOrEmpty(Email))
                return Mapper.Map<ShowOnScreenViewModel>(this);

            return Mapper.Map<SendMailViewModel>(this);
        }

        public JtttAction CreateDao()
        {
            if (string.IsNullOrEmpty(Email))
                return Mapper.Map<JtttActionShow>(this);

            return Mapper.Map<JtttActionEmail>(this);
        }
    }
}
