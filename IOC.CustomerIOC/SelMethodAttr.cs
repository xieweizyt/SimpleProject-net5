using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.CustomerIOC
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SelMethodAttr : Attribute
    {
    }
}
