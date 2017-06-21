using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT.Dtos
{
    class DataInterface
    {
        public string Title;
        public List<string> Images;

        public DataInterface(string title, ICollection<string> images)
        {
            Title = title;
            Images = images.ToList();
        }
    }
}
