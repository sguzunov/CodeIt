using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using CodeIt.Data.Models.Constants;

namespace CodeIt.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(ValidationConstants.NamesMinLenght)]
        [MaxLength(ValidationConstants.NamesMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.NamesMinLenght)]
        [MaxLength(ValidationConstants.NamesMaxLenght)]
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
