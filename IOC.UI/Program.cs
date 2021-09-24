using IOC.Factory;
using IOC.IBLL;
using System;

namespace IOC.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IHeadphone headphone = SimpleFactory.CreatrHeadphone(); 
            IApplePhone applePhone = SimpleFactory.CreatrApplePhone();
            Console.WriteLine("Hello World!");
        }
    }
}
