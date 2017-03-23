using System.Linq;
using NUnit.Framework;
using CodeIt.Data.Models;

namespace CodeIt.UnitTests.DbModels.TestModelTests
{
    [TestFixture]
    public class Test_Should
    {
        [Test]
        public void Has_NavigationPropertyOfTypeChallenge()
        {
            bool hasNavigationPropChallange = typeof(Test)
                .GetProperties()
                .Any(x => x.PropertyType == typeof(Challenge));

            Assert.IsTrue(hasNavigationPropChallange);
        }
    }
}
