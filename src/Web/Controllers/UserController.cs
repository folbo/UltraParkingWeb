using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ultra.Core.Domain.Commands.Client;
using Ultra.Core.Domain.Queries;
using Ultra.Core.Domain.ViewModels;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var driver = Please.Give(new DriverInfo(userId));
            return View(driver);
        }

        public ActionResult ChangeFirstName(ChangeFirstName command)
        {
            command.UserId = Guid.Parse(User.Identity.GetUserId());
            Please.Do(command);
            return JsonOk();
        }

        public ActionResult ChangeLastName(ChangeLastName command)
        {
            command.UserId = Guid.Parse(User.Identity.GetUserId());
            Please.Do(command);
            return JsonOk();
        }

        public ActionResult ChangeCarId(ChangeCarId command)
        {
            command.UserId = Guid.Parse(User.Identity.GetUserId());
            Please.Do(command);
            return JsonOk();
        }
    }
}