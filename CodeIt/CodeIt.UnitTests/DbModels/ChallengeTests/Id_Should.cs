using System;

using CodeIt.Data.Models;

using NUnit.Framework;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class Id_Should
    {
        [Test]
        public void Be_OfTypeGuid()
        {
            // Arrange
            var challenge = new Challenge();

            // Act & Assert
            Assert.IsTrue(challenge.Id.GetType() == typeof(Guid));
        }
    }
}
