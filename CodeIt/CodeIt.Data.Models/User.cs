using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

using CodeIt.Common.Constants;
using CodeIt.Data.Models.Contracts;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace CodeIt.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        private ICollection<Submission> submissions;

        public User()
        {
            this.submissions = new HashSet<Submission>();
        }

        [MinLength(ValidationConstants.UserNamesMinLength)]
        [MaxLength(ValidationConstants.UserNamesMaxLength)]
        public string FirstName { get; set; }

        [MinLength(ValidationConstants.UserNamesMinLength)]
        [MaxLength(ValidationConstants.UserNamesMaxLength)]
        public string LastName { get; set; }

        public ICollection<Submission> Submissions { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
