using System.Threading.Tasks;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Bytes2you.Validation;

using CodeIt.Web.Models.Account;
using CodeIt.Web.Auth.Contracts;

namespace CodeIt.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService authService;

        public AccountController(IAuthenticationService authenticationService)
        {
            Guard.WhenArgument(authenticationService, nameof(authenticationService)).IsNull().Throw();
            this.authService = authenticationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInViewModel vModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(vModel);
            }

            var singnInResult = await this.authService.SignInAsync(vModel.Username, vModel.Password, vModel.RememberMe);
            switch (singnInResult)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = vModel.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(vModel);
            }
        }

        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUpViewModel vModel)
        {
            if (ModelState.IsValid)
            {
                string username = vModel.Username;
                string email = vModel.Email;
                string password = vModel.Password;

                var signUpResult = await this.authService.SignUpAsync(username, email, password);
                if (signUpResult.Succeeded)
                {
                    await this.authService.SignInAsync(username, password, isPersistent: false);
                    return RedirectToHomePage();
                }

                AddErrors(signUpResult);
            }

            return View(vModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            this.authService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToHomePage()
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                //context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}