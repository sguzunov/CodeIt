using System;

using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.Controllers;

using Moq;
using NUnit.Framework;

using TestStack.FluentMVCTesting;
using CodeIt.Data.Models;
using System.Collections.Generic;
using CodeIt.Web.Areas.Administration.ViewModels.Challenge;

namespace CodeIt.UnitTests.Web.AdministrationTests.TestControllerTests
{
    [TestFixture]
    public class ByChallengeId_Should
    {
        [Test]
        [Ignore("Strange behaviour")]
        public void Call_TestsServiceGetByChallenge_WithCorrectParam()
        {
            // Arrange
            var testsServiceFakse = new Mock<ITestsService>();

            var controller = new TestController(testsServiceFakse.Object);

            var challengeId = Guid.NewGuid();

            Guid passedId = default(Guid);
            testsServiceFakse.Setup(x => x.GetByChallenge<object>(It.IsAny<Guid>()))
                .Callback<Guid>(x => passedId = x);

            // Act
            controller.ByChallengeId(challengeId.ToString());

            // Assert
            Assert.AreEqual(challengeId, passedId);
        }

        [Test]
        public void ReturnsDefaultView()
        {
            // Arrange
            var testsServiceFakse = new Mock<ITestsService>();

            var controller = new TestController(testsServiceFakse.Object);

            var challengeId = Guid.NewGuid();

            Guid passedId = default(Guid);
            testsServiceFakse.Setup(x => x.GetByChallenge<object>(It.IsAny<Guid>()))
                .Callback<Guid>(x => passedId = x);

            // Act & Assert
            controller.WithCallTo(x => x.ByChallengeId(challengeId.ToString())).ShouldRenderDefaultView();
        }

        [Test]
        public void Pass_AsViewModel_CollectionReturnedFromTheService()
        {
            // Arrange
            var testsServiceFakse = new Mock<ITestsService>();

            var controller = new TestController(testsServiceFakse.Object);

            var challengeId = Guid.NewGuid();
            IEnumerable<ChallengeTestAdministrationViewModel> tests = new List<ChallengeTestAdministrationViewModel>();
            testsServiceFakse.Setup(x => x.GetByChallenge<ChallengeTestAdministrationViewModel>(It.IsAny<Guid>())).Returns(tests);

            // Act & Assert
            controller.WithCallTo(x => x.ByChallengeId(challengeId.ToString()))
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<ChallengeTestAdministrationViewModel>>();
        }
    }
}
