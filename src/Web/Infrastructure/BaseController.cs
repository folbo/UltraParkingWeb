using System.Web.Mvc;
using Ultra.Core;
using Ultra.Core.Infrastructure;

namespace Ultra.Web.Infrastructure
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            Please = IoC.Resolve<IAssistant>();
        }

        protected IAssistant Please { get; set; }
    }
}