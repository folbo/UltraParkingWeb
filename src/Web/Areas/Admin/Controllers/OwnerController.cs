using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Ultra.Core.Domain.Commands.Admin.Parking;
using Ultra.Core.Domain.Queries.Admin;
using Ultra.Core.Infrastructure.Data;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OwnerController : BaseController
    {
        private CoreDbContext Data;

        public OwnerController(CoreDbContext data)
        {
            Data = data;
        }

        public ActionResult Index()
        {
            var parkings = Please.Give(new AllOwners());

            return View(parkings);
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

        public ActionResult AddOwner(AddOwner command)
        {
            AddRoleIfNotExist("Owner");
            var userId = AddUserToRole(command.NewOwnerUserEmail,"Owner");
            Data.Owners.Add(new Core.Domain.Entities.Owner()
            {
                Id = userId,
                Name = command.NewOwnerName,
            });
            Data.SaveChanges();
            return Json(userId);
        }


        private Guid AddUserToRole(string userName, string roleName)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(userName);
            //check for user roles
            var rolesForUser = userManager.GetRoles(user.Id);
            //if user is not in role, add him to it
            if (!rolesForUser.Contains(roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }

            return Guid.Parse(user.Id);
        }

        private void RemoveUserFromRole(string userid, string roleName)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(userid);
            //check for user roles
            var rolesForUser = userManager.GetRoles(user.Id);
            //if user is not in role, add him to it
            if (rolesForUser.Contains(roleName))
            {
                userManager.RemoveFromRole(user.Id, roleName);
            }
        }

        private void AddRoleIfNotExist(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Data));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public ActionResult SearchUser(SearchUser query)
        {
            return Json(Please.Give(query));
        }

        public ActionResult RenameOwner(RenameOwner command)
        {
            var owner = Data.Owners.First(o => o.Id==command.OwnerId);
            owner.Name = command.NewName;
            foreach (var parking in Data.Parkings.Where(p => p.OwnerId == command.OwnerId))
            {
                parking.UpdateOwnerName(command.NewName);
            }
            Data.SaveChanges();
            return JsonOk();
        }

        public ActionResult RemoveOwner(Guid ownerId)
        {
            var owner = Data.Owners.Find(ownerId);
            Data.Owners.Remove(owner);
            RemoveUserFromRole(ownerId.ToString(),"Owner");

            foreach (var parking in Data.Parkings.Where(p => p.OwnerId == ownerId))
            {
                parking.SetOwner(Guid.Empty, "");
            }

            Data.SaveChanges();
            return JsonOk();
        }
    }

    public class RenameOwner
    {
        public Guid OwnerId { get; set; }
        public string NewName { get; set; }
    }

    public class AddOwner
    {
        public string NewOwnerName { get; set; }
        public string NewOwnerUserEmail { get; set; }
    }
}