using CodeIt.Data.Models;
using NUnit.Framework;
using System;

namespace CodeIt.UnitTests.DbModels.TrackTests
{
    [TestFixture]
    public class Id_Should
    {
        [Test]
        public void Be_OfTypeGuid()
        {
            // Arrange
            var propType = typeof(Track).GetProperty(nameof(Test.Id)).PropertyType;

            // Act & Assert
            Assert.IsTrue(propType == typeof(Guid));
        }
    }
}
