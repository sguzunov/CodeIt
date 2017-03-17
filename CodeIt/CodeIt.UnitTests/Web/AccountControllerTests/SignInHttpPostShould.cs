using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeIt.Web.Controllers;

using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;
using CodeIt.Web.Models.Account;
using CodeIt.Web.Auth.Contracts;

namespace CodeIt.UnitTests.Web.AccountControllerTests
{
    [TestFixture]
    public class SignInHttpPostShould
    {
        //[Test]
        //public void RenderTheSameView_WhenModelState_IsInvalid()
        //{
        //    // Arrange
        //    var fakeAuthService = new Mock<IAuthenticationService>();
        //    var controller = new AccountController(fakeAuthService.Object);
        //    var vModel = this.CreateViewModel("pesho1", "123123", false);

        //    // Act & Assert
        //    controller.WithCallTo(x => x.SignIn(vModel, "url")).ShouldRenderView("SignIn");
        //}

        private SignInViewModel CreateViewModel(string username, string password, bool rememberMe)
        {
            var vModel = new SignInViewModel
            {
                Username = username,
                Password = password,
                RememberMe = rememberMe
            };

            return vModel;
        }
    }
}
