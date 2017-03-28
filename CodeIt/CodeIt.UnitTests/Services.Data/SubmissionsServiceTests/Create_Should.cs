using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Data;
using CodeIt.Services.Logic;
using CodeIt.Services.Logic.Contracts;
using Moq;
using NUnit.Framework;
using System;

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
            var mapperFake = new Mock<IMappingProvider>();

            var service = new SubmissionsService(submisionsRepo.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object, mapperFake.Object);

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
            var mapperFake = new Mock<IMappingProvider>();

            var service = new SubmissionsService(submisionsRepo.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object, mapperFake.Object);

            Assert.Throws<ArgumentNullException>(() => service.Create(null, It.IsAny<Guid>(), It.IsAny<string>()));
        }

        [Test]
        public void ThrowsArgumentException_When_AChallengeWithThePassedId_IsNotFound()
        {
            // Arrange
            var submisionsRepo = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();
            var mapperFake = new Mock<IMappingProvider>();

            var service = new SubmissionsService(submisionsRepo.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object, mapperFake.Object);

            var userFake = new Mock<User>();
            Challenge challenge = null;
            challengeRepoFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(challenge);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.Create(userFake.Object, It.IsAny<Guid>(), "sourceCode"));
        }

        [Test]
        public void Call_SubmissionsRepositoryAdd_WithCorrectlyCreatedObject()
        {
            // Arrange
            var submisionsRepoFake = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();
            var mapperFake = new Mock<IMappingProvider>();

            var service = new SubmissionsService(submisionsRepoFake.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object, mapperFake.Object);

            var challengeFake = new Mock<Challenge>();
            challengeRepoFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(challengeFake.Object);
            Submission passedSubmission = null;
            submisionsRepoFake.Setup(x => x.Add(It.IsAny<Submission>()))
                .Callback<Submission>(x => passedSubmission = x);

            var createDate = DateTime.UtcNow;
            timeFake.Setup(x => x.UtcNow).Returns(createDate);

            var userFake = new Mock<User>();
            var challengeId = Guid.NewGuid();
            string sourceCode = "sourceCode";

            // Act
            service.Create(userFake.Object, challengeId, sourceCode);

            // Assert
            Assert.AreEqual(passedSubmission.User, userFake.Object);
            Assert.AreEqual(passedSubmission.Challenge, challengeFake.Object);
            Assert.AreEqual(passedSubmission.CreatedOn, createDate);
            Assert.AreEqual(passedSubmission.SourceCode, sourceCode);
        }

        [Test]
        public void Call_Commit_ToVerify_DataSave()
        {
            // Arrange
            var submisionsRepoFake = new Mock<IEfRepository<Submission>>();
            var challengeRepoFake = new Mock<IEfRepository<Challenge>>();
            var efDataFake = new Mock<IEfData>();
            var timeFake = new Mock<ITimeProvider>();
            var mapperFake = new Mock<IMappingProvider>();
            var userFake = new Mock<User>();

            var service = new SubmissionsService(submisionsRepoFake.Object, challengeRepoFake.Object, efDataFake.Object,
                timeFake.Object, mapperFake.Object);

            var challengeFake = new Mock<Challenge>();
            challengeRepoFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(challengeFake.Object);

            efDataFake.Setup(x => x.Commit()).Verifiable();


            // Act
            service.Create(userFake.Object, It.IsAny<Guid>(), "sourceCode");

            // Assert
            efDataFake.Verify(x => x.Commit(), Times.Once);
        }
    }
}
