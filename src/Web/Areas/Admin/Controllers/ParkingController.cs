using System;
using System.Web.Mvc;
using Ultra.Core.Domain.Commands.Admin.Parking;
using Ultra.Core.Domain.Queries.Admin;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ParkingController : BaseController
    {
        public ActionResult Index()
        {
            var parkings = Please.Give(new AllParkings());

            return View(parkings);
        }

        [HttpPost]
        public ActionResult Create(AddParking query)
        {
            query.newId = Guid.NewGuid();
            var parking = Please.Do(query);

            return RedirectToAction("Edit", new {Id = query.newId});
        }

        public ActionResult Edit(ParkingById query)
        {
            var parking = Please.Give(query);

            return View(parking);
        }

        [HttpPost]
        public ActionResult RenameParking(RenameParking command)
        {
            Please.Do(command);
            return JsonOk();
        }

        [HttpPost]
        public ActionResult UpdateLocation(UpdateParkingLocation command)
        {
            Please.Do(command);
            return JsonOk();
        }

        [HttpPost]
        public ActionResult RenameSegment(RenameSegment command)
        {
            Please.Do(command);
            return JsonOk();
        }

        [HttpPost]
        public ActionResult ResizeSegment(ResizeSegment command)
        {
            Please.Do(command);
            return JsonOk();
        }

        [HttpPost]
        public ActionResult AddSegment(AddSegment command)
        {
            command.NewId = Guid.NewGuid();
            Please.Do(command);
            return Json(command.NewId);
        }

        public ActionResult DeleteParking(DeleteParking command)
        {
            Please.Do(command);
            return JsonOk();
        }

        public ActionResult RemoveSegment(RemoveSegment command)
        {
            Please.Do(command);
            return JsonOk();
        }

        public ActionResult SearchOwner(SearchOwner query)
        {
            return Json(Please.Give(query));
        }

        public ActionResult ChangeParkingOwner(ChangeParkingOwner command)
        {
            Please.Do(command);
            return JsonOk();
        }
    }
}