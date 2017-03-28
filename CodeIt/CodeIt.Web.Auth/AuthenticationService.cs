﻿using System.Threading.Tasks;

using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Bytes2you.Validation;

using CodeIt.Web.Auth.Contracts;
using CodeIt.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeIt.Web.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOwinContext owinContext;

        public AuthenticationService(IOwinContext owinContext)
        {
            Guard.WhenArgument(owinContext, nameof(owinContext)).IsNull().Throw();
            this.owinContext = owinContext;
        }

        public async Task<SignInStatus> SignInAsync(string username, string password, bool isPersistent)
        {
            var signInManager = this.owinContext.Get<CodeItSignInManager>();
            return await signInManager.PasswordSignInAsync(
                userName: username,
                password: password,
                isPersistent: isPersistent,
                shouldLockout: false);
        }

        public void SignOut()
        {
            this.owinContext.Authentication.SignOut();
        }

        public async Task<IdentityResult> SignUpAsync(string username, string email, string password)
        {
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, nameof(email)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(password, nameof(password)).IsNullOrEmpty().Throw();

            var user = new User { UserName = username, Email = email };
            var userManager = this.owinContext.GetUserManager<CodeItUserManager>();

            var result = await userManager.CreateAsync(user, password);
            userManager.AddToRole(user.Id, "Normal");
            return result;
        }
    }
}
