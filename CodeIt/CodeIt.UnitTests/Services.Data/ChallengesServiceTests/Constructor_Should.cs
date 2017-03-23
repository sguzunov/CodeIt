using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CodeIt.Data.Contracts;
using Moq;
using CodeIt.Data.Models;
using CodeIt.Services.Logic;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.ChallengesServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsArgumentNullException_WithMessageContainingFailedParam_WhenChallengesRepository_IsNull()
        {
            // Arrange
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            var exception = Assert.Catch<ArgumentNullException>(() => new ChallengesService(
                    challengesRepository: null,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object));

            StringAssert.Contains("challengesRepository", exception.Message);
        }

        [Test]
        public void ThrowsArgumentNullException_WithMessageContainingFailedParam_WhenTestsRepository_IsNull()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            var exception = Assert.Catch<ArgumentNullException>(() => new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: null,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object));

            StringAssert.Contains("testsRepository", exception.Message);
        }

        [Test]
        public void ThrowsArgumentNullException_WithMessageContainingFailedParam_WhenFileDescriptionRepository_IsNull()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            var exception = Assert.Catch<ArgumentNullException>(() => new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: null,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object));

            StringAssert.Contains("fileDescriptionRepository", exception.Message);
        }

        [Test]
        public void ThrowsArgumentNullException_WithMessageContainingFailedParam_WhenCategoriesRepository_IsNull()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            var exception = Assert.Catch<ArgumentNullException>(() => new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: null,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object));

            StringAssert.Contains("categoriesRepository", exception.Message);
        }

        [Test]
        public void ThrowsArgumentNullException_WithMessageContainingFailedParam_WhenEfData_IsNull()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var mapperFake = new Mock<IMappingProvider>();

            // Act and Assert
            var exception = Assert.Catch<ArgumentNullException>(() => new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: null,
                    mapper: mapperFake.Object));

            StringAssert.Contains("efData", exception.Message);
        }

        [Test]
        public void ThrowsArgumentNullException_WithMessageContainingFailedParam_WhenMappingProvider_IsNull()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();

            // Act and Assert
            var exception = Assert.Catch<ArgumentNullException>(() => new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: null));

            StringAssert.Contains("mapper", exception.Message);
        }

        private Mock<IEfRepository<T>> GetMockedRepository<T>()
            where T : class
        {
            return new Mock<IEfRepository<T>>();
        }
    }
}
