using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ultra.Core.Domain.Queries;
using Ultra.Web.Helpers;
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
