using System.Web.Mvc;
using Ultra.Core.Domain.Queries.Admin;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TransactionsController : BaseController
    {
        // GET: Admin/Transactions
        public ActionResult Index()
        {
            var paymentVms = Please.Give(new AllTransactions());
            return View(paymentVms);
        }
    }
}