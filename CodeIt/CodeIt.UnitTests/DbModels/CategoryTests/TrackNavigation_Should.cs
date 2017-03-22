using System;

using CodeIt.Data.Models;

using NUnit.Framework;

namespace CodeIt.UnitTests.DbModels.CategoryTests
{
    [TestFixture]
    public class TrackNavigation_Should
    {
        [Test]
        public void HaveIdProp_OfTypeGuid()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            Assert.IsTrue(category.TrackId.GetType() == typeof(Guid));
        }

        [Test]
        public void HaveProp_OfTypeTrack()
        {
            // Arrange
            var category = new Category();
            category.Track = new Track();

            // Act & Assert
            Assert.IsTrue(category.Track.GetType() == typeof(Track));
        }
    }
}
