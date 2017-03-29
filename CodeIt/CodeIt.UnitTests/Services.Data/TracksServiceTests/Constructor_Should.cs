using System;

using NUnit.Framework;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Data;
using Moq;
using CodeIt.Services.Logic;

namespace CodeIt.UnitTests.Services.Data.TracksServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throws_ArgumentNullException_WhenTracksRepository_IsNull()
        {
            // Arrage
            IEfRepository<Track> tracksRepo = null;
            var mapperFake = new Mock<IMappingProvider>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TracksService(tracksRepo, mapperFake.Object));
        }

        [Test]
        public void Throws_ArgumentNullException_WhenMappingProvider_IsNull()
        {
            // Arrage
            var tracksRepoFake = new Mock<IEfRepository<Track>>();
            IMappingProvider mapperFake = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TracksService(tracksRepoFake.Object, mapperFake));
        }
    }
}
