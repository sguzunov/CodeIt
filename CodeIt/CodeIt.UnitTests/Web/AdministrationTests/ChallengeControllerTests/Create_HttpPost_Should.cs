using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Services.Logic.Contracts;
using CodeIt.Web.Areas.Administration.Controllers;
using CodeIt.Web.Areas.Administration.ViewModels.Challenge;
using CodeIt.Web.Infrastructure.FileSystem;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestStack.FluentMVCTesting;

namespace CodeIt.UnitTests.Web.AdministrationTests.ChallengeControllerTests
{
    [TestFixture]
    public class Create_HttpPost_Should
    {
        [Test]
        public async Task Call_ChallengesServiceCreateWhenNoFileIsAttached()
        {
            var tracksServiceFake = new Mock<ITracksService>();
            var challengesServiceFake = new Mock<IChallengesService>();
            var mapperFake = new Mock<IMappingProvider>();
            var fileSystemFake = new Mock<IFileSystemService>();
            var fileUtilsFake = new Mock<IFileUnits>();

            var controller = new ChallengeController(
                tracksServiceFake.Object,
                challengesServiceFake.Object,
                fileSystemFake.Object,
                mapperFake.Object,
                fileUtilsFake.Object);

            var vModelFake = new Mock<ChallengeAdministrationViewModel>();

            challengesServiceFake.Setup(
                x => x.Create(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Language>(),
                    It.IsAny<double>(),
                    It.IsAny<int>(),
                    It.IsAny<IEnumerable<Test>>())).Verifiable();

            // Act
            await controller.Create(vModelFake.Object);

            // Assert
            challengesServiceFake.Verify(
                x => x.Create(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Language>(),
                It.IsAny<double>(),
                It.IsAny<int>(),
                It.IsAny<IEnumerable<Test>>()), Times.Once);
        }

        [Test]
        public async Task ReloadPage()
        {
            var tracksServiceFake = new Mock<ITracksService>();
            var challengesServiceFake = new Mock<IChallengesService>();
            var mapperFake = new Mock<IMappingProvider>();
            var fileSystemFake = new Mock<IFileSystemService>();
            var fileUtilsFake = new Mock<IFileUnits>();

            var controller = new ChallengeController(
                tracksServiceFake.Object,
                challengesServiceFake.Object,
                fileSystemFake.Object,
                mapperFake.Object,
                fileUtilsFake.Object);

            var vModelFake = new Mock<ChallengeAdministrationViewModel>();

            // Act & Assert
            controller.WithCallTo(x => x.Create(vModelFake.Object)).ShouldRedirectTo(x => x.Create());
        }
    }
}
