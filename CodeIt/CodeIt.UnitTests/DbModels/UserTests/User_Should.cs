using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CodeIt.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeIt.UnitTests.DbModels.UserTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void Inherit_IdentityUser()
        {
            // Arrange
            var baseType = typeof(User).BaseType;

            // Act & Assert
            Assert.IsTrue(baseType == typeof(IdentityUser));
        }
    }
}
