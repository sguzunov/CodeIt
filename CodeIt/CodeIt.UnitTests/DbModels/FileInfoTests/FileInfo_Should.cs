using NUnit.Framework;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.DbModels.FileInfoTests
{
    [TestFixture]
    public class FileInfo_Should
    {
        [Test]
        public void Be_AbstractBaseClass()
        {
            // Arrange & Act
            bool isAbstractClass = typeof(FileInfo).IsAbstract;

            // Assert
            Assert.IsTrue(isAbstractClass);
        }
    }
}
