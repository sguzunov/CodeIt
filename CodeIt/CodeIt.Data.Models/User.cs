using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeIt.Data.Models
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(Microsoft.AspNet.Identity.UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
