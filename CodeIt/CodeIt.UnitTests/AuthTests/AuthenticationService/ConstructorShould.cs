using System;

using NUnit.Framework;

using AuthService = CodeIt.Web.Auth.AuthenticationService;

namespace CodeIt.UnitTests.AuthTests.AuthenticationService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowsArgumentNullException_WhenOwinContextIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AuthService(null));
        }
    }
}
