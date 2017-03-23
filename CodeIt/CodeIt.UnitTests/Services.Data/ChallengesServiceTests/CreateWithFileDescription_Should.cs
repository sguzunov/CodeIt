using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.ChallengesServiceTests
{
    [TestFixture]
    public class CreateWithFileDescription_Should
    {
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

            FileDecription passedFileDescription = null;
            fileDescriptionRepositoryFake.Setup(x => x.Add(It.IsAny<FileDecription>()))
                .Callback<FileDecription>(x => passedFileDescription = x);

            string fileName = "file1";
            string fileExt = "exe";
            string filePath = "/";

            // Act
            var challenge = service.CreateWithFileDescription(
                "title",
                "description",
                categoryId.ToString(),
                Language.C,
                12,
                1,
                new List<Test>(),
                fileName,
                fileExt,
                filePath);

            // Assert
            Assert.AreEqual(passedFileDescription.FileName, fileName + challenge.Id);
            Assert.AreEqual(passedFileDescription.FileExtension, fileExt);
            Assert.AreEqual(passedFileDescription.FileSystemPath, filePath);
            Assert.AreEqual(passedFileDescription.ChallengeId, challenge.Id);
        }

        private Mock<IEfRepository<T>> GetMockedRepository<T>()
           where T : class
        {
            return new Mock<IEfRepository<T>>();
        }
    }
}
