using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ultra.Core.Infrastructure;
using Ultra.Core.Infrastructure.Commands;
using Ultra.Core.Infrastructure.Events;
using Ultra.Core.Infrastructure.Queries;

namespace Ultra.Web.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(ICommandHandler<>))
                    .LifestyleTransient()
                    .WithServiceBase(),

                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(IEventHandler<>))
                    .LifestyleTransient()
                    .WithServiceBase(),

                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(IQueryPerformer<,>))
                    .LifestyleTransient()
                    .WithServiceBase(),

                Component.For<ICommandBus>().ImplementedBy<CommandBus>(),
                Component.For<IEventBus>().ImplementedBy<EventBus>(),
                Component.For<IQueryBus>().ImplementedBy<QueryBus>(),
                Component.For<IAssistant>().ImplementedBy<Assistant>(),
                Component.For<IDateTimeGetter>().ImplementedBy<DateTimeGetter>()
                
                );
        }
    }
}