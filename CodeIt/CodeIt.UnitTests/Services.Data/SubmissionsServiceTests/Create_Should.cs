using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Data;
using CodeIt.Services.Logic.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIt.UnitTests.Services.Data.SubmissionsServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ThrowsArgumentNullException_WhenCreator_IsNull()
        {
            // Arrange
            var submisionsRepo = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();

            var service = new SubmissionsService(submisionsRepo.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object);

            Assert.Throws<ArgumentNullException>(() => service.Create(null, It.IsAny<Guid>(), It.IsAny<string>()));
        }

        [Test]
        public void Call_ChallengeRepositoryGetById_WithCorrectParam()
        {
            // Arrange
            var submisionsRepo = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();

            var service = new SubmissionsService(submisionsRepo.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object);

            Assert.Throws<ArgumentNullException>(() => service.Create(null, It.IsAny<Guid>(), It.IsAny<string>()));
        }
    }
}
