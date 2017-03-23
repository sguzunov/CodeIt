using System.Collections.Generic;
using NUnit.Framework;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.DbModels.ChallengeTests
{
    [TestFixture]
    public class Tests_Should
    {
        [Test]
        public void Have_GetterAndSetterWorking_Correctly()
        {
            // Arrange
            var challenge = new Challenge();
            var tests = new List<Test>();
            challenge.Tests = tests;

            // Act & Assert
            Assert.AreSame(challenge.Tests, tests);
        }
    }
}
