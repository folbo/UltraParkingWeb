using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Ultra.Core.Domain.Commands.Admin.Parking;
using Ultra.Core.Domain.Queries.Admin;
using Ultra.Core.Domain.Queries.Owner;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Areas.Owner.Controllers
{
    [Authorize(Roles = "Owner")]
    public class ParkingController : BaseController
    {
        public ActionResult Index()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var parkings = Please.Give(new OwnerParkings(id));

            return View(parkings);
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

        public ActionResult RemoveSegment(RemoveSegment command)
        {
            Please.Do(command);
            return JsonOk();
        }
    }
}