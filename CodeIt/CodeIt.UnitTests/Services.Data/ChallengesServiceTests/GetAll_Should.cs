using System.Linq;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Logic;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.ChallengesServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Call_MappingProvider_ToCreateMappingOf_RequiredData()
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

            mapperFake.Setup(x => x.ProjectTo<Challenge, object>(It.IsAny<IQueryable<Challenge>>())).Verifiable();

            // Act
            service.GetAll<object>();

            // Assert
            mapperFake.Verify(x => x.ProjectTo<Challenge, object>(It.IsAny<IQueryable<Challenge>>()), Times.Once);
        }

        private Mock<IEfRepository<T>> GetMockedRepository<T>()
           where T : class
        {
            return new Mock<IEfRepository<T>>();
        }
    }
}
