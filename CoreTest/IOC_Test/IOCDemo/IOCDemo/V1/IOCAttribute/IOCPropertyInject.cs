﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.V1.IOCAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IOCPropertyInject:Attribute
    {
    }
}
