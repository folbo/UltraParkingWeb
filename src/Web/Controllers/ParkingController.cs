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
            var places = Please.Give(new PlacesForParking(id)).ToList();
            var count = places.Count;
            return Json(JsonConvert.SerializeObject(count));
        }

        public ActionResult GetPlaces(Guid id)
        {
            var places = Please.Give(new PlacesForParking(id)).ToList();
            return Json(JsonConvert.SerializeObject(places));
        }

        public ActionResult AddPlaces(AddPlacesModel model)
        {
            Please.Do(new AddPlaces(model.Id, model.Amount, model.BeginFrom));
            return Content("ok");
        }
    }

    public class AddPlacesModel
    {
        public int Amount { get; set; }
        public int BeginFrom { get; set; }
        public Guid Id { get; set; }
    }

    public enum PlaceStatus
    {
        Available,
        Reserved,
        Disabled
    }
}