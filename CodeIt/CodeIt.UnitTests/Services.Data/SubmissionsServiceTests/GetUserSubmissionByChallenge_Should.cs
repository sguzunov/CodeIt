using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CodeIt.Services.Data;
using CodeIt.Services.Logic;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Logic.Contracts;

namespace CodeIt.UnitTests.Services.Data.SubmissionsServiceTests
{
    [TestFixture]
    public class GetUserSubmissionByChallenge_Should
    {
        [Test]
        public void Call_MapperProjectTo()
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

            var submissions = new List<Submission>().AsQueryable<Submission>();
            mapperFake.Setup(x => x.ProjectTo<Submission, object>(submissions)).Verifiable();

            // Act
            service.GetUserSubmissionByChallenge<object>(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            mapperFake.Verify(x => x.ProjectTo<Submission, object>(submissions), Times.AtLeastOnce);
        }
    }
}
