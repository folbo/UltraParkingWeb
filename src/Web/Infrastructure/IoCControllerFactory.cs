using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Ultra.Web.Infrastructure
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer _container;

        public IoCControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (typeof (Controller).IsAssignableFrom(controllerType))
            {
                return (IController) _container.Resolve(controllerType);
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }
    }
}