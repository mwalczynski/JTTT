using System.Collections.Generic;

namespace JTTT
{
    public class DataCI
    {
        public bool IsConditionFulfilled;
        public string Title;
        public string Text;
        public List<string> Images;

        public DataCI(string title)
        {
            Title = title;
        }
    }
}
