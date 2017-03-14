using System.Threading.Tasks;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace CodeIt.Web.Auth.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(string username, string email, string password);

        Task<SignInStatus> SignInAsync(string username, string password, bool isPersistent);

        void SignOut();
    }
}
