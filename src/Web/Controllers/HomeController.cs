using System.Web.Mvc;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //Please.Give(new AllProjects());
            return View();
        }
    }
}