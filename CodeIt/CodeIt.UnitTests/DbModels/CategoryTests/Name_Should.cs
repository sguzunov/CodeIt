using System.ComponentModel.DataAnnotations;
using System.Linq;

using CodeIt.Data.Models;
using NUnit.Framework;

namespace CodeIt.UnitTests.DbModels.CategoryTests
{
    [TestFixture]
    public class Name_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arrange
            var category = new Category();
            category.Name = "catgory";

            // Act & Assert
            Assert.IsTrue(category.Name.GetType() == typeof(string));
        }

        [Test]
        public void Have_RequiredAttribute()
        {
            // Arrange
            var category = new Category();

            // Act
            var hasAttr = category
                .GetType()
                .GetProperty(nameof(Category.Name))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Assert
            Assert.IsTrue(hasAttr);
        }
    }
}
