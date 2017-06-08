using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Dtos;

namespace JTTT.ViewModels.IfThisViewModels
{
    class TestIfThisViewModel : IfThisViewModel
    {
        private string testValue;

        public string TestValue
        {
            get => testValue;
            set
            {
                testValue = value;
                OnPropertyChanged(nameof(TestValue));
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(TestValue);
        }

        public override string GetData()
        {
            return TestValue;
        }
    }
}
