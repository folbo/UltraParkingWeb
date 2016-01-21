using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Ultra.Core.Infrastructure.Data;

namespace Ultra.Web.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        private readonly CoreDbContext DbContext;

        public TestController(CoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [Authorize]
        public ActionResult PromoteToAdmin()
        {
            AddRoleIfNotExist("Admin");
            AddUserToRole(User.Identity.GetUserId(), "Admin");


            return RedirectToAction("Index", "Home", new {Area = ""});
        }

        private void AddUserToRole(string userId, string roleName)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindById(userId);
            //check for user roles
            var rolesForUser = userManager.GetRoles(user.Id);
            //if user is not in role, add him to it
            if (!rolesForUser.Contains(roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }

            var sigminMenager = HttpContext.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            sigminMenager.SignIn(user, false, false);
        }

        private void AddRoleIfNotExist(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DbContext));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

    }
}