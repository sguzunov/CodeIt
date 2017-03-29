using System;

using CodeIt.Web.Areas.Administration.Controllers;

using NUnit.Framework;

namespace CodeIt.UnitTests.Web.AdministrationTests.TestControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThorowsArgumentNullException_WhenTestsService_IsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TestController(tests: null));
        }
    }
}
