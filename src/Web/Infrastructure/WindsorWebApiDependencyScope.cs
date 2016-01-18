using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;
using Ultra.Core;

namespace Ultra.Web.Infrastructure
{
    public class WindsorWebApiDependencyScope : IDependencyScope
    {
        private ConcurrentBag<object> _toBeReleased = new ConcurrentBag<object>();

        public void Dispose()
        {
            if (_toBeReleased != null)
            {
                foreach (var o in _toBeReleased)
                {
                    IoC.Release(o);
                }
            }
            _toBeReleased = null;
        }

        public object GetService(Type serviceType)
        {
            object resolved = null;
            try
            {
                resolved = IoC.Resolve(serviceType);
                _toBeReleased.Add(resolved);
            }
            catch (Exception)
            { }
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
            { }
            if (resolve != null)
            {
                resolve.ToList()
                    .ForEach(x => _toBeReleased.Add(x));
            }
            return resolve;
        }
    }
}