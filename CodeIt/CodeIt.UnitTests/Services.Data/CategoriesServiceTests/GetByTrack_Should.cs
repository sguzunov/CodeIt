using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Data;
using CodeIt.Services.Logic;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeIt.UnitTests.Services.Data.CategoriesServiceTests
{
    [TestFixture]
    public class GetByTrack_Should
    {
        [Test]
        public void Call_MapperProjectTo()
        {
            // Arrange
            var categoriesRepoFake = new Mock<IEfRepository<Category>>();
            var mapperFake = new Mock<IMappingProvider>();

            var service = new CategoriesService(categoriesRepoFake.Object, mapperFake.Object);

            var categoriesQueryable = new List<Category>().AsQueryable<Category>();
            mapperFake.Setup(x => x.ProjectTo<Category, object>(categoriesQueryable)).Verifiable();

            // Act
            service.GetByTrack<object>(It.IsAny<string>());

            // Assert
            mapperFake.Verify(x => x.ProjectTo<Category, object>(categoriesQueryable), Times.AtLeastOnce);
        }
    }
}
