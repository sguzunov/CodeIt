using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class MemoryInKb_Should
    {
        [Test]
        public void Be_OfTypeInt()
        {
            // Arrange
            var challenge = new Challenge();

            // Act & Assert
            Assert.IsTrue(challenge.MemoryInKb.GetType() == typeof(int));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arrange
            var challenge = new Challenge();

            // Act
            var hasAttr = challenge
                .GetType()
                .GetProperty(nameof(Challenge.MemoryInKb))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
