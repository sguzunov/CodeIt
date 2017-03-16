using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

using CodeIt.Data.Models;

namespace CodeIt.UnitTests.AuthTests.Mocks
{
    public class MockUserManager : UserManager<User>
    {
        public MockUserManager(IUserStore<User> store) : base(store)
        {
            this.IsUserCreated = true;
        }

        public bool IsUserCreated { get; set; }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            this.IsUserCreated = true;
            return base.CreateAsync(user, password);
        }
    }
}
