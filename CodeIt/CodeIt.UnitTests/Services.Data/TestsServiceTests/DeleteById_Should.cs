using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Services.Data.Contracts;

namespace CodeIt.UnitTests.Services.Data.TestsServiceTests
{
    [TestFixture]
    public class DeleteById_Should
    {
        [Test]
        public void Call_Repository_WithCorrectId()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testId = Guid.NewGuid();
            var testFake = new Mock<Test>();
            testsRepository.Setup(x => x.GetById(testId)).Returns(testFake.Object).Verifiable();

            // Act
            service.DeleteById(testId);

            // Assert
            testsRepository.Verify(x => x.GetById(testId), Times.AtLeastOnce);
        }

        [Test]
        public void ThrowsArgumentException_WhenTesWithThePassedId_IsNotFound()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testId = Guid.NewGuid();
            testsRepository.Setup(x => x.GetById(testId)).Returns(It.IsAny<Test>());

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.DeleteById(testId));
        }

        [Test]
        public void Call_TestRepository_ToDeleteTheFoundTest()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testFake = new Mock<Test>();
            testsRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(testFake.Object);
            testsRepository.Setup(x => x.Delete(testFake.Object)).Verifiable();

            // Act
            service.DeleteById(It.IsAny<Guid>());

            // Assert
            testsRepository.Verify(x => x.Delete(testFake.Object), Times.AtLeastOnce);
        }

        [Test]
        public void SaveChanges_WhenCorrectParamIsPassed()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testFake = new Mock<Test>();
            testsRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(testFake.Object);
            testsRepository.Setup(x => x.Delete(It.IsAny<Test>()));
            efData.Setup(x => x.Commit()).Verifiable();

            // Act
            service.DeleteById(It.IsAny<Guid>());

            // Assert
            efData.Verify(x => x.Commit(), Times.AtLeastOnce);
        }
    }
}
