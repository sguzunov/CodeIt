using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.UnitTests.DbModels.FileInfoTests
{
    [TestFixture]
    public class FileName_Should
    {
        [Test]
        public void Be_OfTypeString()
        {
            // Arange
            var fileNamePropType = typeof(FileInfo).GetProperty(nameof(FileInfo.FileName)).PropertyType;

            // Act & Assert
            Assert.IsTrue(fileNamePropType == typeof(string));
        }

        [Test]
        public void Has_RequiredAttribute()
        {
            // Arange
            var hasAttrRequired =
                typeof(FileInfo)
                .GetProperty(nameof(FileInfo.FileName))
                .GetCustomAttributes(false)
                .Where(x => x.GetType() == typeof(RequiredAttribute))
                .Any();

            // Act & Assert
            Assert.IsTrue(hasAttrRequired);
        }
    }
}
