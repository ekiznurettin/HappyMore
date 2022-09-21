using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Layouts.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionsBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionsBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
