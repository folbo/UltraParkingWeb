using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Swashbuckle.Swagger.Annotations;
using Ultra.Core.Domain.DTO;
using Ultra.Core.Domain.Queries.API;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : BaseApiController
    {
        /// <summary>
        /// Metoda zwraca listę płatności obecnie zalogowanego użytkownika posortowaną od najnowszej płatności
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public IEnumerable<PaymentDTO> Index()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var paymentVms = Please.Give(new UsersTransactions(id));
            return paymentVms;
        }
    }
}