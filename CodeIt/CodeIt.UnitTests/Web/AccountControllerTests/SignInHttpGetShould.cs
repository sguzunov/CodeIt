using TestStack.FluentMVCTesting;
using NUnit.Framework;
using Moq;

using CodeIt.Web.Auth.Contracts;
using CodeIt.Web.Controllers;

namespace CodeIt.UnitTests.Web.AccountControllerTests
{
    [TestFixture]
    public class SignInHttpGetShould
    {
        [Test]
        public void Return_DefaultView()
        {
            // Arrange
            var fakeAuthService = new Mock<IAuthenticationService>();
            var controller = new AccountController(fakeAuthService.Object);

            // Act & Assert
            controller.WithCallTo(x => x.SignIn("url")).ShouldRenderView("SignIn");
        }
    }
}
