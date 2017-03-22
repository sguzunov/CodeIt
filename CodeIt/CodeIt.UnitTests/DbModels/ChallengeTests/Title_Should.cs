using System.Linq;

using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class Title_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arrange
            var challenge = new Challenge();
            challenge.Title = "title";

            // Act & Assert
            Assert.IsTrue(challenge.Title.GetType() == typeof(string));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arrange
            var challenge = new Challenge();

            // Act
            var hasAttr = challenge
                .GetType()
                .GetProperty(nameof(Challenge.Title))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Has_MinLenghtAttribute()
        {
            // Arrange
            var challenge = new Challenge();

            // Act
            var hasAttr = challenge
                .GetType()
                .GetProperty(nameof(Challenge.Title))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MinLengthAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }

        [Test]
        public void Has_MaxLenghtAttribute()
        {
            // Arrange
            var challenge = new Challenge();

            // Act
            var hasAttr = challenge
                .GetType()
                .GetProperty(nameof(Challenge.Title))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
