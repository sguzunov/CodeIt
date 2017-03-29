using System;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Logic.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.SubmissionsServiceTests
{
    [TestFixture]
    public class RunSubmission_Should
    {
        [Test]
        public void Call_SubmissionsRepositoryUpdate_WithUpdatedObject()
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

            var submissionFake = new Mock<Submission>();
            submisionsRepoFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(submissionFake.Object);

            Submission passedSubmission = null;
            submisionsRepoFake.Setup(x => x.Update(It.IsAny<Submission>()))
                .Callback<Submission>(x => passedSubmission = x);

            // Act
            service.RunSubmission(It.IsAny<Guid>());

            // Assert
            Assert.IsTrue(passedSubmission.IsRun);
        }

        [Test]
        public void ThrowsArgumentException_When_SubmissionWithThePassedId_IsNotFound()
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

            Submission submission = null;
            submisionsRepoFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(submission);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.RunSubmission(It.IsAny<Guid>()));
        }
    }
}
