using CodeIt.Data.Models;
using NUnit.Framework;
using System;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class CategoryNavigation_Should
    {
        [Test]
        public void HaveIdProp_OfTypeGuid()
        {
            // Arrange
            var challenge = new Challenge();

            // Act & Assert
            Assert.IsTrue(challenge.CategoryId.GetType() == typeof(Guid));
        }

        [Test]
        public void HaveProp_OfTypeCategory()
        {
            // Arrange
            var category = new Challenge();
            category.Category = new Category();

            // Act & Assert
            Assert.IsTrue(category.Category.GetType() == typeof(Category));
        }
    }
}
