using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Owin;
using Microsoft.Owin.Security;

using CodeIt.Web.Auth;
using Microsoft.AspNet.Identity;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.Authentication.Mocks
{
    public class MockOwinContext : IOwinContext
    {
        public MockOwinContext(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        public UserManager<User> UserManager { get; set; }

        public IAuthenticationManager Authentication { get; }

        public IOwinRequest Request { get; }

        public IOwinResponse Response { get; }

        public IDictionary<string, object> Environment { get; }

        public TextWriter TraceOutput { get; set; }

        public T Get<T>(string key)
        {
            return default(T);
        }

        public IOwinContext Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public UserManager<User> GetUserManager()
        {
            return this.UserManager;
        }
    }
}
