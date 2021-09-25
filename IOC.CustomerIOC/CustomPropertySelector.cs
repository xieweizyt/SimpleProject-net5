using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOC.CustomerIOC
{
    public class CustomPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            var flg = propertyInfo.CustomAttributes.Any(it => it.AttributeType == typeof(SelPropAttr));
            return flg;
        }
    }
}
