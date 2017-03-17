using System;

using NUnit.Framework;

using CodeIt.Web.Controllers;

namespace CodeIt.UnitTests.Web.AccountControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenAuthenticationService_IsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AccountController(authenticationService: null));
        }
    }
}
