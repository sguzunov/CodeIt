using System;
using NUnit.Framework;
using CodeIt.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Data.Models;
using Moq;
using CodeIt.Services.Data.Contracts;

namespace CodeIt.UnitTests.Services.Data.TestsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsArgumentNullException_WhenTestsRepository_IsNull()
        {
            // Arrange
            IEfRepository<Test> testsRepository = null;
            var efData = new Mock<IEfData>();
            var mapper = new Mock<IMappingProvider>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TestsService(testsRepository, efData.Object, mapper.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenEfData_IsNull()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            IEfData efData = null;
            var mapper = new Mock<IMappingProvider>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TestsService(testsRepository.Object, efData, mapper.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenMappingProvider_IsNull()
        {
            // Arrange
            var testsRepository = new Mock<IEfRepository<Test>>();
            var efData = new Mock<IEfData>();
            IMappingProvider mapper = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TestsService(testsRepository.Object, efData.Object, mapper));
        }
    }
}
