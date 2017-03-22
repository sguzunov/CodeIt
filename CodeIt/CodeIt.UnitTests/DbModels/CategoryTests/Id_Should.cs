using System;

using CodeIt.Data.Models;

using NUnit.Framework;

namespace CodeIt.UnitTests.DbModels.CategoryTests
{
    [TestFixture]
    public class Id_Should
    {
        [Test]
        public void Be_OfTypeGuid()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            Assert.IsTrue(category.Id.GetType() == typeof(Guid));
        }
    }
}
