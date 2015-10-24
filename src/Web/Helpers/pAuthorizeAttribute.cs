using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ultra.Web.Controllers;

namespace Ultra.Web.Helpers
{
    /// <summary>
    /// użycie: [pAuthorize(Role = Roles.Admin | Roles.User)] - przejdzie jeśli przynajmniej jedna flaga będzie prawdziwa
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class pAuthorizeAttribute : AuthorizeAttribute
    {
        public Roles Role { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Role != 0)
                Roles = Role.ToString();

            base.OnAuthorization(filterContext);
        }
    }
}