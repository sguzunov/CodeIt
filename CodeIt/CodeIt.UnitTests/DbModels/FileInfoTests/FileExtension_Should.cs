using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.FileInfoTests
{
    [TestFixture]
    public class FileExtension_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arange
            var fileExtPropType = typeof(FileInfo).GetProperty(nameof(FileInfo.FileExtension)).PropertyType;

            // Act & Assert
            Assert.IsTrue(fileExtPropType == typeof(string));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arange
            var hasAttrRequired =
                typeof(FileInfo)
                .GetProperty(nameof(FileInfo.FileExtension))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Act & Assert
            Assert.IsTrue(hasAttrRequired);
        }
    }
}
