using System;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Logic.Contracts;
using CodeIt.Services.Data;
using CodeIt.Services.Logic;

namespace CodeIt.UnitTests.Services.Data.SubmissionsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsArgumentNullException_WhenSubmissionsRepository_IsNull()
        {
            // Arrange
            IEfRepository<Submission> submisionsRepo = null;
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new SubmissionsService(submisionsRepo, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object, mapperFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenChallengesRepository_IsNull()
        {
            // Arrange
            var submisionsRepoFake = new Mock<IEfRepository<Submission>>(); ;
            IEfRepository<Challenge> challengeRepo = null;
            var efData = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new SubmissionsService(submisionsRepoFake.Object, challengeRepo, efData.Object,
                timeFake.Object, mapperFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_EfData_IsNull()
        {
            // Arrange
            var submisionsRepoFake = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            IEfData efData = null;
            var timeFake = new Mock<ITimeProvider>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new SubmissionsService(submisionsRepoFake.Object, challengeRepoFake.Object, efData,
                timeFake.Object, mapperFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_TimeProvider_IsNull()
        {
            // Arrange
            var submisionsRepoFake = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            ITimeProvider time = null;
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new SubmissionsService(submisionsRepoFake.Object, challengeRepoFake.Object, efDataFake.Object,
                time, mapperFake.Object));
        }
    }
}
