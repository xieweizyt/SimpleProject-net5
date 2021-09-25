using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IOC.CustomerIOC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace simple_net5.Commom
{
    public class CustomerControllerActivator : IControllerActivator
    {
        public object Create(ControllerContext context)
        {
            IServiceProvider serviceProvider = context.HttpContext.RequestServices;
            Type controllType = context.ActionDescriptor.ControllerTypeInfo.AsType();
            object oControlObj = serviceProvider.GetService(controllType);
            SetPropertyInjection(serviceProvider, controllType, oControlObj);
            SetMethodInjection(serviceProvider, controllType, oControlObj);

            return oControlObj;
        }

        public void Release(ControllerContext context, object controller)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }
            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        private object SetPropertyInjection(IServiceProvider serviceProvider, Type controllerType, object oInstance)
        {
            var props = controllerType.GetProperties().Where(t => t.IsDefined(typeof(SelPropAttr))).ToList();
            foreach (var prop in props)
            {
                object propObj = serviceProvider.GetService(prop.PropertyType);
                Type targetType = propObj.GetType();
                SetPropertyInjection(serviceProvider, targetType, propObj);
                prop.SetValue(oInstance, propObj);
            }

            return oInstance;
        }

        private object SetMethodInjection(IServiceProvider serviceProvider, Type controllerType, object oInstance)
        {
            var methodList = controllerType.GetMethods().Where(t => t.IsDefined(typeof(SelMethodAttr))).ToList();
            foreach (var method in methodList)
            {
                var methodParaList = method.GetParameters();
                List<object>paraList = new List<object>();
                foreach (var methPara in methodParaList)
                {
                    var methodParaType = serviceProvider.GetService(methPara.ParameterType);
                    var paraObj = SetMethodInjection(serviceProvider, methPara.ParameterType, methodParaType);
                    paraList.Add(paraObj);
                }

                method.Invoke(oInstance, paraList.ToArray());
            }

            return oInstance;
        }
    }
}
