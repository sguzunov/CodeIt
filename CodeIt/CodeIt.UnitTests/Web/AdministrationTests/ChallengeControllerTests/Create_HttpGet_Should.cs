using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Web.Infrastructure.FileSystem;
using CodeIt.Services.Logic.Contracts;
using CodeIt.Web.Areas.Administration.Controllers;
using TestStack.FluentMVCTesting;

namespace CodeIt.UnitTests.Web.AdministrationTests.ChallengeControllerTests
{
    [TestFixture]
    public class Create_HttpGet_Should
    {
        [Test]
        public void Return_CorrectView()
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

            // Act & Assert
            controller.WithCallTo(x => x.Create()).ShouldRenderDefaultView();
        }
    }
}
