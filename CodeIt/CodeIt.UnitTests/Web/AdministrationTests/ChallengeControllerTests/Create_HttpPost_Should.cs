using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Services.Logic.Contracts;
using CodeIt.Web.Areas.Administration.Controllers;
using CodeIt.Web.Areas.Administration.ViewModels.Challenge;
using CodeIt.Web.Infrastructure.FileSystem;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace CodeIt.UnitTests.Web.AdministrationTests.ChallengeControllerTests
{
    [TestFixture]
    public class Create_HttpPost_Should
    {
        //[Test]
        //public void ReturnSameView_WhenModelStateIsNotValid()
        //{
        //    var tracksServiceFake = new Mock<ITracksService>();
        //    var challengesServiceFake = new Mock<IChallengesService>();
        //    var mapperFake = new Mock<IMappingProvider>();
        //    var fileSystemFake = new Mock<IFileSystemService>();
        //    var fileUtilsFake = new Mock<IFileUnits>();

        //    var controller = new ChallengeController(
        //        tracksServiceFake.Object,
        //        challengesServiceFake.Object,
        //        fileSystemFake.Object,
        //        mapperFake.Object,
        //        fileUtilsFake.Object);

        //    controller.WithCallTo(x => x.Create(new ChallengeAdministrationViewModel()))
        //        .ShouldRenderDefaultView()
        //        .WithModel<ChallengeAdministrationViewModel>()
        //        .AndModelErrorFor(x => x.Title);
        //}
    }
}
