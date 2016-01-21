using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ultra.Core.Infrastructure.Data;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers
{
    public class TestController : BaseController
    {
        private readonly CoreDbContext _data;

        public TestController(CoreDbContext data)
        {
            _data = data;
        }

        public ActionResult BuyCredit()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var driver = _data.Drivers.Find(userId);
            driver.AddCurency(55);
            _data.SaveChanges();
            return View();
        }
    }
}