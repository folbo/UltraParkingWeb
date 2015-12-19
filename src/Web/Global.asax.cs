using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ultra.Core.Mappings;
using Ultra.Web.Infrastructure;

namespace Ultra.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = ContainerConfig.CreateContainer();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory(container));

            DTOMappings.Register();
        }
    }
}
