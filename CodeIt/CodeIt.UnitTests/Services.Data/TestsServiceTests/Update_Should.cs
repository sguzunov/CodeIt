using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;

namespace CodeIt.UnitTests.Services.Data.TestsServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Call_RepositoryGetById_WithCorrectId()
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
            service.Update(testId, It.IsAny<string>(), It.IsAny<string>());

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
            Assert.Throws<ArgumentException>(() => service.Update(testId, It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void Change_InputProperty_WithThePassedValue()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testId = Guid.NewGuid();
            var testFake = new Mock<Test>();
            testsRepository.Setup(x => x.GetById(testId)).Returns(testFake.Object);

            string input = "someinput";
            string output = "someoutput";

            // Act 
            service.Update(testId, input, output);

            // Assert
            Assert.AreEqual(testFake.Object.Input, input);
            Assert.AreEqual(testFake.Object.Output, output);
        }

        [Test]
        public void Call_RepositoryUpdate_WithTheUpdatedTestObject()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testId = Guid.NewGuid();
            var testFake = new Mock<Test>();
            testsRepository.Setup(x => x.GetById(testId)).Returns(testFake.Object);

            Test passedTest = null;
            testsRepository.Setup(x => x.Update(It.IsAny<Test>()))
                .Callback<Test>(x => passedTest = x);

            string input = "someinput";
            string output = "someoutput";

            // Act
            service.Update(testId, input, output);

            // Assert
            Assert.AreEqual(passedTest.Input, input);
            Assert.AreEqual(passedTest.Output, output);
        }

        [Test]
        public void Save_AfterUpdatingTheTestObject()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            var service = new TestsService(testsRepository.Object, efData.Object, mapper.Object);

            var testId = Guid.NewGuid();
            var testFake = new Mock<Test>();
            testsRepository.Setup(x => x.GetById(testId)).Returns(testFake.Object);
            efData.Setup(x => x.Commit()).Verifiable();

            // Act
            service.Update(testId, It.IsAny<string>(), It.IsAny<string>());

            // Assert
            efData.Verify(x => x.Commit(), Times.AtLeastOnce);
        }
    }
}
