using IOC.Factory;
using IOC.IBLL;
using System;
using IOC.BLL;
using IOC.CustomerIOC;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //IHeadphone headphone = SimpleFactory.CreatrHeadphone();
                //IApplePhone applePhone = SimpleFactory.CreatrApplePhone();
            }

            #region 自带的IOC容器实现
            {
                //IServiceCollection serviceCollection = new ServiceCollection();
                //serviceCollection.AddTransient<IHeadphone, Headphone>();
                //serviceCollection.AddTransient<IApplePhone, ApplePhone>();
                //serviceCollection.AddTransient<IPhone, Phone>();

                //IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                //IApplePhone applePhone = serviceProvider.GetService<IApplePhone>();
            }
            #endregion

            #region 自定义IOC容器
            {
                ICustomerIoc customerIoc = new CustomerIoc();
                customerIoc.AddTransient<IPhone, Phone>();
                customerIoc.AddTransient<IHeadphone, Headphone>();
                IPhone phone = customerIoc.GetService<IPhone>();
                IHeadphone headphone = customerIoc.GetService<IHeadphone>();
            }
            #endregion
        }
    }
}
