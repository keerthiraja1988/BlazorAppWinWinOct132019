﻿using Castle.DynamicProxy;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApiAuthentication.Infrastructure.Logger
{
    public class RepositoryInterfaceLogger : IInterceptor
    {
        private TextWriter _output;

        public RepositoryInterfaceLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            var method = invocation.MethodInvocationTarget;
            var isAsync = method.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null;
            if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                invocation.ReturnValue = InterceptAsync((dynamic)invocation.ReturnValue);
            }
        }

        private static async Task InterceptAsync(Task task)
        {
            await task.ConfigureAwait(false);
            // do the continuation work for Task...
        }

        private static async Task<T> InterceptAsync<T>(Task<T> task)
        {
            T result = await task.ConfigureAwait(false);
            // do the continuation work for Task<T>...
            return result;
        }
    }
}