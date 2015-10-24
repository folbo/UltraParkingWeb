using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Ultra.Core;

namespace Ultra.Web
{
    class ContainerConfig
    {
        public static IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();

            // add ability for resolving IEnumerable<IService>
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            // logging using log4net
            // use Castle.Core.Logging.ILogger as a dependency in your classes if you want logging
            //container.AddFacility<LoggingFacility>(f => f.UseLog4Net("log4net.config"));

            //WCF 
            //container.AddFacility<WcfFacility>();

            // find and use all IWindsorInstaller implementations
            container.Install(FromAssembly.This());

            IoC.Initialize(container);

            return container;
        }
    }
}
