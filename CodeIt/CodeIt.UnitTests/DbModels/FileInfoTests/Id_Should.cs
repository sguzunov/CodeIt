using System;
using NUnit.Framework;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.DbModels.FileInfoTests
{
    [TestFixture]
    public class Id_Should
    {
        [Test]
        public void Be_OfTypeGuid()
        {
            // Arrange
            var idPropType = typeof(FileInfo).GetProperty(nameof(FileInfo.Id)).PropertyType;

            // Act & Assert
            Assert.IsTrue(idPropType == typeof(Guid));
        }
    }
}
