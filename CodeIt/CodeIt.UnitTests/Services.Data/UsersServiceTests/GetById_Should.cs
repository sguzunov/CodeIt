using System;
using NUnit.Framework;
using Moq;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Data;

namespace CodeIt.UnitTests.Services.Data.UsersServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void Call_UsersRepositoryGetById_WithCorrectParam()
        {
            var usersRepoFake = new Mock<IEfRepository<User>>();

            var service = new UsersService(usersRepoFake.Object);

            string passedId = default(string);
            string userId = "123";
            var userFake = new Mock<User>();
            usersRepoFake.Setup(x => x.GetById(It.IsAny<string>())).Returns(userFake.Object)
                .Callback<string>(x => passedId = x);

            // Act
            service.GetById(userId);

            // Assert
            Assert.AreEqual(passedId, userId);
        }

        [Test]
        public void ThrowsArgumentException_When_NoUserFound()
        {
            var usersRepoFake = new Mock<IEfRepository<User>>();

            var service = new UsersService(usersRepoFake.Object);

            User user = null;
            usersRepoFake.Setup(x => x.GetById(It.IsAny<string>())).Returns(user);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.GetById(It.IsAny<string>()));
        }

        [Test]
        public void Return_TheUser_ReturnedByTheRepository()
        {
            var usersRepoFake = new Mock<IEfRepository<User>>();

            var service = new UsersService(usersRepoFake.Object);

            var userFake = new Mock<User>();
            usersRepoFake.Setup(x => x.GetById(It.IsAny<string>())).Returns(userFake.Object);

            // Act
            var actualUser = service.GetById(It.IsAny<string>());

            // Assert
            Assert.AreSame(userFake.Object, actualUser);
        }
    }
}
