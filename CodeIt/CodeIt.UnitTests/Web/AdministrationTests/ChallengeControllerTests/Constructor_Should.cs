using System;
using NUnit.Framework;
using Moq;
using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Web.Infrastructure.FileSystem;
using CodeIt.Services.Logic.Contracts;
using CodeIt.Web.Areas.Administration.Controllers;

namespace CodeIt.UnitTests.Web.AdministrationTests.ChallengeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsArgumentNullException_WhenTracksService_IsNull()
        {
            // Arrange
            ITracksService tracksService = null;
            var challengesServiceFake = new Mock<IChallengesService>();
            var mapperFake = new Mock<IMappingProvider>();
            var fileSystemFake = new Mock<IFileSystemService>();
            var fileUtilsFake = new Mock<IFileUnits>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ChallengeController(
                tracksService,
                challengesServiceFake.Object,
                fileSystemFake.Object,
                mapperFake.Object,
                fileUtilsFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenChallengesService_IsNull()
        {
            // Arrange
            var tracksServiceFake = new Mock<ITracksService>();
            IChallengesService challengesService = null;
            var mapperFake = new Mock<IMappingProvider>();
            var fileSystemFake = new Mock<IFileSystemService>();
            var fileUtilsFake = new Mock<IFileUnits>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ChallengeController(
                tracksServiceFake.Object,
                challengesService,
                fileSystemFake.Object,
                mapperFake.Object,
                fileUtilsFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenMapper_IsNull()
        {
            // Arrange
            var tracksServiceFake = new Mock<ITracksService>();
            var challengesServiceFake = new Mock<IChallengesService>();
            IMappingProvider mapper = null;
            var fileSystemFake = new Mock<IFileSystemService>();
            var fileUtilsFake = new Mock<IFileUnits>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ChallengeController(
                tracksServiceFake.Object,
                challengesServiceFake.Object,
                fileSystemFake.Object,
                mapper,
                fileUtilsFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenFileSystemService_IsNull()
        {
            // Arrange
            var tracksServiceFake = new Mock<ITracksService>();
            var challengesServiceFake = new Mock<IChallengesService>();
            var mapperFake = new Mock<IMappingProvider>();
            IFileSystemService fileSystem = null;
            var fileUtilsFake = new Mock<IFileUnits>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ChallengeController(
                tracksServiceFake.Object,
                challengesServiceFake.Object,
                fileSystem,
                mapperFake.Object,
                fileUtilsFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenFileUtils_IsNull()
        {
            // Arrange
            var tracksServiceFake = new Mock<ITracksService>();
            var challengesServiceFake = new Mock<IChallengesService>();
            var mapperFake = new Mock<IMappingProvider>();
            var fileSystemFake = new Mock<IFileSystemService>();
            IFileUnits fileUtils = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ChallengeController(
                tracksServiceFake.Object,
                challengesServiceFake.Object,
                fileSystemFake.Object,
                mapperFake.Object,
                fileUtils));
        }
    }
}
