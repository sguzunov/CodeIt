using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeIt.UnitTests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestIsTrue()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestIsFalse()
        {
            Assert.IsFalse(true);
        }
    }
}
