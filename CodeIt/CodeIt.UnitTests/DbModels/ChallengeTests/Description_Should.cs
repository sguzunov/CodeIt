using CodeIt.Data.Models;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class Description_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arrange
            var challenge = new Challenge();
            challenge.Description = "some text";

            // Act & Assert
            Assert.IsTrue(challenge.Description.GetType() == typeof(string));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arrange
            var challenge = new Challenge();

            // Act
            var hasAttr = challenge
                .GetType()
                .GetProperty(nameof(Challenge.Description))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
