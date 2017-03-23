using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.UserTests
{
    [TestFixture]
    public class FirstName_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arrange
            var propType = typeof(User)
                .GetProperty(nameof(User.FirstName))
                .PropertyType;

            // Assert
            Assert.IsTrue(propType == typeof(string));
        }

        [Test]
        public void Has_MinLengthAttribute()
        {
            // Arrange
            bool hasAttrMinLength = typeof(User)
                .GetProperty(nameof(User.FirstName))
                .GetCustomAttributes(false)
                .Any(x => x.GetType() == typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(hasAttrMinLength);
        }

        [Test]
        public void Has_MaxLengthAttribute()
        {
            // Arrange
            bool hasAttrMaxLength = typeof(User)
                .GetProperty(nameof(User.FirstName))
                .GetCustomAttributes(false)
                .Any(x => x.GetType() == typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(hasAttrMaxLength);
        }
    }
}
