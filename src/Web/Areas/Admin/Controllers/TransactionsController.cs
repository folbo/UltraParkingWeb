using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ultra.Core.Domain.Queries.Admin;
using Ultra.Core.Domain.ViewModels;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Areas.Admin.Controllers
{
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