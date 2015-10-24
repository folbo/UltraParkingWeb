using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Ultra.Core.Infrastructure.Data;

namespace Ultra.Web.Installers
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
               Component.For<CoreDbContext>().ImplementedBy<CoreDbContext>()
               .DependsOn(Dependency.OnValue("connectionString", System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
               .LifestyleTransient()
           );
        }
    }
}