using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Data;
using CodeIt.Services.Logic;

namespace CodeIt.UnitTests.Services.Data.TracksServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Call_TracksRepository_All()
        {
            // Arrange
            var tracksRepositoryFake = new Mock<IEfRepository<Track>>();
            var mapperFake = new Mock<IMappingProvider>();
            var service = new TracksService(tracksRepositoryFake.Object, mapperFake.Object);
            var queryableTracks = this.GetIQueryable<Track>();

            tracksRepositoryFake.Setup(x => x.All).Returns(queryableTracks).Verifiable();

            // Act
            service.GetAll();

            // Assert
            tracksRepositoryFake.Verify(x => x.All, Times.AtLeastOnce);
        }

        [Test]
        public void Call_ReturnsTheWholeCollection()
        {
            // Arrange
            var tracksRepositoryFake = new Mock<IEfRepository<Track>>();
            var mapperFake = new Mock<IMappingProvider>();
            var service = new TracksService(tracksRepositoryFake.Object, mapperFake.Object);
            var tracksData = new List<Track>
            {
                new Mock<Track>().Object,
                new Mock<Track>().Object,
                new Mock<Track>().Object,
            };

            var queryableTracks = this.GetIQueryable<Track>(tracksData);
            tracksRepositoryFake.Setup(x => x.All).Returns(queryableTracks).Verifiable();

            // Act
            service.GetAll();

            // Assert
            tracksRepositoryFake.Verify(x => x.All, Times.AtLeastOnce);
        }

        private IQueryable<T> GetIQueryable<T>(List<T> data = null)
        {
            data = (data != null) ? data : new List<T>();
            IQueryable<T> queryableData = data.AsQueryable();
            return queryableData;
        }
    }
}
