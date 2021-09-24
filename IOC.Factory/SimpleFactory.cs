using IOC.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Factory
{
    public class SimpleFactory
    {
        public static IHeadphone CreatrHeadphone()
        {
            Assembly assembly = Assembly.LoadFrom("IOC.BLL.dll");//Dll名称
            Type type = assembly.GetType("IOC.BLL.Headphone");//类型全名称
            return (IHeadphone)Activator.CreateInstance(type);
        }

        public static IApplePhone CreatrApplePhone()
        {
            Assembly assembly = Assembly.LoadFrom("IOC.BLL.dll");//Dll名称
            Type type = assembly.GetType("IOC.BLL.ApplePhone");//类型全名称
            return (IApplePhone)Activator.CreateInstance(type, new object[] { CreatrHeadphone() });
        }
    }
}
