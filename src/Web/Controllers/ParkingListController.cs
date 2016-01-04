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
            var model = Please.Give(new AllParkings()).Select(parking => new ParkingListItem()
            {
                Id = parking.Id,
                Name = parking.Name,
                TotalPlaces = parking.TotalPlaces
            }).ToList();

            var r = JsonConvert.SerializeObject(model);
            return View((object)r);
        }

        public ActionResult CreateParking(CreateParkingModel model)
        {
            var id = Guid.NewGuid();
            Please.Do(new CreateParkingKnownId(id, model.Name));
            var parking = Please.Give(new GetParkingById(id));
            return Json(parking);
        }

        public ActionResult ResizeParking(ResizeParkingModel model)
        {
            Please.Do(new AddPlaces(model.Id, model.Amount, model.NamingPattern));
            return Json(JsonConvert.SerializeObject(model));
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

    public class ResizeParkingModel
    {
        public int Amount { get; set; }
        public string NamingPattern { get; set; }
        public Guid Id { get; set; }
    }
}