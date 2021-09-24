using IOC.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.BLL
{
    public class ApplePhone: IApplePhone
    {
        public ApplePhone(IHeadphone headphone)
        {

        }
    }
}
