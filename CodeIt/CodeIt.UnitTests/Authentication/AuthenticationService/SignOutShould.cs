using Microsoft.Owin;

using NUnit.Framework;
using Moq;

using AuthService = CodeIt.Web.Auth.AuthenticationService;
using Microsoft.Owin.Security;

namespace CodeIt.UnitTests.Authentication.AuthenticationService
{
    [TestFixture]
    public class SignOutShould
    {
        [Test]
        public void CallOwinContext_ToSignOut()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var fakeAuthManager = new Mock<IAuthenticationManager>();
            var authService = new AuthService(fakeOwinContext.Object);

            fakeOwinContext.Setup(x => x.Authentication).Returns(fakeAuthManager.Object);
            fakeAuthManager.Setup(x => x.SignOut()).Verifiable();

            // Act
            authService.SignOut();

            // Assert
            fakeAuthManager.Verify(x => x.SignOut(), Times.AtLeastOnce);
        }
    }
}
