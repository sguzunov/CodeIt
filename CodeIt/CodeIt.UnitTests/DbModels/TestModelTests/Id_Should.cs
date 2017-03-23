using System;
using NUnit.Framework;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.DbModels.TestModelTests
{
    [TestFixture]
    public class Id_Should
    {
        [Test]
        public void Be_OfTypeGuid()
        {
            // Arrange
            var propType = typeof(Test).GetProperty(nameof(Test.Id)).PropertyType;

            // Act & Assert
            Assert.IsTrue(propType == typeof(Guid));
        }
    }
}
