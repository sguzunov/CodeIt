using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using CodeIt.Data.Models.Contracts;
using CodeIt.Common.Constants;

namespace CodeIt.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        [Required]
        [MinLength(ValidationConstants.UserNamesMinLength)]
        [MaxLength(ValidationConstants.UserNamesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ValidationConstants.UserNamesMinLength)]
        [MaxLength(ValidationConstants.UserNamesMaxLength)]
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
