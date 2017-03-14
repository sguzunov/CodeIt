using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

using CodeIt.Data.Models;

namespace CodeIt.Web.Auth
{
    public class CodeItSignInManager : SignInManager<User, string>
    {
        public CodeItSignInManager(CodeItUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((CodeItUserManager)UserManager);
        }

        public static CodeItSignInManager Create(IdentityFactoryOptions<CodeItSignInManager> options, IOwinContext context)
        {
            return new CodeItSignInManager(context.GetUserManager<CodeItUserManager>(), context.Authentication);
        }
    }
}
