﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT.Dtos
{
    public class IsImageDto : IDto
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }
}
