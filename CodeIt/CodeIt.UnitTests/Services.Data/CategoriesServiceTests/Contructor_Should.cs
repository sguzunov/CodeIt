using System;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Logic;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.CategoriesServiceTests
{
    [TestFixture]
    public class Contructor_Should
    {
        [Test]
        public void ThrowsArgumentNullException_When_CategoriesRepository_IsNull()
        {
            // Arrange
            IEfRepository<Category> categoriesRepo = null;
            var mapperFake = new Mock<IMappingProvider>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CategoriesService(categoriesRepo, mapperFake.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_When_Mapper_IsNull()
        {
            // Arrange
            var categoriesRepoFake = new Mock<IEfRepository<Category>>();
            IMappingProvider mapper = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CategoriesService(categoriesRepoFake.Object, mapper));
        }
    }
}
