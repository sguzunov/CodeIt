using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Data;
using Moq;

namespace CodeIt.UnitTests.Services.Data.TracksServiceTests
{
    [TestFixture]
    public class GetCategoriesByTrackId_Should
    {
        [Test]
        public void Call_TracksRepositoryGetById_WithCorrectId()
        {
            // Arrange
            var tracksRepositoryFake = new Mock<IEfRepository<Track>>();
            var service = new TracksService(tracksRepositoryFake.Object);
            var id = Guid.NewGuid();
            var trackFake = new Mock<Track>();
            var categoriesFake = new Mock<ICollection<Category>>();

            trackFake.Setup(x => x.Categories).Returns(categoriesFake.Object);
            tracksRepositoryFake.Setup(x => x.GetById(id)).Returns(trackFake.Object).Verifiable();

            // Act
            service.GetCategoriesByTrackId(id);

            // Assert
            tracksRepositoryFake.Verify(x => x.GetById(id), Times.AtLeastOnce);
        }

        [Test]
        public void Returns_AllCategoriesOfATrack()
        {
            // Arrange
            var tracksRepositoryFake = new Mock<IEfRepository<Track>>();
            var service = new TracksService(tracksRepositoryFake.Object);
            var id = Guid.NewGuid();
            var trackFake = new Mock<Track>();
            var categories = new List<Category>
            {
                new Category{ TrackId = id },
                new Category{ TrackId = id }
            };

            trackFake.Setup(x => x.Categories).Returns(categories);
            tracksRepositoryFake.Setup(x => x.GetById(id)).Returns(trackFake.Object).Verifiable();

            // Act
            var actualReturnedCategories = service.GetCategoriesByTrackId(id);

            // Assert
            Assert.AreEqual(categories.Count, actualReturnedCategories.Count());
        }
    }
}
