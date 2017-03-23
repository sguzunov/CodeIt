using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class TimeInMs_Should
    {
        [Test]
        public void Be_OfTypeInt()
        {
            // Arrange
            var challenge = new Challenge();

            // Act & Assert
            Assert.IsTrue(challenge.TimeInMs.GetType() == typeof(int));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arrange
            var challenge = new Challenge();

            // Act
            var hasAttr = challenge
                .GetType()
                .GetProperty(nameof(Challenge.TimeInMs))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
