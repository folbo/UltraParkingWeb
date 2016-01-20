using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ultra.Core.Domain.Queries;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers
{
    [Authorize]
    public class TransactionsController : BaseController
    {
        public ActionResult Index()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var paymentVms = Please.Give(new UsersTransactions(id) );
            return View(paymentVms);
        }
    }
}