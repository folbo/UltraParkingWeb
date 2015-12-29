using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ultra.Core.Domain.Commands;
using Ultra.Core.Domain.Queries;
using Ultra.Web.Helpers;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers
{
    //todo
    //[pAuthorize(Role = Roles.ParkingOwner)]
    public class ParkingController : BaseController
    {
        public ActionResult Index(Guid id)
        {
            return Json("ok");
        }
    }

    

    public enum PlaceStatus
    {
        Available,
        Reserved,
        Disabled
    }
}