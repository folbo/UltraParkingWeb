using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    //todo
    [pAuthorize(Role = Roles.ParkingOwner)]
    public class ParkingController : Controller
    {
        // GET: Parking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult SetPlaceStatus(PlaceStatus status)
        {
            return View();
        }

        public ActionResult ReservePlace()
        {
            return View();
        }
    }

    public enum PlaceStatus
    {
        Available,
        Reserved,
        Disabled
    }
}