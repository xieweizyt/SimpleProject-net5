using IOC.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.BLL
{
    public class Headphone: IHeadphone
    {
        public Headphone(IPhone phone)
        {
            
        }
    }
}
