using System;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

using AuthService = CodeIt.Web.Auth.AuthenticationService;
using Microsoft.Owin;
using CodeIt.Web.Auth;
using CodeIt.UnitTests.AuthTests.Mocks;
using Microsoft.AspNet.Identity;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.AuthTests.AuthenticationService
{
    [TestFixture]
    public class SignUpAsyncShould
    {
        [Test]
        public void ThrowsArgumentNullException_WhenUsername_IsNull()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var authService = new AuthService(fakeOwinContext.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await authService.SignUpAsync(username: null, email: "somemail", password: "123"));
        }

        [Test]
        public void ThrowsArgumentException_WhenUsername_IsEmptyString()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var authService = new AuthService(fakeOwinContext.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await authService.SignUpAsync(username: "", email: "somemail", password: "123"));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenEmail_IsNull()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var authService = new AuthService(fakeOwinContext.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await authService.SignUpAsync(username: "John", email: null, password: "123"));
        }

        [Test]
        public void ThrowsArgumentException_WhenEmail_IsEmptyString()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var authService = new AuthService(fakeOwinContext.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await authService.SignUpAsync(username: "John", email: "", password: "123"));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenPassword_IsNull()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var authService = new AuthService(fakeOwinContext.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await authService.SignUpAsync(username: "John", email: "somemail", password: null));
        }

        [Test]
        public void ThrowsArgumentException_WhenPassword_IsEmptyString()
        {
            // Arrange
            var fakeOwinContext = new Mock<IOwinContext>();
            var authService = new AuthService(fakeOwinContext.Object);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await authService.SignUpAsync(username: "John", email: "somemail", password: ""));
        }

        [Test]
        public async Task CallUserManager_CreateAsync()
        {
            // Arrange
            //var fakeUserStore = new Mock<IUserStore<User>>();
            //var fakeUserManager = new MockUserManager(fakeUserStore.Object);
            //var fakeOwinContext = new MockOwinContext(fakeUserManager);
            //var authService = new AuthService(fakeOwinContext);

            //// Act
            //var creatingResult = await authService.SignUpAsync("username", "somemail", "123");

            //// Assert
            //Assert.IsTrue(fakeUserManager.IsUserCreated);
        }
    }
}
