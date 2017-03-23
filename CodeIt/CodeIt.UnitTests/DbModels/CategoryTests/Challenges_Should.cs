using System.Collections.Generic;

using CodeIt.Data.Models;

using NUnit.Framework;

namespace CodeIt.UnitTests.DbModels.CategoryTests
{
    [TestFixture]
    public class Challenges_Should
    {
        [Test]
        public void Have_GetterAndSetterWorking_Correctly()
        {
            // Arrange
            var category = new Category();
            var challenges = new List<Challenge>();
            category.Challenges = challenges;

            // Act & Assert
            Assert.AreSame(category.Challenges, challenges);
        }
    }
}
