using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.TestModelTests
{
    [TestFixture]
    public class Input_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arrange
            var propType = typeof(Test).GetProperty(nameof(Test.Input)).PropertyType;

            // Act & Assert
            Assert.IsTrue(propType == typeof(string));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arrange & Act
            var hasAttrRequired =
                typeof(Test)
                .GetProperty(nameof(Test.Input))
                .GetCustomAttributes(false)
                .Any(x => x.GetType() == typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(hasAttrRequired);
        }
    }
}
