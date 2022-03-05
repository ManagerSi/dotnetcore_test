using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.V1.IOCAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IOCClassInject:Attribute
    {
    }
}
