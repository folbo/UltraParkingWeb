using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ultra.Core.Domain.Queries.Admin;
using Ultra.Core.Domain.Queries.Owner;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Areas.Owner.Controllers
{
    [Authorize(Roles = "Owner")]
    public class TransactionsController : BaseController
    {
        public ActionResult Index()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var paymentVms = Please.Give(new OwnerTransactions(id) );
            return View(paymentVms);
        }
    }
}