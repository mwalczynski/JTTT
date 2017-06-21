using System.Collections.Generic;

namespace JTTT
{
    public class DataCI
    {
        public string Title;
        public List<string> Images;

        public DataCI(string title, List<string> images)
        {
            Title = title;
            Images = images;
        }
    }
}
