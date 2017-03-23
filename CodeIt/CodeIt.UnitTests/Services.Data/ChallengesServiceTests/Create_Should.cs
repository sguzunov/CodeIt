using System;
using System.Collections.Generic;
using NUnit.Framework;
using CodeIt.Data.Contracts;
using Moq;
using CodeIt.Services.Logic;
using CodeIt.Data.Models;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.ChallengesServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ThrowsArgumentException_WhenCategoryIsNotFound()
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

            Category returnedCateogry = null;
            categoriesRepositoryFake.Setup(x => x.GetById(It.IsAny<object>())).Returns(returnedCateogry);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                service.Create("title", "description", Guid.NewGuid().ToString(), Language.C, 12, 1, new List<Test>()));
        }

        [Test]
        public void Call_CategoriesRepository_WithCorrectId()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();
            var categoryFake = new Mock<Category>();
            var categoryId = Guid.NewGuid();

            var service = new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object);

            categoriesRepositoryFake.Setup(x => x.GetById(categoryId)).Returns(categoryFake.Object).Verifiable();

            // Act
            service.Create("title", "description", categoryId.ToString(), Language.C, 12, 1, new List<Test>());

            // Assert
            categoriesRepositoryFake.Verify(x => x.GetById(categoryId));
        }

        [Test]
        public void Create_ChallengeWithCorrectData()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();
            var categoryFake = new Mock<Category>();

            var service = new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object);

            categoriesRepositoryFake.Setup(x => x.GetById(It.IsAny<object>())).Returns(categoryFake.Object).Verifiable();

            Challenge passedChallenge = null;
            challengesRepositoryFake.Setup(x => x.Add(It.IsAny<Challenge>()))
                .Callback<Challenge>(x => passedChallenge = x);

            string title = "Strings";
            string description = "Draw!";
            var categoryId = Guid.NewGuid();
            var lang = Language.CPlusPlus;
            int timeInMs = 1;
            int memoryInKb = 1;
            var tests = new List<Test>();

            // Act
            service.Create(title, description, categoryId.ToString(), lang, timeInMs, memoryInKb, tests);

            // Assert
            Assert.AreEqual(title, passedChallenge.Title);
            Assert.AreEqual(description, passedChallenge.Description);
            Assert.AreEqual(lang, passedChallenge.Language);
            Assert.AreEqual(categoryId, passedChallenge.CategoryId);
            Assert.AreEqual(timeInMs, passedChallenge.TimeInMs);
            Assert.AreEqual(memoryInKb, passedChallenge.MemoryInKb);
        }

        [Test]
        public void Call_TestsRepositoryAdd_AsManyTimesAsTestsArePassed()
        {
            // Arrange
            var challengesRepositoryFake = this.GetMockedRepository<Challenge>();
            var testsRepositoryFake = this.GetMockedRepository<Test>();
            var fileDescriptionRepositoryFake = this.GetMockedRepository<FileDecription>();
            var categoriesRepositoryFake = this.GetMockedRepository<Category>();
            var efDataFake = new Mock<IEfData>();
            var mapperFake = new Mock<IMappingProvider>();
            var categoryFake = new Mock<Category>();
            var tests = new List<Test>
            {
                new Mock<Test>().Object,
                new Mock<Test>().Object,
                new Mock<Test>().Object
            };

            var service = new ChallengesService(
                    challengesRepository: challengesRepositoryFake.Object,
                    testsRepository: testsRepositoryFake.Object,
                    fileDescriptionRepository: fileDescriptionRepositoryFake.Object,
                    categoriesRepository: categoriesRepositoryFake.Object,
                    efData: efDataFake.Object,
                    mapper: mapperFake.Object);

            categoriesRepositoryFake.Setup(x => x.GetById(It.IsAny<object>())).Returns(categoryFake.Object).Verifiable();
            testsRepositoryFake.Setup(x => x.Add(It.IsAny<Test>())).Verifiable();

            // Act
            service.Create("title", "description", Guid.NewGuid().ToString(), Language.C, 12, 1, tests);

            // Assert
            testsRepositoryFake.Verify(x => x.Add(It.IsAny<Test>()), Times.Exactly(tests.Count));
        }

        private Mock<IEfRepository<T>> GetMockedRepository<T>()
            where T : class
        {
            return new Mock<IEfRepository<T>>();
        }
    }
}
