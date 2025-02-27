﻿using Castle.DynamicProxy;
using System.Reflection;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{
    public abstract partial class MethodInterceptionBaseAttribute
    {
        public class AspectInterceptorSelector : IInterceptorSelector
        {
            public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
            {
                var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                    (true).ToList();
                var methodAttributes = type.GetMethod(method.Name)
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
               // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
        }
    }
}
