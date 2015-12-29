using System.Web.Http;
using Ultra.Core;
using Ultra.Core.Infrastructure;

namespace Ultra.Web.Infrastructure
{
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController()
        {
            Please = IoC.Resolve<IAssistant>();
        }

        protected IAssistant Please { get; set; }
    }
}