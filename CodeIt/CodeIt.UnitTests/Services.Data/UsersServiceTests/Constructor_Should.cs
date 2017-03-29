using NUnit.Framework;
using System;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.UsersServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsArgumentNullException_When_UsersRepository_IsNull()
        {
            // Arrange
            IEfRepository<User> usersRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UsersService(usersRepository));
        }
    }
}
