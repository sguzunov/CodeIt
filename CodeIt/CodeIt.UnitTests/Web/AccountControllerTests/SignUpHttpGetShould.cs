using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

using CodeIt.Web.Controllers;
using CodeIt.Web.Auth.Contracts;

namespace CodeIt.UnitTests.Web.AccountControllerTests
{
    [TestFixture]
    public class SignUpHttpGetShould
    {
        [Test]
        public void Return_DefaultView()
        {
            // Arrange
            var fakeAuthService = new Mock<IAuthenticationService>();
            var controller = new AccountController(fakeAuthService.Object);

            // Act & Assert
            controller.WithCallTo(x => x.SignUp()).ShouldRenderView("SignUp");
        }
    }
}
