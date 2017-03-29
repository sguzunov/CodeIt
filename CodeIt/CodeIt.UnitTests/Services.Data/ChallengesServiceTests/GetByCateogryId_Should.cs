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

namespace CodeIt.UnitTests.Services.Data.ChallengesServiceTests
{
    [TestFixture]
    public class GetByCateogryId_Should
    {
        [Test]
        public void Call_MapperProjectTo()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();

            var service = new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object);

            var challengesFake = new List<Challenge>().AsQueryable<Challenge>();
            mapperFake.Setup(x => x.ProjectTo<Challenge, object>(challengesFake)).Verifiable();

            // Act
            service.GetByCateogryId<object>(It.IsAny<Guid>());

            // Assert
            mapperFake.Verify(x => x.ProjectTo<Challenge, object>(challengesFake), Times.AtLeastOnce);
        }

        [Test]
        public void Call_RepositoryAll_ToGetTheChallenges()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();

            var service = new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object);

            var challengesFake = new List<Challenge>().AsQueryable<Challenge>();
            challengesRepositoryFake.Setup(x => x.All).Returns(challengesFake).Verifiable();

            // Act
            service.GetByCateogryId<object>(It.IsAny<Guid>());

            // Assert
            challengesRepositoryFake.Verify(x => x.All, Times.AtLeastOnce);
        }

        private Mock<IEfRepository<T>> GetMockedRepository<T>()
           where T : class
        {
            return new Mock<IEfRepository<T>>();
        }
    }
}
