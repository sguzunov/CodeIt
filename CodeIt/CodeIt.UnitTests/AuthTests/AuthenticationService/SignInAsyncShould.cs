using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

using AuthService = CodeIt.Web.Auth.AuthenticationService;
using Microsoft.Owin;
using CodeIt.Web.Auth;

namespace CodeIt.UnitTests.AuthTests.AuthenticationService
{
    [TestFixture]
    public class SignInAsyncShould
    {
        //[Test]
        //public async void CallOwinContext_ToGetSignInManager()
        //{
        //    // Arrange
        //    var fakeOwinContext = new Mock<IOwinContext>();
        //    var fakeSignInManager = new Mock<CodeItSignInManager>();
        //    var authService = new AuthService(fakeOwinContext.Object);

        //    fakeOwinContext.Setup(x => x.Get<CodeItSignInManager>())

        //}
    }
}
