using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.CustomerIOC
{
    public interface ICustomerIoc
    {
        void AddTransient<TIt, T>() where T: TIt;
        T GetService<T>();
    }
}
