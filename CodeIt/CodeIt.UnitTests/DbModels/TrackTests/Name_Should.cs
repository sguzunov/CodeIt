using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeIt.UnitTests.DbModels.TrackTests
{
    [TestFixture]
    public class Name_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arrange
            var propType = typeof(Track).GetProperty(nameof(Track.Name)).PropertyType;

            // Act & Assert
            Assert.IsTrue(propType == typeof(string));
        }

        [Test]
        public void Have_RequiredAttribute()
        {
            // Arrange & Act
            var hasAttr =
                typeof(Track)
                .GetProperty(nameof(Track.Name))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_MaxLengthAttribute()
        {
            // Arrange & Act
            var hasAttr =
                typeof(Track)
                .GetProperty(nameof(Track.Name))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Have_IdexAttribute()
        {
            // Arrange & Act
            var hasAttr =
                typeof(Track)
                .GetProperty(nameof(Track.Name))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(IndexAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
