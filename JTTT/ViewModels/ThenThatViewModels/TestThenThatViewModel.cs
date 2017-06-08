using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTTT.Dtos;

namespace JTTT.ViewModels.ThenThatViewModels
{
    public class TestThenThatViewModel : ThenThatViewModel
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
            return true;
        }

        public override void Act(string testDto)
        {
            TestValue = $"Pole po zmianie: {testDto}";
        }
    }
}
