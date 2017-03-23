using System;

using NUnit.Framework;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Data;

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

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TracksService(tracksRepo));
        }
    }
}
