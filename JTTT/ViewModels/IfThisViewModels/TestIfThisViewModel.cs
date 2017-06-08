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
        public override Type TypeOfDto { get; } = typeof(TestDto);
        public override Type TypeOfCondition { get; } = typeof(TestIfThisViewModel);

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

        public override IDto GetData()
        {
            var testDto = new TestDto()
            {
                TestValue = TestValue
            };

            return testDto;
        }
    }
}
