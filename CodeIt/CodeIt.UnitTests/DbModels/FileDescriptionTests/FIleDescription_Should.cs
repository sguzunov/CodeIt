using NUnit.Framework;
using CodeIt.Data.Models;
using System.Linq;

namespace CodeIt.UnitTests.DbModels.FileDescriptionTests
{
    [TestFixture]
    public class FileDescription_Should
    {
        [Test]
        public void Has_BaseTypeOfTypeFileInfo()
        {
            // Arrange
            var baseType = typeof(FileDecription).BaseType;

            // Act & Assert
            Assert.IsTrue(baseType == typeof(FileInfo));
        }

        [Test]
        public void Has_NavigationPropertyOfTypeChallenge()
        {
            // Arrange & Act
            bool hasPropOfTypeChallenge = typeof(FileDecription)
                .GetProperties()
                .Any(x => x.PropertyType == typeof(Challenge));

            Assert.IsTrue(hasPropOfTypeChallenge);
        }
    }
}