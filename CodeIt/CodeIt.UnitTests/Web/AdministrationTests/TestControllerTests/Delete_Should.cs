using System;

using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.Controllers;

using Moq;
using NUnit.Framework;

namespace CodeIt.UnitTests.Web.AdministrationTests.TestControllerTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void Call_TestsServiceDelete_WithCorrectId()
        {
            // Arrange
            var testsServiceFake = new Mock<ITestsService>();

            var controller = new TestController(testsServiceFake.Object);

            var challengeId = Guid.NewGuid();

            testsServiceFake.Setup(x => x.DeleteById(challengeId)).Verifiable();

            // Act
            controller.Delete(challengeId.ToString());

            // Assert
            testsServiceFake.Verify(x => x.DeleteById(challengeId));
        }
    }
}
