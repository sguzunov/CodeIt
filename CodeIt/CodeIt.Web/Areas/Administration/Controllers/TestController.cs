using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.ViewModels;
using System;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class TestController : AdministrationController
    {
        private readonly ITestsService tests;

        public TestController(ITestsService tests)
        {
            Guard.WhenArgument(tests, nameof(tests)).IsNull().Throw();

            this.tests = tests;
        }

        [HttpGet]
        public ActionResult ByChallengeId(string id)
        {
            var tests = this.tests.GetByChallenge<ChallengeTestAdministrationViewModel>(Guid.Parse(id));
            return this.View(tests);
        }

        [HttpPost]
        public ActionResult Update(ChallengeTestAdministrationViewModel challenge, string returnUrlId)
        {
            this.tests.Update(challenge.Id, challenge.Input, challenge.Output);

            return this.RedirectToAction(nameof(TestController.ByChallengeId), new { id = returnUrlId });
        }

        public ActionResult Delete(string id)
        {
            this.tests.DeleteById(Guid.Parse(id));

            return new HttpStatusCodeResult(200);
        }
    }
}