using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Ultra.Core.Domain.Commands;
using Ultra.Core.Domain.Queries;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers
{
    public class ParkingListController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetParkings()
        {
            var model = Please.Give(new AllParkings()).Select(parking => new ParkingListItem()
            {
                Id = parking.Id,
                Name = parking.Name,
                TotalPlaces = parking.TotalPlaces
            }).ToList();

            return Json(JsonConvert.SerializeObject(model), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateParking(CreateParkingModel model)
        {
            Please.Do(new CreateParking(model.Name));
            return Content("ok");
        }
    }

    public class ParkingListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalPlaces { get; set; }
    }

    public class CreateParkingModel
    {
        public string Name { get; set; }
    }
}