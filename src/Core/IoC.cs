using System;
using System.Collections.Generic;
using Castle.Windsor;

namespace Ultra.Core
{
    public static class IoC
    {
        private static IWindsorContainer _container;

        public static void Initialize(IWindsorContainer windsorContainer)
        {
            _container = windsorContainer;
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static T Resolve<T>(string key)
        {
            return _container.Resolve<T>(key);
        }

        public static object Resolve(Type service)
        {
            return _container.Resolve(service);
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        public static void Release(object instance)
        {
            _container.Release(instance);
        }
    }
}