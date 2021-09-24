using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IOC.CustomerIOC
{
    public class CustomerIoc : ICustomerIoc
    {
        private IDictionary<string, Type> _types = new Dictionary<string, Type>();
        public void AddTransient<TIt, T>() where T : TIt
        {
            string tName = typeof(TIt).FullName;
            _types.Add(tName, typeof(T));
        }

        public T GetService<T>()
        {
            object result = CreateService(typeof(T));
            return (T)result;
        }

        private object CreateService(Type _type)
        {
            string tName = _type.FullName;
            Type type = _types[tName];

            //获取当前类型所有的构造函数
            ConstructorInfo[] ctors = type.GetConstructors();

            //优先选择 SelAttr 特性标记的构造函数
            var attrCtors = ctors.Where(t => t.IsDefined(typeof(SelAttr), true));
            ConstructorInfo ctor = null;
            if (attrCtors?.Count() > 0)
            {
                ctor = attrCtors.First();
            }
            else
            {
                //没有 SelAttr 标记的特性就选择参数最多的构造函数
                ctor = ctors.OrderByDescending(t => t.GetParameters().Count()).First();
            }
            List<object> paraList = new List<object>();
            //获取构造函数的所有参数
            foreach (var item in ctor.GetParameters())
            {
                //递归来创建所有参数的实例
                object paraInsatance = CreateService(item.ParameterType);
                paraList.Add(paraInsatance);
            }
            return Activator.CreateInstance(type, paraList.ToArray());
        }
    }
}
