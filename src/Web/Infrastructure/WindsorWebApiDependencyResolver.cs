using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ultra.Core;

namespace Ultra.Web.Infrastructure
{
    public class WindsorWebApiDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return new WindsorWebApiDependencyScope();
        }

        public object GetService(Type serviceType)
        {
            object resolved = null;
            try
            {
                resolved = IoC.Resolve(serviceType);
            }
            catch (Exception)
            {
            }
            return resolved;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> resolve = new object[0];
            try
            {
                resolve = IoC.ResolveAll(serviceType);
            }
            catch (Exception)
            {
            }
            return resolve;
        }

        public void Dispose()
        {
        }
    }
}