using System;
using NUnit.Framework;
using Moq;
using CodeIt.Services.Data;
using CodeIt.Services.Logic;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.Services.Data.ChallengesServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Call_ChallengesRepositoryGetById_WithCorrectValue()
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

            var challengeId = Guid.NewGuid();
            var challengeFake = new Mock<Challenge>();
            Guid passedId = default(Guid);
            challengesRepositoryFake.Setup(x => x.GetById(challengeId)).Returns(challengeFake.Object)
                .Callback<Guid>(x => passedId = x);

            // Act
            service.Update(challengeId.ToString(), It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<double>(), It.IsAny<int>());

            // Assert
            Assert.IsTrue(passedId.ToString() == challengeId.ToString());
        }

        [Test]
        public void ThrowsArgumentException_When_NoChallengeFound()
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

            Challenge challenge = null;
            var challengeId = Guid.NewGuid();
            challengesRepositoryFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(challenge);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.Update(challengeId.ToString(), It.IsAny<string>(), It.IsAny<Language>(), It.IsAny<double>(), It.IsAny<int>()));
        }

        [Test]
        public void Update_Challenge_WithNewValues()
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

            string challengeId = Guid.NewGuid().ToString();
            var challengeFake = new Mock<Challenge>();
            challengesRepositoryFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(challengeFake.Object);

            string title = "title";
            var lang = Language.C;
            double timeInMs = 1.1;
            int memoryInKb = 1;

            // Act
            service.Update(challengeId, title, lang, timeInMs, memoryInKb);

            // Assert
            Assert.AreEqual(title, challengeFake.Object.Title);
            Assert.AreEqual(lang, challengeFake.Object.Language);
            Assert.AreEqual(timeInMs, challengeFake.Object.TimeInMs);
            Assert.AreEqual(memoryInKb, challengeFake.Object.MemoryInKb);
        }

        [Test]
        public void Call_ChallengesRepository_ToUpdateObjectState()
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

            string challengeId = Guid.NewGuid().ToString();
            var challengeFake = new Mock<Challenge>();
            challengesRepositoryFake.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(challengeFake.Object);
            challengesRepositoryFake.Setup(x => x.Update(challengeFake.Object)).Verifiable();

            string title = "title";
            var lang = Language.C;
            double timeInMs = 1.1;
            int memoryInKb = 1;

            // Act
            service.Update(challengeId, title, lang, timeInMs, memoryInKb);

            // Assert
            challengesRepositoryFake.Verify(x => x.Update(challengeFake.Object), Times.AtLeastOnce);
        }

        private Mock<IEfRepository<T>> GetMockedRepository<T>()
           where T : class
        {
            return new Mock<IEfRepository<T>>();
        }
    }
}
