using System;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using CodeIt.Data;
using CodeIt.Data.Models;

namespace CodeIt.Web.Auth
{
    public class CodeItUserManager : UserManager<User>
    {
        public CodeItUserManager(IUserStore<User> store) : base(store)
        {
        }

        public static CodeItUserManager Create(IdentityFactoryOptions<CodeItUserManager> options, IOwinContext context)
        {
            var manager = new CodeItUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<User>(context.Get<CodeItDbContext>()));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                // TODO: Uncomment!!!
                //RequiredLength = 6
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
