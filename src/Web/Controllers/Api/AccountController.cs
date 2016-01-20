using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Swashbuckle.Swagger.Annotations;
using Ultra.Core.Domain.Events;
using Ultra.Core.Infrastructure.Data;
using Ultra.Web.Infrastructure;

namespace Ultra.Web.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/account")]
    public class AccountController : BaseApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="model"></param>
        /// <response code="400">Bad request</response >
        /// <response code="200" cref="LoginResponseDTO"></response >
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(LoginResponseDTO))]
        public async Task<HttpResponseMessage> Login(LoginParams model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

            Guid? userId = null;
            if (result == SignInStatus.Success)
            {
                ApplicationUser user = UserManager.FindByName(model.Email);
                userId = Guid.Parse(user.Id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new LoginResponseDTO
            {
                UserId = userId,
                Status = result,
            });
        }

        /// <summary>
        /// Register (and login) new user 
        /// </summary>
        /// <param name="model"></param>
        /// <response code="400" cref="RegisterResponseDTO">Bad request</response >
        /// <response code="200" cref="RegisterResponseDTO"></response >
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.OK,Type = typeof(RegisterResponseDTO))]
        public async Task<HttpResponseMessage> Register(RegisterParams model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false, false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    Please.Tell(new UserRegistered(Guid.Parse(user.Id), model.CarId, model.FirstName, model.LastName));
                    return Request.CreateResponse(HttpStatusCode.OK, new RegisterResponseDTO()
                    {
                        UserId = Guid.Parse(user.Id)
                    });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            //todo add error model
            return Request.CreateResponse((HttpStatusCode)422, ModelState);
        }


        /// <summary>
        /// Log off current user
        /// </summary>
        /// <response code="200"></response >
        [HttpPost]
        [AllowAnonymous]
        [Route("logoff")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof (void))]
        public HttpResponseMessage LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion
    }

    public class LoginParams
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class LoginResponseDTO
    {
        public Guid? UserId { get; set; }
        public SignInStatus Status { get; set; }
    }

    public class RegisterParams
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string CarId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }

    public class RegisterResponseDTO
    {
        public Guid UserId { get; set; }
    }

}
