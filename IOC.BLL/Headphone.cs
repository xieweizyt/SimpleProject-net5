using IOC.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using IOC.CustomerIOC;

namespace IOC.BLL
{
    [Intercept(typeof(CustomInterceptor))]
    public class Headphone : IHeadphone
    {
        [SelPropAttr]
        public IPhone Phone { get; set; }

        public IPhone Phone1 { get; set; }
        public Headphone(IPhone phone)
        {

        }

        public IPhone phone2;
        [SelMethodAttr]
        public void SetValue(IPhone phone)
        {
            phone2 = phone;
        }

        public void Show()
        {

        }
    }
}
